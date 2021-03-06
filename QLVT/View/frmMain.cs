﻿using DevExpress.XtraReports.UI;
using QLVT.Api;
using QLVT.View;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblStatusChiNhanh.Text = Program.CHI_NHANH.Chinhanh;
            lblStatusHoten.Text = Program.NHAN_VIEN.Hoten;
            lblStatusManv.Text = Program.NHAN_VIEN.Manv.ToString();

        }

        private void btnDHCCPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlConnection con = Connector.GetConnection();
            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_DON_HANG_CHUA_CO_PHIEU_NHAP";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                
                //sqlCommand.Parameters.AddWithValue("@MaNhanP", hoadon.MaNhanPhong);
                //sqlCommand.Parameters.AddWithValue("@MaNV", hoadon.MaNhanVien);


                // sqlCommand.Parameters.AddWithValue("@NgayLap", new SqlDateTime(hoadon.NgayLap));
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                report1DDHCCPN report = new report1DDHCCPN();
                //  report.TONGTIENTHANHTOAN(mahoadon);
                report.DataSource = dataTable;
                report.ShowPreviewDialog();




                try
                {
                    sqlCommand.ExecuteNonQuery();
                    //  result = true;
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
        }
    }
}