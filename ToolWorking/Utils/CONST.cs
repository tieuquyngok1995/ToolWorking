namespace ToolWorking.Utils
{
    public static class CONST
    {
        public static string[] STRING_SEPARATORS = new string[] { STRING_NEW_LINE };
        public static string[] STRING_SEPARATORS_TABLE = new string[] { STRING_C_SQU_BRACKETS_SPACE, STRING_SPACE };

        #region String 
        public const string STRING_NEW_LINE = "\n";
        public const string STRING_COMMA = ",";
        public const string STRING_DOT = ".";
        public const string STRING_SPACE = " ";
        public const string STRING_O_BRACKETS = "(";
        public const string STRING_C_BRACKETS = ")";
        public const string STRING_C_SQU_BRACKETS_SPACE = "] ";
        public const string STRING_C_O_SQU_BRACKETS_SPACE = "] [";
        public const string STRING_O_SQU_BRACKETS = "[";
        public const string STRING_C_SQU_BRACKETS = "]";

        public const string STRING_EMPTY = "EMPTY";
        public const string STRING_TRUNK = "trunk";
        public const string STRING_NULL = "NULL";
        public const string STRING_NOT_NULL = "NOT NULL";

        public const string STRING_FLAG = "FLG";
        public const string STRING_JP_FLAG = "フラグ";
        #endregion

        #region String SQL 
        public const string SQL_CREATE_TABLE = "CREATE TABLE";
        public const string SQL_TYPE_CHAR = "char";
        public const string SQL_TYPE_VARCHAR = "varchar";
        public const string SQL_TYPE_NVARCHAR = "nvarchar";
        public const string SQL_TYPE_DATE = "date";
        public const string SQL_TYPE_TIME_STAMP = "timestamp";
        public const string SQL_TYPE_DATE_TIME = "datetime";
        public const string SQL_TYPE_TIME = "time";
        public const string SQL_TYPE_BIGINT = "bigint";
        public const string SQL_TYPE_SMALLINT = "smallint";
        public const string SQL_TYPE_MONEY = "money";
        public const string SQL_TYPE_NUMERIC = "numeric";
        public const string SQL_TYPE_DECIMAL = "decimal";
        public const string SQL_TYPE_BIT = "bit";
        #endregion

        #region String C Type 
        public const string C_TYPE_STRING = "string";
        public const string C_TYPE_BOOL = "bool";
        public const string C_TYPE_DATE_TIME = "DateTime";
        public const string C_TYPE_TIME = "Time";
        public const string C_TYPE_TIME_STAMP = "timestamp";
        public const string C_TYPE_SHORT = "short";
        public const string C_TYPE_INT = "int";
        public const string C_TYPE_LONG = "long";
        public const string C_TYPE_DECIMAL = "decimal";
        public const string C_TYPE_DOUBLE = "double";
        #endregion

        #region String title
        public static string TITLE_FILE_FOLDER = "Get Link File and Folder";
        public static string TITLE_SEARCH_FILE = "Search Files in the Folder";
        public static string TITLE_DATABASE = "Database Handling";
        #endregion

        #region Type Script SQL
        public static string TYPE_00_RESET_DATA = "00";
        public static string TYPE_01_TABLE_TYPE = "01TABLE";
        public static string TYPE_01_TABLE_ADD = "01TABLEADD";
        public static string TYPE_02_DATA_SYSTEM = "02";
        public static string TYPE_03_CREATE_VIEW = "03";
        public static string TYPE_04_CREATE_FUNCTION = "04";
        public static string TYPE_05_CREATE_PROCEDURE = "05";


        public static string STRING_00 = "00 Reset";
        public static string STRING_01_TYPE = "01 Type";
        public static string STRING_01_ADD = "01 Table";
        public static string STRING_02 = "02 System";
        public static string STRING_03 = "03 View";
        public static string STRING_04 = "04 Function";
        public static string STRING_05 = "05 Procedure";
        #endregion
    }
}
