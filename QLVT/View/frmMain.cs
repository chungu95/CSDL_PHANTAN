using DevExpress.XtraReports.UI;
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
            var frm = IsExist(typeof(frmDatHang));
            if (frm != null)
            {
                frm.Activate();
                Console.Write(frm);
            }
            else
            {
                Console.Write(frm);
                var f = new frmDatHang();
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
    }
}