using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ToolWorking.Views
{
    public partial class LinkFolder : Form
    {
        private Dictionary<string, string> dicResult;

        public LinkFolder()
        {
            InitializeComponent();

            dicResult = new Dictionary<string, string>();
        }

        #region Event
        private void LinkFolder_Load(object sender, EventArgs e)
        {
            string pathFolder = Properties.Settings.Default.pathFolder;

            if (!string.IsNullOrEmpty(pathFolder))
            {
                this.txtPathFolder.Text = pathFolder;
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtPathFolder.Text = fbd.SelectedPath;

                Properties.Settings.Default.pathFolder = fbd.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void btnReloadFolder_Click(object sender, EventArgs e)
        {
            // Setting Inital Value of Progress Bar
            progressBarFolder.Value = 0;
            // Clear All Nodes if Already Exists
            treeViewFolder.Nodes.Clear();
            toolTip1.ShowAlways = true;
            if (this.txtPathFolder.Text != "" && Directory.Exists(txtPathFolder.Text))
            {
                LoadDirectory(this.txtPathFolder.Text);

                this.txtResult.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Select Directory!!");
            }
        }

        private void btnSearchPG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPG.Text)) return;

            dicResult.Clear();
            foreach (TreeNode node in treeViewFolder.Nodes)
            {
                AddNodeAndChildNodesToList(node);
            }

            AddResult();
        }

        private void treeViewFolder_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                dicResult.Add(e.Node.Text, e.Node.Tag.ToString());
            }
            else
            {
                dicResult.Remove(e.Node.Text);
            }

            AddResult();
        }

        private void treeViewFolder_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.SelectedImageIndex = e.Node.ImageIndex;
        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;

            Clipboard.SetText(txtResult.Text);
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            txtSearchPG.Text = string.Empty;
            txtResult.Text = string.Empty;
        }
        #endregion

        #region Function
        public void LoadDirectory(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            //Setting ProgressBar Maximum Value
            progressBarFolder.Maximum = Directory.GetFiles(Dir, "*.*", SearchOption.AllDirectories).Length + Directory.GetDirectories(Dir, "**", SearchOption.AllDirectories).Length;
            TreeNode tds = treeViewFolder.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            tds.ImageIndex = 0;
            tds.SelectedImageIndex = 0;
            LoadFiles(Dir, tds);
            LoadSubDirectories(Dir, tds);
        }

        private void LoadFiles(string dir, TreeNode td)
        {
            string[] Files = Directory.GetFiles(dir, "*.*");
            // Loop through them to see files
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = td.Nodes.Add(fi.Name);
                tds.Tag = fi.FullName;
                tds.StateImageIndex = 1;
                tds.ImageIndex = 1;
                tds.SelectedImageIndex = 1;
                UpdateProgress();
            }
        }

        private void LoadSubDirectories(string dir, TreeNode td)
        {
            // Get all subdirectories
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.Name);
                tds.Tag = di.FullName;
                tds.StateImageIndex = 0;
                tds.ImageIndex = 0;
                tds.SelectedImageIndex = 0;
                LoadFiles(subdirectory, tds);
                LoadSubDirectories(subdirectory, tds);
                UpdateProgress();
            }
        }

        private void UpdateProgress()
        {
            if (progressBarFolder.Value < progressBarFolder.Maximum)
            {
                progressBarFolder.Value++;
                int percent = (int)(((double)progressBarFolder.Value / (double)progressBarFolder.Maximum) * 100);
                progressBarFolder.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBarFolder.Width / 2 - 10, progressBarFolder.Height / 2 - 7));
                Application.DoEvents();
            }
        }

        private void AddNodeAndChildNodesToList(TreeNode node)
        {
            if (node.Text.ToUpper().Contains(txtSearchPG.Text.ToUpper()))
            {
                dicResult.Add(node.Text, node.Tag.ToString());
            }

            foreach (TreeNode actualNode in node.Nodes)
            {
                AddNodeAndChildNodesToList(actualNode);
            }
        }

        private void AddResult()
        {
            txtResult.Text = string.Empty;
            foreach (KeyValuePair<string, string> entry in dicResult)
            {
                txtResult.Text = txtResult.Text + entry.Value + "\r\n";
            }
        }

        #endregion
    }
}
