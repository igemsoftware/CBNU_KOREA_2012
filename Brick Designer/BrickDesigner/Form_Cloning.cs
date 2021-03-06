﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.OleDb;

namespace BrickDesigner
{
    public partial class Form_Cloning : Form
    {

        static class SR
        {
            public const string str_ecor1_seq = "gaattc";
            public const string str_ecor1_name = "Ecor1";
            public const string str_xba1_seq = "tctaga";
            public const string str_xba1_name = "Xba1";
            public const string str_spe1_seq = "actagt";
            public const string str_spe1_name = "Spe1";
            public const string str_pst1_seq = "ctgcag";
            public const string str_pst1_name = "Pst1";
        }

        Form_Main fmain;

        int i_SP;
        int i_EP;

        int i_selected_Sf = -1;
        int i_selected_Pf = -1;

        bool isSelected_Seq = false;

        DBconnector connector;

        string str_sequence;

        SortedList<int, string> sl_SR;

        public Form_Cloning()
        {
            InitializeComponent();
            connector = new DBconnector();


            list_from_DB();

            i_SP = (int)(pn_view.Size.Width * 0.1);
            i_EP = (int)(pn_view.Size.Width * 0.9);
        }

        public Form_Cloning(Form_Main _fmain)
        {
            InitializeComponent();
            connector = new DBconnector();


            list_from_DB();

            i_SP = (int)(pn_view.Size.Width * 0.1);
            i_EP = (int)(pn_view.Size.Width * 0.9);

            fmain = _fmain;
        }

        //////////////////////////////////////////////////////////////////////////
        // 클로닝툴을 누르면 백본을 선택할 수 있다.
        // 백본을 선택해서 셀렉트 버튼을 누르게 되면
        // 백본의 서열을 이용해서 패널에 그림을 그리게 되고
        // 그림은 제한효소의 위치를 포함한다.
        // 그리고 제한효소들을 리스트박스에서 선택하면 그림에서 제한효소가 부각되며
        // 제한효소를 하나씩 선택하고 OK버튼을 누르면
        // 폼은 꺼지며 메인에서 둥근형태로 표현하게 된다.
        //////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Plasmid_Backbone을 가져와서 리스트에 뿌려주기
        /// </summary>
        private void list_from_DB()
        {
            try
            {
                string str_qu = "select part_name, part_short_desc from part where part_type = 'plasmid_backbone' and part_short_name is not null;";

                OleDbDataReader oddr = connector.select_Data(str_qu);

                ListViewItem item;

                lv_All.Groups.Add("Registered Brick", "Registered Brick");

                while (oddr.Read())
                {
                    item = new ListViewItem(oddr.GetString(0));
                    item.SubItems.Add(oddr.GetString(1));
                    item.Group = lv_All.Groups["Registered Brick"];

                    lv_All.Items.Add(item);
                }

                str_qu = "select part_name, part_desc from userbricks where part_type = 'plasmid_backbone'";

                oddr = connector.select_Data(str_qu);

                lv_All.Groups.Add("User's Brick", "User's Brick");

                while (oddr.Read())
                {
                    item = new ListViewItem(oddr.GetString(0));
                    item.SubItems.Add(oddr.GetString(1));
                    item.Group = lv_All.Groups["User's Brick"];

                    lv_All.Items.Add(item);
                }
                oddr.Close();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Error");
            }
        }


        /// <summary>
        /// select 버튼을 눌렀을 경우 sequence 가져오기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Select_Click(object sender, EventArgs e)
        {
            if (lv_All.SelectedItems.Count > 0)
            {
                select_Brick();
            }
        }

        /// <summary>
        /// 브릭선택시 불려질 함수
        /// </summary>
        private void select_Brick()
        {
            ListViewItem lvi_selectedItem = lv_All.SelectedItems[0];

            if (lvi_selectedItem.Group.Name == "Registered Brick")
            {
                string str_qu = "select sequences.seq_data from sequences, part where part.part_name = '" + lvi_selectedItem.Text + "' and part.part_id = sequences.part_id";

                OleDbDataReader oddr = connector.select_Data(str_qu);

                while (oddr.Read())
                {
                    str_sequence = oddr.GetString(0);
                }

            }
            else if (lvi_selectedItem.Group.Name == "User's Brick")
            {
                string str_qu = "select part_seq from userbricks where part_name = '" + lvi_selectedItem.Text + "'";

                OleDbDataReader oddr = connector.select_Data(str_qu);

                while (oddr.Read())
                {
                    str_sequence = oddr.GetString(0);
                }
            }

            i_selected_Sf = -1;
            i_selected_Pf = -1;
            tb_BrickName.Text = lvi_selectedItem.Text;
            search_RS();
        }

