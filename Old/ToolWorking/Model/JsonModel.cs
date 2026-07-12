using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolWorking.Model
{
    public class JsonModel
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public int Range { get; set; }

        public List<JsonModel> Children { get; set; } = new List<JsonModel>();

        public JsonModel(string key, string value, int range = 0)
        {
            Key = key;
            Value = value;
            Range = range;
        }
    }
}
