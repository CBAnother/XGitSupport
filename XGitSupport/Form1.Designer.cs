namespace XGitSupport
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxDirPath = new System.Windows.Forms.TextBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.cbxUrl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxFile = new System.Windows.Forms.ListBox();
            this.btnImportGitFile = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbxNetGitVer = new System.Windows.Forms.ListBox();
            this.btnUpdateXGitImport = new System.Windows.Forms.Button();
            this.btnUpdateGroupImport = new System.Windows.Forms.Button();
            this.btnAddToGroup = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbxUnClean = new System.Windows.Forms.ListBox();
            this.btnShowUnclean = new System.Windows.Forms.Button();
            this.tbxSaveHashToA = new System.Windows.Forms.Button();
            this.tbxCmpDir = new System.Windows.Forms.TextBox();
            this.tbxSaveHashToB = new System.Windows.Forms.Button();
            this.btnCompareLocal = new System.Windows.Forms.Button();
            this.btnAutoCmp = new System.Windows.Forms.Button();
            this.btnParseXGit = new System.Windows.Forms.Button();
            this.cbxFromServer = new System.Windows.Forms.CheckBox();
            this.lbxOldVersion = new System.Windows.Forms.ListBox();
            this.btnUpdateXGit = new System.Windows.Forms.Button();
            this.btnCheckInVersion = new System.Windows.Forms.Button();
            this.rtbxBranchList = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbxDirPath
            // 
            this.tbxDirPath.Location = new System.Drawing.Point(12, 12);
            this.tbxDirPath.Name = "tbxDirPath";
            this.tbxDirPath.Size = new System.Drawing.Size(620, 21);
            this.tbxDirPath.TabIndex = 0;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(638, 10);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(107, 23);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "扫描项目";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // cbxUrl
            // 
            this.cbxUrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUrl.FormattingEnabled = true;
            this.cbxUrl.Location = new System.Drawing.Point(65, 39);
            this.cbxUrl.Name = "cbxUrl";
            this.cbxUrl.Size = new System.Drawing.Size(567, 20);
            this.cbxUrl.TabIndex = 2;
            this.cbxUrl.SelectedIndexChanged += new System.EventHandler(this.cbxUrl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "引用URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "版本列表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "文件列表";
            // 
            // lbxFile
            // 
            this.lbxFile.FormattingEnabled = true;
            this.lbxFile.ItemHeight = 12;
            this.lbxFile.Location = new System.Drawing.Point(65, 214);
            this.lbxFile.Name = "lbxFile";
            this.lbxFile.Size = new System.Drawing.Size(567, 136);
            this.lbxFile.TabIndex = 7;
            // 
            // btnImportGitFile
            // 
            this.btnImportGitFile.Location = new System.Drawing.Point(638, 91);
            this.btnImportGitFile.Name = "btnImportGitFile";
            this.btnImportGitFile.Size = new System.Drawing.Size(107, 23);
            this.btnImportGitFile.TabIndex = 8;
            this.btnImportGitFile.Text = "添加文件";
            this.btnImportGitFile.UseVisualStyleBackColor = true;
            this.btnImportGitFile.Click += new System.EventHandler(this.btnImportGitFile_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(638, 228);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(107, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(65, 360);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(567, 108);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(638, 120);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 21);
            this.textBox1.TabIndex = 11;
            // 
            // lbxNetGitVer
            // 
            this.lbxNetGitVer.FormattingEnabled = true;
            this.lbxNetGitVer.ItemHeight = 12;
            this.lbxNetGitVer.Location = new System.Drawing.Point(65, 65);
            this.lbxNetGitVer.Name = "lbxNetGitVer";
            this.lbxNetGitVer.Size = new System.Drawing.Size(567, 136);
            this.lbxNetGitVer.TabIndex = 7;
            this.lbxNetGitVer.SelectedIndexChanged += new System.EventHandler(this.lbxNetGitVer_SelectedIndexChanged);
            // 
            // btnUpdateXGitImport
            // 
            this.btnUpdateXGitImport.Location = new System.Drawing.Point(638, 36);
            this.btnUpdateXGitImport.Name = "btnUpdateXGitImport";
            this.btnUpdateXGitImport.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateXGitImport.TabIndex = 12;
            this.btnUpdateXGitImport.Text = "更新项目引用";
            this.btnUpdateXGitImport.UseVisualStyleBackColor = true;
            this.btnUpdateXGitImport.Click += new System.EventHandler(this.btnUpdateXGitImport_Click);
            // 
            // btnUpdateGroupImport
            // 
            this.btnUpdateGroupImport.Location = new System.Drawing.Point(638, 360);
            this.btnUpdateGroupImport.Name = "btnUpdateGroupImport";
            this.btnUpdateGroupImport.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateGroupImport.TabIndex = 14;
            this.btnUpdateGroupImport.Text = "更新项目引用集";
            this.btnUpdateGroupImport.UseVisualStyleBackColor = true;
            this.btnUpdateGroupImport.Click += new System.EventHandler(this.btnUpdateGroupImport_Click);
            // 
            // btnAddToGroup
            // 
            this.btnAddToGroup.Location = new System.Drawing.Point(638, 389);
            this.btnAddToGroup.Name = "btnAddToGroup";
            this.btnAddToGroup.Size = new System.Drawing.Size(107, 23);
            this.btnAddToGroup.TabIndex = 14;
            this.btnAddToGroup.Text = "添加到集";
            this.btnAddToGroup.UseVisualStyleBackColor = true;
            this.btnAddToGroup.Click += new System.EventHandler(this.btnAddToGroup_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(638, 418);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(107, 21);
            this.textBox2.TabIndex = 15;
            // 
            // lbxUnClean
            // 
            this.lbxUnClean.FormattingEnabled = true;
            this.lbxUnClean.ItemHeight = 12;
            this.lbxUnClean.Location = new System.Drawing.Point(751, 10);
            this.lbxUnClean.Name = "lbxUnClean";
            this.lbxUnClean.Size = new System.Drawing.Size(327, 280);
            this.lbxUnClean.TabIndex = 16;
            this.lbxUnClean.SelectedIndexChanged += new System.EventHandler(this.lbxUnClean_SelectedIndexChanged);
            // 
            // btnShowUnclean
            // 
            this.btnShowUnclean.Location = new System.Drawing.Point(638, 331);
            this.btnShowUnclean.Name = "btnShowUnclean";
            this.btnShowUnclean.Size = new System.Drawing.Size(107, 23);
            this.btnShowUnclean.TabIndex = 17;
            this.btnShowUnclean.Text = "列出未clean的";
            this.btnShowUnclean.UseVisualStyleBackColor = true;
            this.btnShowUnclean.Click += new System.EventHandler(this.btnShowUnclean_Click);
            // 
            // tbxSaveHashToA
            // 
            this.tbxSaveHashToA.Location = new System.Drawing.Point(638, 476);
            this.tbxSaveHashToA.Name = "tbxSaveHashToA";
            this.tbxSaveHashToA.Size = new System.Drawing.Size(107, 23);
            this.tbxSaveHashToA.TabIndex = 18;
            this.tbxSaveHashToA.Text = "存储至A";
            this.tbxSaveHashToA.UseVisualStyleBackColor = true;
            this.tbxSaveHashToA.Click += new System.EventHandler(this.tbxSaveHashToA_Click);
            // 
            // tbxCmpDir
            // 
            this.tbxCmpDir.Location = new System.Drawing.Point(65, 478);
            this.tbxCmpDir.Name = "tbxCmpDir";
            this.tbxCmpDir.Size = new System.Drawing.Size(567, 21);
            this.tbxCmpDir.TabIndex = 15;
            // 
            // tbxSaveHashToB
            // 
            this.tbxSaveHashToB.Location = new System.Drawing.Point(638, 501);
            this.tbxSaveHashToB.Name = "tbxSaveHashToB";
            this.tbxSaveHashToB.Size = new System.Drawing.Size(107, 23);
            this.tbxSaveHashToB.TabIndex = 18;
            this.tbxSaveHashToB.Text = "存储至B";
            this.tbxSaveHashToB.UseVisualStyleBackColor = true;
            this.tbxSaveHashToB.Click += new System.EventHandler(this.tbxSaveHashToB_Click);
            // 
            // btnCompareLocal
            // 
            this.btnCompareLocal.Location = new System.Drawing.Point(571, 501);
            this.btnCompareLocal.Name = "btnCompareLocal";
            this.btnCompareLocal.Size = new System.Drawing.Size(61, 23);
            this.btnCompareLocal.TabIndex = 18;
            this.btnCompareLocal.Text = "比较";
            this.btnCompareLocal.UseVisualStyleBackColor = true;
            this.btnCompareLocal.Click += new System.EventHandler(this.btnCompareLocal_Click);
            // 
            // btnAutoCmp
            // 
            this.btnAutoCmp.Location = new System.Drawing.Point(490, 501);
            this.btnAutoCmp.Name = "btnAutoCmp";
            this.btnAutoCmp.Size = new System.Drawing.Size(75, 23);
            this.btnAutoCmp.TabIndex = 19;
            this.btnAutoCmp.Text = "自动比较";
            this.btnAutoCmp.UseVisualStyleBackColor = true;
            this.btnAutoCmp.Click += new System.EventHandler(this.btnAutoCmp_Click);
            // 
            // btnParseXGit
            // 
            this.btnParseXGit.Location = new System.Drawing.Point(233, 501);
            this.btnParseXGit.Name = "btnParseXGit";
            this.btnParseXGit.Size = new System.Drawing.Size(120, 23);
            this.btnParseXGit.TabIndex = 20;
            this.btnParseXGit.Text = "列出非最新的引用";
            this.btnParseXGit.UseVisualStyleBackColor = true;
            this.btnParseXGit.Click += new System.EventHandler(this.btnParseXGit_Click);
            // 
            // cbxFromServer
            // 
            this.cbxFromServer.AutoSize = true;
            this.cbxFromServer.Location = new System.Drawing.Point(131, 505);
            this.cbxFromServer.Name = "cbxFromServer";
            this.cbxFromServer.Size = new System.Drawing.Size(96, 16);
            this.cbxFromServer.TabIndex = 21;
            this.cbxFromServer.Text = "从服务器获取";
            this.cbxFromServer.UseVisualStyleBackColor = true;
            // 
            // lbxOldVersion
            // 
            this.lbxOldVersion.FormattingEnabled = true;
            this.lbxOldVersion.ItemHeight = 12;
            this.lbxOldVersion.Location = new System.Drawing.Point(751, 331);
            this.lbxOldVersion.Name = "lbxOldVersion";
            this.lbxOldVersion.Size = new System.Drawing.Size(327, 196);
            this.lbxOldVersion.TabIndex = 22;
            // 
            // btnUpdateXGit
            // 
            this.btnUpdateXGit.Location = new System.Drawing.Point(359, 501);
            this.btnUpdateXGit.Name = "btnUpdateXGit";
            this.btnUpdateXGit.Size = new System.Drawing.Size(125, 23);
            this.btnUpdateXGit.TabIndex = 20;
            this.btnUpdateXGit.Text = "更新非最新的引用";
            this.btnUpdateXGit.UseVisualStyleBackColor = true;
            this.btnUpdateXGit.Click += new System.EventHandler(this.btnUpdateXGit_Click);
            // 
            // btnCheckInVersion
            // 
            this.btnCheckInVersion.Location = new System.Drawing.Point(638, 445);
            this.btnCheckInVersion.Name = "btnCheckInVersion";
            this.btnCheckInVersion.Size = new System.Drawing.Size(107, 23);
            this.btnCheckInVersion.TabIndex = 23;
            this.btnCheckInVersion.Text = "是否处于版本中";
            this.btnCheckInVersion.UseVisualStyleBackColor = true;
            this.btnCheckInVersion.Click += new System.EventHandler(this.btnCheckInVersion_Click);
            // 
            // rtbxBranchList
            // 
            this.rtbxBranchList.Location = new System.Drawing.Point(-1, 360);
            this.rtbxBranchList.Name = "rtbxBranchList";
            this.rtbxBranchList.Size = new System.Drawing.Size(60, 139);
            this.rtbxBranchList.TabIndex = 24;
            this.rtbxBranchList.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 536);
            this.Controls.Add(this.rtbxBranchList);
            this.Controls.Add(this.btnCheckInVersion);
            this.Controls.Add(this.lbxOldVersion);
            this.Controls.Add(this.cbxFromServer);
            this.Controls.Add(this.btnUpdateXGit);
            this.Controls.Add(this.btnParseXGit);
            this.Controls.Add(this.btnAutoCmp);
            this.Controls.Add(this.btnCompareLocal);
            this.Controls.Add(this.tbxSaveHashToB);
            this.Controls.Add(this.tbxSaveHashToA);
            this.Controls.Add(this.btnShowUnclean);
            this.Controls.Add(this.lbxUnClean);
            this.Controls.Add(this.tbxCmpDir);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnAddToGroup);
            this.Controls.Add(this.btnUpdateGroupImport);
            this.Controls.Add(this.btnUpdateXGitImport);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnImportGitFile);
            this.Controls.Add(this.lbxNetGitVer);
            this.Controls.Add(this.lbxFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxUrl);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.tbxDirPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDirPath;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ComboBox cbxUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxFile;
        private System.Windows.Forms.Button btnImportGitFile;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lbxNetGitVer;
        private System.Windows.Forms.Button btnUpdateXGitImport;
        private System.Windows.Forms.Button btnUpdateGroupImport;
        private System.Windows.Forms.Button btnAddToGroup;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox lbxUnClean;
        private System.Windows.Forms.Button btnShowUnclean;
        private System.Windows.Forms.Button tbxSaveHashToA;
        private System.Windows.Forms.TextBox tbxCmpDir;
        private System.Windows.Forms.Button tbxSaveHashToB;
        private System.Windows.Forms.Button btnCompareLocal;
        private System.Windows.Forms.Button btnAutoCmp;
        private System.Windows.Forms.Button btnParseXGit;
        private System.Windows.Forms.CheckBox cbxFromServer;
        private System.Windows.Forms.ListBox lbxOldVersion;
        private System.Windows.Forms.Button btnUpdateXGit;
        private System.Windows.Forms.Button btnCheckInVersion;
        private System.Windows.Forms.RichTextBox rtbxBranchList;
    }
}

