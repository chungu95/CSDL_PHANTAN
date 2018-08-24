using DevExpress.XtraReports.UI;
using QLVT.Api;
using QLVT.model;
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
            LocQuyen();
        }

        private void LocQuyen()
        {
            if (Login.Role.Equals("USER"))
            {
                btnTaoTaiKhoan.Enabled = false;
            } else if (Login.Role.Equals("CONGTY"))
            {
                ribbonPage3.Visible = false;
                ribbonPage2.Visible = false;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblStatusChiNhanh.Text = Program.CO_SO.Tencs;
            lblStatusManv.Text = Program.USER.Username;
            lblStatusQuyen.Text = Program.USER.Userrole;
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
        private Form IsExist(Type fType)
        {
            foreach (var f in MdiChildren)
                if (f.GetType() == fType)
                    return f;
            return null;
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmNhanVien));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmVatTu));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmVatTu();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmKho));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmKho();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDonDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmMonHoc));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmPhieuNhap));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmPhieuNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmPhieuXuat));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmPhieuXuat();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTKSLN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmReportTKSLN));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmReportTKSLN();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHDNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmReportHDNV));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmReportHDNV();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTHNX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmReportTHNX));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmReportTHNX();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void btnTaoTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = IsExist(typeof(frmAddLogin));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmAddLogin();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}