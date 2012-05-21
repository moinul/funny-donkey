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

public partial class Controls_uclUserBalance : System.Web.UI.UserControl
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
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            ShowBalance();
        //}
    }

    private void ShowBalance()
    {
        if (CurrentUserID > 0)
        {
            using (TheFacade _facade = new TheFacade())
            {
                UserBalance userbalance = _facade.AdvertiseFacade.GetUserBalanceByUserID(CurrentUserID);
                if (userbalance != null)
                {
                    lblBalance.Text = "Balance : " + userbalance.Amount.ToString("0.00");
                }
            }
        }
    }
}
