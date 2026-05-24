using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ToolWorking.Model;
using ToolWorking.Utils;

namespace ToolWorking.Views
{
    public partial class Json : Form
    {
        static readonly Random _rnd = new Random();

        bool isInputKey;
        string indentCharacter = string.Empty;

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

                if (mode == 0)
                {
                    rbInput.Checked = true;
                    isInputKey = true;
                }
                else
                {
                    rbModeJson.Checked = true;
                }
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
            // Reset grid 
            txtInputKey_TextChanged(sender, e);
        }

        private void rbModeJson_CheckedChanged(object sender, EventArgs e)
        {
            isInputKey = false;
            groupInputKey.Text = "Input JSON";
            // Reset grid 
            txtInputKey_TextChanged(sender, e);
        }

        private void txtIndent_MouseClick(object sender, MouseEventArgs e)
        {
            txtIndent.SelectAll();
        }

        private void txtIndent_TextChanged(object sender, EventArgs e)
        {
            indentCharacter = string.IsNullOrEmpty(txtIndent.Text) ? string.Empty : txtIndent.Text.Trim();
            txtInputKey_TextChanged(sender, e);
            // Save indent
            Properties.Settings.Default.JsonIndent = indentCharacter;
            Properties.Settings.Default.Save();
        }

        private void txtInputKey_MouseClick(object sender, MouseEventArgs e)
        {
            txtInputKey.SelectAll();
        }

