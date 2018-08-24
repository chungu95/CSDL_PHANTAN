using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLVT.model;
using QLVT.Api;

namespace QLVT.View
{
    public partial class frmAddLogin : DevExpress.XtraEditors.XtraForm
    {
        private static string ROLE = "";
        public frmAddLogin()
        {
            InitializeComponent();
            LocQuyen();
        }

        private void LocQuyen()
        {
            if (Login.Role.Equals("CONGTY"))
            {
                rbChinhanh.Enabled = false;
                rbUser.Enabled = false;
            } else if (Login.Role.Equals("CHINHANH"))
            {
                rbCongty.Enabled = false;
            }
        }

        private void loadGDV()
        {
            string sql = "SELECT MANV,(HO + ' ' + TEN) AS HOTEN FROM NhanVien";
            SqlConnection con = Connector.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            cbbGiaoDichVien.DisplayMember = "HOTEN";
            cbbGiaoDichVien.ValueMember = "MANV"; cbbGiaoDichVien.DataSource = dataTable;
        }

        private void rbCongty_CheckedChanged(object sender, EventArgs e)  
        {
            ROLE = "CONGTY";
        }

        private void rbChinhanh_CheckedChanged(object sender, EventArgs e) 
        {
            ROLE = "CHINHANH";
        }

        private void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            ROLE = "USER";
        } 

        private void cbbGiaoDichVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!CheckNVCoTK(cbbGiaoDichVien.SelectedValue.ToString()))
            {
                btnAddUser.Enabled = true;
                txtUserName.Text = "";
                txtUserName.ReadOnly = false;
                //btnXoaUser.Enabled = false;
                lblThongBao.Text = "";
            }
            else
            {
                lblThongBao.Text = "Nhân viên này đã có tài khoản";
                btnAddUser.Enabled = false;
                txtUserName.Text = LayLoginName(cbbGiaoDichVien.SelectedValue.ToString());
                txtUserName.ReadOnly = true;
                //btnXoaUser.Enabled = true;
            }
        }
        private void frmAddLogin_Load(object sender, EventArgs e)
        {
            loadGDV();
        }

        private bool CheckNVCoTK(string manv)
        {
            DataTable dt = null;
            SqlConnection con = Connector.GetConnection();
            try
            {
                String sql = "EXEC SP_KIEM_TRA_LG '" + manv + "'";
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                dt = new DataTable();
                sqlData.Fill(dt);
            }
            catch (Exception)
            {//
            }
            finally { Connector.CloseConnection(con); }
            int result = Int32.Parse(dt.Rows[0][0].ToString());
            return (result == 1);
        }

        private string LayLoginName(string manv)
        {

            DataTable dt = null;
            SqlConnection con = Connector.GetConnection();
            try
            {
                String sql = "EXEC SP_LGNAME_VIA_MANV '" + manv + "'";
                SqlCommand sqlCommand = new SqlCommand(sql, con);
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                dt = new DataTable();
                sqlData.Fill(dt);
            }
            catch (Exception)
            {//
            }
            finally { Connector.CloseConnection(con); }
            return dt.Rows[0][0].ToString();
        }

        private bool TaoLG()
        {
            bool result = false;
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_TAO_LOGIN";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@LGNAME", txtUserName.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@PASS", txtPass.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@USERNAME", cbbGiaoDichVien.SelectedValue.ToString());
                sqlCommand.Parameters.AddWithValue("@ROLE", ROLE);
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

        private bool XoaLG()
        {
            bool result = false;
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_XOA_LOGIN"; sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@LGNAME", txtUserName.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@USERNAME", cbbGiaoDichVien.SelectedValue.ToString());
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập");
            }
            else if (txtPass.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
            }
            else if (!rbCongty.Checked && !rbChinhanh.Checked && !rbUser.Checked)
            {
                MessageBox.Show("Vui lòng chọn nhóm");
                return;
            }
            else
            {
                try
                {
                    if (TaoLG())
                    {
                        MessageBox.Show("Thêm thành công!");
                        txtUserName.Text = "";
                        txtPass.Text = "";
                        btnAddUser.Enabled = false;
                        //btnXoaUser.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Equals(Login.LgName))
            {
                MessageBox.Show("Bạn không thể xóa chính mình");
                return;
            }
            try
            {
                if (XoaLG())
                {
                    MessageBox.Show("Xóa thành công");
                    txtUserName.Text = "";
                    txtPass.Text = "";
                    lblThongBao.Text = "";
                    btnAddUser.Enabled = false;
                    //btnXoaUser.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }
        }
    }

}