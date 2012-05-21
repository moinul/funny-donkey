using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.DAL;
using IM.Facade;
using IM.Framework;

public partial class Advertise_ClickAdd : System.Web.UI.Page
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
        if (CurrentUserID <= 0)
        {
            Response.Redirect(@"~/NoPermission.aspx");
        }
        if (!IsPostBack)
        {
            
            LoadAdvertise();
            
        }
    }

    private void LoadAdvertise()
    {
        using (TheFacade facade = new TheFacade())
        {
            UserDailyLinkClick userDailyLinkClick = facade.AdvertiseFacade.GetUserDailyLinkClickToday(DateTime.Now.Date, CurrentUserID);
            if (userDailyLinkClick != null)
            {
                if (userDailyLinkClick.ClickCount < 20)
                {
                    lvAdd.DataSource = facade.AdvertiseFacade.GetRandomAdvertise(20 - userDailyLinkClick.ClickCount);
                    lvAdd.DataBind();
                }
            }
            else
            {
                lvAdd.DataSource = facade.AdvertiseFacade.GetRandomAdvertise(10);
                lvAdd.DataBind();
            }
        }
    }
    protected void lvAdd_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowAdd")
        {
            Guid messageId = System.Guid.NewGuid();
            Session["ads"] = messageId.ToString();
            Session["link"] = e.CommandArgument.ToString();
            ListViewDataItem currentItem = (ListViewDataItem)e.Item;
            LinkButton lnkAdd = (LinkButton)currentItem.FindControl("lnkAdd");
            lnkAdd.Enabled = false;
            //Response.Redirect("ShowAdd.aspx");
            //string newWindowUrl = "ShowAdd.aspx";
            //string javaScript =
            // "<script type='text/javascript'>\n" +
            // "<!--\n" +
            // "window.open('" + newWindowUrl + "');\n" +
            // "// -->\n" +
            // "</script>\n";
            //this.RegisterStartupScript("", javaScript);
            //LoadAdvertise();
            Response.Redirect("~/Advertise/ShowAdd.aspx");
        }
    }
    protected void lvAdd_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem currentItem = (ListViewDataItem)e.Item;
            Advertise add = (Advertise)((ListViewDataItem)(e.Item)).DataItem;

            LinkButton lnkAdd = (LinkButton)currentItem.FindControl("lnkAdd");
            lnkAdd.Text = add.Url;
            lnkAdd.CommandArgument = add.Url;
            lnkAdd.CommandName = "ShowAdd";
        }
    }
}
