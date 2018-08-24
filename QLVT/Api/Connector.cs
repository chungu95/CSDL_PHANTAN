using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.Api
{
    class Connector
    {
        private static string _datasourceName = "DESKTOP-KA8V1NA";
        private static string _databaseName = "TRACNGHIEM";

        public static string ConnectionString { get; set; } = "";

        public static string DatasourceName
        {
            get { return _datasourceName; }
            set { _datasourceName = value; }
        }

        public static string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }


        public static SqlConnection GetConnection()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return con;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception)
            {
                //to do something...    
            }
        }

        public static void firstTimeBuild()
        {
            _datasourceName = "DESKTOP-KA8V1NA";
            ConnectionString = "Data Source=" + _datasourceName + ";Initial Catalog=" + DatabaseName +
                               ";User ID=sa;Password=123456";
        }
    }
}
