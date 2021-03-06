﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Diagnostics;
using System.Collections;
using System.Drawing.Drawing2D;
using System.IO;
using System.Data.OleDb;



namespace BrickDesigner
{
    public partial class Form_Main : Form
    {

        /************************************************************************/
        /* 변수                                                                 */
        /************************************************************************/

        static class SizePB
        {

            public const int PBWIDTH = 60;
            public const int PBHEIGHT = 60;
            public const int PBPADDING = 6;

        }

        static class BrickColor
        {

        }

        // 현재 브릭데이터
        public Brick_data newBD;

        // 이미지 리스트
        ImageList imgl_default;
        ImageList imgl_click;

        ImageList imgl_highQ;

        // 클릭 이벤트 BOOL
        bool isPBMove = false;

        // 현재 선택된 PB TAG
        int i_seleted_PB_Tag;

        // 현재 마우스로 선택한 위치 ( 상대적인 위치 )
        int selectX;

        int lb_select = -1;

        ToolTip bt_tooltip;

        public bool isCloning = false;
        public bool isScar = false;

        DBconnector connector;

        Process _pro;

        string str_SBOL_filename;

        /// <summary>
        /// 폼 생성자
        /// </summary>
        public Form_Main()
        {
            InitializeComponent();

            newBD = new Brick_data();

            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);

            this.make_ImgList();

            //base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.pn_Brick.BackColor = Color.Transparent;

            bt_tooltip = new ToolTip();

            _pro = new Process();
            _pro.StartInfo.FileName = "makeSBOL.exe";
            _pro.EnableRaisingEvents = true;
            _pro.Exited += new EventHandler(_pro_Exited);
            _pro.StartInfo.CreateNoWindow = true;
            _pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        }

        /// <summary>
        /// 브릭 아이콘에 쓰일 이미지 리스트 생성
        /// </summary>
        private void make_ImgList()
        {
            imgl_default = new ImageList();
            imgl_default.ColorDepth = ColorDepth.Depth32Bit;
            imgl_default.ImageSize = new Size(SizePB.PBWIDTH, SizePB.PBHEIGHT);
            imgl_default.Images.Add("Regulatory", Properties.Resources._1);
            imgl_default.Images.Add("RBS", Properties.Resources._2);
            imgl_default.Images.Add("Protein_Domain", Properties.Resources._3);
            imgl_default.Images.Add("Coding", Properties.Resources._4);
            imgl_default.Images.Add("Translational_Unit", Properties.Resources._5);
            imgl_default.Images.Add("Terminator", Properties.Resources._6);
            imgl_default.Images.Add("DNA", Properties.Resources._7);
            imgl_default.Images.Add("Plasmid_Backbone", Properties.Resources._8);
            imgl_default.Images.Add("Plasmid", Properties.Resources._9);
            imgl_default.Images.Add("Primer", Properties.Resources._10);
            imgl_default.Images.Add("Generator", Properties.Resources._11);
            imgl_default.Images.Add("Reporter", Properties.Resources._12);
            imgl_default.Images.Add("Inverter", Properties.Resources._13);
            imgl_default.Images.Add("Signalling", Properties.Resources._14);
            imgl_default.Images.Add("Measurement", Properties.Resources._15);
            imgl_default.Images.Add("0", Properties.Resources._20);
            imgl_default.Images.Add("1", Properties.Resources._21);
            imgl_default.Images.Add("2", Properties.Resources._22);
            imgl_default.Images.Add("3", Properties.Resources._23);
            imgl_default.Images.Add("4", Properties.Resources._24);
            imgl_default.Images.Add("5", Properties.Resources._25);
            imgl_default.Images.Add("6", Properties.Resources._26);
            imgl_default.Images.Add("7", Properties.Resources._27);
            imgl_default.Images.Add("8", Properties.Resources._28);
            imgl_default.Images.Add("9", Properties.Resources._29);
            imgl_default.Images.Add("Scar", Properties.Resources.connect);

            imgl_click = new ImageList();
            imgl_click.ColorDepth = ColorDepth.Depth32Bit;
            imgl_click.ImageSize = new Size(SizePB.PBWIDTH, SizePB.PBHEIGHT);
            imgl_click.Images.Add("Regulatory", Properties.Resources._1_click);
            imgl_click.Images.Add("RBS", Properties.Resources._2_click);
            imgl_click.Images.Add("Protein_Domain", Properties.Resources._3_click);
            imgl_click.Images.Add("Coding", Properties.Resources._4_click);
            imgl_click.Images.Add("Translational_Unit", Properties.Resources._5_click);
            imgl_click.Images.Add("Terminator", Properties.Resources._6_click);
            imgl_click.Images.Add("DNA", Properties.Resources._7_click);
            imgl_click.Images.Add("Plasmid_Backbone", Properties.Resources._8_click);
            imgl_click.Images.Add("Plasmid", Properties.Resources._9_click);
            imgl_click.Images.Add("Primer", Properties.Resources._10_click);
            imgl_click.Images.Add("Generator", Properties.Resources._11_click);
            imgl_click.Images.Add("Reporter", Properties.Resources._12_click);
            imgl_click.Images.Add("Inverter", Properties.Resources._13_click);
            imgl_click.Images.Add("Signalling", Properties.Resources._14_click);
            imgl_click.Images.Add("Measurement", Properties.Resources._15_click);
            imgl_click.Images.Add("0", Properties.Resources._20_click);
            imgl_click.Images.Add("1", Properties.Resources._21_click);
            imgl_click.Images.Add("2", Properties.Resources._22_click);
            imgl_click.Images.Add("3", Properties.Resources._23_click);
            imgl_click.Images.Add("4", Properties.Resources._24_click);
            imgl_click.Images.Add("5", Properties.Resources._25_click);
            imgl_click.Images.Add("6", Properties.Resources._26_click);
            imgl_click.Images.Add("7", Properties.Resources._27_click);
            imgl_click.Images.Add("8", Properties.Resources._28_click);
            imgl_click.Images.Add("9", Properties.Resources._29_click);
            imgl_click.Images.Add("Scar", Properties.Resources.connect_click);

            imgl_highQ = new ImageList();
            imgl_highQ.ColorDepth = ColorDepth.Depth32Bit;
            imgl_highQ.ImageSize = new Size(256, 256);
            imgl_highQ.Images.Add("Regulatory", Properties.Resources._1);
            imgl_highQ.Images.Add("RBS", Properties.Resources._2);
            imgl_highQ.Images.Add("Protein_Domain", Properties.Resources._3);
            imgl_highQ.Images.Add("Coding", Properties.Resources._4);
            imgl_highQ.Images.Add("Translational_Unit", Properties.Resources._5);
            imgl_highQ.Images.Add("Terminator", Properties.Resources._6);
            imgl_highQ.Images.Add("DNA", Properties.Resources._7);
            imgl_highQ.Images.Add("Plasmid_Backbone", Properties.Resources._8);
            imgl_highQ.Images.Add("Plasmid", Properties.Resources._9);
            imgl_highQ.Images.Add("Primer", Properties.Resources._10);
            imgl_highQ.Images.Add("Generator", Properties.Resources._11);
            imgl_highQ.Images.Add("Reporter", Properties.Resources._12);
            imgl_highQ.Images.Add("Inverter", Properties.Resources._13);
            imgl_highQ.Images.Add("Signalling", Properties.Resources._14);
            imgl_highQ.Images.Add("Measurement", Properties.Resources._15);
            imgl_highQ.Images.Add("0", Properties.Resources._20);
            imgl_highQ.Images.Add("1", Properties.Resources._21);
            imgl_highQ.Images.Add("2", Properties.Resources._22);
            imgl_highQ.Images.Add("3", Properties.Resources._23);
            imgl_highQ.Images.Add("4", Properties.Resources._24);
            imgl_highQ.Images.Add("5", Properties.Resources._25);
            imgl_highQ.Images.Add("6", Properties.Resources._26);
            imgl_highQ.Images.Add("7", Properties.Resources._27);
            imgl_highQ.Images.Add("8", Properties.Resources._28);
            imgl_highQ.Images.Add("9", Properties.Resources._29);
            imgl_highQ.Images.Add("Scar", Properties.Resources.connect);
        }



