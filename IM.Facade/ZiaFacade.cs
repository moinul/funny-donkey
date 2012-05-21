using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.DAL;
using IM.Framework;

namespace IM.Facade
{
    public interface IZiaFacade
    {
        void Dispose();
        List<UserWithdrawRequest> GetUserWithdrawRequestAll();
        List<UserWithdrawRequest> GetUserWithdrawRequestAllByStatus(Int32 transactionStatus);
        UserWithdrawRequest GetUserWithdrawRequestByIID(long id);

        List<UserTransactionHistory> GetUserTransactionHistoryAll(Int32 transactionType);
        UserTransactionHistory GetUserTransactionHistoryByIID(long id, Int32 transactionType);
        UserTransactionHistory GetUserTransactionHistoryByTransactionKey(Guid transactionkey);

        List<UserWithdrawRequest> GetUserWithdrawRequestAllByStatus(long CurrentUserID, int transactionStatus);



        void UpdateBalanceForWithdraw(long CurrentUserID, decimal amount);
    }


    class ZiaFacade : CoreFacade, IZiaFacade
    {
        public ZiaFacade(IM.DAL.IDSDBDataContext database)
            : base(database)
        {
        }

        public void UpdateBalanceForWithdraw(long CurrentUserID, decimal amount)
        {
            Database.sp_UpdateUserBlance(CurrentUserID, (amount * -1));
 
        }

        public List<UserWithdrawRequest> GetUserWithdrawRequestAll()
        {
            List<UserWithdrawRequest> userWithdrawRequestList = new List<UserWithdrawRequest>();
            userWithdrawRequestList = Database.UserWithdrawRequests.ToList();
            foreach (UserWithdrawRequest userWithdrawRequest in userWithdrawRequestList)
            {
                userWithdrawRequest.SystemUser = userWithdrawRequest.SystemUser;
                UserTransactionHistory userTransactionHistory = new UserTransactionHistory();
                userTransactionHistory = GetUserTransactionHistoryByTransactionKey(userWithdrawRequest.TransactionKey);
                if (userTransactionHistory.IID > 0)
                {
                    userWithdrawRequest.UserTransactionHistory = userTransactionHistory;
                }
            }
            return userWithdrawRequestList;

        }
        public List<UserWithdrawRequest> GetUserWithdrawRequestAllByStatus(long CurrentUserID, int transactionStatus)
        {
            List<UserWithdrawRequest> userWithdrawRequestList = new List<UserWithdrawRequest>();
            userWithdrawRequestList = Database.UserWithdrawRequests.Where(ut => ut.TransactionStatus == transactionStatus && ut.UserID == CurrentUserID).ToList();
            foreach (UserWithdrawRequest userWithdrawRequest in userWithdrawRequestList)
            {
                userWithdrawRequest.SystemUser = userWithdrawRequest.SystemUser;
                UserTransactionHistory userTransactionHistory = new UserTransactionHistory();
                userTransactionHistory = GetUserTransactionHistoryByTransactionKey(userWithdrawRequest.TransactionKey);
                if (userTransactionHistory.IID > 0)
                {
                    userWithdrawRequest.UserTransactionHistory = userTransactionHistory;
                }
            }
            return userWithdrawRequestList;
        }
        public List<UserWithdrawRequest> GetUserWithdrawRequestAllByStatus(Int32 transactionStatus)
        {
            List<UserWithdrawRequest> userWithdrawRequestList = new List<UserWithdrawRequest>();
            userWithdrawRequestList = GetUserWithdrawRequestAll().Where(ut => ut.TransactionStatus == transactionStatus).ToList();
            return userWithdrawRequestList;
        }

        public UserWithdrawRequest GetUserWithdrawRequestByIID(long id)
        {
            UserWithdrawRequest userWithdrawRequest = new UserWithdrawRequest();
            userWithdrawRequest = GetUserWithdrawRequestAll().Single(u => u.IID == id);
            return userWithdrawRequest;
        }

        public List<UserTransactionHistory> GetUserTransactionHistoryAll(Int32 transactionType)
        {
            //Convert.ToInt32(EnumHelper.TransactionType.Withdraw)
            List<UserTransactionHistory> userTransactionHistoryList = new List<UserTransactionHistory>();
            userTransactionHistoryList = Database.UserTransactionHistories.Where(ut => ut.UserTransactionTypeID == transactionType ).ToList();
            return userTransactionHistoryList;
        }
        public UserTransactionHistory GetUserTransactionHistoryByIID(long id, Int32 transactionType)
        {
            UserTransactionHistory userTransactionHistory = GetUserTransactionHistoryAll(transactionType).Single(ut => ut.IID == id);
            return userTransactionHistory;
        }

        public UserTransactionHistory GetUserTransactionHistoryByTransactionKey(Guid transactionkey)
        {
            UserTransactionHistory userTransactionHistory = Database.UserTransactionHistories.Single(ut => ut.TransactionKey== transactionkey);
            return userTransactionHistory;
        }
    }
}
