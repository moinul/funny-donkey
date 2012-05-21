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

public partial class CreateClient : System.Web.UI.Page
{
    TheFacade _facade;
    Int64 clientId;

    SystemUser systemUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeUI();
            //  PopulateUI();
        }
    }

    public void PopulateUI(SystemUser systemUser)
    {
        //if (Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString()) > 0)
        //{
            using (TheFacade _facade = new TheFacade())
            {
                //clientId = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID].ToString());
                //SystemUser systemUser = _facade.TanviFacade.GetSystemUserById(clientId);

                txtUserName.Text = systemUser.UserName;
                txtFisrtName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtDOB.Text = "";
                txtAddress.Text = "";
                txtContactNo.Text = "";
                

                //txtReferrer.Text = systemUser.SponsorID.ToString();
                //ddlUserType.SelectedValue = systemUser.TypeID.ToString();
                //ddlPayment.SelectedValue = systemUser.RegistrationPaymentTypeID.ToString();
            }
        //}
    }

    private void InitializeUI()
    {
        using (_facade = new TheFacade())
        {
            
            ddlUserType.DataSource = _facade.TanviFacade.GetAllUserType();
            ddlUserType.DataTextField = "Name";
            ddlUserType.DataValueField = "IID";
            ddlUserType.DataBind();


            ddlPayment.DataSource = _facade.TanviFacade.GetAllRegistrationPaymentType();
            ddlPayment.DataTextField = "Name";
            ddlPayment.DataValueField = "IID";
            ddlPayment.DataBind();
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.Save();
    }

    private void Save()
    {
        string error = string.Empty;

        if (IsValidData(out error))
        {
            this.CreateUser();

        }
        else
        {
            //Show error msg
        }

    }

    private void FillData(SystemUser systemUser)
    {
        systemUser.UserName = txtUserName.Text;
        systemUser.FirstName = txtFisrtName.Text;
        systemUser.LastName = txtLastName.Text;
        systemUser.DOB = Convert.ToDateTime(txtDOB.Text);
        systemUser.Email = txtEmail.Text;
        systemUser.ContactNo = txtContactNo.Text;
        systemUser.Address = txtAddress.Text;
        // su.AspUserID 

    }

    private bool IsValidData(out string error)
    {
        error = string.Empty;

        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            lblPWMsg.Text = "Password not match.";
            return false;
        }

        using (IM.Facade.TheFacade facade = new IM.Facade.TheFacade())
        {
            SystemUser systemUser=facade.TanviFacade.GetSystemUserByUserName(txtUserName.Text);

            if (systemUser != null)
            {
                lblUserNameMsg.Text = "User Name Already exists.";
                return false;
            }

            if (facade.TanviFacade.GetValidUserKeyInfoByUserKey(txtKey.Text) == null)
            {
                lblKeyMsg.Text = "Invalid Key.";
                return false;
            }
            if (Convert.ToInt32(ddlUserType.SelectedValue) != Convert.ToInt32(EnumHelper.UserTypeEnum.admin))
            {
                SystemUser parentSystemUser = facade.TanviFacade.GetUserByDesplayID(txtParentID.Text);

                if (ddlParentHand.SelectedValue.ToString().ToUpper().Trim() == "RIGHT")
                {
                    if (parentSystemUser.RightHandID != null)
                    {
                        lblKeyMsg.Text = "Parent Right hand is not empty";
                        return false;
                    }

                }
                else
                {
                    if (parentSystemUser.LeftHandID != null)
                    {
                        lblKeyMsg.Text = "Parent Left hand is not empty";
                        return false;
                    }

                }
            }
        }
        return true;
    }

    private void CreateUser()
    {
        MembershipUser user = Membership.GetUser(txtUserName.Text.Trim());

        if (user == null)
        {
            user = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text);

            using (IM.Facade.TheFacade facade = new IM.Facade.TheFacade())
            {
                 systemUser = new IM.DAL.SystemUser();

                systemUser.UserName = txtUserName.Text;

                systemUser.TypeID = Convert.ToInt32(ddlUserType.SelectedValue.ToString());
                systemUser.IsRemoved = 0;
                systemUser.CreatedDate = DateTime.Now;
                systemUser.FirstName = txtFisrtName.Text;
                systemUser.LastName = txtLastName.Text;
                systemUser.ContactNo = txtContactNo.Text;
                systemUser.Email = txtEmail.Text;
                systemUser.DOB = Convert.ToDateTime(txtDOB.Text);
                systemUser.Address = txtAddress.Text;
                systemUser.AspUserID = (Guid)user.ProviderUserKey;
                systemUser.UserDesplayID = "IDS" + (facade.TanviFacade.GetSystemUserCount() + 1).ToString().PadLeft(5, '0');// new string('0',4) + (facade.TanviFacade.GetAllSystemUser().Count+ 1).ToString();
                systemUser.CreatedDate = DateTime.Now;
                systemUser.CreatedBy = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID]);
                //get user keyinfo id
                UserKeyInfo keyInfo = facade.TanviFacade.GetValidUserKeyInfoByUserKey(txtKey.Text);
                systemUser.AthunticationID = keyInfo.IID;
                ///
                long sponsorID = facade.TanviFacade.GetUserIDByDesplayID(txtReferrer.Text.ToUpper());
                if(sponsorID > 0)
                {
                systemUser.SponsorID  = sponsorID;
                }
                long parentUserID = facade.TanviFacade.GetUserIDByDesplayID(txtParentID.Text.ToUpper());
                if (parentUserID > 0)
                {
                    systemUser.ParentID = parentUserID;
                }
                facade.Insert(systemUser);
                Roles.AddUserToRole(txtUserName.Text, EnumHelper.EnumToString<EnumHelper.UserTypeEnum>(Convert.ToInt32(ddlUserType.SelectedValue.ToString())));
                facade.TanviFacade.DoPostRegistrationProcess(systemUser.IID, ddlParentHand.SelectedValue.ToString());
            }
            


            //using (_facade = new TheFacade())
            //{
            //    UserKeyInfo userKeyInfo = _facade.TanviFacade.GetValidUserKeyInfoByUserKey(txtKey.Text);

            //    userKeyInfo.Status = 1;
            //    _facade.Update(userKeyInfo);
            //}
            //this.PopulateUI(systemUser);

        }
        else
        {
           //show message  "User Name Alredy Exist"

        }
    }


}