        private void txtInputKey_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInputKey.Text))
                {
                    gridInputValue.DataSource = new List<ColumnModel>();
                    btnCreate.Enabled = false;
                    return;
                }

                string[] arrKeys = StripInputChars(txtInputKey.Text).Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

                int levelDelta, currentLevel = 0, range = 0;
                string line, key, type, baseType, value;
                string[] arrLine, arrType;
                List<ColumnModel> lstInputKey = new List<ColumnModel>();

                for (int i = 0; i < arrKeys.Length; i++)
                {
                    line = arrKeys[i].Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    line = string.IsNullOrEmpty(indentCharacter) ? line.TrimEnd(',') : line.Replace(indentCharacter, string.Empty).TrimEnd(',');
                    if (isInputKey)
                    {
                        arrLine = line.Split(CONST.STRING_SEPARATORS_COLUMN, StringSplitOptions.RemoveEmptyEntries);
                        key = arrLine[0].Trim();
                        type = arrLine.Length > 1 ? arrLine[1].Trim() : string.Empty;
                        if (string.IsNullOrEmpty(key)) continue;

                        range = 1;
                        baseType = type;

                        if (type.StartsWith(CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase))
                        {
                            baseType = CONST.C_TYPE_ARRAY;
                            arrType = type.Split(CONST.CHAR_COLON);
                            levelDelta = 1;

                            if (arrType.Length > 1 && int.TryParse(arrType[1].Trim(), out int inRange))
                            {
                                if (inRange > 0)
                                {
                                    range = inRange;
                                    levelDelta = arrType.Length > 2 && int.TryParse(arrType[2].Trim(), out int inLevel)
                                        ? inLevel : 1;
                                }
                                else if (inRange < 0)
                                {
                                    levelDelta = inRange;
                                }
                            }
                            else if (arrType.Length > 1)
                            {
                                // String Array (e.g. Array:string) -- no children, don't increase level
                                levelDelta = 0;
                            }
                            else
                            {
                                // Check if next non-empty item is also an Array -> no children, don't increase level
                                bool isLast = i == arrKeys.Length - 1;
                                bool nextIsArray = !isLast && arrKeys[i + 1].ToUpper().Contains(CONST.STRING_ARRAY);

                                baseType = (isLast || nextIsArray) ? CONST.C_TYPE_STRING_ARRAY : CONST.C_TYPE_ARRAY;
                                levelDelta = (isLast || nextIsArray) ? 0 : 1;
                            }

                            if (levelDelta < 0) currentLevel = Math.Max(0, currentLevel + levelDelta);
                            lstInputKey.Add(new ColumnModel(lstInputKey.Count + 1, key, baseType, string.Empty, range, currentLevel.ToString()));
                            currentLevel = Math.Max(0, currentLevel + 1);
                        }
                        else if (type.StartsWith(CONST.C_TYPE_OBJECT, StringComparison.OrdinalIgnoreCase))
                        {
                            baseType = CONST.C_TYPE_OBJECT;
                            lstInputKey.Add(new ColumnModel(lstInputKey.Count + 1, key, baseType, string.Empty, range, currentLevel.ToString()));
                            currentLevel++;
                        }
                        else if (type.StartsWith(CONST.C_TYPE_STRING_ARRAY, StringComparison.OrdinalIgnoreCase))
                        {
                            baseType = CONST.C_TYPE_STRING_ARRAY;
                            lstInputKey.Add(new ColumnModel(lstInputKey.Count + 1, key, baseType, string.Empty, range, currentLevel.ToString()));
                        }
                        else
                        {
                            arrType = type.Split(CONST.CHAR_COLON);
                            if (arrType.Length > 1 && int.TryParse(arrType[1].Trim(), out int inRange))
                            {
                                baseType = arrType[0].Trim();
                                if (inRange < 0) currentLevel = Math.Max(0, currentLevel + inRange);
                            }
                            lstInputKey.Add(new ColumnModel(lstInputKey.Count + 1, key, baseType, string.Empty, range, currentLevel.ToString()));
                        }
                    }
                    else
                    {
                        // Closing brackets -> decrease level, skip
                        if (line == CONST.STRING_C_CURLY_BRACKETS)
                        {
                            bool isLast = i == arrKeys.Length - 1;
                            bool nextIsOject = !isLast && arrKeys[i + 1].Trim().Contains(CONST.STRING_O_CURLY_BRACKETS);
                            if (!nextIsOject) currentLevel = Math.Max(0, currentLevel - 1);
                            continue;
                        }

                        // Skip opening-only structural lines
                        if (line == CONST.STRING_O_CURLY_BRACKETS || line == CONST.STRING_C_SQU_BRACKETS) continue;

                        // Extract "key": value -- only key is kept, type inferred from value
                        arrLine = line.Replace("\"", string.Empty).Trim().Split(CONST.STRING_SEPARATORS_COLON, StringSplitOptions.RemoveEmptyEntries);
                        key = arrLine[0].Trim();
                        value = arrLine.Length > 1 ? arrLine[1].Trim() : string.Empty;

                        if (string.IsNullOrEmpty(key)) continue;

                        range = 1;
                        levelDelta = 0;
                        baseType = CONST.C_TYPE_STRING;

                        if (value.StartsWith(CONST.STRING_O_SQU_BRACKETS) && value.Contains(CONST.STRING_C_SQU_BRACKETS))
                        {
                            baseType = CONST.C_TYPE_STRING_ARRAY;
                        }
                        else if (value.StartsWith(CONST.STRING_O_SQU_BRACKETS))
                        {
                            levelDelta = 1;
                            baseType = CONST.C_TYPE_ARRAY;

                            if (int.TryParse(value.Replace(CONST.STRING_O_SQU_BRACKETS, string.Empty).Trim(), out int inRange))
                            {
                                range = inRange;
                            }
                        }
                        else if (value.StartsWith(CONST.STRING_O_CURLY_BRACKETS))
                        {
                            levelDelta = 1;
                            baseType = CONST.C_TYPE_OBJECT;
                        }
                        else if (value.Equals(CONST.STRING_TRUE, StringComparison.OrdinalIgnoreCase) ||
                                 value.Equals(CONST.STRING_FALSE, StringComparison.OrdinalIgnoreCase))
                        {
                            baseType = CONST.C_TYPE_BOOLEAN;
                        }
                        else if (int.TryParse(value, out _))
                        {
                            baseType = CONST.C_TYPE_INT;
                        }

                        lstInputKey.Add(new ColumnModel(lstInputKey.Count + 1, key, baseType, string.Empty, range, currentLevel.ToString()));
                        currentLevel = currentLevel + levelDelta;
                    }
                }

                // Expand Array children into flat rows for grid
                int no = 1, idx = 0;
                List<ColumnModel> dataGrid = new List<ColumnModel>();
                while (idx < lstInputKey.Count)
                {
                    var col = lstInputKey[idx++];
                    // Collect children until next ARRAY column
                    if (col.Type != CONST.C_TYPE_ARRAY || col.Range <= 1)
                    {
                        dataGrid.Add(new ColumnModel(no++, col.Name, col.Type, col.Value, col.Range, col.ExcludeChars));
                        continue;
                    }

                    dataGrid.Add(new ColumnModel(no++, col.Name, col.Type, col.Value, col.Range, col.ExcludeChars));

                    var childStart = idx;
                    var lv = lstInputKey[idx].ExcludeChars;
                    while (idx < lstInputKey.Count && lstInputKey[idx].Type != CONST.C_TYPE_ARRAY && lstInputKey[idx].ExcludeChars == lv)
                        idx++;

                    var children = lstInputKey.GetRange(childStart, idx - childStart);

                    // Pre-allocate capacity to avoid resizing
                    dataGrid.Capacity = dataGrid.Count + col.Range * children.Count;

                    for (int row = 0; row < col.Range; row++)
                        foreach (var child in children)
                            dataGrid.Add(new ColumnModel(no++, $"{col.Name}[{row}].{child.Name}", child.Type, string.Empty, 1, child.ExcludeChars));
                }
                gridInputValue.DataSource = dataGrid;
                btnCreate.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridInputValue_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in gridInputValue.Rows)
            {
                string type = row.Cells[2].Value?.ToString();

                if (string.Equals(type,
                        CONST.C_TYPE_ARRAY,
                        StringComparison.OrdinalIgnoreCase))
                {
                    row.Cells[3].ReadOnly = true;
                }
            }

        }

        private void gridInputValue_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (gridInputValue.Columns[e.ColumnIndex].Name == "key")
            {
                e.ToolTipText = gridInputValue[e.ColumnIndex, e.RowIndex].Value?.ToString() ?? string.Empty;
            }
            else if (gridInputValue.Columns[e.ColumnIndex].Name == "value")
            {
                e.ToolTipText =
@"XXX = Random letters (e.g. TESTXXX -> TESTABC)
YYY = Random numbers (e.g. 999YYY -> ABC123)
A|B|C = Random value from list (e.g. -> B)";
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!(gridInputValue.DataSource is List<ColumnModel> gridData) || gridData.Count == 0) return;

            gridInputValue.CommitEdit(DataGridViewDataErrorContexts.Commit);
            gridInputValue.EndEdit();

            var errors = new List<string>();
            foreach (var row in gridData)
            {
                if (string.IsNullOrEmpty(row.Name)) continue;

                string val = row.Value?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(val))
                {
                    row.Value = GetDefaultGridValue(row.Type);
                    continue;
                }

                val = ResolveRandomValue(val);

                if (!ValidateAndNormalizeValue(row.Type, val, out string normalized, out string error))
                    errors.Add("no:" + row.No + " - " + row.Name + " - " + error);
                else
                    row.Value = normalized;
            }

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\r\n", errors), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = 0;
            gridInputValue.Refresh();
            txtResult.Text = BuildJsonObject(gridData, ref index, -1, 0, string.Empty);

            if (string.IsNullOrEmpty(txtResult.Text))
            {
                btnCopyResult.Enabled = false;
            }
            else
            {
                btnCopyResult.Enabled = true;
            }
        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;

            Clipboard.SetText(txtResult.Text);
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            txtInputKey.Text = string.Empty;
            txtResult.Text = string.Empty;

            btnCreate.Enabled = false;
            btnCopyResult.Enabled = false;

            gridInputValue.DataSource = new List<ColumnModel>();
        }
        #endregion

        #region Function
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

        private string GetDefaultGridValue(string type)
        {
            if (string.Equals(type, CONST.C_TYPE_INT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_LONG, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_SHORT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DECIMAL, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DOUBLE, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_NUMERIC, StringComparison.OrdinalIgnoreCase))
                return "0";

            if (string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_BIT, StringComparison.OrdinalIgnoreCase))
                return "false";

            if (string.Equals(type, CONST.C_TYPE_STRING_ARRAY, StringComparison.OrdinalIgnoreCase))
                return "[]";

            return string.Empty;
        }

        private string ResolveRandomValue(string val)
        {
            if (string.IsNullOrEmpty(val)) return val;

            // Pipe: randomly pick one of the options separated by |
            if (val.Contains("|"))
            {
                string[] options = val.Split('|');
                return options[_rnd.Next(options.Length)].Trim();
            }

            // XXX: random alphanumeric string of N chars X
            int countChars = val.Count(c => c == 'X');
            if (val.Contains("XX") && countChars >= 2)
            {
                string _type = CONST.STRING_TEXT1;
                return val.Replace("X", string.Empty) + CUtils.GenerateRandomValue(ref _type, countChars);
            }

            // YYY: random N-digit number of N chars Y
            countChars = val.Count(c => c == 'Y');
            if (val.Contains("YY") && countChars >= 2)
            {
                return val.Replace("Y", string.Empty) + CUtils.GenerateRandomNumber(countChars);
            }

            return val;
        }

        private bool ValidateAndNormalizeValue(string type, string value, out string normalized, out string error)
        {
            normalized = value;
            error = string.Empty;
            string _value = value.Trim();

            // Numeric
            if (string.Equals(type, CONST.C_TYPE_INT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_LONG, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_SHORT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DECIMAL, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DOUBLE, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_NUMERIC, StringComparison.OrdinalIgnoreCase))
            {
                if (!decimal.TryParse(value, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out _))
                {
                    error = "Invalid number format.";
                    return false;
                }
                return true;
            }

            // Boolean / Bit
            if (string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_BIT, StringComparison.OrdinalIgnoreCase))
            {
                _value = value.ToLower();
                if (_value != "true" && _value != "false" && _value != "1" && _value != "0")
                {
                    error = "Invalid boolean format.";
                    return false;
                }
                normalized = (_value == "true" || _value == "1") ? "true" : "false";
                return true;
            }

            // Date
            if (string.Equals(type, CONST.C_TYPE_DATE, StringComparison.OrdinalIgnoreCase))
            {
                string[] formats = { "yyyy/MM/dd", "yyyy-MM-dd" };
                if (!DateTime.TryParseExact(value, formats,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    error = "Invalid date format.";
                    return false;
                }
                normalized = dt.ToString("yyyy/MM/dd");
                return true;
            }

            // DateTime / Timestamp
            if (string.Equals(type, CONST.C_TYPE_DATE_TIME, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.SQL_TYPE_DATE_TIME, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_TIME_STAMP, StringComparison.OrdinalIgnoreCase))
            {
                string[] formats = { "yyyy/MM/dd", "yyyy-MM-dd",
                    "yyyy/MM/dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss",
                    "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-ddTHH:mm:sszzz" };
                if (!DateTimeOffset.TryParseExact(value, formats,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTimeOffset dt))
                {
                    error = "Invalid datetime format.";
                    return false;
                }
                normalized = dt.ToString("yyyy-MM-ddTHH:mm:ss") + "+09:00";
                return true;
            }

            // Array
            if (string.Equals(type, CONST.C_TYPE_STRING_ARRAY, StringComparison.OrdinalIgnoreCase))
            {
                if (_value.StartsWith("[") != _value.EndsWith("]"))
                {
                    error = "Invalid array format.";
                    return false;
                }

                normalized = _value.StartsWith("[") ? _value : $"[{_value}]";

                string content = normalized.Trim('[', ']');

                if (!string.IsNullOrWhiteSpace(content))
                {
                    string[] items = content
                        .Split(',')
                        .Select(x => x.Trim())
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToArray();

                    bool allInt = items.All(x => int.TryParse(x, out _));

                    bool allString = items.All(x =>
                        x.StartsWith("\"") && x.EndsWith("\""));

                    if (!allInt && !allString)
                    {
                        error = "Invalid array value format.";
                        return false;
                    }
                }

                return true;
            }

            // String (default) -- không cho phép chứa ký tự "
            if (value.Contains("\""))
            {
                error = "Invalid string format.";
                return false;
            }
            return true;
        }

        private string BuildJsonObject(List<ColumnModel> gridData, ref int rowNo, int minLevel, int indent, string parentPath)
        {
            string pad = new string(' ', indent * 2);
            string padChild = new string(' ', (indent + 1) * 2);
            var parts = new List<string>();

            while (rowNo < gridData.Count)
            {
                var row = gridData[rowNo];
                int level = int.TryParse(row.ExcludeChars, out int lv) ? lv : 0;

                if (level <= minLevel) break;

                string childPath = string.IsNullOrEmpty(parentPath)
                    ? row.Name : parentPath + "." + row.Name;

                if (row.Type == CONST.C_TYPE_OBJECT)
                {
                    rowNo++;
                    string inner = BuildJsonObject(gridData, ref rowNo, level - 1, indent + 1, childPath);
                    parts.Add(padChild + "\"" + row.Name + "\": " + inner);
                }
                else if (row.Type == CONST.C_TYPE_ARRAY)
                {
                    // Check if next item is a child (higher level) -> object array
                    // If not -> String Array (leaf array), use valueMap directly
                    bool hasChildren = (rowNo + 1 < gridData.Count) &&
                        (int.TryParse(gridData[rowNo + 1].ExcludeChars, out int nextLv) && nextLv > level);

                    if (!hasChildren)
                    {
                        string jsonVal = string.IsNullOrEmpty(row.Value) ? "[]" : row.Value;
                        parts.Add(padChild + "\"" + row.Name + "\": " + jsonVal);
                        rowNo++;
                    }
                    else
                    {
                        rowNo++;
                        string inner = BuildJsonArray(gridData, ref rowNo, level, row.Range, row.Name, indent + 1, parentPath);
                        parts.Add(padChild + "\"" + row.Name + "\": " + inner);
                    }
                }
                else
                {
                    rowNo++;

                    string parentLast = parentPath.Contains('.') ? parentPath.Split('.').Last() : parentPath;
                    string rowFirst = row.Name.Contains('.') ? row.Name.Split('.').First() : row.Name;
                    if (row.Name.Contains('.') && !string.Equals(parentLast, rowFirst, StringComparison.OrdinalIgnoreCase)) continue;

                    // Leaf: get value from grid, apply type rules
                    bool isComment = row.Value.TrimStart().StartsWith("//");
                    string jsonVal = isComment ? GetDefaultJsonValue(row.Type) : FormatLeafValue(row.Type, row.Value);
                    string name = row.Name.Contains('.') ? row.Name.Split('.').Last() : row.Name;
                    string line = padChild + "\"" + name + "\": " + jsonVal;
                    parts.Add(isComment ? "// " + line.TrimStart() : line);
                }
            }

            if (parts.Count == 0) return "{}";
            return "{\n" + string.Join(",\n", parts) + "\n" + pad + "}";
        }

        private string BuildJsonArray(List<ColumnModel> gridData,
            ref int index, int minLevel, int range, string arrayKey, int indent, string parentPath)
        {
            string pad = new string(' ', indent * 2);

            // Collect element-template items (direct children of this array)
            var childItems = new List<ColumnModel>();
            while (index < gridData.Count)
            {
                int childLevel = int.TryParse(gridData[index].ExcludeChars, out int lv) ? lv : 0;
                if (childLevel <= minLevel) break;
                childItems.Add(gridData[index++]);
            }

            if (childItems.Count == 0) return "[]";

            var elements = new List<string>();
            string arrayBase = string.IsNullOrEmpty(parentPath) ? arrayKey : parentPath + "." + arrayKey;
            for (int r = 0; r < Math.Max(range, 1); r++)
            {
                string elemPath = arrayBase + "[" + r + "]";
                int tempIdx = 0;
                elements.Add(BuildJsonObject(childItems, ref tempIdx, minLevel, indent + 1, elemPath));
            }

            return "[\n" + string.Join(",\n", elements) + "\n" + pad + "]";
        }

        private string GetDefaultJsonValue(string type)
        {
            if (string.Equals(type, CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase)) return "[]";
            if (string.Equals(type, CONST.C_TYPE_OBJECT, StringComparison.OrdinalIgnoreCase)) return "{}";
            if (string.Equals(type, CONST.C_TYPE_INT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_LONG, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_SHORT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DECIMAL, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DOUBLE, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_NUMERIC, StringComparison.OrdinalIgnoreCase))
                return "0";
            if (string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase))
                return "false";
            return "\"\"";
        }

        private string FormatLeafValue(string type, string raw)
        {
            string value = raw?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(value)) return GetDefaultJsonValue(type);

            if (string.Equals(type, CONST.C_TYPE_INT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_LONG, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_SHORT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DECIMAL, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DOUBLE, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_NUMERIC, StringComparison.OrdinalIgnoreCase))
                return decimal.TryParse(value, System.Globalization.NumberStyles.Any,
                       System.Globalization.CultureInfo.InvariantCulture, out _) ? value : "0";

            if (string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase))
                return (value.Equals("true", StringComparison.OrdinalIgnoreCase) || value == "1") ? "true" : "false";

            if (string.Equals(type, CONST.C_TYPE_STRING_ARRAY, StringComparison.OrdinalIgnoreCase)) return value;

            return "\"" + value.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
        }

        #endregion
    }
}