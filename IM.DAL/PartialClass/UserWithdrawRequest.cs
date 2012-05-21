using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.DAL
{
    public partial class UserWithdrawRequest
    {

        UserTransactionHistory _userTransactionHistory = new UserTransactionHistory();

        public UserTransactionHistory UserTransactionHistory
        {
            get { return _userTransactionHistory; }
            set { _userTransactionHistory = value; }
        }
    }
}
