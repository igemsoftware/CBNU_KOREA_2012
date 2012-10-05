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
    public partial class Form_Save : Form
    {
        DBconnector connector;
        Form_Main fmain;

        // 부른 함수가 무엇인지
        // 1 = New
        // 2 = Save
        int i_from;

        public Form_Save()
        {
            InitializeComponent();
        }

        public Form_Save(Form_Main _fmain, int i)
        {
            InitializeComponent();
            fmain = _fmain;
            connector = new DBconnector();

            combo_from_db();
            i_from = i;
        }

        private void combo_from_db()
        {

            comboBox1.Items.Clear();

            string str_select_qu = "select distinct(part_type) from part";

            OleDbDataReader oddr = connector.select_Data(str_select_qu);

            while (oddr.Read())
            {
                comboBox1.Items.Add(oddr.GetString(0));
            }

            oddr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (i_from == 2)
            {
                if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && comboBox1.SelectedItem != null)
                {
                    fmain.newBD.str_brick_name = textBox1.Text;
                    fmain.newBD.str_brick_type = comboBox1.SelectedItem.ToString();
                    fmain.newBD.str_brick_desc = textBox2.Text;

                    this.Close();

                    fmain.data_save();
                    fmain.change_FromName();
                }
                else
                {
                    MessageBox.Show("Fill out all of this form.");
                }
            }
            else
            {
                if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && comboBox1.SelectedItem != null)
                {
                    fmain.newBD.str_brick_name = textBox1.Text;
                    fmain.newBD.str_brick_type = comboBox1.SelectedItem.ToString();
                    fmain.newBD.str_brick_desc = textBox2.Text;

                    this.Close();

                    fmain.change_FromName();
                }
                else
                {
                    MessageBox.Show("Fill out all of this form.");
                }
            }

            
        }
    }
}
