﻿
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
            this.btnOpenPathBk = new System.Windows.Forms.Button();
            this.txtPathBk = new System.Windows.Forms.TextBox();
            this.btnOpenPath = new System.Windows.Forms.Button();
            this.rbModePath = new System.Windows.Forms.RadioButton();
            this.rbModeTree = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSearchPG = new System.Windows.Forms.Button();
            this.txtPGSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnReloadFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtPathFolder = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.progressBarFolder = new System.Windows.Forms.ProgressBar();
            this.treeViewFolder = new System.Windows.Forms.TreeView();
            this.imageListTree = new System.Windows.Forms.ImageList(this.components);
            this.panelCenterTreeFolder = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.btnCopyResult = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelCenterPath = new System.Windows.Forms.Panel();
            this.lblNumCount = new System.Windows.Forms.Label();
            this.lblNumBefore = new System.Windows.Forms.Label();
            this.lblNumAfter = new System.Windows.Forms.Label();
            this.txtResultPathFile = new System.Windows.Forms.RichTextBox();
            this.txtListFile = new System.Windows.Forms.RichTextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCount = new System.Windows.Forms.Button();
            this.rbCopyBackup = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.rbCopy = new System.Windows.Forms.RadioButton();
            this.lblAction = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelCenterTreeFolder.SuspendLayout();
            this.panelCenterPath.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnOpenPathBk);
            this.panelTop.Controls.Add(this.txtPathBk);
            this.panelTop.Controls.Add(this.btnOpenPath);
            this.panelTop.Controls.Add(this.rbModePath);
            this.panelTop.Controls.Add(this.rbModeTree);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.txtPath);
            this.panelTop.Controls.Add(this.btnSearchPG);
            this.panelTop.Controls.Add(this.txtPGSearch);
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Controls.Add(this.btnReloadFolder);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnOpenFolder);
            this.panelTop.Controls.Add(this.txtPathFolder);
            this.panelTop.Controls.Add(this.lblPath);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(660, 68);
            this.panelTop.TabIndex = 0;
            // 
            // btnOpenPathBk
            // 
            this.btnOpenPathBk.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenPathBk.Image")));
            this.btnOpenPathBk.Location = new System.Drawing.Point(265, 39);
            this.btnOpenPathBk.Name = "btnOpenPathBk";
            this.btnOpenPathBk.Size = new System.Drawing.Size(26, 26);
            this.btnOpenPathBk.TabIndex = 18;
            this.btnOpenPathBk.UseVisualStyleBackColor = true;
            this.btnOpenPathBk.Click += new System.EventHandler(this.btnOpenPathBk_Click);
            // 
            // txtPathBk
            // 
            this.txtPathBk.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPathBk.Location = new System.Drawing.Point(109, 39);
            this.txtPathBk.Name = "txtPathBk";
            this.txtPathBk.Size = new System.Drawing.Size(150, 24);
            this.txtPathBk.TabIndex = 17;
            this.txtPathBk.Click += new System.EventHandler(this.txtPathBk_Click);
            this.txtPathBk.TextChanged += new System.EventHandler(this.txtPathBk_TextChanged);
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenPath.Image")));
            this.btnOpenPath.Location = new System.Drawing.Point(596, 39);
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(26, 26);
            this.btnOpenPath.TabIndex = 16;
            this.btnOpenPath.UseVisualStyleBackColor = true;
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // rbModePath
            // 
            this.rbModePath.AutoSize = true;
            this.rbModePath.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbModePath.Location = new System.Drawing.Point(189, 8);
            this.rbModePath.Name = "rbModePath";
            this.rbModePath.Size = new System.Drawing.Size(95, 21);
            this.rbModePath.TabIndex = 15;
            this.rbModePath.TabStop = true;
            this.rbModePath.Text = "In Path File";
            this.rbModePath.UseVisualStyleBackColor = true;
            this.rbModePath.CheckedChanged += new System.EventHandler(this.rbModePath_CheckedChanged);
            // 
            // rbModeTree
            // 
            this.rbModeTree.AutoSize = true;
            this.rbModeTree.Checked = true;
            this.rbModeTree.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbModeTree.Location = new System.Drawing.Point(80, 8);
            this.rbModeTree.Name = "rbModeTree";
            this.rbModeTree.Size = new System.Drawing.Size(109, 21);
            this.rbModeTree.TabIndex = 14;
            this.rbModeTree.TabStop = true;
            this.rbModeTree.Text = "In Tree Folder";
            this.rbModeTree.UseVisualStyleBackColor = true;
            this.rbModeTree.CheckedChanged += new System.EventHandler(this.rbModeTree_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label4.Location = new System.Drawing.Point(6, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mode";
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPath.Location = new System.Drawing.Point(420, 39);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(170, 24);
            this.txtPath.TabIndex = 5;
            this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
            this.txtPath.TextChanged += new System.EventHandler(this.txtPathRemove_TextChanged);
            // 
            // btnSearchPG
            // 
            this.btnSearchPG.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPG.Image")));
            this.btnSearchPG.Location = new System.Drawing.Point(264, 39);
            this.btnSearchPG.Name = "btnSearchPG";
            this.btnSearchPG.Size = new System.Drawing.Size(26, 26);
            this.btnSearchPG.TabIndex = 4;
            this.btnSearchPG.UseVisualStyleBackColor = true;
            this.btnSearchPG.Click += new System.EventHandler(this.btnSearchPG_Click);
            // 
            // txtPGSearch
            // 
            this.txtPGSearch.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPGSearch.Location = new System.Drawing.Point(109, 39);
            this.txtPGSearch.Name = "txtPGSearch";
            this.txtPGSearch.Size = new System.Drawing.Size(150, 24);
            this.txtPGSearch.TabIndex = 3;
            this.txtPGSearch.Click += new System.EventHandler(this.txtPGSearch_Click);
            this.txtPGSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPGSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblSearch.Location = new System.Drawing.Point(6, 42);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(100, 17);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Project Search";
            // 
            // btnReloadFolder
            // 
            this.btnReloadFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadFolder.Image")));
            this.btnReloadFolder.Location = new System.Drawing.Point(626, 6);
            this.btnReloadFolder.Name = "btnReloadFolder";
            this.btnReloadFolder.Size = new System.Drawing.Size(26, 26);
            this.btnReloadFolder.TabIndex = 2;
            this.btnReloadFolder.UseVisualStyleBackColor = true;
            this.btnReloadFolder.Click += new System.EventHandler(this.btnReloadFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label1.Location = new System.Drawing.Point(296, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source Folder";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFolder.Image")));
            this.btnOpenFolder.Location = new System.Drawing.Point(596, 6);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(26, 26);
            this.btnOpenFolder.TabIndex = 1;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // txtPathFolder
            // 
            this.txtPathFolder.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPathFolder.Location = new System.Drawing.Point(420, 6);
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.Size = new System.Drawing.Size(170, 24);
            this.txtPathFolder.TabIndex = 0;
            this.txtPathFolder.Click += new System.EventHandler(this.txtPathFolder_Click);
            this.txtPathFolder.TextChanged += new System.EventHandler(this.txtPathFolder_TextChanged);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(296, 42);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(105, 17);
            this.lblPath.TabIndex = 8;
            this.lblPath.Text = "Remove Folder";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBarFolder
            // 
            this.progressBarFolder.Location = new System.Drawing.Point(9, 193);
            this.progressBarFolder.Name = "progressBarFolder";
            this.progressBarFolder.Size = new System.Drawing.Size(642, 23);
            this.progressBarFolder.TabIndex = 1;
            // 
            // treeViewFolder
            // 
            this.treeViewFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewFolder.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.treeViewFolder.ImageIndex = 0;
            this.treeViewFolder.ImageList = this.imageListTree;
            this.treeViewFolder.Location = new System.Drawing.Point(9, 4);
            this.treeViewFolder.Name = "treeViewFolder";
            this.treeViewFolder.SelectedImageIndex = 0;
            this.treeViewFolder.Size = new System.Drawing.Size(642, 183);
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
            // panelCenterTreeFolder
            // 
            this.panelCenterTreeFolder.Controls.Add(this.txtResult);
            this.panelCenterTreeFolder.Controls.Add(this.treeViewFolder);
            this.panelCenterTreeFolder.Controls.Add(this.progressBarFolder);
            this.panelCenterTreeFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterTreeFolder.Location = new System.Drawing.Point(0, 68);
            this.panelCenterTreeFolder.Name = "panelCenterTreeFolder";
            this.panelCenterTreeFolder.Size = new System.Drawing.Size(660, 377);
            this.panelCenterTreeFolder.TabIndex = 3;
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtResult.Location = new System.Drawing.Point(9, 222);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(642, 111);
            this.txtResult.TabIndex = 7;
            this.txtResult.Text = "";
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
            // btnCopyResult
            // 
            this.btnCopyResult.Enabled = false;
            this.btnCopyResult.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnCopyResult.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyResult.Image")));
            this.btnCopyResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyResult.Location = new System.Drawing.Point(498, 0);
            this.btnCopyResult.Name = "btnCopyResult";
            this.btnCopyResult.Size = new System.Drawing.Size(75, 27);
            this.btnCopyResult.TabIndex = 8;
            this.btnCopyResult.Text = "    Copy";
            this.btnCopyResult.UseVisualStyleBackColor = true;
            this.btnCopyResult.Click += new System.EventHandler(this.btnCopyResult_Click);
            // 
            // panelCenterPath
            // 
            this.panelCenterPath.Controls.Add(this.lblNumCount);
            this.panelCenterPath.Controls.Add(this.lblNumBefore);
            this.panelCenterPath.Controls.Add(this.lblNumAfter);
            this.panelCenterPath.Controls.Add(this.txtResultPathFile);
            this.panelCenterPath.Controls.Add(this.txtListFile);
            this.panelCenterPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterPath.Location = new System.Drawing.Point(0, 68);
            this.panelCenterPath.Name = "panelCenterPath";
            this.panelCenterPath.Size = new System.Drawing.Size(660, 345);
            this.panelCenterPath.TabIndex = 10;
            // 
            // lblNumCount
            // 
            this.lblNumCount.AutoSize = true;
            this.lblNumCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumCount.Location = new System.Drawing.Point(467, 198);
            this.lblNumCount.Name = "lblNumCount";
            this.lblNumCount.Size = new System.Drawing.Size(150, 15);
            this.lblNumCount.TabIndex = 25;
            this.lblNumCount.Text = "Total file in folder Backup: ";
            this.lblNumCount.Visible = false;
            // 
            // lblNumBefore
            // 
            this.lblNumBefore.AutoSize = true;
            this.lblNumBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumBefore.Location = new System.Drawing.Point(13, 198);
            this.lblNumBefore.Name = "lblNumBefore";
            this.lblNumBefore.Size = new System.Drawing.Size(148, 15);
            this.lblNumBefore.TabIndex = 24;
            this.lblNumBefore.Text = "Line number before input:";
            this.lblNumBefore.Visible = false;
            // 
            // lblNumAfter
            // 
            this.lblNumAfter.AutoSize = true;
            this.lblNumAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumAfter.Location = new System.Drawing.Point(217, 198);
            this.lblNumAfter.Name = "lblNumAfter";
            this.lblNumAfter.Size = new System.Drawing.Size(154, 15);
            this.lblNumAfter.TabIndex = 23;
            this.lblNumAfter.Text = "Line number after change: ";
            this.lblNumAfter.Visible = false;
            // 
            // txtResultPathFile
            // 
            this.txtResultPathFile.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtResultPathFile.Location = new System.Drawing.Point(9, 222);
            this.txtResultPathFile.Name = "txtResultPathFile";
            this.txtResultPathFile.ReadOnly = true;
            this.txtResultPathFile.Size = new System.Drawing.Size(642, 111);
            this.txtResultPathFile.TabIndex = 22;
            this.txtResultPathFile.Text = "";
            // 
            // txtListFile
            // 
            this.txtListFile.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtListFile.Location = new System.Drawing.Point(9, 4);
            this.txtListFile.Name = "txtListFile";
            this.txtListFile.Size = new System.Drawing.Size(642, 185);
            this.txtListFile.TabIndex = 21;
            this.txtListFile.Text = "";
            this.txtListFile.Click += new System.EventHandler(this.txtListFile_Click);
            this.txtListFile.TextChanged += new System.EventHandler(this.txtListFile_TextChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCount);
            this.panelBottom.Controls.Add(this.rbCopyBackup);
            this.panelBottom.Controls.Add(this.rbDelete);
            this.panelBottom.Controls.Add(this.btnCopyResult);
            this.panelBottom.Controls.Add(this.rbCopy);
            this.panelBottom.Controls.Add(this.lblAction);
            this.panelBottom.Controls.Add(this.btnClearResult);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 413);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(660, 32);
            this.panelBottom.TabIndex = 11;
            // 
            // btnCount
            // 
            this.btnCount.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnCount.Image = ((System.Drawing.Image)(resources.GetObject("btnCount.Image")));
            this.btnCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCount.Location = new System.Drawing.Point(419, 0);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(75, 27);
            this.btnCount.TabIndex = 21;
            this.btnCount.Text = "    Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Visible = false;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // rbCopyBackup
            // 
            this.rbCopyBackup.AutoSize = true;
            this.rbCopyBackup.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbCopyBackup.Location = new System.Drawing.Point(231, 3);
            this.rbCopyBackup.Name = "rbCopyBackup";
            this.rbCopyBackup.Size = new System.Drawing.Size(113, 21);
            this.rbCopyBackup.TabIndex = 20;
            this.rbCopyBackup.Text = "Copy Backup";
            this.rbCopyBackup.UseVisualStyleBackColor = true;
            this.rbCopyBackup.Visible = false;
            this.rbCopyBackup.CheckedChanged += new System.EventHandler(this.rbCopyBackup_CheckedChanged);
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbDelete.Location = new System.Drawing.Point(348, 3);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(68, 21);
            this.rbDelete.TabIndex = 19;
            this.rbDelete.Text = "Delete";
            this.rbDelete.UseVisualStyleBackColor = true;
            this.rbDelete.Visible = false;
            this.rbDelete.CheckedChanged += new System.EventHandler(this.rbDelete_CheckedChanged);
            // 
            // rbCopy
            // 
            this.rbCopy.AutoSize = true;
            this.rbCopy.Checked = true;
            this.rbCopy.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.rbCopy.Location = new System.Drawing.Point(118, 3);
            this.rbCopy.Name = "rbCopy";
            this.rbCopy.Size = new System.Drawing.Size(108, 21);
            this.rbCopy.TabIndex = 18;
            this.rbCopy.TabStop = true;
            this.rbCopy.Text = "Copy Source";
            this.rbCopy.UseVisualStyleBackColor = true;
            this.rbCopy.Visible = false;
            this.rbCopy.CheckedChanged += new System.EventHandler(this.rbCopy_CheckedChanged);
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblAction.Location = new System.Drawing.Point(6, 5);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(104, 17);
            this.lblAction.TabIndex = 17;
            this.lblAction.Text = "Choose Action";
            this.lblAction.Visible = false;
            // 
            // LinkFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 445);
            this.Controls.Add(this.panelCenterPath);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelCenterTreeFolder);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LinkFolder";
            this.Text = "LinkFolder";
            this.Load += new System.EventHandler(this.LinkFolder_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenterTreeFolder.ResumeLayout(false);
            this.panelCenterPath.ResumeLayout(false);
            this.panelCenterPath.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtPathFolder;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ProgressBar progressBarFolder;
        private System.Windows.Forms.TreeView treeViewFolder;
        private System.Windows.Forms.Panel panelCenterTreeFolder;
        private System.Windows.Forms.Button btnReloadFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ImageList imageListTree;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnSearchPG;
        private System.Windows.Forms.TextBox txtPGSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Button btnCopyResult;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbModePath;
        private System.Windows.Forms.RadioButton rbModeTree;
        private System.Windows.Forms.Panel panelCenterPath;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.RichTextBox txtListFile;
        private System.Windows.Forms.RichTextBox txtResultPathFile;
        private System.Windows.Forms.Button btnOpenPath;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.RadioButton rbCopy;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblNumAfter;
        private System.Windows.Forms.Label lblNumBefore;
        private System.Windows.Forms.Button btnOpenPathBk;
        private System.Windows.Forms.TextBox txtPathBk;
        private System.Windows.Forms.RadioButton rbCopyBackup;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Label lblNumCount;
    }
}