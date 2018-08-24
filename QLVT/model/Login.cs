using QLVT.Api;
using System;
using System.Data;
using System.Data.SqlClient;


namespace QLVT.model
{
    class Login
    {
        private static string LGName;
        private static String _username;
        private static string _password;
        private static string _role;
        private static string _coso;

        public static String Username
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

        public static string Coso
        {
            get
            {
                return _coso;
            }

            set
            {
                _coso = value;
            }
        }

        public static void doLogin()
        {
            try
            {
                string sql = "exec SP_DANG_NHAP '" + Login.LgName + "'";
                SqlConnection con = Connector.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter data = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                data.Fill(dataTable);
                Login.Username = dataTable.Rows[0][0].ToString();
                Login.Role = dataTable.Rows[0][1].ToString();
                Program.USER.Username = Login.Username;
                Program.USER.Userrole = Login.Role;
                //               Program.USER = NhanVien.getThongtinNhanvien(Login.Username);
                Program.CO_SO = CoSo.getCosoViaSVName(Program.SV_NAME);
            } catch (Exception e)
            {
                throw e;
            }
        }
    }
}
