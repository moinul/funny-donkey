using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IM.Facade;
using IM.DAL;
using IM.Framework;
using System.Web.Security;
using System.Web.Script.Services;
using System.Web.Script.Serialization;


/// <summary>
/// Summary description for IDSService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.ComponentModel.ToolboxItem(false)]
[System.Web.Script.Services.ScriptService]
public class IDSSystemService : System.Web.Services.WebService
{
    public IDSSystemService()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [WebMethod(EnableSession = true)]
    public string[] SystemUserDisplayName(string prefixText, int count)
    {
        long userId = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID]);
        List<string> userDisplayNames = new List<string>();
        using (TheFacade _facade = new TheFacade())
        {
            userDisplayNames = _facade.TransactionFacade.GetUserDispalyNameBySearchText(prefixText);
        }
        return userDisplayNames.ToArray();
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string SystemUserNameByDispalyId(string displayId)
    {
        SystemUser systemUser = new SystemUser();
        using (TheFacade _facade = new TheFacade())
        {
            systemUser = _facade.TransactionFacade.GetSystemUserByDisplayName(displayId);
        }
        JasonObject _jasonObject = new JasonObject();
        if (systemUser != null)
        {
            _jasonObject.Id = systemUser.IID.ToString();
            _jasonObject.Name = systemUser.FirstName + " " + systemUser.LastName;
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        string str = js.Serialize(_jasonObject);
        return str;

    }
    [WebMethod(EnableSession = true)]
    public bool CheckUserPassword(string password)
    {
        bool _passwordMatch;
        long userId = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID]);
        using (TheFacade _facade = new TheFacade())
        {
            SystemUser systemUser = _facade.TransactionFacade.GetSystemUserById(userId);
            _passwordMatch = Membership.ValidateUser(systemUser.UserName, password);
        }
        return _passwordMatch;
    }
    [WebMethod(EnableSession = true)]
    public bool CheckUserAmount(string amount)
    {
        bool _isValidAmount = false;
        long userId = Convert.ToInt64(Session[GeneralConstant.LOGINUSERID]);
        decimal _amount;  
        UserBalance userBalance;
        using (TheFacade _facade = new TheFacade())
        {
            userBalance = _facade.TransactionFacade.GetUserBlanceById(userId);
            
        }
        if (userBalance != null && decimal.TryParse(amount,out _amount))
        {
            if (userBalance.Amount >= _amount) {
                _isValidAmount = true;
            }
        }
        return _isValidAmount;

    }
}

[Serializable]
public class JasonObject
{
    private string _Id = "0";

    public string Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    private string _name = string.Empty;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
