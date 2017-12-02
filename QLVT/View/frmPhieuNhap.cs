using System;
using System.Collections.Generic;
using System.Data;
using QLVT.model;
using QLVT.model.db_response;
using System.Windows.Forms;
using QLVT.transaction;

namespace QLVT.View
{
    public partial class frmPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        float giaVT; 
        static List<CTDDHResponse> chitietDH;
        static List<CTPN> chitietPN;
        static PhieuNhap phieunhap;
        public frmPhieuNhap()
        {
            InitializeComponent();
            chitietDH = new List<CTDDHResponse>();
            chitietPN = new List<CTPN>();
        }
        

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDonHang();
            phieunhap = new PhieuNhap();
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

        private void LoadDSVatTu()
        {
            if (chitietDH.Count > 0)
            {
                chitietDH.Clear();
            }
            DataTable dt = PhieuNhap.DSVatTu(cmbDonDDH.SelectedValue.ToString());
            if (dt != null)
            {
                cmbMaVT.ValueMember = "MAVT";
                cmbMaVT.DisplayMember = "TENVT";
                cmbMaVT.DataSource = dt;
                LoadCTDDHToList(dt);
                txtSoLuongDat.Text = chitietDH[0].Soluong.ToString();
                txtSoLuongNhap.Text = chitietDH[0].Soluong.ToString();
            }
        }

