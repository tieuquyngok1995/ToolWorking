namespace ToolWorking.Model
{
    public class ColumnModel
    {
        public int no { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public string value { get; set; }

        public ColumnModel(int _no, string _name, string _type, string _value)
        {
            no = _no;
            name = _name;
            type = _type;
            value = _value;
        }
    }
}
