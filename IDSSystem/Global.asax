<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    protected void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        if (!Roles.RoleExists("Admin"))
        {
            Roles.CreateRole("Admin");
        }
        if (!Roles.RoleExists("user"))
        {
            Roles.CreateRole("user");
        }

        if (!Roles.RoleExists("specialuser"))
        {
            Roles.CreateRole("specialuser");
        }


        MembershipUser user = Membership.GetUser("IDSadmin");

        if (user == null)
        {
            user = Membership.CreateUser("IDSadmin", "admin123", "IDSadmin@IDSadmin.com");

            using (IM.Facade.TheFacade facade = new IM.Facade.TheFacade())
            {
                IM.DAL.SystemUser admin = new IM.DAL.SystemUser();
                admin.UserName = "IDSadmin";

                admin.TypeID = (int)IM.Framework.EnumHelper.UserTypeEnum.admin;
                admin.IsRemoved = 0;
                admin.CreatedBy = 1;
                admin.CreatedDate = DateTime.Now;
                admin.AspUserID = (Guid)user.ProviderUserKey;
                admin.FirstName = "Admin";
                admin.LastName = "Admin";
                admin.ContactNo = " ";
                admin.Email = "IDSadmin@IDSadmin.com";
                admin.DOB = DateTime.Now;
                facade.Insert(admin);
            }



            Roles.AddUserToRole("IDSadmin", "admin");

        }

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
