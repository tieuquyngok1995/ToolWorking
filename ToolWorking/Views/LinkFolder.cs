using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class LinkFolder : Form
    {
        // Path folder source
        private string pathFolderSource;
        // Path folder backup
        private string pathFolderBk;
        // Path folder move/remove
        private string pathFolder;

        // Path Files
        private List<string> listFiles;
        // Tree node
        private TreeNode nodeSelected;
        // Dictionary result
        private Dictionary<string, string> dicResult;

        public LinkFolder()
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
        private void LinkFolder_Load(object sender, EventArgs e)
        {
            try
            {
                int mode = Properties.Settings.Default.modeLinkFolder;
                pathFolderSource = Properties.Settings.Default.pathFolder;
                pathFolderBk = Properties.Settings.Default.pathFolderBk;
                pathFolder = Properties.Settings.Default.pathFolderRemove;

                if (mode == 0) rbModeTree.Checked = true; else rbModePath.Checked = true;
                panelCenterTreeFolder.Visible = rbModeTree.Checked;
                panelCenterPath.Visible = rbModePath.Checked;

                txtPathFolder.Text = !string.IsNullOrEmpty(pathFolderSource) ? pathFolderSource : string.Empty;
                txtPathBk.Text = !string.IsNullOrEmpty(pathFolderBk) ? pathFolderBk : string.Empty;
                txtPath.Text = !string.IsNullOrEmpty(pathFolder) ? pathFolder : string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event chose mode get path in tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbModeTree_CheckedChanged(object sender, EventArgs e)
        {
            btnReloadFolder.Visible = true;
            lblSearch.Text = "Project Search";
            txtPGSearch.Visible = rbModeTree.Checked;
            btnSearchPG.Visible = rbModeTree.Checked;
            txtPathBk.Visible = rbModePath.Checked;
            btnOpenPathBk.Visible = rbModePath.Checked;

            lblPath.Text = "Remove Folder";

            lblAction.Visible = false;
            rbCopy.Visible = false;
            rbDelete.Visible = false;
            btnCopyResult.Text = "    Copy";

            panelCenterTreeFolder.Visible = rbModeTree.Checked;
            panelCenterPath.Visible = rbModePath.Checked;

            // Save mode
            Properties.Settings.Default.modeLinkFolder = 0;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event chose mode get path in list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbModePath_CheckedChanged(object sender, EventArgs e)
        {
            btnReloadFolder.Visible = false;
            lblSearch.Text = "Backup Folder";
            txtPGSearch.Visible = rbModeTree.Checked;
            btnSearchPG.Visible = rbModeTree.Checked;
            txtPathBk.Visible = rbModePath.Checked;
            btnOpenPathBk.Visible = rbModePath.Checked;

            lblPath.Text = "Destination Folder";

            lblAction.Visible = true;
            rbCopy.Visible = true;
            rbCopy.Checked = true;
            rbCopyBackup.Visible = true;
            rbDelete.Visible = true;
            btnCopyResult.Text = "    Copy";

            panelCenterTreeFolder.Visible = rbModeTree.Checked;
            panelCenterPath.Visible = rbModePath.Checked;

            // Save mode
            Properties.Settings.Default.modeLinkFolder = 1;
            Properties.Settings.Default.Save();
        }

        private void txtPathFolder_Click(object sender, EventArgs e)
        {
            txtPathFolder.SelectAll();
            txtPathFolder.Focus();
        }

        private void txtPathFolder_TextChanged(object sender, EventArgs e)
        {
            pathFolderSource = txtPathFolder.Text.Trim();
            Properties.Settings.Default.pathFolder = pathFolderSource;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event select folder source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (!string.IsNullOrEmpty(pathFolderSource)) fbd.SelectedPath = pathFolderSource;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathFolder.Text = fbd.SelectedPath;
                    pathFolderSource = fbd.SelectedPath;

                    Properties.Settings.Default.pathFolder = fbd.SelectedPath;
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
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;

                // Setting Inital Value of Progress Bar
                progressBarFolder.Value = 0;

                // Clear All Nodes if Already Exists
                treeViewFolder.Nodes.Clear();

                dicResult.Clear();
                toolTip.ShowAlways = true;
                if (!string.IsNullOrEmpty(txtPathFolder.Text) && Directory.Exists(txtPathFolder.Text))
                {
                    loadDirectory(txtPathFolder.Text);
                    txtResult.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Select Directory!!!");
                }

                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event select all text in text box search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPGSearch_Click(object sender, EventArgs e)
        {
            txtPGSearch.SelectAll();
            txtPGSearch.Focus();
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
                string valSearch = txtPGSearch.Text.Trim();
                if (string.IsNullOrEmpty(valSearch)) return;

                string dirRemove = txtPath.Text.Trim();

                foreach (TreeNode node in treeViewFolder.Nodes)
                {
                    searchNode(node, valSearch, dirRemove);
                }

                reloadResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPathBk_Click(object sender, EventArgs e)
        {
            txtPathBk.SelectAll();
            txtPathBk.Focus();
        }

        /// <summary>
        /// Event change text path backup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPathBk_TextChanged(object sender, EventArgs e)
        {
            pathFolderBk = txtPathBk.Text.Trim();
            Properties.Settings.Default.pathFolderBk = pathFolderBk;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event select folder backup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenPathBk_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (!string.IsNullOrEmpty(pathFolderBk)) fbd.SelectedPath = pathFolderBk;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathBk.Text = fbd.SelectedPath;
                    pathFolderBk = fbd.SelectedPath;

                    Properties.Settings.Default.pathFolderBk = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    txtPathBk.Text = string.Empty;
                    pathFolderBk = string.Empty;

                    Properties.Settings.Default.pathFolderBk = string.Empty;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPath_Click(object sender, EventArgs e)
        {
            txtPath.SelectAll();
            txtPath.Focus();
        }

        /// <summary>
        /// Event change text path remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPathRemove_TextChanged(object sender, EventArgs e)
        {
            pathFolder = txtPath.Text.Trim();
            Properties.Settings.Default.pathFolderRemove = pathFolder;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event select folder remove/move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (!string.IsNullOrEmpty(pathFolder)) fbd.SelectedPath = pathFolder;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fbd.SelectedPath;
                    pathFolder = fbd.SelectedPath;

                    Properties.Settings.Default.pathFolderRemove = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string dirRemove = txtPath.Text.Trim();

                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;

                if (nodeSelected.Nodes.Count > 0)
                {
                    checkNodeExits(nodeSelected, dirRemove);
                }
                else
                {
                    checkNodeExits(e.Node, dirRemove);
                }

                reloadResult();

                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event select all text 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtListFile_Click(object sender, EventArgs e)
        {
            txtListFile.SelectAll();
            txtListFile.Focus();
            txtListFile.SelectionStart = txtListFile.Text.Length;
            txtListFile.SelectionLength = 0;
        }

        /// <summary>
        /// Event change value textbox list file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtListFile_TextChanged(object sender, EventArgs e)
        {
            lblNumCount.Visible = false;
            if (string.IsNullOrEmpty(txtListFile.Text))
            {
                txtResultPathFile.Text = string.Empty;
                btnCopyResult.Enabled = false;
                return;
            }

            int numBefore = 0;
            string[] arrPathFiles = txtListFile.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            btnCopyResult.Enabled = false;
            if (arrPathFiles.Length > 0)
            {
                int numCheck;
                listFiles = new List<string>();
                StringBuilder sb = new StringBuilder();

                foreach (var pathFile in arrPathFiles)
                {
                    if (!int.TryParse(pathFile.Trim(), out numCheck))
                    {
                        numBefore++;

                        if (pathFile.LastIndexOf(".mjs") != -1 || pathFile.LastIndexOf(".mjs.map") != -1 || pathFile.LastIndexOf(".d.ts") != -1)
                        {
                            continue;
                        }

                        string isExit = listFiles.FirstOrDefault(str => str.Equals(pathFile.Trim()));
                        if (isExit == null)
                        {
                            listFiles.Add(pathFile.Replace("\"", "").Trim());
                            sb.Append(pathFile.Replace("\"", "").Trim());
                            sb.AppendLine();
                        }
                    }
                }

                lblNumBefore.Text = "Line number before input: " + numBefore;
                lblNumBefore.Visible = true;

                if (listFiles.Count > 0)
                {
                    lblNumAfter.Text = "Line number after change: " + listFiles.Count;
                    lblNumAfter.Visible = true;
                }

                txtResultPathFile.Text = string.Empty;
                btnCopyResult.Enabled = true;
                txtListFile.Text = sb.ToString();
            }
            else
            {
                lblNumBefore.Visible = false;
                lblNumAfter.Visible = false;
            }
        }

        /// <summary>
        /// Event change select radio action mode copy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbCopy_CheckedChanged(object sender, EventArgs e)
        {
            lblNumCount.Visible = false;
            btnCount.Visible = false;
            btnCopyResult.Text = "    Copy";
        }

        /// <summary>
        /// Event change select radio action mode copy backup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbCopyBackup_CheckedChanged(object sender, EventArgs e)
        {
            lblNumCount.Visible = false;
            btnCount.Visible = true;
            btnCopyResult.Text = "    Copy";
        }

        /// <summary>
        /// Event change select radio action mode delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbDelete_CheckedChanged(object sender, EventArgs e)
        {
            lblNumCount.Visible = false;
            btnCount.Visible = false;
            btnCopyResult.Text = "    Delete";
        }

        /// <summary>
        /// Event count total file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCount_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(pathFolderBk)) return;

                string[] files = Directory.GetFiles(pathFolderBk, "*.*", SearchOption.AllDirectories);
                int fileCount = files.Length;

                lblNumCount.Visible = true;
                lblNumCount.Text = "Total file in folder Backup: " + fileCount;
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
            try
            {
                if (rbModeTree.Checked)
                {
                    if (string.IsNullOrEmpty(txtResult.Text)) return;

                    Clipboard.SetText(txtResult.Text);
                }
                else if (rbModePath.Checked)
                {
                    lblNumCount.Visible = false;
                    if (string.IsNullOrEmpty(txtPathFolder.Text) || !Directory.Exists(txtPathFolder.Text))
                    {
                        MessageBox.Show("Select path folder srouce!!!");
                    }
                    else if (string.IsNullOrEmpty(txtPath.Text) || !Directory.Exists(txtPath.Text))
                    {
                        MessageBox.Show("Select path folder move source!!!");
                    }
                    else if (string.IsNullOrEmpty(txtPathBk.Text) || !Directory.Exists(txtPathBk.Text))
                    {
                        if (rbCopyBackup.Checked) MessageBox.Show("Select path folder backup source!!!");
                    }
                    else
                    {
                        handelFile();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearResult_Click(object sender, EventArgs e)
        {
            dicResult.Clear();
            txtResult.Text = string.Empty;

            txtResultPathFile.Text = string.Empty;
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

            // Setting Inital Value of Progress Bar
            progressBarFolder.Value = 0;
            //Setting ProgressBar Maximum Value
            progressBarFolder.Maximum = dicResult.Count;

            foreach (KeyValuePair<string, string> entry in dicResult)
            {
                txtResult.Text = txtResult.Text + entry.Value + "\r\n";
                updateProgress();
            }

            if (!string.IsNullOrEmpty(txtResult.Text))
            {
                btnCopyResult.Enabled = true;
            }
        }

        /// <summary>
        /// Handel file in list file
        /// </summary>
        private void handelFile()
        {
            string targetBk = string.Empty;
            txtResultPathFile.Text = string.Empty;

            if (rbCopy.Checked || rbCopyBackup.Checked)
            {
                if (Directory.Exists(pathFolderBk)) Directory.Delete(pathFolderBk, true);
            }

            foreach (string path in listFiles)
            {
                if (string.IsNullOrEmpty(path)) continue;

                string fileName = CUtils.getFileName(path);

                try
                {
                    string sourceFile = txtPathFolder.Text + "/" + path.Replace("\"", "");
                    FileInfo fileInfo = new FileInfo(sourceFile);

                    string targetFileBk = string.Empty;
                    if (!string.IsNullOrEmpty(txtPathBk.Text))
                    {
                        targetBk = txtPathBk.Text + fileInfo.DirectoryName.Replace(txtPathFolder.Text, string.Empty);
                        targetFileBk = Path.Combine(targetBk, (new FileInfo(sourceFile)).Name);
                    }

                    string targetDir = txtPath.Text + fileInfo.DirectoryName.Replace(txtPathFolder.Text, string.Empty);
                    string targetFile = Path.Combine(targetDir, (new FileInfo(sourceFile)).Name);

                    if (rbCopy.Checked)
                    {
                        if (!string.IsNullOrEmpty(txtPathBk.Text))
                        {
                            if (!Directory.Exists(targetBk) && File.Exists(sourceFile))
                            {
                                Directory.CreateDirectory(targetBk);
                            }

                            File.Copy(sourceFile, targetFileBk, true);
                        }

                        if (!Directory.Exists(targetDir) && File.Exists(sourceFile))
                        {
                            Directory.CreateDirectory(targetDir);
                        }

                        File.Copy(sourceFile, targetFile, true);

                        txtResultPathFile.Text += "Copy file [" + fileName + "] success.\r\n";
                    }
                    else if (rbCopyBackup.Checked)
                    {
                        if (!Directory.Exists(targetBk) && File.Exists(targetFile))
                        {
                            Directory.CreateDirectory(targetBk);
                        }

                        File.Copy(targetFile, targetFileBk, true);

                        txtResultPathFile.Text += "Copy file [" + fileName + "] success.\r\n";
                    }
                    else
                    {
                        if (File.Exists(targetFile))
                        {
                            File.Delete(targetFile);
                            txtResultPathFile.Text += "Delete file [" + fileName + "] success.\r\n";
                        }
                        else
                        {
                            txtResultPathFile.Text += "Delete file [" + fileName + "] unsuccessful. File does not exist.\r\n";
                        }
                    }
                }
                catch (Exception ex)
                {
                    txtResultPathFile.Text += "File processing [" + fileName + "] failed.\r\nError detail: " + ex.Message + "\r\n";
                }
            }
        }

        #endregion
    }
}