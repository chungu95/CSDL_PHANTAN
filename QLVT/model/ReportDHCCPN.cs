using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.model
{
    class ReportDHCCPN
    {
        private String masoDDH;
        private DateTime ngay;
        private String nhacc;
        private String hoten;
        private String tenvt;
        private int soluong;
        private float dongia;

        public string MasoDDH
        {
            get
            {
                return masoDDH;
            }

            set
            {
                masoDDH = value;
            }
        }

        public string NhaCC
        {
            get
            {
                return nhacc;
            }

            set
            {
                nhacc = value;
            }
        }

        public string HOTEN
        {
            get
            {
                return hoten;
            }

            set
            {
                hoten = value;
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

        public int SOLUONG
        {
            get
            {
                return soluong;
            }

            set
            {
                soluong = value;
            }
        }

        public float DONGIA
        {
            get
            {
                return dongia;
            }

            set
            {
                dongia = value;
            }
        }
    }
}
