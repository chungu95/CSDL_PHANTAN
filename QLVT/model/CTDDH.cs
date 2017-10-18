using QLVT.Api;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLVT.model
{
    class CTDDH
    {
        private String _maDH;
        private String _mavt;
        private int _soluong;
        private float _dongia;

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

        public static bool LuuCTDDH(CTDDH chitiet) 
        {
            bool result = false;
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_THEM_CTDDH";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MasoDDH", chitiet.MaDH);
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
                    MessageBox.Show(ex.Message);
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