        /// <summary>
        /// 시퀀스에서 제한효소절단위치 찾기
        /// </summary>
        private void search_RS()
        {
            sl_SR = new SortedList<int, string>();


            int i = 0;

            while (str_sequence.IndexOf(SR.str_ecor1_seq, i) != -1)
            {
                i = str_sequence.IndexOf(SR.str_ecor1_seq, i);
                sl_SR.Add(i, SR.str_ecor1_name);
                i += 6;
            }
            i = 0;
            while (str_sequence.IndexOf(SR.str_xba1_seq, i) != -1)
            {
                i = str_sequence.IndexOf(SR.str_xba1_seq, i);
                sl_SR.Add(i, SR.str_xba1_name);
                i += 6;
            }
            i = 0;
            while (str_sequence.IndexOf(SR.str_spe1_seq, i) != -1)
            {
                i = str_sequence.IndexOf(SR.str_spe1_seq, i);
                sl_SR.Add(i, SR.str_spe1_name);
                i += 6;
            }
            i = 0;
            while (str_sequence.IndexOf(SR.str_pst1_seq, i) != -1)
            {
                i = str_sequence.IndexOf(SR.str_pst1_seq, i);
                sl_SR.Add(i, SR.str_pst1_name);
                i += 6;
            }

            if ((sl_SR.Values.Contains(SR.str_ecor1_name) || sl_SR.Values.Contains(SR.str_xba1_name)) && (sl_SR.Values.Contains(SR.str_spe1_name) || sl_SR.Values.Contains(SR.str_pst1_name)))
            {

                // 위치를 퍼센트로 계산한다.
                foreach (int key in sl_SR.Keys)
                {
                    isSelected_Seq = true;
                    // 퍼센트 계산하고 그려주기
                    paint_RS();
                    // 리스트박스 추가하기
                    listbox_from_slSR();
                }
                

            }
            else
            {
                MessageBox.Show("Please select another Brick");
                pn_view.CreateGraphics().Clear(Color.White);
                lb_Pf.Items.Clear();
                lb_Sf.Items.Clear();
            }
        }


        /// <summary>
        /// 시퀀스 그려주기
        /// </summary>
        private void paint_RS()
        {

            if (isSelected_Seq)
            {
                Graphics _g = pn_view.CreateGraphics();
                _g.Clear(Color.White);

                Pen _p = new Pen(Color.Beige, 20f);

                _g.DrawLine(_p, i_SP, (pn_view.Size.Height / 2), i_EP, (pn_view.Size.Height / 2));

                foreach (int key in sl_SR.Keys)
                {

                    if (key == i_selected_Pf || key == i_selected_Sf)
                    {
                        _p.Width = 50f;
                    }
                    else
                    {
                        _p.Width = 20f;
                    }

                    if (sl_SR[key] == SR.str_ecor1_name)
                    {
                        _p.Color = Color.Tomato;
                        int i_percent = (int)(((double)key / str_sequence.Length) * (pn_view.Size.Width * 0.8)) + i_SP;
                        _g.DrawLine(_p, i_percent, (pn_view.Size.Height / 2), i_percent + 3, (pn_view.Size.Height / 2));

                    }
                    else if (sl_SR[key] == SR.str_pst1_name)
                    {
                        _p.Color = Color.Turquoise;

                        int i_percent = (int)(((double)key / str_sequence.Length) * (pn_view.Size.Width * 0.8)) + i_SP;
                        _g.DrawLine(_p, i_percent, (pn_view.Size.Height / 2), i_percent + 3, (pn_view.Size.Height / 2));
                    }
                    else if (sl_SR[key] == SR.str_spe1_name)
                    {
                        _p.Color = Color.BlueViolet;

                        int i_percent = (int)(((double)key / str_sequence.Length) * (pn_view.Size.Width * 0.8)) + i_SP;
                        _g.DrawLine(_p, i_percent, (pn_view.Size.Height / 2), i_percent + 3, (pn_view.Size.Height / 2));
                    }
                    else if (sl_SR[key] == SR.str_xba1_name)
                    {
                        _p.Color = Color.Black;

                        int i_percent = (int)(((double)key / str_sequence.Length) * (pn_view.Size.Width * 0.8)) + i_SP;
                        _g.DrawLine(_p, i_percent, (pn_view.Size.Height / 2), i_percent + 3, (pn_view.Size.Height / 2));
                    }
                }

                _g.Dispose();
                _p.Dispose();
            }
        }


