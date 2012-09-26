using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrickDesigner
{
    public partial class Form_Update : Form
    {
        DBconnector connector;

        public Form_Update()
        {
            InitializeComponent();
        }

        public Form_Update(OleDbDataReader oddr)
        {

            InitializeComponent();

            connector = new DBconnector();

            while (oddr.Read())
            {
                tb_Name.Text = oddr.GetString(0);
                tb_Desc.Text = oddr.GetString(2);
                tb_Seq.Text = oddr.GetString(3);
            }
        }

        private void bt_Ok_Click(object sender, EventArgs e)
        {


            if (tb_Desc.Text.Length == 0 || tb_Seq.Text.Length == 0)
            {
                MessageBox.Show("오류", "Modify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("수정하시겠습니까?", "Modify", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string str_qu = "update userbricks set part_desc = @DESC, part_seq = @SEQ where part_name = '" + tb_Name.Text + "'";


                    OleDbCommand conm = new OleDbCommand(str_qu);
                    conm.Parameters.AddWithValue("@DESC", tb_Desc.Text);
                    conm.Parameters.AddWithValue("@SEQ", tb_Seq.Text.Replace("\r\n", "").Replace(" ", ""));

                    connector.update_Data(conm);

                    MessageBox.Show("수정됨");

                    this.Close();
                }
            }
        }
    }
}
