using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.DAL;
using IM.Facade;
using IM.Framework;
using System.Web.Security;

public partial class SponsorChildList : System.Web.UI.Page
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
                    txtSponsorDispalayID.ReadOnly = true;
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
            txtSponsorDispalayID.Text = userInfo.UserDesplayID;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSponsorDispalayID.Text.Trim()))
        {
            List<SystemUser> childUserList = new List<SystemUser>();
            using (TheFacade _facade = new TheFacade())
            {
                childUserList = _facade.TransactionFacade.GetSystemUserByDisplayId(txtSponsorDispalayID.Text.Trim());
            }
            lvChildList.DataSource = childUserList;
            lvChildList.DataBind();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }
    protected void lvChildList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem currentItem = (ListViewDataItem)e.Item;
            SystemUser systemUser = (SystemUser)((ListViewDataItem)(e.Item)).DataItem;

            Label lblName = (Label)currentItem.FindControl("lblName");
            Label lblUserName = (Label)currentItem.FindControl("lblUserName");
            Label lblDisplayName = (Label)currentItem.FindControl("lblDisplayName");
            Label lblContactNo = (Label)currentItem.FindControl("lblContactNo");
            Label lblEmail = (Label)currentItem.FindControl("lblEmail");

            lblName.Text = systemUser.FirstName + " " + systemUser.LastName;
            lblUserName.Text = systemUser.UserName;
            lblDisplayName.Text = systemUser.UserDesplayID;
            lblContactNo.Text = systemUser.ContactNo;
            lblEmail.Text = systemUser.Email;

        }
    }

}