        private Color get_type_color(string _str_type)
        {
            switch (_str_type)
            {
                case "Regulatory":
                    return Color.YellowGreen;
                case "RBS":
                    return Color.Crimson;
                case "Protein_Domain":
                    return Color.CornflowerBlue;
                case "Coding":
                    return Color.BlueViolet;
                case "Translational_Unit":
                    return Color.DarkBlue;
                case "Terminator":
                    return Color.LightCoral;
                case "DNA":
                    return Color.SpringGreen;
                case "Plasmid_Backbone":
                    return Color.PaleVioletRed;
                case "Plasmid":
                    return Color.DeepPink;
                case "Primer":
                    return Color.Gold;


                case "Generator":
                    return Color.Violet;
                case "Reporter":
                    return Color.Silver;
                case "Inverter":
                    return Color.DarkOrange;
                case "Signalling":
                    return Color.Tomato;
                case "Measurement":
                    return Color.DarkGray;
                case "Scar":
                    return Color.Chocolate;
                case "":
                    return Color.Gainsboro;
                case "Basic":
                    return Color.Tan;
                case "Cell":
                    return Color.LightCyan;
                case "Composite":
                    return Color.Moccasin;


                case "Conjugation":
                    return Color.MediumSpringGreen;
                case "Device":
                    return Color.DarkKhaki;
                case "Intermediate":
                    return Color.LightSteelBlue;
                case "Other":
                    return Color.Thistle;
                case "Project":
                    return Color.OliveDrab;
                case "RNA":
                    return Color.IndianRed;
                case "T7":
                    return Color.Gainsboro;
                case "Tag":
                    return Color.LightSeaGreen;
                case "Temporary":
                    return Color.PaleVioletRed;

                case "Suffix":
                case "Prefix":
                    return Color.Peru;


                default:
                    return Color.Firebrick;
            }
        }




        /// <summary>
        /// 데이터 스왑하기
        /// </summary>
        /// <param name="i">dd</param>
        /// <param name="j"></param>
        private void swap_Brickdata(int i, int j)
        {
            Brick_sub_data bsd = this.newBD.sl_subpart_list[j];
            this.newBD.sl_subpart_list[j] = this.newBD.sl_subpart_list[i];
            this.newBD.sl_subpart_list[i] = bsd;
        }

