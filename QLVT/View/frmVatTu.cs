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
    public partial class frmVatTu : DevExpress.XtraEditors.XtraForm
    {
        public frmVatTu()
        {
            InitializeComponent();
        }

        private void frmVatTu_Load(object sender, EventArgs e)
        {
            loadDsVT();
        }

        private void loadDsVT()
        {
            DataTable dt = VatTu.DSVattu();
            if (dt != null)
            {
                gridControl1.DataSource = dt;
            }
            //btnGhi.Visible = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}