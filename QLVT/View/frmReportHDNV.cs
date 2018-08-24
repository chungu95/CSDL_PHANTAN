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
using QLVT.Api;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using QLVT.model;

namespace QLVT.View
{
    public partial class frmReportHDNV : DevExpress.XtraEditors.XtraForm
    {
        public frmReportHDNV()
        {
            InitializeComponent();
        }
        private void loadDsNhanVien()
        {
            DataTable dt = null;
            SqlConnection con = Connector.GetConnection();
            try
            {
                String sql = "select MANV from NhanVien";
                SqlCommand sqlcommand = new SqlCommand(sql, con);
                SqlDataAdapter sqldata = new SqlDataAdapter(sqlcommand);
                dt = new DataTable();
                sqldata.Fill(dt);


            }
            catch (Exception)
            { }
            finally { Connector.CloseConnection(con); }
            if (dt != null)
            {
                cmbMaNV.ValueMember = "MANV";
                cmbMaNV.DisplayMember = "MANV";
                cmbMaNV.DataSource = dt;
            }
        }


        private void btnIn_Click(object sender, EventArgs e)
        {
            String NgayBatDau = txtFromDate.Value.ToString("yyyy/MM/dd");
            String NgayKetThuc = txtToDate.Value.ToString("yyyy/MM/dd");
            String MANV = cmbMaNV.SelectedValue.ToString().Trim();
           // Connector.firstTimeBuild();
            //  MessageBox.Show(NgayBatDau);
            SqlConnection con = Connector.GetConnection();

            using (SqlCommand sqlCommand = con.CreateCommand())
            {
                sqlCommand.CommandText = "SP_HOAT_DONG_NHAN_VIEN";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MANV", MANV);
                sqlCommand.Parameters.AddWithValue("@FROMDATE", NgayBatDau);
                sqlCommand.Parameters.AddWithValue("@TODATE", NgayKetThuc);
                //sqlCommand.Parameters.AddWithValue("@MaNhanP", hoadon.MaNhanPhong);
                //sqlCommand.Parameters.AddWithValue("@MaNV", hoadon.MaNhanVien);


                // sqlCommand.Parameters.AddWithValue("@NgayLap", new SqlDateTime(hoadon.NgayLap));
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                reportHDNV report = new reportHDNV();
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

        private void frmReportHDNV_Load(object sender, EventArgs e)
        {
            loadDsNhanVien();
        }

        private void cmbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhanVien nhanvien = NhanVien.getThongtinNhanvien(Convert.ToInt32( cmbMaNV.SelectedValue.ToString()));
            txtTenNV.Text = nhanvien.Hoten; 
           
        }
    }
}