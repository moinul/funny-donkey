using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.Framework;
using IM.Facade;
using IM.DAL;

public partial class Admin_CdeateAdd : System.Web.UI.Page
{
    protected long CurrentAddID
    {
        get
        {
            if (ViewState["AddID"] != null)
                return Convert.ToInt64(ViewState["AddID"]);
            else
                return -1;
        }
        set
        {
            ViewState["AddID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        if (!IsPostBack)
        {
            LoadListView();
            if (Session[GeneralConstant.ISSAVED] != null)
            {
                if (Convert.ToBoolean(Session[GeneralConstant.ISSAVED]) == true)
                    ShowMsg("Data Saved Successfully");
                else
                    ShowMsg("Problem On Saving Data");
            }
        }
    }

    private void LoadListView()
    {
        using (TheFacade facade = new TheFacade())
        {
            lvAdd.DataSource = facade.GeneralFacade.GetAllAdvertise();
            lvAdd.DataBind();
        }
    }

    private void ShowMsg(string msg)
    {
        lblMsg.Visible = true;
        lblMsg.Text = msg;
        Session[GeneralConstant.ISSAVED] = null;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            using (TheFacade facade = new TheFacade())
            {
                if (CurrentAddID <= 0)
                {
                    Advertise advertise = new Advertise();
                    advertise.Name = txtName.Text.Trim();
                    advertise.Url = txtUrl.Text.Trim();
                    facade.Insert<Advertise>(advertise);

                }
                else if (CurrentAddID > 0)
                {
                    Advertise advertise = facade.GeneralFacade.GetAdvertiseByIID(CurrentAddID);
                    advertise.Name = txtName.Text.Trim();
                    advertise.Url = txtUrl.Text.Trim();
                    facade.Update<Advertise>(advertise);
                }
            }
            Session[GeneralConstant.ISSAVED] = true;
        }
        catch
        {
            Session[GeneralConstant.ISSAVED] = true;
        }
        finally
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }
    protected void lvAdd_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "DoEdit")
        {

            CurrentAddID = Convert.ToInt64(e.CommandArgument.ToString());
            using (TheFacade facade = new TheFacade())
            {

                Advertise advertise = facade.GeneralFacade.GetAdvertiseByIID(CurrentAddID);
                txtUrl.Text = advertise.Url;
                txtName.Text = advertise.Name;
            }

        }
    }
    int slNo = 1;
    protected void lvAdd_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem currentItem = (ListViewDataItem)e.Item;
            Advertise advertise = (Advertise)((ListViewDataItem)(e.Item)).DataItem;

            Label lblSL = (Label)currentItem.FindControl("lblSL");
            Label lblName = (Label)currentItem.FindControl("lblName");

            HyperLink lblUrl = (HyperLink)currentItem.FindControl("lblUrl");
            LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");

            

            lblSL.Text = slNo.ToString();
            slNo++;
            lblName.Text = advertise.Name;

            lblUrl.NavigateUrl = advertise.Url;

            lnkEdit.CommandName = "DoEdit";
            lnkEdit.CommandArgument = advertise.IID.ToString();
        }
    }
}
