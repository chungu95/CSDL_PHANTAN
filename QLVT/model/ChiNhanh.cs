using QLVT.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace QLVT.model
{
    class ChiNhanh
    {
        private String _macn;
        private String _chinhanh;
        private String _diachi;
        private String _sodt;

        public string Macn
        {
            get
            {
                return _macn;
            }

            set
            {
                _macn = value;
            }
        }

        public string Chinhanh
        {
            get
            {
                return _chinhanh;
            }

            set
            {
                _chinhanh = value;
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

        public string Sodt
        {
            get
            {
                return _sodt;
            }

            set
            {
                _sodt = value;
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
        public static ChiNhanh getChinhanh(string macn)
        {
            ChiNhanh chinhanh = null;
            SqlConnection con = Connector.GetConnection();
            string sql = "SELECT * FROM CHINHANH WHERE MACN = '" + macn + "'";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    chinhanh = new ChiNhanh();
                    chinhanh.Macn = dataTable.Rows[0][0].ToString();
                    chinhanh.Chinhanh = dataTable.Rows[0][1].ToString();
                    chinhanh.Diachi = dataTable.Rows[0][2].ToString();
                    chinhanh.Sodt = dataTable.Rows[0][3].ToString();
                }
            }
            catch (Exception)
            {
                // 
            }
            finally { Connector.CloseConnection(con); }
            return chinhanh;
        }
    }
}
