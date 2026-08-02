namespace WorkBuddy.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelCenter = new Panel();
            panelBottom = new Panel();
            panelCenterRight = new Panel();
            panelCenterLeft = new Panel();
            btnJson = new Sunny.UI.UIButton();
            btnDatabase = new Sunny.UI.UIButton();
            btnSearch = new Sunny.UI.UIButton();
            btnSetting = new Sunny.UI.UIButton();
            uiButton4 = new Sunny.UI.UIButton();
            uiButton3 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton1 = new Sunny.UI.UIButton();
            panelRoundedTopCorners = new WorkBuddy.Extensions.InvertedCornerPanel();
            panelRoundedBotCorners = new WorkBuddy.Extensions.InvertedCornerPanel();
            lblVersion = new Sunny.UI.UILabel();
            panelCenterMain = new Panel();
            chillForm = new Sunny.UI.UIPanel();
            panelTop = new Panel();
            pctLogo = new PictureBox();
            btMinimize = new Sunny.UI.UIButton();
            btnClose = new Sunny.UI.UIButton();
            panelCenter.SuspendLayout();
            panelCenterLeft.SuspendLayout();
            panelCenterMain.SuspendLayout();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctLogo).BeginInit();
            SuspendLayout();
            // 
            // panelCenter
            // 
            panelCenter.BackColor = Color.FromArgb(32, 57, 133);
            panelCenter.Controls.Add(panelBottom);
            panelCenter.Controls.Add(panelCenterRight);
            panelCenter.Controls.Add(panelCenterLeft);
            panelCenter.Controls.Add(panelCenterMain);
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Location = new Point(0, 42);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(952, 613);
            panelCenter.TabIndex = 2;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(32, 57, 133);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(140, 601);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(800, 12);
            panelBottom.TabIndex = 3;
            // 
            // panelCenterRight
            // 
            panelCenterRight.BackColor = Color.FromArgb(32, 57, 133);
            panelCenterRight.Dock = DockStyle.Right;
            panelCenterRight.Location = new Point(940, 0);
            panelCenterRight.Name = "panelCenterRight";
            panelCenterRight.Size = new Size(12, 613);
            panelCenterRight.TabIndex = 1;
            // 
            // panelCenterLeft
            // 
            panelCenterLeft.BackColor = Color.FromArgb(32, 57, 133);
            panelCenterLeft.Controls.Add(btnJson);
            panelCenterLeft.Controls.Add(btnDatabase);
            panelCenterLeft.Controls.Add(btnSearch);
            panelCenterLeft.Controls.Add(btnSetting);
            panelCenterLeft.Controls.Add(uiButton4);
            panelCenterLeft.Controls.Add(uiButton3);
            panelCenterLeft.Controls.Add(uiButton2);
            panelCenterLeft.Controls.Add(uiButton1);
            panelCenterLeft.Controls.Add(panelRoundedTopCorners);
            panelCenterLeft.Controls.Add(panelRoundedBotCorners);
            panelCenterLeft.Controls.Add(lblVersion);
            panelCenterLeft.Dock = DockStyle.Left;
            panelCenterLeft.ForeColor = Color.Transparent;
            panelCenterLeft.Location = new Point(0, 0);
            panelCenterLeft.Name = "panelCenterLeft";
            panelCenterLeft.Size = new Size(140, 613);
            panelCenterLeft.TabIndex = 0;
            // 
            // btnJson
            // 
            btnJson.FillColor = Color.FromArgb(32, 57, 133);
            btnJson.FillColor2 = Color.FromArgb(32, 57, 133);
            btnJson.FillDisableColor = Color.White;
            btnJson.FillHoverColor = Color.White;
            btnJson.FillPressColor = Color.White;
            btnJson.FillSelectedColor = Color.White;
            btnJson.Font = new Font("Consolas", 12F);
            btnJson.ForeDisableColor = Color.Gray;
            btnJson.ForeHoverColor = Color.Black;
            btnJson.ForePressColor = Color.Gray;
            btnJson.Location = new Point(12, 170);
            btnJson.MinimumSize = new Size(1, 1);
            btnJson.Name = "btnJson";
            btnJson.Radius = 35;
            btnJson.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom;
            btnJson.RectColor = Color.FromArgb(32, 57, 133);
            btnJson.RectDisableColor = Color.White;
            btnJson.RectHoverColor = Color.White;
            btnJson.RectPressColor = Color.White;
            btnJson.RectSelectedColor = Color.White;
            btnJson.Size = new Size(130, 40);
            btnJson.TabIndex = 8;
            btnJson.Tag = "JSONForm";
            btnJson.Text = "JSON";
            btnJson.TipsFont = new Font("Consolas", 10F);
            btnJson.Click += MenuButton_Click;
            // 
            // btnDatabase
            // 
            btnDatabase.FillColor = Color.FromArgb(32, 57, 133);
            btnDatabase.FillColor2 = Color.FromArgb(32, 57, 133);
            btnDatabase.FillDisableColor = Color.White;
            btnDatabase.FillHoverColor = Color.White;
            btnDatabase.FillPressColor = Color.White;
            btnDatabase.FillSelectedColor = Color.White;
            btnDatabase.Font = new Font("Consolas", 12F);
            btnDatabase.ForeDisableColor = Color.Gray;
            btnDatabase.ForeHoverColor = Color.Black;
            btnDatabase.ForePressColor = Color.Gray;
            btnDatabase.Location = new Point(12, 100);
            btnDatabase.MinimumSize = new Size(1, 1);
            btnDatabase.Name = "btnDatabase";
            btnDatabase.Radius = 35;
            btnDatabase.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom;
            btnDatabase.RectColor = Color.FromArgb(32, 57, 133);
            btnDatabase.RectDisableColor = Color.White;
            btnDatabase.RectHoverColor = Color.White;
            btnDatabase.RectPressColor = Color.White;
            btnDatabase.RectSelectedColor = Color.White;
            btnDatabase.Size = new Size(130, 40);
            btnDatabase.TabIndex = 6;
            btnDatabase.Tag = "DatabaseForm";
            btnDatabase.Text = "Database";
            btnDatabase.TipsFont = new Font("Consolas", 10F);
            btnDatabase.Click += MenuButton_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImageLayout = ImageLayout.Center;
            btnSearch.FillColor = Color.White;
            btnSearch.FillColor2 = Color.White;
            btnSearch.FillDisableColor = Color.White;
            btnSearch.FillHoverColor = Color.White;
            btnSearch.FillPressColor = Color.White;
            btnSearch.FillSelectedColor = Color.White;
            btnSearch.Font = new Font("Consolas", 12F);
            btnSearch.ForeColor = Color.Black;
            btnSearch.ForeDisableColor = Color.Gray;
            btnSearch.ForeHoverColor = Color.Black;
            btnSearch.ForePressColor = Color.Gray;
            btnSearch.Location = new Point(12, 30);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Radius = 35;
            btnSearch.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom;
            btnSearch.RectColor = Color.White;
            btnSearch.RectDisableColor = Color.White;
            btnSearch.RectHoverColor = Color.White;
            btnSearch.RectPressColor = Color.White;
            btnSearch.RectSelectedColor = Color.White;
            btnSearch.Size = new Size(130, 40);
            btnSearch.TabIndex = 2;
            btnSearch.Tag = "SearchForm";
            btnSearch.Text = "Search";
            btnSearch.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnSearch.Click += MenuButton_Click;
            // 
            // btnSetting
            // 
            btnSetting.FillColor = Color.FromArgb(32, 57, 133);
            btnSetting.FillColor2 = Color.FromArgb(32, 57, 133);
            btnSetting.FillDisableColor = Color.White;
            btnSetting.FillHoverColor = Color.White;
            btnSetting.FillPressColor = Color.White;
            btnSetting.FillSelectedColor = Color.White;
            btnSetting.Font = new Font("Consolas", 12F);
            btnSetting.ForeDisableColor = Color.Gray;
            btnSetting.ForeHoverColor = Color.Black;
            btnSetting.ForePressColor = Color.Gray;
            btnSetting.Location = new Point(12, 520);
            btnSetting.MinimumSize = new Size(1, 1);
            btnSetting.Name = "btnSetting";
            btnSetting.Radius = 35;
            btnSetting.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom;
            btnSetting.RectColor = Color.FromArgb(32, 57, 133);
            btnSetting.RectDisableColor = Color.White;
            btnSetting.RectHoverColor = Color.White;
            btnSetting.RectPressColor = Color.White;
            btnSetting.RectSelectedColor = Color.White;
            btnSetting.Size = new Size(130, 40);
            btnSetting.TabIndex = 14;
            btnSetting.Tag = "SettingForm";
            btnSetting.Text = "Setting";
            btnSetting.TipsFont = new Font("Consolas", 10F);
            btnSetting.Click += MenuButton_Click;
            // 
            // uiButton4
            // 
            uiButton4.FillColor = Color.FromArgb(32, 57, 133);
            uiButton4.FillColor2 = Color.FromArgb(32, 57, 133);
            uiButton4.FillDisableColor = Color.White;
            uiButton4.FillHoverColor = Color.White;
            uiButton4.FillPressColor = Color.White;
            uiButton4.FillSelectedColor = Color.White;
            uiButton4.Font = new Font("Consolas", 12F);
            uiButton4.ForeDisableColor = Color.Gray;
            uiButton4.ForeHoverColor = Color.Black;
            uiButton4.ForePressColor = Color.Gray;
            uiButton4.Location = new Point(12, 450);
            uiButton4.MinimumSize = new Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.Radius = 35;
            uiButton4.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom;
            uiButton4.RectColor = Color.FromArgb(32, 57, 133);
            uiButton4.RectDisableColor = Color.White;
            uiButton4.RectHoverColor = Color.White;
            uiButton4.RectPressColor = Color.White;
            uiButton4.RectSelectedColor = Color.White;
            uiButton4.Size = new Size(130, 40);
            uiButton4.TabIndex = 12;
            uiButton4.Text = "Coming soon";
            uiButton4.TipsFont = new Font("Consolas", 10F);
            uiButton4.Visible = false;
            // 
            // uiButton3
            // 
            uiButton3.FillColor = Color.FromArgb(32, 57, 133);
            uiButton3.FillColor2 = Color.FromArgb(32, 57, 133);
            uiButton3.FillDisableColor = Color.White;
            uiButton3.FillHoverColor = Color.White;
            uiButton3.FillPressColor = Color.White;
            uiButton3.FillSelectedColor = Color.White;
            uiButton3.Font = new Font("Consolas", 12F);
            uiButton3.ForeDisableColor = Color.Gray;
            uiButton3.ForeHoverColor = Color.Black;
            uiButton3.ForePressColor = Color.Gray;
            uiButton3.Location = new Point(12, 380);
            uiButton3.MinimumSize = new Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Radius = 35;
            uiButton3.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom;
            uiButton3.RectColor = Color.FromArgb(32, 57, 133);
            uiButton3.RectDisableColor = Color.White;
            uiButton3.RectHoverColor = Color.White;
            uiButton3.RectPressColor = Color.White;
            uiButton3.RectSelectedColor = Color.White;
            uiButton3.Size = new Size(130, 40);
            uiButton3.TabIndex = 11;
            uiButton3.Text = "Coming soon";
            uiButton3.TipsFont = new Font("Consolas", 10F);
            uiButton3.Visible = false;
            // 
            // uiButton2
            // 
            uiButton2.FillColor = Color.FromArgb(32, 57, 133);
            uiButton2.FillColor2 = Color.FromArgb(32, 57, 133);
            uiButton2.FillDisableColor = Color.White;
            uiButton2.FillHoverColor = Color.White;
            uiButton2.FillPressColor = Color.White;
            uiButton2.FillSelectedColor = Color.White;
            uiButton2.Font = new Font("Consolas", 12F);
            uiButton2.ForeDisableColor = Color.Gray;
            uiButton2.ForeHoverColor = Color.Black;
            uiButton2.ForePressColor = Color.Gray;
            uiButton2.Location = new Point(12, 310);
            uiButton2.MinimumSize = new Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Radius = 35;
            uiButton2.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom;
            uiButton2.RectColor = Color.FromArgb(32, 57, 133);
            uiButton2.RectDisableColor = Color.White;
            uiButton2.RectHoverColor = Color.White;
            uiButton2.RectPressColor = Color.White;
            uiButton2.RectSelectedColor = Color.White;
            uiButton2.Size = new Size(130, 40);
            uiButton2.TabIndex = 10;
            uiButton2.Text = "Coming soon";
            uiButton2.TipsFont = new Font("Consolas", 10F);
            uiButton2.Visible = false;
            // 
            // uiButton1
            // 
            uiButton1.FillColor = Color.FromArgb(32, 57, 133);
            uiButton1.FillColor2 = Color.FromArgb(32, 57, 133);
            uiButton1.FillDisableColor = Color.White;
            uiButton1.FillHoverColor = Color.White;
            uiButton1.FillPressColor = Color.White;
            uiButton1.FillSelectedColor = Color.White;
            uiButton1.Font = new Font("Consolas", 12F);
            uiButton1.ForeDisableColor = Color.Gray;
            uiButton1.ForeHoverColor = Color.Black;
            uiButton1.ForePressColor = Color.Gray;
            uiButton1.Location = new Point(12, 240);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Radius = 35;
            uiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom;
            uiButton1.RectColor = Color.FromArgb(32, 57, 133);
            uiButton1.RectDisableColor = Color.White;
            uiButton1.RectHoverColor = Color.White;
            uiButton1.RectPressColor = Color.White;
            uiButton1.RectSelectedColor = Color.White;
            uiButton1.Size = new Size(130, 40);
            uiButton1.TabIndex = 9;
            uiButton1.Text = "Coming soon";
            uiButton1.TipsFont = new Font("Consolas", 10F);
            uiButton1.Visible = false;
            // 
            // panelRoundedTopCorners
            // 
            panelRoundedTopCorners.BackColor = Color.White;
            panelRoundedTopCorners.BackgroundColor = Color.White;
            panelRoundedTopCorners.BorderColor = Color.White;
            panelRoundedTopCorners.BorderSize = 0;
            panelRoundedTopCorners.BottomLeftStyle = Extensions.CornerStyle.Square;
            panelRoundedTopCorners.BottomRightStyle = Extensions.CornerStyle.Square;
            panelRoundedTopCorners.CornerRadius = 18;
            panelRoundedTopCorners.Location = new Point(120, 10);
            panelRoundedTopCorners.Name = "panelRoundedTopCorners";
            panelRoundedTopCorners.Size = new Size(24, 24);
            panelRoundedTopCorners.TabIndex = 0;
            panelRoundedTopCorners.TopLeftStyle = Extensions.CornerStyle.Inverted;
            panelRoundedTopCorners.TopRightStyle = Extensions.CornerStyle.Square;
            // 
            // panelRoundedBotCorners
            // 
            panelRoundedBotCorners.BackColor = Color.White;
            panelRoundedBotCorners.BackgroundColor = Color.White;
            panelRoundedBotCorners.BorderColor = Color.White;
            panelRoundedBotCorners.BorderSize = 0;
            panelRoundedBotCorners.BottomLeftStyle = Extensions.CornerStyle.Inverted;
            panelRoundedBotCorners.BottomRightStyle = Extensions.CornerStyle.Square;
            panelRoundedBotCorners.CornerRadius = 18;
            panelRoundedBotCorners.Location = new Point(120, 65);
            panelRoundedBotCorners.Name = "panelRoundedBotCorners";
            panelRoundedBotCorners.Size = new Size(24, 24);
            panelRoundedBotCorners.TabIndex = 15;
            panelRoundedBotCorners.TopLeftStyle = Extensions.CornerStyle.Square;
            panelRoundedBotCorners.TopRightStyle = Extensions.CornerStyle.Square;
            // 
            // lblVersion
            // 
            lblVersion.BackColor = Color.Transparent;
            lblVersion.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVersion.ForeColor = Color.White;
            lblVersion.Location = new Point(40, 574);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(140, 24);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "Version 1.1";
            // 
            // panelCenterMain
            // 
            panelCenterMain.BackColor = Color.FromArgb(32, 57, 133);
            panelCenterMain.Controls.Add(chillForm);
            panelCenterMain.ForeColor = Color.Transparent;
            panelCenterMain.Location = new Point(139, 0);
            panelCenterMain.Name = "panelCenterMain";
            panelCenterMain.Size = new Size(802, 602);
            panelCenterMain.TabIndex = 2;
            // 
            // chillForm
            // 
            chillForm.Dock = DockStyle.Fill;
            chillForm.Font = new Font("Microsoft Sans Serif", 12F);
            chillForm.Location = new Point(0, 0);
            chillForm.Margin = new Padding(4, 5, 4, 5);
            chillForm.MinimumSize = new Size(1, 1);
            chillForm.Name = "chillForm";
            chillForm.Radius = 25;
            chillForm.Size = new Size(802, 602);
            chillForm.TabIndex = 0;
            chillForm.Text = null;
            chillForm.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(32, 57, 133);
            panelTop.Controls.Add(pctLogo);
            panelTop.Controls.Add(btMinimize);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(952, 42);
            panelTop.TabIndex = 1;
            panelTop.MouseMove += panelTop_MouseMove;
            // 
            // pctLogo
            // 
            pctLogo.BackgroundImage = Properties.Resources.Image_Logo;
            pctLogo.BackgroundImageLayout = ImageLayout.Center;
            pctLogo.ErrorImage = null;
            pctLogo.Location = new Point(3, 1);
            pctLogo.Name = "pctLogo";
            pctLogo.Size = new Size(240, 42);
            pctLogo.TabIndex = 4;
            pctLogo.TabStop = false;
            pctLogo.MouseMove += pctLogo_MouseMove;
            // 
            // btMinimize
            // 
            btMinimize.BackColor = Color.Transparent;
            btMinimize.BackgroundImage = Properties.Resources.Icon_Minimize_Write;
            btMinimize.BackgroundImageLayout = ImageLayout.Center;
            btMinimize.FillColor = Color.Transparent;
            btMinimize.FillColor2 = Color.Transparent;
            btMinimize.FillDisableColor = Color.Transparent;
            btMinimize.FillHoverColor = Color.Transparent;
            btMinimize.FillPressColor = Color.Transparent;
            btMinimize.FillSelectedColor = Color.Transparent;
            btMinimize.Font = new Font("Microsoft Sans Serif", 12F);
            btMinimize.ForeColor = Color.Transparent;
            btMinimize.ForeDisableColor = Color.Transparent;
            btMinimize.ForeHoverColor = Color.Transparent;
            btMinimize.ForePressColor = Color.Transparent;
            btMinimize.ForeSelectedColor = Color.Transparent;
            btMinimize.LightColor = Color.Transparent;
            btMinimize.Location = new Point(873, 5);
            btMinimize.MinimumSize = new Size(1, 1);
            btMinimize.Name = "btMinimize";
            btMinimize.Radius = 12;
            btMinimize.RectColor = Color.Transparent;
            btMinimize.RectDisableColor = Color.Transparent;
            btMinimize.RectHoverColor = Color.Transparent;
            btMinimize.RectPressColor = Color.Transparent;
            btMinimize.RectSelectedColor = Color.Transparent;
            btMinimize.Size = new Size(32, 32);
            btMinimize.TabIndex = 3;
            btMinimize.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btMinimize.Click += btMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundImage = Properties.Resources.icon_Close_Write;
            btnClose.BackgroundImageLayout = ImageLayout.Center;
            btnClose.FillColor = Color.Transparent;
            btnClose.FillColor2 = Color.Transparent;
            btnClose.FillDisableColor = Color.Transparent;
            btnClose.FillHoverColor = Color.Transparent;
            btnClose.FillPressColor = Color.Transparent;
            btnClose.FillSelectedColor = Color.Transparent;
            btnClose.Font = new Font("Microsoft Sans Serif", 12F);
            btnClose.ForeColor = Color.Transparent;
            btnClose.ForeDisableColor = Color.Transparent;
            btnClose.ForeHoverColor = Color.Transparent;
            btnClose.ForePressColor = Color.Transparent;
            btnClose.ForeSelectedColor = Color.Transparent;
            btnClose.LightColor = Color.Transparent;
            btnClose.Location = new Point(909, 5);
            btnClose.MinimumSize = new Size(1, 1);
            btnClose.Name = "btnClose";
            btnClose.Radius = 12;
            btnClose.RectColor = Color.Transparent;
            btnClose.RectDisableColor = Color.Transparent;
            btnClose.RectHoverColor = Color.Transparent;
            btnClose.RectPressColor = Color.Transparent;
            btnClose.RectSelectedColor = Color.Transparent;
            btnClose.Size = new Size(32, 32);
            btnClose.TabIndex = 2;
            btnClose.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnClose.Click += btnClose_Click;
            // 
            // MainForm
            // 
            AllowShowTitle = false;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(952, 655);
            Controls.Add(panelCenter);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Padding = new Padding(0);
            ShowTitle = false;
            Text = "Main";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += MainForm_Load;
            panelCenter.ResumeLayout(false);
            panelCenterLeft.ResumeLayout(false);
            panelCenterMain.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pctLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelCenter;
        private Panel panelCenterLeft;
        private Panel panelTop;
        private Panel panelCenterRight;
        private Sunny.UI.UIButton btnSearch;
        private Sunny.UI.UIButton btnDatabase;
        private Sunny.UI.UIButton btnJson;
        private Sunny.UI.UIButton btnSetting;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton btnClose;
        private Sunny.UI.UIButton btMinimize;
        private PictureBox pctLogo;
        private Sunny.UI.UILabel lblVersion;
        private Panel panelCenterMain;
        private Panel panelBottom;
        private Extensions.InvertedCornerPanel panelRoundedTopCorners;
        private Extensions.InvertedCornerPanel panelRoundedBotCorners;
        private Sunny.UI.UIPanel chillForm;
    }
}