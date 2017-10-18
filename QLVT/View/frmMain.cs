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
            lblStatusChiNhanh.Text = Program.CHI_NHANH.Chinhanh;
            lblStatusHoten.Text = Program.NHAN_VIEN.Hoten;
            lblStatusManv.Text = Program.NHAN_VIEN.Manv.ToString();

        }
    }
}