using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.model.db_response
{
    class CTDDHResponse
    {
        private String _mavt;
        private String _tenvt; 
        private int _soluong;
        private float _dongia;

        public CTDDHResponse(string _mavt, string _tenvt, int _soluong, float _dongia)
        {
            this._mavt = _mavt;
            this._tenvt = _tenvt;
            this._soluong = _soluong;
            this._dongia = _dongia;
        }

        public string MaDH
        {
            get
            {
                return _tenvt;
            }

            set
            {
                _tenvt = value;
            }
        }

        public string Mavt
        {
            get
            {
                return _mavt;
            }

            set
            {
                _mavt = value;
            }
        }

        public int Soluong
        {
            get
            {
                return _soluong;
            }

            set
            {
                _soluong = value;
            }
        }

        public float Dongia
        {
            get
            {
                return _dongia;
            }

            set
            {
                _dongia = value;
            }
        }
    }
}
