
namespace ToolWorking.Views
{
    partial class CreateFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateFile));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.cbFileType = new System.Windows.Forms.ComboBox();
            this.lblPathFolder = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtPathFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCenterQuery = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSetting = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridInputValue = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.txtNumRow = new System.Windows.Forms.TextBox();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblNumRows = new System.Windows.Forms.Label();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcludeChars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbDelimiter = new System.Windows.Forms.ComboBox();
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelCenterQuery.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInputValue)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.cbFileType);
            this.panelTop.Controls.Add(this.lblPathFolder);
            this.panelTop.Controls.Add(this.btnOpenFolder);
            this.panelTop.Controls.Add(this.txtPathFolder);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.txtFileName);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(660, 34);
            this.panelTop.TabIndex = 1;
            // 
            // cbFileType
            // 
            this.cbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFileType.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cbFileType.Items.AddRange(new object[] {
            "CSV",
            "Json"});
            this.cbFileType.Location = new System.Drawing.Point(383, 6);
            this.cbFileType.Name = "cbFileType";
            this.cbFileType.Size = new System.Drawing.Size(60, 25);
            this.cbFileType.TabIndex = 22;
            this.cbFileType.SelectedIndexChanged += new System.EventHandler(this.cbFileType_SelectedIndexChanged);
            // 
            // lblPathFolder
            // 
            this.lblPathFolder.AutoSize = true;
            this.lblPathFolder.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblPathFolder.Location = new System.Drawing.Point(6, 11);
            this.lblPathFolder.Name = "lblPathFolder";
            this.lblPathFolder.Size = new System.Drawing.Size(107, 17);
            this.lblPathFolder.TabIndex = 17;
            this.lblPathFolder.Text = "Select Directory";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFolder.Image")));
            this.btnOpenFolder.Location = new System.Drawing.Point(291, 6);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(26, 26);
            this.btnOpenFolder.TabIndex = 15;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // txtPathFolder
            // 
            this.txtPathFolder.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPathFolder.Location = new System.Drawing.Point(113, 6);
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.Size = new System.Drawing.Size(175, 24);
            this.txtPathFolder.TabIndex = 14;
            this.txtPathFolder.TextChanged += new System.EventHandler(this.txtPathFolder_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label2.Location = new System.Drawing.Point(449, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "File Name";
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtFileName.Location = new System.Drawing.Point(521, 6);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(132, 24);
            this.txtFileName.TabIndex = 3;
            this.txtFileName.Leave += new System.EventHandler(this.txtFileName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label1.Location = new System.Drawing.Point(322, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "File Type";
            // 
            // panelCenterQuery
            // 
            this.panelCenterQuery.BackColor = System.Drawing.SystemColors.Control;
            this.panelCenterQuery.Controls.Add(this.groupBox1);
            this.panelCenterQuery.Controls.Add(this.groupBox2);
            this.panelCenterQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCenterQuery.Location = new System.Drawing.Point(0, 34);
            this.panelCenterQuery.Name = "panelCenterQuery";
            this.panelCenterQuery.Size = new System.Drawing.Size(660, 377);
            this.panelCenterQuery.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSetting);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(9, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 149);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Setting";
            // 
            // txtSetting
            // 
            this.txtSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSetting.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetting.Location = new System.Drawing.Point(3, 19);
            this.txtSetting.Name = "txtSetting";
            this.txtSetting.Size = new System.Drawing.Size(636, 127);
            this.txtSetting.TabIndex = 20;
            this.txtSetting.Text = "";
            this.txtSetting.TextChanged += new System.EventHandler(this.txtSetting_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridInputValue);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(9, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 219);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Value ";
            // 
            // gridInputValue
            // 
            this.gridInputValue.AllowUserToAddRows = false;
            this.gridInputValue.AllowUserToDeleteRows = false;
            this.gridInputValue.AllowUserToResizeRows = false;
            this.gridInputValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInputValue.CausesValidation = false;
            this.gridInputValue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInputValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridInputValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInputValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.name,
            this.type,
            this.value,
            this.Range,
            this.ExcludeChars});
            this.gridInputValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInputValue.EnableHeadersVisualStyles = false;
            this.gridInputValue.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridInputValue.Location = new System.Drawing.Point(3, 19);
            this.gridInputValue.Name = "gridInputValue";
            this.gridInputValue.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInputValue.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridInputValue.RowHeadersVisible = false;
            this.gridInputValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridInputValue.Size = new System.Drawing.Size(636, 197);
            this.gridInputValue.TabIndex = 11;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.cbDelimiter);
            this.panelBottom.Controls.Add(this.lblDelimiter);
            this.panelBottom.Controls.Add(this.txtNumRow);
            this.panelBottom.Controls.Add(this.btnClearResult);
            this.panelBottom.Controls.Add(this.btnCreate);
            this.panelBottom.Controls.Add(this.lblNumRows);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 413);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(660, 32);
            this.panelBottom.TabIndex = 11;
            // 
            // txtNumRow
            // 
            this.txtNumRow.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtNumRow.Location = new System.Drawing.Point(83, 1);
            this.txtNumRow.MaxLength = 9;
            this.txtNumRow.Name = "txtNumRow";
            this.txtNumRow.Size = new System.Drawing.Size(94, 23);
            this.txtNumRow.TabIndex = 23;
            this.txtNumRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumRow_KeyPress);
            // 
            // btnClearResult
            // 
            this.btnClearResult.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnClearResult.Image = ((System.Drawing.Image)(resources.GetObject("btnClearResult.Image")));
            this.btnClearResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearResult.Location = new System.Drawing.Point(577, 0);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(75, 27);
            this.btnClearResult.TabIndex = 9;
            this.btnClearResult.Text = "    Clear";
            this.btnClearResult.UseVisualStyleBackColor = true;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(493, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(80, 27);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "    Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblNumRows
            // 
            this.lblNumRows.AutoSize = true;
            this.lblNumRows.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblNumRows.Location = new System.Drawing.Point(6, 4);
            this.lblNumRows.Name = "lblNumRows";
            this.lblNumRows.Size = new System.Drawing.Size(77, 17);
            this.lblNumRows.TabIndex = 24;
            this.lblNumRows.Text = "Num Rows";
            // 
            // no
            // 
            this.no.DataPropertyName = "No";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.no.DefaultCellStyle = dataGridViewCellStyle8;
            this.no.Frozen = true;
            this.no.HeaderText = "No.";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.no.Width = 30;
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            this.name.Frozen = true;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // type
            // 
            this.type.DataPropertyName = "Type";
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.type.Width = 90;
            // 
            // value
            // 
            this.value.DataPropertyName = "Value";
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            this.value.Width = 348;
            // 
            // Range
            // 
            this.Range.DataPropertyName = "Range";
            this.Range.HeaderText = "Range";
            this.Range.Name = "Range";
            this.Range.Visible = false;
            // 
            // ExcludeChars
            // 
            this.ExcludeChars.DataPropertyName = "ExcludeChars";
            this.ExcludeChars.HeaderText = "ExcludeChars";
            this.ExcludeChars.Name = "ExcludeChars";
            this.ExcludeChars.Visible = false;
            // 
            // cbDelimiter
            // 
            this.cbDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelimiter.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cbDelimiter.Items.AddRange(new object[] {
            "Tab",
            "Comma",
            "Semicolon"});
            this.cbDelimiter.Location = new System.Drawing.Point(250, 1);
            this.cbDelimiter.Name = "cbDelimiter";
            this.cbDelimiter.Size = new System.Drawing.Size(90, 25);
            this.cbDelimiter.TabIndex = 26;
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblDelimiter.Location = new System.Drawing.Point(184, 4);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(65, 17);
            this.lblDelimiter.TabIndex = 25;
            this.lblDelimiter.Text = "Delimiter";
            // 
            // CreateFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 445);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelCenterQuery);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateFile";
            this.Text = "LinkFolder";
            this.Load += new System.EventHandler(this.CreateFile_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenterQuery.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInputValue)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ComboBox cbFileType;
        private System.Windows.Forms.Label lblPathFolder;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtPathFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCenterQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtSetting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridInputValue;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtNumRow;
        private System.Windows.Forms.Label lblNumRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExcludeChars;
        private System.Windows.Forms.ComboBox cbDelimiter;
        private System.Windows.Forms.Label lblDelimiter;
    }
}