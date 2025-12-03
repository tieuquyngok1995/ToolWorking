using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class Format : Form
    {
        private Encoding sjis = Encoding.GetEncoding("Shift_JIS");
        // Path folder
        int modeFormatFile;
        string pathFolderFormatFile;
        string fileNameFormat;
        // List content file
        private List<string> listContent = new List<string>();

        public Format()
        {
            InitializeComponent();
        }

        #region Event

        /// <summary>
        /// Event setting init form create file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Format_Load(object sender, EventArgs e)
        {
            try
            {
                pathFolderFormatFile = Properties.Settings.Default.pathFolderFormatFile;
                modeFormatFile = Properties.Settings.Default.modeFormatFile;
                fileNameFormat = Properties.Settings.Default.fileNameFormat;

                txtPathFolder.Text = !string.IsNullOrEmpty(pathFolderFormatFile) ? pathFolderFormatFile : string.Empty;
                cbFileType.SelectedIndex = modeFormatFile;
                txtFileName.Text = fileNameFormat;
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
            pathFolderFormatFile = txtPathFolder.Text.Trim();

            if (!string.IsNullOrEmpty(pathFolderFormatFile) && !Path.IsPathRooted(pathFolderFormatFile))
            {
                MessageBox.Show("Invalid Input Folder Path!!!");
                txtPathFolder.Text = string.Empty;
                pathFolderFormatFile = string.Empty;
            }

            Properties.Settings.Default.pathFolderFormatFile = pathFolderFormatFile;
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
                if (!string.IsNullOrEmpty(pathFolderFormatFile)) fbd.SelectedPath = pathFolderFormatFile;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathFolder.Text = fbd.SelectedPath;
                    pathFolderFormatFile = fbd.SelectedPath;

                    Properties.Settings.Default.pathFolderFormatFile = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    txtPathFolder.Text = string.Empty;
                    pathFolderFormatFile = string.Empty;

                    Properties.Settings.Default.pathFolderFormatFile = string.Empty;
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
            if (modeFormatFile != cbFileType.SelectedIndex) txtFileName_Leave(sender, e);

            modeFormatFile = cbFileType.SelectedIndex;

            Properties.Settings.Default.modeFormatFile = modeFormatFile;
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
                string modeFormatFile = "." + cbFileType.SelectedItem.ToString().ToLower();
                fileName = Path.GetFileNameWithoutExtension(fileName) + modeFormatFile;

                txtFileName.Text = fileName;
                fileNameFormat = fileName;
                Properties.Settings.Default.fileNameFormat = fileName;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.fileNameFormat = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Event load file source structure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathFolderFormatFile) || !Directory.Exists(pathFolderFormatFile))
            {
                MessageBox.Show("Please select a valid folder path to load the source file.", "Invalid Folder Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(fileNameFormat))
            {
                MessageBox.Show("Please enter a valid file name to load the source file.", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullFilePath = Path.Combine(pathFolderFormatFile, fileNameFormat);
            if (!File.Exists(fullFilePath))
            {
                MessageBox.Show($"The file '{fileNameFormat}' does not exist in the selected folder.",
                                "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (var line in File.ReadLines(fullFilePath))
                {
                    listContent.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}",
                                "Read File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSource_Click(object sender, EventArgs e)
        {
            txtSource.SelectAll();
            txtSource.Focus();
        }

        /// <summary>
        /// Event change text setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string setting = txtSource.Text.Trim();
                if (string.IsNullOrEmpty(setting))
                {
                    btnFormat.Enabled = false;
                    btnCopyResult.Enabled = false;
                    return;
                }

                int maxDec = 0;
                int maxVar = 0;
                int maxType = 0;
                int maxAssign = 0;

                List<string> result = new List<string>();
                var dict = new Dictionary<string, (string dec, string var, string type, string assign, string comment)>();

                string[] lines = setting.Split(CONST.STRING_SEPARATORS_ROWS, StringSplitOptions.None);
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (line.ToUpper().Contains(CONST.SQL_TYPE_DECLARE) &&
                        !line.ToUpper().Contains("TABLE"))
                    {
                        string comment = "";
                        int commentIdx = line.IndexOf("--");
                        if (commentIdx >= 0)
                        {
                            comment = line.Substring(commentIdx).Trim();
                            line = line.Substring(0, commentIdx).TrimEnd();
                        }

                        string assign = "";
                        int eqIndex = line.IndexOf('=');
                        if (eqIndex >= 0)
                        {
                            assign = line.Substring(eqIndex).Trim();
                            line = line.Substring(0, eqIndex).TrimEnd();
                        }

                        string[] parts = line.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

                        string dec = parts.Length > 0 ? parts[0] : "";
                        string var = parts.Length > 1 ? parts[1] : "";
                        string type = "";

                        if (parts.Length > 2)
                        {
                            type = string.Join(" ", parts.Skip(2));
                        }

                        type = type.Replace(" ", string.Empty);
                        if (string.IsNullOrEmpty(comment))
                        {
                            type = type.TrimEnd(';') + ";";
                        }

                        dict.Add($"row{i}", (dec, var, type, assign, comment));
                        result.Add($"row{i}");

                        maxDec = Math.Max(maxDec, dec.Length);
                        maxVar = Math.Max(maxVar, var.Length);
                        maxType = Math.Max(maxType, type.Length);
                        maxAssign = Math.Max(maxAssign, sjis.GetByteCount(assign));
                    }
                    else
                    {
                        result.Add(line);
                    }
                }


                int rowNum = 0;
                listContent.Clear();
                foreach (var line in result)
                {
                    if (line.Equals($"row{rowNum}"))
                    {
                        var item = dict[$"row{rowNum}"];

                        string dec = item.dec.TrimEnd().PadRight(maxDec + 1);
                        string var = item.var.TrimEnd().PadRight(maxVar + 1);
                        string type = item.type.TrimEnd().PadRight(maxType + 1);

                        string assign = maxAssign == 0
                            ? ""
                            : item.assign.TrimEnd().PadRight(maxAssign + 1);

                        string comment = string.IsNullOrEmpty(item.comment)
                            ? ""
                            : item.comment;

                        listContent.Add((assign.Length > 0
                            ? $"{dec}{var}{type}{assign}{comment}"
                            : $"{dec}{var}{type}{comment}").TrimEnd());
                    }
                    else if (string.IsNullOrWhiteSpace(line))
                    {
                        listContent.Add(string.Empty);
                    }
                    else
                    {
                        listContent.Add(line);
                    }
                    rowNum++;
                }
                btnFormat.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error get source structure format: {ex.Message}",
                                "Source Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            try
            {
                bool isCreatePr = false;
                bool isSelect = false;
                bool isFrom = false;
                bool isJoin = false;
                bool isWhere = false;

                int indentLevel = 0;
                string result = string.Empty;
                string _line = string.Empty;
                string tab = "    ";

                foreach (var line in listContent)
                {
                    if (modeFormatFile == 0)
                    {
                        _line = CUtils.toUpperKeySQL(line).Trim();

                        if (_line.StartsWith("END"))
                        {
                            indentLevel = Math.Max(0, indentLevel - 1);
                        }
                        else if (_line.StartsWith("DROP PROCEDURE"))
                        {
                            indentLevel = Math.Max(0, indentLevel - 1);
                        }
                        else if (isCreatePr && _line.Trim().Equals("AS"))
                        {
                            indentLevel = Math.Max(0, indentLevel - 1);
                        }
                        else if (isSelect && _line.Contains("INTO"))
                        {
                            isSelect = false;
                            indentLevel = Math.Max(0, indentLevel - 1);
                        }
                        else if (isSelect && _line.Contains("FROM"))
                        {
                            isSelect = false;
                            indentLevel = Math.Max(0, indentLevel - 1);
                        }
                        else if (isJoin && _line.Contains("WHERE"))
                        {
                            isJoin = false;
                            indentLevel = Math.Max(0, indentLevel - 1);
                        }
                        else if (isWhere && _line.Contains("GROUP BY") ||
                            isWhere && _line.Trim().Equals(")") ||
                            isWhere && !_line.Contains("AND"))
                        {
                            isWhere = false;
                            indentLevel = Math.Max(0, indentLevel - 1);
                        }

                        string indentedLine = new string(' ', indentLevel * 4) + _line;
                        result += indentedLine + Environment.NewLine;

                        if (_line.StartsWith("BEGIN") || _line.StartsWith("IF EXISTS"))
                        {
                            indentLevel++;
                        }
                        else if (_line.StartsWith("CREATE PROCEDURE"))
                        {
                            isCreatePr = true;
                            indentLevel++;
                        }
                        else if (_line.Contains("SELECT"))
                        {
                            isSelect = true;
                            indentLevel++;
                        }
                        else if (_line.Contains("FROM") && _line.Contains(CONST.STRING_DBO))
                        {
                            isFrom = true;
                        }
                        else if (isFrom && (_line.Contains("INNER JOIN") ||
                            _line.Contains("LEFT JOIN") ||
                            _line.Contains("RIGHT JOIN")))
                        {
                            isJoin = true;
                            indentLevel++;
                        }
                        else if (_line.Contains("WHERE"))
                        {
                            isWhere = true;
                            indentLevel++;
                        }
                    }
                }

                txtResult.Text = result;
                btnCopyResult.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to format source.\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;

            Clipboard.SetText(txtResult.Text);
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            txtSource.Text = string.Empty;
            txtResult.Text = string.Empty;
            btnFormat.Enabled = false;
            btnCopyResult.Enabled = false;
        }
        #endregion
    }
}
