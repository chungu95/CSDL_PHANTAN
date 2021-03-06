﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using QLVT.Api;
using DevExpress.XtraReports.UI;
using QLVT.model;

namespace QLVT.View
{
    public partial class frmReportTKSLN : DevExpress.XtraEditors.XtraForm
    {
        public frmReportTKSLN()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            String NgayBatDau = txtFromDate.Value.ToString("yyyy/MM/dd");
            String NgayKetThuc = txtToDate.Value.ToString("yyyy/MM/dd");
            MessageBox.Show(Login.Role);


            SqlConnection con = Connector.GetConnection();
            //    MessageBox.Show(NgayBatDau);


            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_CHITIET_SOLUONG_NHAP";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ROLE", Login.Role);
                sqlCommand.Parameters.AddWithValue("@FROMDATE", NgayBatDau);
                sqlCommand.Parameters.AddWithValue("@TODATE", NgayKetThuc);
                //sqlCommand.Parameters.AddWithValue("@MaNhanP", hoadon.MaNhanPhong);
                //sqlCommand.Parameters.AddWithValue("@MaNV", hoadon.MaNhanVien);


                // sqlCommand.Parameters.AddWithValue("@NgayLap", new SqlDateTime(hoadon.NgayLap));
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                reportTKSLN report = new reportTKSLN();
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