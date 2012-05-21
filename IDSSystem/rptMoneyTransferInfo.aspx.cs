using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.Framework;
using System.Web.Security;
using IM.DAL;
using IM.Facade;

public partial class rptMoneyTransferInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[GeneralConstant.LOGINUSERID] != null)
            {
                List<string> userRoleList = Roles.GetRolesForUser().ToList();
                if (userRoleList.Exists(delegate(string role) { return role == EnumHelper.EnumToString<EnumHelper.UserTypeEnum>(EnumHelper.UserTypeEnum.user); }))
                {
                    txtUserDispalayID.ReadOnly = true;
                }
                FillDefaultValue();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

    }

    private void FillDefaultValue()
    {
        SystemUser userInfo = new SystemUser();
        using (TheFacade _facade = new TheFacade())
        {
            userInfo = _facade.TransactionFacade.GetSystemUserById(Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString()));
        }
        if (userInfo != null)
        {
            txtUserDispalayID.Text = userInfo.UserDesplayID;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadTranferList();
    }

    private void LoadTranferList()
    {
        if (!string.IsNullOrEmpty(txtDateFrom.Text) && !string.IsNullOrEmpty(txtDateTo.Text))
        {
            DateTime fromDate = txtDateFrom.Text.Trim().ConvertToDateTime();
            DateTime toDate = txtDateTo.Text.Trim().ConvertToDateTime();
            List<UserMoneyTransfer> userMoneyTransferList;
            using (TheFacade _facade = new TheFacade())
            {
                userMoneyTransferList = _facade.TransactionFacade.GetUserTransferInfoByDispalyIdAndDateRange(txtUserDispalayID.Text.Trim(), fromDate, toDate);
            }
            lvTransaction.DataSource = userMoneyTransferList;
            lvTransaction.DataBind();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }
    protected void lvTransaction_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem currentItem = (ListViewDataItem)e.Item;
            UserMoneyTransfer userMoneyTransfer = (UserMoneyTransfer)((ListViewDataItem)(e.Item)).DataItem;

            Label lblDate = (Label)currentItem.FindControl("lblDate");
            Label lblUserName = (Label)currentItem.FindControl("lblUserName");
            Label lblAmount = (Label)currentItem.FindControl("lblAmount");

            lblDate.Text = userMoneyTransfer.Date.ConvertDateToString();
            lblUserName.Text = userMoneyTransfer.SystemUser.FirstName + " " + userMoneyTransfer.SystemUser.LastName;
            lblAmount.Text = userMoneyTransfer.Amount.ToString();
        }
    }
    protected void dpstdList_PreRender(object sender, EventArgs e)
    {
        LoadTranferList();
    }
}
