﻿namespace Synb_Project_TeamB
{
    partial class TransControl
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
            this.SuspendLayout();
            // 
            // TransControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Size = new System.Drawing.Size(60, 60);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TransControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TransControl_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

    }
}