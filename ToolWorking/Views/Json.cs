using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolWorking.Model;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class Json : Form
    {
        bool isInputKey;

        string indentCharacter = string.Empty;

        List<ColumnModel> lstInputKey;
        List<string> lstInputValue;

        public Json()
        {
            InitializeComponent();
        }

        #region Event
        private void Json_Load(object sender, EventArgs e)
        {
            try
            {
                int mode = Properties.Settings.Default.JsonModel;
                indentCharacter = Properties.Settings.Default.JsonIndent;

                if (mode == 0) rbInput.Checked = true; else rbModeJson.Checked = true;

                txtIndent.Text = !string.IsNullOrEmpty(indentCharacter) ? indentCharacter : string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbInput_CheckedChanged(object sender, EventArgs e)
        {
            panelInput.Visible = rbInput.Checked;
            // Save mode
            Properties.Settings.Default.JsonModel = 0;
            Properties.Settings.Default.Save();
        }

        private void rbOutput_CheckedChanged(object sender, EventArgs e)
        {
            // Save mode
            Properties.Settings.Default.JsonModel = 1;
            Properties.Settings.Default.Save();
        }

        private void rbModeKeys_CheckedChanged(object sender, EventArgs e)
        {
            isInputKey = true;
            groupInputKey.Text = "Input Keys";
        }

        private void rbModeJson_CheckedChanged(object sender, EventArgs e)
        {
            isInputKey = false;
            groupInputKey.Text = "Input JSON";
        }

        private void txtIndent_TextChanged(object sender, EventArgs e)
        {
            indentCharacter = string.IsNullOrEmpty(txtIndent.Text) ? string.Empty : txtIndent.Text.Trim();
            // Save indent
            Properties.Settings.Default.JsonIndent = indentCharacter;
            Properties.Settings.Default.Save();
        }

        private void txtInputKey_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInputKey.Text)) return;

            string rawInput = StripInputChars(txtInputKey.Text);
            string[] arrKeys = rawInput.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            lstInputKey = new List<ColumnModel>();
            if (arrKeys.Length > 0)
            {
                int currentLevel = 0;
                foreach (var _key in arrKeys)
                {
                    if (rbModeKeys.Checked)
                    {
                        string line = string.IsNullOrEmpty(indentCharacter) ? _key.Trim() : _key.Replace(indentCharacter, string.Empty).Trim();

                        if (string.IsNullOrEmpty(line)) continue;

                        string[] parts = line.Split(CONST.STRING_SEPARATORS_COLUMN, StringSplitOptions.RemoveEmptyEntries);
                        string key = parts[0].Trim();
                        string type = parts.Length > 1 ? parts[1].Trim() : string.Empty;

                        if (string.IsNullOrEmpty(key)) continue;

                        int range = 1;
                        string baseType = type;
                        if (type.ToUpper().IndexOf("ARRAY", StringComparison.OrdinalIgnoreCase) >= 0 && type.Contains(":"))
                        {
                            string rangeText = type.Split(':')[1].Trim();
                            if (int.TryParse(rangeText, out int r) && r > 0) range = r;
                            baseType = "Array";
                        }
                        else if (type.ToUpper().StartsWith("ARRAY", StringComparison.OrdinalIgnoreCase))
                        {
                            baseType = "Array";
                        }
                        else if (type.ToUpper().StartsWith("OBJECT", StringComparison.OrdinalIgnoreCase))
                        {
                            baseType = "Object";
                        }

                        bool isStructural = baseType == "Array" || baseType == "Object";
                        if (isStructural)
                        {
                            if (type.Contains(":"))
                            {
                                string afterColon = type.Split(':')[1].Trim();
                                if (int.TryParse(afterColon, out int levelAdj) && levelAdj < 0)
                                    currentLevel = Math.Max(0, currentLevel + levelAdj);
                                else
                                    currentLevel++;
                            }
                            else
                            {
                                currentLevel++;
                            }
                        }

                        lstInputKey.Add(new ColumnModel(lstInputKey.Count + 1, key, baseType, string.Empty, range, currentLevel.ToString()));
                    }
                    else if (rbModeJson.Checked)
                    {

                    }

                    //    string key = _key.Trim().Replace("  ", string.Empty);
                    //if (string.IsNullOrEmpty(key) ||
                    //    (!isInputKey && (key.Equals("[") || key.Equals("{") || key.Equals("}")))) continue;

                    //if (isInputKey)
                    //{
                    //    lstInputKey.Add(key.Replace(indentCharacter, string.Empty));
                    //}
                    //else
                    //{
                    //    key = key.Replace("\"", "").Replace(",", string.Empty);
                    //    key = (key.Contains("[") || key.Contains("{")) ? key : key.Replace(":", string.Empty).Trim();
                    //    lstInputKey.Add(key.Replace(indentCharacter, string.Empty));
                    //}
                }
            }


            gridInputValue.DataSource = new List<ColumnModel>();
            if (lstInputKey.Count > 0)
            {
                var expanded = new List<ColumnModel>();
                int no = 1;
                int idx = 0;
                while (idx < lstInputKey.Count)
                {
                    var col = lstInputKey[idx];
                    if (col.Type == "Array" && col.Range > 1)
                    {
                        var children = new List<ColumnModel>();
                        idx++;
                        while (idx < lstInputKey.Count)
                        {
                            var child = lstInputKey[idx];
                            if (child.Type == "Array") break;
                            children.Add(child);
                            idx++;
                        }
                        for (int r = 0; r < col.Range; r++)
                        {
                            foreach (var child in children)
                                expanded.Add(new ColumnModel(no++, col.Name + "[" + r + "]." + child.Name, child.Type, string.Empty, 1));
                        }
                    }
                    else
                    {
                        expanded.Add(new ColumnModel(no++, col.Name, col.Type, col.Value, col.Range));
                        idx++;
                    }
                }
                gridInputValue.DataSource = expanded;
            }
        }

        private void txtInputValue_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Function
        private List<ColumnModel> ParseKeysModeLines(string[] lines)
        {
            var result = new List<ColumnModel>();
            int no = 1;
            int i = 0;

            while (i < lines.Length)
            {
                string line = lines[i].Trim().Replace(indentCharacter, string.Empty).Trim();
                if (string.IsNullOrEmpty(line)) { i++; continue; }

                string[] parts = line.Split(CONST.STRING_SEPARATORS_COLUMN, StringSplitOptions.None);
                string key = parts[0].Trim();
                string type = parts.Length > 1 ? parts[1].Trim() : string.Empty;

                if (string.IsNullOrEmpty(key)) { i++; continue; }

                if (type.StartsWith("Array", StringComparison.OrdinalIgnoreCase))
                {
                    int range = 1;
                    if (type.Contains(":"))
                    {
                        string rangeText = type.Split(':')[1].Trim();
                        if (int.TryParse(rangeText, out int r) && r > 0) range = r;
                    }

                    result.Add(new ColumnModel(no++, key, type, string.Empty, range));

                    // Collect children until next Array/Object or end of input
                    var children = new List<string[]>();
                    i++;
                    while (i < lines.Length)
                    {
                        string childLine = lines[i].Trim().Replace(indentCharacter, string.Empty).Trim();
                        if (string.IsNullOrEmpty(childLine)) { i++; continue; }

                        string[] childParts = childLine.Split(CONST.STRING_SEPARATORS_COLUMN, StringSplitOptions.None);
                        string childKey = childParts[0].Trim();
                        string childType = childParts.Length > 1 ? childParts[1].Trim() : string.Empty;

                        if (childType.StartsWith("Array", StringComparison.OrdinalIgnoreCase) ||
                            childType.StartsWith("Object", StringComparison.OrdinalIgnoreCase))
                            break;

                        if (!string.IsNullOrEmpty(childKey))
                            children.Add(new[] { childKey, childType });
                        i++;
                    }

                    // Expand range × children into flat rows
                    for (int idx = 0; idx < range; idx++)
                    {
                        foreach (var child in children)
                            result.Add(new ColumnModel(no++, "[" + idx + "]" + child[0], child[1], string.Empty, 1));
                    }
                }
                else
                {
                    result.Add(new ColumnModel(no++, key, type, string.Empty, 1));
                    i++;
                }
            }

            return result;
        }

        private string StripInputChars(string input)
        {
            if (string.IsNullOrEmpty(txtIndent.Text)) return input;

            string[] stripItems = txtIndent.Text.Split(',');
            foreach (var item in stripItems)
            {
                string stripChar = item.Trim();
                if (!string.IsNullOrEmpty(stripChar))
                    input = input.Replace(stripChar, string.Empty);
            }
            return input;
        }

        #endregion

    }
}