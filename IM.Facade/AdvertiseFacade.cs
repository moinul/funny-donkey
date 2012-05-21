using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.DAL;

namespace IM.Facade
{
    public interface IAdvertiseFacade
    {
        void Dispose();

        List<Advertise> GetRandomAdvertise(int count);


        UserDailyLinkClick GetUserDailyLinkClickToday(DateTime dateTime,long userID);

        UserBalance GetUserBalanceByUserID(long CurrentUserID);
        List<UserDailyIncomeResult> GetDailyIncome(DateTime dateTime, long userID);
    }
    class AdvertiseFacade : CoreFacade, IAdvertiseFacade
    {
        public AdvertiseFacade(IDSDBDataContext database)
            : base(database)
        {
        }

        public List<Advertise> GetRandomAdvertise(int count )
        {
            return Database.Advertises.Take(count).ToList();
        }
        public UserDailyLinkClick GetUserDailyLinkClickToday(DateTime dateTime,long userID)
        {
            return Database.UserDailyLinkClicks.Where(u => u.UserID == userID && u.Date.Date == dateTime.Date).FirstOrDefault();
        }
        public UserBalance GetUserBalanceByUserID(long CurrentUserID)
        {
            return Database.UserBalances.Where(u => u.UserID == CurrentUserID).FirstOrDefault();
        }
        public List<UserDailyIncomeResult> GetDailyIncome(DateTime dateTime, long userID)
        {
            return Database.UserDailyIncome(dateTime.Date, userID).ToList();
        }

    }
}
