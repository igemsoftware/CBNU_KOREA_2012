﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


/*
 * 생성자에서 부품선택
 * 디비에서 뿌려와서 모두 보여줌
 * 검색기능
 * 셀렉트되어있는 곳 메인으로 보내기
 * 
 * 
 */


namespace BrickDesigner
{
    public partial class Form_Select : Form
    {
        string str_FormType;
        Form_Main fMain;

        DBconnector connector;

        Brick_sub_data select_data;

        public Form_Select()
        {
            InitializeComponent();
        }

        public Form_Select(Form_Main _fMain, string _strType)
        {
            InitializeComponent();

            connector = new DBconnector();

            str_FormType = _strType;
            fMain = _fMain;

            select_to_listview();
        }


        /// <summary>
        /// 해당 타입의 브릭들 리스트뷰에 보여주기
        /// </summary>
        public void select_to_listview()
        {
            ListViewItem item;

            string str_q = "select part_name, part_short_desc, part_type from part where part_type = '" + str_FormType + "' and part_short_name is not null;";

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

            str_q = "select part_name, part_desc, part_type from userbricks where part_type = '"+str_FormType+"'";

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
        /// Search버튼 눌렀을 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Search_Click(object sender, EventArgs e)
        {
            try
            {
                lv_Type.Items.Clear();
                lv_Type.Groups.Clear();

                string str_qu = "select part_name, part_short_desc, part_type from part where part_name like '%" + tb_Search.Text + "%' and part_type = '" + str_FormType + "' and part_short_name is not null;";

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

                str_qu = "select part_name, part_desc, part_type from userbricks where part_name like '%" + tb_Search.Text + "%' and part_type = '" + str_FormType + "'";

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
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 리스트뷰에서 브릭선택시 해당 정보 데이터 저장 및 보여주기
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

        /// <summary>
        /// OK버튼 눌렀을 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                this.select_ok();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 리스트뷰에서 브릭 더블클릭시 메인으로 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_Type_DoubleClick(object sender, EventArgs e)
        {
            if (lv_Type.SelectedItems.Count > 0)
            {
                this.select_ok();
            }
        }

        /// <summary>
        /// 선택 완료시 메인으로 넘겨주기
        /// </summary>
        private void select_ok()
        {
            if (select_data != null)
            {
                fMain.Add_BrickData(select_data);
                this.Close();
            }
        }
    }
}
