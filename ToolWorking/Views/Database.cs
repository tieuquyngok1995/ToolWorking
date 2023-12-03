using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class Database : Form
    {
        // Dictionary result
        private Dictionary<string, string> dicResult;
        // Tree node
        private TreeNode nodeSelected;

        public Database()
        {
            InitializeComponent();

            dicResult = new Dictionary<string, string>();
        }

        #region Event
        /// <summary>
        /// Event setting path folder init
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Database_Load(object sender, EventArgs e)
        {
            try
            {
                string settingServer = Properties.Settings.Default.serverDatabse;
                string settingUser = Properties.Settings.Default.userDatabase;
                string settingPass = Properties.Settings.Default.passDatabase;
                string pathFolder = Properties.Settings.Default.pathFolderDatabase;

                txtServer.Text = !string.IsNullOrEmpty(settingServer) ? settingServer : string.Empty;
                txtUser.Text = !string.IsNullOrEmpty(settingUser) ? settingUser : string.Empty;
                txtPass.Text = !string.IsNullOrEmpty(settingPass) ? settingPass : string.Empty;
                txtPathFolder.Text = !string.IsNullOrEmpty(pathFolder) ? pathFolder : string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event change value text box server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtServer_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.serverDatabse = txtServer.Text;
            Properties.Settings.Default.Save();
        }


        /// <summary>
        /// Event change value text box user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUser_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.userDatabase = txtUser.Text;
            Properties.Settings.Default.Save();
        }


        /// <summary>
        /// Event change value text box pass
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPass_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.passDatabase = txtPass.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event check connect database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckConnect_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event show item when checkbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbRunScript_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRunScript.Checked)
            {
                lblPathFolder.Visible = true;
                txtPathFolder.Visible = true;
                btnOpenFolder.Visible = true;
                btnReloadFolder.Visible = true;
            }
        }

        /// <summary>
        /// Event hidden item when checkbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbRunQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRunQuery.Checked)
            {
                lblPathFolder.Visible = false;
                txtPathFolder.Visible = false;
                btnOpenFolder.Visible = false;
                btnReloadFolder.Visible = false;
            }
        }

        /// <summary>
        /// Event Open Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathFolder.Text = fbd.SelectedPath;

                    Properties.Settings.Default.pathFolderDatabase = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evemt load data in path folder 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadFolder_Click(object sender, EventArgs e)
        {
            try
            {
                // Setting Inital Value of Progress Bar
                progressBarFolder.Value = 0;
                // Clear All Nodes if Already Exists
                treeViewFolder.Nodes.Clear();
                dicResult.Clear();
                toolTip1.ShowAlways = true;
                if (txtServer.Text != "" && Directory.Exists(txtServer.Text))
                {
                    loadDirectory(txtServer.Text);

                    txtResult.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Select Directory!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event change value search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPGSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchPG_Click(sender, e);
            }
        }

        /// <summary>
        /// Event search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchPG_Click(object sender, EventArgs e)
        {
            try
            {
                string valSearch = txtUser.Text.Trim();
                if (string.IsNullOrEmpty(valSearch)) return;


                foreach (TreeNode node in treeViewFolder.Nodes)
                {
                }

                reloadResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event change text remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPathRemove_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event select node tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            nodeSelected = e.Node;
        }

        /// <summary>
        /// Event mouse double click node tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewFolder_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {

               

                reloadResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event copy 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;

            Clipboard.SetText(txtResult.Text);
        }

        /// <summary>
        /// Event clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearResult_Click(object sender, EventArgs e)
        {
            dicResult.Clear();
            txtUser.Text = string.Empty;
            txtResult.Text = string.Empty;
        }
        #endregion

        #region Function
        /// <summary>
        /// Load folder
        /// </summary>
        /// <param name="Dir"></param>
        private void loadDirectory(string pathFolder)
        {
            DirectoryInfo di = new DirectoryInfo(pathFolder);
            //Setting ProgressBar Maximum Value
            progressBarFolder.Maximum = Directory.GetFiles(pathFolder, "*.*", SearchOption.AllDirectories).Length + Directory.GetDirectories(pathFolder, "**", SearchOption.AllDirectories).Length;
            TreeNode treeNode = treeViewFolder.Nodes.Add(di.Name);
            treeNode.Tag = di.FullName;
            treeNode.StateImageIndex = 0;
            treeNode.ImageIndex = 0;
            treeNode.SelectedImageIndex = 0;
            loadFiles(pathFolder, treeNode);
            loadSubDirectories(pathFolder, treeNode);
        }

        /// <summary>
        /// Load files in folder
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="treeNode"></param>
        private void loadFiles(string pathFile, TreeNode treeNode)
        {
            string[] Files = Directory.GetFiles(pathFile, "*.*");
            // Loop through them to see files
            foreach (string file in Files)
            {
                FileInfo fileInfo = new FileInfo(file);
                TreeNode treeNodeAdd = treeNode.Nodes.Add(fileInfo.Name);
                treeNodeAdd.Tag = fileInfo.FullName;
                treeNodeAdd.StateImageIndex = 1;
                treeNodeAdd.ImageIndex = 1;
                treeNodeAdd.SelectedImageIndex = 1;
                updateProgress();
            }
        }

        /// <summary>
        /// Load sub folder in folder
        /// </summary>
        /// <param name="pathFolder"></param>
        /// <param name="treeNode"></param>
        private void loadSubDirectories(string pathFolder, TreeNode treeNode)
        {
            // Get all subdirectories
            string[] pathSubFolders = Directory.GetDirectories(pathFolder);
            // Loop through them to see if they have any other subdirectories
            foreach (string pathSubFolder in pathSubFolders)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(pathSubFolder);
                TreeNode treeNodeAdd = treeNode.Nodes.Add(directoryInfo.Name);
                treeNodeAdd.Tag = directoryInfo.FullName;
                treeNodeAdd.StateImageIndex = 0;
                treeNodeAdd.ImageIndex = 0;
                treeNodeAdd.SelectedImageIndex = 0;
                loadFiles(pathSubFolder, treeNodeAdd);
                loadSubDirectories(pathSubFolder, treeNodeAdd);
                updateProgress();
            }
        }

        /// <summary>
        /// Update processing progress
        /// </summary>
        private void updateProgress()
        {
            if (progressBarFolder.Value < progressBarFolder.Maximum)
            {
                progressBarFolder.Value++;
                int percent = (int)(((double)progressBarFolder.Value / (double)progressBarFolder.Maximum) * 100);
                string percentDisplay = percent < 10 ? "0" + percent.ToString() : percent.ToString();
                progressBarFolder.CreateGraphics().DrawString(percentDisplay + " %", new Font("Century Gothic", (float)10, FontStyle.Regular), Brushes.Black, new PointF(progressBarFolder.Width / 2 - 10, progressBarFolder.Height / 2 - 7));
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Search node in tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="valSearch"></param>
        /// <param name="dirRemove"></param>
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

        /// <summary>
        /// Check exit node in tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="dirRemove"></param>
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

        /// <summary>
        /// Reload text box result
        /// </summary>
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
