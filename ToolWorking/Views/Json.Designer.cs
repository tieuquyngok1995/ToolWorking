
using ToolWorking.Extension;

namespace ToolWorking.Views
{
    partial class Json
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Json));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCopyResult = new System.Windows.Forms.Button();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelCenterBot = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.panelCenterTop = new System.Windows.Forms.Panel();
            this.groupInputValue = new System.Windows.Forms.GroupBox();
            this.gridInputValue = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcludeChars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupInputKey = new System.Windows.Forms.GroupBox();
            this.txtInputKey = new System.Windows.Forms.RichTextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.txtIndent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.rbModeKeys = new System.Windows.Forms.RadioButton();
            this.rbModeJson = new System.Windows.Forms.RadioButton();
            this.rbOutput = new System.Windows.Forms.RadioButton();
            this.rbInput = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInputJsonFilter = new System.Windows.Forms.RichTextBox();
            this.panelCenter.SuspendLayout();
            this.panelCenterBot.SuspendLayout();
            this.panelCenterTop.SuspendLayout();
            this.groupInputValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInputValue)).BeginInit();
            this.groupInputKey.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
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
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelCenterBot);
            this.panelCenter.Controls.Add(this.panelCenterTop);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 63);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(660, 318);
            this.panelCenter.TabIndex = 14;
            // 
            // panelCenterBot
            // 
            this.panelCenterBot.Controls.Add(this.txtResult);
            this.panelCenterBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCenterBot.Location = new System.Drawing.Point(0, 220);
            this.panelCenterBot.Name = "panelCenterBot";
            this.panelCenterBot.Size = new System.Drawing.Size(660, 98);
            this.panelCenterBot.TabIndex = 24;
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(660, 98);
            this.txtResult.TabIndex = 22;
            this.txtResult.Text = "";
            // 
            // panelCenterTop
            // 
            this.panelCenterTop.Controls.Add(this.groupInputValue);
            this.panelCenterTop.Controls.Add(this.groupInputKey);
            this.panelCenterTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCenterTop.Location = new System.Drawing.Point(0, 0);
            this.panelCenterTop.Name = "panelCenterTop";
            this.panelCenterTop.Size = new System.Drawing.Size(660, 211);
            this.panelCenterTop.TabIndex = 23;
            // 
            // groupInputValue
            // 
            this.groupInputValue.Controls.Add(this.txtInputJsonFilter);
            this.groupInputValue.Controls.Add(this.gridInputValue);
            this.groupInputValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupInputValue.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupInputValue.Location = new System.Drawing.Point(206, 0);
            this.groupInputValue.Name = "groupInputValue";
            this.groupInputValue.Size = new System.Drawing.Size(454, 211);
            this.groupInputValue.TabIndex = 24;
            this.groupInputValue.TabStop = false;
            this.groupInputValue.Text = "Input Value";
            // 
            // gridInputValue
            // 
            this.gridInputValue.AllowUserToAddRows = false;
            this.gridInputValue.AllowUserToDeleteRows = false;
            this.gridInputValue.AllowUserToResizeRows = false;
            this.gridInputValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInputValue.CausesValidation = false;
            this.gridInputValue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInputValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInputValue.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridInputValue.RowHeadersVisible = false;
            this.gridInputValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridInputValue.Size = new System.Drawing.Size(448, 189);
            this.gridInputValue.TabIndex = 12;
            this.gridInputValue.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.gridInputValue_CellToolTipTextNeeded);
            this.gridInputValue.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridInputValue_DataBindingComplete);
            // 
            // no
            // 
            this.no.DataPropertyName = "No";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.no.DefaultCellStyle = dataGridViewCellStyle5;
            this.no.Frozen = true;
            this.no.HeaderText = "No";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Width = 25;
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
            this.type.Frozen = true;
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 65;
            // 
            // value
            // 
            this.value.DataPropertyName = "Value";
            this.value.Frozen = true;
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            this.value.Width = 190;
            // 
            // Range
            // 
            this.Range.DataPropertyName = "Range";
            this.Range.Frozen = true;
            this.Range.HeaderText = "Range";
            this.Range.Name = "Range";
            this.Range.Visible = false;
            // 
            // ExcludeChars
            // 
            this.ExcludeChars.DataPropertyName = "ExcludeChars";
            this.ExcludeChars.Frozen = true;
            this.ExcludeChars.HeaderText = "ExcludeChars";
            this.ExcludeChars.Name = "ExcludeChars";
            this.ExcludeChars.ReadOnly = true;
            this.ExcludeChars.Visible = false;
            // 
            // groupInputKey
            // 
            this.groupInputKey.Controls.Add(this.txtInputKey);
            this.groupInputKey.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupInputKey.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupInputKey.Location = new System.Drawing.Point(0, 0);
            this.groupInputKey.Name = "groupInputKey";
            this.groupInputKey.Size = new System.Drawing.Size(200, 211);
            this.groupInputKey.TabIndex = 23;
            this.groupInputKey.TabStop = false;
            this.groupInputKey.Text = "Input Keys";
            // 
            // txtInputKey
            // 
            this.txtInputKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputKey.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputKey.Location = new System.Drawing.Point(3, 19);
            this.txtInputKey.Name = "txtInputKey";
            this.txtInputKey.Size = new System.Drawing.Size(194, 189);
            this.txtInputKey.TabIndex = 22;
            this.txtInputKey.Text = "";
            this.txtInputKey.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtInputKey_MouseClick);
            this.txtInputKey.TextChanged += new System.EventHandler(this.txtInputKey_TextChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCreate);
            this.panelBottom.Controls.Add(this.btnCopyResult);
            this.panelBottom.Controls.Add(this.btnClearResult);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 381);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(660, 30);
            this.panelBottom.TabIndex = 15;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(415, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(80, 25);
            this.btnCreate.TabIndex = 21;
            this.btnCreate.Text = "    Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.txtIndent);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.panelInput);
            this.panelTop.Controls.Add(this.rbOutput);
            this.panelTop.Controls.Add(this.rbInput);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(660, 63);
            this.panelTop.TabIndex = 12;
            // 
            // txtIndent
            // 
            this.txtIndent.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtIndent.Location = new System.Drawing.Point(80, 36);
            this.txtIndent.Name = "txtIndent";
            this.txtIndent.Size = new System.Drawing.Size(117, 24);
            this.txtIndent.TabIndex = 18;
            this.txtIndent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtIndent_MouseClick);
            this.txtIndent.TextChanged += new System.EventHandler(this.txtIndent_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Indent";
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.rbModeKeys);
            this.panelInput.Controls.Add(this.rbModeJson);
            this.panelInput.Location = new System.Drawing.Point(213, 0);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(191, 27);
            this.panelInput.TabIndex = 16;
            // 
            // rbModeKeys
            // 
            this.rbModeKeys.AutoSize = true;
            this.rbModeKeys.Checked = true;
            this.rbModeKeys.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbModeKeys.Location = new System.Drawing.Point(0, 7);
            this.rbModeKeys.Name = "rbModeKeys";
            this.rbModeKeys.Size = new System.Drawing.Size(53, 21);
            this.rbModeKeys.TabIndex = 14;
            this.rbModeKeys.TabStop = true;
            this.rbModeKeys.Text = "Keys";
            this.rbModeKeys.UseVisualStyleBackColor = true;
            this.rbModeKeys.CheckedChanged += new System.EventHandler(this.rbModeKeys_CheckedChanged);
            // 
            // rbModeJson
            // 
            this.rbModeJson.AutoSize = true;
            this.rbModeJson.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbModeJson.Location = new System.Drawing.Point(55, 7);
            this.rbModeJson.Name = "rbModeJson";
            this.rbModeJson.Size = new System.Drawing.Size(107, 21);
            this.rbModeJson.TabIndex = 15;
            this.rbModeJson.Text = "JSON Object";
            this.rbModeJson.UseVisualStyleBackColor = true;
            this.rbModeJson.CheckedChanged += new System.EventHandler(this.rbModeJson_CheckedChanged);
            // 
            // rbOutput
            // 
            this.rbOutput.AutoSize = true;
            this.rbOutput.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbOutput.Location = new System.Drawing.Point(140, 7);
            this.rbOutput.Name = "rbOutput";
            this.rbOutput.Size = new System.Drawing.Size(72, 21);
            this.rbOutput.TabIndex = 2;
            this.rbOutput.Text = "Output";
            this.rbOutput.UseVisualStyleBackColor = true;
            this.rbOutput.CheckedChanged += new System.EventHandler(this.rbOutput_CheckedChanged);
            // 
            // rbInput
            // 
            this.rbInput.AutoSize = true;
            this.rbInput.Checked = true;
            this.rbInput.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbInput.Location = new System.Drawing.Point(80, 7);
            this.rbInput.Name = "rbInput";
            this.rbInput.Size = new System.Drawing.Size(59, 21);
            this.rbInput.TabIndex = 1;
            this.rbInput.TabStop = true;
            this.rbInput.Text = "Input";
            this.rbInput.UseVisualStyleBackColor = true;
            this.rbInput.CheckedChanged += new System.EventHandler(this.rbInput_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label4.Location = new System.Drawing.Point(6, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mode";
            // 
            // txtInputJsonFilter
            // 
            this.txtInputJsonFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputJsonFilter.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputJsonFilter.Location = new System.Drawing.Point(3, 19);
            this.txtInputJsonFilter.Name = "txtInputJsonFilter";
            this.txtInputJsonFilter.Size = new System.Drawing.Size(448, 189);
            this.txtInputJsonFilter.TabIndex = 23;
            this.txtInputJsonFilter.Text = "";
            this.txtInputJsonFilter.Visible = false;
            this.txtInputJsonFilter.TextChanged += new System.EventHandler(this.txtInputJsonFilter_TextChanged);
            // 
            // Json
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 411);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Json";
            this.Text = "LinkFolder";
            this.Load += new System.EventHandler(this.Json_Load);
            this.panelCenter.ResumeLayout(false);
            this.panelCenterBot.ResumeLayout(false);
            this.panelCenterTop.ResumeLayout(false);
            this.groupInputValue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInputValue)).EndInit();
            this.groupInputKey.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCopyResult;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.RadioButton rbModeJson;
        private System.Windows.Forms.RadioButton rbModeKeys;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelCenterTop;
        private System.Windows.Forms.Panel panelCenterBot;
        private System.Windows.Forms.RichTextBox txtInputKey;
        private System.Windows.Forms.GroupBox groupInputKey;
        private System.Windows.Forms.GroupBox groupInputValue;
        private System.Windows.Forms.RadioButton rbInput;
        private System.Windows.Forms.RadioButton rbOutput;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIndent;
        private System.Windows.Forms.DataGridView gridInputValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExcludeChars;
        private System.Windows.Forms.RichTextBox txtInputJsonFilter;
    }
}