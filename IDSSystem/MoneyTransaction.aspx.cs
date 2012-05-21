using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.Framework;
using IM.Facade;
using IM.DAL;
using System.Drawing;

public partial class MoneyTransaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[GeneralConstant.LOGINUSERID] != null)
            {
                lblYourUserId.Text = Session[GeneralConstant.LOGINUSERID].ToString();
                if (Session[GeneralConstant.ISSAVED] != null)
                {
                    if (Convert.ToBoolean(Session[GeneralConstant.ISSAVED].ToString()))
                    {
                        ShowMessage("Successfull Transaction", Color.Green);
                        Session[GeneralConstant.ISSAVED] = null;
                    }
                    else
                    {
                        ShowMessage("Transaction Faliur", Color.Red);
                        Session[GeneralConstant.ISSAVED] = null;
                    }

                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
            
        }
    }
    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                using (TheFacade _facade = new TheFacade())
                {
                    string transactionKey = Guid.NewGuid().ToString();
                    long fromUserId = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID]);
                    long toUserId = 0;
                    decimal amount = 0;
                    decimal.TryParse(txtAmount.Text.Trim(), out amount);
                    SystemUser toUser = _facade.TransactionFacade.GetSystemUserByDisplayName(txtToUser.Text.Trim());
                    if (toUser != null)
                    {
                        toUserId = toUser.IID;
                        _facade.TransactionFacade.UserTransaction(transactionKey, fromUserId, toUserId, amount);
                        Session[GeneralConstant.ISSAVED] = true;

                    }
                    else
                    {
                        Session[GeneralConstant.ISSAVED] = false;
                    }
                }
                Response.Redirect(Request.Url.ToString());
            }
        }
        catch (Exception ex)
        {
            ShowMessage("Transaction Faliur", Color.Red);
        }
    }

    private void ShowMessage(string mgs, Color color)
    {
        lblMgs.Visible = true;
        lblMgs.Text = mgs;
        lblMgs.Style.Add(HtmlTextWriterStyle.Color, color.Name);

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }
}
