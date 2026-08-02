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
            panelBottom = new Panel();
            panelCenter = new Panel();
            panelCenterMain = new Panel();
            panelCenterRight = new Panel();
            panelCenterLeft = new Panel();
            btnSetting = new Sunny.UI.UIButton();
            uiButton5 = new Sunny.UI.UIButton();
            uiButton4 = new Sunny.UI.UIButton();
            uiButton3 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton1 = new Sunny.UI.UIButton();
            btnDatabase = new Sunny.UI.UIButton();
            btnJson = new Sunny.UI.UIButton();
            btnSearch = new Sunny.UI.UIButton();
            btnBorderTop = new WorkBuddy.Extensions.InvertedCornerPanel();
            btnBorderBot = new WorkBuddy.Extensions.InvertedCornerPanel();
            panelTop = new Panel();
            pctLogo = new PictureBox();
            btMinimize = new Sunny.UI.UIButton();
            btnClose = new Sunny.UI.UIButton();
            panelCenter.SuspendLayout();
            panelCenterLeft.SuspendLayout();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctLogo).BeginInit();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(32, 57, 133);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 642);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(952, 12);
            panelBottom.TabIndex = 3;
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(panelCenterMain);
            panelCenter.Controls.Add(panelCenterRight);
            panelCenter.Controls.Add(panelCenterLeft);
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Location = new Point(0, 42);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(952, 612);
            panelCenter.TabIndex = 2;
            // 
            // panelCenterMain
            // 
            panelCenterMain.BackColor = Color.Transparent;
            panelCenterMain.Dock = DockStyle.Fill;
            panelCenterMain.Location = new Point(140, 0);
            panelCenterMain.Name = "panelCenterMain";
            panelCenterMain.Size = new Size(800, 612);
            panelCenterMain.TabIndex = 2;
            // 
            // panelCenterRight
            // 
            panelCenterRight.BackColor = Color.FromArgb(32, 57, 133);
            panelCenterRight.Dock = DockStyle.Right;
            panelCenterRight.Location = new Point(940, 0);
            panelCenterRight.Name = "panelCenterRight";
            panelCenterRight.Size = new Size(12, 612);
            panelCenterRight.TabIndex = 1;
            // 
            // panelCenterLeft
            // 
            panelCenterLeft.BackColor = Color.FromArgb(32, 57, 133);
            panelCenterLeft.Controls.Add(btnSetting);
            panelCenterLeft.Controls.Add(uiButton5);
            panelCenterLeft.Controls.Add(uiButton4);
            panelCenterLeft.Controls.Add(uiButton3);
            panelCenterLeft.Controls.Add(uiButton2);
            panelCenterLeft.Controls.Add(uiButton1);
            panelCenterLeft.Controls.Add(btnDatabase);
            panelCenterLeft.Controls.Add(btnJson);
            panelCenterLeft.Controls.Add(btnSearch);
            panelCenterLeft.Controls.Add(btnBorderTop);
            panelCenterLeft.Controls.Add(btnBorderBot);
            panelCenterLeft.Dock = DockStyle.Left;
            panelCenterLeft.Location = new Point(0, 0);
            panelCenterLeft.Name = "panelCenterLeft";
            panelCenterLeft.Size = new Size(140, 612);
            panelCenterLeft.TabIndex = 0;
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
            btnSetting.Location = new Point(12, 540);
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
            btnSetting.Text = "Setting";
            btnSetting.TipsFont = new Font("Consolas", 10F);
            btnSetting.Click += btnSetting_Click;
            // 
            // uiButton5
            // 
            uiButton5.FillColor = Color.FromArgb(32, 57, 133);
            uiButton5.FillColor2 = Color.FromArgb(32, 57, 133);
            uiButton5.FillDisableColor = Color.White;
            uiButton5.FillHoverColor = Color.White;
            uiButton5.FillPressColor = Color.White;
            uiButton5.FillSelectedColor = Color.White;
            uiButton5.Font = new Font("Consolas", 12F);
            uiButton5.ForeDisableColor = Color.Gray;
            uiButton5.ForeHoverColor = Color.Black;
            uiButton5.ForePressColor = Color.Gray;
            uiButton5.Location = new Point(12, 475);
            uiButton5.MinimumSize = new Size(1, 1);
            uiButton5.Name = "uiButton5";
            uiButton5.Radius = 35;
            uiButton5.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom;
            uiButton5.RectColor = Color.FromArgb(32, 57, 133);
            uiButton5.RectDisableColor = Color.White;
            uiButton5.RectHoverColor = Color.White;
            uiButton5.RectPressColor = Color.White;
            uiButton5.RectSelectedColor = Color.White;
            uiButton5.Size = new Size(130, 40);
            uiButton5.TabIndex = 13;
            uiButton5.Text = "Coming soon";
            uiButton5.TipsFont = new Font("Consolas", 10F);
            uiButton5.Visible = false;
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
            uiButton4.Location = new Point(12, 410);
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
            uiButton3.Location = new Point(12, 345);
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
            uiButton2.Location = new Point(12, 280);
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
            uiButton1.Location = new Point(12, 215);
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
            btnDatabase.Location = new Point(12, 85);
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
            btnDatabase.Text = "Database";
            btnDatabase.TipsFont = new Font("Consolas", 10F);
            btnDatabase.Click += btnDatabase_Click;
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
            btnJson.Location = new Point(12, 150);
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
            btnJson.Text = "JSON";
            btnJson.TipsFont = new Font("Consolas", 10F);
            btnJson.Click += btnJson_Click;
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
            btnSearch.Location = new Point(12, 20);
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
            btnSearch.Text = "Search";
            btnSearch.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnSearch.Click += btnSearch_Click;
            // 
            // btnBorderTop
            // 
            btnBorderTop.BackColor = Color.White;
            btnBorderTop.BackgroundColor = Color.White;
            btnBorderTop.BorderColor = Color.White;
            btnBorderTop.BorderSize = 0;
            btnBorderTop.BottomLeftStyle = Extensions.CornerStyle.Square;
            btnBorderTop.BottomRightStyle = Extensions.CornerStyle.Square;
            btnBorderTop.CornerRadius = 18;
            btnBorderTop.Location = new Point(120, 0);
            btnBorderTop.Name = "btnBorderTop";
            btnBorderTop.Size = new Size(24, 24);
            btnBorderTop.TabIndex = 0;
            btnBorderTop.TopLeftStyle = Extensions.CornerStyle.Inverted;
            btnBorderTop.TopRightStyle = Extensions.CornerStyle.Square;
            // 
            // btnBorderBot
            // 
            btnBorderBot.BackColor = Color.White;
            btnBorderBot.BackgroundColor = Color.White;
            btnBorderBot.BorderColor = Color.White;
            btnBorderBot.BorderSize = 0;
            btnBorderBot.BottomLeftStyle = Extensions.CornerStyle.Inverted;
            btnBorderBot.BottomRightStyle = Extensions.CornerStyle.Square;
            btnBorderBot.CornerRadius = 18;
            btnBorderBot.Location = new Point(120, 55);
            btnBorderBot.Name = "btnBorderBot";
            btnBorderBot.Size = new Size(24, 24);
            btnBorderBot.TabIndex = 1;
            btnBorderBot.TopLeftStyle = Extensions.CornerStyle.Square;
            btnBorderBot.TopRightStyle = Extensions.CornerStyle.Square;
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
            pctLogo.BackgroundImage = (Image)resources.GetObject("pctLogo.BackgroundImage");
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
            btMinimize.BackgroundImage = (Image)resources.GetObject("btMinimize.BackgroundImage");
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
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
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
            ClientSize = new Size(952, 654);
            Controls.Add(panelBottom);
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
            panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pctLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBottom;
        private Panel panelCenter;
        private Panel panelCenterLeft;
        private Panel panelTop;
        private Panel panelCenterRight;
        private Sunny.UI.UIButton btnSearch;
        private Sunny.UI.UIButton btnDatabase;
        private Extensions.InvertedCornerPanel btnBorderTop;
        private Sunny.UI.UIButton btnJson;
        private Sunny.UI.UIButton btnSetting;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton1;
        private Panel panelCenterMain;
        private Sunny.UI.UIButton btnClose;
        private Sunny.UI.UIButton btMinimize;
        private PictureBox pctLogo;
        private Extensions.InvertedCornerPanel btnBorderBot;
    }
}