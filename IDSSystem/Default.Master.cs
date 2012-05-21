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
using Data.SMSMoney;
using Facade.SMSMoney;
using Framework.SMSMoney;

namespace Web.SMSMoney
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session[GeneralConstant.LOGINUSERID] != null)
            //{
            //    divUserAfterLog.Visible = true;
            //    pnlBeforeLog.Visible = false;
            //    pnlAfterLog.Visible = true;
            //    using (TheFacade _facade = new TheFacade())
            //    {
            //        SystemUser user = _facade.UserFacade.GetBySystemUserID(Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString()));
            //        //lblName.Text = user.FirstName + " " + user.LastName;
            //        lblTotalBalance.Text = user.TotalBalance.ToString("0.00");
            //        lblBulkSmsQty.Text = user.BulkSMSQty.ToString();
            //        //lblEmail.Text = user.Email;
            //        if (user.Type == (int)EnumHelper.UserTypeEnum.speciasl)
            //        {
            //            lMenuProfileEdit.Visible = false;
            //            //lMenuChangePassword.Visible = false;
            //            lMenuCreditBalance.Visible = false;
            //            lMenuCreditBulk.Visible = false;
            //            divUserAfterLog.Visible = false;
            //            lMenuSendGift.Visible = false;
            //        }
            //        else
            //        {
            //            if (user.Type == (int)EnumHelper.UserTypeEnum.general)
            //            {
            //                lMenuTransfer.Visible = false;
            //                lMenuSendGift.Visible = true;
            //            } 
            //        }
            //    }
            //}
            //else
            //{
            //    divUserAfterLog.Visible = false;
            //    pnlBeforeLog.Visible = true;
            //    pnlAfterLog.Visible = false;
            //}
        }

        protected void btnlogIn_Click(object sender, EventArgs e)
        {
            //Label lblMsg = ((Label)lView.FindControl("lblMsg"));

            //TextBox txtName = ((TextBox)lView.FindControl("txtName"));
            //TextBox txtPass = ((TextBox)lView.FindControl("txtPass"));

            //lblMsg.Text = "";
            //if (Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
            //{
            //    string userName = txtUserName.Text.Trim();
            //    using (TheFacade facade = new TheFacade())
            //    {
            //        SystemUser lUser = facade.UserFacade.GetByUserName(userName);

            //        Session[GeneralConstant.LOGINUSERID] = lUser.IID.ToString();
            //        Session[GeneralConstant.LOGINUSERTYPE] = lUser.Type.ToString();

            //        FormsAuthentication.SetAuthCookie(userName, false);
            //        pnlBeforeLog.Visible = false;

            //        Response.Redirect("~/DashBoard.aspx");

            //    }

            //}
            //lblMsg.Text = "Invalid Username/Password.";

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Session.Abandon();
            //Response.Redirect("~/Default.aspx");
        }
    }
}
