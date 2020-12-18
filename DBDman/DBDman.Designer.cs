namespace DBDman
{
    partial class DBDman
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInstallCert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUninstallCert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExportCert = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerAddXp = new System.ComponentModel.BackgroundWorker();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.log = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.textBoxCookie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.numericUpDownKillerPips = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSurvivorPips = new System.Windows.Forms.NumericUpDown();
            this.buttonGetRank = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTotalXp = new System.Windows.Forms.Label();
            this.labelDevotion = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonGetCurrentXp = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.groupBoxInventory = new System.Windows.Forms.GroupBox();
            this.radioButtonInventoryDump = new System.Windows.Forms.RadioButton();
            this.radioButtonInventoryRedirect = new System.Windows.Forms.RadioButton();
            this.checkBoxInventory = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxSave = new System.Windows.Forms.GroupBox();
            this.radioButtonSaveDump = new System.Windows.Forms.RadioButton();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKillerPips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSurvivorPips)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBoxInventory.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxSave.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInstallCert,
            this.menuUninstallCert,
            this.toolStripMenuItem1,
            this.menuExportCert});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuInstallCert
            // 
            this.menuInstallCert.Enabled = false;
            this.menuInstallCert.Name = "menuInstallCert";
            this.menuInstallCert.Size = new System.Drawing.Size(177, 22);
            this.menuInstallCert.Text = "Install Certificate";
            this.menuInstallCert.Click += new System.EventHandler(this.menuInstallCert_Click);
            // 
            // menuUninstallCert
            // 
            this.menuUninstallCert.Enabled = false;
            this.menuUninstallCert.Name = "menuUninstallCert";
            this.menuUninstallCert.Size = new System.Drawing.Size(177, 22);
            this.menuUninstallCert.Text = "Uninstall Certificate";
            this.menuUninstallCert.Click += new System.EventHandler(this.menuUninstallCert_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // menuExportCert
            // 
            this.menuExportCert.Enabled = false;
            this.menuExportCert.Name = "menuExportCert";
            this.menuExportCert.Size = new System.Drawing.Size(177, 22);
            this.menuExportCert.Text = "Export Certificate";
            this.menuExportCert.Click += new System.EventHandler(this.menuExportCert_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.log);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(402, 348);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Log";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.Black;
            this.log.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.ForeColor = System.Drawing.Color.Lime;
            this.log.Location = new System.Drawing.Point(3, 3);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(396, 342);
            this.log.TabIndex = 2;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.textBoxCookie);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(402, 348);
            this.tabPage7.TabIndex = 5;
            this.tabPage7.Text = "Options";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // textBoxCookie
            // 
            this.textBoxCookie.Location = new System.Drawing.Point(53, 13);
            this.textBoxCookie.Multiline = true;
            this.textBoxCookie.Name = "textBoxCookie";
            this.textBoxCookie.Size = new System.Drawing.Size(337, 106);
            this.textBoxCookie.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cookie:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.numericUpDownKillerPips);
            this.tabPage5.Controls.Add(this.numericUpDownSurvivorPips);
            this.tabPage5.Controls.Add(this.buttonGetRank);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(402, 348);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "Rank";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // numericUpDownKillerPips
            // 
            this.numericUpDownKillerPips.Location = new System.Drawing.Point(214, 164);
            this.numericUpDownKillerPips.Maximum = new decimal(new int[] {
            85,
            0,
            0,
            0});
            this.numericUpDownKillerPips.Name = "numericUpDownKillerPips";
            this.numericUpDownKillerPips.Size = new System.Drawing.Size(61, 20);
            this.numericUpDownKillerPips.TabIndex = 9;
            // 
            // numericUpDownSurvivorPips
            // 
            this.numericUpDownSurvivorPips.Location = new System.Drawing.Point(214, 124);
            this.numericUpDownSurvivorPips.Maximum = new decimal(new int[] {
            85,
            0,
            0,
            0});
            this.numericUpDownSurvivorPips.Name = "numericUpDownSurvivorPips";
            this.numericUpDownSurvivorPips.Size = new System.Drawing.Size(61, 20);
            this.numericUpDownSurvivorPips.TabIndex = 8;
            // 
            // buttonGetRank
            // 
            this.buttonGetRank.Location = new System.Drawing.Point(161, 243);
            this.buttonGetRank.Name = "buttonGetRank";
            this.buttonGetRank.Size = new System.Drawing.Size(87, 23);
            this.buttonGetRank.TabIndex = 0;
            this.buttonGetRank.Text = "Get Rank";
            this.buttonGetRank.UseVisualStyleBackColor = true;
            this.buttonGetRank.Click += new System.EventHandler(this.buttonGetRank_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label7.Location = new System.Drawing.Point(84, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 24);
            this.label7.TabIndex = 3;
            this.label7.Text = "Survivor Pips:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label8.Location = new System.Drawing.Point(111, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "Killer Pips:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(402, 348);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "XP";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelTotalXp);
            this.panel1.Controls.Add(this.labelDevotion);
            this.panel1.Controls.Add(this.labelLevel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.buttonGetCurrentXp);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 185);
            this.panel1.TabIndex = 1;
            // 
            // labelTotalXp
            // 
            this.labelTotalXp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTotalXp.Location = new System.Drawing.Point(212, 100);
            this.labelTotalXp.Name = "labelTotalXp";
            this.labelTotalXp.Size = new System.Drawing.Size(100, 22);
            this.labelTotalXp.TabIndex = 6;
            this.labelTotalXp.Text = "?";
            // 
            // labelDevotion
            // 
            this.labelDevotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelDevotion.Location = new System.Drawing.Point(212, 60);
            this.labelDevotion.Name = "labelDevotion";
            this.labelDevotion.Size = new System.Drawing.Size(100, 22);
            this.labelDevotion.TabIndex = 5;
            this.labelDevotion.Text = "?";
            // 
            // labelLevel
            // 
            this.labelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelLevel.Location = new System.Drawing.Point(212, 20);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(100, 22);
            this.labelLevel.TabIndex = 4;
            this.labelLevel.Text = "?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(112, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Devotion: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(141, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Level: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(114, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total XP: ";
            // 
            // buttonGetCurrentXp
            // 
            this.buttonGetCurrentXp.Location = new System.Drawing.Point(156, 151);
            this.buttonGetCurrentXp.Name = "buttonGetCurrentXp";
            this.buttonGetCurrentXp.Size = new System.Drawing.Size(87, 23);
            this.buttonGetCurrentXp.TabIndex = 0;
            this.buttonGetCurrentXp.Text = "Get Current XP";
            this.buttonGetCurrentXp.UseVisualStyleBackColor = true;
            this.buttonGetCurrentXp.Click += new System.EventHandler(this.buttonGetCurrentXp_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonInventory);
            this.tabPage3.Controls.Add(this.groupBoxInventory);
            this.tabPage3.Controls.Add(this.checkBoxInventory);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(402, 348);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Inventory";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonInventory
            // 
            this.buttonInventory.Location = new System.Drawing.Point(140, 232);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(120, 32);
            this.buttonInventory.TabIndex = 5;
            this.buttonInventory.Text = "Inventory Manager";
            this.buttonInventory.UseVisualStyleBackColor = true;
            this.buttonInventory.Click += new System.EventHandler(this.buttonInventory_Click);
            // 
            // groupBoxInventory
            // 
            this.groupBoxInventory.Controls.Add(this.radioButtonInventoryDump);
            this.groupBoxInventory.Controls.Add(this.radioButtonInventoryRedirect);
            this.groupBoxInventory.Enabled = false;
            this.groupBoxInventory.Location = new System.Drawing.Point(101, 112);
            this.groupBoxInventory.Name = "groupBoxInventory";
            this.groupBoxInventory.Size = new System.Drawing.Size(200, 100);
            this.groupBoxInventory.TabIndex = 4;
            this.groupBoxInventory.TabStop = false;
            // 
            // radioButtonInventoryDump
            // 
            this.radioButtonInventoryDump.AutoSize = true;
            this.radioButtonInventoryDump.Checked = true;
            this.radioButtonInventoryDump.Location = new System.Drawing.Point(28, 44);
            this.radioButtonInventoryDump.Name = "radioButtonInventoryDump";
            this.radioButtonInventoryDump.Size = new System.Drawing.Size(53, 17);
            this.radioButtonInventoryDump.TabIndex = 1;
            this.radioButtonInventoryDump.TabStop = true;
            this.radioButtonInventoryDump.Text = "Dump";
            this.radioButtonInventoryDump.UseVisualStyleBackColor = true;
            // 
            // radioButtonInventoryRedirect
            // 
            this.radioButtonInventoryRedirect.AutoSize = true;
            this.radioButtonInventoryRedirect.Location = new System.Drawing.Point(113, 44);
            this.radioButtonInventoryRedirect.Name = "radioButtonInventoryRedirect";
            this.radioButtonInventoryRedirect.Size = new System.Drawing.Size(65, 17);
            this.radioButtonInventoryRedirect.TabIndex = 2;
            this.radioButtonInventoryRedirect.Text = "Redirect";
            this.radioButtonInventoryRedirect.UseVisualStyleBackColor = true;
            // 
            // checkBoxInventory
            // 
            this.checkBoxInventory.AutoSize = true;
            this.checkBoxInventory.Location = new System.Drawing.Point(18, 18);
            this.checkBoxInventory.Name = "checkBoxInventory";
            this.checkBoxInventory.Size = new System.Drawing.Size(59, 17);
            this.checkBoxInventory.TabIndex = 1;
            this.checkBoxInventory.Text = "Enable";
            this.checkBoxInventory.UseVisualStyleBackColor = true;
            this.checkBoxInventory.CheckedChanged += new System.EventHandler(this.checkBoxInventory_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxSave);
            this.tabPage2.Controls.Add(this.checkBoxSave);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(402, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Save";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxSave
            // 
            this.groupBoxSave.Controls.Add(this.radioButtonSaveDump);
            this.groupBoxSave.Enabled = false;
            this.groupBoxSave.Location = new System.Drawing.Point(101, 112);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(200, 100);
            this.groupBoxSave.TabIndex = 3;
            this.groupBoxSave.TabStop = false;
            // 
            // radioButtonSaveDump
            // 
            this.radioButtonSaveDump.AutoSize = true;
            this.radioButtonSaveDump.Checked = true;
            this.radioButtonSaveDump.Location = new System.Drawing.Point(28, 44);
            this.radioButtonSaveDump.Name = "radioButtonSaveDump";
            this.radioButtonSaveDump.Size = new System.Drawing.Size(53, 17);
            this.radioButtonSaveDump.TabIndex = 1;
            this.radioButtonSaveDump.TabStop = true;
            this.radioButtonSaveDump.Text = "Dump";
            this.radioButtonSaveDump.UseVisualStyleBackColor = true;
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Location = new System.Drawing.Point(18, 18);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(59, 17);
            this.checkBoxSave.TabIndex = 0;
            this.checkBoxSave.Text = "Enable";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            this.checkBoxSave.CheckedChanged += new System.EventHandler(this.checkBoxSave_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonServer);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(402, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonServer
            // 
            this.buttonServer.Location = new System.Drawing.Point(139, 258);
            this.buttonServer.Name = "buttonServer";
            this.buttonServer.Size = new System.Drawing.Size(130, 44);
            this.buttonServer.TabIndex = 1;
            this.buttonServer.Text = "Start Server";
            this.buttonServer.UseVisualStyleBackColor = true;
            this.buttonServer.Click += new System.EventHandler(this.buttonServer_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to DBDman";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(12, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(410, 374);
            this.tabControl1.TabIndex = 1;
            // 
            // DBDman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "DBDman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DBDman_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKillerPips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSurvivorPips)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBoxInventory.ResumeLayout(false);
            this.groupBoxInventory.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxSave.ResumeLayout(false);
            this.groupBoxSave.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuInstallCert;
        private System.Windows.Forms.ToolStripMenuItem menuUninstallCert;
        private System.Windows.Forms.ToolStripMenuItem menuExportCert;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAddXp;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox textBoxCookie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.NumericUpDown numericUpDownKillerPips;
        private System.Windows.Forms.NumericUpDown numericUpDownSurvivorPips;
        private System.Windows.Forms.Button buttonGetRank;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTotalXp;
        private System.Windows.Forms.Label labelDevotion;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonGetCurrentXp;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonInventory;
        private System.Windows.Forms.GroupBox groupBoxInventory;
        private System.Windows.Forms.RadioButton radioButtonInventoryDump;
        private System.Windows.Forms.RadioButton radioButtonInventoryRedirect;
        private System.Windows.Forms.CheckBox checkBoxInventory;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxSave;
        private System.Windows.Forms.RadioButton radioButtonSaveDump;
        private System.Windows.Forms.CheckBox checkBoxSave;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

