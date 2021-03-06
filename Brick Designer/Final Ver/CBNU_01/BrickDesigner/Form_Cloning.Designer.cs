﻿namespace BrickDesigner
{
    partial class Form_Cloning
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
            this.pn_view = new System.Windows.Forms.Panel();
            this.lv_All = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_BrickName = new System.Windows.Forms.TextBox();
            this.lb_Sf = new System.Windows.Forms.ListBox();
            this.lb_Pf = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Ok = new System.Windows.Forms.Button();
            this.bt_Select = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_view
            // 
            this.pn_view.BackColor = System.Drawing.SystemColors.Window;
            this.pn_view.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_view.Location = new System.Drawing.Point(12, 12);
            this.pn_view.Name = "pn_view";
            this.pn_view.Size = new System.Drawing.Size(753, 213);
            this.pn_view.TabIndex = 0;
            this.pn_view.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_view_Paint);
            // 
            // lv_All
            // 
            this.lv_All.BackColor = System.Drawing.SystemColors.Window;
            this.lv_All.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_All.GridLines = true;
            this.lv_All.Location = new System.Drawing.Point(6, 20);
            this.lv_All.Name = "lv_All";
            this.lv_All.Size = new System.Drawing.Size(419, 255);
            this.lv_All.TabIndex = 2;
            this.lv_All.UseCompatibleStateImageBehavior = false;
            this.lv_All.View = System.Windows.Forms.View.Details;
            this.lv_All.DoubleClick += new System.EventHandler(this.lv_All_DoubleClick);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_BrickName);
            this.groupBox1.Controls.Add(this.lb_Sf);
            this.groupBox1.Controls.Add(this.lb_Pf);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bt_Ok);
            this.groupBox1.Location = new System.Drawing.Point(449, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 310);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // tb_BrickName
            // 
            this.tb_BrickName.Location = new System.Drawing.Point(8, 41);
            this.tb_BrickName.Name = "tb_BrickName";
            this.tb_BrickName.ReadOnly = true;
            this.tb_BrickName.Size = new System.Drawing.Size(302, 21);
            this.tb_BrickName.TabIndex = 7;
            // 
            // lb_Sf
            // 
            this.lb_Sf.FormattingEnabled = true;
            this.lb_Sf.ItemHeight = 12;
            this.lb_Sf.Location = new System.Drawing.Point(162, 105);
            this.lb_Sf.Name = "lb_Sf";
            this.lb_Sf.Size = new System.Drawing.Size(148, 136);
            this.lb_Sf.TabIndex = 6;
            this.lb_Sf.SelectedIndexChanged += new System.EventHandler(this.listbox_SelectedIndexChanged);
            // 
            // lb_Pf
            // 
            this.lb_Pf.FormattingEnabled = true;
            this.lb_Pf.ItemHeight = 12;
            this.lb_Pf.Location = new System.Drawing.Point(8, 105);
            this.lb_Pf.Name = "lb_Pf";
            this.lb_Pf.Size = new System.Drawing.Size(148, 136);
            this.lb_Pf.TabIndex = 6;
            this.lb_Pf.SelectedIndexChanged += new System.EventHandler(this.listbox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "· Selected Brick";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "· Restriction Site";
            // 
            // bt_Ok
            // 
            this.bt_Ok.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Ok.Location = new System.Drawing.Point(174, 281);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(136, 23);
            this.bt_Ok.TabIndex = 4;
            this.bt_Ok.Text = "OK";
            this.bt_Ok.UseVisualStyleBackColor = false;
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // bt_Select
            // 
            this.bt_Select.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Select.Location = new System.Drawing.Point(289, 281);
            this.bt_Select.Name = "bt_Select";
            this.bt_Select.Size = new System.Drawing.Size(136, 23);
            this.bt_Select.TabIndex = 4;
            this.bt_Select.Text = "Select";
            this.bt_Select.UseVisualStyleBackColor = false;
            this.bt_Select.Click += new System.EventHandler(this.bt_Select_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_All);
            this.groupBox2.Controls.Add(this.bt_Select);
            this.groupBox2.Location = new System.Drawing.Point(12, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 310);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // Form_Cloning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pn_view);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Cloning";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cloning";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_view;
        private System.Windows.Forms.ListView lv_All;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Ok;
        private System.Windows.Forms.Button bt_Select;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_Pf;
        private System.Windows.Forms.ListBox lb_Sf;
        private System.Windows.Forms.TextBox tb_BrickName;
        private System.Windows.Forms.Label label2;
    }
}