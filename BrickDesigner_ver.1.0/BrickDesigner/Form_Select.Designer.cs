namespace BrickDesigner
{
    partial class Form_Select
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
            this.lv_Type = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.bt_Search = new System.Windows.Forms.Button();
            this.bt_Ok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_SubParts = new System.Windows.Forms.ListBox();
            this.tb_BQ = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_Entered = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_Result = new System.Windows.Forms.TextBox();
            this.tb_Status = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_Type
            // 
            this.lv_Type.BackColor = System.Drawing.SystemColors.Window;
            this.lv_Type.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_Type.GridLines = true;
            this.lv_Type.Location = new System.Drawing.Point(12, 12);
            this.lv_Type.Name = "lv_Type";
            this.lv_Type.Size = new System.Drawing.Size(485, 457);
            this.lv_Type.TabIndex = 1;
            this.lv_Type.UseCompatibleStateImageBehavior = false;
            this.lv_Type.View = System.Windows.Forms.View.Details;
            this.lv_Type.SelectedIndexChanged += new System.EventHandler(this.lv_Type_SelectedIndexChanged);
            this.lv_Type.DoubleClick += new System.EventHandler(this.lv_Type_DoubleClick);
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
            // tb_Search
            // 
            this.tb_Search.Location = new System.Drawing.Point(6, 20);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(187, 21);
            this.tb_Search.TabIndex = 3;
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(6, 47);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(187, 23);
            this.bt_Search.TabIndex = 4;
            this.bt_Search.Text = "Search";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // bt_Ok
            // 
            this.bt_Ok.Location = new System.Drawing.Point(6, 428);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(187, 23);
            this.bt_Ok.TabIndex = 4;
            this.bt_Ok.Text = "OK";
            this.bt_Ok.UseVisualStyleBackColor = true;
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tb_Search);
            this.groupBox1.Controls.Add(this.bt_Ok);
            this.groupBox1.Controls.Add(this.bt_Search);
            this.groupBox1.Location = new System.Drawing.Point(503, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 457);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lb_SubParts
            // 
            this.lb_SubParts.FormattingEnabled = true;
            this.lb_SubParts.ItemHeight = 12;
            this.lb_SubParts.Location = new System.Drawing.Point(6, 188);
            this.lb_SubParts.Name = "lb_SubParts";
            this.lb_SubParts.Size = new System.Drawing.Size(175, 148);
            this.lb_SubParts.TabIndex = 16;
            // 
            // tb_BQ
            // 
            this.tb_BQ.Location = new System.Drawing.Point(6, 149);
            this.tb_BQ.Name = "tb_BQ";
            this.tb_BQ.ReadOnly = true;
            this.tb_BQ.Size = new System.Drawing.Size(175, 21);
            this.tb_BQ.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "· Subparts";
            // 
            // tb_Entered
            // 
            this.tb_Entered.Location = new System.Drawing.Point(6, 110);
            this.tb_Entered.Name = "tb_Entered";
            this.tb_Entered.ReadOnly = true;
            this.tb_Entered.Size = new System.Drawing.Size(175, 21);
            this.tb_Entered.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "· Best Quality";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "· Entered";
            // 
            // tb_Result
            // 
            this.tb_Result.Location = new System.Drawing.Point(6, 71);
            this.tb_Result.Name = "tb_Result";
            this.tb_Result.ReadOnly = true;
            this.tb_Result.Size = new System.Drawing.Size(175, 21);
            this.tb_Result.TabIndex = 14;
            // 
            // tb_Status
            // 
            this.tb_Status.Location = new System.Drawing.Point(6, 32);
            this.tb_Status.Name = "tb_Status";
            this.tb_Status.ReadOnly = true;
            this.tb_Status.Size = new System.Drawing.Size(175, 21);
            this.tb_Status.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "· Result";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "· Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lb_SubParts);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tb_BQ);
            this.groupBox2.Controls.Add(this.tb_Status);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tb_Result);
            this.groupBox2.Controls.Add(this.tb_Entered);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(6, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 346);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // Form_Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 481);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lv_Type);
            this.Name = "Form_Select";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Select";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_Type;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.Button bt_Ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lb_SubParts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_BQ;
        private System.Windows.Forms.TextBox tb_Status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_Result;
        private System.Windows.Forms.TextBox tb_Entered;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

    }
}