using System;
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
using QLVT.View;

namespace QLVT.View
{
    public partial class frmReportTHNX : DevExpress.XtraEditors.XtraForm
    {
        public frmReportTHNX()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            String NgayBatDau = txtFromDate.Value.ToString("yyyy/MM/dd");
            String NgayKetThuc = txtToDate.Value.ToString("yyyy/MM/dd");
          //  MessageBox.Show(Login.Role);


            SqlConnection con = Connector.GetConnection();
            //    MessageBox.Show(NgayBatDau);


            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_TONG_HOP_NHAP_XUAT";
                sqlCommand.CommandType = CommandType.StoredProcedure;
              
                sqlCommand.Parameters.AddWithValue("@FROMDATE", NgayBatDau);
                sqlCommand.Parameters.AddWithValue("@TODATE", NgayKetThuc);
                //sqlCommand.Parameters.AddWithValue("@MaNhanP", hoadon.MaNhanPhong);
                //sqlCommand.Parameters.AddWithValue("@MaNV", hoadon.MaNhanVien);


                // sqlCommand.Parameters.AddWithValue("@NgayLap", new SqlDateTime(hoadon.NgayLap));
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                reportTKNX report = new reportTKNX();
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