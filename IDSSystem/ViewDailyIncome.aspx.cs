using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.Facade;

public partial class Advertise_ViewDailyIncome : System.Web.UI.Page
{
    protected long CurrentUserID
    {
        get
        {
            if (Session["UserID"] != null)
                return Convert.ToInt64(Session["UserID"]);
            else
                return -1;
        }
        set
        {
            Session["UserID"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["UserID"] = 2;
            LoadListView(DateTime.Now);
        }
    }

    private void LoadListView(DateTime dateTime)
    {
        using (TheFacade facade = new TheFacade())
        {
            gvDailyIncome.DataSource = facade.AdvertiseFacade.GetDailyIncome(dateTime, CurrentUserID);
            gvDailyIncome.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadListView(Convert.ToDateTime(txtDate.Text.Trim()));
    }
}
