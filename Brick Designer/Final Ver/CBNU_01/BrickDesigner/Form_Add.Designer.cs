﻿namespace BrickDesigner
{
    partial class Form_Add
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Ok = new System.Windows.Forms.Button();
            this.tb_Seq = new System.Windows.Forms.TextBox();
            this.tb_Desc = new System.Windows.Forms.TextBox();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.lab_Sec = new System.Windows.Forms.Label();
            this.lab_Desc = new System.Windows.Forms.Label();
            this.lab_Name = new System.Windows.Forms.Label();
            this.lab_Type = new System.Windows.Forms.Label();
            this.lv_All = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Ok);
            this.groupBox1.Controls.Add(this.tb_Seq);
            this.groupBox1.Controls.Add(this.tb_Desc);
            this.groupBox1.Controls.Add(this.tb_Name);
            this.groupBox1.Controls.Add(this.cb_Type);
            this.groupBox1.Controls.Add(this.lab_Sec);
            this.groupBox1.Controls.Add(this.lab_Desc);
            this.groupBox1.Controls.Add(this.lab_Name);
            this.groupBox1.Controls.Add(this.lab_Type);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 436);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bt_Ok
            // 
            this.bt_Ok.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Ok.Location = new System.Drawing.Point(9, 391);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(359, 39);
            this.bt_Ok.TabIndex = 5;
            this.bt_Ok.Text = "OK";
            this.bt_Ok.UseVisualStyleBackColor = false;
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // tb_Seq
            // 
            this.tb_Seq.Location = new System.Drawing.Point(95, 188);
            this.tb_Seq.Multiline = true;
            this.tb_Seq.Name = "tb_Seq";
            this.tb_Seq.Size = new System.Drawing.Size(273, 197);
            this.tb_Seq.TabIndex = 4;
            // 
            // tb_Desc
            // 
            this.tb_Desc.Location = new System.Drawing.Point(95, 90);
            this.tb_Desc.Multiline = true;
            this.tb_Desc.Name = "tb_Desc";
            this.tb_Desc.Size = new System.Drawing.Size(273, 78);
            this.tb_Desc.TabIndex = 3;
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(95, 48);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(273, 22);
            this.tb_Name.TabIndex = 2;
            this.tb_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // cb_Type
            // 
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Location = new System.Drawing.Point(95, 20);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(273, 22);
            this.cb_Type.TabIndex = 1;
            // 
            // lab_Sec
            // 
            this.lab_Sec.AutoSize = true;
            this.lab_Sec.Location = new System.Drawing.Point(6, 171);
            this.lab_Sec.Name = "lab_Sec";
            this.lab_Sec.Size = new System.Drawing.Size(70, 14);
            this.lab_Sec.TabIndex = 0;
            this.lab_Sec.Text = "· Sequence";
            // 
            // lab_Desc
            // 
            this.lab_Desc.AutoSize = true;
            this.lab_Desc.Location = new System.Drawing.Point(6, 73);
            this.lab_Desc.Name = "lab_Desc";
            this.lab_Desc.Size = new System.Drawing.Size(75, 14);
            this.lab_Desc.TabIndex = 0;
            this.lab_Desc.Text = "· Description";
            // 
            // lab_Name
            // 
            this.lab_Name.AutoSize = true;
            this.lab_Name.Location = new System.Drawing.Point(6, 51);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(46, 14);
            this.lab_Name.TabIndex = 0;
            this.lab_Name.Text = "· Name";
            // 
            // lab_Type
            // 
            this.lab_Type.AutoSize = true;
            this.lab_Type.Location = new System.Drawing.Point(6, 23);
            this.lab_Type.Name = "lab_Type";
            this.lab_Type.Size = new System.Drawing.Size(43, 14);
            this.lab_Type.TabIndex = 0;
            this.lab_Type.Text = "· Type";
            // 
            // lv_All
            // 
            this.lv_All.BackColor = System.Drawing.SystemColors.Window;
            this.lv_All.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_All.GridLines = true;
            this.lv_All.Location = new System.Drawing.Point(392, 14);
            this.lv_All.Name = "lv_All";
            this.lv_All.Size = new System.Drawing.Size(491, 436);
            this.lv_All.TabIndex = 6;
            this.lv_All.UseCompatibleStateImageBehavior = false;
            this.lv_All.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 105;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Short_Desc";
            this.columnHeader2.Width = 278;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 80;
            // 
            // Form_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 462);
            this.Controls.Add(this.lv_All);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "Form_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Brick";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.Label lab_Name;
        private System.Windows.Forms.Label lab_Type;
        private System.Windows.Forms.TextBox tb_Desc;
        private System.Windows.Forms.Label lab_Desc;
        private System.Windows.Forms.TextBox tb_Seq;
        private System.Windows.Forms.Label lab_Sec;
        private System.Windows.Forms.Button bt_Ok;
        private System.Windows.Forms.ListView lv_All;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}