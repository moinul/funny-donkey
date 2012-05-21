using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.DAL;
using IM.Framework;
using IM.DAL.HelperClass;

namespace IM.Facade
{
    public interface ITransactionFacade
    {
        void Dispose();
        #region UserTransaction
        void UserTransaction(string transactionKey, long fromUserId, long toUserId, decimal amount);
        #endregion
        #region SystemUser
        List<string> GetUserDispalyNameBySearchText(string prefix);
        SystemUser GetSystemUserByDisplayName(string displayName);
        SystemUser GetSystemUserById(long? userId);
        List<SystemUser> GetSystemUserByDisplayId(string sponsorDisplayId);
        SystemUser GetSponserUserByUserId(long userId);
        SystemUser GetSponserUserByUserDisplayId(string displayId);
        List<TreeViewHelper> GetUserChildNodeBy(string displayId);
        #endregion
        #region UserBlance
        UserBalance GetUserBlanceById(long userId);
        #endregion
        #region User Money Transfer
        List<UserMoneyTransfer> GetUserTransferInfoByDispalyIdAndDateRange(string userDisplayId, DateTime fromDate, DateTime toDate);
        #endregion
    }

    class TransactionFacade : CoreFacade, ITransactionFacade
    {
        public TransactionFacade(IDSDBDataContext database)
            : base(database)
        {
        }
        #region UserTransaction
        public void UserTransaction(string transactionKey, long fromUserId, long toUserId, decimal amount)
        {
            System.Data.Common.DbTransaction _transaction = null;
            IDSDBDataContext _dbcontext = DatabaseHelper.GetData();
            try
            {
                _dbcontext.Connection.Open();
                _transaction = _dbcontext.Connection.BeginTransaction();
                _dbcontext.Transaction = _transaction;

                //Transfer
                _dbcontext.sp_InsertUserTransfer(fromUserId, toUserId, amount, DateTime.Now, transactionKey);
                //Update user Blance
                _dbcontext.sp_UpdateUserBlance(fromUserId, (amount * -1));
                _dbcontext.sp_UpdateUserBlance(toUserId, amount);
                //Insert User History
                _dbcontext.sp_InsertUserTransactionHistory(fromUserId, Convert.ToInt32(EnumHelper.UserTransactionType.TransferFrom), amount, DateTime.Now, string.Format("Transfer {0} Taka to user {1}", amount, toUserId), 0, 0, 0, transactionKey, 1);
                _dbcontext.sp_InsertUserTransactionHistory(toUserId, Convert.ToInt32(EnumHelper.UserTransactionType.TransferTo), amount, DateTime.Now, string.Format("Add {0} Taka from user {1}", amount, fromUserId), 0, 0, 0, transactionKey, 1);

                _transaction.Commit();
            }
            catch (Exception ex)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                }
            }
            finally
            {
                if (_dbcontext.Connection.State == System.Data.ConnectionState.Open)
                {
                    _dbcontext.Connection.Close();
                }
            }

        }
        #endregion
        #region SystemUser
        public List<string> GetUserDispalyNameBySearchText(string prefix)
        {
            return Database.SystemUsers.Where(su => su.UserDesplayID.Contains(prefix)).Select(su => su.UserDesplayID).ToList();
        }
        public SystemUser GetSystemUserByDisplayName(string displayName)
        {
            return Database.SystemUsers.Where(su => su.UserDesplayID.ToLower().Equals(displayName.ToLower())).FirstOrDefault();
        }
        public SystemUser GetSystemUserById(long? userId)
        {
            if (userId == null)
                return null;
            return Database.SystemUsers.Where(su => su.IID == userId).FirstOrDefault();
        }
        public List<SystemUser> GetSystemUserByDisplayId(string sponsorDisplayId)
        {
            SystemUser systemUser = GetSystemUserByDisplayName(sponsorDisplayId);
            return Database.SystemUsers.Where(su => su.SponsorID == systemUser.IID).ToList();
        }

        public SystemUser GetSponserUserByUserId(long userId)
        {
            SystemUser systemUser = GetSystemUserById(userId);
            return Database.SystemUsers.Where(su => su.IID == systemUser.SponsorID).FirstOrDefault();
        }
        public SystemUser GetSponserUserByUserDisplayId(string displayId)
        {
            SystemUser systemUser = GetSystemUserByDisplayName(displayId);
            return Database.SystemUsers.Where(su => su.IID == systemUser.SponsorID).FirstOrDefault();
        }
        public List<TreeViewHelper> GetUserChildNodeBy(string displayId)
        {
            List<TreeViewHelper> treeViewHelperList = new List<TreeViewHelper>();
            SystemUser parentUser = GetSystemUserByDisplayName(displayId);
            treeViewHelperList.Add(addTree(parentUser, "node_parent"));
            //Left Child
            if (parentUser != null)
            {   
                SystemUser leftChild = GetSystemUserById(parentUser.LeftHandID);
                treeViewHelperList.Add(addTree(leftChild, "node_second_left"));
            }

            return treeViewHelperList;
        }
        private TreeViewHelper addTree(SystemUser systemUser, string controlName)//"node_second_left"
        {
            TreeViewHelper treeViewHelper = new TreeViewHelper();
            treeViewHelper.ControlName = controlName;
            treeViewHelper.User = systemUser;
            return treeViewHelper;
        }
        #endregion
        #region UserBlance
        public UserBalance GetUserBlanceById(long userId)
        {
            return Database.UserBalances.Where(ub => ub.UserID == userId).FirstOrDefault();
        }
        #endregion
        #region User Money Transfer
        public List<UserMoneyTransfer> GetUserTransferInfoByDispalyIdAndDateRange(string userDisplayId, DateTime fromDate, DateTime toDate)
        {
            SystemUser systemUser = GetSystemUserByDisplayName(userDisplayId);
            return Database.UserMoneyTransfers.Where(umf => umf.FromUser == systemUser.IID && umf.Date >= fromDate && umf.Date <= toDate).ToList();
        }
        #endregion
    }
}