        /// <summary>
        /// 리스트박스에 제한효소 넣어주기
        /// </summary>
        private void listbox_from_slSR()
        {
            lb_Pf.Items.Clear();
            lb_Sf.Items.Clear();

            foreach (string str_value in sl_SR.Values)
            {
                if (str_value == SR.str_ecor1_name || str_value == SR.str_xba1_name)
                {
                    lb_Pf.Items.Add(str_value);
                }
                else if (str_value == SR.str_pst1_name || str_value == SR.str_spe1_name)
                {
                    lb_Sf.Items.Add(str_value);
                }
            }
        }

        /// <summary>
        /// 리스트박스에서 아이템이 선택되면 이벤트 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ListBox).SelectedItems.Count > 0)
            {
                if (sender as ListBox == lb_Pf)
                {
                    int i_selected = 0;
                    // 현재 리스트박스에서 같은 아이템들 중에서 몇번째인지 계산하면 sl_SR에서 몇번째인지 나옴.

                    for (int i = 0; i <= lb_Pf.SelectedIndex; i++)
                    {
                        if (lb_Pf.Items[i].ToString() == lb_Pf.SelectedItem.ToString())
                        {
                            i_selected++;
                        }
                    }

                    foreach (int keys in sl_SR.Keys)
                    {
                        if (sl_SR[keys] == lb_Pf.SelectedItem.ToString())
                        {
                            i_selected--;
                            if (i_selected == 0)
                            {
                                i_selected_Pf = keys;
                                paint_RS();
                            }
                        }
                    }

                }
                else if (sender as ListBox == lb_Sf)
                {
                    int i_selected = 0;
                    // 현재 리스트박스에서 같은 아이템들 중에서 몇번째인지 계산하면 sl_SR에서 몇번째인지 나옴.

                    for (int i = 0; i <= lb_Sf.SelectedIndex; i++)
                    {
                        if (lb_Sf.Items[i].ToString() == lb_Sf.SelectedItem.ToString())
                        {
                            i_selected++;
                        }
                    }

                    foreach (int keys in sl_SR.Keys)
                    {
                        if (sl_SR[keys] == lb_Sf.SelectedItem.ToString())
                        {
                            i_selected--;
                            if (i_selected == 0)
                            {
                                i_selected_Sf = keys;
                                paint_RS();
                            }
                        }
                    }
                }
            }

        }


        /// <summary>
        /// pn_View 다시 그리기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pn_view_Paint(object sender, PaintEventArgs e)
        {
            paint_RS();
        }

        /// <summary>
        /// listview 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_All_DoubleClick(object sender, EventArgs e)
        {
            if (lv_All.SelectedItems.Count > 0)
            {
                select_Brick();
            }
        }

        /// <summary>
        /// OK버튼 누르면 꺼지면서... 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Ok_Click(object sender, EventArgs e)
        {
            // OK버튼을 누르면 시퀀스 클로닝 처리를 해주고
            // 메인에 데이터 전송.


            if (i_selected_Pf == -1 || i_selected_Sf == -1)
            {
                MessageBox.Show("Error.");
                return;
            }


            fmain.isCloning = true;

            fmain.processing_Scar();
            fmain.processing_Seq(tb_BrickName.Text, str_sequence, sl_SR[i_selected_Pf], i_selected_Pf, sl_SR[i_selected_Sf], i_selected_Sf);
            fmain.paint_linear_Seq();
            fmain.listbox_from_BrickData();

            fmain.Refresh();

            this.Close();
        }
    }
}
