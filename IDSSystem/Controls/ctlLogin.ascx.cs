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

public partial class Controls_ctlLogin : System.Web.UI.UserControl
{

    TheFacade theFacade;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    private void Login(string userName, string password)
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
        Login(txtUserName.Text, txtPassword.Text);
    }
}