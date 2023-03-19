using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class Main : Form
    {
        // Dll
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Fields
        private Form activeForm;

        #region Event
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            panelSide.Height = btnLinkFolder.Height;
            panelSide.Top = btnLinkFolder.Top;

            OpenChildForm(new LinkFolder(), sender);
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLinkFolder_Click(object sender, EventArgs e)
        {
            panelSide.Height = btnLinkFolder.Height;
            panelSide.Top = btnLinkFolder.Top;

            OpenChildForm(new LinkFolder(), sender);
        }
        #endregion

        #region Function

        private void loadPanelColor()
        {
            Color panelColor = CUtils.CreateColor();
            panelTop.BackColor = panelColor;
            panelSide.BackColor = panelColor;
            panelBottom.BackColor = panelColor;
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            childForm.BringToFront();
            childForm.Show();

            this.panelCenter.Controls.Add(childForm);

            this.loadPanelColor();
        }
        #endregion


    }
}
