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

public partial class EditClient : System.Web.UI.Page
{

    TheFacade _facade;
    Int64 clientId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeUI();
            PopulateUI();
        }
    }

    public void PopulateUI()
    {
        if (Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString()) > 0)
        {
            using (TheFacade _facade = new TheFacade())
            {
                //  clientId = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString());
                SystemUser systemUser = _facade.TanviFacade.GetSystemUserById(clientId);

                //  txtUserName.Text = systemUser.UserName;
                txtFisrtName.Text = systemUser.FirstName;
                txtLastName.Text = systemUser.LastName;
                txtEmail.Text = systemUser.Email;
                ctlCalender.SelectedDate = systemUser.DOB;
                txtContactNo.Text = systemUser.ContactNo;
                txtAddress.Text = systemUser.Address;
                txtDisplay.Text = systemUser.UserDesplayID;
                //txtReferrer.Text = systemUser.SponsorID.ToString();
                //ddlUserType.SelectedValue = systemUser.TypeID.ToString();
                //ddlPayment.SelectedValue = systemUser.RegistrationPaymentTypeID.ToString();
            }
        }
    }

    private void InitializeUI()
    {
        using (_facade = new TheFacade())
        {
            //ddlUserType.DataSource = _facade.TanviFacade.GetAllUserType();
            //ddlUserType.DataTextField = "Name";
            //ddlUserType.DataValueField = "IID";
            //ddlUserType.DataBind();


            //ddlPayment.DataSource = _facade.TanviFacade.GetAllRegistrationPaymentType();
            //ddlPayment.DataTextField = "Name";
            //ddlPayment.DataValueField = "IID";
            //ddlPayment.DataBind();

            clientId = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString());
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.Save();
    }

    private void Save()
    {
        string error = string.Empty;
        //bool result = true;
        if (IsValidData(out error))
        {

            //    this.createUser();
            using (TheFacade _facade = new TheFacade())
            {
                SystemUser user = _facade.TanviFacade.GetSystemUserById(Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString()));
                FillData(user);
                _facade.Update<SystemUser>(user);
            }
        }
        else
        {
            //Show error msg
        }

    }

    private void FillData(SystemUser systemUser)
    {
        // systemUser.UserName = txtUserName.Text;
        systemUser.FirstName = txtFisrtName.Text;
        systemUser.LastName = txtLastName.Text;
        systemUser.DOB = ctlCalender.SelectedDate.Value;
        systemUser.Email = txtEmail.Text;
        systemUser.ContactNo = txtContactNo.Text;
        systemUser.Address = txtAddress.Text;
        // su.AspUserID 

    }

    private bool IsValidData(out string error)
    {
        error = string.Empty;
        return true;
    }

    //private void createUser()
    //{
    //    MembershipUser user = Membership.GetUser(txtUserName.Text.Trim());

    //    if (user == null)
    //    {
    //        user = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text);

    //        using (IM.Facade.TheFacade facade = new IM.Facade.TheFacade())
    //        {
    //            IM.DAL.SystemUser systemUser = new IM.DAL.SystemUser();
    //            systemUser.UserName = txtUserName.Text;

    //            systemUser.TypeID = (int)IM.Framework.EnumHelper.UserTypeEnum.admin;
    //            systemUser.IsRemoved = 0;
    //            systemUser.CreatedBy = 1;
    //            systemUser.CreatedDate = DateTime.Now;
    //            systemUser.AspUserID = (Guid)user.ProviderUserKey;
    //            systemUser.FirstName = txtFisrtName.Text;
    //            systemUser.LastName = txtLastName.Text;
    //            systemUser.ContactNo = txtContactNo.Text;
    //            systemUser.Email = txtEmail.Text;
    //            systemUser.DOB = Convert.ToDateTime(txtDOB.Text);
    //            systemUser.Address = txtAddress.Text;

    //            facade.Insert(user);
    //        }
    //        Roles.AddUserToRole(txtUserName.Text, "admin");
    //    }
    //}
}
