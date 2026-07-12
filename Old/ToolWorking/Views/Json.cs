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

                    gridInputValue.Visible = true;
                    txtInputJsonFilter.Visible = false;
                }
                else
                {
                    rbModeJson.Checked = true;
                    isInputKey = false;

                    gridInputValue.Visible = false;
                    txtInputJsonFilter.Visible = false;
                }
                txtIndent.Text = indentCharacter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbInput_CheckedChanged(object sender, EventArgs e)
        {
            groupInputValue.Text = "Input Value";
            groupInputKey.Text = rbModeKeys.Checked ? "Input Keys" : "Input JSON";

            panelInput.Visible = rbInput.Checked;
            gridInputValue.Visible = rbInput.Checked;
            txtInputKey.Clear();
            txtInputJsonFilter.Visible = !rbInput.Checked;
            // Save mode
            Properties.Settings.Default.JsonModel = 0;
            Properties.Settings.Default.Save();
        }

        private void rbOutput_CheckedChanged(object sender, EventArgs e)
        {
            groupInputKey.Text = "Input Keys Filter";
            groupInputValue.Text = "Input JSON Filter";

            gridInputValue.Visible = !rbOutput.Checked;
            txtInputKey.Clear();
            txtInputJsonFilter.Visible = rbOutput.Checked;
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
                if (rbOutput.Checked)
                {
                    btnCreate.Enabled = !string.IsNullOrEmpty(txtInputKey.Text) && !string.IsNullOrEmpty(txtInputJsonFilter.Text);
                    return;
                }

                if (string.IsNullOrEmpty(txtInputKey.Text))
                {
                    gridInputValue.DataSource = new List<ColumnModel>();
                    txtResult.Text = string.Empty;
                    btnCreate.Enabled = false;
                    return;
                }

                string[] arrKeys = StripInputChars(txtInputKey.Text).Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

                int levelDelta, currentLevel = 0, range = 0;
                string line, key, type, baseType, value;
                string[] arrLine, arrType;
                List<ColumnModel> lstInputKey = new List<ColumnModel>();
                void AddKey() => lstInputKey.Add(new ColumnModel(lstInputKey.Count + 1, key, baseType, string.Empty, range, currentLevel.ToString()));

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
                            AddKey();
                            currentLevel = Math.Max(0, currentLevel + 1);
                        }
                        else if (type.StartsWith(CONST.C_TYPE_OBJECT, StringComparison.OrdinalIgnoreCase))
                        {
                            baseType = CONST.C_TYPE_OBJECT;
                            AddKey();
                            currentLevel++;
                        }
                        else if (type.StartsWith(CONST.C_TYPE_STRING_ARRAY, StringComparison.OrdinalIgnoreCase))
                        {
                            baseType = CONST.C_TYPE_STRING_ARRAY;
                            AddKey();
                        }
                        else
                        {
                            arrType = type.Split(CONST.CHAR_COLON);
                            if (arrType.Length > 1 && int.TryParse(arrType[1].Trim(), out int inRange))
                            {
                                baseType = arrType[0].Trim();
                                if (inRange < 0) currentLevel = Math.Max(0, currentLevel + inRange);
                            }
                            AddKey();
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

                        AddKey();
                        currentLevel = currentLevel + levelDelta;
                    }
                }

                // Expand Array children into flat rows for grid (recursive, multi-level)
                int no = 1, idx = 0;
                List<ColumnModel> dataGrid = new List<ColumnModel>();
                ExpandToGrid(lstInputKey, ref idx, -1, ref no, dataGrid, string.Empty);
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

        private void txtInputJsonFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInputJsonFilter.Text))
                {
                    txtResult.Text = string.Empty;
                    btnCreate.Enabled = false;
                    return;
                }
                btnCreate.Enabled = !string.IsNullOrEmpty(txtInputKey.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (rbOutput.Checked)
            {
                if (string.IsNullOrEmpty(txtInputKey.Text) || string.IsNullOrEmpty(txtInputJsonFilter.Text)) return;

                string[] keys = txtInputKey.Text
                    .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(k => k.Trim())
                    .Where(k => !string.IsNullOrEmpty(k))
                    .ToArray();

                if (keys.Length == 0) return;

                try
                {
                    string result = FilterJsonByKeys(txtInputJsonFilter.Text.Trim(), keys);
                    txtResult.Text = result;
                    btnCopyResult.Enabled = !string.IsNullOrEmpty(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

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
            btnCopyResult.Enabled = !string.IsNullOrEmpty(txtResult.Text);
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
            txtInputJsonFilter.Text = string.Empty;

            btnCreate.Enabled = false;
            btnCopyResult.Enabled = false;

            gridInputValue.DataSource = new List<ColumnModel>();
        }
        #endregion

        #region Function
        /// <summary>
        /// Đệ quy expand lstInputKey (dựa vào level lưu trong ExcludeChars) thành flat rows cho grid.
        /// minLevel: level cha (chỉ xử lý các item có level > minLevel).
        /// prefix: chuỗi tiền tố tên cột (VD: "arr[0]").
        /// </summary>
        private void ExpandToGrid(List<ColumnModel> src, ref int idx, int minLevel, ref int no,
            List<ColumnModel> dest, string prefix)
        {
            while (idx < src.Count)
            {
                var col = src[idx];
                int level = ParseLevel(col.ExcludeChars);

                // Nếu level <= minLevel thì item này thuộc về cha (caller sẽ xử lý)
                if (level <= minLevel) break;

                idx++;
                string fullName = string.IsNullOrEmpty(prefix) ? col.Name : prefix + "." + col.Name;

                if (col.Type == CONST.C_TYPE_ARRAY)
                {
                    // Kiểm tra có child không (item tiếp theo có level cao hơn)
                    bool hasChildren = idx < src.Count && ParseLevel(src[idx].ExcludeChars) > level;

                    if (!hasChildren || col.Type == CONST.C_TYPE_STRING_ARRAY)
                    {
                        // Leaf array (string array)
                        dest.Add(new ColumnModel(no++, fullName, col.Type, col.Value, col.Range, col.ExcludeChars));
                    }
                    else
                    {
                        // Object array: thêm header row
                        dest.Add(new ColumnModel(no++, fullName, col.Type, col.Value, col.Range, col.ExcludeChars));

                        // Snapshot children vào list tạm
                        var childItems = new List<ColumnModel>();
                        // Thu thập tất cả children trực tiếp (level == level+1) và con cháu
                        CollectChildren(src, ref idx, level, childItems);

                        // Expand theo range
                        int range = col.Range > 0 ? col.Range : 1;
                        for (int r = 0; r < range; r++)
                        {
                            int tempIdx = 0;
                            ExpandToGrid(childItems, ref tempIdx, -1, ref no, dest, fullName + "[" + r + "]");
                        }
                    }
                }
                else if (col.Type == CONST.C_TYPE_OBJECT)
                {
                    dest.Add(new ColumnModel(no++, fullName, col.Type, col.Value, col.Range, col.ExcludeChars));
                    // Object: đệ quy expand children với cùng prefix
                    ExpandToGrid(src, ref idx, level - 1, ref no, dest, prefix);
                }
                else
                {
                    dest.Add(new ColumnModel(no++, fullName, col.Type, col.Value, col.Range, col.ExcludeChars));
                }
            }
        }

        /// <summary>
        /// Thu thập tất cả items trong src có level > parentLevel vào childItems,
        /// đồng thời advance idx. Level được re-map về gốc (trừ đi parentLevel+1) để dùng lại đệ quy.
        /// </summary>
        private void CollectChildren(List<ColumnModel> src, ref int idx, int parentLevel, List<ColumnModel> childItems)
        {
            int baseLevel = parentLevel + 1;
            while (idx < src.Count)
            {
                int level = ParseLevel(src[idx].ExcludeChars);
                if (level <= parentLevel) break;

                // Re-map level: child trực tiếp -> 0, cháu -> 1, ...
                int remapped = level - baseLevel;
                var item = src[idx++];
                childItems.Add(new ColumnModel(item.No, item.Name, item.Type, item.Value, item.Range,
                    remapped.ToString()));
            }
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

        private string GetDefaultGridValue(string type)
        {
            if (IsNumericType(type)) return "0";
            if (IsBooleanType(type)) return "false";
            if (string.Equals(type, CONST.C_TYPE_STRING_ARRAY, StringComparison.OrdinalIgnoreCase)) return "[]";
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
            if (IsNumericType(type))
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
            if (IsBooleanType(type))
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

            // prefix used to filter rows that belong to this context
            string prefix = string.IsNullOrEmpty(parentPath) ? string.Empty : parentPath + ".";

            while (rowNo < gridData.Count)
            {
                var row = gridData[rowNo];
                int level = ParseLevel(row.ExcludeChars);

                if (level <= minLevel) break;

                // Filter by parentPath:
                // - prefix set  → only rows whose name starts with "parentPath."
                // - prefix empty → skip expanded array element rows (they have "[r]." in name)
                if (!string.IsNullOrEmpty(prefix))
                {
                    if (!row.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) break;
                }
                else if (row.Name.Contains("[") && row.Type != CONST.C_TYPE_ARRAY)
                {
                    break;
                }

                rowNo++;

                // Extract local field name (strip prefix)
                string localName = prefix.Length > 0 ? row.Name.Substring(prefix.Length) : row.Name;

                if (row.Type == CONST.C_TYPE_OBJECT)
                {
                    // Object children share the same parentPath (ExpandToGrid keeps same prefix);
                    // use level-based minLevel to distinguish children from siblings.
                    string inner = BuildJsonObject(gridData, ref rowNo, level, indent + 1, parentPath);
                    parts.Add(padChild + "\"" + localName + "\": " + inner);
                }
                else if (row.Type == CONST.C_TYPE_ARRAY)
                {
                    // In the flat grid, array elements are named "arrayFullName[r].*"
                    string arrayFullName = prefix.Length > 0 ? parentPath + "." + localName : localName;
                    bool hasExpandedElements = rowNo < gridData.Count &&
                        gridData[rowNo].Name.StartsWith(arrayFullName + "[", StringComparison.OrdinalIgnoreCase);

                    if (!hasExpandedElements)
                    {
                        string jsonVal = string.IsNullOrEmpty(row.Value) ? "[]" : row.Value;
                        parts.Add(padChild + "\"" + localName + "\": " + jsonVal);
                    }
                    else
                    {
                        string inner = BuildFlatArray(gridData, ref rowNo, arrayFullName, row.Range, indent + 1);
                        parts.Add(padChild + "\"" + localName + "\": " + inner);
                    }
                }
                else
                {
                    bool isComment = (row.Value ?? string.Empty).TrimStart().StartsWith("//");
                    string jsonVal = isComment ? GetDefaultJsonValue(row.Type) : FormatLeafValue(row.Type, row.Value);
                    string line = padChild + "\"" + localName + "\": " + jsonVal;
                    parts.Add(isComment ? "// " + line.TrimStart() : line);
                }
            }

            if (parts.Count == 0) return "{}";
            return "{\n" + string.Join(",\n", parts) + "\n" + pad + "}";
        }

        private string BuildFlatArray(List<ColumnModel> gridData, ref int rowNo, string arrayPrefix, int range, int indent)
        {
            string pad = new string(' ', indent * 2);
            var elements = new List<string>();
            int count = Math.Max(range, 1);

            for (int r = 0; r < count; r++)
            {
                string elementPrefix = arrayPrefix + "[" + r + "]";
                if (rowNo < gridData.Count &&
                    gridData[rowNo].Name.StartsWith(elementPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    elements.Add(BuildJsonObject(gridData, ref rowNo, -1, indent + 1, elementPrefix));
                }
                else
                {
                    elements.Add("{}");
                }
            }

            return "[\n" + string.Join(",\n", elements) + "\n" + pad + "]";
        }

        private string GetDefaultJsonValue(string type)
        {
            if (string.Equals(type, CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase)) return "[]";
            if (string.Equals(type, CONST.C_TYPE_OBJECT, StringComparison.OrdinalIgnoreCase)) return "{}";
            if (IsNumericType(type)) return "0";
            if (string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase)) return "false";
            return "\"\"";
        }

        private string FormatLeafValue(string type, string raw)
        {
            string value = raw?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(value)) return GetDefaultJsonValue(type);

            if (IsNumericType(type))
                return decimal.TryParse(value, System.Globalization.NumberStyles.Any,
                       System.Globalization.CultureInfo.InvariantCulture, out _) ? value : "0";

            if (string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase))
                return (value.Equals("true", StringComparison.OrdinalIgnoreCase) || value == "1") ? "true" : "false";

            if (string.Equals(type, CONST.C_TYPE_STRING_ARRAY, StringComparison.OrdinalIgnoreCase)) return value;

            return "\"" + value.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
        }

        private static bool IsNumericType(string type) =>
            string.Equals(type, CONST.C_TYPE_INT, StringComparison.OrdinalIgnoreCase)
            || string.Equals(type, CONST.C_TYPE_LONG, StringComparison.OrdinalIgnoreCase)
            || string.Equals(type, CONST.C_TYPE_SHORT, StringComparison.OrdinalIgnoreCase)
            || string.Equals(type, CONST.C_TYPE_DECIMAL, StringComparison.OrdinalIgnoreCase)
            || string.Equals(type, CONST.C_TYPE_DOUBLE, StringComparison.OrdinalIgnoreCase)
            || string.Equals(type, CONST.C_TYPE_NUMERIC, StringComparison.OrdinalIgnoreCase);

        private static bool IsBooleanType(string type) =>
            string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase)
            || string.Equals(type, CONST.C_TYPE_BIT, StringComparison.OrdinalIgnoreCase);

        private static int ParseLevel(string s) => int.TryParse(s, out int lv) ? lv : 0;

        private string FilterJsonByKeys(string jsonInput, string[] keys)
        {
            int i = 0;
            SkipJsonWhitespace(jsonInput, ref i);

            var items = new List<Dictionary<string, object>>();

            if (i < jsonInput.Length && jsonInput[i] == '[')
            {
                i++; // skip [
                SkipJsonWhitespace(jsonInput, ref i);
                while (i < jsonInput.Length && jsonInput[i] != ']')
                {
                    SkipJsonWhitespace(jsonInput, ref i);
                    if (i < jsonInput.Length && jsonInput[i] == '{')
                        items.Add(ParseJsonObject(jsonInput, ref i));
                    else
                        ParseJsonValue(jsonInput, ref i); // skip non-object items
                    SkipJsonWhitespace(jsonInput, ref i);
                    if (i < jsonInput.Length && jsonInput[i] == ',') i++;
                }
            }
            else if (i < jsonInput.Length && jsonInput[i] == '{')
            {
                items.Add(ParseJsonObject(jsonInput, ref i));
            }

            if (items.Count == 0) return string.Empty;

            var sb = new System.Text.StringBuilder();
            sb.AppendLine("[");

            if (keys.Length == 1)
            {
                string key = keys[0];
                for (int j = 0; j < items.Count; j++)
                {
                    sb.Append("  " + SerializeJsonValue(FindJsonValue(items[j], key)));
                    if (j < items.Count - 1) sb.Append(",");
                    sb.AppendLine();
                }
            }
            else
            {
                for (int j = 0; j < items.Count; j++)
                {
                    sb.AppendLine("  {");
                    for (int k = 0; k < keys.Length; k++)
                    {
                        sb.Append("    \"" + keys[k] + "\": " + SerializeJsonValue(FindJsonValue(items[j], keys[k])));
                        if (k < keys.Length - 1) sb.Append(",");
                        sb.AppendLine();
                    }
                    sb.Append("  }");
                    if (j < items.Count - 1) sb.Append(",");
                    sb.AppendLine();
                }
            }

            sb.Append("]");
            return sb.ToString();
        }

        private object FindJsonValue(Dictionary<string, object> obj, string key)
        {
            if (obj == null) return null;
            if (obj.TryGetValue(key, out object val)) return val;
            foreach (var kv in obj.Values)
            {
                if (kv is Dictionary<string, object> nested)
                {
                    object found = FindJsonValue(nested, key);
                    if (found != null) return found;
                }
            }
            return null;
        }

        private string SerializeJsonValue(object val)
        {
            if (val == null) return "null";
            if (val is bool b) return b ? "true" : "false";
            if (val is decimal d) return d.ToString(System.Globalization.CultureInfo.InvariantCulture);
            if (val is Dictionary<string, object> dict)
            {
                var parts = dict.Select(kv => "\"" + kv.Key + "\": " + SerializeJsonValue(kv.Value));
                return "{" + string.Join(", ", parts) + "}";
            }
            if (val is List<object> list)
                return "[" + string.Join(", ", list.Select(v => SerializeJsonValue(v))) + "]";
            return "\"" + val.ToString().Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
        }

        private Dictionary<string, object> ParseJsonObject(string json, ref int i)
        {
            var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            i++; // skip {
            SkipJsonWhitespace(json, ref i);
            while (i < json.Length && json[i] != '}')
            {
                SkipJsonWhitespace(json, ref i);
                if (i >= json.Length || json[i] == '}') break;
                if (json[i] != '"') { i++; continue; }
                string key = ParseJsonString(json, ref i);
                SkipJsonWhitespace(json, ref i);
                if (i < json.Length && json[i] == ':') i++;
                SkipJsonWhitespace(json, ref i);
                object value = ParseJsonValue(json, ref i);
                if (!dict.ContainsKey(key)) dict[key] = value;
                SkipJsonWhitespace(json, ref i);
                if (i < json.Length && json[i] == ',') i++;
                SkipJsonWhitespace(json, ref i);
            }
            if (i < json.Length) i++; // skip }
            return dict;
        }

        private List<object> ParseJsonArray(string json, ref int i)
        {
            var list = new List<object>();
            i++; // skip [
            SkipJsonWhitespace(json, ref i);
            while (i < json.Length && json[i] != ']')
            {
                list.Add(ParseJsonValue(json, ref i));
                SkipJsonWhitespace(json, ref i);
                if (i < json.Length && json[i] == ',') i++;
                SkipJsonWhitespace(json, ref i);
            }
            if (i < json.Length) i++; // skip ]
            return list;
        }

        private object ParseJsonValue(string json, ref int i)
        {
            SkipJsonWhitespace(json, ref i);
            if (i >= json.Length) return null;
            char c = json[i];
            if (c == '"') return ParseJsonString(json, ref i);
            if (c == '{') return ParseJsonObject(json, ref i);
            if (c == '[') return ParseJsonArray(json, ref i);
            if (i + 4 <= json.Length && json.Substring(i, 4) == "true") { i += 4; return true; }
            if (i + 5 <= json.Length && json.Substring(i, 5) == "false") { i += 5; return false; }
            if (i + 4 <= json.Length && json.Substring(i, 4) == "null") { i += 4; return null; }
            // Number
            int start = i;
            while (i < json.Length && (char.IsDigit(json[i]) || json[i] == '.' || json[i] == 'e' || json[i] == 'E' || json[i] == '+' || json[i] == '-'))
                i++;
            string numStr = json.Substring(start, i - start);
            if (decimal.TryParse(numStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal dec))
                return dec;
            return numStr;
        }

        private string ParseJsonString(string json, ref int i)
        {
            i++; // skip opening "
            var sb = new System.Text.StringBuilder();
            while (i < json.Length && json[i] != '"')
            {
                if (json[i] == '\\' && i + 1 < json.Length)
                {
                    i++;
                    switch (json[i])
                    {
                        case '"': sb.Append('"'); break;
                        case '\\': sb.Append('\\'); break;
                        case '/': sb.Append('/'); break;
                        case 'n': sb.Append('\n'); break;
                        case 'r': sb.Append('\r'); break;
                        case 't': sb.Append('\t'); break;
                        case 'b': sb.Append('\b'); break;
                        case 'f': sb.Append('\f'); break;
                        case 'u':
                            if (i + 4 < json.Length)
                            {
                                string hex = json.Substring(i + 1, 4);
                                if (int.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out int code))
                                    sb.Append((char)code);
                                i += 4;
                            }
                            break;
                        default: sb.Append(json[i]); break;
                    }
                }
                else
                {
                    sb.Append(json[i]);
                }
                i++;
            }
            if (i < json.Length) i++; // skip closing "
            return sb.ToString();
        }

        private void SkipJsonWhitespace(string json, ref int i)
        {
            while (i < json.Length && char.IsWhiteSpace(json[i])) i++;
        }

        #endregion

    }
}