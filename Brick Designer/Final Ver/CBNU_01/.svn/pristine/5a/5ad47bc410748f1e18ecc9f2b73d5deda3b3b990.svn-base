using System;
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
    public partial class Form_DB : Form
    {

        DBconnector connector;

        public Form_DB()
        {
            InitializeComponent();

            connector = new DBconnector();


            list_from_DB();
        }


        /// <summary>
        /// 관리해야 하는 데이터 DB에서 가져오기
        /// </summary>
        public void list_from_DB()
        {
            try
            {
                lv_All.Items.Clear();

                ListViewItem item;

                string str_qu = "select part_name, part_short_desc, part_type from part where part_short_name is not null";

                OleDbDataReader oddr = connector.select_Data(str_qu);

                lv_All.Groups.Add("Registered Brick", "Registered Brick");

                while (oddr.Read())
                {
                    item = new ListViewItem(oddr.GetString(0));
                    item.SubItems.Add(oddr.GetString(1));
                    item.SubItems.Add(oddr.GetString(2));
                    item.Group = lv_All.Groups["Registered Brick"];

                    lv_All.Items.Add(item);
                }

                str_qu = "select part_name, part_desc, part_type from userbricks";
                oddr = connector.select_Data(str_qu);

                lv_All.Groups.Add("User's Brick", "User's Brick");

                while (oddr.Read())
                {
                    item = new ListViewItem(oddr.GetString(0));
                    item.SubItems.Add(oddr.GetString(1));
                    item.SubItems.Add(oddr.GetString(2));
                    item.Group = lv_All.Groups["User's Brick"];

                    lv_All.Items.Add(item);
                }

                oddr.Close();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (lv_All.SelectedItems.Count > 0)
            {

                if (MessageBox.Show("Number of " + lv_All.SelectedItems.Count + " data are going to be deleted.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    foreach (ListViewItem lvitem in lv_All.SelectedItems)
                    {
                        if (lvitem.Group.Name == "Registered Brick")
                        {
                            string str_qu = "select part_id, part_name, part_short_desc, part_type from part where part_name = '" + lvitem.SubItems[0].Text + "'";
                            OleDbDataReader oddr = connector.select_Data(str_qu);

                            if (oddr.Read())
                            {
                                string str_id = oddr.GetInt32(0).ToString();
                                string str_name = oddr.GetString(1);
                                string str_desc = oddr.GetString(2);
                                string str_type = oddr.GetString(3);

                                str_qu = "delete from part where part_name = '" + lvitem.SubItems[0].Text + "'";
                                connector.insert_Data(str_qu);

                                str_qu = "insert into part (part_id, part_name, part_short_desc, part_type) values(@ID, @NAME, @DESC, @TYPE)";

                                OleDbCommand conm = new OleDbCommand(str_qu);
                                conm.Parameters.AddWithValue("@ID", str_id);
                                conm.Parameters.AddWithValue("@NAME", str_name);
                                conm.Parameters.AddWithValue("@DESC", str_desc);
                                conm.Parameters.AddWithValue("@TYPE", str_type);

                                connector.insert_Data(conm);
                                conm.Dispose();
                            }

                        }
                        else if (lvitem.Group.Name == "User's Brick")
                        {

                            string str_qu = "delete from userbricks where part_name = '" + lvitem.SubItems[0].Text + "'";
                            connector.insert_Data(str_qu);
                        }
                    }

                    list_from_DB();

                }

                
            }
        }

        private void bt_modify_Click(object sender, EventArgs e)
        {
            if (lv_All.SelectedItems.Count > 0)
            {
                if (lv_All.SelectedItems[0].Group.Name == "User's Brick")
                {
                    string str_qu = "select * from userbricks where part_name = '" + lv_All.SelectedItems[0].SubItems[0].Text + "'";
                    OleDbDataReader oddr = connector.select_Data(str_qu);

                    Form_Update fu1 = new Form_Update(oddr);
                    fu1.ShowDialog();

                    list_from_DB();
                }

            }
        }
    }
}
