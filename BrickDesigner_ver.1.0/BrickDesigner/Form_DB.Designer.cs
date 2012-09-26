namespace BrickDesigner
{
    partial class Form_DB
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
            this.lv_All = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_modify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv_All
            // 
            this.lv_All.BackColor = System.Drawing.SystemColors.Window;
            this.lv_All.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_All.GridLines = true;
            this.lv_All.Location = new System.Drawing.Point(12, 12);
            this.lv_All.Name = "lv_All";
            this.lv_All.Size = new System.Drawing.Size(485, 412);
            this.lv_All.TabIndex = 1;
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
            // bt_delete
            // 
            this.bt_delete.BackColor = System.Drawing.SystemColors.Control;
            this.bt_delete.Location = new System.Drawing.Point(503, 372);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(167, 23);
            this.bt_delete.TabIndex = 2;
            this.bt_delete.Text = "Delete";
            this.bt_delete.UseVisualStyleBackColor = false;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_modify
            // 
            this.bt_modify.BackColor = System.Drawing.SystemColors.Control;
            this.bt_modify.Location = new System.Drawing.Point(503, 401);
            this.bt_modify.Name = "bt_modify";
            this.bt_modify.Size = new System.Drawing.Size(167, 23);
            this.bt_modify.TabIndex = 2;
            this.bt_modify.Text = "Modify";
            this.bt_modify.UseVisualStyleBackColor = false;
            this.bt_modify.Click += new System.EventHandler(this.bt_modify_Click);
            // 
            // Form_DB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 436);
            this.Controls.Add(this.bt_modify);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.lv_All);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Management";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_All;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_modify;
    }
}