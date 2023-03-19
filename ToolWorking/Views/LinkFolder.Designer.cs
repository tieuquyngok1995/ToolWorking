
namespace ToolWorking.Views
{
    partial class LinkFolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkFolder));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtPathFolder = new System.Windows.Forms.TextBox();
            this.progressBarFolder = new System.Windows.Forms.ProgressBar();
            this.treeViewFolder = new System.Windows.Forms.TreeView();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReloadFolder = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageListTree = new System.Windows.Forms.ImageList(this.components);
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchPG = new System.Windows.Forms.TextBox();
            this.btnSearchPG = new System.Windows.Forms.Button();
            this.btnCopyResult = new System.Windows.Forms.Button();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnSearchPG);
            this.panelTop.Controls.Add(this.txtSearchPG);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.btnReloadFolder);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnOpenFolder);
            this.panelTop.Controls.Add(this.txtPathFolder);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(660, 47);
            this.panelTop.TabIndex = 0;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFolder.Image")));
            this.btnOpenFolder.Location = new System.Drawing.Point(311, 9);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(26, 26);
            this.btnOpenFolder.TabIndex = 1;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // txtPathFolder
            // 
            this.txtPathFolder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathFolder.Location = new System.Drawing.Point(119, 9);
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.ReadOnly = true;
            this.txtPathFolder.Size = new System.Drawing.Size(188, 26);
            this.txtPathFolder.TabIndex = 0;
            // 
            // progressBarFolder
            // 
            this.progressBarFolder.Location = new System.Drawing.Point(12, 206);
            this.progressBarFolder.Name = "progressBarFolder";
            this.progressBarFolder.Size = new System.Drawing.Size(636, 23);
            this.progressBarFolder.TabIndex = 1;
            // 
            // treeViewFolder
            // 
            this.treeViewFolder.CheckBoxes = true;
            this.treeViewFolder.ImageIndex = 0;
            this.treeViewFolder.ImageList = this.imageListTree;
            this.treeViewFolder.Location = new System.Drawing.Point(12, 6);
            this.treeViewFolder.Name = "treeViewFolder";
            this.treeViewFolder.SelectedImageIndex = 0;
            this.treeViewFolder.Size = new System.Drawing.Size(636, 196);
            this.treeViewFolder.TabIndex = 2;
            this.treeViewFolder.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolder_AfterCheck);
            this.treeViewFolder.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewFolder_BeforeSelect);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.btnClearResult);
            this.panelCenter.Controls.Add(this.btnCopyResult);
            this.panelCenter.Controls.Add(this.txtResult);
            this.panelCenter.Controls.Add(this.treeViewFolder);
            this.panelCenter.Controls.Add(this.progressBarFolder);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 47);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(660, 398);
            this.panelCenter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Directory";
            // 
            // btnReloadFolder
            // 
            this.btnReloadFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadFolder.Image")));
            this.btnReloadFolder.Location = new System.Drawing.Point(343, 9);
            this.btnReloadFolder.Name = "btnReloadFolder";
            this.btnReloadFolder.Size = new System.Drawing.Size(26, 26);
            this.btnReloadFolder.TabIndex = 3;
            this.btnReloadFolder.UseVisualStyleBackColor = true;
            this.btnReloadFolder.Click += new System.EventHandler(this.btnReloadFolder_Click);
            // 
            // imageListTree
            // 
            this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
            this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTree.Images.SetKeyName(0, "icon-folder-16x16.png");
            this.imageListTree.Images.SetKeyName(1, "icon-file-16x16.png");
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 231);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(636, 128);
            this.txtResult.TabIndex = 3;
            this.txtResult.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(376, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search PG";
            // 
            // txtSearchPG
            // 
            this.txtSearchPG.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchPG.Location = new System.Drawing.Point(457, 9);
            this.txtSearchPG.Name = "txtSearchPG";
            this.txtSearchPG.Size = new System.Drawing.Size(161, 26);
            this.txtSearchPG.TabIndex = 5;
            // 
            // btnSearchPG
            // 
            this.btnSearchPG.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPG.Image")));
            this.btnSearchPG.Location = new System.Drawing.Point(623, 9);
            this.btnSearchPG.Name = "btnSearchPG";
            this.btnSearchPG.Size = new System.Drawing.Size(26, 26);
            this.btnSearchPG.TabIndex = 6;
            this.btnSearchPG.UseVisualStyleBackColor = true;
            this.btnSearchPG.Click += new System.EventHandler(this.btnSearchPG_Click);
            // 
            // btnCopyResult
            // 
            this.btnCopyResult.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyResult.Image")));
            this.btnCopyResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyResult.Location = new System.Drawing.Point(510, 360);
            this.btnCopyResult.Name = "btnCopyResult";
            this.btnCopyResult.Size = new System.Drawing.Size(66, 26);
            this.btnCopyResult.TabIndex = 7;
            this.btnCopyResult.Text = "    Copy";
            this.btnCopyResult.UseVisualStyleBackColor = true;
            this.btnCopyResult.Click += new System.EventHandler(this.btnCopyResult_Click);
            // 
            // btnClearResult
            // 
            this.btnClearResult.Image = ((System.Drawing.Image)(resources.GetObject("btnClearResult.Image")));
            this.btnClearResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearResult.Location = new System.Drawing.Point(582, 360);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(66, 26);
            this.btnClearResult.TabIndex = 8;
            this.btnClearResult.Text = "    Clear";
            this.btnClearResult.UseVisualStyleBackColor = true;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // LinkFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 445);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LinkFolder";
            this.Text = "LinkFolder";
            this.Load += new System.EventHandler(this.LinkFolder_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtPathFolder;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ProgressBar progressBarFolder;
        private System.Windows.Forms.TreeView treeViewFolder;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Button btnReloadFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageListTree;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnSearchPG;
        private System.Windows.Forms.TextBox txtSearchPG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Button btnCopyResult;
    }
}