﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;

namespace BrickDesigner
{
    public partial class Form_Add : Form
    {

        DBconnector connector;

        public Form_Add()
        {
            InitializeComponent();

            connector = new DBconnector();

            combo_From_DB();
            lv_From_DB();
        }


        /// <summary>
        /// 데이터베이스에서 userBricks 데이터 가져와서 뿌려주기
        /// </summary>
        private void lv_From_DB()
        {
            try
            {

                lv_All.Items.Clear();

                ListViewItem item;
                string str_qu = "select part_name, part_desc, part_type from userbricks";

                OleDbDataReader oddr = connector.select_Data(str_qu);

                lv_All.Groups.Add("User","User");

                while (oddr.Read())
                {
                    item = new ListViewItem(oddr.GetString(0));
                    item.SubItems.Add(oddr.GetString(1));
                    item.SubItems.Add(oddr.GetString(2));
                    item.Group = lv_All.Groups["User"];

                    lv_All.Items.Add(item);
                }

                oddr.Close();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 데이터베이스에서 Type 가지고 오기
        /// </summary>
        private void combo_From_DB()
        {
            try
            {
                cb_Type.Items.Clear();

                string str_select_qu = "select distinct(part_type) from part";

                OleDbDataReader oddr = connector.select_Data(str_select_qu);

                while (oddr.Read())
                {
                    cb_Type.Items.Add(oddr.GetString(0));
                }

                oddr.Close();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// DB에 브릭 데이터 넣기
        /// </summary>
        private void insert_DB()
        {
            if (this.cb_Type.SelectedItem == null || this.tb_Name.TextLength == 0 || this.tb_Seq.TextLength == 0)
            {
                MessageBox.Show("Error.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string str_qu = " insert into userbricks values (@NAME, @TYPE, @DESC, @SEQ) ";

                OleDbCommand conm = new OleDbCommand(str_qu);

                conm.Parameters.AddWithValue("@ID", tb_Name.Text);
                conm.Parameters.AddWithValue("@TYPE", cb_Type.SelectedItem.ToString());
                conm.Parameters.AddWithValue("@DESC", tb_Desc.Text);
                conm.Parameters.AddWithValue("@SEQ", tb_Seq.Text.Replace("\r\n","").Replace(" ",""));

                if (connector.insert_Data(conm))
                {
                    MessageBox.Show("Complete.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lv_From_DB();
                }
                else
                {
                    MessageBox.Show("Fail.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// OK버튼눌렀을 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Ok_Click(object sender, EventArgs e)
        {
            this.insert_DB();
        }

        /// <summary>
        /// 텍스트 박스에서 Enter넣기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (sender as TextBox == tb_Name)
                {
                    tb_Desc.Focus();
                }

            }
        }
    }
}
