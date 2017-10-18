using QLVT.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLVT.model
{
    class DonHang
    {
        private String _maDH;
        private DateTime _ngay;
        private String _nhaCC;
        private int _maNV;
        private String _maKho;
        private List<CTDDH> _chitiet; 

        public DonHang()
        {
            if(_chitiet == null)
            {
                _chitiet = new List<CTDDH>(); 
            }
        }

        public string MaDH
        {
            get
            {
                return _maDH;
            }

            set
            {
                _maDH = value;
            }
        }

        public string NhaCC
        {
            get
            {
                return _nhaCC;
            }

            set
            {
                _nhaCC = value;
            }
        }

        public string MaKho
        {
            get
            {
                return _maKho;
            }

            set
            {
                _maKho = value;
            }
        }

        public int Manv
        {
            get
            {
                return _maNV;
            }

            set
            {
                _maNV = value;
            }
        }

        public DateTime Ngay
        {
            get
            {
                return _ngay;
            }

            set
            {
                _ngay = value;
            }
        }

        public List<CTDDH> Chitiet 
        {
            get
            {
                return _chitiet;
            }

            set
            {
                _chitiet = value;
            }
        }

        public static bool LuuDonHang(DonHang donhang) 
        {
            bool result = false;
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_THEM_DON_HANG"; 
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MasoDDH", donhang.MaDH);
                sqlCommand.Parameters.AddWithValue("@NhaCC", donhang.NhaCC);
                sqlCommand.Parameters.AddWithValue("@MANV", donhang.Manv);
                sqlCommand.Parameters.AddWithValue("@MAKHO", donhang.MaKho);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Connector.CloseConnection(con);
                }
            }
            return result;
        }

        public static void XoaDonHang(String MaDH)
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "DELETE FROM DatHang WHERE MasoDDH = '" + MaDH + "'";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally { Connector.CloseConnection(con); }
        }

        public static DataTable LayDSDHChuaCoPhieuNhap()
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "EXEC SP_DON_HANG_CHUA_NHAP_DU";
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
