﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using QLVT.model;
using QLVT.Api;
using System.Windows.Forms;

namespace QLVT.View
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            DataTable dt = CoSo.getServer();
            Program.DanhSachCoSo = CoSo.getDSCoSo();
            if (dt != null)
            {
                cbbChiNhanh.ValueMember = "subscriber";
                cbbChiNhanh.DisplayMember = "publication";
                cbbChiNhanh.DataSource = dt;
            }
        }

        private void cbbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Login.Coso = cbbChiNhanh.SelectedValue.ToString();
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnDangNhap.Enabled = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Login.LgName = txtUsername.Text;
            Login.Password = txtPassword.Text;
            Connector.DatasourceName = Login.Coso;
            Connector.ConnectionString = "Data Source=" + Connector.DatasourceName + ";Initial Catalog=" + "TRACNGHIEM" +
                               ";User ID="+Login.LgName+";Password="+Login.Password;
            var con = Connector.GetConnection();
            if (con != null && con.State == ConnectionState.Open)
            {
                try
                {
                    Program.SV_NAME = cbbChiNhanh.SelectedValue.ToString();
                    Login.doLogin();
                    new frmMain().Show(); Hide();
                } catch (Exception ex)
                {
                    Program.MaCoSo = "";
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
            }
        }
    }
}