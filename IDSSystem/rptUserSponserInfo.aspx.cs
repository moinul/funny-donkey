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

public partial class rptUserSponserInfo : System.Web.UI.Page
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
                    txtUserId.ReadOnly = true;
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
           userInfo =  _facade.TransactionFacade.GetSystemUserById(Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString()));
        }
        if (userInfo != null)
        {
            txtUserId.Text = userInfo.UserDesplayID;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SystemUser sponserUserInfo = new SystemUser();
        using (TheFacade _facade = new TheFacade())
        {
            sponserUserInfo = _facade.TransactionFacade.GetSponserUserByUserDisplayId(txtUserId.Text.Trim());
        }
        if (sponserUserInfo != null)
        {
            lblName.Text = sponserUserInfo.FirstName + " " + sponserUserInfo.LastName;
            lblDisplayName.Text = sponserUserInfo.UserName;
            lblContactNo.Text = sponserUserInfo.ContactNo;
            lblEmail.Text = sponserUserInfo.Email;

            tdInfo.Visible = true;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }
}
