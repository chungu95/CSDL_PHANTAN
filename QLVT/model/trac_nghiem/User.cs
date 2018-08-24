using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.model.trac_nghiem
{
    class User
    {
        private String _username;
        private String _userrole;

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Userrole
        {
            get
            {
                return _userrole;
            }

            set
            {
                _userrole = value;
            }
        }

    }
}
