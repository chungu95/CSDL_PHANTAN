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

        public VatTu(string _mavt, string _tenvt)
        {
            this._mavt = _mavt;
            this._tenvt = _tenvt;
        }

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
            string sql = "SELECT MAVT, TENVT , DVT FROM VATTU ORDER BY TENVT";
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

        public static Dictionary<String, VatTu> LoadDSVT(string makho)
        {
            Dictionary<String, VatTu> vattu = new Dictionary<string, VatTu>();
            SqlConnection con = Connector.GetConnection();
            string sql = "SELECT * FROM VATTU ORDER BY TENVT";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    for(int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string mavt = dataTable.Rows[i][0].ToString();
                        string tenvt = dataTable.Rows[i][1].ToString();
                        vattu.Add(mavt, new VatTu(mavt, tenvt));
                    }
                }

            }
            catch (Exception)
            {
                return vattu;
            }
            finally { Connector.CloseConnection(con); }
            for(int i = 0; i < vattu.Count; i++)
            {
                vattu.ElementAt(i).Value.Soluongton = SoLuongVTTrongKho(vattu.ElementAt(i).Value.Mavt, makho);
            }
            return vattu;
        }

        public static int SoLuongVTTrongKho(string mavt, string makho)
        {
            int soluong;
            SqlConnection con = Connector.GetConnection();
            DataTable datatable = new DataTable();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_SO_LUONG_VT_TRONG_KHO";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MAKHO", makho);
                sqlCommand.Parameters.AddWithValue("@MAVT", mavt);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(datatable);
                    if (datatable.Rows.Count > 0)
                    {
                        soluong = Int32.Parse(datatable.Rows[0][0].ToString());
                    }
                    else soluong = 0;
                }
                catch (Exception)
                {
                    return 0;
                }
                finally
                {
                    Connector.CloseConnection(con);
                }
            }
            return soluong;
        }
    }
}
