using QLVT.model;
using QLVT.transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT.View
{
    public partial class frmPhieuXuat : Form
    {
        private static PhieuXuat phieuxuat;
        private static List<CTPX> chitiet;
        private static int soluongton;
        private Dictionary<String, VatTu> listVT;
        public frmPhieuXuat()
        {
            InitializeComponent();
            phieuxuat = new PhieuXuat();
            chitiet = new List<CTPX>();
        }

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            loadDSVattu();
            LoadKho();
            listVT = VatTu.LoadDSVT(cmbMaKho.SelectedValue.ToString());
            soluongton = listVT.ElementAt(0).Value.Soluongton;
            txtSoLuongTon.Text = listVT.ElementAt(0).Value.Soluongton.ToString();
        }

        private void LoadKho()
        {
            DataTable dt = Kho.getDSKho(Program.MaCoSo);
            if (dt != null)
            {
                cmbMaKho.ValueMember = "MAKHO";
                cmbMaKho.DisplayMember = "TENKHO";
                cmbMaKho.DataSource = dt;
            }
        }

        private void loadDSVattu()
        {
            DataTable dt = VatTu.DSVattu();
            if (dt != null)
            {
                cmbMaVT.DisplayMember = "TENVT";
                cmbMaVT.ValueMember = "MAVT";
                cmbMaVT.DataSource = dt;
            }
        }

        private void cmbMaVT_SelectionChangeCommitted(object sender, EventArgs e) 
        {
            string mavattu = cmbMaVT.SelectedValue.ToString();
            bool isExisted = false;
            soluongton = listVT[mavattu].Soluongton;
            txtSoLuongTon.Text = soluongton.ToString();
            for(int i = 0; i < chitiet.Count; i++)
            {
                if (chitiet[i].Mavt.Equals(mavattu))
                {
                    txtSLTrongPhieu.Text = chitiet[i].Soluong.ToString();
                    isExisted = true;
                    break;
                }               
            }
            if(!isExisted)
            txtSLTrongPhieu.Text = "0";
        }

        private void cmbMaKho_SelectionChangeCommitted(object sender, EventArgs e) 
        {
            DialogResult result = MessageBox.Show("Đổi kho sẽ xóa toàn bộ vật tư đã thêm, bạn có đồng ý đổi?", "Xác nhận đổi kho", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                chitiet = null;
                chitiet = new List<CTPX>();
                string mavattu = cmbMaVT.SelectedValue.ToString();
                listVT = VatTu.LoadDSVT(cmbMaKho.SelectedValue.ToString());
                soluongton = listVT[mavattu].Soluongton;
                txtSoLuongTon.Text = soluongton.ToString();
                refreshChitiet();
                txtSLTrongPhieu.Text = "";
            }
            else if (result == DialogResult.No)
            {
                // Do something else
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (chitiet == null)
                chitiet = new List<CTPX>();
            string mavt = cmbMaVT.SelectedValue.ToString();
            int soluong;
            float dongia;
            if (Checksoluong() && Checkgia())
            {
                soluong = Int32.Parse(txtSoLuong.Text.Trim());
                dongia = float.Parse(txtDonGia.Text.Trim());
                bool isExisted = false;
                for (int i = 0; i < chitiet.Count; i++)
                {
                    if (chitiet[i].Mavt.Equals(mavt))
                    {
                        chitiet[i].Soluong = chitiet[i].Soluong + soluong;
                        chitiet[i].Dongia = dongia;
                        listVT[mavt].Soluongton = listVT[mavt].Soluongton - soluong;
                        soluongton = listVT[mavt].Soluongton;
                        txtSoLuongTon.Text = soluongton.ToString();
                        txtSLTrongPhieu.Text = chitiet[i].Soluong.ToString();
                        isExisted = true;
                    }
                }
                if(!isExisted){
                    chitiet.Add(new CTPX(mavt, soluong, dongia));
                    listVT[mavt].Soluongton = listVT[mavt].Soluongton - soluong;
                    soluongton = listVT[mavt].Soluongton;
                    txtSoLuongTon.Text = soluongton.ToString();
                    for (int i = 0; i < chitiet.Count; i++)
                    {
                        if (chitiet[i].Mavt.Equals(mavt))
                        {
                            txtSLTrongPhieu.Text = chitiet[i].Soluong.ToString();
                        }
                    }
                }
                refreshChitiet();
            }
        }

        private bool Checksoluong()
        {
            try
            {
                if (Int32.Parse(txtSoLuong.Text.Trim()) <= 0){
                    MessageBox.Show("Số lượng phải lớn hơn 0");
                    return false;
                } else if(Int32.Parse(txtSoLuong.Text.Trim()) > soluongton)
                {
                    MessageBox.Show("Số lượng vật tư còn trong kho không đủ");
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Số lượng phải là chữ số");
                return false;
            }
            return true;
        }

        private bool Checkgia()
        {
            try
            {
                if (float.Parse(txtDonGia.Text.Trim()) <= 0)
                {
                    MessageBox.Show("Đơn giá phải lớn hơn 0");
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đơn giá phải là chữ số");
                return false;
            }
            return true;
        }

        private void refreshChitiet()
        {
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KiemTraKhiLuu())
            {
                string mapx = txtMaPhieuXuat.Text.Trim();
                string hotenkh = txtHoTenKH.Text.Trim();
//                int manv = Program.NHAN_VIEN.Manv;
                string makho = cmbMaKho.SelectedValue.ToString();
                if (phieuxuat == null)
                    phieuxuat = new PhieuXuat();
                chitiet.ForEach(item => item.Mapx = mapx);
                phieuxuat.MaPX = mapx;
                phieuxuat.HotenKH = hotenkh;
//                phieuxuat.MaNV = manv;
                phieuxuat.Makho = makho;
                phieuxuat.Chitiet = chitiet;
                if (T_PhieuXuat.LuuPhieuXuat(phieuxuat))
                {
                    MessageBox.Show("Thêm phiếu xuất thành công");
                    RefreshAllComponents();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private bool KiemTraKhiLuu()
        {
            if (txtMaPhieuXuat.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu xuất");
                return false;
            } else if (txtMaPhieuXuat.Text.Trim().Length > 8)
            {
                MessageBox.Show("Mã phiếu không được dài quá 8 ký tự");
                return false;
            } else if (txtHoTenKH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng");
                return false;
            } else if (txtHoTenKH.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên khách hàng không được dài quá 100 ký tự");
                return false;
            } else if (chitiet == null || chitiet.Count == 0)
            {
                MessageBox.Show("Bạn chưa thêm vật tư");
                return false;
            }
            return true;
        }

        private void RefreshAllComponents()
        {
            string mavattu = cmbMaVT.SelectedValue.ToString();
            listVT = VatTu.LoadDSVT(cmbMaKho.SelectedValue.ToString());
            soluongton = listVT[mavattu].Soluongton;
            refreshChitiet();
            txtSoLuongTon.Text = soluongton.ToString();
            txtHoTenKH.Text = "";
            txtMaPhieuXuat.Text = "";
            txtSLTrongPhieu.Text = "";
            phieuxuat = null;
            chitiet = null;
        }
    }
}
