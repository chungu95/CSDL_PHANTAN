using System;

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
            lblStatusChiNhanh.Text = Program.chinhanh.Chinhanh;
            lblStatusHoten.Text = Program.nhanvien.Hoten;
            lblStatusManv.Text = Program.nhanvien.Manv;
        }
    }
}