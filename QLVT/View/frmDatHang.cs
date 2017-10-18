using QLVT.model;
using QLVT.transaction;
using System;
using System.Data;
using System.Windows.Forms;
namespace QLVT.View
{
    public partial class frmDatHang : DevExpress.XtraEditors.XtraForm
    {
        private DonHang donhang;
        private CTDDH chitiet; 

        public frmDatHang()
        {
            InitializeComponent();
            donhang = new DonHang(); 
        }

        private void frmDatHang_Load(object sender, EventArgs e)
        {
            loadDSKho();
            loadDSVattu();
        }

        private void btnLuuDonHang_Click(object sender, EventArgs e)
        {
            if (checkMDH())
            {
                if (donhang == null) donhang = new DonHang();
                donhang.MaDH = txtMaDDH.Text.Trim();
                donhang.NhaCC = txtNhaCungCap.Text.Trim();
                donhang.MaKho = cbbKho.SelectedValue.ToString().Trim();
                donhang.Manv = Program.NHAN_VIEN.Manv;
                if (donhang.Chitiet.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm vật tư vào đơn hàng");
                    return;
                }
                donhang.Chitiet.ForEach(item => item.MaDH = donhang.MaDH);
                if (T_DatHang.LuuDonHang(donhang))
                {
                    MessageBox.Show("Thêm thành công!");
                    refreshComponents();
                }
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (checkSoLuong() && checkGia())
            {
                if (donhang == null) donhang = new DonHang();
                bool isExisted = false;
                if (chitiet == null)
                    chitiet = new CTDDH();
                chitiet.Mavt = cbbMaVatTu.SelectedValue.ToString().Trim();
                chitiet.Soluong = Int32.Parse(txtSoLuong.Text.Trim());
                chitiet.Dongia = float.Parse(txtDonGia.Text.Trim());
                for(int i = 0; i< donhang.Chitiet.Count; i++) {
                    if (donhang.Chitiet[i].Mavt.Equals(chitiet.Mavt))
                    {
                        donhang.Chitiet[i].Soluong += chitiet.Soluong;
                        donhang.Chitiet[i].Dongia += chitiet.Dongia;
                        isExisted = true;
                        break;
                    }
                }
                if (!isExisted)
                {
                    donhang.Chitiet.Add(chitiet);
                }
                refreshChiTiet();
            }
        }

        private void loadDSVattu()
        {
            DataTable dt = VatTu.DSVattu();
            if (dt != null)
            {
                cbbMaVatTu.DisplayMember = "TENVT";
                cbbMaVatTu.ValueMember = "MAVT";
                cbbMaVatTu.DataSource = dt;
            }
        }

        private void loadDSKho()
        {
            DataTable dt = Kho.getDSKho(Program.CHI_NHANH.Macn);
            if (dt != null)
            {
                cbbKho.ValueMember = "MAKHO";
                cbbKho.DisplayMember = "TENKHO";
                cbbKho.DataSource = dt;
            }
        }

        private void refreshComponents()
        {
            txtMaDDH.Text = "";
            txtNhaCungCap.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            donhang = null;
            chitiet = null;
        }

        private bool checkSoLuong()
        {
            try {
                if (Int32.Parse(txtSoLuong.Text.Trim()) <= 0)
                {
                    return false;
                }
            } catch 
            {
                MessageBox.Show("Số lượng phải là chữ số");
                return false;
            }
            return true;
        }

        private bool checkGia()
        {
            try
            {
                if (float.Parse(txtDonGia.Text.Trim()) <= 0)
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Giá tiền phải là chữ số");
                return false;
            }
            return true;
        }

        private void refreshChiTiet()
        {
            chitiet = null;
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
        }
        
        private bool checkMDH()
        {
            if (txtMaDDH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập mã đơn hàng!");
                return false;
            }else if(txtMaDDH.Text.Trim().Length > 8)
            {
                MessageBox.Show("Mã đơn hàng phải nhỏ hơn hoặc bằng 8 ký tự");
                txtMaDDH.Text = "";
                return false;
            }
            else if (txtNhaCungCap.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!");
                return false;
            } 
            return true;
        }

        private void btnRefrestDetails_Click(object sender, EventArgs e)
        {
            if(donhang!=null && donhang.Chitiet.Count != 0)
            {
                donhang.Chitiet.Clear();
            }
        }
    }
}