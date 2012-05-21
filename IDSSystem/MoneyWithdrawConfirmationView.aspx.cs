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
using System.Collections.Generic;
using IM.Facade;
using IM.Framework;

public partial class MoneyWithdrawConfirmationView : System.Web.UI.Page
{
    public long CurrentUserWithdrawID
    {
        get
        {
            if (ViewState["CurrentUserWithdrawID"] == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(ViewState["CurrentUserWithdrawID"]);
            }
        }
        set { ViewState["CurrentUserWithdrawID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadListView();
        }
    }

    private void LoadListView()
    {
        List<UserWithdrawRequest> userWithdrawRequestList = new List<UserWithdrawRequest>();
        using (TheFacade _facade = new TheFacade())
        {
            userWithdrawRequestList = _facade.ZiaFacade.GetUserWithdrawRequestAllByStatus(Convert.ToInt32(EnumHelper.TransactionStatus.Pending));
            if (userWithdrawRequestList.Count > 0)
            {
                lvConfirmation.DataSource = userWithdrawRequestList;
                lvConfirmation.DataBind();
            }
        }
    }

    protected void lvConfirmation_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem currentItem = (ListViewDataItem)e.Item;
            UserWithdrawRequest userWithdrawRequest = (UserWithdrawRequest)((ListViewDataItem)(e.Item)).DataItem;
            Label lblRequestdate = (Label)currentItem.FindControl("lblRequestdate");
            Label lblAmount = (Label)currentItem.FindControl("lblAmount");
            LinkButton lnkUser = (LinkButton)currentItem.FindControl("lnkUser");
            LinkButton lnkConfirm = (LinkButton)currentItem.FindControl("lnkConfirm");

            lblRequestdate.Text = userWithdrawRequest.RequestDate.ToShortDateString();
            lblAmount.Text = userWithdrawRequest.UserTransactionHistory.ActualAmount.ToString("0.00");


            lnkUser.Text = userWithdrawRequest.SystemUser.FirstName + " " + userWithdrawRequest.SystemUser.LastName;

            lnkConfirm.CommandName = "DoConfirm";
            lnkConfirm.CommandArgument = userWithdrawRequest.IID.ToString();
        }
    }
    protected void lvConfirmation_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "DoConfirm")
        {

            using (TheFacade _facade = new TheFacade())
            {
                UserWithdrawRequest userWithdrawRequest = new UserWithdrawRequest();

                userWithdrawRequest = _facade.ZiaFacade.GetUserWithdrawRequestByIID(Convert.ToInt64(e.CommandArgument.ToString()));
                CurrentUserWithdrawID = userWithdrawRequest.IID;
                if (userWithdrawRequest.IID > 0)
                {
                    userWithdrawRequest = LoadUserWithdrawRequest(userWithdrawRequest);
                    _facade.Update<UserWithdrawRequest>(userWithdrawRequest);                    
                    UserTransactionHistory userTransactionHistory = _facade.ZiaFacade.GetUserTransactionHistoryByTransactionKey(userWithdrawRequest.TransactionKey);
                    userTransactionHistory.UserTransactionTypeID = Convert.ToInt32(EnumHelper.UserTransactionType.Withdraw);
                    userTransactionHistory.Status = Convert.ToInt32(EnumHelper.TransactionStatus.Completed);
                    _facade.Update<UserTransactionHistory>(userTransactionHistory);
                }
            }
        }
    }

    private UserWithdrawRequest LoadUserWithdrawRequest(UserWithdrawRequest userWithdrawRequest)
    {

        if (CurrentUserWithdrawID > 0)
        {
            userWithdrawRequest.TransactionStatus = Convert.ToInt32(EnumHelper.TransactionStatus.Completed);
            userWithdrawRequest.ComplitionDate = DateTime.Now;
        }
        return userWithdrawRequest;
    }

    protected void dpConfirmation_PreRender(object sender, EventArgs e)
    {
        LoadListView();
    }
}
