using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.Facade;
using IM.DAL;
using IM.Framework;

public partial class Advertise_ShowAdd : System.Web.UI.Page
{
    protected long CurrentUserID
    {
        get
        {
            if (Session[GeneralConstant.LOGINUSERID] != null)
                return Convert.ToInt64(Session[GeneralConstant.LOGINUSERID]);
            else
                return -1;
        }
    }

    protected int CurrentCountDown
    {
        get
        {
            if (ViewState["CountDown"] != null)
                return Convert.ToInt32(ViewState["CountDown"]);
            else
                return -1;
        }
        set
        {
            ViewState["CountDown"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Session["ads"] != null && Session["link"] != null)
            {
                CurrentCountDown = 30;
                MyIframe.Attributes.Add("src", "http://" + Session["link"].ToString());//
                
                divMsg.Visible = false;
                Session["ads"] = null;
                Session["link"] = null;
                Label1.Text = "30";
                Timer1 = new Timer();
                Timer1.Interval = 1000; // 1 second
                //Timer1.Tick+=new EventHandler<EventArgs>(Timer1_Tick);
                //Timer1.star

            }
            else
            {
                //MyIframe.Visible = false;
                divMsg.Visible = true;

            }
        }
        //if (CurrentCountDown > 0)
        //{
        //    Timer1_Tick(null, null);
        //}
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (CurrentCountDown > 0)
        {
            CurrentCountDown = CurrentCountDown - 1;
            Label1.Text = CurrentCountDown.ToString();
            if (CurrentCountDown == 0)
            {
                //btnDone.Enabled = true;
                // User daily link click ins/upd
                // userbalance upd/ins
                // ins usertransactionhistory
                using (TheFacade facade = new TheFacade())
                {
                    UserDailyLinkClick userDailyLinkClickOld = facade.AdvertiseFacade.GetUserDailyLinkClickToday(DateTime.Now.Date,CurrentUserID);
                    if (userDailyLinkClickOld == null || userDailyLinkClickOld.IID <= 0)
                    {
                        UserDailyLinkClick userDailyLinkClick = new UserDailyLinkClick();
                        userDailyLinkClick.UserID = CurrentUserID;
                        userDailyLinkClick.ClickCount = 1;
                        userDailyLinkClick.Date = DateTime.Now;
                        facade.Insert<UserDailyLinkClick>(userDailyLinkClick);
                    }
                    else
                    {
                        int click = userDailyLinkClickOld.ClickCount;
                        userDailyLinkClickOld.ClickCount=click+1;
                        facade.Update<UserDailyLinkClick>(userDailyLinkClickOld);
                    }

                    decimal Amount = Convert.ToDecimal(0.05);
                    decimal sponsorAmount = (Amount * 5) / 100;
                    decimal actualAmount=Amount-sponsorAmount;
                    UserBalance userBalanceOld = facade.AdvertiseFacade.GetUserBalanceByUserID(CurrentUserID);
                    if (userBalanceOld == null)
                    {
                        UserBalance userBalance = new UserBalance();
                        userBalance.Amount = actualAmount;
                        userBalance.UserID = CurrentUserID;
                        facade.Insert<UserBalance>(userBalance);
                    }
                    else
                    {
                        userBalanceOld.Amount = userBalanceOld.Amount + actualAmount;
                        facade.Update<UserBalance>(userBalanceOld);
                    }

                    UserTransactionHistory userTransactionHistory = new UserTransactionHistory();
                    userTransactionHistory.UserID = CurrentUserID;
                    userTransactionHistory.UserTransactionTypeID = Convert.ToInt32(EnumHelper.UserTransactionType.Click);
                    userTransactionHistory.Amount = actualAmount ;
                    userTransactionHistory.ActualAmount = Amount;
                    userTransactionHistory.Date = DateTime.Now;
                    userTransactionHistory.Description = "You have received $"+actualAmount.ToString()+" for clicking a advetrisement";
                    userTransactionHistory.Status = 1;
                    userTransactionHistory.TAXAmount = 0;
                    Guid TransactionKey = System.Guid.NewGuid();

                    userTransactionHistory.TransactionKey = TransactionKey;

                    facade.Insert<UserTransactionHistory>(userTransactionHistory);

                    SystemUser user = facade.TanviFacade.GetSystemUserById(CurrentUserID);

                    UserTransactionHistory userTransactionHistory2 = new UserTransactionHistory();
                    userTransactionHistory2.UserID = user.SponsorID.Value;
                    userTransactionHistory2.UserTransactionTypeID = Convert.ToInt32(EnumHelper.UserTransactionType.Sponsor);
                    userTransactionHistory2.Amount = sponsorAmount;
                    userTransactionHistory2.ActualAmount = sponsorAmount;
                    userTransactionHistory2.Date = DateTime.Now;
                    userTransactionHistory2.Description = "You have received $" + sponsorAmount.ToString() + " sponsor amount for clicking a advetrisement of your sponsored user";
                    userTransactionHistory2.Status = 1;
                    userTransactionHistory2.TAXAmount = 0;
                    userTransactionHistory2.TransactionKey = TransactionKey;

                    facade.Insert<UserTransactionHistory>(userTransactionHistory2);
                    UserBalance sponsorUserBalance = facade.AdvertiseFacade.GetUserBalanceByUserID(user.SponsorID.Value);
                    if (sponsorUserBalance == null)
                    {
                        sponsorUserBalance = new UserBalance();
                        sponsorUserBalance.Amount = sponsorAmount;
                        sponsorUserBalance.UserID = user.SponsorID.Value;
                        facade.Insert<UserBalance>(sponsorUserBalance);
                    }
                    else
                    {
                        sponsorUserBalance.Amount = sponsorUserBalance.Amount + sponsorAmount;
                        facade.Update<UserBalance>(sponsorUserBalance);
                    }

                    Label1.Text = "Done";
                    Timer1.Enabled = false;
                    Response.Redirect("~/Advertise/ClickAdd.aspx");
                }
                
            }
        }
    }
}
