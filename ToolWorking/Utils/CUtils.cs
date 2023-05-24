using System;
using System.Collections.Generic;
using System.Drawing;

namespace ToolWorking.Utils
{
    public static class CUtils
    {
        #region Layout 
        private static Random random = new Random();
        public static Color createColor()
        {
            return Color.FromArgb((int)(0xFF << 24 ^ (random.Next(0xFFFFFF) & 0x7F7F7F))); ;
        }

        public static Color createPanelColor()
        {
            Random random = new Random();
            return Color.FromArgb((int)(0xFF << 24 ^ (random.Next(0xFFFFFF) & 0x7F7F7F))); ;
        }
        #endregion

        #region Check
        public static bool dicIsExists(Dictionary<string, string> dic, string key)
        {
            if (dic.ContainsKey(key)) return true; 
            return false;
        }

        public static string dicGetValue(Dictionary<string, string> dic, string key)
        {
            if (dic.ContainsKey(key)) return dic[key];
            return string.Empty;
        }
        #endregion

    }
}
