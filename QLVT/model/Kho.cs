using QLVT.Api;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLVT.model
{
    class Kho
    {
        private String _makho;
        private String _tenkho;
        private String _diachi;
        private String _chinhanh;

        public string Makho
        {
            get
            {
                return _makho;
            }

            set
            {
                _makho = value;
            }
        }

        public string Tenkho
        {
            get
            {
                return _tenkho;
            }

            set
            {
                _tenkho = value;
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

        public static DataTable getDSKho(string macn)
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "SELECT MAKHO, TENKHO, DIACHI FROM Kho WHERE MACN = '" + macn + "'";
            try
            { 
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                    return dataTable;
                else
                    return null;

            }
            catch (Exception)
            {
                return null; 
            }
            finally { Connector.CloseConnection(con); }
        }
    }
}