        private void LoadCTDDHToList(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string mavt = dt.Rows[i][1].ToString();
                string tenvt = dt.Rows[i][0].ToString();
                int soluong = Int32.Parse(dt.Rows[i][2].ToString());
                float dongia = float.Parse(dt.Rows[i][3].ToString());
                chitietDH.Add(new CTDDHResponse(mavt, tenvt, soluong, dongia));
            }
        }

        private void cmbDonDDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDSVatTu();
            if(chitietDH.Count>0 && chitietDH != null)
                giaVT = chitietDH[0].Dongia;
            chitietPN = null;
        }

        private void LoadChiTietVatTu(String mavt)
        {
            for (int i = 0; i < chitietDH.Count; i++)
            {
                if (chitietDH[i].Mavt.Equals(mavt))
                {
                    txtSoLuongDat.Text = chitietDH[i].Soluong.ToString();
                    txtSoLuongNhap.Text = chitietDH[i].Soluong.ToString();
                    giaVT = chitietDH[i].Dongia;
                    break;
                }
            }
        }

        private void cmbMaVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChiTietVatTu(cmbMaVT.SelectedValue.ToString());
            loadSoLuongTrongPhieu(cmbMaVT.SelectedValue.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (phieunhap == null) phieunhap = new PhieuNhap();
            if (chitietPN == null) chitietPN = new List<CTPN>();
            if (checkSoLuong())
            {
                bool isExisted = false;
                for(int i=0; i<chitietPN.Count; i++)
                {
                    if (chitietPN[i].Mavt.Equals(cmbMaVT.SelectedValue.ToString())) {
                        isExisted = true;
                        if(Int32.Parse(txtSoLuongNhap.Text)+chitietPN[i].Soluong > Int32.Parse(txtSoLuongDat.Text))
                        {
                            MessageBox.Show("Không được nhập quá số lượng đặt");
                            return;
                        }
                        chitietPN[i].Soluong = chitietPN[i].Soluong + Int32.Parse(txtSoLuongNhap.Text);
                       // float dongia = chitietPN[i].Dongia + PhieuNhap.tinhGia(Int32.Parse(txtSoLuongNhap.Text), giaVT);
                       // chitietPN[i].Dongia = dongia;
                        refreshChiTiet();
                        loadSoLuongTrongPhieu(cmbMaVT.SelectedValue.ToString());
                        //loadGiaHienTai(cmbMaVT.SelectedValue.ToString());
                    }
                }
                if (!isExisted)
                {
                    string mavt = cmbMaVT.SelectedValue.ToString();
                    int soluong = Int32.Parse(txtSoLuongNhap.Text);
                    float dongia = giaVT;
                    //float dongia = PhieuNhap.tinhGia(Int32.Parse(txtSoLuongNhap.Text), giaVT);
                    chitietPN.Add(new CTPN(mavt, soluong, dongia));
                    refreshChiTiet();
                    loadSoLuongTrongPhieu(mavt);
                    //loadGiaHienTai(mavt);
                }
            }
        }

        private bool checkSoLuong()
        {
            try
            {
                int soluong = Int32.Parse(txtSoLuongNhap.Text);
                if (soluong <= 0)
                {
                    MessageBox.Show("Số lượng nhập phải lớn hơn 0");
                    return false;
                }
                else if (soluong > Int32.Parse(txtSoLuongDat.Text))
                {
                    MessageBox.Show("Số lượng nhập không được nhiều hơn số lượng đặt");
                    return false;
                }
            }
            catch (Exception) { return false; }
            return true;
        }

        private void btnXemGia_Click(object sender, EventArgs e)
        {
            if(checkSoLuong())
            txtDonGia.Text = PhieuNhap.tinhGia(Int32.Parse(txtSoLuongNhap.Text), giaVT).ToString();
        }

        private void refreshChiTiet()
        {
            txtSoLuongNhap.Text = "";
            //txtSoLuongDat.Text = "";
            txtDonGia.Text = ""; 
        }

        private void loadSoLuongTrongPhieu(string mavt) 
        {
            if (chitietPN == null) chitietPN = new List<CTPN>();
            bool isExisted = false; 
            for (int i = 0; i<chitietPN.Count; i++)
            {
                if (chitietPN[i].Mavt.Equals(mavt))
                {
                    isExisted = true;
                    txtSoLuongTrongPhieu.Text = chitietPN[i].Soluong.ToString();
                }
                if (!isExisted)
                {
                    txtSoLuongTrongPhieu.Text = "0"; 
                }
            }
        }

        private void loadGiaHienTai(string mavt)
        {
            if (chitietPN == null) chitietPN = new List<CTPN>();
            bool isExisted = false;
            for (int i = 0; i < chitietPN.Count; i++)
            {
                if (chitietPN[i].Mavt.Equals(mavt))
                {
                    isExisted = true;
                    txtGiaHT.Text = chitietPN[i].Dongia.ToString();
                }
                if (!isExisted)
                {
                    txtSoLuongTrongPhieu.Text = "0";
                }
            }
        }

        private bool checkMaPN()
        {
            if (txtMaPhieuNhap.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu");
                return false;
            } else if (txtMaPhieuNhap.Text.Length > 8)
            {
                MessageBox.Show("Mã phiếu không được nhập quá 8 ký tự");
                return false;
            }
            return true;
        }

        private void btnLuuPhieuNhap_Click(object sender, EventArgs e)
        {
            if (checkMaPN())
            {
                if (phieunhap == null) phieunhap = new PhieuNhap();
                phieunhap.Mapn = txtMaPhieuNhap.Text.Trim();
                phieunhap.MaDH = cmbDonDDH.SelectedValue.ToString().Trim();
                phieunhap.Manv = Program.NHAN_VIEN.Manv;
                phieunhap.Chitiet = chitietPN;
                if (phieunhap.Chitiet.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm vật tư vào đơn hàng");
                    return;
                }
                phieunhap.Chitiet.ForEach(item => item.Mapn = phieunhap.Mapn);
                if (T_PhieuNhap.LuuPhieuNhap(phieunhap)) 
                {
                    MessageBox.Show("Thêm thành công!");
                    refreshComponents();
                    LoadDonHang();
                }
            }
        }

        private void refreshComponents()
        {
            txtMaPhieuNhap.Text = "";
            txtSoLuongDat.Text = "";
            txtDonGia.Text = "";
            txtGiaHT.Text = "";
            txtSoLuongTrongPhieu.Text = "";
            txtSoLuongTrongPhieu.Text = "";
        }
    }
}