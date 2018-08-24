using QLVT.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace QLVT.model
{
    class CoSo
    {
        private String _macs;
        private String _tencs;
        private String _diachi;

        public string Macs
        {
            get
            {
                return _macs;
            }

            set
            {
                _macs = value;
            }
        }

        public string Diachi
        {
            get
            {
                return _diachi;
            }

            set
            {
                _diachi = value;
            }
        }

        public string Tencs
        {
            get
            {
                return _tencs;
            }

            set
            {
                _tencs = value;
            }
        }

        public static DataTable getServer()
        {
            Connector.firstTimeBuild();
            String sql = "SELECT * FROM VIEW_DS_SERVER";
            SqlConnection con = Connector.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            SqlDataAdapter data = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);
            Connector.CloseConnection(con);
            return dataTable;
        }

        public static DataTable getDSCoSo()
        {
            String sql = "SELECT MACS, TENCS FROM COSO";
            SqlConnection con = Connector.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            SqlDataAdapter data = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);
            Connector.CloseConnection(con);
            return dataTable;
        }

        public static CoSo getCosoViaSVName(string serverName)  
        {
            CoSo coso = null;
            SqlConnection con = Connector.GetConnection();
            string sql = "SELECT * FROM COSO WHERE SV_NAME = '" + serverName + "'";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    coso = new CoSo();
                    coso.Macs = dataTable.Rows[0][0].ToString();
                    coso.Tencs = dataTable.Rows[0][1].ToString();
                    coso.Diachi = dataTable.Rows[0][2].ToString();
                }
            }
            catch (Exception)
            {
                // 
            }
            finally { Connector.CloseConnection(con); }
            return coso;
        }
    }
}
