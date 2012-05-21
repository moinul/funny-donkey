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
using IM.DAL;
using IM.Facade;

public partial class GenerateUserKey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtAmount.Enabled = false;
            BindDDl();

        }
    }

    private void BindDDl()
    {
        DDLHelper.Bind(ddlPaymetType, EnumHelper.EnumToList<EnumHelper.RegistrationPaymentType>(), EnumHelper.ListItemType.Select);
    }
    protected void ddlPaymetType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch(Convert.ToInt32(ddlPaymetType.SelectedValue))
        { 
            case -1:
                txtAmount.Text = string.Empty;
                break;
            case 1:
                txtAmount.Text = "80";
                break;
        case 2:
                txtAmount.Text = "20";
                break;
        }
    }
    protected void btnGenerateKey_Click(object sender, EventArgs e)
    {
        UserKeyInfo keyInfo = new UserKeyInfo();
        keyInfo.Amount = Convert.ToDecimal(txtAmount.Text);
        keyInfo.CreatedDate = DateTime.Now;
        keyInfo.Status = Convert.ToInt32(EnumHelper.RegistrationKeyStatus.User_Not_Created);
        keyInfo.UserPaymetType = Convert.ToInt32(ddlPaymetType.SelectedValue.ToString());
        keyInfo.UserKey = Guid.NewGuid();
        keyInfo.KeyTaker = txtName.Text;
        keyInfo.KeyTakerPhone = txtPhoneNo.Text;
        using (TheFacade facade = new TheFacade())
        {
            facade.Insert<UserKeyInfo>(keyInfo);
        }
        if (keyInfo.IID > 0)
        {
            lblGenerateKey.Text = keyInfo.UserKey.ToString();
        }
    }
}
