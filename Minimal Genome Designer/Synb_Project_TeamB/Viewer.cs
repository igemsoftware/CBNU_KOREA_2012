﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Synb_Project_TeamB
{
    public partial class Viewer : Form
    {
        Home_View HV;
        PictureBox Arrow = null;
        Graphics Ag = null;
        private int zoomSize;
        private int startPoint;
        private int endPoint;

        private int x, y;

        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;
        private double x4;
        private double y4;

        private bool LoadImage = false;
        private int length;
        private Random Color_Random;
        List<Color> Color_List;
        Color[] Cog_Color;
        List<int> Deg_index;
        List<int> EG_index;
        List<int> Cog_index;

        private bool Mode_Change = true;

        Rectangle[] Linear_Block;
        Rectangle[] Deg_Block;

        private int[] DStartPoint;
        private int[] DEndPoint;

        double CenterX, CenterY;
        double radius;
        GraphicsPath[] Circular_Block;

        private int getCount;
        private Point Line_first;
        private Point Line_second;
        private Point[] verticalline_first;
        private Point[] verticalline_second;

        private Pen line_pen;
        private Pen Fill_pen;
        private bool isLininit = false;
        private Font font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
        private StringFormat stringformat;
        private Bitmap bmp;
        private int rearmaximum;
        Brush blackBrush;

        private double Gijun;

        TransControl Region_Circle = null;

        //         PictureBox Temp_PictureBox = null;
        //         PictureBox Temp_LineBox = null;
        //         private int Block_temp;                             //사각형 범위가 초과하면 나타나는 변수
        public Viewer()
        {
            InitializeComponent();
        }
        public Viewer(Home_View _HV)
        {
            HV = _HV;
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
            Region_Circle = new TransControl(this);
            CircularBox.Controls.Add(Region_Circle);
            Region_Circle.Visible = false;
            Region_Circle.Size = new Size(60, 60);

            LinearPanel.HorizontalScroll.Visible = false;
            this.initTaxonomyTree();
            Cog_Combo.Text = "ALL";
            Cog_Combo.SendToBack();

            Color_List = new List<Color>();
            Deg_index = new List<int>();
            EG_index = new List<int>();
            Cog_index = new List<int>();

        }

        public void initTaxonomyTree()
        {

            TreeNode rootNode = new TreeNode();
            rootNode.Text = "Streptococcus";

            String query = "Select * from Synb_View.taxonomyTree";
            ViewerData.treeList_reader(query);

            int numOfList = ViewerData.getNodeCount();

            rootNode.Text = rootNode.Text + "(" + numOfList + ")";

            String lastSpecies = "";

            TreeNode speciesNode = new TreeNode();

            int streinCnt = 0;

            for (int i = 0; i < numOfList; i++)
            {
                String strein = ViewerData.getNodeName(i);

                //스트레인 이름을 잘라서 종 이름을 가져온다.
                String species = strein.Substring(0, strein.IndexOf(" ", strein.IndexOf(" ") + 1));

                if (lastSpecies.Equals(species))
                {
                    speciesNode.Nodes.Add("key", strein, "leapnode");
                    streinCnt++;
                }
                else
                {
                    if (i != 0)
                    {
                        speciesNode.Text = speciesNode.Text + "(" + (streinCnt + 1) + ")";
                        rootNode.Nodes.Add(speciesNode);
                        speciesNode = null;
                    }
                    speciesNode = new TreeNode();
                    speciesNode.Text = species;
                    speciesNode.Nodes.Add("key", strein, "leapnode");
                    lastSpecies = species;

                    streinCnt = 0;
                }
            }

            TVtaxoTree.Nodes.Add(rootNode);
            rootNode.Expand();
        }

        private void onViewClose(object sender, FormClosedEventArgs e)
        {
            HV.Show();
        }

        private void BTviewGenome_Click(object sender, EventArgs e)
        {
            //선택한 리스트 정보를 이용해 뷰 시작

        }

        private void TVtaxoTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ((e.Action) == TreeViewAction.ByMouse && e.Node.ImageKey.Equals("leapnode"))
            {
                isLininit = false;


                String tableName = e.Node.Text.Replace("-", "_").Replace("/", "").Replace(".", "").Replace(" ", "_");
                HistoryList.Items.Add((String)tableName);
                String query = "Select * from Synb_View.A_" + tableName;
                LinearBox.SizeMode = PictureBoxSizeMode.AutoSize;

                GeneName.Text = tableName;
                Species.Text = e.Node.Parent.Text;

                TBstrand.Text = "";
                TBnc.Text = "";
                TBdeg.Text = "";
                NA_LENGTH.Text = "";
                Start.Text = "";
                D_End.Text = "";
                TERM.Text = "";
                Product.Text = "";
                Sequence.Text = "";

                this.Linear_init(query);

                Graphics g = LinearBox.CreateGraphics();
                Graphics lg = Linear_Line.CreateGraphics();
                Graphics cg = CircularBox.CreateGraphics();


                g.SmoothingMode = SmoothingMode.HighSpeed;
                lg.SmoothingMode = SmoothingMode.HighSpeed;
                cg.SmoothingMode = SmoothingMode.HighQuality;

                this.LinearBrowserComponent(g, lg);
                this.CircularBrowserComponent(cg);
                LoadImage = true;
            }
        }

        private void Linear_init(string query)
        {
            CKGroup.Visible = true;
            GBgenomeInfo.Visible = true;
            GBgeneInfo.Visible = true;
            Design_GB.Visible = false;



            Mode_Change = true;
            //신비 테이블 접속
            try
            {
                ViewerData.Synb_reader(query);
                zoomSize = 37;
                startPoint = 0;
                endPoint = 0;
                CenterX = CircularBox.Width / 2;
                CenterY = CircularBox.Height / 2;

                Color_Random = new Random();
                //                 Color_List = new List<Color>();
                Deg_index.Clear();
                EG_index.Clear();
                Cog_index.Clear();
                getCount = ViewerData.Synb_View_getCount();
                NumofGene.Text = Convert.ToString(getCount);
                Double a = 2 * Math.PI / Convert.ToInt32(ViewerData.Synb_View_getEnd(getCount - 1));
                radius = CircularBox.Height / 2 - 15;
                if (Linear_Block != null)
                    Linear_Block = null;
                Linear_Block = new Rectangle[getCount];
                Deg_Block = new Rectangle[getCount];
                if (Cog_Color != null)
                    Cog_Color = null;
                Cog_Color = new Color[getCount];
                Circular_Block = new GraphicsPath[getCount];

                for (int i = 0; i < getCount; i++)
                {
                    startPoint = Convert.ToInt32(ViewerData.Synb_View_getStart(i));
                    endPoint = Convert.ToInt32(ViewerData.Synb_View_getEnd(i));
                    length = endPoint - startPoint;
                    if (ViewerData.Synb_View_getStrand(i).Equals("+"))
                    {
                        Linear_Block[i] = new Rectangle(
                            (startPoint / zoomSize), 30, (length / zoomSize), 35);
                    }
                    else
                    {
                        Linear_Block[i] = new Rectangle(
                            (startPoint / zoomSize), 65, (length / zoomSize), 35);
                    }

                    /*
                     * 
                     * 필수 유전자를 확인하여 인덱스 값을 기록하여 둔다.
                     * 
                    */

                    if (ViewerData.Synb_View_getDEG(i).Equals("+") && ViewerData.Synb_View_getType(i).Equals("CDS"))
                    {
                        Deg_index.Add(i);
                    }
                    if (ViewerData.Synb_View_getEG(i).Equals("+") && ViewerData.Synb_View_getType(i).Equals("CDS"))
                    {
                        EG_index.Add(i);
                    }
                    if (!ViewerData.Synb_View_getCog(i).Equals("null"))
                    {
                        Cog_Color[i] = CogColor(ViewerData.Synb_View_getCog(i));
                        Cog_index.Add(i);
                    }
                    NumOfDEG.Text = Convert.ToString(Deg_index.Count);
                    NumOfEG.Text = Convert.ToString(EG_index.Count);
                    Len.Text = Convert.ToString(Convert.ToInt32(ViewerData.Synb_View_getEnd(getCount - 1)) - Convert.ToInt32(ViewerData.Synb_View_getStart(0)));


                    Color_List.Add(
                        Color.FromArgb(Color_Random.Next(256), Color_Random.Next(256), Color_Random.Next(256)));
                    x1 = CenterX - radius * Math.Sin(-a * startPoint) * 0.75;
                    y1 = CenterY - radius * Math.Cos(-a * startPoint) * 0.75;
                    x2 = CenterX - radius * Math.Sin(-a * startPoint) * 0.95;
                    y2 = CenterY - radius * Math.Cos(-a * startPoint) * 0.95;
                    x3 = CenterX - radius * Math.Sin(-a * endPoint) * 0.95;
                    y3 = CenterY - radius * Math.Cos(-a * endPoint) * 0.95;
                    x4 = CenterX - radius * Math.Sin(-a * endPoint) * 0.75;
                    y4 = CenterY - radius * Math.Cos(-a * endPoint) * 0.75;
                    Circular_Block[i] = new GraphicsPath();

                    Circular_Block[i].AddLine((float)x1, (float)y1, (float)x2, (float)y2);
                    Circular_Block[i].AddLine((float)x2, (float)y2, (float)x3, (float)y3);
                    Circular_Block[i].AddLine((float)x3, (float)y3, (float)x4, (float)y4);
                    Circular_Block[i].AddLine((float)x4, (float)y4, (float)x1, (float)y1);
                }
                verticalline_first = new Point[endPoint / 10000 + 2];
                verticalline_second = new Point[endPoint / 10000 + 2];


                Size sz = new Size();
                sz.Width = (endPoint / zoomSize) + 15;

                sz.Height = 100;
                LinearPanel.AutoScrollMinSize = sz;

                Line_first = new Point(0, 15);
                Line_second = new Point(endPoint / zoomSize, 15);
                line_pen = new Pen(Color.Black, 1);
                Fill_pen = new Pen(Color.Black, 3);
                stringformat = new StringFormat();
                stringformat.Alignment = StringAlignment.Center;
                stringformat.LineAlignment = StringAlignment.Center;



                blackBrush = new SolidBrush(Color.Black);

                for (int i = 0; i < verticalline_second.Length - 1; i++)
                {
                    verticalline_first[i].X = i * ((endPoint / zoomSize) / (endPoint / 10000));
                    verticalline_first[i].Y = 5;
                    verticalline_second[i].X = i * ((endPoint / zoomSize) / (endPoint / 10000));
                    verticalline_second[i].Y = 20;
                }
                verticalline_first[verticalline_second.Length - 1].X = (endPoint / zoomSize) - 3;
                verticalline_first[verticalline_second.Length - 1].Y = 5;
                verticalline_second[verticalline_second.Length - 1].X = (endPoint / zoomSize) - 3;
                verticalline_second[verticalline_second.Length - 1].Y = 20;

                isLininit = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //선형 을 그리는 함수
        public void LinearBrowserComponent(Graphics g, Graphics lg)
        {
            try
            {
                g.Clear(Color.White);
                lg.Clear(Color.White);
                if (!DEGCheck.Checked && !EGCheck.Checked && !IsCog.Checked)
                {
                    for (int i = 0; i < Linear_Block.Length; i++)
                    {
                        SolidBrush MyBrush = new SolidBrush(Color.FromArgb(Color_List[i].R, Color_List[i].G, Color_List[i].B));
                        g.FillRectangle(MyBrush, Linear_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                else if (DEGCheck.Checked && !EGCheck.Checked && !IsCog.Checked)
                {
                    foreach (int i in Deg_index)
                    {
                        SolidBrush MyBrush = new SolidBrush(Color.Red);
                        g.FillRectangle(MyBrush, Linear_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                else if (!DEGCheck.Checked && EGCheck.Checked && !IsCog.Checked)
                {
                    foreach (int i in EG_index)
                    {
                        SolidBrush MyBrush = new SolidBrush(Color.Blue);
                        g.FillRectangle(MyBrush, Linear_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                else if (!DEGCheck.Checked && !EGCheck.Checked && IsCog.Checked)
                {
                    foreach (int i in Cog_index)
                    {
                        SolidBrush MyBrush = new SolidBrush(Cog_Color[i]);
                        g.FillRectangle(MyBrush, Linear_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                lg.DrawLine(line_pen, Line_first, Line_second);
                lg.DrawString(0 + "", font, blackBrush, new Point(2, 23));
                for (int i = 0; i < verticalline_first.Length - 2; i++)
                {
                    if (i % 5 == 0)
                    {
                        lg.DrawLine(Fill_pen, verticalline_first[i], verticalline_second[i]);
                    }
                    else
                        lg.DrawLine(line_pen, verticalline_first[i], verticalline_second[i]);
                    if(Mode_Change)
                        lg.DrawString(i * 10000 + "", font, blackBrush, new Point(verticalline_first[i].X - 20, 23));
                    else
                        lg.DrawString(i * 1000 + "", font, blackBrush, new Point(verticalline_first[i].X - 20, 23));
                }
                lg.DrawLine(Fill_pen, verticalline_first[verticalline_first.Length - 1], verticalline_second[verticalline_first.Length - 1]);
                if(Mode_Change)
                    lg.DrawString(endPoint + "", font, blackBrush, new Point(verticalline_first[verticalline_first.Length - 1].X - 25, 23));
                else
                    lg.DrawString(DEndPoint[DEndPoint.Length-1] + "", font, blackBrush, new Point(verticalline_first[verticalline_first.Length - 1].X - 25, 23));
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Error" + e.ToString());
            }
            LinearPanel.HorizontalScroll.Value = LinearPanel.HorizontalScroll.Maximum;
            rearmaximum = LinearPanel.HorizontalScroll.LargeChange;
            Gijun = LinearPanel.HorizontalScroll.Maximum - rearmaximum;
        }

        private void LinearBox_Paint(object sender, PaintEventArgs e)
        {
            if (isLininit == true)
            {
                Graphics _g = e.Graphics;
                _g.Clear(Color.White);
                if (!DEGCheck.Checked && !EGCheck.Checked && !IsCog.Checked)
                {
                    for (int i = 0; i < Linear_Block.Length; i++)
                    {
                        SolidBrush MyBrush = new SolidBrush(Color.FromArgb(Color_List[i].R, Color_List[i].G, Color_List[i].B));
                        _g.FillRectangle(MyBrush, Linear_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                else if (DEGCheck.Checked && !EGCheck.Checked && !IsCog.Checked)
                {
                    foreach (int i in Deg_index)
                    {
                        SolidBrush MyBrush = new SolidBrush(Color.Red);
                        _g.FillRectangle(MyBrush, Linear_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                else if (!DEGCheck.Checked && EGCheck.Checked && !IsCog.Checked)
                {
                    foreach (int i in EG_index)
                    {
                        SolidBrush MyBrush = new SolidBrush(Color.Blue);
                        _g.FillRectangle(MyBrush, Linear_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                else if (!DEGCheck.Checked && !EGCheck.Checked && IsCog.Checked)
                {
                    foreach (int i in Cog_index)
                    {
                        SolidBrush MyBrush = new SolidBrush(Cog_Color[i]);
                        _g.FillRectangle(MyBrush, Linear_Block[i]);
                        MyBrush.Dispose();
                    }
                }
            }
        }

        private void Linear_Line_Paint(object sender, PaintEventArgs e)
        {
            if (isLininit == true)
            {
                Graphics _lg = e.Graphics;
                _lg.Clear(Color.White);
                _lg.DrawLine(line_pen, Line_first, Line_second);
                _lg.DrawString(0 + "", font, blackBrush, new Point(2, 23));

                for (int i = 0; i < verticalline_first.Length - 2; i++)
                {
                    if (i % 5 == 0)
                    {
                        _lg.DrawLine(Fill_pen, verticalline_first[i], verticalline_second[i]);
                    }
                    else
                        _lg.DrawLine(line_pen, verticalline_first[i], verticalline_second[i]);

                    if (Mode_Change)
                        _lg.DrawString(i * 10000 + "", font, blackBrush, new Point(verticalline_first[i].X - 20, 23));
                    else
                        _lg.DrawString(i * 1000 + "", font, blackBrush, new Point(verticalline_first[i].X - 20, 23));
                }
                _lg.DrawLine(Fill_pen, verticalline_first[verticalline_first.Length - 1], verticalline_second[verticalline_first.Length - 1]);
                if (Mode_Change)
                    _lg.DrawString(endPoint + "", font, blackBrush, new Point(verticalline_first[verticalline_first.Length - 1].X - 25, 23));
                else
                    _lg.DrawString(DEndPoint[DEndPoint.Length - 1] + "", font, blackBrush, new Point(verticalline_first[verticalline_first.Length - 1].X - 25, 23));
            }
        }



        public void PanelControl(double i, double Lth)
        {
            double Bunbae = Gijun / Lth;
            LinearPanel.HorizontalScroll.Value = (int)(i * Bunbae);
        }



        //원형을 그리는 함수

        public void CircularBrowserComponent(Graphics cg)
        {
            try
            {
                Region_Circle.Visible = false;
                cg.Clear(Color.White);
                cg.DrawEllipse(line_pen, (float)(CenterX - radius - 2), (float)(CenterY - radius - 2), (float)(2 * radius + 4), (float)(2 * radius + 4));
                if (!DEGCheck.Checked && !EGCheck.Checked && !IsCog.Checked)
                {
                    for (int i = 0; i < Circular_Block.Length; i++)
                    {
                        SolidBrush MyBrush = new SolidBrush(Color.FromArgb(Color_List[i].R, Color_List[i].G, Color_List[i].B));
                        cg.FillPath(MyBrush, Circular_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                else if (DEGCheck.Checked && !EGCheck.Checked && !IsCog.Checked)
                {
                    foreach (int i in Deg_index)
                    {
                        SolidBrush MyBrush = new SolidBrush(Color.Red);
                        cg.FillPath(MyBrush, Circular_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                else if (!DEGCheck.Checked && EGCheck.Checked && !IsCog.Checked)
                {
                    foreach (int i in EG_index)
                    {
                        SolidBrush MyBrush = new SolidBrush(Color.Blue);
                        cg.FillPath(MyBrush, Circular_Block[i]);
                        MyBrush.Dispose();
                    }
                }
                else if (!DEGCheck.Checked && !EGCheck.Checked && IsCog.Checked)
                {
                    if (Cog_index.Count != 0)
                    {
                        foreach (int i in Cog_index)
                        {
                            SolidBrush MyBrush = new SolidBrush(Cog_Color[i]);
                            cg.FillPath(MyBrush, Circular_Block[i]);
                            MyBrush.Dispose();
                        }

                    }
                }

                CircularBox_line(cg);
                bmp = new Bitmap(CircularBox.Width, CircularBox.Height);
                Graphics Temp = Graphics.FromImage(bmp);
                Temp.CopyFromScreen
                    (PointToScreen(new Point(this.Circular_Panel.Location.X + GBviews.Location.X, this.Circular_Panel.Location.Y + GBviews.Location.Y)),
                    new Point(0, 0), new Size(CircularBox.Width, CircularBox.Height));

                Region_Circle.Show();
                Region_Circle.Location = new Point((int)(CenterX * 0.915), 10);
                LinearPanel.HorizontalScroll.Value = 0;
            }
            catch (Exception e)
            {
            }

        }

        private void CircularBox_Paint(object sender, PaintEventArgs e)
        {
            if (isLininit == true)
            {
                Rectangle rec;
                rec = e.ClipRectangle;
                Graphics _cg = e.Graphics;
                _cg.SmoothingMode = SmoothingMode.HighSpeed;
                _cg.Clear(Color.White);
                _cg.DrawImage(bmp as Image, 0, 0);
            }
        }

        private void CircularBox_line(Graphics g)
        {
            try
            {
                if (Mode_Change)
                {
                    int decimalPoint = 1;
                    for (int i = 0; i < Convert.ToString(endPoint).Length - 2; i++)
                    {
                        decimalPoint = decimalPoint * 10;
                    }

                    int mat = endPoint / decimalPoint;

                    double range = 2 * Math.PI / endPoint * decimalPoint;

                    double t;

                    for (int k = 0; k < mat; k++)
                    {
                        t = -range * k;
                        g.DrawLine(Fill_pen, (float)(CenterX - radius * Math.Sin(t)), (float)(CenterY - radius * Math.Cos(t)),
                            (float)(CenterX - radius * Math.Sin(t) * 0.96), (float)(CenterY - radius * Math.Cos(t) * 0.96));
                        if (k % 5 == 0)
                        {
                            t = -range * k;
                            if ((CenterX - radius * Math.Sin(t) * 1.02) >= CenterX)
                            {
                                if ((CenterY - radius * Math.Cos(t) * 1.02) >= CenterY)
                                {
                                    g.DrawString(decimalPoint * k + "", font, blackBrush,
                                        (int)(CenterX - radius * Math.Sin(t) * 1.02), (int)(CenterY - radius * Math.Cos(t) * 1.02) + 10);
                                }
                                else
                                {
                                    g.DrawString(decimalPoint * k + "", font, blackBrush,
                                        (int)(CenterX - radius * Math.Sin(t) * 1.02), (int)(CenterY - radius * Math.Cos(t) * 1.02));
                                }
                            }
                            else
                            {
                                if (CenterY - radius * Math.Sin(t) * 1.02 >= CenterY)
                                {
                                    g.DrawString(decimalPoint * k + "", font, blackBrush,
                                        (int)(CenterX - radius * Math.Sin(t) * 1.02) - 50, (int)(CenterY - radius * Math.Cos(t) * 1.02) + 10);
                                }
                                else
                                {

                                    g.DrawString(decimalPoint * k + "", font, blackBrush,
                                        (int)(CenterX - radius * Math.Sin(t) * 1.02) - 50, (int)(CenterY - radius * Math.Cos(t) * 1.02));
                                }
                            }
                        }
                    }

                    for (int k = 0; k < mat; k++)
                    {
                        for (double j = 1; j < 5; j++)
                        {
                            t = -range * k + j * -range / 5;

                            g.DrawLine(line_pen, (float)(CenterX - radius * Math.Sin(t)), (float)(CenterY - radius * Math.Cos(t)),
                                (float)(CenterX - radius * Math.Sin(t) * 0.98), (float)(CenterY - radius * Math.Cos(t) * 0.98));
                        }
                    }

                    for (double j = 1; j < 5; j++)
                    {
                        t = -range * mat + j * -range / 5;

                        if (radius * Math.Sin(t) < 0)
                        {
                            break;
                        }
                        else
                        {
                            g.DrawLine(line_pen, (float)(CenterX - radius * Math.Sin(t)), (float)(CenterY - radius * Math.Cos(t)),
                                (float)(CenterX - radius * Math.Sin(t) * 0.98), (float)(CenterY - radius * Math.Cos(t) * 0.98));

                        }
                    }
                }
                else
                {
                    int decimalPoint = 1;
                    for (int i = 0; i < Convert.ToString(DEndPoint[DEndPoint.Length - 1]).Length - 2; i++)
                    {
                        decimalPoint = decimalPoint * 10;
                    }

                    int mat = DEndPoint[DEndPoint.Length - 1] / decimalPoint;

                    double range = 2 * Math.PI / DEndPoint[DEndPoint.Length - 1] * decimalPoint;

                    double t;

                    for (int k = 0; k < mat; k++)
                    {
                        t = -range * k;
                        g.DrawLine(Fill_pen, (float)(CenterX - radius * Math.Sin(t)), (float)(CenterY - radius * Math.Cos(t)),
                            (float)(CenterX - radius * Math.Sin(t) * 0.96), (float)(CenterY - radius * Math.Cos(t) * 0.96));
                        if (k % 5 == 0)
                        {
                            t = -range * k;
                            if ((CenterX - radius * Math.Sin(t) * 1.02) >= CenterX)
                            {
                                if ((CenterY - radius * Math.Cos(t) * 1.02) >= CenterY)
                                {
                                    g.DrawString(decimalPoint * k + "", font, blackBrush,
                                        (int)(CenterX - radius * Math.Sin(t) * 1.02), (int)(CenterY - radius * Math.Cos(t) * 1.02) + 10);
                                }
                                else
                                {
                                    g.DrawString(decimalPoint * k + "", font, blackBrush,
                                        (int)(CenterX - radius * Math.Sin(t) * 1.02), (int)(CenterY - radius * Math.Cos(t) * 1.02));
                                }
                            }
                            else
                            {
                                if (CenterY - radius * Math.Sin(t) * 1.02 >= CenterY)
                                {
                                    g.DrawString(decimalPoint * k + "", font, blackBrush,
                                        (int)(CenterX - radius * Math.Sin(t) * 1.02) - 50, (int)(CenterY - radius * Math.Cos(t) * 1.02) + 10);
                                }
                                else
                                {

                                    g.DrawString(decimalPoint * k + "", font, blackBrush,
                                        (int)(CenterX - radius * Math.Sin(t) * 1.02) - 50, (int)(CenterY - radius * Math.Cos(t) * 1.02));
                                }
                            }
                        }
                    }

                    for (int k = 0; k < mat; k++)
                    {
                        for (double j = 1; j < 5; j++)
                        {
                            t = -range * k + j * -range / 5;

                            g.DrawLine(line_pen, (float)(CenterX - radius * Math.Sin(t)), (float)(CenterY - radius * Math.Cos(t)),
                                (float)(CenterX - radius * Math.Sin(t) * 0.98), (float)(CenterY - radius * Math.Cos(t) * 0.98));
                        }
                    }

                    for (double j = 1; j < 5; j++)
                    {
                        t = -range * mat + j * -range / 5;

                        if (radius * Math.Sin(t) < 0)
                        {
                            break;
                        }
                        else
                        {
                            g.DrawLine(line_pen, (float)(CenterX - radius * Math.Sin(t)), (float)(CenterY - radius * Math.Cos(t)),
                                (float)(CenterX - radius * Math.Sin(t) * 0.98), (float)(CenterY - radius * Math.Cos(t) * 0.98));

                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("에러 " + e.Message);
            }
        }





        private void BTsearch_Click(object sender, EventArgs e)
        {
            this.searchTaxonomyTree(TBsearch.Text);
        }

        public void searchTaxonomyTree(String key)
        {
            TVtaxoTree.Nodes.Clear();
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "Streptococcus";

            String query = "Select * from Synb_View.taxonomyTree WHERE name like'%" + key + "%'";
            ViewerData.treeList_reader(query);

            int numOfList = ViewerData.getNodeCount();

            rootNode.Text = rootNode.Text + "(" + numOfList + ")";

            String lastSpecies = "";

            TreeNode speciesNode = new TreeNode();

            int streinCnt = 0;

            for (int i = 0; i < numOfList; i++)
            {
                String strein = ViewerData.getNodeName(i);

                //스트레인 이름을 잘라서 종 이름을 가져온다.
                String species = strein.Substring(0, strein.IndexOf(" ", strein.IndexOf(" ") + 1));

                if (lastSpecies.Equals(species))
                {
                    if (i == numOfList - 1)
                    {
                        speciesNode.Nodes.Add("key", strein, "leapnode");
                        streinCnt++;
                        speciesNode.Text = speciesNode.Text + "(" + (streinCnt + 1) + ")";
                        rootNode.Nodes.Add(speciesNode);
                    }
                    else
                    {
                        speciesNode.Nodes.Add("key", strein, "leapnode");
                        streinCnt++;
                    }
                }
                else
                {
                    if (i != 0)
                    {
                        speciesNode.Text = speciesNode.Text + "(" + (streinCnt + 1) + ")";
                        rootNode.Nodes.Add(speciesNode);
                        speciesNode = null;
                    }

                    speciesNode = new TreeNode();
                    speciesNode.Text = species;
                    speciesNode.Nodes.Add("key", strein, "leapnode");

                    lastSpecies = species;

                    streinCnt = 0;

                    if (i == numOfList - 1)
                    {
                        speciesNode.Text = speciesNode.Text + "(" + (streinCnt + 1) + ")";
                        rootNode.Nodes.Add(speciesNode);
                    }
                }
            }

            TVtaxoTree.Nodes.Add(rootNode);
            rootNode.Expand();
        }

        private void TBsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.BTsearch_Click(null, null);
        }

        private void BTdownSeq_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://naver.com");
            Down_ViewerData DVD = new Down_ViewerData();
            DVD.Show();
        }

        private void LinearBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point mPoint = new Point((ushort)e.X, (ushort)e.Y);
            if (Mode_Change)                                                    //일반 뷰어일 경우
            {
                for (int i = 0; i < getCount; i++)
                {
                    if ((Linear_Block[i].X <= mPoint.X) && ((Linear_Block[i].X + Linear_Block[i].Width) >= mPoint.X))
                    {
                        if (ViewerData.Synb_View_getType(i).Equals("CDS") ||
                            ViewerData.Synb_View_getType(i).Equals("tRNA") || ViewerData.Synb_View_getType(i).Equals("rRNA"))
                        {
                            if (Arrow != null)
                            {
                                Ag.Dispose();
                                Ag = null;
                                Arrow.Dispose();
                                Arrow = null;
                            }
                            if (!ViewerData.Synb_View_getID(i).Equals("null")) SynbId.Text = ViewerData.Synb_View_getID(i);
                            else SynbId.Text = "";

                            LocusTag.Text = ViewerData.Synb_View_getLocus(i);
                            Product.Text = ViewerData.Synb_View_getProduct(i);
                            Start.Text = ViewerData.Synb_View_getStart(i);
                            Emd.Text = ViewerData.Synb_View_getEnd(i);

                            if (!ViewerData.Synb_View_getTERM(i).Equals(("null"))) TERM.Text = ViewerData.Synb_View_getTERM(i);
                            else TERM.Text = "";

                            NA_LENGTH.Text = ViewerData.Synb_View_getNA(i);
                            Sequence.Text = ViewerData.Synb_View_getSec(i);
                            if (!ViewerData.Synb_View_getDeg(i).Equals("null"))
                                TBdeg.Text = ViewerData.Synb_View_getDeg(i);
                            else
                                TBdeg.Text = "";
                            TBnc.Text = ViewerData.Synb_View_getAccession(i);
                            TBstrand.Text = ViewerData.Synb_View_getStrand(i);

                            Arrow_Make((ushort)(Linear_Block[i].X + Linear_Block[i].Width / 2 - 10), 0);
                            break;
                        }
                    }
                }
            }
            else                                                //디자이너 뷰어일 경우
            {   
                for (int i = 0; i < getCount; i++)
                {
                    if ((Linear_Block[i].X <= mPoint.X) && ((Linear_Block[i].X + Linear_Block[i].Width) >= mPoint.X))
                    {
                        if (Arrow != null)
                        {
                            Ag.Dispose();
                            Ag = null;
                            Arrow.Dispose();
                            Arrow = null;
                        }
                        if (!Designer_data[i][0].Equals("null")) D_Synb_id.Text = Designer_data[i][0];
                        else D_Synb_id.Text = "";
                        ViewerData.Designer_SelectGene(Designer_data[i][0]);
                        D_Start.Text = Convert.ToString(DStartPoint[i]);
                        D_End.Text = Convert.ToString(DEndPoint[i]);
                        D_Length.Text = ViewerData.Designer_getLength();
                        //Sequence.Text = ViewerData.Synb_View_getSec(i);
                        Arrow_Make((ushort)(Linear_Block[i].X + Linear_Block[i].Width / 2 - 10), 0);
                        break;
                    }
                }
            }
        }

        private void Arrow_Make(ushort _x, ushort _y)
        {
            x = _x;
            y = _y;
            ArrowBox.Width = LinearBox.Width;
            Ag = ArrowBox.CreateGraphics();
            Ag.Clear(Color.White);
            Ag.DrawImage(Properties.Resources.arrow_down, (ushort)_x, (ushort)_y, 20, 20);
            ArrowBox.Paint += new PaintEventHandler(this.Arrow_Paint);
        }
        private void Arrow_Paint(object sender, PaintEventArgs e)
        {
            Graphics _g = e.Graphics;
            _g.Clear(Color.White);
            _g.DrawImage(Properties.Resources.arrow_down, x, y, 20, 20);
        }

        private void HistoryList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectPosition = -1;

            Point ePoint = e.Location;
            selectPosition = HistoryList.IndexFromPoint(ePoint);
            if (selectPosition != -1)
            {
                String query = "Select * from Synb_View." + HistoryList.Items[selectPosition] as String;
                LinearBox.SizeMode = PictureBoxSizeMode.AutoSize;


                this.Linear_init(query);

                Graphics g = LinearBox.CreateGraphics();
                Graphics lg = Linear_Line.CreateGraphics();
                Graphics cg = CircularBox.CreateGraphics();


                g.SmoothingMode = SmoothingMode.HighSpeed;
                lg.SmoothingMode = SmoothingMode.HighSpeed;
                cg.SmoothingMode = SmoothingMode.HighQuality;

                this.LinearBrowserComponent(g, lg);
                this.CircularBrowserComponent(cg);
            }
        }



        /*
         * 데그와 EG 체크박스
         * 
         */




        private void DEGCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadImage)
            {
                if (DEGCheck.Checked)
                {
                    if (EGCheck.Checked)
                        EGCheck.Checked = false;
                    if (IsCog.Checked)
                        IsCog.Checked = false;
                    Graphics cg = CircularBox.CreateGraphics();
                    cg.SmoothingMode = SmoothingMode.HighQuality;
                    CircularBrowserComponent(cg);
                    LinearBox.Invalidate();
                    Linear_Line.Invalidate();
                }
                else
                {
                    Graphics cg = CircularBox.CreateGraphics();
                    cg.SmoothingMode = SmoothingMode.HighQuality;
                    CircularBrowserComponent(cg);
                    LinearBox.Invalidate();
                    Linear_Line.Invalidate();
                }
            }
        }

        private void EGCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadImage)
            {
                if (EGCheck.Checked)
                {
                    if (DEGCheck.Checked)
                        DEGCheck.Checked = false;
                    if (IsCog.Checked)
                        IsCog.Checked = false;
                    Graphics cg = CircularBox.CreateGraphics();
                    cg.SmoothingMode = SmoothingMode.HighQuality;
                    CircularBrowserComponent(cg);
                    LinearBox.Invalidate();
                    Linear_Line.Invalidate();
                }
                else
                {
                    Graphics cg = CircularBox.CreateGraphics();
                    cg.SmoothingMode = SmoothingMode.HighQuality;
                    CircularBrowserComponent(cg);
                    LinearBox.Invalidate();
                    Linear_Line.Invalidate();
                }
            }
        }



        /*
         * 
         * Cog 체크박스
         */

        private void IsCog_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCog.Checked)
            {
                if (DEGCheck.Checked)
                {
                    DEGCheck.Checked = false;
                }
                if (EGCheck.Checked)
                {
                    EGCheck.Checked = false;
                }
                try
                {
                    Cog_Combo.BringToFront();
                    if (Cog_index.Count != 0)
                        Cog_index.Clear();
                    String Cog_String = Cog_Combo.SelectedItem as String;
                    getCount = ViewerData.Synb_View_getCount();

                    if (Cog_String.Equals("ALL"))
                    {
                        for (int i = 0; i < getCount; i++)
                        {
                            if (!ViewerData.Synb_View_getCog(i).Equals("null")/* || !ViewerData.Synb_View_getCog(i).Equals("")*/)
                            {
                                Cog_index.Add(i);
                            }
                        }
                        Graphics cg = CircularBox.CreateGraphics();
                        cg.SmoothingMode = SmoothingMode.HighQuality;
                        CircularBrowserComponent(cg);
                        LinearBox.Invalidate();
                        Linear_Line.Invalidate();
                    }
                    else if (Cog_String.Equals("ETC"))
                    {
                        for (int i = 0; i < getCount; i++)
                        {
                            if (ViewerData.Synb_View_getCog(i).Length >= 2)
                            {
                                Cog_index.Add(i);
                            }
                        }
                        Graphics cg = CircularBox.CreateGraphics();
                        cg.SmoothingMode = SmoothingMode.HighQuality;
                        CircularBrowserComponent(cg);
                        LinearBox.Invalidate();
                        Linear_Line.Invalidate();
                    }
                    else
                    {
                        for (int i = 0; i < getCount; i++)
                        {
                            if (ViewerData.Synb_View_getCog(i).Equals(Cog_String))
                            {
                                Cog_index.Add(i);
                            }
                        }
                        Graphics cg = CircularBox.CreateGraphics();
                        cg.SmoothingMode = SmoothingMode.HighQuality;
                        CircularBrowserComponent(cg);
                        LinearBox.Invalidate();
                        Linear_Line.Invalidate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Try Select Gene");
                }

            }

            else
            {
                Cog_Combo.SendToBack();
                Graphics cg = CircularBox.CreateGraphics();
                cg.SmoothingMode = SmoothingMode.HighQuality;
                CircularBrowserComponent(cg);
                LinearBox.Invalidate();
                Linear_Line.Invalidate();
            }
        }

        private void Cog_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsCog.Checked)
            {
                if (Cog_index.Count != 0)
                    Cog_index.Clear();
                String Cog_String = Cog_Combo.SelectedItem as String;
                getCount = ViewerData.Synb_View_getCount();

                if (Cog_String.Equals("ALL"))
                {
                    for (int i = 0; i < getCount; i++)
                    {
                        if (!ViewerData.Synb_View_getCog(i).Equals("null")/* || !ViewerData.Synb_View_getCog(i).Equals("")*/)
                        {
                            Cog_index.Add(i);
                        }
                    }
                    Graphics cg = CircularBox.CreateGraphics();
                    cg.SmoothingMode = SmoothingMode.HighQuality;
                    CircularBrowserComponent(cg);
                    LinearBox.Invalidate();
                    Linear_Line.Invalidate();
                }
                else if (Cog_String.Equals("ETC"))
                {
                    for (int i = 0; i < getCount; i++)
                    {
                        if (ViewerData.Synb_View_getCog(i).Length >= 2)
                        {
                            Cog_index.Add(i);
                        }
                    }
                    Graphics cg = CircularBox.CreateGraphics();
                    cg.SmoothingMode = SmoothingMode.HighQuality;
                    CircularBrowserComponent(cg);
                    LinearBox.Invalidate();
                    Linear_Line.Invalidate();
                }
                else
                {
                    for (int i = 0; i < getCount; i++)
                    {
                        if (ViewerData.Synb_View_getCog(i).Equals(Cog_String))
                        {
                            Cog_index.Add(i);
                        }
                    }
                    Graphics cg = CircularBox.CreateGraphics();
                    cg.SmoothingMode = SmoothingMode.HighQuality;
                    CircularBrowserComponent(cg);
                    LinearBox.Invalidate();
                    Linear_Line.Invalidate();
                }
            }
        }



        private Color CogColor(String g)
        {
            switch (g)
            {
                case "A":
                    return Color.FromArgb(254, 46, 46);
                case "B":
                    return Color.FromArgb(254, 100, 46);
                case "C":
                    return Color.FromArgb(254, 154, 46);
                case "D":
                    return Color.FromArgb(250, 204, 46);
                case "E":
                    return Color.FromArgb(247, 254, 46);
                case "F":
                    return Color.FromArgb(200, 254, 46);
                case "G":
                    return Color.FromArgb(154, 254, 46);
                case "H":
                    return Color.FromArgb(100, 254, 46);
                case "I":
                    return Color.FromArgb(46, 254, 46);
                case "J":
                    return Color.FromArgb(46, 254, 100);
                case "K":
                    return Color.FromArgb(46, 254, 200);
                case "L":
                    return Color.FromArgb(46, 254, 247);
                case "M":
                    return Color.FromArgb(46, 204, 250);
                case "N":
                    return Color.FromArgb(46, 154, 254);
                case "O":
                    return Color.FromArgb(46, 46, 254);
                case "P":
                    return Color.FromArgb(154, 46, 254);
                case "Q":
                    return Color.FromArgb(204, 46, 250);
                case "R":
                    return Color.FromArgb(254, 46, 247);
                case "S":
                    return Color.FromArgb(254, 46, 154);
                case "T":
                    return Color.FromArgb(223, 1, 58);
                case "U":
                    return Color.FromArgb(110, 110, 110);
                case "V":
                    return Color.FromArgb(8, 138, 133);
                case "W":
                    return Color.FromArgb(8, 75, 138);
                case "Y":
                    return Color.FromArgb(134, 138, 8);
                case "Z":
                    return Color.FromArgb(41, 138, 8);
                default:
                    return Color.Black;
            }

        }


        List<String[]> Designer_data;
        String[] Temp_Data;

        private void Load_xmlFile(object sender, EventArgs e)
        {
            CKGroup.Visible = false;
            GBgenomeInfo.Visible = false;
            GBgeneInfo.Visible = false;
            Design_GB.Visible = true;
            Designer_data = new List<String[]>();
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Xml Files|*.xml|All Files|*.*";
            openfile.FilterIndex = 1;
            openfile.RestoreDirectory = true;                   //파일을 연다
            int cu = 0;
            String name;
            Temp_Data = new String[2];
            try
            {
                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(openfile.FileName);

                        XmlNodeList BlockList = xmlDoc.SelectNodes("/Block");          //파싱을 시작한다.
                        foreach (XmlNode bl in BlockList)
                        {
                            XmlNodeList xnl = bl.ChildNodes;
                            foreach (XmlNode xnn in xnl)
                            {
                                XmlNodeList NameList = xnn.ChildNodes;
                                foreach (XmlNode synb_n in NameList)
                                {
                                    if (synb_n.InnerText != null)
                                    {
                                        name = synb_n.InnerText;
                                        try
                                        {
                                            if (name.Length > 3)
                                            {
                                                Temp_Data[0] = name;
                                            }
                                            else
                                                Temp_Data[1] = name;
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                        name = null;
                                    }
                                    if (Temp_Data[0] != null && Temp_Data[1] != null)
                                    {

                                        Designer_data.Add(Temp_Data);
                                        Temp_Data = null;
                                        Temp_Data = new String[2];
                                    }

                                }
                            }
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Xml File Error! : " + ex.Message);
                    }
                    Graphics g = LinearBox.CreateGraphics();
                    Graphics lg = Linear_Line.CreateGraphics();
                    Graphics cg = CircularBox.CreateGraphics();

                    Designer_viewer_init();
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                    lg.SmoothingMode = SmoothingMode.HighSpeed;
                    cg.SmoothingMode = SmoothingMode.HighQuality;

                    this.LinearBrowserComponent(g, lg);
                    this.CircularBrowserComponent(cg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File open error : " + ex.Message);
            }


        }


        private void Designer_viewer_init()
        {
            Mode_Change = false;

            zoomSize = 35;
            CenterX = CircularBox.Width / 2;
            CenterY = CircularBox.Height / 2;
            int j = 0;
            int k = 0;
            Color_Random = new Random();

            getCount = Designer_data.Count;
            DStartPoint = new int[getCount];
            DEndPoint = new int[getCount];
            DStartPoint[0] = 1;
            DEndPoint[0] = 0;
            foreach (String[] Temp_Data in Designer_data)
            {
                ViewerData.Designer_SelectGene(Temp_Data[0]);
                int geneLength = Convert.ToInt32(ViewerData.Designer_getLength());
                DEndPoint[k] = DStartPoint[k] + geneLength;
                k++;
                if (k > getCount - 1)
                {
                    break;
                }
                else
                    DStartPoint[k] = DEndPoint[k - 1] + 80;
            }

            Double a = 2 * Math.PI / DEndPoint[DEndPoint.Length - 1];
            radius = CircularBox.Height / 2 - 20;
            if (Linear_Block != null)
                Linear_Block = null;
            Linear_Block = new Rectangle[getCount];
            if (Cog_Color != null)
                Cog_Color = null;
            Cog_Color = new Color[getCount];
            Circular_Block = new GraphicsPath[getCount];
            foreach (String[] Temp_Data in Designer_data)
            {
                ViewerData.Designer_SelectGene(Temp_Data[0]);
                int geneLength = Convert.ToInt32(ViewerData.Designer_getLength());

                if (Temp_Data[1].Equals("+"))
                {
                    Linear_Block[j] = new Rectangle(
                        (DStartPoint[j] / zoomSize), 30, (geneLength / zoomSize), 35);
                }
                else
                {
                    Linear_Block[j] = new Rectangle(
                        (DStartPoint[j] / zoomSize), 65, (geneLength / zoomSize), 35);
                }
                Color_List.Add(
                        Color.FromArgb(Color_Random.Next(256), Color_Random.Next(256), Color_Random.Next(150,256)));
                x1 = CenterX - radius * Math.Sin(-a * DStartPoint[j]) * 0.75;
                y1 = CenterY - radius * Math.Cos(-a * DStartPoint[j]) * 0.75;
                x2 = CenterX - radius * Math.Sin(-a * DStartPoint[j]) * 0.95;
                y2 = CenterY - radius * Math.Cos(-a * DStartPoint[j]) * 0.95;
                x3 = CenterX - radius * Math.Sin(-a * DEndPoint[j]) * 0.95;
                y3 = CenterY - radius * Math.Cos(-a * DEndPoint[j]) * 0.95;
                x4 = CenterX - radius * Math.Sin(-a * DEndPoint[j]) * 0.75;
                y4 = CenterY - radius * Math.Cos(-a * DEndPoint[j]) * 0.75;
                Circular_Block[j] = new GraphicsPath();

                Circular_Block[j].AddLine((float)x1, (float)y1, (float)x2, (float)y2);
                Circular_Block[j].AddLine((float)x2, (float)y2, (float)x3, (float)y3);
                Circular_Block[j].AddLine((float)x3, (float)y3, (float)x4, (float)y4);
                Circular_Block[j].AddLine((float)x4, (float)y4, (float)x1, (float)y1);
                j++;
            }
            verticalline_first = new Point[DEndPoint[DEndPoint.Length - 1] / 10000 + 2];
            verticalline_second = new Point[DEndPoint[DEndPoint.Length - 1] / 10000 + 2];


            Size sz = new Size();
            sz.Width = (DEndPoint[DEndPoint.Length - 1]) / zoomSize;

            sz.Height = 100;
            LinearPanel.AutoScrollMinSize = sz;

            Line_first = new Point(0, 15);
            Line_second = new Point(DEndPoint[DEndPoint.Length - 1] / zoomSize, 15);
            line_pen = new Pen(Color.Black, 1);
            Fill_pen = new Pen(Color.Black, 3);
            stringformat = new StringFormat();
            stringformat.Alignment = StringAlignment.Center;
            stringformat.LineAlignment = StringAlignment.Center;

            blackBrush = new SolidBrush(Color.Black);

            for (int i = 0; i < verticalline_second.Length - 1; i++)
            {
                verticalline_first[i].X = i * ((DEndPoint[DEndPoint.Length - 1] / zoomSize) / (DEndPoint[DEndPoint.Length - 1] / 10000));
                verticalline_first[i].Y = 5;
                verticalline_second[i].X = i * ((DEndPoint[DEndPoint.Length - 1] / zoomSize) / (DEndPoint[DEndPoint.Length - 1] / 10000));
                verticalline_second[i].Y = 20;
            }
            verticalline_first[verticalline_second.Length - 1].X = (DEndPoint[DEndPoint.Length - 1] / zoomSize) - 3;
            verticalline_first[verticalline_second.Length - 1].Y = 5;
            verticalline_second[verticalline_second.Length - 1].X = (DEndPoint[DEndPoint.Length - 1] / zoomSize) - 3;
            verticalline_second[verticalline_second.Length - 1].Y = 20;
            isLininit = true;
        }

        private void SynbId_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void custumGenomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_xmlFile(null, null);
        }
    }
}