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
using IM.Facade;
using IM.DAL;
using IM.Framework;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    private void UserLogin(string userName, string password)
    {
        if (userName == "")
        {
            lblMsg.Text = "User Name can not be blank.";
        }
        else if (password == "")
        {
            lblMsg.Text = "Password can not be blank.";
        }
        else
        {
            if (Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
            {
                using (TheFacade facade = new TheFacade())
                {
                    SystemUser lUser = facade.TanviFacade.GetSystemUserByUserName(userName.Trim());
                    if (lUser != null)
                    {
                        Session[GeneralConstant.LOGINUSERID] = lUser.IID.ToString();
                        Session[GeneralConstant.LOGINUSERTYPE] = lUser.TypeID.ToString();


                        FormsAuthentication.SetAuthCookie(userName, false);
                        if (lUser.TypeID == (int)EnumHelper.UserTypeEnum.admin)
                        {
                            Response.Redirect("AdminDashboard.aspx");
                        }
                        else if (lUser.TypeID == (int)EnumHelper.UserTypeEnum.user)
                        {
                            Response.Redirect("ClientProfile.aspx");
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Invalid Account.";
                    }
                }
            }
            else
            {
                lblMsg.Text = "Invalid Username/Password.";
            }

        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserLogin(txtUserName.Text, txtPassword.Text);
    }
}
