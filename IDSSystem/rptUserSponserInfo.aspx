<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true"
    CodeFile="rptUserSponserInfo.aspx.cs" Inherits="rptUserSponserInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="30%" align="right">
                <asp:Label ID="Label1" runat="server" Text="User Display ID :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtUserId" runat="server" Text="" />
                <cc1:TextBoxWatermarkExtender ID="txtUserId_TextBoxWatermarkExtender1" runat="server"
                    TargetControlID="txtUserId" WatermarkText="User Dispaly ID" />
                <cc1:AutoCompleteExtender ID="txtUserId_AutoCompleteExtender1" runat="server" TargetControlID="txtUserId"
                    ServiceMethod="SystemUserDisplayName" ServicePath="IDSService.asmx" MinimumPrefixLength="2"
                    CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20" ShowOnlyCurrentWordInCompletionListItem="true">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td width="30%" align="right">
            </td>
            <td align="left">
                <asp:Button ID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" id="tdInfo" runat="server" visible="false">
                <table width="100%">
                    <tr>
                        <td width="30%" align="right">
                            <asp:Label ID="Label2" runat="server" Text="Name :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" align="right">
                            <asp:Label ID="Label3" runat="server" Text="Display Name :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDisplayName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" align="right">
                            <asp:Label ID="Label5" runat="server" Text="Contact No :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblContactNo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" align="right">
                            <asp:Label ID="Label4" runat="server" Text="Email Address :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
