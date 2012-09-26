namespace Synb_Project_TeamB
{
    partial class Home_View
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
            this.PBindivDownload = new System.Windows.Forms.ProgressBar();
            this.PBtotalDownload = new System.Windows.Forms.ProgressBar();
            this.LBindivFileName = new System.Windows.Forms.Label();
            this.LBindivProg = new System.Windows.Forms.Label();
            this.LBtotalProg = new System.Windows.Forms.Label();
            this.BTupdate = new System.Windows.Forms.Button();
            this.LBtotalFileName = new System.Windows.Forms.Label();
            this.GBupdate = new System.Windows.Forms.GroupBox();
            this.GBnotice = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBnotice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BTdesigner = new System.Windows.Forms.Button();
            this.BTmainImage3 = new System.Windows.Forms.Button();
            this.BTviewer = new System.Windows.Forms.Button();
            this.BTmainImage2 = new System.Windows.Forms.Button();
            this.BTmainImage1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.IVwindow = new System.Windows.Forms.PictureBox();
            this.GBupdate.SuspendLayout();
            this.GBnotice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IVwindow)).BeginInit();
            this.SuspendLayout();
            // 
            // PBindivDownload
            // 
            this.PBindivDownload.Location = new System.Drawing.Point(6, 89);
            this.PBindivDownload.Name = "PBindivDownload";
            this.PBindivDownload.Size = new System.Drawing.Size(642, 23);
            this.PBindivDownload.TabIndex = 2;
            // 
            // PBtotalDownload
            // 
            this.PBtotalDownload.Location = new System.Drawing.Point(6, 39);
            this.PBtotalDownload.Name = "PBtotalDownload";
            this.PBtotalDownload.Size = new System.Drawing.Size(642, 23);
            this.PBtotalDownload.TabIndex = 3;
            // 
            // LBindivFileName
            // 
            this.LBindivFileName.AutoSize = true;
            this.LBindivFileName.Location = new System.Drawing.Point(4, 74);
            this.LBindivFileName.Name = "LBindivFileName";
            this.LBindivFileName.Size = new System.Drawing.Size(140, 12);
            this.LBindivFileName.TabIndex = 4;
            this.LBindivFileName.Text = "Downloading File Name";
            // 
            // LBindivProg
            // 
            this.LBindivProg.AutoSize = true;
            this.LBindivProg.Location = new System.Drawing.Point(575, 74);
            this.LBindivProg.Name = "LBindivProg";
            this.LBindivProg.Size = new System.Drawing.Size(73, 12);
            this.LBindivProg.TabIndex = 5;
            this.LBindivProg.Text = "15/100(15%)";
            // 
            // LBtotalProg
            // 
            this.LBtotalProg.AutoSize = true;
            this.LBtotalProg.Location = new System.Drawing.Point(575, 23);
            this.LBtotalProg.Name = "LBtotalProg";
            this.LBtotalProg.Size = new System.Drawing.Size(73, 12);
            this.LBtotalProg.TabIndex = 6;
            this.LBtotalProg.Text = "15/100(15%)";
            // 
            // BTupdate
            // 
            this.BTupdate.Location = new System.Drawing.Point(472, 7);
            this.BTupdate.Name = "BTupdate";
            this.BTupdate.Size = new System.Drawing.Size(176, 113);
            this.BTupdate.TabIndex = 7;
            this.BTupdate.Text = "Update Database";
            this.BTupdate.UseVisualStyleBackColor = true;
            // 
            // LBtotalFileName
            // 
            this.LBtotalFileName.AutoSize = true;
            this.LBtotalFileName.Location = new System.Drawing.Point(4, 23);
            this.LBtotalFileName.Name = "LBtotalFileName";
            this.LBtotalFileName.Size = new System.Drawing.Size(140, 12);
            this.LBtotalFileName.TabIndex = 8;
            this.LBtotalFileName.Text = "Downloading File Name";
            // 
            // GBupdate
            // 
            this.GBupdate.Controls.Add(this.PBtotalDownload);
            this.GBupdate.Controls.Add(this.BTupdate);
            this.GBupdate.Controls.Add(this.LBtotalFileName);
            this.GBupdate.Controls.Add(this.PBindivDownload);
            this.GBupdate.Controls.Add(this.LBindivFileName);
            this.GBupdate.Controls.Add(this.LBtotalProg);
            this.GBupdate.Controls.Add(this.LBindivProg);
            this.GBupdate.Location = new System.Drawing.Point(12, 298);
            this.GBupdate.Name = "GBupdate";
            this.GBupdate.Size = new System.Drawing.Size(654, 120);
            this.GBupdate.TabIndex = 9;
            this.GBupdate.TabStop = false;
            // 
            // GBnotice
            // 
            this.GBnotice.Controls.Add(this.label3);
            this.GBnotice.Controls.Add(this.pictureBox1);
            this.GBnotice.Controls.Add(this.TBnotice);
            this.GBnotice.Location = new System.Drawing.Point(666, 4);
            this.GBnotice.Name = "GBnotice";
            this.GBnotice.Size = new System.Drawing.Size(254, 229);
            this.GBnotice.TabIndex = 11;
            this.GBnotice.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(28, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 11);
            this.label3.TabIndex = 2;
            this.label3.Text = "NOTICE";
            // 
            // TBnotice
            // 
            this.TBnotice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBnotice.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TBnotice.Location = new System.Drawing.Point(6, 24);
            this.TBnotice.Multiline = true;
            this.TBnotice.Name = "TBnotice";
            this.TBnotice.ReadOnly = true;
            this.TBnotice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBnotice.Size = new System.Drawing.Size(242, 199);
            this.TBnotice.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IVwindow);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 261);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(617, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "1.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(566, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Verson";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::Synb_Project_TeamB.Properties.Resources.bullet_black;
            this.button3.Location = new System.Drawing.Point(124, 268);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(15, 15);
            this.button3.TabIndex = 18;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::Synb_Project_TeamB.Properties.Resources.bullet_black;
            this.button2.Location = new System.Drawing.Point(103, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(15, 15);
            this.button2.TabIndex = 17;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Synb_Project_TeamB.Properties.Resources.bullet_black;
            this.button1.Location = new System.Drawing.Point(82, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 15);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(521, 265);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 18);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // BTdesigner
            // 
            this.BTdesigner.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTdesigner.Image = global::Synb_Project_TeamB.Properties.Resources.bricks;
            this.BTdesigner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTdesigner.Location = new System.Drawing.Point(796, 239);
            this.BTdesigner.Name = "BTdesigner";
            this.BTdesigner.Size = new System.Drawing.Size(124, 42);
            this.BTdesigner.TabIndex = 1;
            this.BTdesigner.Text = "        Designer";
            this.BTdesigner.UseVisualStyleBackColor = true;
            this.BTdesigner.Click += new System.EventHandler(this.Designer_Click);
            // 
            // BTmainImage3
            // 
            this.BTmainImage3.BackColor = System.Drawing.Color.White;
            this.BTmainImage3.FlatAppearance.BorderSize = 0;
            this.BTmainImage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTmainImage3.Image = global::Synb_Project_TeamB.Properties.Resources.bullet_black;
            this.BTmainImage3.Location = new System.Drawing.Point(61, 268);
            this.BTmainImage3.Name = "BTmainImage3";
            this.BTmainImage3.Size = new System.Drawing.Size(15, 15);
            this.BTmainImage3.TabIndex = 4;
            this.BTmainImage3.UseVisualStyleBackColor = false;
            this.BTmainImage3.Click += new System.EventHandler(this.BTmainImage3_Click);
            // 
            // BTviewer
            // 
            this.BTviewer.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTviewer.Image = global::Synb_Project_TeamB.Properties.Resources.color_wheel;
            this.BTviewer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTviewer.Location = new System.Drawing.Point(666, 239);
            this.BTviewer.Name = "BTviewer";
            this.BTviewer.Size = new System.Drawing.Size(124, 42);
            this.BTviewer.TabIndex = 0;
            this.BTviewer.Text = "Viewer     ";
            this.BTviewer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTviewer.UseVisualStyleBackColor = true;
            this.BTviewer.Click += new System.EventHandler(this.Viewer_Click);
            // 
            // BTmainImage2
            // 
            this.BTmainImage2.BackColor = System.Drawing.Color.White;
            this.BTmainImage2.FlatAppearance.BorderSize = 0;
            this.BTmainImage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTmainImage2.Image = global::Synb_Project_TeamB.Properties.Resources.bullet_black;
            this.BTmainImage2.Location = new System.Drawing.Point(39, 268);
            this.BTmainImage2.Name = "BTmainImage2";
            this.BTmainImage2.Size = new System.Drawing.Size(15, 15);
            this.BTmainImage2.TabIndex = 2;
            this.BTmainImage2.UseVisualStyleBackColor = false;
            this.BTmainImage2.Click += new System.EventHandler(this.BTmainImage2_Click);
            // 
            // BTmainImage1
            // 
            this.BTmainImage1.BackColor = System.Drawing.Color.Transparent;
            this.BTmainImage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTmainImage1.FlatAppearance.BorderSize = 0;
            this.BTmainImage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTmainImage1.ForeColor = System.Drawing.Color.Transparent;
            this.BTmainImage1.Image = global::Synb_Project_TeamB.Properties.Resources.bullet_blue;
            this.BTmainImage1.Location = new System.Drawing.Point(18, 268);
            this.BTmainImage1.Name = "BTmainImage1";
            this.BTmainImage1.Size = new System.Drawing.Size(15, 15);
            this.BTmainImage1.TabIndex = 3;
            this.BTmainImage1.UseVisualStyleBackColor = false;
            this.BTmainImage1.Click += new System.EventHandler(this.BTmainImage1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Synb_Project_TeamB.Properties.Resources.application_view_columns;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(6, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 18);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // IVwindow
            // 
            this.IVwindow.BackgroundImage = global::Synb_Project_TeamB.Properties.Resources._1;
            this.IVwindow.Location = new System.Drawing.Point(6, 13);
            this.IVwindow.Name = "IVwindow";
            this.IVwindow.Size = new System.Drawing.Size(636, 242);
            this.IVwindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IVwindow.TabIndex = 0;
            this.IVwindow.TabStop = false;
            // 
            // Home_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 288);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTdesigner);
            this.Controls.Add(this.BTmainImage3);
            this.Controls.Add(this.BTviewer);
            this.Controls.Add(this.BTmainImage2);
            this.Controls.Add(this.BTmainImage1);
            this.Controls.Add(this.GBnotice);
            this.Controls.Add(this.GBupdate);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Home_View";
            this.Text = "SynB SW(Viewer + Designer)";
            this.GBupdate.ResumeLayout(false);
            this.GBupdate.PerformLayout();
            this.GBnotice.ResumeLayout(false);
            this.GBnotice.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IVwindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTviewer;
        private System.Windows.Forms.Button BTdesigner;
        private System.Windows.Forms.ProgressBar PBindivDownload;
        private System.Windows.Forms.ProgressBar PBtotalDownload;
        private System.Windows.Forms.Label LBindivFileName;
        private System.Windows.Forms.Label LBindivProg;
        private System.Windows.Forms.Label LBtotalProg;
        private System.Windows.Forms.Button BTupdate;
        private System.Windows.Forms.Label LBtotalFileName;
        private System.Windows.Forms.GroupBox GBupdate;
        private System.Windows.Forms.GroupBox GBnotice;
        private System.Windows.Forms.TextBox TBnotice;
        private System.Windows.Forms.PictureBox IVwindow;
        private System.Windows.Forms.Button BTmainImage2;
        private System.Windows.Forms.Button BTmainImage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTmainImage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}