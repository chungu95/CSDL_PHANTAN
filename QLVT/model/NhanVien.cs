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
    class NhanVien
    {
        private String _manv;
        private String _hoten;
        private String _diachi;
        private DateTime _ngaysinh;
        private String _macn;

        public string Manv
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

        public DateTime Ngaysinh
        {
            get { return _ngaysinh; }
            set { _ngaysinh = value; }
        }

        public string Macn
        {
            get
            {
                return _macn;
            }

            set
            {
                _macn = value;
            }
        }

        public static NhanVien getThongtinNhanvien(string manv)
        {
            NhanVien nhanvien = null;
            SqlConnection con = Connector.GetConnection();
            string sql = "EXEC SP_THONGTINNHANVIEN '" + manv + "'";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    nhanvien = new NhanVien();
                    nhanvien.Manv = dataTable.Rows[0][0].ToString();
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