        /// <summary>
        /// 브릭데이터 추가하기
        /// </summary>
        /// <param name="bsd"></param>
        public void Add_BrickData(Brick_sub_data bsd)
        {

            if (isCloning)
            {
                if (MessageBox.Show("Do you want to cancel Cloning?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.newBD.cancel_scar();
                    cancel_cloning();
                }
                else
                {
                    return;
                }
            }

            this.newBD.sl_subpart_list.Add(this.newBD.sl_subpart_list.Count, bsd);

            paint_BrickData();
            listbox_from_BrickData();
            paint_linear_Seq();
        }

        /// <summary>
        /// 리스트박스에 데이터리스트에 있는 제목들 뿌려주기
        /// </summary>
        public void listbox_from_BrickData()
        {
            try
            {
                lb_Brick.Items.Clear();

                if (isCloning)
                {
                    foreach (Brick_sub_data bsd in this.newBD.sl_cloning_list.Values)
                    {
                        lb_Brick.Items.Add("· " + bsd.part_name);
                    }
                }
                else
                {
                    foreach (Brick_sub_data bsd in this.newBD.sl_subpart_list.Values)
                    {
                        lb_Brick.Items.Add("· " + bsd.part_name);
                    }
                }


            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 브릭 리스트를 이용해서 화면에 배치시킨다.
        /// </summary>
        public void paint_BrickData()
        {
            // 컨트롤들 지우기
            pn_Brick.Controls.Clear();

            if (this.newBD.sl_subpart_list.Count == 0)
            {
                return;
            }

            Size si_PB;
            Point pi_PB;

            si_PB = new Size((SizePB.PBWIDTH * this.newBD.sl_subpart_list.Count) + (SizePB.PBPADDING * 2), SizePB.PBHEIGHT);
            pi_PB = new Point((SizePB.PBPADDING), (pn_Brick.Size.Height / 2) - (SizePB.PBHEIGHT / 2));

            PictureBox pb_line = new PictureBox();
            pb_line.Name = "line";
            pb_line.BackgroundImageLayout = ImageLayout.Stretch;
            pb_line.BackgroundImage = Properties.Resources.line4;

            pb_line.Location = pi_PB;
            pb_line.Size = si_PB;
            pn_Brick.Controls.Add(pb_line);

            si_PB = new Size(SizePB.PBWIDTH, SizePB.PBHEIGHT);


            for (int i = 0; i < this.newBD.sl_subpart_list.Count; i++)
            {

                pi_PB = new Point();
                pi_PB.X = ((SizePB.PBWIDTH) * i) + SizePB.PBPADDING;
                pi_PB.Y = 0;

                PictureBox pb_Brick = new PictureBox();
                pb_Brick.BackColor = Color.Transparent;

                pb_Brick.MouseDown += pb_Brick_MouseDown;
                pb_Brick.MouseMove += pb_Brick_MouseMove;
                pb_Brick.MouseUp += pb_Brick_MouseUp;

                ContextMenu cm_PB_munu = new System.Windows.Forms.ContextMenu();
                cm_PB_munu.MenuItems.Add("Delete").Click += context_delete_click;
                cm_PB_munu.Name = i.ToString();
                pb_Brick.ContextMenu = cm_PB_munu;

                pb_Brick.Tag = i;
                pb_Brick.Name = i.ToString();


                if (this.newBD.sl_subpart_list[i].part_icon == -1)
                {
                    pb_Brick.Image = imgl_default.Images[this.newBD.sl_subpart_list[i].part_type];
                }
                else
                {
                    pb_Brick.Image = imgl_default.Images[this.newBD.sl_subpart_list[i].part_icon.ToString()];
                }



                pb_Brick.Location = pi_PB;
                pb_Brick.Size = si_PB;

                pn_Brick.Controls.Add(pb_Brick);
                pb_Brick.Parent = pb_line;
            }
        }

        /// <summary>
        /// delete 메뉴를 선택했을 경우 _ context
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void context_delete_click(object sender, EventArgs e)
        {

            if (isCloning)
            {
                if (MessageBox.Show("Do you want to cancel Cloning?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cancel_cloning();
                }
                else
                {
                    return;
                }
            }

            if (isScar)
            {
                this.newBD.cancel_scar();
            }



            ContextMenu ctm_temp = (sender as MenuItem).GetContextMenu();
            int i_PB_tag = int.Parse(ctm_temp.Name);


            if (this.newBD.sl_subpart_list.Count == 1)
            {
                this.newBD.sl_subpart_list.Remove(0);
            }
            else if (this.newBD.sl_subpart_list.Count == 2)
            {
                if (i_PB_tag == 0)
                {
                    swap_Brickdata(0, 1);
                }
                this.newBD.sl_subpart_list.Remove(this.newBD.sl_subpart_list.Count - 1);
            }
            else if (this.newBD.sl_subpart_list.Count > 2)
            {
                for (int i = i_PB_tag; i < this.newBD.sl_subpart_list.Count - 1; i++)
                {
                    swap_Brickdata(i, i + 1);
                }

                this.newBD.sl_subpart_list.Remove(this.newBD.sl_subpart_list.Count - 1);
            }

            paint_BrickData();
            listbox_from_BrickData();
            paint_Circle();
            paint_linear_Seq();
        }



        /************************************************************************/
        /*                                                                      */
        /************************************************************************/

        /// <summary>
        /// 마우스 다운
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pb_Brick_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isPBMove && e.Button == MouseButtons.Left)
            {
                isPBMove = true;
                i_seleted_PB_Tag = (int)((PictureBox)sender).Tag;

                if (this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_icon == -1)
                {
                    (sender as PictureBox).Image = imgl_click.Images[this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_type];

                }
                else
                {
                    (sender as PictureBox).Image = imgl_click.Images[this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_icon.ToString()];
                }
            }
            else if (!isPBMove && e.Button == MouseButtons.Right)
            {
                i_seleted_PB_Tag = (int)((PictureBox)sender).Tag;

                if (this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_icon == -1)
                {
                    (sender as PictureBox).Image = imgl_click.Images[this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_type];

                }
                else
                {
                    (sender as PictureBox).Image = imgl_click.Images[this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_icon.ToString()];
                }
            }
        }

        /// <summary>
        /// 마우스 무브
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pb_Brick_MouseMove(object sender, MouseEventArgs e)
        {

            if (isPBMove && e.Button == MouseButtons.Left)
            {
                // 현재 선택한 X의 상대좌표 가지고 오기
                selectX = (SizePB.PBWIDTH * i_seleted_PB_Tag) + SizePB.PBPADDING + e.X;

                //////////////////////////////////////////////////////////////////////////
                /* 
                 * 현재 상대좌표가 전 PB의 반을 넘어선다면 전거와 위치, 데이터를 변경한다
                 * 만약 그 전 PB가 없다면 하지 않는다.
                 */
                //////////////////////////////////////////////////////////////////////////

                if (selectX <= (((SizePB.PBWIDTH) * (i_seleted_PB_Tag - 1)) + SizePB.PBPADDING + ((SizePB.PBWIDTH / 2) + SizePB.PBPADDING)))
                {
                    if (i_seleted_PB_Tag != 0)
                    {

                        if (isCloning)
                        {
                            cancel_cloning();
                        }

                        if (isScar)
                        {
                            this.newBD.cancel_scar();
                        }

                        Control pre_PB = (pn_Brick.Controls.Find((i_seleted_PB_Tag - 1).ToString(), true))[0];

                        Point p_Current_PB_Pi = ((PictureBox)sender).Location;

                        ((PictureBox)sender).Location = pre_PB.Location;
                        ((PictureBox)sender).Tag = i_seleted_PB_Tag - 1;
                        ((PictureBox)sender).Name = (i_seleted_PB_Tag - 1).ToString();
                        ((PictureBox)sender).ContextMenu.Name = (i_seleted_PB_Tag - 1).ToString();

                        pre_PB.Tag = i_seleted_PB_Tag;
                        pre_PB.Name = i_seleted_PB_Tag.ToString();
                        pre_PB.Location = p_Current_PB_Pi;
                        pre_PB.ContextMenu.Name = i_seleted_PB_Tag.ToString();
                        p_Current_PB_Pi = ((PictureBox)sender).Location;

                        swap_Brickdata(i_seleted_PB_Tag - 1, i_seleted_PB_Tag);

                        i_seleted_PB_Tag = i_seleted_PB_Tag - 1;

                        listbox_from_BrickData();
                        paint_Circle();
                        paint_linear_Seq();
                    }
                }
                else if (selectX >= ((SizePB.PBWIDTH * (i_seleted_PB_Tag + 1)) + ((SizePB.PBWIDTH / 2) - SizePB.PBPADDING)))
                {
                    if (i_seleted_PB_Tag < (this.newBD.sl_subpart_list.Count - 1))
                    {

                        if (isCloning)
                        {
                            cancel_cloning();
                        }

                        if (isScar)
                        {
                            this.newBD.cancel_scar();
                        }

                        Control temp_pb = (pn_Brick.Controls.Find((i_seleted_PB_Tag + 1).ToString(), true))[0];

                        Point p_Current_PB_Pi = ((PictureBox)sender).Location;

                        ((PictureBox)sender).Location = temp_pb.Location;
                        ((PictureBox)sender).Tag = i_seleted_PB_Tag + 1;
                        ((PictureBox)sender).Name = (i_seleted_PB_Tag + 1).ToString();
                        ((PictureBox)sender).ContextMenu.Name = (i_seleted_PB_Tag + 1).ToString();
                        temp_pb.Tag = i_seleted_PB_Tag;
                        temp_pb.Name = i_seleted_PB_Tag.ToString();
                        temp_pb.Location = p_Current_PB_Pi;
                        temp_pb.ContextMenu.Name = i_seleted_PB_Tag.ToString();
                        p_Current_PB_Pi = ((PictureBox)sender).Location;

                        swap_Brickdata(i_seleted_PB_Tag, i_seleted_PB_Tag + 1);

                        i_seleted_PB_Tag = i_seleted_PB_Tag + 1;

                        listbox_from_BrickData();
                        paint_Circle();
                        paint_linear_Seq();
                    }
                }

                pn_Brick.Update();
            }
        }

        /// <summary>
        /// 마우스 업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pb_Brick_MouseUp(object sender, MouseEventArgs e)
        {
            if (isPBMove)
            {
                isPBMove = false;

                if (this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_icon == -1)
                {
                    (sender as PictureBox).Image = imgl_default.Images[this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_type];

                }
                else
                {
                    (sender as PictureBox).Image = imgl_default.Images[this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_icon.ToString()];
                }



                i_seleted_PB_Tag = -1;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_icon == -1)
                {
                    (sender as PictureBox).Image = imgl_default.Images[this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_type];

                }
                else
                {
                    (sender as PictureBox).Image = imgl_default.Images[this.newBD.sl_subpart_list[i_seleted_PB_Tag].part_icon.ToString()];
                }
            }


        }

        public void data_save()
        {
            StringBuilder sbSave = new StringBuilder();
            Stream sr_Stream;

            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Filter = "Project files (*brp)|*.brp";
            saveFD.FileName = this.newBD.str_brick_name;

            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                if ((sr_Stream = saveFD.OpenFile()) != null)
                {
                    TextWriter tw = new StreamWriter(sr_Stream);

                    sbSave.Append(newBD.str_brick_name);
                    sbSave.Append(Environment.NewLine);
                    sbSave.Append(newBD.str_brick_type);
                    sbSave.Append(Environment.NewLine);
                    sbSave.Append(newBD.str_brick_desc);
                    sbSave.Append(Environment.NewLine);
                    sbSave.Append(Environment.NewLine);

                    foreach (Brick_sub_data bsd in newBD.sl_subpart_list.Values)
                    {
                        sbSave.Append(bsd.part_name);
                        sbSave.Append(" " + bsd.part_id);
                        if (bsd.part_icon != -1)
                        {
                            sbSave.Append(" " + bsd.part_icon);
                        }
                        sbSave.Append(Environment.NewLine);
                    }

                    //클로닝 전까지만 저장하기

                    tw.WriteLine(sbSave.ToString());
                    tw.Close();
                }
            }
        }

        public void data_load()
        {
            StringBuilder sbLoad = new StringBuilder();
            Stream sr_Stream;

            connector = new DBconnector();

            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Filter = "project files (*brp)|*.brp";

            if (openFD.ShowDialog() == DialogResult.OK)
            {
                if ((sr_Stream = openFD.OpenFile()) != null)
                {
                    this.newBD = new Brick_data();

                    TextReader tr = new StreamReader(sr_Stream);
                    string _str;

                    int i = 0;
                    int j = 0;
                    while ((_str = tr.ReadLine()) != null)
                    {

                        if (_str.Length == 0)
                        {
                            continue;
                        }

                        if (i == 0)
                        {
                            this.newBD.str_brick_name = _str;
                        }
                        else if (i == 1)
                        {
                            this.newBD.str_brick_type = _str;
                        }
                        else if (i == 2)
                        {
                            this.newBD.str_brick_desc = _str;
                        }
                        else
                        {
                            // 여기서 브릭 네임으로 가져와서 정보를 서브 데이터로 저장해야함

                            Brick_sub_data bsd = new Brick_sub_data();
                            string[] split_str = _str.Split(' ');

                            if (split_str[0] == "Scar" || split_str[0] == "Spe1+Xba1")
                            {
                                // 여긴 스칼임
                                bsd.part_name = "Scar";
                                bsd.part_type = "Scar";
                                bsd.part_seq = "";

                                this.newBD.sl_subpart_list.Add(j, bsd);

                            }
                            else if (split_str[1] == "-1")
                            {
                                // 유저브릭임.
                                string str_q = "select * from userbricks where part_name = '" + split_str[0] + "'";

                                OleDbDataReader oddr = connector.select_Data(str_q);

                                while (oddr.Read())
                                {
                                    bsd.part_name = oddr.GetString(0);
                                    bsd.part_type = oddr.GetString(1);
                                    bsd.part_desc = oddr.GetString(2);
                                    bsd.part_seq = oddr.GetString(3);

                                    if (split_str.Count() > 2)
                                    {
                                        bsd.part_icon = int.Parse(split_str[2]);
                                    }
                                }

                                this.newBD.sl_subpart_list.Add(j, bsd);
                            }
                            else
                            {
                                string str_q = "select * from part where part_name = '" + split_str[0] + "'";

                                OleDbDataReader oddr = connector.select_Data(str_q);

                                while (oddr.Read())
                                {
                                    bsd.part_id = oddr.GetInt32(0);
                                    bsd.part_name = oddr.GetString(1);
                                    bsd.part_desc = oddr.GetString(3);
                                    bsd.part_type = oddr.GetString(4);
                                    bsd.part_status = oddr.GetString(5);
                                    bsd.part_result = oddr.GetString(6);
                                    bsd.part_entered = oddr.GetString(10);
                                    bsd.part_author = oddr.GetString(11);
                                    bsd.best_qulity = oddr.GetString(12);
                                }

                                str_q = "select sequences.seq_data from sequences, part where part.part_name = '" + split_str[0] + "' and part.part_id = sequences.part_id";

                                oddr = connector.select_Data(str_q);

                                while (oddr.Read())
                                {
                                    bsd.part_seq = oddr.GetString(0);
                                }

                                str_q = "select p.part_name from part as p, specified_subparts as sp where sp.part_id = " + bsd.part_id + " and sp.subpart_id = p.part_id";

                                oddr = connector.select_Data(str_q);

                                while (oddr.Read())
                                {
                                    bsd.subparts.Add(oddr.GetString(0));
                                }

                                if (split_str.Count() > 2)
                                {
                                    bsd.part_icon = int.Parse(split_str[2]);
                                }

                                this.newBD.sl_subpart_list.Add(j, bsd);
                            }

                            j++;
                        }
                        i++;
                    }

                }
            }


            connector = null;
            this.change_FromName();
        }


