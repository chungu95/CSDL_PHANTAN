using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.model
{
    class ReportTHNX
    {

        private DateTime ngay;
        private float nhap;
        private float tylenhap;
        private float xuat;
        private float tylexuat;

        public DateTime NGAY
        {
            get
            {
                return ngay;
            }

            set
            {
                ngay = value;
            }
        }

        public float NHAP
        {
            get
            {
                return nhap;
            }

            set
            {
                nhap = value;
            }
        }

        public float TYLENHAP
        {
            get
            {
                return tylenhap;
            }

            set
            {
                tylenhap = value;
            }
        }

        public float XUAT
        {
            get
            {
                return xuat;
            }

            set
            {
                xuat = value;
            }
        }

        public float TYLEXUAT
        {
            get
            {
                return tylexuat;
            }

            set
            {
                tylexuat = value;
            }
        }
    }
}
