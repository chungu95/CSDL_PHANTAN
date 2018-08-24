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
using QLVT.Api;

namespace QLVT
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {

        private int mode;
        public frmNhanVien()
        {
            InitializeComponent();
            txtMaNV.Visible = false;
        }


        private void clearEdit()
        {
            txtMaNV.Text = string.Empty;
            txtHo.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;
            txtLuong.Text = string.Empty;
        }
        private void enableEdit()
        {
          //  txtMaNV.Enabled = true;
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            txtDiaChi.Enabled = true;
            txtLuong.Enabled = true;
            dateTimePicker1.Enabled = true;
        }
        private void disableEdit()
        {
            txtMaNV.Enabled = false;
            txtHo.Enabled = false;
            txtTen.Enabled = false;
            txtDiaChi.Enabled = false;

            txtLuong.Enabled = false;
            dateTimePicker1.Enabled = false;
        }


        private bool checkNHANVIEN()
        {
            if (txtHo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập họ!");
                return false;
            }
            else if (txtTen.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập tên");
               
                return false;
            }
            else if (txtDiaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!");
                return false;
            }
            
            return true;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            if (Login.Role == "CHINHANH")
            {
                loadDsNhanVien();
                
            }
        }
        private void loadDsNhanVien()
        {
            DataTable dt = NhanVien.getDsNhanVien(Program.MaCoSo);
            if (dt != null)
            {
                gridControl1.DataSource = dt;
            }
            btnGhi.Visible = false;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.RowCount != 0)
            {

                txtMaNV.Text = gridView1.GetFocusedDataRow()["MANV"].ToString().Trim();
                txtHo.Text = gridView1.GetFocusedDataRow()["HO"].ToString().Trim();
                txtTen.Text = gridView1.GetFocusedDataRow()["TEN"].ToString().Trim();
                //   dateTimePicker1.Value =  Convert.ToDateTime(gridView1.GetFocusedDataRow()["TEN"].ToString());
                txtDiaChi.Text = gridView1.GetFocusedDataRow()["DIACHI"].ToString().Trim();
                txtLuong.Text = gridView1.GetFocusedDataRow()["LUONG"].ToString().Trim();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnGhi.Visible = true;
            enableEdit();
            clearEdit();
            btnGhi.Text = "Thêm";
            mode = 1;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           
            enableEdit();
            btnGhi.Visible = true;
            btnGhi.Text = "Sửa";
            txtMaNV.Enabled = false;
            mode = 2;
            
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            var manv = txtMaNV.Text;
            var ho = txtHo.Text;
            var ten = txtTen.Text;
            var diachi = txtDiaChi.Text;
            var ngaysinh = dateTimePicker1.Value;
            var luong = txtLuong.Text;
            var con = Connector.GetConnection();

            if (mode == 1)//them
            {

                if (checkNHANVIEN())
                {
                    using (var spCommand = con.CreateCommand())
                    {

                        spCommand.CommandText = "SP_THEM_NHAN_VIEN";
                        spCommand.CommandType = CommandType.StoredProcedure;
                        spCommand.Parameters.AddWithValue("@MACN", Program.MaCoSo);
                        spCommand.Parameters.AddWithValue("@HO", ho.Trim());
                        spCommand.Parameters.AddWithValue("@TEN", ten.Trim());
                        spCommand.Parameters.AddWithValue("@DIACHI", diachi.Trim());
                        spCommand.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                        spCommand.Parameters.AddWithValue("@LUONG", luong.Trim());


                        try
                        {
                            spCommand.ExecuteNonQuery();
                            MessageBox.Show("Thêm thành công");
                            loadDsNhanVien();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
               
            }
            if (mode == 2)//them
            {
                
                if(manv.Length <=0)
                {
                    MessageBox.Show("vui lòng chọn nhân viên cần sửa");
                }
                else {
                    if(checkNHANVIEN())
                    {
                        using (var spCommand = con.CreateCommand())
                        {

                            spCommand.CommandText = "SP_SUA_NHAN_VIEN";
                            spCommand.CommandType = CommandType.StoredProcedure;

                            spCommand.Parameters.AddWithValue("@MANV", manv);
                            spCommand.Parameters.AddWithValue("@MACN", Program.MaCoSo);
                            spCommand.Parameters.AddWithValue("@HO", ho.Trim());
                            spCommand.Parameters.AddWithValue("@TEN", ten.Trim());
                            spCommand.Parameters.AddWithValue("@DIACHI", diachi.Trim());
                            spCommand.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                            spCommand.Parameters.AddWithValue("@LUONG", luong.Trim());


                            try
                            {
                                spCommand.ExecuteNonQuery();
                                MessageBox.Show("Sửa thành công");
                                loadDsNhanVien();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    
                }

                
            }




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
               
            
        
    
}