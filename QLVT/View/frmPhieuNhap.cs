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
using QLVT.model;

namespace QLVT.View
{
    public partial class frmPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void LoadDonHang()
        {
            DataTable dt = DonHang.LayDSDHChuaCoPhieuNhap();
            if (dt != null)
            {
                cmbDonDDH.ValueMember = "MasoDDH";
                cmbDonDDH.DisplayMember = "MasoDDH";
                cmbDonDDH.DataSource = dt;
            }
        }
    }
}