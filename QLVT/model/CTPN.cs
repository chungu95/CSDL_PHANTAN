using QLVT.Api;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.model
{
    class CTPN
    {
        private String _mapn;
        private String _mavt;
        private int _soluong;
        private float _dongia;

        public CTPN(string _mavt, int _soluong, float _dongia)
        {
            this._mavt = _mavt;
            this._soluong = _soluong;
            this._dongia = _dongia;
        }



        public CTPN() { }

        public CTPN(string _mapn, string _mavt, int _soluong)
        {
            this._mapn = _mapn;
            this._mavt = _mavt;
            this._soluong = _soluong;
        }

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

        public static bool LuuCTPN(CTPN chitiet)
        {
            bool result = false;
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_THEM_CTPN";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MAPN", chitiet.Mapn);
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
    }
}
