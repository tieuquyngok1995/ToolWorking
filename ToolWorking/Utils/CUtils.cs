using System;
using System.Drawing;

namespace ToolWorking.Utils
{
    public static class CUtils
    {
        private static Random random = new Random();
        public static Color CreateColor()
        {
            return Color.FromArgb((int)(0xFF << 24 ^ (random.Next(0xFFFFFF) & 0x7F7F7F))); ;
        }

        public static Color CreatePanelColor()
        {
            Random random = new Random();
            return Color.FromArgb((int)(0xFF << 24 ^ (random.Next(0xFFFFFF) & 0x7F7F7F))); ;
        }
    }
}
