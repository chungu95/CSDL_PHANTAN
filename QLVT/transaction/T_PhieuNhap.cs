using QLVT.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.transaction
{
    class T_PhieuNhap
    {
        public static bool LuuPhieuNhap(PhieuNhap phieunhap) 
        {
            if (PhieuNhap.LuuPhieuNhap(phieunhap))
            {
                foreach (var item in phieunhap.Chitiet)
                {
                    if (!CTPN.LuuCTPN(item))
                    {
                        PhieuNhap.XoaPhieuNhap(phieunhap.Mapn);
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
