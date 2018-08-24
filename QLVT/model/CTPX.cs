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
    class CTPX
    {
        private String _mapx;
        private String _mavt;
        private int _soluong;
        private float _dongia;

        public CTPX(string _mavt, int _soluong, float _dongia)
        {
            this._mavt = _mavt;
            this._soluong = _soluong;
            this._dongia = _dongia;
        }

        public CTPX()
        {

        }

        public string Mapx
        {
            get
            {
                return _mapx;
            }

            set
            {
                _mapx = value;
            }
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

        public int Soluong
        {
            get
            {
                return _soluong;
            }

            set
            {
                _soluong = value;
            }
        }

        public float Dongia
        {
            get
            {
                return _dongia;
            }

            set
            {
                _dongia = value;
            }
        }

        public static bool LuuCTPX(CTPX chitiet)
        {
            bool result = false;
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_THEM_CTPX";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MAPX", chitiet.Mapx);
                sqlCommand.Parameters.AddWithValue("@MAVT", chitiet.Mavt);
                sqlCommand.Parameters.AddWithValue("@SOLUONG", chitiet.Soluong);
                sqlCommand.Parameters.AddWithValue("@DONGIA", chitiet.Dongia);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    Connector.CloseConnection(con);
                }
            }
            return result;
        }

        public static bool CapNhatSoluong(string mavt, string mapn, int soluong)
        {
            bool result = false;
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_CAP_NHAT_SO_LUONG_CTPXN";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MAPN", mapn);
                sqlCommand.Parameters.AddWithValue("@MAVT", mavt);
                sqlCommand.Parameters.AddWithValue("@SOLUONG", soluong);
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

        public static bool TruSoLuong(string mavt, string makho, int soluong1)
        {
            int soluong = soluong1;
            List<CTPN> chitiet = PhieuXuat.DSVattuTrongKho(mavt, makho);
            for(int i = 0; i < chitiet.Count; i++)
            {
                int soluongcapnhat = 0;
                if (chitiet[i].Soluong - soluong < 0)
                {
                    if (!CapNhatSoluong(mavt, chitiet[i].Mapn, 0))
                        return false;
                    soluong = soluong - chitiet[i].Soluong;
                }
                else if(chitiet[i].Soluong - soluong == 0)
                {
                    if (!CapNhatSoluong(mavt, chitiet[i].Mapn, 0))
                        return false;
                    break;
                }else
                {
                    soluongcapnhat = chitiet[i].Soluong - soluong;
                    if (!CapNhatSoluong(mavt, chitiet[i].Mapn, soluongcapnhat))
                        return false;
                    break;
                }
            }
            return true;
        }

        public static bool CapNhatSoluong(List<CTPX> chitietpx, string makho)
        {
            foreach(CTPX item in chitietpx)
            {
                if(!TruSoLuong(item.Mavt, makho, item.Soluong))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
