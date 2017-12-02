using QLVT.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT.model
{
    class PhieuNhap
    {
        private String _mapn;
        private String _ngay;
        private String _maDH;
        private int _manv;
        private List<CTPN> _chitiet;

        public string Mapn
        {
            get
            {
                return _mapn;
            }

            set
            {
                _mapn = value;
            }
        }

        public string Ngay
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

        public int Manv
        {
            get
            {
                return _manv;
            }

            set
            {
                _manv = value; 
            }
        } 

        internal List<CTPN> Chitiet
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

        public static DataTable DSVatTu(String maDH)
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "EXEC SP_VAT_TU_TRONG_DON_HANG '" + maDH + "'";
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

        public static float tinhGia(int soluongdat, float dongia)
        {
            float gia = 0;
            gia = soluongdat * dongia;
            return gia;
        }

        public static bool LuuPhieuNhap(PhieuNhap phieunhap)
        {
            bool result = false;
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_THEM_PHIEU_NHAP"; 
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MAPN", phieunhap.Mapn);
                sqlCommand.Parameters.AddWithValue("@MasoDDH", phieunhap.MaDH);
                sqlCommand.Parameters.AddWithValue("@MANV", phieunhap.Manv);
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

        public static void XoaPhieuNhap(String Mapn)
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "DELETE FROM PhieuNhap WHERE MAPN = '" + Mapn + "'";
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
    }
}
