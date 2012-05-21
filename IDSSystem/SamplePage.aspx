<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true"
    CodeFile="SamplePage.aspx.cs" Inherits="SamplePage" %>

<%@ Register Src="Controls/ctlLogin.ascx" TagName="ctlLogin" TagPrefix="uc1" %>
<%@ Register src="Controls/ctlRegistration.ascx" tagname="ctlRegistration" tagprefix="uc2" %>
<%@ Register src="Controls/ctlClientMenu.ascx" tagname="ctlClientMenu" tagprefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <div>    
    </div>
    <div>
       
    </div>
    <div>
    </div>
    <div>
    </div>
    <div>
    </div>
    <div>
    </div>--%>

    <uc1:ctlLogin ID="ctlLogin1" runat="server" />
     <uc2:ctlRegistration ID="ctlRegistration1" runat="server" />
     
    
      <asp:Label ID="lblTest" runat="server" Text="Text"></asp:Label>
     

<uc3:ctlClientMenu ID="ctlClientMenu1" runat="server" />
     

</asp:Content>
