﻿namespace BrickDesigner
{
    partial class Form_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.savetoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.extoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.genbankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sBOLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clonningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenShotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lb_Subparts = new System.Windows.Forms.ListBox();
            this.tb_Desc = new System.Windows.Forms.TextBox();
            this.tb_BQ = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_Entered = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_URL = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_Result = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_Status = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_Type = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Add_Brick = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bt_Scar = new System.Windows.Forms.Button();
            this.bt_Primer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_RBS = new System.Windows.Forms.Button();
            this.bt_Promoter = new System.Windows.Forms.Button();
            this.bt_ProteinD = new System.Windows.Forms.Button();
            this.bt_TU = new System.Windows.Forms.Button();
            this.bt_DNA = new System.Windows.Forms.Button();
            this.bt_Plasmid = new System.Windows.Forms.Button();
            this.bt_Terminator = new System.Windows.Forms.Button();
            this.bt_Coding = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Other = new System.Windows.Forms.Button();
            this.bt_Measurement = new System.Windows.Forms.Button();
            this.bt_Signalling = new System.Windows.Forms.Button();
            this.bt_Inverter = new System.Windows.Forms.Button();
            this.bt_Reporter = new System.Windows.Forms.Button();
            this.bt_Generator = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pn_Brick = new System.Windows.Forms.Panel();
            this.lb_Brick = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pn_Seq = new System.Windows.Forms.Panel();
            this.pn_Circle = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1094, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadtoolStripMenuItem1,
            this.savetoolStripMenuItem1,
            this.toolStripSeparator1,
            this.extoolStripMenuItem1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.menu_NEW;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadtoolStripMenuItem1
            // 
            this.loadtoolStripMenuItem1.Image = global::BrickDesigner.Properties.Resources.menu_LOAD;
            this.loadtoolStripMenuItem1.Name = "loadtoolStripMenuItem1";
            this.loadtoolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadtoolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.loadtoolStripMenuItem1.Text = "Load";
            this.loadtoolStripMenuItem1.Click += new System.EventHandler(this.loadtoolStripMenuItem1_Click);
            // 
            // savetoolStripMenuItem1
            // 
            this.savetoolStripMenuItem1.Image = global::BrickDesigner.Properties.Resources.menu_SAVE;
            this.savetoolStripMenuItem1.Name = "savetoolStripMenuItem1";
            this.savetoolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.savetoolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.savetoolStripMenuItem1.Text = "Save";
            this.savetoolStripMenuItem1.Click += new System.EventHandler(this.savetoolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // extoolStripMenuItem1
            // 
            this.extoolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genbankToolStripMenuItem,
            this.sBOLToolStripMenuItem,
            this.fastaToolStripMenuItem});
            this.extoolStripMenuItem1.Image = global::BrickDesigner.Properties.Resources.menu_EXPORT;
            this.extoolStripMenuItem1.Name = "extoolStripMenuItem1";
            this.extoolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.extoolStripMenuItem1.Text = "Export";
            // 
            // genbankToolStripMenuItem
            // 
            this.genbankToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.menu_EX_FILE;
            this.genbankToolStripMenuItem.Name = "genbankToolStripMenuItem";
            this.genbankToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.genbankToolStripMenuItem.Text = "Genbank";
            this.genbankToolStripMenuItem.Click += new System.EventHandler(this.genbankToolStripMenuItem_Click);
            // 
            // sBOLToolStripMenuItem
            // 
            this.sBOLToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.menu_EX_FILE;
            this.sBOLToolStripMenuItem.Name = "sBOLToolStripMenuItem";
            this.sBOLToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.sBOLToolStripMenuItem.Text = "SBOL";
            this.sBOLToolStripMenuItem.Click += new System.EventHandler(this.sBOLToolStripMenuItem_Click);
            // 
            // fastaToolStripMenuItem
            // 
            this.fastaToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.menu_EX_FILE;
            this.fastaToolStripMenuItem.Name = "fastaToolStripMenuItem";
            this.fastaToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.fastaToolStripMenuItem.Text = "Fasta";
            this.fastaToolStripMenuItem.Click += new System.EventHandler(this.fastaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.menu_EXIT;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.dBToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.databaseToolStripMenuItem.Text = "Data";
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.download;
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // dBToolStripMenuItem
            // 
            this.dBToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.database_gear;
            this.dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            this.dBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.dBToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.dBToolStripMenuItem.Text = "DB";
            this.dBToolStripMenuItem.Click += new System.EventHandler(this.dBToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clonningToolStripMenuItem,
            this.screenShotToolStripMenuItem,
            this.scarToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // clonningToolStripMenuItem
            // 
            this.clonningToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.clonning;
            this.clonningToolStripMenuItem.Name = "clonningToolStripMenuItem";
            this.clonningToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.clonningToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.clonningToolStripMenuItem.Text = "Cloning";
            this.clonningToolStripMenuItem.Click += new System.EventHandler(this.clonningToolStripMenuItem_Click);
            // 
            // screenShotToolStripMenuItem
            // 
            this.screenShotToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.menu_SS;
            this.screenShotToolStripMenuItem.Name = "screenShotToolStripMenuItem";
            this.screenShotToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.screenShotToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.screenShotToolStripMenuItem.Text = "ScreenShot";
            this.screenShotToolStripMenuItem.Click += new System.EventHandler(this.screenShotToolStripMenuItem_Click);
            // 
            // scarToolStripMenuItem
            // 
            this.scarToolStripMenuItem.Image = global::BrickDesigner.Properties.Resources.menu_Scar;
            this.scarToolStripMenuItem.Name = "scarToolStripMenuItem";
            this.scarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.scarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.scarToolStripMenuItem.Text = "Scar";
            this.scarToolStripMenuItem.Click += new System.EventHandler(this.scarToolStripMenuItem_Click);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.lb_Subparts);
            this.panel7.Controls.Add(this.tb_Desc);
            this.panel7.Controls.Add(this.tb_BQ);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.tb_Entered);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.tb_URL);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.tb_Result);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.tb_Status);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.tb_Type);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.tb_Name);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Location = new System.Drawing.Point(4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(170, 603);
            this.panel7.TabIndex = 0;
            // 
            // lb_Subparts
            // 
            this.lb_Subparts.FormattingEnabled = true;
            this.lb_Subparts.ItemHeight = 14;
            this.lb_Subparts.Location = new System.Drawing.Point(3, 375);
            this.lb_Subparts.Name = "lb_Subparts";
            this.lb_Subparts.Size = new System.Drawing.Size(164, 214);
            this.lb_Subparts.TabIndex = 2;
            // 
            // tb_Desc
            // 
            this.tb_Desc.Location = new System.Drawing.Point(3, 76);
            this.tb_Desc.Name = "tb_Desc";
            this.tb_Desc.ReadOnly = true;
            this.tb_Desc.Size = new System.Drawing.Size(164, 22);
            this.tb_Desc.TabIndex = 1;
            // 
            // tb_BQ
            // 
            this.tb_BQ.Location = new System.Drawing.Point(3, 332);
            this.tb_BQ.Name = "tb_BQ";
            this.tb_BQ.ReadOnly = true;
            this.tb_BQ.Size = new System.Drawing.Size(164, 22);
            this.tb_BQ.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 358);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "· Subparts";
            // 
            // tb_Entered
            // 
            this.tb_Entered.Location = new System.Drawing.Point(3, 290);
            this.tb_Entered.Name = "tb_Entered";
            this.tb_Entered.ReadOnly = true;
            this.tb_Entered.Size = new System.Drawing.Size(164, 22);
            this.tb_Entered.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "· Best Quality";
            // 
            // tb_URL
            // 
            this.tb_URL.Location = new System.Drawing.Point(3, 248);
            this.tb_URL.Name = "tb_URL";
            this.tb_URL.ReadOnly = true;
            this.tb_URL.Size = new System.Drawing.Size(164, 22);
            this.tb_URL.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "· Entered";
            // 
            // tb_Result
            // 
            this.tb_Result.Location = new System.Drawing.Point(3, 206);
            this.tb_Result.Name = "tb_Result";
            this.tb_Result.ReadOnly = true;
            this.tb_Result.Size = new System.Drawing.Size(164, 22);
            this.tb_Result.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "· URL";
            // 
            // tb_Status
            // 
            this.tb_Status.Location = new System.Drawing.Point(3, 164);
            this.tb_Status.Name = "tb_Status";
            this.tb_Status.ReadOnly = true;
            this.tb_Status.Size = new System.Drawing.Size(164, 22);
            this.tb_Status.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "· Result";
            // 
            // tb_Type
            // 
            this.tb_Type.Location = new System.Drawing.Point(3, 119);
            this.tb_Type.Name = "tb_Type";
            this.tb_Type.ReadOnly = true;
            this.tb_Type.Size = new System.Drawing.Size(164, 22);
            this.tb_Type.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "· Status";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(3, 34);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.ReadOnly = true;
            this.tb_Name.Size = new System.Drawing.Size(164, 22);
            this.tb_Name.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "· Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "· Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "· Name";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Add_Brick, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.64583F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.35417F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(127, 611);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btn_Add_Brick
            // 
            this.btn_Add_Brick.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Add_Brick.Location = new System.Drawing.Point(4, 572);
            this.btn_Add_Brick.Name = "btn_Add_Brick";
            this.btn_Add_Brick.Size = new System.Drawing.Size(119, 35);
            this.btn_Add_Brick.TabIndex = 2;
            this.btn_Add_Brick.Text = "Add Brick";
            this.btn_Add_Brick.UseVisualStyleBackColor = false;
            this.btn_Add_Brick.Click += new System.EventHandler(this.btn_Add_Brick_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bt_Scar);
            this.panel5.Controls.Add(this.bt_Primer);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.bt_RBS);
            this.panel5.Controls.Add(this.bt_Promoter);
            this.panel5.Controls.Add(this.bt_ProteinD);
            this.panel5.Controls.Add(this.bt_TU);
            this.panel5.Controls.Add(this.bt_DNA);
            this.panel5.Controls.Add(this.bt_Plasmid);
            this.panel5.Controls.Add(this.bt_Terminator);
            this.panel5.Controls.Add(this.bt_Coding);
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(119, 298);
            this.panel5.TabIndex = 3;
            // 
            // bt_Scar
            // 
            this.bt_Scar.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Scar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Scar.BackgroundImage")));
            this.bt_Scar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Scar.Location = new System.Drawing.Point(62, 241);
            this.bt_Scar.Name = "bt_Scar";
            this.bt_Scar.Size = new System.Drawing.Size(50, 50);
            this.bt_Scar.TabIndex = 2;
            this.bt_Scar.UseVisualStyleBackColor = false;
            this.bt_Scar.Click += new System.EventHandler(this.bt_Scar_Click);
            this.bt_Scar.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_Primer
            // 
            this.bt_Primer.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Primer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Primer.BackgroundImage")));
            this.bt_Primer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Primer.Location = new System.Drawing.Point(6, 241);
            this.bt_Primer.Name = "bt_Primer";
            this.bt_Primer.Size = new System.Drawing.Size(50, 50);
            this.bt_Primer.TabIndex = 2;
            this.bt_Primer.UseVisualStyleBackColor = false;
            this.bt_Primer.Click += new System.EventHandler(this.bt_Primer_Click);
            this.bt_Primer.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "· Part";
            // 
            // bt_RBS
            // 
            this.bt_RBS.BackColor = System.Drawing.SystemColors.Control;
            this.bt_RBS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_RBS.BackgroundImage")));
            this.bt_RBS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_RBS.Location = new System.Drawing.Point(62, 17);
            this.bt_RBS.Name = "bt_RBS";
            this.bt_RBS.Size = new System.Drawing.Size(50, 50);
            this.bt_RBS.TabIndex = 1;
            this.bt_RBS.UseVisualStyleBackColor = false;
            this.bt_RBS.Click += new System.EventHandler(this.bt_RBS_Click);
            this.bt_RBS.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_Promoter
            // 
            this.bt_Promoter.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Promoter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Promoter.BackgroundImage")));
            this.bt_Promoter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Promoter.Location = new System.Drawing.Point(6, 17);
            this.bt_Promoter.Name = "bt_Promoter";
            this.bt_Promoter.Size = new System.Drawing.Size(50, 50);
            this.bt_Promoter.TabIndex = 1;
            this.bt_Promoter.UseVisualStyleBackColor = false;
            this.bt_Promoter.Click += new System.EventHandler(this.bt_Promoter_Click);
            this.bt_Promoter.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_ProteinD
            // 
            this.bt_ProteinD.BackColor = System.Drawing.SystemColors.Control;
            this.bt_ProteinD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_ProteinD.BackgroundImage")));
            this.bt_ProteinD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ProteinD.Location = new System.Drawing.Point(6, 73);
            this.bt_ProteinD.Name = "bt_ProteinD";
            this.bt_ProteinD.Size = new System.Drawing.Size(50, 50);
            this.bt_ProteinD.TabIndex = 2;
            this.bt_ProteinD.UseVisualStyleBackColor = false;
            this.bt_ProteinD.Click += new System.EventHandler(this.bt_ProteinD_Click);
            this.bt_ProteinD.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_TU
            // 
            this.bt_TU.BackColor = System.Drawing.SystemColors.Control;
            this.bt_TU.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_TU.BackgroundImage")));
            this.bt_TU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_TU.Location = new System.Drawing.Point(6, 129);
            this.bt_TU.Name = "bt_TU";
            this.bt_TU.Size = new System.Drawing.Size(50, 50);
            this.bt_TU.TabIndex = 2;
            this.bt_TU.UseVisualStyleBackColor = false;
            this.bt_TU.Click += new System.EventHandler(this.bt_TU_Click);
            this.bt_TU.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_DNA
            // 
            this.bt_DNA.BackColor = System.Drawing.SystemColors.Control;
            this.bt_DNA.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_DNA.BackgroundImage")));
            this.bt_DNA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_DNA.Location = new System.Drawing.Point(6, 185);
            this.bt_DNA.Name = "bt_DNA";
            this.bt_DNA.Size = new System.Drawing.Size(50, 50);
            this.bt_DNA.TabIndex = 2;
            this.bt_DNA.UseVisualStyleBackColor = false;
            this.bt_DNA.Click += new System.EventHandler(this.bt_DNA_Click);
            this.bt_DNA.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_Plasmid
            // 
            this.bt_Plasmid.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Plasmid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Plasmid.BackgroundImage")));
            this.bt_Plasmid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Plasmid.Location = new System.Drawing.Point(62, 185);
            this.bt_Plasmid.Name = "bt_Plasmid";
            this.bt_Plasmid.Size = new System.Drawing.Size(50, 50);
            this.bt_Plasmid.TabIndex = 2;
            this.bt_Plasmid.UseVisualStyleBackColor = false;
            this.bt_Plasmid.Click += new System.EventHandler(this.bt_Plasmid_Click);
            this.bt_Plasmid.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_Terminator
            // 
            this.bt_Terminator.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Terminator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Terminator.BackgroundImage")));
            this.bt_Terminator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Terminator.Location = new System.Drawing.Point(62, 129);
            this.bt_Terminator.Name = "bt_Terminator";
            this.bt_Terminator.Size = new System.Drawing.Size(50, 50);
            this.bt_Terminator.TabIndex = 2;
            this.bt_Terminator.UseVisualStyleBackColor = false;
            this.bt_Terminator.Click += new System.EventHandler(this.bt_Terminator_Click);
            this.bt_Terminator.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_Coding
            // 
            this.bt_Coding.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Coding.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Coding.BackgroundImage")));
            this.bt_Coding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Coding.Location = new System.Drawing.Point(62, 73);
            this.bt_Coding.Name = "bt_Coding";
            this.bt_Coding.Size = new System.Drawing.Size(50, 50);
            this.bt_Coding.TabIndex = 2;
            this.bt_Coding.UseVisualStyleBackColor = false;
            this.bt_Coding.Click += new System.EventHandler(this.bt_Coding_Click);
            this.bt_Coding.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.bt_Other);
            this.panel6.Controls.Add(this.bt_Measurement);
            this.panel6.Controls.Add(this.bt_Signalling);
            this.panel6.Controls.Add(this.bt_Inverter);
            this.panel6.Controls.Add(this.bt_Reporter);
            this.panel6.Controls.Add(this.bt_Generator);
            this.panel6.Location = new System.Drawing.Point(4, 309);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(119, 256);
            this.panel6.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "· Device";
            // 
            // bt_Other
            // 
            this.bt_Other.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Other.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Other.Location = new System.Drawing.Point(62, 203);
            this.bt_Other.Name = "bt_Other";
            this.bt_Other.Size = new System.Drawing.Size(50, 50);
            this.bt_Other.TabIndex = 0;
            this.bt_Other.Text = "Other";
            this.bt_Other.UseVisualStyleBackColor = false;
            this.bt_Other.Click += new System.EventHandler(this.bt_Other_Click);
            // 
            // bt_Measurement
            // 
            this.bt_Measurement.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Measurement.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Measurement.BackgroundImage")));
            this.bt_Measurement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Measurement.Location = new System.Drawing.Point(6, 128);
            this.bt_Measurement.Name = "bt_Measurement";
            this.bt_Measurement.Size = new System.Drawing.Size(50, 50);
            this.bt_Measurement.TabIndex = 0;
            this.bt_Measurement.UseVisualStyleBackColor = false;
            this.bt_Measurement.Click += new System.EventHandler(this.bt_Measurement_Click);
            this.bt_Measurement.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_Signalling
            // 
            this.bt_Signalling.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Signalling.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Signalling.BackgroundImage")));
            this.bt_Signalling.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Signalling.Location = new System.Drawing.Point(62, 73);
            this.bt_Signalling.Name = "bt_Signalling";
            this.bt_Signalling.Size = new System.Drawing.Size(50, 50);
            this.bt_Signalling.TabIndex = 0;
            this.bt_Signalling.UseVisualStyleBackColor = false;
            this.bt_Signalling.Click += new System.EventHandler(this.bt_Signalling_Click);
            this.bt_Signalling.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_Inverter
            // 
            this.bt_Inverter.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Inverter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Inverter.BackgroundImage")));
            this.bt_Inverter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Inverter.Location = new System.Drawing.Point(6, 72);
            this.bt_Inverter.Name = "bt_Inverter";
            this.bt_Inverter.Size = new System.Drawing.Size(50, 50);
            this.bt_Inverter.TabIndex = 0;
            this.bt_Inverter.UseVisualStyleBackColor = false;
            this.bt_Inverter.Click += new System.EventHandler(this.bt_Inverter_Click);
            this.bt_Inverter.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_Reporter
            // 
            this.bt_Reporter.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Reporter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Reporter.BackgroundImage")));
            this.bt_Reporter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Reporter.Location = new System.Drawing.Point(62, 17);
            this.bt_Reporter.Name = "bt_Reporter";
            this.bt_Reporter.Size = new System.Drawing.Size(50, 50);
            this.bt_Reporter.TabIndex = 0;
            this.bt_Reporter.UseVisualStyleBackColor = false;
            this.bt_Reporter.Click += new System.EventHandler(this.bt_Reporter_Click);
            this.bt_Reporter.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // bt_Generator
            // 
            this.bt_Generator.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Generator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Generator.BackgroundImage")));
            this.bt_Generator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Generator.Location = new System.Drawing.Point(6, 17);
            this.bt_Generator.Name = "bt_Generator";
            this.bt_Generator.Size = new System.Drawing.Size(50, 50);
            this.bt_Generator.TabIndex = 0;
            this.bt_Generator.UseVisualStyleBackColor = false;
            this.bt_Generator.Click += new System.EventHandler(this.bt_Generator_Click);
            this.bt_Generator.MouseHover += new System.EventHandler(this.bt_MouserHover);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(136, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(739, 617);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.pn_Brick, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lb_Brick, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(733, 117);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // pn_Brick
            // 
            this.pn_Brick.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_Brick.AutoScroll = true;
            this.pn_Brick.Location = new System.Drawing.Point(4, 4);
            this.pn_Brick.Name = "pn_Brick";
            this.pn_Brick.Size = new System.Drawing.Size(578, 109);
            this.pn_Brick.TabIndex = 0;
            // 
            // lb_Brick
            // 
            this.lb_Brick.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Brick.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_Brick.FormattingEnabled = true;
            this.lb_Brick.ItemHeight = 14;
            this.lb_Brick.Location = new System.Drawing.Point(589, 4);
            this.lb_Brick.Name = "lb_Brick";
            this.lb_Brick.Size = new System.Drawing.Size(140, 98);
            this.lb_Brick.TabIndex = 1;
            this.lb_Brick.SelectedIndexChanged += new System.EventHandler(this.lb_Brick_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.pn_Seq, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.pn_Circle, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 126);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(733, 488);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // pn_Seq
            // 
            this.pn_Seq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_Seq.AutoScroll = true;
            this.pn_Seq.Location = new System.Drawing.Point(4, 4);
            this.pn_Seq.Name = "pn_Seq";
            this.pn_Seq.Size = new System.Drawing.Size(725, 115);
            this.pn_Seq.TabIndex = 0;
            // 
            // pn_Circle
            // 
            this.pn_Circle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_Circle.Location = new System.Drawing.Point(4, 126);
            this.pn_Circle.Name = "pn_Circle";
            this.pn_Circle.Size = new System.Drawing.Size(725, 358);
            this.pn_Circle.TabIndex = 1;
            this.pn_Circle.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_Circle_Paint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 623);
            this.panel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(879, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 610F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(178, 611);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1094, 672);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brick Designer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_Add_Brick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_Promoter;
        private System.Windows.Forms.Button bt_RBS;
        private System.Windows.Forms.Button bt_ProteinD;
        private System.Windows.Forms.Button bt_Primer;
        private System.Windows.Forms.Button bt_Plasmid;
        private System.Windows.Forms.Button bt_DNA;
        private System.Windows.Forms.Button bt_Terminator;
        private System.Windows.Forms.Button bt_TU;
        private System.Windows.Forms.Button bt_Coding;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel pn_Brick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ListBox lb_Brick;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem loadtoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem savetoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem extoolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Measurement;
        private System.Windows.Forms.Button bt_Signalling;
        private System.Windows.Forms.Button bt_Inverter;
        private System.Windows.Forms.Button bt_Reporter;
        private System.Windows.Forms.Button bt_Generator;
        private System.Windows.Forms.ToolStripMenuItem genbankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sBOLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clonningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBToolStripMenuItem;
        private System.Windows.Forms.Panel pn_Seq;
        private System.Windows.Forms.Panel pn_Circle;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListBox lb_Subparts;
        private System.Windows.Forms.TextBox tb_Desc;
        private System.Windows.Forms.TextBox tb_BQ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_Entered;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_URL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_Result;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_Status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_Type;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_Scar;
        private System.Windows.Forms.Button bt_Other;
        private System.Windows.Forms.ToolStripMenuItem screenShotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastaToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem scarToolStripMenuItem;


    }
}

