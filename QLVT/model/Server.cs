using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.model
{
    class Server
    {
        private String _chinhanh;
        private String _serverName;

        public string Chinhanh
        {
            get
            {
                return _chinhanh;
            }

            set
            {
                _chinhanh = value;
            }
        }

        public string ServerName
        {
            get
            {
                return _serverName;
            }

            set
            {
                _serverName = value;
            }
        }
    }
}
