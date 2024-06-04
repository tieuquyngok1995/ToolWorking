using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolWorking.Model;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class SearchFile : Form
    {
        // Path folder
        string pathFolderDatabase;
        // List data files
        private List<FileModel> listFiles;
        // Index row table
        private int index;

        public SearchFile()
        {
            InitializeComponent();

            listFiles = new List<FileModel>();
            index = 1;
        }

        #region Event
        /// <summary>
        /// Event setting path folder init
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchFile_Load(object sender, EventArgs e)
        {
            try
            {
                // get path folder in setting
                pathFolderDatabase = Properties.Settings.Default.pathFolderSearch;

                txtPathFolder.Text = !string.IsNullOrEmpty(pathFolderDatabase) ? pathFolderDatabase : string.Empty;

                txtPathFolder.Select();
                txtPathFolder.Focus();

                int mode = Properties.Settings.Default.modeSearchFile;
                if (mode == 0) rbRead.Checked = true; else rbReadOpen.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (!string.IsNullOrEmpty(pathFolderDatabase)) fbd.SelectedPath = pathFolderDatabase;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathFolder.Text = fbd.SelectedPath;
                    pathFolderDatabase = fbd.SelectedPath;

                    Properties.Settings.Default.pathFolderSearch = fbd.SelectedPath;
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
                toolTip1.ShowAlways = true;

                if (txtPathFolder.Text != "" && Directory.Exists(txtPathFolder.Text))
                {
                    index = 1;
                    listFiles.Clear();

                    runCommandUpdateSVN();

                    // load folder
                    loadDirectory(txtPathFolder.Text);

                    // set data to grid view
                    gridViewFiles.DataSource = listFiles;

                    txtResult.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Select Directory!!");
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
        /// Event select all text in text box Search
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
        private void txtPGSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearchPG_Click(sender, e);
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
                string valSearch = txtPGSearch.Text.Trim().ToUpper();
                if (string.IsNullOrEmpty(valSearch))
                {
                    // set data to grid view
                    gridViewFiles.DataSource = listFiles;
                }
                else
                {
                    // set data to grid view
                    gridViewFiles.DataSource = listFiles.Where(o => o.fileName.ToUpper().Contains(valSearch)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event check read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbRead_CheckedChanged(object sender, EventArgs e)
        {
            cbProcessOpen.Visible = false;
            // Save mode
            Properties.Settings.Default.modeSearchFile = 0;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event check read open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbReadOpen_CheckedChanged(object sender, EventArgs e)
        {
            cbProcessOpen.Visible = true;
            cbProcessOpen.SelectedIndex = 0;
            // Save mode
            Properties.Settings.Default.modeSearchFile = 1;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event double click cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewFiles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string pathFile = gridViewFiles.Rows[e.RowIndex].Cells[4].Value.ToString();

                if (!File.Exists(pathFile)) return;

                string result = File.ReadAllText(pathFile, Encoding.GetEncoding("shift-jis"));

                if (rbReadOpen.Checked)
                {
                    if (cbProcessOpen.SelectedIndex == 0)
                    {
                        Process.Start("notepad++.exe", $@"""{pathFile}""");
                    }
                    else if (cbProcessOpen.SelectedIndex == 1)
                    {
                        pathFile = pathFile.Substring(0, pathFile.LastIndexOf("\\"));
                        Process.Start("explorer.exe", @pathFile);
                    }
                }

                txtResult.Text = result;
                btnCopyResult.Enabled = string.IsNullOrEmpty(result) ? false : true;
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
            txtPGSearch.Text = string.Empty;
            txtResult.Text = string.Empty;
            btnCopyResult.Enabled = false;
        }
        #endregion

        #region Function
        /// <summary>
        /// Load file and folder in directory
        /// </summary>
        /// <param name="pathFolder"></param>
        private void loadDirectory(string pathFolder)
        {
            DirectoryInfo directory = new DirectoryInfo(pathFolder);
            //Setting ProgressBar Maximum Value
            progressBarFolder.Maximum = Directory.GetFiles(pathFolder, "*.*", SearchOption.AllDirectories).Length + Directory.GetDirectories(pathFolder, "**", SearchOption.AllDirectories).Length;
            // Load files in folder
            loadFiles(string.Empty, pathFolder, directory.Name);

            loadSubDirectories(string.Empty, pathFolder);
        }

        /// <summary>
        /// Load files in folder
        /// </summary>
        /// <param name="pathFolder"></param>
        /// <param name="nameFolder"></param>
        private void loadFiles(string pathParentFolder, string pathFolder, string nameFolder)
        {
            string folder = nameFolder;
            if (!string.IsNullOrEmpty(pathParentFolder)) folder = pathFolder.Replace(pathParentFolder, string.Empty);

            string[] Files = Directory.GetFiles(pathFolder, "*.*");
            // Loop through them to see files
            foreach (string file in Files)
            {
                // Get info file
                FileInfo fileInfo = new FileInfo(file);
                // Add info to data grid view
                listFiles.Add(new FileModel(index, folder, getTypeFile(fileInfo.Name), fileInfo.Name, fileInfo.FullName,
                    File.GetLastWriteTime(fileInfo.FullName).ToString("yyyy-MM-dd")));
                index++;
                // Update progress
                updateProgress();
            }
        }

        /// <summary>
        /// Load sub folder in folder
        /// </summary>
        /// <param name="pathFolder"></param>
        private void loadSubDirectories(string pathParentFolder, string pathFolder)
        {
            // Get all subdirectories
            string[] pathSubFolder = Directory.GetDirectories(pathFolder);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in pathSubFolder)
            {
                // Info sub folder
                DirectoryInfo subDirectory = new DirectoryInfo(subdirectory);
                // Load files in folder
                loadFiles(pathParentFolder, subdirectory, subDirectory.Name);
                // Load sub folder
                loadSubDirectories(pathFolder, subdirectory);
                // Update progress
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
        /// Get type file in file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string getTypeFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) && fileName.Length < 7) return string.Empty;

            if (fileName.Length > 12)
            {
                string type = fileName.Substring(0, 10);
                if (type.Equals(CONST.TYPE_01_TABLE_ADD)) return CONST.STRING_01_ADD;

                type = type.Substring(0, 7);
                if (type.Equals(CONST.TYPE_01_TABLE_TYPE)) return CONST.STRING_01_TYPE;

                type = type.Substring(0, 2);
                if (type.Equals(CONST.TYPE_00_RESET_DATA)) return CONST.STRING_00;

                if (type.Equals(CONST.TYPE_02_DATA_SYSTEM)) return CONST.STRING_02;

                if (type.Equals(CONST.TYPE_03_CREATE_VIEW)) return CONST.STRING_03;

                if (type.Equals(CONST.TYPE_04_CREATE_FUNCTION)) return CONST.STRING_04;

                if (type.Equals(CONST.TYPE_05_CREATE_PROCEDURE)) return CONST.STRING_05;
            }
            return string.Empty;
        }

        /// <summary>
        /// Run command line update svn 
        /// </summary>
        /// <returns></returns>
        private void runCommandUpdateSVN()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C cd /d \"" + pathFolderDatabase + "\" && svn update \"" + pathFolderDatabase + "\"&& exit";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                process.Close();
            }
            catch
            {
                throw;
            }
        }
        #endregion

    }
}
