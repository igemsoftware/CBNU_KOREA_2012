namespace Synb_Project_TeamB
{
    partial class inEGList
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
            this.DGVlist = new System.Windows.Forms.DataGridView();
            this.TBsection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTdelete = new System.Windows.Forms.Button();
            this.CLcheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CLsynb_uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLfreq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLGOTerm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLproduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLCOG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSTRAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STRAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVlist)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVlist
            // 
            this.DGVlist.AllowUserToAddRows = false;
            this.DGVlist.AllowUserToDeleteRows = false;
            this.DGVlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLcheck,
            this.CLsynb_uid,
            this.CLfreq,
            this.CLGOTerm,
            this.CLproduct,
            this.CLCOG,
            this.CSTRAND,
            this.STRAND});
            this.DGVlist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVlist.Location = new System.Drawing.Point(11, 14);
            this.DGVlist.Name = "DGVlist";
            this.DGVlist.RowHeadersVisible = false;
            this.DGVlist.RowTemplate.Height = 23;
            this.DGVlist.Size = new System.Drawing.Size(588, 321);
            this.DGVlist.TabIndex = 0;
            this.DGVlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVlist_CellContentClick);
            this.DGVlist.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVlist_CellPainting);
            // 
            // TBsection
            // 
            this.TBsection.BackColor = System.Drawing.SystemColors.Window;
            this.TBsection.Enabled = false;
            this.TBsection.Location = new System.Drawing.Point(63, 344);
            this.TBsection.Name = "TBsection";
            this.TBsection.Size = new System.Drawing.Size(26, 22);
            this.TBsection.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Section";
            // 
            // BTdelete
            // 
            this.BTdelete.BackgroundImage = global::Synb_Project_TeamB.Properties.Resources.delete;
            this.BTdelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTdelete.FlatAppearance.BorderSize = 0;
            this.BTdelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTdelete.Location = new System.Drawing.Point(564, 341);
            this.BTdelete.Name = "BTdelete";
            this.BTdelete.Size = new System.Drawing.Size(35, 25);
            this.BTdelete.TabIndex = 1;
            this.BTdelete.Text = "-";
            this.BTdelete.UseVisualStyleBackColor = true;
            this.BTdelete.Click += new System.EventHandler(this.BTdelete_Click);
            // 
            // CLcheck
            // 
            this.CLcheck.HeaderText = "";
            this.CLcheck.Name = "CLcheck";
            this.CLcheck.Width = 25;
            // 
            // CLsynb_uid
            // 
            this.CLsynb_uid.HeaderText = "Synb UID";
            this.CLsynb_uid.Name = "CLsynb_uid";
            this.CLsynb_uid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLsynb_uid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CLsynb_uid.Width = 90;
            // 
            // CLfreq
            // 
            this.CLfreq.HeaderText = "Freq(%)";
            this.CLfreq.Name = "CLfreq";
            this.CLfreq.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLfreq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CLfreq.Width = 55;
            // 
            // CLGOTerm
            // 
            this.CLGOTerm.HeaderText = "GO Term";
            this.CLGOTerm.Name = "CLGOTerm";
            this.CLGOTerm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLGOTerm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CLGOTerm.Width = 150;
            // 
            // CLproduct
            // 
            this.CLproduct.HeaderText = "Product";
            this.CLproduct.Name = "CLproduct";
            this.CLproduct.Width = 150;
            // 
            // CLCOG
            // 
            this.CLCOG.HeaderText = "COG";
            this.CLCOG.Name = "CLCOG";
            this.CLCOG.Width = 55;
            // 
            // CSTRAND
            // 
            this.CSTRAND.HeaderText = "STRAND";
            this.CSTRAND.Name = "CSTRAND";
            this.CSTRAND.Width = 60;
            // 
            // STRAND
            // 
            this.STRAND.HeaderText = "STRAND";
            this.STRAND.Name = "STRAND";
            this.STRAND.Visible = false;
            // 
            // inEGList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 372);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBsection);
            this.Controls.Add(this.BTdelete);
            this.Controls.Add(this.DGVlist);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "inEGList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserted EG";
            ((System.ComponentModel.ISupportInitialize)(this.DGVlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVlist;
        private System.Windows.Forms.Button BTdelete;
        private System.Windows.Forms.TextBox TBsection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CLcheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLsynb_uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLfreq;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLGOTerm;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLproduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLCOG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSTRAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn STRAND;
    }
}