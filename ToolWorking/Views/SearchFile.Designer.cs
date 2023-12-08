
namespace ToolWorking.Views
{
    partial class SearchFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchFile));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnSearchPG = new System.Windows.Forms.Button();
            this.txtPGSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReloadFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtPathFolder = new System.Windows.Forms.TextBox();
            this.progressBarFolder = new System.Windows.Forms.ProgressBar();
            this.imageListTree = new System.Windows.Forms.ImageList(this.components);
            this.panelCenter = new System.Windows.Forms.Panel();
            this.cbProcessOpen = new System.Windows.Forms.ComboBox();
            this.rbReadOpen = new System.Windows.Forms.RadioButton();
            this.rbRead = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.gridViewFiles = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.btnCopyResult = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelTop.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnSearchPG);
            this.panelTop.Controls.Add(this.txtPGSearch);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.btnReloadFolder);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnOpenFolder);
            this.panelTop.Controls.Add(this.txtPathFolder);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(660, 33);
            this.panelTop.TabIndex = 0;
            // 
            // btnSearchPG
            // 
            this.btnSearchPG.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPG.Image")));
            this.btnSearchPG.Location = new System.Drawing.Point(626, 6);
            this.btnSearchPG.Name = "btnSearchPG";
            this.btnSearchPG.Size = new System.Drawing.Size(26, 24);
            this.btnSearchPG.TabIndex = 5;
            this.btnSearchPG.UseVisualStyleBackColor = true;
            this.btnSearchPG.Click += new System.EventHandler(this.btnSearchPG_Click);
            // 
            // txtPGSearch
            // 
            this.txtPGSearch.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPGSearch.Location = new System.Drawing.Point(452, 6);
            this.txtPGSearch.Name = "txtPGSearch";
            this.txtPGSearch.Size = new System.Drawing.Size(169, 24);
            this.txtPGSearch.TabIndex = 4;
            this.txtPGSearch.Click += new System.EventHandler(this.txtPGSearch_Click);
            this.txtPGSearch.TextChanged += new System.EventHandler(this.txtPGSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label2.Location = new System.Drawing.Point(376, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "PG Search";
            // 
            // btnReloadFolder
            // 
            this.btnReloadFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadFolder.Image")));
            this.btnReloadFolder.Location = new System.Drawing.Point(346, 6);
            this.btnReloadFolder.Name = "btnReloadFolder";
            this.btnReloadFolder.Size = new System.Drawing.Size(26, 24);
            this.btnReloadFolder.TabIndex = 3;
            this.btnReloadFolder.UseVisualStyleBackColor = true;
            this.btnReloadFolder.Click += new System.EventHandler(this.btnReloadFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Directory";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFolder.Image")));
            this.btnOpenFolder.Location = new System.Drawing.Point(316, 6);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(26, 24);
            this.btnOpenFolder.TabIndex = 2;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // txtPathFolder
            // 
            this.txtPathFolder.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPathFolder.Location = new System.Drawing.Point(131, 6);
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.ReadOnly = true;
            this.txtPathFolder.Size = new System.Drawing.Size(180, 24);
            this.txtPathFolder.TabIndex = 1;
            // 
            // progressBarFolder
            // 
            this.progressBarFolder.Location = new System.Drawing.Point(10, 198);
            this.progressBarFolder.Name = "progressBarFolder";
            this.progressBarFolder.Size = new System.Drawing.Size(640, 21);
            this.progressBarFolder.TabIndex = 1;
            // 
            // imageListTree
            // 
            this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
            this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTree.Images.SetKeyName(0, "icon-folder-16x16.png");
            this.imageListTree.Images.SetKeyName(1, "icon-file-16x16.png");
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.cbProcessOpen);
            this.panelCenter.Controls.Add(this.rbReadOpen);
            this.panelCenter.Controls.Add(this.rbRead);
            this.panelCenter.Controls.Add(this.label3);
            this.panelCenter.Controls.Add(this.gridViewFiles);
            this.panelCenter.Controls.Add(this.btnClearResult);
            this.panelCenter.Controls.Add(this.btnCopyResult);
            this.panelCenter.Controls.Add(this.txtResult);
            this.panelCenter.Controls.Add(this.progressBarFolder);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 33);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(660, 378);
            this.panelCenter.TabIndex = 3;
            // 
            // cbProcessOpen
            // 
            this.cbProcessOpen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProcessOpen.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cbProcessOpen.Items.AddRange(new object[] {
            "Explorer",
            "Notepad++"});
            this.cbProcessOpen.Location = new System.Drawing.Point(221, 343);
            this.cbProcessOpen.Name = "cbProcessOpen";
            this.cbProcessOpen.Size = new System.Drawing.Size(272, 25);
            this.cbProcessOpen.TabIndex = 14;
            this.cbProcessOpen.Visible = false;
            // 
            // rbReadOpen
            // 
            this.rbReadOpen.AutoSize = true;
            this.rbReadOpen.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbReadOpen.Location = new System.Drawing.Point(117, 346);
            this.rbReadOpen.Name = "rbReadOpen";
            this.rbReadOpen.Size = new System.Drawing.Size(102, 21);
            this.rbReadOpen.TabIndex = 13;
            this.rbReadOpen.TabStop = true;
            this.rbReadOpen.Text = "Read/Open";
            this.rbReadOpen.UseVisualStyleBackColor = true;
            this.rbReadOpen.CheckedChanged += new System.EventHandler(this.rbReadOpen_CheckedChanged);
            // 
            // rbRead
            // 
            this.rbRead.AutoSize = true;
            this.rbRead.Checked = true;
            this.rbRead.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbRead.Location = new System.Drawing.Point(55, 346);
            this.rbRead.Name = "rbRead";
            this.rbRead.Size = new System.Drawing.Size(60, 21);
            this.rbRead.TabIndex = 12;
            this.rbRead.TabStop = true;
            this.rbRead.Text = "Read";
            this.rbRead.UseVisualStyleBackColor = true;
            this.rbRead.CheckedChanged += new System.EventHandler(this.rbRead_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label3.Location = new System.Drawing.Point(6, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mode";
            // 
            // gridViewFiles
            // 
            this.gridViewFiles.AllowUserToAddRows = false;
            this.gridViewFiles.AllowUserToDeleteRows = false;
            this.gridViewFiles.AllowUserToResizeRows = false;
            this.gridViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewFiles.CausesValidation = false;
            this.gridViewFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.folderName,
            this.type,
            this.name,
            this.pathFile,
            this.lastDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewFiles.EnableHeadersVisualStyles = false;
            this.gridViewFiles.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridViewFiles.Location = new System.Drawing.Point(9, 3);
            this.gridViewFiles.Name = "gridViewFiles";
            this.gridViewFiles.ReadOnly = true;
            this.gridViewFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridViewFiles.RowHeadersVisible = false;
            this.gridViewFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewFiles.Size = new System.Drawing.Size(642, 189);
            this.gridViewFiles.TabIndex = 10;
            this.gridViewFiles.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridViewFiles_CellMouseDoubleClick);
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
            // folderName
            // 
            this.folderName.DataPropertyName = "folderName";
            this.folderName.Frozen = true;
            this.folderName.HeaderText = "Folder";
            this.folderName.Name = "folderName";
            this.folderName.ReadOnly = true;
            this.folderName.Width = 99;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.Frozen = true;
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 88;
            // 
            // name
            // 
            this.name.DataPropertyName = "fileName";
            this.name.Frozen = true;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 330;
            // 
            // pathFile
            // 
            this.pathFile.DataPropertyName = "pathFile";
            this.pathFile.Frozen = true;
            this.pathFile.HeaderText = "";
            this.pathFile.Name = "pathFile";
            this.pathFile.ReadOnly = true;
            this.pathFile.Visible = false;
            // 
            // lastDate
            // 
            this.lastDate.DataPropertyName = "date";
            this.lastDate.Frozen = true;
            this.lastDate.HeaderText = "Date";
            this.lastDate.Name = "lastDate";
            this.lastDate.ReadOnly = true;
            this.lastDate.Width = 77;
            // 
            // btnClearResult
            // 
            this.btnClearResult.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnClearResult.Image = ((System.Drawing.Image)(resources.GetObject("btnClearResult.Image")));
            this.btnClearResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearResult.Location = new System.Drawing.Point(577, 344);
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
            this.btnCopyResult.Location = new System.Drawing.Point(498, 344);
            this.btnCopyResult.Name = "btnCopyResult";
            this.btnCopyResult.Size = new System.Drawing.Size(75, 25);
            this.btnCopyResult.TabIndex = 8;
            this.btnCopyResult.Text = "    Copy";
            this.btnCopyResult.UseVisualStyleBackColor = true;
            this.btnCopyResult.Click += new System.EventHandler(this.btnCopyResult_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(10, 225);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(640, 112);
            this.txtResult.TabIndex = 7;
            this.txtResult.Text = "";
            // 
            // SearchFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 411);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchFile";
            this.Text = "LinkFolder";
            this.Load += new System.EventHandler(this.SearchFile_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtPathFolder;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ProgressBar progressBarFolder;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Button btnReloadFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageListTree;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnSearchPG;
        private System.Windows.Forms.TextBox txtPGSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Button btnCopyResult;
        private System.Windows.Forms.DataGridView gridViewFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbProcessOpen;
        private System.Windows.Forms.RadioButton rbReadOpen;
        private System.Windows.Forms.RadioButton rbRead;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn folderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastDate;
    }
}