using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.DAL;
using IM.Framework;


namespace IM.Facade
{
    public interface ITanviFacade
    {
        void Dispose();

        #region SystemUser
        SystemUser GetSystemUserById(long userId);
        SystemUser GetSystemUserByUserName(string userName);
        List<SystemUser> GetAllSystemUser();
        SystemUser GetSystemUserByUserId(Guid userId);
        #endregion

        #region PaymentType
        List<RegistrationPaymentType> GetAllRegistrationPaymentType();
        #endregion

        #region UserType
        List<UserType> GetAllUserType();
        #endregion


        #region UserKeyInfo
        UserKeyInfo GetValidUserKeyInfoByUserKey(string userKey);
        #endregion


        int GetSystemUserCount();

        long GetUserIDByDesplayID(string displayID);

        void DoPostRegistrationProcess(long systemUserID, string handSide);

        SystemUser GetUserByDesplayID(string displayID);
    }


    class TanviFacade : CoreFacade, ITanviFacade
    {
        public TanviFacade(IDSDBDataContext database)
            : base(database)
        {
        }
        public SystemUser GetUserByDesplayID(string displayID)
        {
            return Database.SystemUsers.Where(s => s.UserDesplayID == displayID).FirstOrDefault();
        }
        public void DoPostRegistrationProcess(long systemUserID, string handSide)
        {
            Database.PostRegistrationProcess(systemUserID);
            if (!string.IsNullOrEmpty(handSide))
            {
                SystemUser user = Database.SystemUsers.Where(s => s.IID == systemUserID).FirstOrDefault();
                SystemUser parentUser = Database.SystemUsers.Where(s => s.IID == user.ParentID).FirstOrDefault();
                if (handSide.ToUpper() == "RIGHT")
                {
                    parentUser.RightHandID = user.IID;
                }
                else
                {
                    parentUser.LeftHandID = user.IID;
                }
                DatabaseHelper.Update<SystemUser>(Database, parentUser);
            }
        }

        public long GetUserIDByDesplayID(string displayID)
        {
            long sponsorID = 0;
            SystemUser user = Database.SystemUsers.Where(s => s.UserDesplayID.ToUpper() == displayID.ToUpper()).FirstOrDefault();
            if (user != null)
                sponsorID = user.IID;
            return sponsorID;
        }

        #region SystemUser
        public SystemUser GetSystemUserById(long userId)
        {
            SystemUser user = new SystemUser();
            try
            {
                user = Database.SystemUsers.Single(u => u.IID == userId);
            }
            catch (Exception ex)
            {
            }

            return user;
        }

        public SystemUser GetSystemUserByUserName(string userName)
        {
            SystemUser systemUser = new SystemUser();

          //  return Database.SystemUsers.Single(s => s.UserName.Equals(userName) && s.IsRemoved == 0);
            try
            {
                systemUser = Database.SystemUsers.Single(s => s.UserName==userName && s.IsRemoved == 0);
                return systemUser;
            }
            catch (Exception ex)
            {
                return null;
            }

            //return systemUser;
        }

        public List<SystemUser> GetAllSystemUser()
        {
            List<SystemUser> systemUserList = new List<SystemUser>();
            systemUserList = Database.SystemUsers.ToList();
            return systemUserList;
        }


        public SystemUser GetSystemUserByUserId(Guid userId)
        {
            SystemUser user = new SystemUser();
            try
            {
                user = Database.SystemUsers.Single(u => u.AspUserID == userId);
            }
            catch (Exception ex)
            {
            }

            return user;
        }

        public int GetSystemUserCount()
        {
            int count = 0;
            count = Database.SystemUsers.ToList().Count;

            return count;
        }
        #endregion

        #region UserType
        public List<UserType> GetAllUserType()
        {
            List<UserType> userTypeList = new List<UserType>();
            userTypeList = Database.UserTypes.ToList();
            return userTypeList;
        }
        #endregion

        #region PaymentType
        public List<RegistrationPaymentType> GetAllRegistrationPaymentType()
        {
            List<RegistrationPaymentType> paymentTypeList = new List<RegistrationPaymentType>();
            paymentTypeList = Database.RegistrationPaymentTypes.ToList();
            return paymentTypeList;
        }
        #endregion

        #region UserKeyInfo
        public UserKeyInfo GetValidUserKeyInfoByUserKey(string userKey)
        {
            UserKeyInfo userKeyInfo = new UserKeyInfo();
            try
            {
                Guid Temp = new Guid(userKey);
                userKeyInfo = Database.UserKeyInfos.Single(u => u.UserKey == Temp && u.Status == (int)EnumHelper.UserKeyInfoStatus.NotUse);
            }
            catch (Exception ex)
            {
            }

            return userKeyInfo;
        }
        #endregion
    }
}
