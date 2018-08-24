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
    class PhieuXuat
    {
        private String _MaPX;
        private DateTime _Ngay;
        private String _hotenKH;
        private int _manv;
        private String _makho;
        private List<CTPX> _chitiet;

        public string MaPX
        {
            get
            {
                return _MaPX;
            }

            set
            {
                _MaPX = value;
            }
        }

        public DateTime Ngay
        {
            get
            {
                return _Ngay;
            }

            set
            {
                _Ngay = value;
            }
        }

        public string HotenKH
        {
            get
            {
                return _hotenKH;
            }

            set
            {
                _hotenKH = value;
            }
        }

        public int MaNV
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

        public List<CTPX> Chitiet
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

        public static bool LuuPhieuXuat(PhieuXuat phieuxuat)
        {
            bool result = false;
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_THEM_PHIEU_XUAT";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MAPX", phieuxuat.MaPX);
                sqlCommand.Parameters.AddWithValue("@HOTENKH", phieuxuat.HotenKH);
                sqlCommand.Parameters.AddWithValue("@MANV", phieuxuat.MaNV);
                sqlCommand.Parameters.AddWithValue("@MAKHO", phieuxuat.Makho);
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

        public static List<CTPN> DSVattuTrongKho(string mavt, string makho)
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "EXEC SP_DANH_SACH_VT_TRONG_KHO '" + mavt + "','"+makho+"'";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    List<CTPN> chitietphieunhap = new List<CTPN>();
                    for(int i = 0; i< dataTable.Rows.Count; i++)
                    {
                        string mapn = dataTable.Rows[i][0].ToString();
                        string mavattu = dataTable.Rows[i][1].ToString();
                        int soluong = Int32.Parse(dataTable.Rows[i][2].ToString());
                        chitietphieunhap.Add(new CTPN(mapn, mavattu, soluong));
                    }
                    return chitietphieunhap;
                }
                else
                    return null;

            }
            catch (Exception)
            {
                return null;
            }
            finally { Connector.CloseConnection(con); }
        }

        public static void XoaPhieuXuat(string mapx)
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "DELETE FROM PhieuXuat WHERE MAPX = '" + mapx + "'";
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
