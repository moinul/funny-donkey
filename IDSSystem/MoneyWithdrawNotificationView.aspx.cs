using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using IM.DAL;
using IM.Framework;
using IM.Facade;
using System.Collections.Generic;

public partial class MoneyWithdrawNotificationView : System.Web.UI.Page
{
    public long CurrentNotificationID
    {
        get
        {
            if (ViewState["CurrentNotificationID"] == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(ViewState["CurrentNotificationID"]);
            }
        }
        set { ViewState["CurrentNotificationID"] = value; }
    }
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentUserID <= 0 )
        {
            Response.Redirect(@"~/NoPermission.aspx");
        }
        if (!IsPostBack)
        {
            LoadBalance();

            LoadListView();
        }
    }
    private void LoadBalance()
    {
        if (CurrentUserID > 0)
        {
            using (TheFacade _facade = new TheFacade())
            {
                UserBalance userbalance = _facade.AdvertiseFacade.GetUserBalanceByUserID(CurrentUserID);
                if (userbalance != null)
                {
                    lblAmount.Text = "Balance : " + userbalance.Amount.ToString("0.00");
                }
            }
        }
    }

    private void LoadListView()
    {
        List<UserWithdrawRequest> userWithdrawRequestList = new List<UserWithdrawRequest>();
        using (TheFacade _facade = new TheFacade())
        {
            userWithdrawRequestList = _facade.ZiaFacade.GetUserWithdrawRequestAllByStatus(CurrentUserID, Convert.ToInt32(EnumHelper.TransactionStatus.Pending));
            lvNotification.Items.Clear();
            lvNotification.DataSource = userWithdrawRequestList;
            lvNotification.DataBind();

        }
    }    

    private UserWithdrawRequest LoadUserWithdrawRequest(UserWithdrawRequest userWithdrawRequest)
    {
        
        if (CurrentNotificationID <= 0)
        {
            userWithdrawRequest.UserID = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString());
            //userWithdrawRequest.UserID = 2;
            userWithdrawRequest.TransactionKey = Guid.NewGuid();
            userWithdrawRequest.TransactionStatus = Convert.ToInt32(EnumHelper.TransactionStatus.Pending);
            userWithdrawRequest.RequestDate = DateTime.Now;
            userWithdrawRequest.Amount = Convert.ToDecimal(txtAmount.Text);
        }
        else
        {
            userWithdrawRequest.TransactionStatus = Convert.ToInt32(EnumHelper.TransactionStatus.Completed);
            userWithdrawRequest.ComplitionDate = DateTime.Now;
        }
        
        return userWithdrawRequest;
    }
    protected void btnWithdraw_Click(object sender, EventArgs e)
    {
        //lblMSG.Text = string.Empty;
        if (Convert.ToDecimal(txtAmount.Text) >= 10)
        {
            UserWithdrawRequest userWithdrawRequest = new UserWithdrawRequest();

            userWithdrawRequest = LoadUserWithdrawRequest(userWithdrawRequest);
            using (TheFacade _facade = new TheFacade())
            {
                _facade.Insert<UserWithdrawRequest>(userWithdrawRequest);
                if (userWithdrawRequest.IID > 0)
                {
                    UserTransactionHistory userTransactionHistory = new UserTransactionHistory();
                    LoadUserTransactionHistory(userTransactionHistory, userWithdrawRequest);
                    _facade.Insert<UserTransactionHistory>(userTransactionHistory);
                    _facade.ZiaFacade.UpdateBalanceForWithdraw(CurrentUserID, userWithdrawRequest.Amount);
                }
            }
            Response.Redirect(Request.Url.ToString());
        }
        else
        {
            lblMSG.Text = "The Amount must be greater than or equal to 10";
        }
    }

    private void ClearControl()
    {
        txtAmount.Text = string.Empty;
        lblMSG.Text = string.Empty;
    }

    private UserTransactionHistory LoadUserTransactionHistory(UserTransactionHistory userTransactionHistory, UserWithdrawRequest userWithdrawRequest)
    {
        if (CurrentNotificationID <= 0)
        {
            //userTransactionHistory.UserID = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString());
            userTransactionHistory.UserID = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString());
            userTransactionHistory.UserTransactionTypeID = Convert.ToInt32(EnumHelper.UserTransactionType.Withdraw);
            Decimal taxAmount = ((Convert.ToDecimal(txtAmount.Text) * 5) / 100);
            userTransactionHistory.Amount = Convert.ToDecimal(txtAmount.Text);
            userTransactionHistory.Date = DateTime.Now;
            userTransactionHistory.Description = string.Empty;
            userTransactionHistory.SponsorAmount = 0;
            userTransactionHistory.TAXAmount = taxAmount;
            userTransactionHistory.ActualAmount = Convert.ToDecimal(txtAmount.Text) - taxAmount;
            userTransactionHistory.TransactionKey = userWithdrawRequest.TransactionKey;
            userTransactionHistory.Status = Convert.ToInt32(EnumHelper.TransactionStatus.Pending);
        }
        else
        {
            userTransactionHistory.Status = Convert.ToInt32(EnumHelper.TransactionStatus.Completed);
        }
        return userTransactionHistory;
    }

    protected void lvNotification_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem currentItem = (ListViewDataItem)e.Item;
            UserWithdrawRequest userWithdrawRequest = (UserWithdrawRequest)((ListViewDataItem)(e.Item)).DataItem;
            Label lblRequestdate = (Label)currentItem.FindControl("lblRequestdate");
            Label lblAmount = (Label)currentItem.FindControl("lblAmount");
            LinkButton lnkUser = (LinkButton)currentItem.FindControl("lnkUser");
            LinkButton lnkVerify = (LinkButton)currentItem.FindControl("lnkVerify");

            lblRequestdate.Text = userWithdrawRequest.RequestDate.ToShortDateString();
            lblAmount.Text = userWithdrawRequest.UserTransactionHistory.ActualAmount.ToString("0.00");


            lnkUser.Text = userWithdrawRequest.SystemUser.FirstName + " " + userWithdrawRequest.SystemUser.LastName;

            lnkVerify.CommandName = "DoVerify";
            lnkVerify.CommandArgument = userWithdrawRequest.IID.ToString();
        }
    }
    
    protected void lvNotification_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "DoVerify")
        {

            //using (TheFacade _facade = new TheFacade())
            //{
            //    UserWithdrawRequest userWithdrawRequest = new UserWithdrawRequest();

            //    userWithdrawRequest = _facade.ZiaFacade.GetUserWithdrawRequestByIID(Convert.ToInt64(e.CommandArgument.ToString()));
            //    CurrentNotificationID = userWithdrawRequest.IID;
            //    if (userWithdrawRequest.IID > 0)
            //    {
            //        UserWithdrawRequest userWithdrawRequestUpdate = LoadUserWithdrawRequest(userWithdrawRequest);
            //        userWithdrawRequestUpdate.IID = CurrentNotificationID;
            //        _facade.Update<UserWithdrawRequest>(userWithdrawRequestUpdate);
            //        UserTransactionHistory userTransactionHistory = _facade.ZiaFacade.GetUserTransactionHistoryByTransactionKey(userWithdrawRequest.TransactionKey);
            //        UserTransactionHistory userTransactionHistoryUpdate = LoadUserTransactionHistory(userTransactionHistory, userWithdrawRequest);

            //    }
            //}
        }
    }

    protected void dpNotification_PreRender(object sender, EventArgs e)
    {
        LoadListView();
    }
}
