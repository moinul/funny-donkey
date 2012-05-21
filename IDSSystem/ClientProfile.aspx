<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true"
    CodeFile="ClientProfile.aspx.cs" Inherits="ClientProfile" Title="Untitled Page" %>

<%@ Register Src="Controls/ctlShowClientGeneralInformation.ascx" TagName="ctlShowClientGeneralInformation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="1" cellspacing="1">
        <tr>
            <td align="left" valign="top">
                <div id="ClientBodyContainer">
                    <div id="ClientProfileHeader">
                        Customer Profile
                    </div>
                    <div id="GeneralInfoHeader">
                        General Information
                        <div style="float: right; font-size: 11px">
                            <a href="EditClient.aspx">Edit</a></div>
                    </div>
                    <div>
                        <uc2:ctlShowClientGeneralInformation ID="ctlShowClientGeneralInformation1" runat="server" />
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
