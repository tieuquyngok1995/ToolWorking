using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ToolWorking.Utils
{
    class DBUtils
    {
        // SQL Connection
        private static SqlConnection connection;

        /// <summary>
        /// Get Database connection, create string connection
        /// </summary>
        /// <param name="datasource"></param>
        /// <param name="database"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        /// <summary>
        ///  Get Database connection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetDBConnection()
        {
            string datasource = Properties.Settings.Default.serverDatabse;
            string database = Properties.Settings.Default.database;
            string username = Properties.Settings.Default.userDatabase;
            string password = Properties.Settings.Default.passDatabase;

            return GetDBConnection(datasource, database, username, password);
        }

        /// <summary>
        /// Check connection
        /// </summary>
        /// <returns></returns>
        public static bool IsConnection()
        {
            connection = GetDBConnection();
            try
            {
                if (connection != null)
                {
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Exuter script file
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="Exception"></exception>
        public static string ExecuteFileScript(string path)
        {
            string errMess = string.Empty;

            // Open and read file
            StreamReader streamReader = new StreamReader(path, Encoding.GetEncoding("shift-jis"));
            string scripts = streamReader.ReadToEnd();
            streamReader.Close();

            // Handel text script
            string[] arrScript = System.Text.RegularExpressions.Regex.Split(scripts, "\r\n[\t ]*GO");

            // Open connection
            connection = GetDBConnection();
            SqlCommand command = new SqlCommand(String.Empty, connection);
            connection.Open();

            // Run Script
            foreach (string script in arrScript)
            {
                try
                {
                    if (script.Trim() == string.Empty) continue;
                    if ((script.Length >= 3) && (script.Substring(0, 3).ToUpper() == "USE"))
                    {
                        throw new Exception("Create-script contains USE-statement. Please provide non-database specific create-scripts!");
                    }
                    command.CommandText = script;
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    errMess += ex.Message + "\r\n";
                }
            }

            connection.Close();
            return errMess;
        }

        /// <summary>
        /// Execute script sql
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string ExecuteScript(string query)
        {
            string errMess = string.Empty;

            // Open connection
            connection = GetDBConnection();
            connection.Open();
            SqlTransaction sqlTran = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand(query, connection, sqlTran);
                command.ExecuteNonQuery();
                sqlTran.Commit();
            }
            catch (SqlException ex)
            {
                sqlTran.Rollback();
                errMess += ex.Message + "\r\n";
            }

            connection.Close();
            return errMess;
        }
    }
}

