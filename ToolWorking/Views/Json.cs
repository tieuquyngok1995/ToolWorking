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

            string[] arrKeys = StripInputChars(txtInputKey.Text).Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            lstInputKey = new List<ColumnModel>();
            int currentLevel = 0;

            foreach (var _key in arrKeys)
            {
                if (rbModeKeys.Checked)
                {
                    string line = _key.Replace(indentCharacter, string.Empty).Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] parts = line.Split(CONST.STRING_SEPARATORS_COLUMN, StringSplitOptions.RemoveEmptyEntries);
                    string key = parts[0].Trim();
                    string type = parts.Length > 1 ? parts[1].Trim() : string.Empty;
                    if (string.IsNullOrEmpty(key)) continue;

                    int range = 1;
                    string baseType = type;

                    // Format: Array[:range[:-level]]  -- if -level omitted, level increases by 1
                    if (type.StartsWith(CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase))
                    {
                        baseType = CONST.C_TYPE_ARRAY;
                        string[] typeParts = type.Split(':');
                        if (typeParts.Length > 1 && int.TryParse(typeParts[1].Trim(), out int r) && r > 0)
                            range = r;
                        int levelDelta = typeParts.Length > 2 && int.TryParse(typeParts[2].Trim(), out int lv) ? lv : 1;
                        currentLevel = Math.Max(0, currentLevel + levelDelta);
                    }
                    else if (type.StartsWith(CONST.C_TYPE_OBJECT, StringComparison.OrdinalIgnoreCase))
                    {
                        baseType = CONST.C_TYPE_OBJECT;
                        currentLevel++;
                    }

                    lstInputKey.Add(new ColumnModel(lstInputKey.Count + 1, key, baseType, string.Empty, range, currentLevel.ToString()));
                }
                else if (rbModeJson.Checked)
                {
                    string line = _key.Replace(indentCharacter, string.Empty).Trim().TrimEnd(',');
                    if (string.IsNullOrEmpty(line)) continue;

                    // Closing brackets -> decrease level, skip
                    if (line == CONST.STRING_C_CURLY_BRACKETS || line == CONST.STRING_C_SQU_BRACKETS)
                    {
                        currentLevel = Math.Max(0, currentLevel - 1);
                        continue;
                    }

                    // Skip opening-only structural lines
                    if (line == CONST.STRING_O_CURLY_BRACKETS || line == CONST.STRING_O_SQU_BRACKETS) continue;

                    // Extract "key": value -- only key is kept, type inferred from value
                    int colonIdx = line.IndexOf("\":");
                    if (colonIdx < 0) continue;

                    int quoteStart = line.IndexOf('"');
                    string jsonKey = line.Substring(quoteStart + 1, colonIdx - quoteStart - 1).Trim();
                    string jsonValue = line.Substring(colonIdx + 2).Trim().TrimEnd(',');

                    if (string.IsNullOrEmpty(jsonKey)) continue;

                    int range = 1;
                    string baseType = CONST.C_TYPE_STRING;

                    if (jsonValue.StartsWith(CONST.STRING_O_SQU_BRACKETS))
                    {
                        // Format: [[:range][:-level]] -- if -level omitted, level increases by 1
                        baseType = CONST.C_TYPE_ARRAY;
                        int levelDelta = 1;
                        foreach (var part in jsonValue.Substring(1).Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (int.TryParse(part.Trim(), out int val))
                            {
                                if (val > 0) range = val;
                                else levelDelta = val;
                            }
                        }
                        currentLevel = Math.Max(0, currentLevel + levelDelta);
                    }
                    else if (jsonValue.StartsWith(CONST.STRING_O_CURLY_BRACKETS))
                    {
                        baseType = CONST.C_TYPE_OBJECT;
                        currentLevel++;
                    }
                    else if (jsonValue.StartsWith("\""))
                        baseType = CONST.C_TYPE_STRING;
                    else if (jsonValue.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                             jsonValue.Equals("false", StringComparison.OrdinalIgnoreCase))
                        baseType = CONST.C_TYPE_BOOLEAN;
                    else if (decimal.TryParse(jsonValue, System.Globalization.NumberStyles.Any,
                             System.Globalization.CultureInfo.InvariantCulture, out _))
                        baseType = CONST.C_TYPE_INT;

                    lstInputKey.Add(new ColumnModel(lstInputKey.Count + 1, jsonKey, baseType, string.Empty, range, currentLevel.ToString()));
                }
            }

            // Expand Array children into flat rows for grid
            var expanded = new List<ColumnModel>();
            int no = 1, idx = 0;
            while (idx < lstInputKey.Count)
            {
                var col = lstInputKey[idx];
                if (col.Type == CONST.C_TYPE_ARRAY && col.Range > 1)
                {
                    var children = new List<ColumnModel>();
                    idx++;
                    while (idx < lstInputKey.Count && lstInputKey[idx].Type != CONST.C_TYPE_ARRAY)
                        children.Add(lstInputKey[idx++]);
                    for (int r = 0; r < col.Range; r++)
                        foreach (var child in children)
                            expanded.Add(new ColumnModel(no++, col.Name + "[" + r + "]." + child.Name, child.Type, string.Empty, 1));
                }
                else
                {
                    expanded.Add(new ColumnModel(no++, col.Name, col.Type, col.Value, col.Range));
                    idx++;
                }
            }
            gridInputValue.DataSource = expanded;
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

                if (type.StartsWith(CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase))
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

                        if (childType.StartsWith(CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase) ||
                            childType.StartsWith(CONST.C_TYPE_OBJECT, StringComparison.OrdinalIgnoreCase))
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