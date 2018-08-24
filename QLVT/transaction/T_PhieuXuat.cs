using QLVT.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.transaction
{
    class T_PhieuXuat
    {
        public static bool LuuPhieuXuat(PhieuXuat phieuxuat)
        {
            if (PhieuXuat.LuuPhieuXuat(phieuxuat))
            {
                foreach (var item in phieuxuat.Chitiet)
                {
                    if (!CTPX.LuuCTPX(item))
                    {
                        PhieuXuat.XoaPhieuXuat(phieuxuat.MaPX);
                        return false;
                    }
                }
                if(!CTPX.CapNhatSoluong(phieuxuat.Chitiet, phieuxuat.Makho))
                {
                    PhieuXuat.XoaPhieuXuat(phieuxuat.MaPX);
                    return false;
                }
            }
            return true;
        }
    }
}
