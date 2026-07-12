namespace ToolWorking.Model
{
    public class ColumnModel
    {
        public int No { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public int Range { get; set; }

        public string ExcludeChars { get; set; }

        public ColumnModel(int no, string name, string type, string value, int range, string excludeChars = null)
        {
            No = no;
            Name = name;
            Type = type;
            Value = value;
            Range = range;

            if (!string.IsNullOrEmpty(excludeChars))
                ExcludeChars = excludeChars;
        }
    }
}
