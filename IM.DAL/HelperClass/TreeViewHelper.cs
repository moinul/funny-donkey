using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.DAL.HelperClass
{
    public class TreeViewHelper
    {
        private string _controlName = string.Empty;

        public string ControlName
        {
            get { return _controlName; }
            set { _controlName = value; }
        }
        private SystemUser _user = null;

        public SystemUser User
        {
            get { return _user; }
            set { _user = value; }
        }

    }
}
