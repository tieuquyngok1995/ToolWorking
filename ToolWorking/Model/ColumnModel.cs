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

        public ColumnModel(int _No, string _Name, string _Type, string _Value, int _Range)
        {
            No = _No;
            Name = _Name;
            Type = _Type;
            Value = _Value;
            Range = _Range;
        }

        public ColumnModel(int _No, string _Name, string _Type, string _Value, int _Range, string _ExcludeChars)
        {
            No = _No;
            Name = _Name;
            Type = _Type;
            Value = _Value;
            Range = _Range;
            ExcludeChars = _ExcludeChars;
        }
    }
}
