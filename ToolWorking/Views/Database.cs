using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ToolWorking.Model;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class Database : Form
    {
        // Database connection
        string database;
        // Path folder
        string pathFolderDatabase;
        // Dictionary result
        private Dictionary<string, string> dicResult;
        // Tree node
        private TreeNode nodeSelected;
        // Name Table 
        private string nameTable;
        // Template insert
        private string tempInsert;
        // List column in script table
        private List<ColumnModel> lstColumnTable = new List<ColumnModel>();
        private Dictionary<int, string> dicTypeInput = new Dictionary<int, string>();
        // List value input excel
        private List<string> lstInputExcel = new List<string>();

        public Database()
        {
            InitializeComponent();

            dicResult = new Dictionary<string, string>();
            tempInsert = "INSERT INTO [dbo].[{0}] VALUES ( {1} )";
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
                database = Properties.Settings.Default.database;
                string settingUser = Properties.Settings.Default.userDatabase;
                string settingPass = Properties.Settings.Default.passDatabase;
                pathFolderDatabase = Properties.Settings.Default.pathFolderDatabase;
                int mode = Properties.Settings.Default.modeDatabase;

                txtServer.Text = !string.IsNullOrEmpty(settingServer) ? settingServer : string.Empty;
                cbDatabase.SelectedIndex = !string.IsNullOrEmpty(database) ? cbDatabase.Items.IndexOf(database) : 0;
                txtUser.Text = !string.IsNullOrEmpty(settingUser) ? settingUser : string.Empty;
                txtPass.Text = !string.IsNullOrEmpty(settingPass) ? settingPass : string.Empty;
                txtPathFolder.Text = !string.IsNullOrEmpty(pathFolderDatabase) ? pathFolderDatabase : string.Empty;

                rbRunScript.Checked = true;
                if (mode != 0)
                {
                    panelQueryInput.Visible = true;
                    rbRunQuery.Checked = true;
                }
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
        /// Evemt change combobx database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            database = this.cbDatabase.GetItemText(this.cbDatabase.SelectedItem);
            Properties.Settings.Default.database = database;
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
                txtResult.Text = string.Empty;
                txtLog.Text = string.Empty;
                if (DBUtils.IsConnection())
                {
                    MessageBox.Show("Connection database: " + database + " is success.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                panelQueryInput.Visible = false;
                panelCenterScript.Visible = true;
                panelCenterQuery.Visible = false;
                chkMultiRow.Visible = false;
                lblSearchScript.Visible = true;
                txtSearchScript.Visible = true;
                btnSearchScript.Visible = true;
                lblNumRows.Visible = false;
                txtNumRow.Visible = false;
                btnRunScript.Enabled = false;
                btnRunScript.Text = "    Run Script";

                txtResult.Text = string.Empty;
                txtLog.Text = string.Empty;

                Properties.Settings.Default.modeDatabase = 0;
                Properties.Settings.Default.Save();
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
                panelQueryInput.Visible = true;
                panelCenterScript.Visible = false;
                panelCenterQuery.Visible = true;
                chkMultiRow.Visible = true;
                lblSearchScript.Visible = false;
                txtSearchScript.Visible = false;
                btnSearchScript.Visible = false;
                lblNumRows.Visible = chkMultiRow.Checked;
                lblNumScript.Visible = false;
                txtNumRow.Visible = chkMultiRow.Checked;
                btnRunScript.Enabled = false;
                btnRunScript.Text = "    Run Query";

                txtResultQuery.Text = string.Empty;

                Properties.Settings.Default.modeDatabase = 1;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Event show input value using table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbInputTable_CheckedChanged(object sender, EventArgs e)
        {
            gridInputValue.Visible = true;
            txtInputExcel.Visible = false;

            chkMultiRow.Visible = true;
            txtNumRow.Visible = chkMultiRow.Checked;
            lblNumRows.Visible = chkMultiRow.Checked;

            if (!string.IsNullOrEmpty(txtScriptTable.Text))
            {
                txtScriptTable_TextChanged(sender, e);
            }
        }

        /// <summary>
        /// Event show input value using excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbInputExcel_CheckedChanged(object sender, EventArgs e)
        {
            gridInputValue.Visible = false;
            txtInputExcel.Visible = true;
            txtInputExcel.Text = string.Empty;

            chkMultiRow.Visible = false;
            txtNumRow.Visible = false;
            lblNumRows.Visible = false;
        }

        /// <summary>
        /// Event select add text path folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPathFolder_Click(object sender, EventArgs e)
        {
            txtPathFolder.SelectAll();
            txtPathFolder.Focus();
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
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                // Setting Inital Value of Progress Bar
                progressBarFolder.Value = 0;
                // Clear All Nodes if Already Exists
                treeViewFolder.Nodes.Clear();
                dicResult.Clear();
                toolTip.ShowAlways = true;
                if (txtPathFolder.Text != "" && Directory.Exists(txtPathFolder.Text))
                {
                    CUtils.RunCommandUpdateSVN(pathFolderDatabase);

                    loadDirectory(txtPathFolder.Text);
                    txtResult.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Select Directory!!");
                }

                txtResult.Text = string.Empty;
                txtLog.Text = string.Empty;

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
        /// Event change value search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchScript_Click(object sender, EventArgs e)
        {
            txtSearchScript.SelectAll();
            txtSearchScript.Focus();
        }

        /// <summary>
        /// Event search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchScript_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string valSearch = txtSearchScript.Text.Trim();
                if (string.IsNullOrEmpty(valSearch)) return;

                foreach (TreeNode node in treeViewFolder.Nodes)
                {
                    searchNode(node, valSearch);
                }

                reloadResult();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
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
                Cursor.Current = Cursors.WaitCursor;

                if (nodeSelected.Nodes.Count > 0)
                {
                    checkNodeExits(nodeSelected);
                }
                else
                {
                    checkNodeExits(e.Node);
                }

                reloadResult();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event change text box script table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScriptTable_TextChanged(object sender, EventArgs e)
        {
            int no = 1;
            string[] arrTable = txtScriptTable.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            // handle data input
            if (arrTable.Length > 0)
            {
                lstColumnTable = new List<ColumnModel>();
                dicTypeInput = new Dictionary<int, string>();
                foreach (var item in arrTable)
                {
                    if (string.IsNullOrEmpty(item) || item.ToLower().Contains("primary key")) continue;

                    string[] arrItem;

                    if (item.ToUpper().Contains(CONST.SQL_CREATE_TABLE))
                    {
                        arrItem = item.Replace(CONST.STRING_DOT, string.Empty).Replace(CONST.STRING_C_SQU_BRACKETS, string.Empty).Replace(CONST.STRING_O_BRACKETS, string.Empty)
                            .Split(new string[] { CONST.STRING_O_SQU_BRACKETS }, StringSplitOptions.None);
                        nameTable = arrItem.Length > 2 ? arrItem[2].Trim() : null;
                        continue;
                    }

                    arrItem = item.Replace(CONST.STRING_COMMA, string.Empty).Trim().Replace(CONST.STRING_C_O_SQU_BRACKETS_SPACE, CONST.STRING_C_SQU_BRACKETS_SPACE)
                                  .Split(CONST.STRING_SEPARATORS_TABLE, StringSplitOptions.None);
                    if (arrItem.Length > 1)
                    {
                        string name = arrItem[0].Replace(CONST.STRING_O_SQU_BRACKETS, string.Empty).Replace(CONST.STRING_COMMA, string.Empty).Trim();
                        string type = arrItem[1];

                        int index = type.LastIndexOf(CONST.STRING_C_SQU_BRACKETS);
                        if (index != -1) type = type.Substring(0, index);

                        index = type.LastIndexOf(CONST.STRING_O_BRACKETS);
                        if (index != -1) type = type.Substring(0, index);

                        type = CUtils.ConvertSQLToCType(type);
                        int range = 0;
                        if (type.Equals(CONST.C_TYPE_STRING))
                        {
                            string[] arr = arrItem[1].Split(new string[] { CONST.STRING_O_BRACKETS, CONST.STRING_C_BRACKETS }, StringSplitOptions.None);
                            range = 0;
                            if (arr.Length > 1)
                            {
                                if (arr[1].ToUpper().Equals("MAX")) range = 255;
                                else range = Convert.ToInt32(arr[1]);
                            }
                            type = type + "(" + range + ")";
                        }

                        string defaultValue = CONST.STRING_NULL;
                        if (type.Contains(CONST.C_TYPE_DATE_TIME) || type.Equals(CONST.C_TYPE_TIME))
                        {
                            defaultValue = "SYSDATETIME()";
                        }
                        else if (type.Equals(CONST.C_TYPE_BOOL))
                        {
                            defaultValue = "0";
                        }
                        else if (type.Contains(CONST.C_TYPE_STRING) && (name.Contains(CONST.STRING_JP_FLAG) || name.Contains(CONST.STRING_FLAG)))
                        {
                            type = CONST.C_TYPE_BOOL;
                            defaultValue = "0";
                        }
                        else if (type.Equals(CONST.C_TYPE_BOOL)) defaultValue = "0";
                        else if (item.ToUpper().Contains(CONST.STRING_NOT_NULL))
                        {
                            if (type.Contains(CONST.C_TYPE_STRING))
                            {
                                defaultValue = addValue(range, 0) + "1";
                            }
                            else if (type.Contains(CONST.C_TYPE_DATE_TIME) || type.Equals(CONST.C_TYPE_TIME))
                            {
                                defaultValue = "SYSDATETIME()";
                            }
                            else if (type.Contains(CONST.C_TYPE_DOUBLE))
                            {
                                defaultValue = "1.0";
                            }
                            else if (type.Equals(CONST.C_TYPE_TIME_STAMP))
                            {
                                defaultValue = CONST.STRING_NULL;
                            }
                            else if (type.Equals(CONST.C_TYPE_BOOL))
                            {
                                defaultValue = "0";
                            }
                            else
                            {
                                defaultValue = "1";
                            }
                        }

                        lstColumnTable.Add(new ColumnModel(no, name, type, defaultValue, range));
                        dicTypeInput.Add(no, type);
                        no++;
                    }
                }
            }

            // add data to grid 
            if (lstColumnTable.Count > 0)
            {
                gridInputValue.DataSource = lstColumnTable;
                txtInputExcel.Enabled = true;
                btnRunScript.Enabled = true;
            }
            else
            {
                gridInputValue.DataSource = new List<ColumnModel>();
                txtInputExcel.Enabled = false;
                btnRunScript.Enabled = false;
            }
        }

        /// <summary>
        /// Event select all text in text box Input Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputExcel_Click(object sender, EventArgs e)
        {
            txtInputExcel.SelectAll();
            txtInputExcel.Focus();
        }

        /// <summary>
        /// Event change text box input excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputExcel_TextChanged(object sender, EventArgs e)
        {
            int numItem = lstColumnTable.Count;
            string[] arrTable = txtInputExcel.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            // handle data input
            if (arrTable.Length > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                lstInputExcel = new List<string>();
                foreach (var row in arrTable)
                {
                    if (string.IsNullOrEmpty(row)) continue;

                    string[] arrRow = row.Split('\t');
                    if (arrRow.Length < numItem)
                    {
                        lstInputExcel.Add(string.Empty);
                        continue;
                    }

                    string result = string.Empty;
                    for (int i = 0; i < arrRow.Length; i++)
                    {
                        string item = arrRow[i];
                        string type = string.Empty;
                        if (dicTypeInput.Count >= i + 1)
                        {
                            type = dicTypeInput[i + 1];
                        }

                        if (string.IsNullOrEmpty(item) && !type.Contains(CONST.C_TYPE_DATE_TIME) && !type.Contains(CONST.C_TYPE_TIME))
                        {
                            result += CONST.STRING_NULL + ", ";
                        }
                        else if (item.ToUpper().Equals(CONST.STRING_EMPTY) && type.Contains(CONST.C_TYPE_STRING))
                        {
                            result += "'', ";
                        }
                        else
                        {
                            result += createValue(type, item.Trim()) + ", ";
                        }
                    }

                    lstInputExcel.Add(CUtils.RemoveLastCommaSpace(result));
                }
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Event select text in text box script table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScriptTable_Click(object sender, EventArgs e)
        {
            txtScriptTable.SelectAll();
            txtScriptTable.Focus();
        }

        /// <summary>
        /// Event set value to cell table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridInputValue_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridInputValue.IsCurrentCellDirty)
            {
                gridInputValue.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Event check add multi row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMultiRow_CheckedChanged(object sender, EventArgs e)
        {
            txtNumRow.Visible = chkMultiRow.Checked;
            lblNumRows.Visible = chkMultiRow.Checked;
        }

        /// <summary>
        /// Event check valid input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumRow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Event check change value text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResult.Text))
            {
                btnRunScript.Enabled = true;
            }
            else
            {
                btnRunScript.Enabled = false;
            }
        }

        /// <summary>
        /// Event edit value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtResult_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;

            string nameFolder = pathFolderDatabase.Substring(pathFolderDatabase.LastIndexOf("\\"));
            string[] arrPaths = txtResult.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            string result = string.Empty;
            foreach (string path in arrPaths)
            {
                string tmpPath = path.Replace("/", "\\");
                if (tmpPath.Contains(CONST.STRING_TRUNK) && tmpPath.Contains(nameFolder))
                {
                    string pathKey = tmpPath.Substring(tmpPath.LastIndexOf(nameFolder));
                    string pathValue = pathFolderDatabase.Replace(nameFolder, "") + pathKey;

                    if (CUtils.dicIsExists(dicResult, pathKey))
                    {
                        dicResult.Remove(pathKey);
                    }
                    else
                    {
                        int index = pathValue.IndexOf(".sql");
                        if (index >= 0) pathValue = pathValue.Substring(0, index) + ".sql";
                        FileAttributes attr = File.GetAttributes(pathValue);
                        if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                        {
                            dicResult.Add(pathKey, pathValue);
                        }
                    }

                    result += pathValue + CONST.STRING_NEW_LINE;
                }
                else
                {
                    result += path + CONST.STRING_NEW_LINE;
                }
            }

            txtResult.Text = result;
        }

        /// <summary>
        /// Event Run Script
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunScript_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string errMessage = string.Empty;
                progressBarFolder.Value = 0;
                progressBarQuery.Value = 0;

                if (rbRunScript.Checked)
                {
                    if (string.IsNullOrEmpty(txtResult.Text)) return;

                    progressBarFolder.Maximum = dicResult.Count;

                    txtLog.Text = string.Empty;
                    foreach (KeyValuePair<string, string> entry in dicResult)
                    {
                        string fileName = CUtils.getFileName(entry.Key);
                        string path = entry.Value;
                        try
                        {
                            if (!File.Exists(path))
                            {
                                txtLog.Text += addLog(true, fileName) + "\r\nFile not exists.\r\n";
                                continue;
                            }

                            errMessage = DBUtils.ExecuteFileScript(path);
                            if (string.IsNullOrEmpty(errMessage))
                            {
                                txtLog.Text += addLog(false, fileName) + "\r\n";
                            }
                            else
                            {
                                txtLog.Text += addLog(true, fileName) + "\r\nError detail: " + errMessage + "\r\n";
                            }
                            updateProgressFolder();
                        }
                        catch (Exception ex)
                        {
                            txtLog.Text += addLog(true, fileName) + "\r\nError detail: " + ex.Message + "\r\n";
                        }
                    }

                    if (!string.IsNullOrEmpty(txtLog.Text)) btnCopyResult.Enabled = true;
                    else btnCopyResult.Enabled = false;
                }
                else if (rbRunQuery.Checked)
                {
                    txtResultQuery.Text = string.Empty;

                    string value = string.Empty;
                    if (chkMultiRow.Checked)
                    {
                        int numRow = Convert.ToInt32(txtNumRow.Text);
                        progressBarQuery.Maximum = numRow;

                        for (int i = 0; i <= numRow; i++)
                        {
                            value = getValue(i);
                            if (string.IsNullOrEmpty(value)) return;

                            value = string.Format(tempInsert, nameTable, value);
                            txtResultQuery.Text += value + "\r\n";

                            if (cbDatabase.SelectedIndex != 0) errMessage = DBUtils.ExecuteScript(value);

                            updateProgressQuery();

                            if (!string.IsNullOrEmpty(errMessage)) break;
                        }
                        if (!string.IsNullOrEmpty(errMessage))
                        {
                            MessageBox.Show("An error occurred during SQL script execution.\r\nError detail: " + errMessage, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            progressBarQuery.Value = 0;
                        }
                        else if (cbDatabase.SelectedIndex != 0)
                        {
                            MessageBox.Show("Execute inserting " + numRow + " line of data successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (rbInputExcel.Checked)
                    {
                        progressBarQuery.Maximum = lstInputExcel.Count;
                        for (int i = 0; i < lstInputExcel.Count; i++)
                        {
                            value = lstInputExcel[i];
                            if (string.IsNullOrEmpty(value))
                            {
                                txtResultQuery.Text += "Data line " + i + 1 + " entered the wrong format" + "\r\n";
                                continue;
                            }

                            value = string.Format(tempInsert, nameTable, value);
                            txtResultQuery.Text += value + "\r\n";

                            if (cbDatabase.SelectedIndex != 0) errMessage = DBUtils.ExecuteScript(value);

                            updateProgressQuery();

                            if (!string.IsNullOrEmpty(errMessage)) break;
                        }

                        if (!string.IsNullOrEmpty(errMessage))
                        {
                            MessageBox.Show("An error occurred during SQL script execution.\r\nError detail: " + errMessage, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            progressBarQuery.Value = 0;
                        }
                        else if (cbDatabase.SelectedIndex != 0)
                        {
                            MessageBox.Show("Execute inserting " + lstInputExcel.Count + " line of data successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        value = getValue(null);
                        if (string.IsNullOrEmpty(value)) return;

                        value = string.Format(tempInsert, nameTable, value);
                        txtResultQuery.Text = value;

                        if (cbDatabase.SelectedIndex != 0) errMessage = DBUtils.ExecuteScript(value);
                        if (!string.IsNullOrEmpty(errMessage))
                        {
                            MessageBox.Show("An error occurred during SQL script execution.\r\nError detail: " + errMessage, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (cbDatabase.SelectedIndex != 0)
                        {
                            MessageBox.Show("Execute inserting " + 1 + " line of data successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (!string.IsNullOrEmpty(txtResultQuery.Text)) btnCopyResult.Enabled = true;
                    else btnCopyResult.Enabled = false;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Event copy 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if (rbRunScript.Checked)
            {
                if (string.IsNullOrEmpty(txtLog.Text)) return;

                Clipboard.SetText(txtLog.Text);
            }
            else
            {
                if (string.IsNullOrEmpty(txtResultQuery.Text)) return;

                Clipboard.SetText(txtResultQuery.Text);
            }
        }

        /// <summary>
        /// Event clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearResult_Click(object sender, EventArgs e)
        {
            if (rbRunScript.Checked)
            {
                dicResult.Clear();
                txtResult.Text = string.Empty;
                txtLog.Text = string.Empty;
                btnRunScript.Enabled = false;
                btnCopyResult.Enabled = false;
                lblNumScript.Visible = false;
            }
            else if (rbRunQuery.Checked)
            {
                txtScriptTable.Text = string.Empty;
                gridInputValue.DataSource = new List<ColumnModel>();
                chkMultiRow.Checked = false;
                btnRunScript.Enabled = false;
                btnCopyResult.Enabled = false;
                txtResultQuery.Text = string.Empty;
            }
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
                updateProgressFolder();
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
                updateProgressFolder();
            }
        }

        /// <summary>
        /// Update processing progress
        /// </summary>
        private void updateProgressFolder()
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
        /// Update processing progress
        /// </summary>
        private void updateProgressQuery()
        {
            if (progressBarQuery.Value < progressBarQuery.Maximum)
            {
                progressBarQuery.Value++;
                int percent = (int)(((double)progressBarQuery.Value / (double)progressBarQuery.Maximum) * 100);
                string percentDisplay = percent < 10 ? "0" + percent.ToString() : percent.ToString();
                progressBarQuery.CreateGraphics().DrawString(percentDisplay + " %", new Font("Century Gothic", (float)10, FontStyle.Regular), Brushes.Black, new PointF(progressBarQuery.Width / 2 - 10, progressBarQuery.Height / 2 - 7));
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Search node in tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="valSearch"></param>
        /// <param name="dirRemove"></param>
        private void searchNode(TreeNode node, string valSearch)
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
                        dicResult.Add(nodeKey, nodeValue);
                    }
                }
            }

            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode actualNode in node.Nodes)
                {
                    searchNode(actualNode, valSearch);
                }
            }
        }

        /// <summary>
        /// Check exit node in tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="dirRemove"></param>
        private void checkNodeExits(TreeNode node)
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
                    dicResult.Add(nodeKey, nodeValue);
                }
            }

            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode actualNode in node.Nodes)
                {
                    checkNodeExits(actualNode);
                }
            }
        }

        /// <summary>
        /// Reload text box result
        /// </summary>
        private void reloadResult()
        {
            string result = string.Empty;
            txtResult.Text = string.Empty;
            txtLog.Text = string.Empty;

            progressBarFolder.Maximum = dicResult.Count;

            foreach (var entry in dicResult)
            {
                result += entry.Value + "\r\n";
                updateProgressFolder();
            }

            txtResult.Text = result;
            if (!string.IsNullOrEmpty(txtResult.Text))
            {
                btnRunScript.Enabled = true;
                lblNumScript.Visible = true;
                lblNumScript.Text = "Num Script Select: " + dicResult.Count;
            }
            else
            {
                btnRunScript.Enabled = false;
                lblNumScript.Visible = false;
            }
        }

        /// <summary>
        /// Create log run script
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string addLog(bool isError, string fileName)
        {
            if (isError)
            {
                return "Run Script \t" + fileName + "\t" + "Error";
            }
            else
            {
                return "Run Script \t" + fileName + "\t" + "Done";
            }
        }

        /// <summary>
        /// Add value to cell table
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        private string addValue(int range, int numIndex)
        {
            int index = 0;
            string result = string.Empty;
            int numOut = range - numIndex.ToString().Length - 1;
            numOut = numOut > 15 ? 15 : numOut;

            while (index < numOut)
            {
                result += "0";
                index++;
            }

            if (numOut >= 0) result += numIndex;
            return result;
        }

        /// <summary>
        /// Get value in cell table
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private string getValue(int? index)
        {
            string result = string.Empty;
            foreach (DataGridViewRow row in gridInputValue.Rows)
            {
                string name = row.Cells[1].Value.ToString();
                string type = row.Cells[2].Value.ToString();
                string value = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : CONST.STRING_NULL;
                int range = Convert.ToInt32(row.Cells[4].Value);

                if (isValidate(type, value, range))
                {
                    MessageBox.Show("The value of column [" + name + "] entered is incorrect, please edit and try again.", "Error Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }

                if (type.Contains(CONST.C_TYPE_STRING))
                {
                    if (value.Equals(CONST.STRING_NULL))
                    {
                        result += CONST.STRING_NULL + ", ";
                    }
                    else if (index.HasValue)
                    {
                        int _value;
                        if (int.TryParse(value, out _value))
                        {
                            _value++;

                            if (value.Length > range)
                            {
                                value = CUtils.GenerateRandomNumber(range);
                            }
                            else
                            {
                                value = _value.ToString();
                            }
                        }

                        if (value.Length < range)
                        {
                            int _range = range - value.Length;
                            value = value + CUtils.GenerateRandomNumber(_range > 5 ? 5 : _range);
                        }
                        else
                        {
                            value = CUtils.GenerateRandomNumber(range);
                        }

                        result += "'" + value + "'" + ", ";
                    }
                    else
                    {
                        result += "'" + value + "'" + ", ";
                    }
                }
                else if (type.Equals(CONST.C_TYPE_DOUBLE))
                {
                    if (value.Equals(CONST.STRING_NULL))
                    {
                        result += CONST.STRING_NULL + ", ";
                    }
                    else if (index.HasValue)
                    {
                        result += index + "." + (index % 10).ToString() + ", ";
                    }
                    else
                    {
                        result += value + ", ";
                    }
                }
                else if (type.Contains(CONST.C_TYPE_DATE_TIME) || type.Equals(CONST.C_TYPE_TIME) || type.Equals(CONST.C_TYPE_BOOL))
                {
                    result += value + ", ";
                }
                else
                {
                    if (value.Equals(CONST.STRING_NULL))
                    {
                        result += CONST.STRING_NULL + ", ";
                    }
                    else if (index.HasValue)
                    {
                        result += int.Parse(value) + index + ", ";
                    }
                    else
                    {
                        result += value + ", ";
                    }
                }
            }

            return result.Trim().TrimEnd(',');
        }

        /// <summary>
        /// Create value in data excel
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string createValue(string type, string value)
        {
            if (type.Contains(CONST.C_TYPE_STRING))
            {
                if (isValidate(type, value, value.Length)) return CONST.STRING_NULL;

                return "'" + value + "'";
            }
            else if (type.Contains(CONST.C_TYPE_DATE_TIME) || type.Contains(CONST.C_TYPE_TIME))
            {
                return "SYSDATETIME()";
            }
            else if (type.Contains(CONST.C_TYPE_TIME_STAMP))
            {
                return CONST.STRING_NULL;
            }
            else
            {
                if (isValidate(type, value, value.Length)) return "0";
                return value;
            }
        }

        /// <summary>
        /// Check validate input in table
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        private bool isValidate(string type, string value, int range)
        {
            if (value == CONST.STRING_NULL) return false;

            if (type.Contains(CONST.C_TYPE_STRING))
            {
                return value.Length > range;
            }
            else if (type.Contains(CONST.C_TYPE_DATE_TIME) || type.Contains(CONST.C_TYPE_TIME))
            {
                return value != "SYSDATETIME()";
            }
            else if (type.Contains(CONST.C_TYPE_DOUBLE))
            {
                return !Double.TryParse(value, out _);
            }
            else if (type.Contains(CONST.C_TYPE_TIME_STAMP))
            {
                return value != CONST.STRING_NULL;
            }
            else
            {
                return !int.TryParse(value, out _);
            }
        }
        #endregion

    }
}
