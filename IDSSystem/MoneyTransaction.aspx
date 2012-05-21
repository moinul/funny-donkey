<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true"
    CodeFile="MoneyTransaction.aspx.cs" Inherits="MoneyTransaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script src="Scripts/IDSScript.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblMgs" runat="server" Text="" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr style="display: none">
            <td width="30%" align="right">
                <asp:Label ID="Label5" runat="server" Text="Your User ID:"></asp:Label>
            </td>
            <td align="left">
                <asp:Label ID="lblYourUserId" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="30%" align="right">
                <asp:Label ID="Label1" runat="server" Text="Transfer to User :"></asp:Label>
                <%--OnClientItemSelected="txtToUser_OnClientItemSelected"--%>
            </td>
            <td align="left">
                <asp:TextBox ID="txtToUser" runat="server" Text="" />
                <cc1:TextBoxWatermarkExtender ID="txtToUser_TextBoxWatermarkExtender1" runat="server"
                    TargetControlID="txtToUser" WatermarkText="User Dispaly ID" />
                <cc1:AutoCompleteExtender ID="txtToUser_AutoCompleteExtender1" runat="server" TargetControlID="txtToUser"
                    ServiceMethod="SystemUserDisplayName" ServicePath="IDSService.asmx" MinimumPrefixLength="2"
                    CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20" ShowOnlyCurrentWordInCompletionListItem="true">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="txtToUser_RequiredFieldValidator1" runat="server"
                    ErrorMessage="*" ControlToValidate="txtToUser" ValidationGroup="G1"></asp:RequiredFieldValidator>
                <%--<asp:CustomValidator ID="txtToUser_CustomValidator1" runat="server" ErrorMessage="Invalid User" ControlToValidate="txtToUser" ClientValidationFunction="CheckUser" ValidationGroup="G1"></asp:CustomValidator>
                <div id="userName"></div>--%>
                <%--<asp:HiddenField ID="hdnUserId" runat="server" />--%>
            </td>
        </tr>
        <tr>
            <td width="30%" align="right">
                <asp:Label ID="Label2" runat="server" Text="Amount :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtAmount_RequiredFieldValidator1" runat="server"
                    ErrorMessage="*" ControlToValidate="txtAmount" ValidationGroup="G1"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="txtAmount_CustomValidator1" runat="server" ErrorMessage="Invalid Amount"
                    ControlToValidate="txtAmount" ClientValidationFunction="CheckAmount" ValidationGroup="G1"></asp:CustomValidator>
                <%-- <input type="text" id="txtAmount" onblur="txtAmount_OnTextChanged()" />--%>
            </td>
        </tr>
        <tr>
            <td width="30%" align="right">
                <asp:Label ID="Label3" runat="server" Text="Password :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtPassword" ValidationGroup="G1"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="txtPassword_CustomValidator1" runat="server" ErrorMessage="Invalid Pssword"
                    ControlToValidate="txtPassword" ClientValidationFunction="CheckPassword" ValidationGroup="G1" />
            </td>
        </tr>
        <tr>
            <td width="30%" align="right">
                <asp:Label ID="Label4" runat="server" Text="Confirm Password :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtConfirmPassword_RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="txtConfirmPassword" ValidationGroup="G1"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="txtConfirmPassword_CompareValidator1" runat="server" ErrorMessage="Password not Match"
                    ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ValidationGroup="G1" />
            </td>
        </tr>
        <tr>
            <td width="30%" align="right">
            </td>
            <td align="left">
                <asp:Button ID="btnTransfer" runat="server" Text="Transfer" OnClick="btnTransfer_Click"
                    ValidationGroup="G1" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
