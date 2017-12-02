using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.model
{
    class ReportTKSLN
    {
        private int thang;
        private int nam;
        private int tongsoluong;
        private float tongtrigia;
        private String tenvt;

        public int Thang
        {
            get
            {
                return thang;
            }

            set
            {
                thang = value;
            }
        }

        public int Nam
        {
            get
            {
                return nam;
            }

            set
            {
                nam = value;
            }
        }



        public int TongSL
        {
            get
            {
                return tongsoluong;
            }

            set
            {
                tongsoluong = value;
            }
        }

        public float TongTriGia
        {
            get
            {
                return tongtrigia;
            }

            set
            {
                tongtrigia = value;
            }
        }

        public string TENVT
        {
            get
            {
                return tenvt;
            }

            set
            {
                tenvt = value;
            }
        }
    }
}
