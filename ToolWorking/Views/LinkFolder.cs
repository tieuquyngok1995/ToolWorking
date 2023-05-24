using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class LinkFolder : Form
    {
        private Dictionary<string, string> dicResult;

        private TreeNode nodeSelected;

        public LinkFolder()
        {
            InitializeComponent();

            dicResult = new Dictionary<string, string>();
        }

        #region Event
        private void LinkFolder_Load(object sender, EventArgs e)
        {
            string pathFolder = Properties.Settings.Default.pathFolder;
            string pathFolderRemove = Properties.Settings.Default.pathFolderRemove;

            txtPathFolder.Text = !string.IsNullOrEmpty(pathFolder) ? pathFolder : string.Empty;
            txtPathRemove.Text = !string.IsNullOrEmpty(pathFolderRemove) ? pathFolderRemove : string.Empty;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPathFolder.Text = fbd.SelectedPath;

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
            dicResult.Clear();
            toolTip1.ShowAlways = true;
            if (txtPathFolder.Text != "" && Directory.Exists(txtPathFolder.Text))
            {
                loadDirectory(txtPathFolder.Text);

                txtResult.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Select Directory!!");
            }
        }

        private void txtPGSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchPG_Click(sender, e);
            }
        }

        private void btnSearchPG_Click(object sender, EventArgs e)
        {
            string valSearch = txtPGSearch.Text.Trim();
            if (string.IsNullOrEmpty(valSearch)) return;

            string dirRemove = txtPathRemove.Text.Trim();

            foreach (TreeNode node in treeViewFolder.Nodes)
            {
                searchNode(node, valSearch, dirRemove);
            }

            reloadResult();
        }

        private void txtPathRemove_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.pathFolderRemove = txtPathRemove.Text.Trim();
            Properties.Settings.Default.Save();
        }

        private void treeViewFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            nodeSelected = e.Node;
        }

        private void treeViewFolder_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string dirRemove = txtPathRemove.Text.Trim();

            if (nodeSelected.Nodes.Count > 0)
            {
                checkNodeExits(nodeSelected, dirRemove);
            }
            else
            {
                checkNodeExits(e.Node, dirRemove);
            }

            reloadResult();
        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;

            Clipboard.SetText(txtResult.Text);
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            dicResult.Clear();
            txtPGSearch.Text = string.Empty;
            txtResult.Text = string.Empty;
        }
        #endregion

        #region Function
        private void loadDirectory(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            //Setting ProgressBar Maximum Value
            progressBarFolder.Maximum = Directory.GetFiles(Dir, "*.*", SearchOption.AllDirectories).Length + Directory.GetDirectories(Dir, "**", SearchOption.AllDirectories).Length;
            TreeNode tds = treeViewFolder.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            tds.ImageIndex = 0;
            tds.SelectedImageIndex = 0;
            loadFiles(Dir, tds);
            loadSubDirectories(Dir, tds);
        }

        private void loadFiles(string dir, TreeNode td)
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
                updateProgress();
            }
        }

        private void loadSubDirectories(string dir, TreeNode td)
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
                loadFiles(subdirectory, tds);
                loadSubDirectories(subdirectory, tds);
                updateProgress();
            }
        }

        private void updateProgress()
        {
            if (progressBarFolder.Value < progressBarFolder.Maximum)
            {
                progressBarFolder.Value++;
                int percent = (int)(((double)progressBarFolder.Value / (double)progressBarFolder.Maximum) * 100);
                progressBarFolder.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBarFolder.Width / 2 - 10, progressBarFolder.Height / 2 - 7));
                Application.DoEvents();
            }
        }

        private void searchNode(TreeNode node, string valSearch, string dirRemove)
        {
            string nodePath = node.Tag as string;

            if (nodePath.Contains(valSearch))
            {
                string nodeKey = node.FullPath;
                string nodeValue = node.Tag as string;

                if (CUtils.dicIsExists(dicResult, nodeKey))
                {
                    dicResult.Remove(nodeKey);
                }
                else
                {
                    FileAttributes attr = File.GetAttributes(nodePath);
                    if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                    {
                        nodeValue = !String.IsNullOrEmpty(dirRemove) ? nodeValue.Replace(dirRemove, string.Empty) : nodeValue;
                        dicResult.Add(nodeKey, nodeValue);
                    }
                }
            }

            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode actualNode in node.Nodes)
                {
                    searchNode(actualNode, valSearch, dirRemove);
                }
            }
        }

        private void checkNodeExits(TreeNode node, string dirRemove)
        {
            string nodeKey = node.FullPath;
            string nodeValue = node.Tag as string;

            if (CUtils.dicIsExists(dicResult, nodeKey))
            {
                dicResult.Remove(nodeKey);
            }
            else
            {
                FileAttributes attr = File.GetAttributes(nodeValue);
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    nodeValue = !String.IsNullOrEmpty(dirRemove) ? nodeValue.Replace(dirRemove, string.Empty) : nodeValue;
                    dicResult.Add(nodeKey, nodeValue);
                }
            }

            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode actualNode in node.Nodes)
                {
                    checkNodeExits(actualNode, dirRemove);
                }
            }
        }

        private void reloadResult()
        {
            txtResult.Text = string.Empty;
            foreach (KeyValuePair<string, string> entry in dicResult)
            {
                txtResult.Text = txtResult.Text + entry.Value + "\r\n";
            }

            if (!string.IsNullOrEmpty(txtResult.Text))
            {
                btnCopyResult.Enabled = true;
            }
        }

        #endregion
    }
}
