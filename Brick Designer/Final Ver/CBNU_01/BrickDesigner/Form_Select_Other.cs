﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BrickDesigner
{
    public partial class Form_Select_Other : Form
    {

        Form_Main fMain;
        DBconnector connector;


        Brick_sub_data select_data;


        public Form_Select_Other()
        {
            InitializeComponent();
        }

        public Form_Select_Other(Form_Main _fmain)
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            connector = new DBconnector();
            fMain = _fmain;

            listview_from_DB();
            combobox_setting_item();
        }

        private void combobox_setting_item()
        {
            for (int i = 1; i <= 10; i++ )
            {
                cb_Icon.Items.Add("Icon " + i);
            }
        }


        /// <summary>
        /// 리스트뷰에 Other에 해당하는 브릭을 뿌려준다.
        /// </summary>
        private void listview_from_DB()
        {
            ListViewItem item;

            string str_q = "select part_name, part_short_desc, part_type from part where part_short_name is not null and (part_type = '' or part_type = 'Basic' or part_type = 'Cell' or part_type = 'Composite' or part_type = 'Conjugation' or part_type = 'Device' or part_type = 'Intermediate' or part_type = 'Other' or part_type = 'Project' or part_type = 'Project' or part_type = 'RNA' or part_type = 'T7' or part_type = 'Tag' or part_type = 'Temporary')";

            OleDbDataReader oddr = connector.select_Data(str_q);

            lv_Type.Groups.Add("Registered Brick", "Registered Brick");

            while (oddr.Read())
            {
                item = new ListViewItem(oddr.GetString(0));
                item.SubItems.Add(oddr.GetString(1));
                item.SubItems.Add(oddr.GetString(2));
                item.Group = lv_Type.Groups["Registered Brick"];

                lv_Type.Items.Add(item);
            }

            str_q = "select part_name, part_desc, part_type from userbricks where part_type = '' or part_type = 'Basic' or part_type = 'Cell' or part_type = 'Composite' or part_type = 'Conjugation' or part_type = 'Device' or part_type = 'Intermediate' or part_type = 'Other' or part_type = 'Project' or part_type = 'Project' or part_type = 'RNA' or part_type = 'T7' or part_type = 'Tag' or part_type = 'Temporary'";

            oddr = connector.select_Data(str_q);

            lv_Type.Groups.Add("User's Brick", "User's Brick");

            while (oddr.Read())
            {
                item = new ListViewItem(oddr.GetString(0));
                item.SubItems.Add(oddr.GetString(1));
                item.SubItems.Add(oddr.GetString(2));
                item.Group = lv_Type.Groups["User's Brick"];

                lv_Type.Items.Add(item);
            }

            oddr.Close();


        }

        /// <summary>
        /// 서치버튼 눌렀을때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Search_Click(object sender, EventArgs e)
        {
            if (tb_Search.Text.Length != 0)
            {
                lv_Type.Items.Clear();
                lv_Type.Groups.Clear();

                string str_qu = "select part_name, part_short_desc, part_type from part where part_short_name is not null and part_name like '%"+tb_Search.Text+"%' and (part_type = '' or part_type = 'Basic' or part_type = 'Cell' or part_type = 'Composite' or part_type = 'Conjugation' or part_type = 'Device' or part_type = 'Intermediate' or part_type = 'Other' or part_type = 'Project' or part_type = 'Project' or part_type = 'RNA' or part_type = 'T7' or part_type = 'Tag' or part_type = 'Temporary')";

                OleDbDataReader oddr = connector.select_Data(str_qu);

                ListViewItem item;

                lv_Type.Groups.Add("Registered Brick", "Registered Brick");

                while (oddr.Read())
                {
                    item = new ListViewItem(oddr.GetString(0));
                    item.SubItems.Add(oddr.GetString(1));
                    item.SubItems.Add(oddr.GetString(2));
                    item.Group = lv_Type.Groups["Registered Brick"];

                    lv_Type.Items.Add(item);
                }

                str_qu = "select part_name, part_desc, part_type from userbricks where part_name like '%"+tb_Search.Text+"%' and (part_type = '' or part_type = 'Basic' or part_type = 'Cell' or part_type = 'Composite' or part_type = 'Conjugation' or part_type = 'Device' or part_type = 'Intermediate' or part_type = 'Other' or part_type = 'Project' or part_type = 'Project' or part_type = 'RNA' or part_type = 'T7' or part_type = 'Tag' or part_type = 'Temporary')";

                oddr = connector.select_Data(str_qu);

                lv_Type.Groups.Add("User's Brick", "User's Brick");

                while (oddr.Read())
                {
                    item = new ListViewItem(oddr.GetString(0));
                    item.SubItems.Add(oddr.GetString(1));
                    item.SubItems.Add(oddr.GetString(2));
                    item.Group = lv_Type.Groups["User's Brick"];

                    lv_Type.Items.Add(item);
                }

                oddr.Close();
            }
        }



        /// <summary>
        /// 리스트뷰에서 브릭선택시 해당 정보 및 데이터 저장 및 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_Type.SelectedItems.Count > 0)
            {
                select_data = null;
                select_data = new Brick_sub_data();
                lb_SubParts.Items.Clear();
                tb_Entered.Text = "";
                tb_BQ.Text = "";
                tb_Status.Text = "";
                tb_Result.Text = "";

                if (lv_Type.SelectedItems[0].Group.Name == "Registered Brick")
                {
                    string str_q = "select * from part where part_name = '" + lv_Type.SelectedItems[0].Text + "'";

                    OleDbDataReader oddr = connector.select_Data(str_q);

                    while (oddr.Read())
                    {
                        select_data.part_id = oddr.GetInt32(0);
                        select_data.part_name = oddr.GetString(1);
                        select_data.part_desc = oddr.GetString(3);
                        select_data.part_type = oddr.GetString(4);
                        select_data.part_status = oddr.GetString(5);
                        tb_Status.Text = oddr.GetString(5);

                        select_data.part_result = oddr.GetString(6);
                        tb_Result.Text = oddr.GetString(6);

                        select_data.part_entered = oddr.GetString(10);
                        tb_Entered.Text = oddr.GetString(10);

                        select_data.part_author = oddr.GetString(11);
                        select_data.best_qulity = oddr.GetString(12);
                        tb_BQ.Text = oddr.GetString(12);
                    }

                    str_q = "select sequences.seq_data from sequences, part where part.part_name = '" + lv_Type.SelectedItems[0].Text + "' and part.part_id = sequences.part_id";

                    oddr = connector.select_Data(str_q);

                    while (oddr.Read())
                    {
                        select_data.part_seq = oddr.GetString(0);
                    }


                    str_q = "select p.part_name from part as p, specified_subparts as sp where sp.part_id = " + select_data.part_id + " and sp.subpart_id = p.part_id";

                    oddr = connector.select_Data(str_q);

                    while (oddr.Read())
                    {
                        select_data.subparts.Add(oddr.GetString(0));
                        lb_SubParts.Items.Add(oddr.GetString(0));
                    }
                }
                else if (lv_Type.SelectedItems[0].Group.Name == "User's Brick")
                {
                    string str_q = "select * from userbricks where part_name = '" + lv_Type.SelectedItems[0].Text + "'";

                    OleDbDataReader oddr = connector.select_Data(str_q);

                    while (oddr.Read())
                    {
                        select_data.part_name = oddr.GetString(0);
                        select_data.part_desc = oddr.GetString(2);
                        select_data.part_type = oddr.GetString(1);
                        select_data.part_seq = oddr.GetString(3);
                    }
                }

            }
        }

        private void cb_Icon_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cb_Icon.SelectedIndex)
            {
                case 0:
                    pictureBox1.Image = Properties.Resources._20;
            	    break;
                case 1:
                    pictureBox1.Image = Properties.Resources._21;
            	    break;
                case 2:
                    pictureBox1.Image = Properties.Resources._22;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources._23;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources._24;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources._25;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources._26;
                    break;
                case 7:
                    pictureBox1.Image = Properties.Resources._27;
                    break;
                case 8:
                    pictureBox1.Image = Properties.Resources._28;
                    break;
                case 9:
                    pictureBox1.Image = Properties.Resources._29;
                    break;
            }

            if (select_data != null)
            {
                select_data.part_icon = cb_Icon.SelectedIndex;
            }
        }

        private void lv_Type_DoubleClick(object sender, EventArgs e)
        {
            if (lv_Type.SelectedItems.Count > 0)
            {
                this.select_ok();
            }
        }

        private void bt_Ok_Click(object sender, EventArgs e)
        {
            this.select_ok();
        }

        private void select_ok()
        {
            if (select_data != null)
            {

                if (select_data.part_icon == -1)
                {
                    if (cb_Icon.SelectedItem == null)
                    {
                        MessageBox.Show("Please select icon.");
                    }
                    else
                    {
                        select_data.part_icon = cb_Icon.SelectedIndex;
                        fMain.Add_BrickData(select_data);
                        this.Close();
                    }
                }
                else
                {
                    fMain.Add_BrickData(select_data);
                    this.Close();
                }
            }
        }



        //////////////////////////////////////////////////////////////////////////
        // 만약에 OK 버튼이나 더블클릭해서 보낼때 icon넘버가 없으면 다시 선택해서 보내주기
        //////////////////////////////////////////////////////////////////////////



    }
}
