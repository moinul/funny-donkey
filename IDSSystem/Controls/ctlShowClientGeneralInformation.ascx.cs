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
using IM.DAL;
using IM.Facade;

public partial class Controls_ctlShowClientGeneralInformation : System.Web.UI.UserControl
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Populate(Int64 clientId)
    {
        if (clientId > 0)
        {
            using (TheFacade _facade = new TheFacade())
            {
                SystemUser systemUser = _facade.TanviFacade.GetSystemUserById(clientId);

                lblUserName.Text = systemUser.UserName;


                lblFisrtName.Text = systemUser.FirstName;
                lblLastName.Text = systemUser.LastName;
                lblEmail.Text = systemUser.Email;
                lblDOB.Text = systemUser.DOB.ToShortDateString();
                lblContactNo.Text = systemUser.ContactNo;
                lblAddress.Text = systemUser.Address;
                SystemUser sponsorUser = _facade.TanviFacade.GetSystemUserById(systemUser.SponsorID.Value);
                lblReferrer.Text = sponsorUser.UserDesplayID;

                lblDisplayId.Text = systemUser.UserDesplayID;
            }
        }
    }
}
