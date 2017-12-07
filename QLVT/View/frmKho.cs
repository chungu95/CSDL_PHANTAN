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
    public partial class frmKho : DevExpress.XtraEditors.XtraForm
    {
        private static int mode;
        public frmKho()
        {
            InitializeComponent();
        }
        private void clearEdit()
        {
            txtMaKho.Text = string.Empty;
            txtTenKho.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
         
        }
        private void enableEdit()
        {
            
            txtMaKho.Enabled = true;
            txtTenKho.Enabled = true;
            txtDiaChi.Enabled = true;
          
        }
        private void disableEdit()
        {
            txtMaKho.Enabled = false;
            txtTenKho.Enabled = false;
            txtDiaChi.Enabled = false;
           

          
        }
        private bool checkKHO()
        {
            if (txtMaKho.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập mã  kho!");
                return false;
            }
            else if (txtMaKho.Text.Trim().Length > 4)
            {
                MessageBox.Show("Mã đơn hàng phải nhỏ hơn hoặc bằng 4 ký tự");
                txtMaKho.Text = "";
                return false;
            }
            else if (txtTenKho.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập tên kho!");
                return false;
            }
            else if (txtDiaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!");
                return false;
            }
            return true;
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            if (Login.Role == "CHINHANH")
            {
                loadDsKho();

            }
        }
        private void loadDsKho()
        {
            DataTable dt = Kho.getDSKho(Program.CHI_NHANH.Macn);
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

                txtMaKho.Text = gridView1.GetFocusedDataRow()["MAKHO"].ToString().Trim();
                txtTenKho.Text = gridView1.GetFocusedDataRow()["TENKHO"].ToString().Trim();
                txtDiaChi.Text = gridView1.GetFocusedDataRow()["DIACHI"].ToString().Trim();
                //   dateTimePicker1.Value =  Convert.ToDateTime(gridView1.GetFocusedDataRow()["TEN"].ToString());
               // txtDiaChi.Text = gridView1.GetFocusedDataRow()["DIACHI"].ToString().Trim();
              //  txtLuong.Text = gridView1.GetFocusedDataRow()["LUONG"].ToString().Trim();
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
            txtMaKho.Enabled = false;
            mode = 2;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            var makho = txtMaKho.Text;
            var tenkho = txtTenKho.Text;
            var diachi = txtDiaChi.Text;
       
          
            var con = Connector.GetConnection();

            if (mode == 1)//them
            {
                if(checkKHO())
                {
                    using (var spCommand = con.CreateCommand())
                    {

                        spCommand.CommandText = "SP_THEM_KHO";
                        spCommand.CommandType = CommandType.StoredProcedure;
                        spCommand.Parameters.AddWithValue("@MACN", Program.CHI_NHANH.Macn);
                        spCommand.Parameters.AddWithValue("@MAKHO", makho.Trim());
                        spCommand.Parameters.AddWithValue("@TENKHO", tenkho.Trim());
                        spCommand.Parameters.AddWithValue("@DIACHI", diachi.Trim());


                        try
                        {
                            spCommand.ExecuteNonQuery();
                            MessageBox.Show("Thêm kho thành công");
                            loadDsKho();
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
                if (makho.Length <= 0)
                {
                    MessageBox.Show("vui lòng chọn kho cần sửa");
                }
                else
                {
                    if (checkKHO())
                    {
                        using (var spCommand = con.CreateCommand())
                        {

                            spCommand.CommandText = "SP_SUA_KHO";
                            spCommand.CommandType = CommandType.StoredProcedure;

                            spCommand.Parameters.AddWithValue("@MAKHO", makho.Trim());
                            spCommand.Parameters.AddWithValue("@MACN", Program.CHI_NHANH.Macn);
                            spCommand.Parameters.AddWithValue("@TENKHO", tenkho.Trim());
                            spCommand.Parameters.AddWithValue("@DIACHI", diachi.Trim());



                            try
                            {
                                spCommand.ExecuteNonQuery();
                                MessageBox.Show("Sửa kho thành công");
                                loadDsKho();

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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}