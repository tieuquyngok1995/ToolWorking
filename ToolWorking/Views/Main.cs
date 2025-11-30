using System;
using System.Drawing;
using System.Runtime.InteropServices;
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
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Fields
        private Form activeForm;

        #region Event
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load init
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            int numTabOpen = Properties.Settings.Default.numTabOpen;
            switch (numTabOpen)
            {
                case 0:
                    panelSide.Height = btnLinkFolder.Height;
                    panelSide.Top = btnLinkFolder.Top;
                    panelBotSide.Top = btnLinkFolder.Bottom - 2;
                    labelTitle.Text = CONST.TITLE_FILE_FOLDER;

                    OpenChildForm(new LinkFolder(), sender);
                    break;
                case 1:
                    panelSide.Height = btnSearchFile.Height;
                    panelSide.Top = btnSearchFile.Top;
                    panelBotSide.Top = btnSearchFile.Bottom - 2;
                    labelTitle.Text = CONST.TITLE_SEARCH_FILE;

                    OpenChildForm(new SearchFile(), sender);
                    break;
                case 2:
                    panelSide.Height = btnCreateFile.Height;
                    panelSide.Top = btnCreateFile.Top;
                    panelBotSide.Top = btnCreateFile.Bottom - 2;
                    labelTitle.Text = CONST.TITLE_CREATE_FILE;

                    OpenChildForm(new CreateFile(), sender);
                    break;
                case 3:
                    panelSide.Height = btnDatabase.Height;
                    panelSide.Top = btnDatabase.Top;
                    panelBotSide.Top = btnDatabase.Bottom - 2;
                    labelTitle.Text = CONST.TITLE_DATABASE;

                    OpenChildForm(new Database(), sender);
                    break;

                case 4:
                    panelSide.Height = btnFormat.Height;
                    panelSide.Top = btnFormat.Top;
                    panelBotSide.Top = btnFormat.Bottom - 2;
                    labelTitle.Text = CONST.TITLE_FORMAT;

                    OpenChildForm(new Format(), sender);
                    break;
            }
        }

        /// <summary>
        /// Event mouse move form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Event mouse move form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelLabel_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Event mouse move form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Event minimize form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Event close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Event click button Link Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLinkFolder_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.numTabOpen = 0;
            Properties.Settings.Default.Save();

            panelSide.Height = btnLinkFolder.Height;
            panelSide.Top = btnLinkFolder.Top;
            panelBotSide.Top = btnLinkFolder.Bottom - 2;

            labelTitle.Text = CONST.TITLE_FILE_FOLDER;

            OpenChildForm(new LinkFolder(), sender);
        }

        /// <summary>
        /// Event click button Search File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.numTabOpen = 1;
            Properties.Settings.Default.Save();

            panelSide.Height = btnSearchFile.Height;
            panelSide.Top = btnSearchFile.Top;
            panelBotSide.Top = btnSearchFile.Bottom - 2;

            labelTitle.Text = CONST.TITLE_SEARCH_FILE;

            OpenChildForm(new SearchFile(), sender);
        }

        /// <summary>
        /// Event click button Create File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.numTabOpen = 2;
            Properties.Settings.Default.Save();

            panelSide.Height = btnCreateFile.Height;
            panelSide.Top = btnCreateFile.Top;
            panelBotSide.Top = btnCreateFile.Bottom - 2;

            labelTitle.Text = CONST.TITLE_CREATE_FILE;

            OpenChildForm(new CreateFile(), sender);
        }

        /// <summary>
        /// Event click button Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDatabase_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.numTabOpen = 3;
            Properties.Settings.Default.Save();

            panelSide.Height = btnDatabase.Height;
            panelSide.Top = btnDatabase.Top;
            panelBotSide.Top = btnDatabase.Bottom - 2;

            labelTitle.Text = CONST.TITLE_DATABASE;

            OpenChildForm(new Database(), sender);
        }

        /// <summary>
        /// Event click button Format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFormat_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.numTabOpen = 4;
            Properties.Settings.Default.Save();

            panelSide.Height = btnFormat.Height;
            panelSide.Top = btnFormat.Top;
            panelBotSide.Top = btnFormat.Bottom - 2;

            labelTitle.Text = CONST.TITLE_FORMAT;

            OpenChildForm(new Format(), sender);
        }
        #endregion

        #region Function
        /// <summary>
        /// Open sub form
        /// </summary>
        /// <param name="childForm"></param>
        /// <param name="btnSender"></param>
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

        /// <summary>
        /// Setting panel color
        /// </summary>
        private void loadPanelColor()
        {
            Color panelColor = CUtils.createColor();
            panelTop.BackColor = panelColor;
            panelTopDown.BackColor = panelColor;
            panelBottom.BackColor = panelColor;
            panelLeft.BackColor = panelColor;
        }
        #endregion
    }
}
