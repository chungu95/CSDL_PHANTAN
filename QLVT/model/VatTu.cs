using QLVT.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.model
{
    class VatTu
    {
        private String _mavt;
        private String _tenvt;
        private String _donvitinh;
        private int _soluongton;

        public string Mavt
        {
            get
            {
                return _mavt;
            }

            set
            {
                _mavt = value;
            }
        }

        public string Tenvt
        {
            get
            {
                return _tenvt;
            }

            set
            {
                _tenvt = value;
            }
        }

        public string Donvitinh
        {
            get
            {
                return _donvitinh;
            }

            set
            {
                _donvitinh = value;
            }
        }

        public int Soluongton
        {
            get
            {
                return _soluongton;
            }

            set
            {
                _soluongton = value; 
            }
        }

        public static DataTable DSVattu() 
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "SELECT * FROM VATTU ORDER BY TENVT";
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
