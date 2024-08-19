using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;

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

        #region Convert 
        public static string ConvertSQLToCType(string type)
        {
            switch (type)
            {
                case var sqlchar when type.Contains(CONST.SQL_TYPE_CHAR):
                case var varchar when type.Contains(CONST.SQL_TYPE_VARCHAR):
                case var nvarchar when type.Contains(CONST.SQL_TYPE_NVARCHAR):
                    return CONST.C_TYPE_STRING;
                case var nvarchar when type.Contains(CONST.SQL_TYPE_DATE):
                    return CONST.C_TYPE_DATE_TIME;
                case CONST.SQL_TYPE_DATE_TIME:
                    return CONST.C_TYPE_DATE_TIME;
                case CONST.SQL_TYPE_TIME:
                    return CONST.C_TYPE_TIME;
                case CONST.SQL_TYPE_TIME_STAMP:
                    return CONST.C_TYPE_TIME_STAMP;
                case CONST.SQL_TYPE_BIT:
                    return CONST.C_TYPE_BOOL;
                case CONST.SQL_TYPE_MONEY:
                case CONST.SQL_TYPE_NUMERIC:
                case CONST.SQL_TYPE_DECIMAL:
                    return CONST.C_TYPE_DOUBLE;
                default:
                    return CONST.C_TYPE_INT;
            }
        }
        #endregion

        #region File info
        /// <summary>
        /// Get file name 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string getFileName(string fileName)
        {
            int index = fileName.LastIndexOf("\\");
            if (index == -1)
            {
                return fileName;
            }
            else
            {
                return fileName.Substring(index + 1);
            }
        }
        #endregion

        #region Handle string 
        public static string RemoveLastCommaSpace(string str)
        {
            int lastIndex = str.LastIndexOf(CONST.STRING_COMMA + CONST.STRING_SPACE);
            if (lastIndex != -1 && lastIndex == str.Length - 2)
            {
                str = str.Substring(0, lastIndex);
                str = RemoveLastLineBlank(str);
            }
            return str;
        }

        public static string RemoveLastLineBlank(string str)
        {
            int lastIndex = str.LastIndexOf("\r\n");
            if (lastIndex != -1 && lastIndex == str.Length - 2)
            {
                str = str.Substring(0, lastIndex);
                str = RemoveLastLineBlank(str);
            }
            return str;
        }
        #endregion

        #region Util
        public static string GenerateRandomNumber(int length)
        {
            byte[] randomNumber = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomNumber);
            }

            char[] digits = new char[length];
            for (int i = 0; i < length; i++)
            {
                digits[i] = (char)('0' + (randomNumber[i] % 10));
            }

            return new string(digits);
        }
        #endregion
    }
}
