
namespace ToolWorking.Views
{
    partial class Database
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Database));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbRunQuery = new System.Windows.Forms.RadioButton();
            this.rbRunScript = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReloadFolder = new System.Windows.Forms.Button();
            this.lblPathFolder = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtPathFolder = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCheckConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.progressBarFolder = new System.Windows.Forms.ProgressBar();
            this.treeViewFolder = new System.Windows.Forms.TreeView();
            this.imageListTree = new System.Windows.Forms.ImageList(this.components);
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.btnCopyResult = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelCenterScript = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.panelCenterQuery = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtScriptTable = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResultQuery = new System.Windows.Forms.RichTextBox();
            this.gridInputValue = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelCenterScript.SuspendLayout();
            this.panelCenterQuery.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInputValue)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.cbDatabase);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.rbRunQuery);
            this.panelTop.Controls.Add(this.rbRunScript);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.btnReloadFolder);
            this.panelTop.Controls.Add(this.lblPathFolder);
            this.panelTop.Controls.Add(this.btnOpenFolder);
            this.panelTop.Controls.Add(this.txtPathFolder);
            this.panelTop.Controls.Add(this.txtPass);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.btnCheckConnect);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.txtUser);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.txtServer);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(660, 63);
            this.panelTop.TabIndex = 0;
            // 
            // cbDatabase
            // 
            this.cbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabase.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cbDatabase.Items.AddRange(new object[] {
            "esKyotsu",
            "Usolia障害者福祉システム"});
            this.cbDatabase.Location = new System.Drawing.Point(220, 6);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(120, 25);
            this.cbDatabase.TabIndex = 22;
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label4.Location = new System.Drawing.Point(148, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Database";
            // 
            // rbRunQuery
            // 
            this.rbRunQuery.AutoSize = true;
            this.rbRunQuery.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbRunQuery.Location = new System.Drawing.Point(150, 37);
            this.rbRunQuery.Name = "rbRunQuery";
            this.rbRunQuery.Size = new System.Drawing.Size(91, 21);
            this.rbRunQuery.TabIndex = 20;
            this.rbRunQuery.Text = "Run Query";
            this.rbRunQuery.UseVisualStyleBackColor = true;
            this.rbRunQuery.CheckedChanged += new System.EventHandler(this.rbRunQuery_CheckedChanged);
            // 
            // rbRunScript
            // 
            this.rbRunScript.AutoSize = true;
            this.rbRunScript.Checked = true;
            this.rbRunScript.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbRunScript.Location = new System.Drawing.Point(55, 37);
            this.rbRunScript.Name = "rbRunScript";
            this.rbRunScript.Size = new System.Drawing.Size(89, 21);
            this.rbRunScript.TabIndex = 19;
            this.rbRunScript.TabStop = true;
            this.rbRunScript.Text = "Run Script";
            this.rbRunScript.UseVisualStyleBackColor = true;
            this.rbRunScript.CheckedChanged += new System.EventHandler(this.rbRunScript_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Mode";
            // 
            // btnReloadFolder
            // 
            this.btnReloadFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadFolder.Image")));
            this.btnReloadFolder.Location = new System.Drawing.Point(626, 36);
            this.btnReloadFolder.Name = "btnReloadFolder";
            this.btnReloadFolder.Size = new System.Drawing.Size(26, 24);
            this.btnReloadFolder.TabIndex = 16;
            this.btnReloadFolder.UseVisualStyleBackColor = true;
            this.btnReloadFolder.Click += new System.EventHandler(this.btnReloadFolder_Click);
            // 
            // lblPathFolder
            // 
            this.lblPathFolder.AutoSize = true;
            this.lblPathFolder.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblPathFolder.Location = new System.Drawing.Point(248, 39);
            this.lblPathFolder.Name = "lblPathFolder";
            this.lblPathFolder.Size = new System.Drawing.Size(107, 17);
            this.lblPathFolder.TabIndex = 17;
            this.lblPathFolder.Text = "Select Directory";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFolder.Image")));
            this.btnOpenFolder.Location = new System.Drawing.Point(596, 36);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(26, 24);
            this.btnOpenFolder.TabIndex = 15;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // txtPathFolder
            // 
            this.txtPathFolder.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPathFolder.Location = new System.Drawing.Point(357, 36);
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.ReadOnly = true;
            this.txtPathFolder.Size = new System.Drawing.Size(234, 24);
            this.txtPathFolder.TabIndex = 14;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPass.Location = new System.Drawing.Point(536, 6);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(85, 24);
            this.txtPass.TabIndex = 13;
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label3.Location = new System.Drawing.Point(466, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password";
            // 
            // btnCheckConnect
            // 
            this.btnCheckConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckConnect.Image")));
            this.btnCheckConnect.Location = new System.Drawing.Point(626, 6);
            this.btnCheckConnect.Name = "btnCheckConnect";
            this.btnCheckConnect.Size = new System.Drawing.Size(26, 24);
            this.btnCheckConnect.TabIndex = 11;
            this.btnCheckConnect.UseVisualStyleBackColor = true;
            this.btnCheckConnect.Click += new System.EventHandler(this.btnCheckConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label2.Location = new System.Drawing.Point(343, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "User";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtUser.Location = new System.Drawing.Point(378, 6);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(85, 24);
            this.txtUser.TabIndex = 3;
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server";
            // 
            // txtServer
            // 
            this.txtServer.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtServer.Location = new System.Drawing.Point(55, 6);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(90, 24);
            this.txtServer.TabIndex = 0;
            this.txtServer.Leave += new System.EventHandler(this.txtServer_Leave);
            // 
            // progressBarFolder
            // 
            this.progressBarFolder.Location = new System.Drawing.Point(9, 178);
            this.progressBarFolder.Name = "progressBarFolder";
            this.progressBarFolder.Size = new System.Drawing.Size(642, 21);
            this.progressBarFolder.TabIndex = 1;
            // 
            // treeViewFolder
            // 
            this.treeViewFolder.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.treeViewFolder.ImageIndex = 0;
            this.treeViewFolder.ImageList = this.imageListTree;
            this.treeViewFolder.Location = new System.Drawing.Point(9, 3);
            this.treeViewFolder.Name = "treeViewFolder";
            this.treeViewFolder.SelectedImageIndex = 0;
            this.treeViewFolder.Size = new System.Drawing.Size(642, 169);
            this.treeViewFolder.TabIndex = 6;
            this.treeViewFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolder_AfterSelect);
            this.treeViewFolder.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFolder_NodeMouseDoubleClick);
            // 
            // imageListTree
            // 
            this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
            this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTree.Images.SetKeyName(0, "icon-folder-2-16x16.png");
            this.imageListTree.Images.SetKeyName(1, "icon-file-16x16.png");
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnRunScript);
            this.panelBottom.Controls.Add(this.btnClearResult);
            this.panelBottom.Controls.Add(this.btnCopyResult);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 381);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(660, 30);
            this.panelBottom.TabIndex = 3;
            // 
            // btnRunScript
            // 
            this.btnRunScript.Enabled = false;
            this.btnRunScript.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnRunScript.Image = ((System.Drawing.Image)(resources.GetObject("btnRunScript.Image")));
            this.btnRunScript.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunScript.Location = new System.Drawing.Point(394, 0);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(100, 25);
            this.btnRunScript.TabIndex = 16;
            this.btnRunScript.Text = "    Run Script";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // btnClearResult
            // 
            this.btnClearResult.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnClearResult.Image = ((System.Drawing.Image)(resources.GetObject("btnClearResult.Image")));
            this.btnClearResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearResult.Location = new System.Drawing.Point(577, 0);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(75, 25);
            this.btnClearResult.TabIndex = 9;
            this.btnClearResult.Text = "    Clear";
            this.btnClearResult.UseVisualStyleBackColor = true;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // btnCopyResult
            // 
            this.btnCopyResult.Enabled = false;
            this.btnCopyResult.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnCopyResult.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyResult.Image")));
            this.btnCopyResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyResult.Location = new System.Drawing.Point(498, 0);
            this.btnCopyResult.Name = "btnCopyResult";
            this.btnCopyResult.Size = new System.Drawing.Size(75, 25);
            this.btnCopyResult.TabIndex = 8;
            this.btnCopyResult.Text = "    Copy";
            this.btnCopyResult.UseVisualStyleBackColor = true;
            this.btnCopyResult.Click += new System.EventHandler(this.btnCopyResult_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtResult.Location = new System.Drawing.Point(9, 205);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(318, 104);
            this.txtResult.TabIndex = 7;
            this.txtResult.Text = "";
            // 
            // panelCenterScript
            // 
            this.panelCenterScript.Controls.Add(this.txtLog);
            this.panelCenterScript.Controls.Add(this.treeViewFolder);
            this.panelCenterScript.Controls.Add(this.progressBarFolder);
            this.panelCenterScript.Controls.Add(this.txtResult);
            this.panelCenterScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterScript.Location = new System.Drawing.Point(0, 63);
            this.panelCenterScript.Name = "panelCenterScript";
            this.panelCenterScript.Size = new System.Drawing.Size(660, 318);
            this.panelCenterScript.TabIndex = 4;
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtLog.Location = new System.Drawing.Point(333, 205);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(318, 104);
            this.txtLog.TabIndex = 8;
            this.txtLog.Text = "";
            // 
            // panelCenterQuery
            // 
            this.panelCenterQuery.BackColor = System.Drawing.SystemColors.Control;
            this.panelCenterQuery.Controls.Add(this.groupBox1);
            this.panelCenterQuery.Controls.Add(this.groupBox2);
            this.panelCenterQuery.Controls.Add(this.groupBox3);
            this.panelCenterQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterQuery.Location = new System.Drawing.Point(0, 63);
            this.panelCenterQuery.Name = "panelCenterQuery";
            this.panelCenterQuery.Size = new System.Drawing.Size(660, 318);
            this.panelCenterQuery.TabIndex = 9;
            this.panelCenterQuery.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtScriptTable);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(9, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 83);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Script Table";
            // 
            // txtScriptTable
            // 
            this.txtScriptTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScriptTable.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScriptTable.Location = new System.Drawing.Point(3, 19);
            this.txtScriptTable.Name = "txtScriptTable";
            this.txtScriptTable.Size = new System.Drawing.Size(636, 61);
            this.txtScriptTable.TabIndex = 20;
            this.txtScriptTable.Text = "";
            this.txtScriptTable.Click += new System.EventHandler(this.txtScriptTable_Click);
            this.txtScriptTable.TextChanged += new System.EventHandler(this.txtScriptTable_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridInputValue);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(9, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 232);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Value ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtResultQuery);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox3.Location = new System.Drawing.Point(378, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 232);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result Query";
            // 
            // txtResultQuery
            // 
            this.txtResultQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultQuery.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultQuery.Location = new System.Drawing.Point(3, 19);
            this.txtResultQuery.Name = "txtResultQuery";
            this.txtResultQuery.ReadOnly = true;
            this.txtResultQuery.Size = new System.Drawing.Size(268, 210);
            this.txtResultQuery.TabIndex = 21;
            this.txtResultQuery.Text = "";
            // 
            // gridInputValue
            // 
            this.gridInputValue.AllowUserToAddRows = false;
            this.gridInputValue.AllowUserToDeleteRows = false;
            this.gridInputValue.AllowUserToResizeRows = false;
            this.gridInputValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInputValue.CausesValidation = false;
            this.gridInputValue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInputValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridInputValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInputValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.name,
            this.type,
            this.value});
            this.gridInputValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInputValue.EnableHeadersVisualStyles = false;
            this.gridInputValue.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridInputValue.Location = new System.Drawing.Point(3, 19);
            this.gridInputValue.Name = "gridInputValue";
            this.gridInputValue.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInputValue.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridInputValue.RowHeadersVisible = false;
            this.gridInputValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridInputValue.Size = new System.Drawing.Size(357, 210);
            this.gridInputValue.TabIndex = 11;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.Frozen = true;
            this.no.HeaderText = "No.";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.no.Width = 30;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.Frozen = true;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 95;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.type.Width = 80;
            // 
            // value
            // 
            this.value.DataPropertyName = "value";
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            this.value.Width = 134;
            // 
            // Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 411);
            this.Controls.Add(this.panelCenterQuery);
            this.Controls.Add(this.panelCenterScript);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Database";
            this.Text = "LinkFolder";
            this.Load += new System.EventHandler(this.Database_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelCenterScript.ResumeLayout(false);
            this.panelCenterQuery.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInputValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.ProgressBar progressBarFolder;
        private System.Windows.Forms.TreeView treeViewFolder;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ImageList imageListTree;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Button btnCopyResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckConnect;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReloadFolder;
        private System.Windows.Forms.Label lblPathFolder;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtPathFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbRunScript;
        private System.Windows.Forms.RadioButton rbRunQuery;
        private System.Windows.Forms.Panel panelCenterScript;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Panel panelCenterQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtScriptTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtResultQuery;
        private System.Windows.Forms.DataGridView gridInputValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
    }
}