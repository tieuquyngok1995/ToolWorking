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

        static readonly Random _rnd = new Random();

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

            for (int ki = 0; ki < arrKeys.Length; ki++)
            {
                var _key = arrKeys[ki];
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

                    // Format: Array[:positive][:negative]
                    //   :positive         -> range only (level +1)
                    //   :positive:negative -> range + level delta
                    //   :negative         -> level delta only (range stays 1)
                    if (type.StartsWith(CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase))
                    {
                        baseType = CONST.C_TYPE_ARRAY;
                        string[] typeParts = type.Split(':');
                        int levelDelta = 1;

                        if (typeParts.Length > 1 && int.TryParse(typeParts[1].Trim(), out int val1))
                        {
                            if (val1 > 0)
                            {
                                range = val1;
                                if (typeParts.Length > 2 && int.TryParse(typeParts[2].Trim(), out int lv2))
                                    levelDelta = lv2;
                            }
                            else if (val1 < 0)
                            {
                                levelDelta = val1;
                            }
                        }
                        else if (typeParts.Length > 1)
                        {
                            // String Array (e.g. Array:string) -- no children, don't increase level
                            levelDelta = 0;
                        }
                        else
                        {
                            // Check if next non-empty item is also an Array -> no children, don't increase level
                            for (int ni = ki + 1; ni < arrKeys.Length; ni++)
                            {
                                string nextLine = arrKeys[ni].Replace(indentCharacter, string.Empty).Trim();
                                if (string.IsNullOrEmpty(nextLine)) continue;
                                string[] nextParts = nextLine.Split(CONST.STRING_SEPARATORS_COLUMN, StringSplitOptions.RemoveEmptyEntries);
                                string nextType = nextParts.Length > 1 ? nextParts[1].Trim() : string.Empty;
                                if (nextType.StartsWith(CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase))
                                    levelDelta = 0;
                                break;
                            }
                        }

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

        private string BuildJsonObject(List<ColumnModel> items, Dictionary<string, string> valueMap,
            ref int index, int minLevel, int indent, string parentPath)
        {
            string pad = new string(' ', indent * 2);
            string padChild = new string(' ', (indent + 1) * 2);
            var parts = new List<string>();

            while (index < items.Count)
            {
                var item = items[index];
                int level = int.TryParse(item.ExcludeChars, out int lv) ? lv : 0;
                if (level <= minLevel) break;

                string childPath = string.IsNullOrEmpty(parentPath)
                    ? item.Name : parentPath + "." + item.Name;

                if (item.Type == CONST.C_TYPE_OBJECT)
                {
                    index++;
                    string inner = BuildJsonObject(items, valueMap, ref index, level - 1, indent + 1, childPath);
                    parts.Add(padChild + "\"" + item.Name + "\": " + inner);
                }
                else if (item.Type == CONST.C_TYPE_ARRAY)
                {
                    // Check if next item is a child (higher level) -> object array
                    // If not -> String Array (leaf array), use valueMap directly
                    bool hasChildren = (index + 1 < items.Count) &&
                        (int.TryParse(items[index + 1].ExcludeChars, out int nextLv) && nextLv > level);

                    if (!hasChildren)
                    {
                        string raw = valueMap.ContainsKey(childPath) ? valueMap[childPath]
                                   : valueMap.ContainsKey(item.Name) ? valueMap[item.Name]
                                   : string.Empty;
                        string jsonVal = string.IsNullOrEmpty(raw) ? "[]" : raw;
                        parts.Add(padChild + "\"" + item.Name + "\": " + jsonVal);
                        index++;
                    }
                    else
                    {
                        index++;
                        string inner = BuildJsonArray(items, valueMap, ref index, level - 1, item.Range, item.Name, indent + 1, parentPath);
                        parts.Add(padChild + "\"" + item.Name + "\": " + inner);
                    }
                }
                else
                {
                    // Leaf: get value from grid, apply type rules
                    string raw = valueMap.ContainsKey(childPath) ? valueMap[childPath]
                               : valueMap.ContainsKey(item.Name) ? valueMap[item.Name]
                               : string.Empty;
                    bool isComment = raw.TrimStart().StartsWith("//");
                    string jsonVal = isComment ? GetDefaultJsonValue(item.Type) : FormatLeafValue(item.Type, raw);
                    string line = padChild + "\"" + item.Name + "\": " + jsonVal;
                    parts.Add(isComment ? "// " + line.TrimStart() : line);
                    index++;
                }
            }

            if (parts.Count == 0) return "{}";
            return "{\n" + string.Join(",\n", parts) + "\n" + pad + "}";
        }

        private string BuildJsonArray(List<ColumnModel> items, Dictionary<string, string> valueMap,
            ref int index, int minLevel, int range, string arrayKey, int indent, string parentPath)
        {
            string pad = new string(' ', indent * 2);

            // Collect element-template items (direct children of this array)
            var childItems = new List<ColumnModel>();
            while (index < items.Count)
            {
                int childLevel = int.TryParse(items[index].ExcludeChars, out int lv) ? lv : 0;
                if (childLevel <= minLevel) break;
                childItems.Add(items[index++]);
            }

            if (childItems.Count == 0) return "[]";

            var elements = new List<string>();
            string arrayBase = string.IsNullOrEmpty(parentPath) ? arrayKey : parentPath + "." + arrayKey;
            for (int r = 0; r < Math.Max(range, 1); r++)
            {
                string elemPath = arrayBase + "[" + r + "]";
                int tempIdx = 0;
                elements.Add(BuildJsonObject(childItems, valueMap, ref tempIdx, -1, indent + 1, elemPath));
            }

            return "[\n" + string.Join(",\n", elements) + "\n" + pad + "]";
        }

        private string FormatLeafValue(string type, string raw)
        {
            string v = raw?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(v)) return GetDefaultJsonValue(type);

            if (string.Equals(type, CONST.C_TYPE_INT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_LONG, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_SHORT, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DECIMAL, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_DOUBLE, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_NUMERIC, StringComparison.OrdinalIgnoreCase))
                return decimal.TryParse(v, System.Globalization.NumberStyles.Any,
                       System.Globalization.CultureInfo.InvariantCulture, out _) ? v : "0";

            if (string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_BIT, StringComparison.OrdinalIgnoreCase))
                return (v.Equals("true", StringComparison.OrdinalIgnoreCase) || v == "1") ? "true" : "false";

            // string (default) 窶・escape JSON special characters
            return "\"" + v.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
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
            if (string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_BIT, StringComparison.OrdinalIgnoreCase))
                return "false";
            return "\"\"";
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

        private bool ValidateAndNormalizeValue(string type, string value, out string normalized, out string error)
        {
            normalized = value;
            error = string.Empty;

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
                    error = "Phải là số hợp lệ (không chứa chữ hoặc ký tự đặc biệt)";
                    return false;
                }
                return true;
            }

            // Boolean / Bit
            if (string.Equals(type, CONST.C_TYPE_BOOLEAN, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_BIT, StringComparison.OrdinalIgnoreCase))
            {
                string v = value.ToLower();
                if (v != "true" && v != "false" && v != "1" && v != "0")
                {
                    error = "Phải là true hoặc false";
                    return false;
                }
                normalized = (v == "true" || v == "1") ? "true" : "false";
                return true;
            }

            // Date
            if (string.Equals(type, "date", StringComparison.OrdinalIgnoreCase))
            {
                string[] formats = { "yyyy/MM/dd", "yyyy-MM-dd" };
                if (!DateTime.TryParseExact(value, formats,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    error = "Ngày phải có định dạng yyyy/mm/dd hoặc yyyy-mm-dd";
                    return false;
                }
                normalized = dt.ToString("yyyy-MM-dd");
                return true;
            }

            // DateTime / Timestamp
            if (string.Equals(type, CONST.C_TYPE_DATE_TIME, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.SQL_TYPE_DATE_TIME, StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, CONST.C_TYPE_TIME_STAMP, StringComparison.OrdinalIgnoreCase))
            {
                string[] formats = { "yyyy/MM/dd", "yyyy-MM-dd", "yyyy/MM/dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss" };
                if (!DateTime.TryParseExact(value, formats,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    error = "Phải là dạng yyyy/mm/dd hoặc yyyy-mm-dd (có thể kèm hh:mm:ss)";
                    return false;
                }
                normalized = dt.ToString("yyyy-MM-ddTHH:mm:ss") + "+09:00";
                return true;
            }

            // Array
            if (string.Equals(type, CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase))
            {
                string v = value.Trim();
                if (v.StartsWith("["))
                {
                    if (!v.EndsWith("]"))
                    {
                        error = "Mảng phải có định dạng [\"v1\",\"v2\"] hoặc \"v1\",\"v2\"";
                        return false;
                    }
                    normalized = v;
                }
                else
                {
                    normalized = "[" + v + "]";
                }
                return true;
            }

            // String (default) -- không cho phép chứa ký tự "
            if (value.Contains("\""))
            {
                error = "Không được chứa ký tự \"";
                return false;
            }
            return true;
        }

        private string ResolveRandomValue(string val)
        {
            if (string.IsNullOrEmpty(val)) return val;

            // Pipe: randomly pick one of the options separated by |
            if (val.Contains("|"))
            {
                string[] options = val.Split('|');
                val = options[_rnd.Next(options.Length)].Trim();
                return ResolveRandomValue(val);
            }

            // XXX[~N]: random alphanumeric string of N chars (default 8)
            if (val.StartsWith("XXX", StringComparison.OrdinalIgnoreCase))
            {
                int length = 8;
                if (val.Length > 3 && val[3] == '~'
                    && int.TryParse(val.Substring(4), out int n) && n > 0)
                    length = n;
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var sb = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                    sb.Append(chars[_rnd.Next(chars.Length)]);
                return sb.ToString();
            }

            // YYY[~N]: random N-digit number (default 5 digits)
            if (val.StartsWith("YYY", StringComparison.OrdinalIgnoreCase))
            {
                int digits = 5;
                if (val.Length > 3 && val[3] == '~'
                    && int.TryParse(val.Substring(4), out int n) && n > 0)
                    digits = n;
                int minVal = digits == 1 ? 0 : (int)Math.Pow(10, digits - 1);
                int maxVal = (int)Math.Pow(10, digits) - 1;
                return _rnd.Next(minVal, maxVal + 1).ToString();
            }

            return val;
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

            if (string.Equals(type, CONST.C_TYPE_ARRAY, StringComparison.OrdinalIgnoreCase))
                return "[]";

            return string.Empty;
        }

        #endregion


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (lstInputKey == null || lstInputKey.Count == 0) return;

            var gridData = gridInputValue.DataSource as List<ColumnModel>;
            if (gridData == null || gridData.Count == 0) return;

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

            gridInputValue.Refresh();

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\r\n", errors), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var valueMap = new Dictionary<string, string>();
            foreach (var row in gridData)
                if (!string.IsNullOrEmpty(row.Name))
                    valueMap[row.Name] = row.Value ?? string.Empty;

            int index = 0;
            txtResult.Text = BuildJsonObject(lstInputKey, valueMap, ref index, -1, 0, string.Empty);
        }
    }
}