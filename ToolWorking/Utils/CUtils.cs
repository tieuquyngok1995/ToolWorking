using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ToolWorking.Utils
{
    public static class CUtils
    {
        private static readonly char[] SPECIAL_CHARS = "!@#$%^&*_+-=;,.<>?/".ToCharArray();
        private static readonly char[] ASCII_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Concat(SPECIAL_CHARS).ToArray();
        private static readonly char[] UNICODE_CHARS = "あいうえおアイウエオ漢字测试文字符号".Concat(ASCII_CHARS).ToArray();

        private static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random());

        #region Layout 
        public static Color createColor()
        {
            Random random = new Random();
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

        /// <summary>
        /// Check encoding file is UTF-8 Bom
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CheckEcodingUTF8Bom(string filePath)
        {
            try
            {
                byte[] expectedBytes = new byte[] { 0xEF, 0xBB, 0xBF };

                byte[] fileHeaderBytes = ReadFirstBytes(filePath, 3);

                if (fileHeaderBytes.Length == expectedBytes.Length)
                {
                    bool isMatch = true;
                    for (int i = 0; i < fileHeaderBytes.Length; i++)
                    {
                        if (fileHeaderBytes[i] != expectedBytes[i])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    return isMatch;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Read first byte in file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="numberOfBytes"></param>
        /// <returns></returns>
        public static byte[] ReadFirstBytes(string filePath, int numberOfBytes)
        {
            byte[] bytes = new byte[numberOfBytes];

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // Đọc số byte yêu cầu từ file
                int bytesRead = fileStream.Read(bytes, 0, numberOfBytes);

                // Nếu không đọc đủ số byte yêu cầu, điều chỉnh kích thước mảng
                if (bytesRead < numberOfBytes)
                {
                    Array.Resize(ref bytes, bytesRead);
                }
            }

            return bytes;
        }

        /// <summary>
        /// Change Ecoding To UTF-8 Bom
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ChangeEcodingToUTF8Bom(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath, Encoding.UTF8);

                File.WriteAllText(filePath, content, new UTF8Encoding(true));

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
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

        public static string GenerateRandomValue(ref string type, int range, string excludeChars)
        {
            if (range <= 0) return "";

            Random rand = random.Value;
            HashSet<char> excludeSet = new HashSet<char>(excludeChars);
            switch (type.ToLower())
            {
                case CONST.STRING_TEXT1:
                case "string(1 byte)":
                    type = CONST.STRING_TEXT_1BYTE;
                    return new string(Enumerable.Range(0, range)
                        .Select(_ => GetRandomChar(rand, ASCII_CHARS, excludeSet))
                        .ToArray());

                case CONST.STRING_TEXT2:
                case "string(2 byte)":
                    type = CONST.STRING_TEXT_2BYTE;
                    return new string(Enumerable.Range(0, range)
                        .Select(_ => GetRandomChar(rand, UNICODE_CHARS, excludeSet))
                        .ToArray());

                case CONST.STRING_NUMBER:
                    type = "Number";
                    return string.Concat(Enumerable.Range(0, range)
                        .Select(_ => GetRandomChar(rand, "0123456789*#".ToArray(), excludeSet))
                        .ToArray());

                default:
                    return "";
            }
        }

        /// <summary>
        /// Run command line update svn 
        /// </summary>
        /// <returns></returns>
        public static void RunCommandUpdateSVN(string pathFolder)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C cd /d \"{pathFolder}\" && svn update \"{pathFolder}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            return;
                        }
                    };

                    process.Start();
                    process.BeginErrorReadLine();
                    process.BeginOutputReadLine();

                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        MessageBox.Show("There was an error during processing. SVN command failed.", "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception occurred: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static char GetRandomChar(Random rand, char[] charSet, HashSet<char> excludeSet)
        {
            char c;
            do
            {
                c = charSet[rand.Next(charSet.Length)];
            } while (excludeSet.Contains(c));

            return c;
        }
        #endregion
    }
}
