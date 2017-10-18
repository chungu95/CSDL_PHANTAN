using QLVT.Api;
using System;
using System.Data;
using System.Data.SqlClient;


namespace QLVT.model
{
    class Login
    {
        private static string LGName;
        private static int _username;
        private static string _password;
        private static string _role;
        private static string _chinhanh;

        public static int Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public static string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public static string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public static string LgName
        {
            get { return LGName; }
            set { LGName = value; }
        }

        public static string Chinhanh
        {
            get { return _chinhanh; }
            set { _chinhanh = value; }
        }

        public static void doLogin()
        {
            string sql = "exec SP_DANG_NHAP '" + Login.LgName + "'";
            SqlConnection con = Connector.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            SqlDataAdapter data = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);
            Login.Username = Int32.Parse(dataTable.Rows[0][0].ToString());
            Login.Role = dataTable.Rows[0][2].ToString();
            Program.NHAN_VIEN = NhanVien.getThongtinNhanvien(Login.Username);
            Program.CHI_NHANH = ChiNhanh.getChinhanh(Program.NHAN_VIEN.Macn);
        }
    }
}
