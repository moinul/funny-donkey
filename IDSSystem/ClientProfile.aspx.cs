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
using IM.Framework;

public partial class ClientProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Int64 clientId = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString());
            ctlShowClientGeneralInformation1.Populate(clientId);
        }
    }
}
