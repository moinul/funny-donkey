using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace IM.Framework
{
    public class EnumHelper
    {

        public enum WeekDay
        {
            No = -1,
            Saturday = 1,
            Sunday = 2,
            Monday = 3,
            Tuesday = 4,
            Wednesday = 5,
            Thursday = 6,
            Friday = 7

        }

        public enum UserTypeEnum
        {

            admin = 1,
            user,
            specialuser

        }

        public enum TransactionStatus
        {
            Completed = 1,
            Pending,
            Cancel
        }


        public enum UserTransactionType
        {
            Sponsor = 1,
            Click,
            Withdraw,
            Transfer,
            TransferFrom,
            TransferTo

        }

       
        public enum ListItemType
        {
            Select = -1,
            All

        }

        public enum RegistrationKeyStatus
        {
            User_Created = 1,
            User_Not_Created
        }
        public enum RegistrationPaymentType
        {
            Full_Paid = 1,
            Partial_Paid
        }

     
        public enum ActiveUserStatus
        {
            Active = 0,
            Inactive

        }

        public enum UserKeyInfoStatus
        {
            use = 1,
            NotUse

        }

        public enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December

        }



        #region Methods


        public static ListItemCollection EnumToList<T>()
        {
            ListItemCollection lists = new ListItemCollection();
            foreach (string item in Enum.GetNames(typeof(T)))
            {
                string modifyItem = item.ToString();
                int value = (int)Enum.Parse(typeof(T), item);
                modifyItem = item.Replace("__", " + ");
                modifyItem = modifyItem.Replace('_', ' ');
                ListItem listItem = new ListItem(/*item.Replace('_', ' ')*/modifyItem, value.ToString());

                lists.Add(listItem);

            }
            return lists;
        }

        public static string EnumToString<T>(int value)
        {
            ListItemCollection lists = EnumToList<T>();
            return lists.FindByValue(value.ToString()).Text;
        }
        public static string EnumToString<T>(T value)
        {
            ListItemCollection lists = EnumToList<T>();
            return lists.FindByValue(value.ToString()).Text;
        }

        public static int EnumToValue<T>(string value)
        {
            ListItemCollection lists = EnumToList<T>();
            return Convert.ToInt32(lists.FindByText(value.ToString()).Value);
        }

        public static string EnumToString<T1>(long p)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
