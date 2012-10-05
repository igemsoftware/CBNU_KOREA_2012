namespace BrickDesigner
{
    partial class Form_Update
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
            this.lab_Sec = new System.Windows.Forms.Label();
            this.lab_Desc = new System.Windows.Forms.Label();
            this.lab_Name = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Ok);
            this.groupBox1.Controls.Add(this.tb_Seq);
            this.groupBox1.Controls.Add(this.tb_Desc);
            this.groupBox1.Controls.Add(this.tb_Name);
            this.groupBox1.Controls.Add(this.lab_Sec);
            this.groupBox1.Controls.Add(this.lab_Desc);
            this.groupBox1.Controls.Add(this.lab_Name);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 408);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // bt_Ok
            // 
            this.bt_Ok.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Ok.Location = new System.Drawing.Point(9, 356);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(359, 39);
            this.bt_Ok.TabIndex = 5;
            this.bt_Ok.Text = "OK";
            this.bt_Ok.UseVisualStyleBackColor = false;
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // tb_Seq
            // 
            this.tb_Seq.Location = new System.Drawing.Point(95, 153);
            this.tb_Seq.Multiline = true;
            this.tb_Seq.Name = "tb_Seq";
            this.tb_Seq.Size = new System.Drawing.Size(273, 197);
            this.tb_Seq.TabIndex = 4;
            // 
            // tb_Desc
            // 
            this.tb_Desc.Location = new System.Drawing.Point(95, 55);
            this.tb_Desc.Multiline = true;
            this.tb_Desc.Name = "tb_Desc";
            this.tb_Desc.Size = new System.Drawing.Size(273, 78);
            this.tb_Desc.TabIndex = 3;
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(95, 13);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.ReadOnly = true;
            this.tb_Name.Size = new System.Drawing.Size(273, 21);
            this.tb_Name.TabIndex = 2;
            // 
            // lab_Sec
            // 
            this.lab_Sec.AutoSize = true;
            this.lab_Sec.Location = new System.Drawing.Point(6, 136);
            this.lab_Sec.Name = "lab_Sec";
            this.lab_Sec.Size = new System.Drawing.Size(69, 12);
            this.lab_Sec.TabIndex = 0;
            this.lab_Sec.Text = "· Sequence";
            // 
            // lab_Desc
            // 
            this.lab_Desc.AutoSize = true;
            this.lab_Desc.Location = new System.Drawing.Point(6, 38);
            this.lab_Desc.Name = "lab_Desc";
            this.lab_Desc.Size = new System.Drawing.Size(75, 12);
            this.lab_Desc.TabIndex = 0;
            this.lab_Desc.Text = "· Description";
            // 
            // lab_Name
            // 
            this.lab_Name.AutoSize = true;
            this.lab_Name.Location = new System.Drawing.Point(6, 16);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(46, 12);
            this.lab_Name.TabIndex = 0;
            this.lab_Name.Text = "· Name";
            // 
            // Form_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 433);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Update";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Ok;
        private System.Windows.Forms.TextBox tb_Seq;
        private System.Windows.Forms.TextBox tb_Desc;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label lab_Sec;
        private System.Windows.Forms.Label lab_Desc;
        private System.Windows.Forms.Label lab_Name;

    }
}