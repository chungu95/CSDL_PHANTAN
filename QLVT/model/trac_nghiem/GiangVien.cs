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
    class GiangVien
    {
        private int _magv;
        private String _hoten;
        private String _hocvi; 
        private String _makhoa; 

        public int Magv
        {
            get
            {
                return _magv;
            }

            set
            {
                _magv = value;
            }
        }

        public string Hoten
        {
            get
            {
                return _hoten;
            }

            set
            {
                _hoten = value;
            }
        }

        public string Hocvi
        {
            get
            {
                return _hocvi;
            }

            set
            {
                _hocvi = value;
            }
        }

        public string Makhoa
        {
            get
            {
                return _makhoa;
            }

            set
            {
                _makhoa = value;
            }
        }

        public static DataTable getDsNhanVien(string macn)
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "SELECT MANV, HO, TEN, DIACHI, NGAYSINH, LUONG, MACN from NhanVien where  MACN= '" + macn + "'";
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
        public static DataTable getdsNhanVien()
        {
            SqlConnection con = Connector.GetConnection();
            string sql = "";
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
        public static NhanVien getThongtinNhanvien(int manv)
        {
            NhanVien nhanvien = null;
            SqlConnection con = Connector.GetConnection();
            string sql = "EXEC SP_THONG_TIN_NHAN_VIEN '" + manv + "'";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    nhanvien = new NhanVien();
                    nhanvien.Manv = Int32.Parse(dataTable.Rows[0][0].ToString());
                    nhanvien.Hoten = dataTable.Rows[0][1].ToString();
                    nhanvien.Diachi = dataTable.Rows[0][2].ToString();
                    nhanvien.Ngaysinh = Convert.ToDateTime(dataTable.Rows[0][3].ToString());
                    nhanvien.Macn = dataTable.Rows[0][4].ToString();
                }
            }
            catch (Exception)
            {
                // 
            }
            finally { Connector.CloseConnection(con); }
            return nhanvien;
        }
    }
}