        /************************************************************************/
        /*                                                                      */
        /************************************************************************/

        /// <summary>
        /// New 버튼 눌렀을 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // 현재 데이터를 편집중이었다면 저장하시겠습니까?
            // 예스  - 저장
            // 노 - 데이터 리셋, 이름 저장


            if (this.newBD.sl_subpart_list.Count > 0)
            {
                // 정보를 저장하기 원하면
                if (MessageBox.Show("Do you want to save current data?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // 데이터가 있으면
                    if (this.newBD.str_brick_name == null)
                    {
                        MessageBox.Show("Please enter information.");
                        Form_Save fs1 = new Form_Save(this, 2);
                        fs1.ShowDialog();
                    }
                    else
                    {
                        this.data_save();
                    }
                }
                else
                {
                    this.newBD = new Brick_data();
                    Form_Save fs1 = new Form_Save(this, 1);
                    fs1.ShowDialog();

                    paint_BrickData();
                    paint_Circle();
                    paint_linear_Seq();
                    listbox_from_BrickData();

                }
            }
            else // 정보가 없으면 
            {
                this.newBD = new Brick_data();
                Form_Save fs1 = new Form_Save(this, 1);
                fs1.ShowDialog();

                paint_BrickData();
                paint_Circle();
                paint_linear_Seq();
                listbox_from_BrickData();
            }
        }


