using QLVT.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT.transaction
{
    class T_DatHang
    {
        public static bool LuuDonHang (DonHang donhang)
        {
            if (DonHang.LuuDonHang(donhang))
            {
                foreach(var item in donhang.Chitiet)
                {
                    if (!CTDDH.LuuCTDDH(item))
                    {
                        DonHang.XoaDonHang(donhang.MaDH);
                        MessageBox.Show("Có lỗi");
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
