
namespace ToolWorking.Views
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelBotSide = new System.Windows.Forms.Panel();
            this.btnSearchFile = new System.Windows.Forms.Button();
            this.panelSide = new System.Windows.Forms.Panel();
            this.btnLinkFolder = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelLabel = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelTopDown = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.btnClose = new ToolWorking.Extension.RJButton();
            this.btnMini = new ToolWorking.Extension.RJButton();
            this.panelLeft.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panelLeft.Controls.Add(this.panelBotSide);
            this.panelLeft.Controls.Add(this.btnSearchFile);
            this.panelLeft.Controls.Add(this.panelSide);
            this.panelLeft.Controls.Add(this.btnLinkFolder);
            this.panelLeft.Controls.Add(this.panelLogo);
            this.panelLeft.Controls.Add(this.btnDatabase);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(140, 462);
            this.panelLeft.TabIndex = 0;
            // 
            // panelBotSide
            // 
            this.panelBotSide.BackColor = System.Drawing.SystemColors.Control;
            this.panelBotSide.Location = new System.Drawing.Point(0, 79);
            this.panelBotSide.Name = "panelBotSide";
            this.panelBotSide.Size = new System.Drawing.Size(140, 2);
            this.panelBotSide.TabIndex = 1;
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.FlatAppearance.BorderSize = 0;
            this.btnSearchFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchFile.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnSearchFile.ForeColor = System.Drawing.Color.White;
            this.btnSearchFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchFile.Image")));
            this.btnSearchFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchFile.Location = new System.Drawing.Point(10, 81);
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Size = new System.Drawing.Size(130, 42);
            this.btnSearchFile.TabIndex = 20;
            this.btnSearchFile.Text = "Search File";
            this.btnSearchFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchFile.UseVisualStyleBackColor = true;
            this.btnSearchFile.Click += new System.EventHandler(this.btnSearchFile_Click);
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.SystemColors.Control;
            this.panelSide.Location = new System.Drawing.Point(0, 38);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(10, 42);
            this.panelSide.TabIndex = 1;
            // 
            // btnLinkFolder
            // 
            this.btnLinkFolder.FlatAppearance.BorderSize = 0;
            this.btnLinkFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinkFolder.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnLinkFolder.ForeColor = System.Drawing.Color.White;
            this.btnLinkFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkFolder.Image")));
            this.btnLinkFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLinkFolder.Location = new System.Drawing.Point(10, 39);
            this.btnLinkFolder.Name = "btnLinkFolder";
            this.btnLinkFolder.Size = new System.Drawing.Size(130, 42);
            this.btnLinkFolder.TabIndex = 10;
            this.btnLinkFolder.Text = "Link Folder";
            this.btnLinkFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLinkFolder.UseVisualStyleBackColor = true;
            this.btnLinkFolder.Click += new System.EventHandler(this.btnLinkFolder_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(140, 39);
            this.panelLogo.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 30);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnDatabase
            // 
            this.btnDatabase.FlatAppearance.BorderSize = 0;
            this.btnDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabase.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnDatabase.ForeColor = System.Drawing.Color.White;
            this.btnDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnDatabase.Image")));
            this.btnDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatabase.Location = new System.Drawing.Point(5, 124);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(130, 42);
            this.btnDatabase.TabIndex = 21;
            this.btnDatabase.Text = "Database";
            this.btnDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDatabase.UseVisualStyleBackColor = true;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.DarkCyan;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(140, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(660, 9);
            this.panelTop.TabIndex = 1;
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // panelLabel
            // 
            this.panelLabel.Controls.Add(this.labelTitle);
            this.panelLabel.Controls.Add(this.panelTopDown);
            this.panelLabel.Controls.Add(this.btnClose);
            this.panelLabel.Controls.Add(this.btnMini);
            this.panelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabel.Location = new System.Drawing.Point(140, 9);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Size = new System.Drawing.Size(660, 37);
            this.panelLabel.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Lucida Console", 20F);
            this.labelTitle.Location = new System.Drawing.Point(6, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(172, 27);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "labelTitle";
            // 
            // panelTopDown
            // 
            this.panelTopDown.BackColor = System.Drawing.Color.DarkCyan;
            this.panelTopDown.Location = new System.Drawing.Point(0, 36);
            this.panelTopDown.Name = "panelTopDown";
            this.panelTopDown.Size = new System.Drawing.Size(660, 1);
            this.panelTopDown.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(140, 453);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(660, 9);
            this.panelBottom.TabIndex = 4;
            // 
            // panelCenter
            // 
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(140, 46);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(660, 407);
            this.panelCenter.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundColor = System.Drawing.Color.White;
            this.btnClose.BorderColor = System.Drawing.Color.White;
            this.btnClose.BorderRadius = 18;
            this.btnClose.BorderSize = 0;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(620, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMini
            // 
            this.btnMini.BackColor = System.Drawing.Color.White;
            this.btnMini.BackgroundColor = System.Drawing.Color.White;
            this.btnMini.BorderColor = System.Drawing.Color.White;
            this.btnMini.BorderRadius = 18;
            this.btnMini.BorderSize = 0;
            this.btnMini.FlatAppearance.BorderSize = 0;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.ForeColor = System.Drawing.Color.White;
            this.btnMini.Image = ((System.Drawing.Image)(resources.GetObject("btnMini.Image")));
            this.btnMini.Location = new System.Drawing.Point(582, 1);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(35, 32);
            this.btnMini.TabIndex = 1;
            this.btnMini.TextColor = System.Drawing.Color.White;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelLabel);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelTop;
        private Extension.RJButton btnClose;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnLinkFolder;
        private Extension.RJButton btnMini;
        private System.Windows.Forms.Panel panelLabel;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelTopDown;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnSearchFile;
        private System.Windows.Forms.Panel panelBotSide;
        private System.Windows.Forms.Button btnDatabase;
    }
}