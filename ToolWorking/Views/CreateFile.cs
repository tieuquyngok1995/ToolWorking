using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolWorking.Model;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class CreateFile : Form
    {
        // Path folder
        string pathFolderCreateFile;
        string fileNameCreate;
        int fileType;
        // List column in script table
        private List<ColumnModel> lstSetting = new List<ColumnModel>();
        BindingSource bindingSource = new BindingSource();

        public CreateFile()
        {
            InitializeComponent();
        }

        #region Event

        /// <summary>
        /// Event setting init form create file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFile_Load(object sender, EventArgs e)
        {
            try
            {
                bindingSource.DataSource = lstSetting;
                gridInputValue.AutoGenerateColumns = true;
                gridInputValue.DataSource = bindingSource;

                pathFolderCreateFile = Properties.Settings.Default.pathFolderCreateFile;
                fileType = Properties.Settings.Default.modeCreateFile;
                fileNameCreate = Properties.Settings.Default.fileNameCreate;

                txtPathFolder.Text = !string.IsNullOrEmpty(pathFolderCreateFile) ? pathFolderCreateFile : string.Empty;
                cbFileType.SelectedIndex = fileType;
                txtFileName.Text = fileNameCreate;

                txtNumRow.Enabled = false;
                lblDelimiter.Visible = fileType == 0;
                cbDelimiter.Visible = fileType == 0;
                cbDelimiter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Event change text path folder create file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPathFolder_TextChanged(object sender, EventArgs e)
        {
            pathFolderCreateFile = txtPathFolder.Text.Trim();

            if (!string.IsNullOrEmpty(pathFolderCreateFile) && !Path.IsPathRooted(pathFolderCreateFile))
            {
                MessageBox.Show("Invalid Input Folder Path!!!");
                txtPathFolder.Text = string.Empty;
                pathFolderCreateFile = string.Empty;
            }

            Properties.Settings.Default.pathFolderCreateFile = pathFolderCreateFile;
            Properties.Settings.Default.Save();

        }

        /// <summary>
        /// Event select folder create file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (!string.IsNullOrEmpty(pathFolderCreateFile)) fbd.SelectedPath = pathFolderCreateFile;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathFolder.Text = fbd.SelectedPath;
                    pathFolderCreateFile = fbd.SelectedPath;

                    Properties.Settings.Default.pathFolderCreateFile = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    txtPathFolder.Text = string.Empty;
                    pathFolderCreateFile = string.Empty;

                    Properties.Settings.Default.pathFolderCreateFile = string.Empty;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event change combobox File Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileType != cbFileType.SelectedIndex) txtFileName_Leave(sender, e);

            fileType = cbFileType.SelectedIndex;
            lblDelimiter.Visible = fileType == 0;
            cbDelimiter.Visible = fileType == 0;
            cbDelimiter.SelectedIndex = 0;

            Properties.Settings.Default.modeCreateFile = fileType;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Event leave text box File Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFileName_Leave(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text;
            if (!string.IsNullOrEmpty(fileName))
            {
                string fileType = "." + cbFileType.SelectedItem.ToString().ToLower();
                fileName = Path.GetFileNameWithoutExtension(fileName) + fileType;

                txtFileName.Text = fileName;
                fileNameCreate = fileName;
                Properties.Settings.Default.fileNameCreate = fileName;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.fileNameCreate = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Event change text setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSetting_TextChanged(object sender, EventArgs e)
        {
            string setting = txtSetting.Text.Trim();
            if (string.IsNullOrEmpty(setting))
            {
                btnCreate.Enabled = false;
                lblNumRows.Enabled = false;
                return;
            }

            string[] lines = setting.Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length < 1)
            {
                MessageBox.Show("Invalid Input Setting!!!");
                return;
            }

            string[] columnNames = lines[0].Split(CONST.STRING_SEPARATORS_COLUMN, StringSplitOptions.RemoveEmptyEntries);
            string[] columnTypes = lines.Length > 1 ? lines[1].Split(CONST.STRING_SEPARATORS_COLUMN, StringSplitOptions.RemoveEmptyEntries) : Array.Empty<string>();
            string[] columnRanges = lines.Length > 2 ? lines[2].Split(CONST.STRING_SEPARATORS_COLUMN, StringSplitOptions.RemoveEmptyEntries) : Array.Empty<string>();

            lstSetting.Clear();

            for (int i = 0; i < columnNames.Length; i++)
            {
                var typeParts = (i < columnTypes.Length ? columnTypes[i] : CONST.STRING_TEXT1).Trim().Split('|');
                string type = typeParts[0];
                string excludeChars = typeParts.Length > 1 ? typeParts[1] : string.Empty;
                int range = (i < columnRanges.Length && int.TryParse(columnRanges[i], out int r)) ? r : 1;
                string generatedValue = CUtils.GenerateRandomValue(ref type, range, excludeChars);

                lstSetting.Add(new ColumnModel(i + 1, columnNames[i].Trim(), type, generatedValue, range, excludeChars));
            }

            if (lstSetting.Count > 0)
            {
                if (bindingSource.DataSource == null)
                    bindingSource.DataSource = lstSetting;

                bindingSource.ResetBindings(false);
                txtNumRow.Enabled = true;
                btnCreate.Enabled = true;
            }
        }

        private void txtNumRow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int numRows = !string.IsNullOrEmpty(txtNumRow.Text) ? int.Parse(txtNumRow.Text) : 1;
            string filePath = Path.Combine(pathFolderCreateFile, fileNameCreate);

            progressBar.Maximum = numRows;

            try
            {
                if (fileType == 0)
                {
                    string delimiter = cbDelimiter.SelectedIndex == 0 ? CONST.STRING_TAB : cbDelimiter.SelectedIndex == 1 ? CONST.STRING_COMMA : CONST.STRING_SEMICOLON;
                    using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        // write header (name)
                        writer.WriteLine(string.Join(delimiter, lstSetting.Select(col => col.Name)));

                        // write data
                        writer.WriteLine(string.Join(delimiter, lstSetting.Select(col => col.Value).ToArray()));
                        for (int i = 1; i < numRows; i++)
                        {
                            string[] rowValues = lstSetting.Select(col =>
                            {
                                string type = col.Type;
                                return CUtils.GenerateRandomValue(ref type, col.Range, col.ExcludeChars);
                            }).ToArray();

                            writer.WriteLine(string.Join(delimiter, rowValues));
                            updateProgress();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create CSV file.\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            txtSetting.Text = string.Empty;
            lstSetting.Clear();
            bindingSource.ResetBindings(false);
            txtNumRow.Text = string.Empty;
            txtNumRow.Enabled = false;
            btnCreate.Enabled = false;
        }

        #endregion

        /// <summary>
        /// Update processing progress
        /// </summary>
        private void updateProgress()
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(updateProgress));
                return;
            }

            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value++;
                progressBar.Refresh();
            }
        }
    }
}
