using Sunny.UI;
using System.Runtime.InteropServices;

using static WorkBuddy.Helpers.UIHelper;

namespace WorkBuddy.Forms
{
    public partial class MainForm : UIForm
    {
        // Dll
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private UIButton? _activeButton;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Event

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event mouse move form
        /// </summary>
        private void pctLogo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Event mouse move form
        /// </summary>
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        /// <summary>
        /// Event minimize form
        /// </summary>
        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Event close form
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetActive((UIButton)sender);
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            SetActive((UIButton)sender);

        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            SetActive((UIButton)sender);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SetActive((UIButton)sender);
        }

        #endregion


        #region Setting layout

        private void OpenChildForm(Form childForm, object btnSender)
        {

        }

        /// <summary>
        /// Setting panel color
        /// </summary>
        private void SetActive(UIButton button)
        {
            if (_activeButton == button)
                return;

            var (bColor, fColor) = ColorHelper.CreateColorPair();

            // Deactivate old button
            foreach (Control control in panelCenterLeft.Controls)
            {
                if (control is UIButton _deactiveButton)
                {
                    _deactiveButton.FillColor = bColor;
                    _deactiveButton.FillHoverColor = Color.White;
                    _deactiveButton.RectColor = bColor;
                    _deactiveButton.RectHoverColor = Color.White;
                    _deactiveButton.RectPressColor = bColor;
                    _deactiveButton.RectSelectedColor = bColor;
                    _deactiveButton.ForeColor = fColor;
                }
            }

            // Set colot to active button
            _activeButton = button;
            _activeButton.FillColor = Color.White;
            _activeButton.FillHoverColor = Color.White;
            _activeButton.RectColor = Color.White;
            _activeButton.RectHoverColor = Color.White;
            _activeButton.RectPressColor = Color.White;
            _activeButton.RectSelectedColor = Color.White;
            _activeButton.ForeColor = Color.Black;

            // Set color header button
            if (fColor == Color.Black)
            {
                btnClose.BackgroundImage = Image.FromFile(Path.Combine("Assets", "Icons", "icon-close-b.png"));
                btMinimize.BackgroundImage = Image.FromFile(Path.Combine("Assets", "Icons", "icon-minimize-b.png"));
            }
            else
            {
                btnClose.BackgroundImage = Image.FromFile(Path.Combine("Assets", "Icons", "icon-close-w.png"));
                btMinimize.BackgroundImage = Image.FromFile(Path.Combine("Assets", "Icons", "icon-minimize-w.png"));
            }

            // Set location button border
            btnBorderTop.Top = _activeButton.Top - 20;
            btnBorderBot.Top = _activeButton.Top + 35;

            // Set colot to panel
            panelTop.BackColor = bColor;
            panelCenterLeft.BackColor = bColor;
            panelCenterRight.BackColor = bColor;
            panelBottom.BackColor = bColor;
        }
        #endregion

    }
}