        private void btn_Add_Brick_Click(object sender, EventArgs e)
        {
            Form_Add fa1 = new Form_Add();
            fa1.ShowDialog();
        }


        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Download fd1 = new Form_Download();
            fd1.ShowDialog();
        }

        private void dBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DB fd1 = new Form_DB();
            fd1.ShowDialog();
        }

        private void clonningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.newBD.sl_subpart_list.Count <= 0)
            {
                MessageBox.Show("There isn't a brick you just selected.");
                return;
            }

            if (this.check_Scar())
            {
                cancel_cloning();

                Form_Cloning fc1 = new Form_Cloning(this);
                fc1.ShowDialog();


            }
            else
            {

            }


        }

        private void bt_Promoter_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Regulatory");
            fs1.ShowDialog();
        }

        private void bt_RBS_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "RBS");
            fs1.ShowDialog();
        }

        private void bt_ProteinD_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Protein_Domain");
            fs1.ShowDialog();
        }

        private void bt_Coding_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Coding");
            fs1.ShowDialog();
        }

        private void bt_TU_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Translational_Unit");
            fs1.ShowDialog();
        }

        private void bt_Terminator_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Terminator");
            fs1.ShowDialog();
        }

        private void bt_DNA_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "DNA");
            fs1.ShowDialog();
        }

        private void bt_Plasmid_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Plasmid");
            fs1.ShowDialog();
        }

        private void bt_Primer_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Primer");
            fs1.ShowDialog();
        }

        private void bt_Scar_Click(object sender, EventArgs e)
        {
            Brick_sub_data _bsd = new Brick_sub_data();
            _bsd.part_name = "Scar";
            _bsd.part_type = "Scar";
            _bsd.part_seq = "";

            this.Add_BrickData(_bsd);
        }

        private void bt_Generator_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Generator");
            fs1.ShowDialog();
        }

        private void bt_Reporter_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Reporter");
            fs1.ShowDialog();
        }

        private void bt_Inverter_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Inverter");
            fs1.ShowDialog();
        }

        private void bt_Signalling_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Signalling");
            fs1.ShowDialog();
        }

        private void bt_Measurement_Click(object sender, EventArgs e)
        {
            Form_Select fs1 = new Form_Select(this, "Measurement");
            fs1.ShowDialog();
        }

        private void bt_Other_Click(object sender, EventArgs e)
        {
            Form_Select_Other fso1 = new Form_Select_Other(this);
            fso1.ShowDialog();
        }

        /// <summary>
        /// exit 버튼눌렀을 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 버튼에서 마우스 오버했을때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_MouserHover(object sender, EventArgs e)
        {
            bt_tooltip.ShowAlways = true;

            string str_sender = (sender as Button).Name;

            switch (str_sender)
            {
                case "bt_Promoter":
                    bt_tooltip.SetToolTip(bt_Promoter, "Promoter");
                    break;

                case "bt_RBS":
                    bt_tooltip.SetToolTip(bt_RBS, "RBS");
                    break;

                case "bt_ProteinD":
                    bt_tooltip.SetToolTip(bt_ProteinD, "Protein Domain");
                    break;

                case "bt_Coding":
                    bt_tooltip.SetToolTip(bt_Coding, "Coding");
                    break;

                case "bt_TU":
                    bt_tooltip.SetToolTip(bt_TU, "Translational Unit");
                    break;

                case "bt_Terminator":
                    bt_tooltip.SetToolTip(bt_Terminator, "Terminator");
                    break;

                case "bt_DNA":
                    bt_tooltip.SetToolTip(bt_DNA, "DNA");
                    break;

                case "bt_Plasmid":
                    bt_tooltip.SetToolTip(bt_Plasmid, "Plasmid");
                    break;

                case "bt_Primer":
                    bt_tooltip.SetToolTip(bt_Primer, "Primer");
                    break;

                case "bt_Generator":
                    bt_tooltip.SetToolTip(bt_Generator, "Generator");
                    break;

                case "bt_Reporter":
                    bt_tooltip.SetToolTip(bt_Reporter, "Reporter");
                    break;

                case "bt_Inverter":
                    bt_tooltip.SetToolTip(bt_Inverter, "Inverter");
                    break;

                case "bt_Signalling":
                    bt_tooltip.SetToolTip(bt_Signalling, "Signalling");
                    break;

                case "bt_Measurement":
                    bt_tooltip.SetToolTip(bt_Measurement, "Measurement");
                    break;

                case "bt_Scar":
                    bt_tooltip.SetToolTip(bt_Scar, "Scar");
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 세이브 버튼 눌렀을 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void savetoolStripMenuItem1_Click(object sender, EventArgs e)
        {

            // 현재 정보가 없으면 "저장할 정보를 입력하세요"
            // 그냥 닫으면 저장창이 뜨지 않고
            // OK누르면 저장창이 뜨기


            if (this.newBD.str_brick_name == null && this.newBD.sl_subpart_list.Count == 0)
            {
                // 현재 브릭 정보와 서브정보가 없으니
                // 저장할 정보가 없다.
                MessageBox.Show("There is NO data to save.");
            }
            else if (this.newBD.str_brick_name == null && this.newBD.sl_subpart_list.Count > 0)
            {
                // 서브 정보는 있는데 이름 정보가 없으니 창 띄어주고 data save 함수 호출
                MessageBox.Show("Please enter information.");
                Form_Save fs1 = new Form_Save(this, 2);
                fs1.ShowDialog();
            }
            else if (this.newBD.str_brick_name != null && this.newBD.sl_subpart_list.Count == 0)
            {
                MessageBox.Show("There is NO data to save.");
            }
            else
            {
                this.data_save();
            }

        }

        /// <summary>
        /// 로드 버튼 눌렀을 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadtoolStripMenuItem1_Click(object sender, EventArgs e)
        {

            // 현재 아무것도 없을경우
            if (this.newBD.str_brick_name == null && this.newBD.sl_subpart_list.Count == 0)
            {
                data_load();
                this.paint_BrickData();
                this.paint_linear_Seq();
                this.listbox_from_BrickData();
            }
            // 현재 정보는 없지만 데이터는 있는 경우
            else if (this.newBD.str_brick_name == null && this.newBD.sl_subpart_list.Count > 0)
            {
                // 정보를 저장하시겠습니까?
                if (MessageBox.Show("Do you want to save current data?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // 저장한다면
                    MessageBox.Show("Please enter information.");
                    Form_Save fs1 = new Form_Save(this, 2);
                    fs1.ShowDialog();
                }
                data_load();
                this.paint_BrickData();
                this.paint_linear_Seq();
                this.listbox_from_BrickData();
            } // 현재 정보도 있고 데이터도 있는 경우
            else if (this.newBD.str_brick_name != null && this.newBD.sl_subpart_list.Count > 0)
            {
                if (MessageBox.Show("Do you want to save current data?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    data_save();
                }
                data_load();
                this.paint_BrickData();
                this.paint_linear_Seq();
                this.listbox_from_BrickData();
            }
            else
            {
                // 정보는 있찌만 데이터가 없는경우
                data_load();
                this.paint_BrickData();
                this.paint_linear_Seq();
                this.listbox_from_BrickData();
            }

        }

        /************************************************************************/
        /*                                                                      */
        /************************************************************************/


        /// <summary>
        /// Circle 그려주는 함수
        /// </summary>
        private void paint_Circle()
        {
            Graphics _g = pn_Circle.CreateGraphics();
            _g.SmoothingMode = SmoothingMode.HighQuality;

            _g.Clear(Color.White);

            if (this.newBD.sl_cloning_list.Count > 0)
            {
                
                Random _r = new Random();
                SolidBrush _s = new SolidBrush(Color.White);
                HatchBrush _h = new HatchBrush(HatchStyle.LightUpwardDiagonal, Color.White, Color.Brown);

                string str_sum = "";
                int i_sum = 0;
                int p_do = 0;

                for (int i = 0; i < this.newBD.sl_cloning_list.Count; i++)
                {

                    if (this.newBD.sl_cloning_list[i].part_seq.Length <= 10)
                    {
                        str_sum += this.newBD.sl_cloning_list[i].part_seq;
                        //i_sum += this.newBD.sl_cloning_list[i].part_seq.Length;
                        i_sum += 5;
                    }
                    else if (this.newBD.sl_cloning_list[i].part_seq.Length <= 100 && this.newBD.sl_cloning_list[i].part_seq.Length > 10)
                    {
                        str_sum += this.newBD.sl_cloning_list[i].part_seq;
                        //i_sum += this.newBD.sl_cloning_list[i].part_seq.Length;
                        i_sum += 15;
                    }
                    else if (this.newBD.sl_cloning_list[i].part_seq.Length <= 1000 && this.newBD.sl_cloning_list[i].part_seq.Length > 100)
                    {
                        str_sum += this.newBD.sl_cloning_list[i].part_seq;
                        i_sum += 50;
                        //i_sum += this.newBD.sl_cloning_list[i].part_seq.Length;
                    }
                    else
                    {
                        str_sum += this.newBD.sl_cloning_list[i].part_seq;
                        i_sum += 150;
                        //i_sum += this.newBD.sl_cloning_list[i].part_seq.Length;
                    }

                }

                int str_sum_num = str_sum.Length;

                // 전체 길이를 가져왔으니 시퀀스마다를 계산해서 각도를 계산한다.

                for (int i = 0; i < this.newBD.sl_cloning_list.Count; i++)
                {
                    double temp1 = 0;

                    if (this.newBD.sl_cloning_list[i].part_seq.Length <= 10)
                    {
                        temp1 = 5 / (double)i_sum;
                    }
                    else if (this.newBD.sl_cloning_list[i].part_seq.Length <= 100 && this.newBD.sl_cloning_list[i].part_seq.Length > 10)
                    {
                        //temp1 = (double)this.newBD.sl_cloning_list[i].part_seq.Length / (double)i_sum;
                        temp1 = 15 / (double)i_sum;
                    }
                    else if (this.newBD.sl_cloning_list[i].part_seq.Length <= 1000 && this.newBD.sl_cloning_list[i].part_seq.Length > 100)
                    {
                        temp1 = 50 / (double)i_sum;
                    }
                    else
                    {
                        temp1 = 150 / (double)i_sum;
                    }

                    _s.Color = get_type_color(this.newBD.sl_cloning_list[i].part_type);

                    int z = (360 - 90 + p_do) % 360;

                    if (i == this.newBD.sl_cloning_list.Count - 1)
                    {
                        if (i == lb_select)
                        {
                            int zz = 270 - z;

                            _g.FillPie(_s, ((pn_Circle.Size.Width / 2) - 160), ((pn_Circle.Size.Height / 2) - 160), 320, 320, z, zz);
                        }
                        else
                        {
                            int zz = 270 - z;

                            _g.FillPie(_s, ((pn_Circle.Size.Width / 2) - 150), ((pn_Circle.Size.Height / 2) - 150), 300, 300, z, zz);
                        }

                    }
                    else
                    {
                        if (i == lb_select)
                        {
                            _g.FillPie(_s, ((pn_Circle.Size.Width / 2) - 160), ((pn_Circle.Size.Height / 2) - 160), 320, 320, z, (int)Math.Round(temp1 * 360));
                        }
                        else
                        {
                            _g.FillPie(_s, ((pn_Circle.Size.Width / 2) - 150), ((pn_Circle.Size.Height / 2) - 150), 300, 300, z, (int)Math.Round(temp1 * 360));
                        }


                    }

                    p_do += (int)Math.Round(temp1 * 360);

                }

                _s.Color = Color.White;

                _g.FillPie(_s, ((pn_Circle.Size.Width / 2) - 130), ((pn_Circle.Size.Height / 2) - 130), 260, 260, 0f, 360f);
            }
        }


        /// <summary>
        /// 리스트박스에서 선택할때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Brick_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_brick(lb_Brick.SelectedIndex);
            lb_select = lb_Brick.SelectedIndex;
            paint_Circle();
        }


        /// <summary>
        /// 선택한 브릭 정보 뿌려주기
        /// </summary>
        /// <param name="_index"></param>
        private void select_brick(int _index)
        {
            try
            {
                lb_Subparts.Items.Clear();

                Brick_sub_data _temp;

                int sum = 0;

                if (isCloning)
                {
                    _temp = this.newBD.sl_cloning_list[_index];

                    for (int i = 0; i < _index; i++)
                    {
                        sum += this.newBD.sl_cloning_list[i].part_seq_pixel;
                    }
                }
                else
                {
                    _temp = this.newBD.sl_subpart_list[_index];

                    for (int i = 0; i < _index; i++)
                    {
                        sum += this.newBD.sl_subpart_list[i].part_seq_pixel;
                    }
                }

                tb_Name.Text = _temp.part_name;
                tb_Desc.Text = _temp.part_desc;
                tb_Type.Text = _temp.part_type;
                tb_Status.Text = _temp.part_status;
                tb_Result.Text = _temp.part_result;

                if (_temp.part_id != -1)
                {
                    tb_URL.Text = "http://partsregistry.org/Part:" + _temp.part_name;
                }
                else
                {
                    tb_URL.Text = "";
                }
                tb_Entered.Text = _temp.part_entered;
                tb_BQ.Text = _temp.best_qulity;

                foreach (string _subpart in _temp.subparts)
                {
                    lb_Subparts.Items.Add(_subpart);
                }


                // 여기에 브릭그림 변환하기


                pn_Seq.HorizontalScroll.Value = sum;
                pn_Seq.Update();

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }



        /// <summary>
        /// Circle Paint함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pn_Circle_Paint(object sender, PaintEventArgs e)
        {
            if (isCloning)
            {
                paint_Circle();
            }
        }


        /// <summary>
        /// 스칼이 중복이거나 잘못들어가있는지 체크
        /// </summary>
        /// <returns></returns>
        private bool check_Scar()
        {

            if (this.newBD.sl_subpart_list.Count > 0)
            {

                // 스칼이 맨 앞과 맨 뒤에 있는지 체크하기
                int sb_count = this.newBD.sl_subpart_list.Count;

                if (this.newBD.sl_subpart_list[0].part_type == "Scar" || this.newBD.sl_subpart_list[sb_count - 1].part_type == "Scar")
                {
                    MessageBox.Show("There are some errors on the location of scar.");
                    return false;
                }

                for (int i = 0; i < sb_count - 2; i++)
                {
                    if (this.newBD.sl_subpart_list[i].part_type == "Scar" && this.newBD.sl_subpart_list[i + 1].part_type == "Scar")
                    {
                        MessageBox.Show("There are some errors on the location of scar.");
                        return false;
                    }
                }

                return true;
            }
            else
            {
                // return;

                return true;
            }
        }

        /// <summary>
        /// 스칼과 그 다음 브릭 검사해서 스칼 시퀀스, 이름 교체
        /// </summary>
        public void processing_Scar()
        {
            for (int i = 0; i < this.newBD.sl_subpart_list.Count; i++)
            {
                if (this.newBD.sl_subpart_list[i].part_type == "Scar")
                {
                    if (this.newBD.sl_subpart_list[i + 1].part_seq.StartsWith("atg"))
                    {
                        this.newBD.sl_subpart_list[i].part_seq = "tactag";
                    }
                    else
                    {
                        this.newBD.sl_subpart_list[i].part_seq = "tactagag";
                    }

                    this.newBD.sl_subpart_list[i].part_name = "Spe1+Xba1";
                }

            }

            isScar = true;
        }

        /// <summary>
        /// 클로닝 시퀀스 하는거염
        /// </summary>
        /// <param name="bb_name"></param>
        /// <param name="bb_seq"></param>
        /// <param name="rs1"></param>
        /// <param name="i_rs1"></param>
        /// <param name="rs2"></param>
        /// <param name="i_rs2"></param>
        public void processing_Seq(string bb_name, string bb_seq, string rs1, int i_rs1, string rs2, int i_rs2, bool isReg)
        {

            // 먼저 브릭리스트 앞에 해당되는 pre, suf 붙여주기
            // 그런 다음에 bb seq를 가공하고 seq의 정보를 보고 

            // 먼저 위치계산을 먼저 해서 브릭이 앞에 갈지 뒤에 갈지를 결정

            // 하지만 rs가 오는 순서는 prefix인지 suffix인지는 결정되어 있으니

            string str_brick_prefix;
            string str_brick_suffix;

            string str_plasmid_seq;

            if (rs1 == "Ecor1")
            {
                if (this.newBD.sl_subpart_list[0].part_seq.StartsWith("atg"))
                {
                    str_brick_prefix = "cgcggccgcttctaga";
                }
                else
                {
                    str_brick_prefix = "cgcggccgcttctagag";
                }
            }
            else
            {
                if (this.newBD.sl_subpart_list[0].part_seq.StartsWith("atg"))
                {
                    str_brick_prefix = "ag";
                }
                else
                {
                    str_brick_prefix = "a";
                }
            }

            if (rs2 == "Pst1")
            {
                str_brick_suffix = "tactagtagcggccgc";
            }
            else
            {
                str_brick_suffix = "ta";
            }

            // 제한효소가 뒤집어 있으면 서열 뒤집기
            // 아니면 그대로
            // 그리고 나서 prefix 넣고 브릭 넣고 서픽스 넣고 제한효소 넣고 시퀀스 넣고 제한효소 넣고 끝.


            // 백본 시퀀스 서브시퀀스 가져오기
            // rs1 이 더 큼
            // rs2 는 앞 쪽임

            str_plasmid_seq = bb_seq.Substring(i_rs2 + 5, Math.Abs(i_rs1 + 1 - (i_rs2 + 5)));

            // 현재 백본 시퀀스 처리

            if (i_rs2 > i_rs1)
            {
                string str_plasmid_seq_d = "";
                foreach (char c in str_plasmid_seq.ToCharArray())
                {
                    switch (c)
                    {
                        case 'a':
                            str_plasmid_seq_d += 't';
                            break;
                        case 't':
                            str_plasmid_seq_d += 'a';
                            break;
                        case 'c':
                            str_plasmid_seq_d += 'g';
                            break;
                        case 'g':
                            str_plasmid_seq_d += 'c';
                            break;
                    }
                }
                str_plasmid_seq = str_plasmid_seq_d;
            }

            // 클로닝 리스트 작성
            // 1. Prefix
            // 2. 브릭리스트
            // 3. Suffix
            // 4. 제한효소
            // 5. 백본 시퀀스
            // 6. 제한효소

            int i = 0;

            Brick_sub_data _bsd = new Brick_sub_data();
            _bsd.part_name = "Prefix";
            _bsd.part_type = "Prefix";
            _bsd.part_seq = str_brick_prefix;
            this.newBD.sl_cloning_list.Add(0, _bsd);

            for (i = 1; i < this.newBD.sl_subpart_list.Count + 1; i++)
            {
                this.newBD.sl_cloning_list.Add(i, newBD.sl_subpart_list[i - 1]);
            }

            _bsd = new Brick_sub_data();
            _bsd.part_name = "Suffix";
            _bsd.part_type = "Suffix";
            _bsd.part_seq = str_brick_suffix;
            this.newBD.sl_cloning_list.Add(i, _bsd);

            _bsd = new Brick_sub_data();
            _bsd.part_name = rs2;
            _bsd.part_type = rs2;
            _bsd.part_seq = this.get_SR_seq(rs1);
            this.newBD.sl_cloning_list.Add(i + 1, _bsd);

            _bsd = new Brick_sub_data();
            //_bsd.part_name = bb_name;

            connector = new DBconnector();

            if (isReg) // 등록된 브릭이면
            {
                string str_q = "select * from part where part_name = '" + bb_name + "'";

                OleDbDataReader oddr = connector.select_Data(str_q);

                while (oddr.Read())
                {
                    _bsd.part_id = oddr.GetInt32(0);
                    _bsd.part_name = oddr.GetString(1);
                    _bsd.part_desc = oddr.GetString(3);
                    _bsd.part_type = oddr.GetString(4);
                    _bsd.part_status = oddr.GetString(5);

                    _bsd.part_result = oddr.GetString(6);

                    _bsd.part_entered = oddr.GetString(10);

                    _bsd.part_author = oddr.GetString(11);
                    _bsd.best_qulity = oddr.GetString(12);
                }

                str_q = "select p.part_name from part as p, specified_subparts as sp where sp.part_id = " + _bsd.part_id + " and sp.subpart_id = p.part_id";

                oddr = connector.select_Data(str_q);

                while (oddr.Read())
                {
                    _bsd.subparts.Add(oddr.GetString(0));
                    lb_Subparts.Items.Add(oddr.GetString(0));
                }
            }
            else
            {
                string str_q = "select * from userbricks where part_name = '" + bb_name + "'";

                OleDbDataReader oddr = connector.select_Data(str_q);

                while (oddr.Read())
                {
                    _bsd.part_name = oddr.GetString(0);
                    _bsd.part_desc = oddr.GetString(2);
                    _bsd.part_type = oddr.GetString(1);
                    _bsd.part_seq = oddr.GetString(3);
                }
            }

            _bsd.part_seq = str_plasmid_seq;
            this.newBD.sl_cloning_list.Add(i + 2, _bsd);

            _bsd = new Brick_sub_data();
            _bsd.part_name = rs1;
            _bsd.part_name = rs1;
            _bsd.part_seq = this.get_SR_seq(rs2);
            this.newBD.sl_cloning_list.Add(i + 3, _bsd);

        }


        /// <summary>
        /// 제한효소 얻는 함수
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string get_SR_seq(string name)
        {
            switch (name)
            {
                case "Ecor1":
                    return "aatt";

                case "Xba1":
                    return "ctag";

                case "Spe1":
                    return "ctag";

                case "Pst1":
                    return "tgca";

                default:
                    return null;
            }

        }

        /// <summary>
        /// 클로닝 캔슬 함수
        /// </summary>
        private void cancel_cloning()
        {
            this.newBD.sl_cloning_list = null;
            this.newBD.sl_cloning_list = new SortedList<int, Brick_sub_data>();

            this.newBD.cancel_scar();
            this.isCloning = false;
            this.pn_Circle.Refresh();
        }


        /// <summary>
        /// 스크린샷 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void screenShotToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (check_Scar())
            {
                if (this.newBD.sl_subpart_list.Count > 0)
                {

                    int i_count = 0;

                    foreach (Brick_sub_data bsd in this.newBD.sl_subpart_list.Values)
                    {
                        if (bsd.part_type != "Scar")
                        {
                            i_count++;
                        }
                    }

                    int width = 256 * i_count;

                    Bitmap _b = new Bitmap(width + 256, 256);
                    Graphics _g = Graphics.FromImage(_b);
                    Pen _p = new Pen(Color.Gray, 20);

                    _g.DrawLine(_p, 0, 128 - 5, width + 256, 128 - 5);

                    int j = 0;

                    for (int i = 0; i < this.newBD.sl_subpart_list.Count; i++)
                    {
                        if (this.newBD.sl_subpart_list[i].part_type != "Scar")
                        {
                            if (this.newBD.sl_subpart_list[i].part_icon == -1)
                            {
                                _g.DrawImage(imgl_highQ.Images[newBD.sl_subpart_list[i].part_type], (j * 256) + (256 / 2), 0, 256, 256);
                            }
                            else
                            {
                                _g.DrawImage(imgl_highQ.Images[newBD.sl_subpart_list[i].part_icon.ToString()], (j * 256) + (256 / 2), 0, 256, 256);
                            }

                            j++;
                        }
                    }

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "png files (*.png)|*.png";
                    sfd.Title = "Save";
                    sfd.FileName = this.newBD.str_brick_name;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        _b.Save(sfd.FileName);
                        MessageBox.Show("Complete");
                    }
                }
                else
                {
                    MessageBox.Show("There isn't a brick you just selected.");
                }
            }
        }



        /// <summary>
        /// 선형 시퀀스 보여주기.
        /// </summary>
        public void paint_linear_Seq()
        {
            pn_Seq.Controls.Clear();

            if (isCloning)
            {
                if (this.newBD.sl_cloning_list.Count > 0)
                {

                    Label lb;
                    int pre_width = 0;
                    Font _f = new Font("tahoma", 12);

                    for (int i = 0; i < this.newBD.sl_cloning_list.Count; i++)
                    {
                        lb = new Label();
                        lb.ForeColor = Color.Black;
                        lb.Font = _f;
                        lb.Location = new Point(pre_width, (pn_Seq.Size.Height / 2) - 15);
                        lb.AutoSize = true;
                        lb.Text = this.newBD.sl_cloning_list[i].part_seq;
                        lb.TextAlign = ContentAlignment.MiddleCenter;
                        lb.ForeColor = Color.White;
                        lb.BackColor = get_type_color(this.newBD.sl_cloning_list[i].part_type);
                        pn_Seq.Controls.Add(lb);

                        this.newBD.sl_cloning_list[i].part_seq_pixel = lb.Size.Width + 5;

                        pre_width += lb.Size.Width + 5;
                    }
                }
            }
            else
            {
                // 클로닝 전에는 브릭 데이터로 뿌려준다.
                if (this.newBD.sl_subpart_list.Count > 0)
                {

                    Label lb;
                    int pre_width = 0;
                    Random _r = new Random();
                    Font _f = new Font("tahoma", 12);

                    for (int i = 0; i < this.newBD.sl_subpart_list.Count; i++)
                    {
                        lb = new Label();
                        lb.AutoEllipsis = true;
                        lb.ForeColor = Color.Black;
                        lb.Font = _f;
                        lb.Location = new Point(pre_width, (pn_Seq.Size.Height / 2) - 15);
                        lb.AutoSize = true;
                        lb.Text = this.newBD.sl_subpart_list[i].part_seq;
                        lb.TextAlign = ContentAlignment.MiddleCenter;
                        lb.ForeColor = Color.White;
                        lb.BackColor = get_type_color(this.newBD.sl_subpart_list[i].part_type);
                        pn_Seq.Controls.Add(lb);

                        this.newBD.sl_subpart_list[i].part_seq_pixel = lb.Size.Width + 5;

                        pre_width += lb.Size.Width + 5;
                    }

                }

            }

        }


        private void genbankToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.newBD.sl_subpart_list.Count > 0)
            {
                if (this.newBD.str_brick_name == null)
                {
                    MessageBox.Show("Please enter information.");
                    Form_Save fs1 = new Form_Save(this, 1);
                    fs1.ShowDialog();
                }

                export_GenBank();
            }
            else
            {
                MessageBox.Show("There is no Data to save.");
            }
        }



        private void export_GenBank()
        {

            

            SaveFileDialog _sfd = new SaveFileDialog();
            _sfd.Filter = "Genbank files (*.gb)|*.gb";
            _sfd.FileName = this.newBD.str_brick_name;
            _sfd.Title = "Save";

            if (_sfd.ShowDialog() == DialogResult.OK)
            {

                StringBuilder sb_seqContent = new StringBuilder();
                Stream sr_Stream;

                if ((sr_Stream = _sfd.OpenFile()) != null)
                {
                    TextWriter tw = new StreamWriter(sr_Stream);

                    if (isCloning)
                    {
                        foreach (Brick_sub_data bsd in this.newBD.sl_cloning_list.Values)
                        {
                            this.newBD.str_sequence += bsd.part_seq;
                        }

                        // 현재 서브 브릭 아웃풋 하기

                        // 1번 줄
                        tw.Write("LOCUS       ");
                        tw.Write(this.newBD.str_brick_name);
                        tw.Write("     ");
                        tw.Write(this.newBD.str_sequence.Length);
                        tw.Write(" bp    DNA         SYN       ");
                        tw.WriteLine(DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year);

                        // 2번 줄
                        tw.Write("ACCESSION   ");
                        tw.WriteLine(this.newBD.str_brick_name);

                        // 3번 줄
                        tw.WriteLine("KEYWORDS    ");

                        // 4번 줄
                        tw.WriteLine("SOURCE      Synthetic");

                        // 5번 줄
                        tw.WriteLine("  ORGANISM  Synthetic");

                        // 6번 줄
                        tw.WriteLine("COMMENT     ");

                        // 7번 줄
                        tw.WriteLine("FEATURES             Location/Qualifiers");

                        // 8번 줄
                        tw.Write("     source          1..");
                        tw.WriteLine(this.newBD.str_sequence.Length);

                        // 9번 줄
                        tw.WriteLine("                     /organism=\"Synthetic\"");

                        int i = 1;

                        foreach (Brick_sub_data _bsd in this.newBD.sl_cloning_list.Values)
                        {
                            tw.WriteLine("     misc_feature    " + i + ".." + (i + _bsd.part_seq.Length - 1));
                            i += _bsd.part_seq.Length;
                            tw.WriteLine("                     /product=\"" + _bsd.part_name + "\"");
                            tw.WriteLine("                     /label=\"" + _bsd.part_name + "\"");
                        }

                        tw.WriteLine("ORIGIN");

                        bool bFlag = true;

                        string str_seq = this.newBD.str_sequence;
                        int z = 0;

                        while (bFlag)
                        {
                            tw.Write(string.Format("{0,9}", (1 + (60 * z)).ToString()) + " ");

                            for (int j = 0; j < 6; j++)
                            {

                                if (str_seq.Length >= 10)
                                {
                                    if (j == 5)
                                    {
                                        tw.WriteLine(str_seq.Substring(0, 10));
                                    }
                                    else
                                    {
                                        tw.Write(str_seq.Substring(0, 10) + " ");
                                    }
                                    str_seq = str_seq.Substring(10);
                                }
                                else
                                {
                                    tw.WriteLine(str_seq.Substring(0));
                                    bFlag = false;
                                    break;
                                }
                            }
                            z++;
                        }

                        tw.WriteLine("//");
                    }
                    else
                    {
                        this.processing_Scar();
                        this.listbox_from_BrickData();

                        foreach (Brick_sub_data bsd in this.newBD.sl_subpart_list.Values)
                        {
                            this.newBD.str_sequence += bsd.part_seq;
                        }

                        // 현재 서브 브릭 아웃풋 하기

                        // 1번 줄
                        tw.Write("LOCUS       ");
                        tw.Write(this.newBD.str_brick_name);
                        tw.Write("     ");
                        tw.Write(this.newBD.str_sequence.Length);
                        tw.Write(" bp    DNA         SYN       ");
                        tw.WriteLine(DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year);

                        // 2번 줄
                        tw.Write("ACCESSION   ");
                        tw.WriteLine(this.newBD.str_brick_name);

                        // 3번 줄
                        tw.WriteLine("KEYWORDS    ");

                        // 4번 줄
                        tw.WriteLine("SOURCE      Synthetic");

                        // 5번 줄
                        tw.WriteLine("  ORGANISM  Synthetic");

                        // 6번 줄
                        tw.WriteLine("COMMENT     ");

                        // 7번 줄
                        tw.WriteLine("FEATURES             Location/Qualifiers");

                        // 8번 줄
                        tw.Write("     source          1..");
                        tw.WriteLine(this.newBD.str_sequence.Length);

                        // 9번 줄
                        tw.WriteLine("                     /organism=\"Synthetic\"");

                        int i = 1;

                        foreach (Brick_sub_data _bsd in this.newBD.sl_subpart_list.Values)
                        {
                            tw.WriteLine("     misc_feature    " + i + ".." + (i + _bsd.part_seq.Length - 1));
                            i += _bsd.part_seq.Length;
                            tw.WriteLine("                     /product=\"" + _bsd.part_name + "\"");
                            tw.WriteLine("                     /label=\"" + _bsd.part_name + "\"");
                        }

                        tw.WriteLine("ORIGIN");

                        bool bFlag = true;

                        string str_seq = this.newBD.str_sequence;
                        int z = 0;

                        while (bFlag)
                        {
                            tw.Write(string.Format("{0,9}", (1 + (60 * z)).ToString()) + " ");

                            for (int j = 0; j < 6; j++)
                            {

                                if (str_seq.Length >= 10)
                                {
                                    if (j == 5)
                                    {
                                        tw.WriteLine(str_seq.Substring(0, 10));
                                    }
                                    else
                                    {
                                        tw.Write(str_seq.Substring(0, 10) + " ");
                                    }
                                    str_seq = str_seq.Substring(10);
                                }
                                else
                                {
                                    tw.WriteLine(str_seq.Substring(0));
                                    bFlag = false;
                                    break;
                                }
                            }
                            z++;
                        }

                        tw.WriteLine("//");
                    }

                    tw.Close();
                    MessageBox.Show("Complete","GenBank",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                
            }


            

        }

        private void sBOLToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.newBD.str_brick_name == null)
            {
                // 정보를 입력하라고 해서 정보를 입력하게 되면 SBOL을 출력시켜야 한다.
                MessageBox.Show("Please enter information.");
                Form_Save fs1 = new Form_Save(this, 1);
                fs1.ShowDialog();
            }

            SaveFileDialog _sfd = new SaveFileDialog();
            _sfd.Filter = "SBOL files (*.SBOL)|*.SBOL";
            _sfd.FileName = this.newBD.str_brick_name;
            _sfd.Title = "Save";

            if (_sfd.ShowDialog() == DialogResult.OK)
            {
                if (this.newBD.sl_subpart_list.Count > 0)
                {
                    StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "SBOLSTARTFILE.txt"));
                    sw.WriteLine("http://partsregistry.org/Part:" + this.newBD.str_brick_name);
                    sw.WriteLine(this.newBD.str_brick_name);

                    if (this.newBD.str_brick_name.Contains("_") == true)
                    {
                        sw.WriteLine((this.newBD.str_brick_name.Split('_'))[1]);
                    }
                    else
                    {
                        sw.WriteLine(this.newBD.str_brick_name);
                    }

                    sw.WriteLine(this.newBD.str_brick_desc);

                    
                    foreach (Brick_sub_data _bsd in this.newBD.sl_subpart_list.Values)
                    {
                        sw.Write(_bsd.part_seq);
                    }

                    sw.WriteLine(Environment.NewLine);

                    int i = 0;

                    foreach (Brick_sub_data bsd in this.newBD.sl_subpart_list.Values)
                    {
                        if (bsd.part_type != "Scar")
                        {
                            i++;
                        }
                    }
                    sw.WriteLine(i);
                    foreach (Brick_sub_data bsd in this.newBD.sl_subpart_list.Values)
                    {
                        if (bsd.part_type != "Scar")
                        {
                            sw.WriteLine("http://partsregistry.org/Part:" + bsd.part_name);
                            sw.WriteLine(bsd.part_name);

                            if (bsd.part_name.Contains("_") == true)
                            {
                                sw.WriteLine((bsd.part_name.Split('_'))[1]);
                            }
                            else
                            {
                                sw.WriteLine(bsd.part_name);
                            }
                            sw.WriteLine(bsd.part_desc);
                        }
                    }

                    sw.Close();

                    str_SBOL_filename = _sfd.FileName;
                }

                _pro.Start();
            }



            

        }

        void _pro_Exited(object sender, EventArgs e)
        {
            FileInfo sbol_txt = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "SBOLSTARTFILE.txt"));
            FileInfo sbol_xml = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "SBOLMIDFILE.xml"));

            sbol_txt.Delete();

            sbol_xml.CopyTo(str_SBOL_filename, true);
            sbol_xml.Delete();

            MessageBox.Show("Complete");
        }

        private void fastaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isCloning)
            {

                StringBuilder sb_seqContent = new StringBuilder();
                Stream sr_Stream;

                SaveFileDialog saveFD = new SaveFileDialog();
                saveFD.Filter = "Fasta files (*fasta)|*.fasta";
                saveFD.FileName = this.newBD.str_brick_name;

                if (saveFD.ShowDialog() == DialogResult.OK)
                {
                    if ((sr_Stream = saveFD.OpenFile()) != null)
                    {
                        TextWriter tw = new StreamWriter(sr_Stream);

                        sb_seqContent.Append("> " + newBD.str_brick_name + " " + newBD.str_brick_type + " " + "\"" + newBD.str_brick_desc + "\"");
                        sb_seqContent.Append(Environment.NewLine);

                        foreach (Brick_sub_data bsd in this.newBD.sl_cloning_list.Values)
                        {
                            sb_seqContent.Append(bsd.part_seq);
                        }

                        tw.WriteLine(sb_seqContent.ToString());
                        tw.Close();


                    }
                }

            }
            else
            {
                if (this.newBD.sl_subpart_list.Count > 0)
                {
                    StringBuilder sb_seqContent = new StringBuilder();
                    Stream sr_Stream;

                    SaveFileDialog saveFD = new SaveFileDialog();
                    saveFD.Filter = "Fasta files (*fasta)|*.fasta";
                    saveFD.FileName = this.newBD.str_brick_name;

                    if (saveFD.ShowDialog() == DialogResult.OK)
                    {
                        if ((sr_Stream = saveFD.OpenFile()) != null)
                        {
                            TextWriter tw = new StreamWriter(sr_Stream);

                            sb_seqContent.Append("> " + newBD.str_brick_name + " " + newBD.str_brick_type + " " + "\"" + newBD.str_brick_desc + "\"");
                            sb_seqContent.Append(Environment.NewLine);

                            foreach (Brick_sub_data bsd in this.newBD.sl_subpart_list.Values)
                            {
                                sb_seqContent.Append(bsd.part_seq);
                            }

                            tw.WriteLine(sb_seqContent.ToString());
                            tw.Close();


                        }
                    }
                }
            }
        }

        private void scarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (check_Scar())
            {
                this.processing_Scar();
                this.listbox_from_BrickData();
                this.paint_linear_Seq();
            }
        }

        // 현재 폼이름 변경시켜서 뿌려주기
        public void change_FromName()
        {
            this.Text = "Brick Designer (" + this.newBD.str_brick_name + ")";
        }
    }
}




