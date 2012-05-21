using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.Facade;

public partial class SamplePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (TheFacade _facade = new TheFacade())
            {
                //   lblTest.Text = _facade.GeneralFacade.GetSystemUserById(14).UserName;
            }

        }
    }
}