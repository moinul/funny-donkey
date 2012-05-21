<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="ClientProfileHeader" align="center">
        Create Customer Profile
    </div>
    <table id="ClientGeneralInfoText">
        <tr>
            <td>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblGeneralInfoTitle" runat="server" Text=" General Information " Font-Bold="true"
                            BackColor="Gray"></asp:Label></legend>
                    <table width="98%" cellpadding="1" cellspacing="3">
                        <tr>
                            <td style="width: 130px;" align="right">
                                First Name:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtFisrtName" runat="server" Width="320px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert First Name." ControlToValidate="txtFisrtName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Last Name:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtLastName" runat="server" Width="320px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="Please Insert Last Name." ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Date of Birth:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtDOB" runat="server" Width="200px"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOB">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="Please Insert Date of Birth." ControlToValidate="txtDOB"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Email:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Contact No:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtContactNo" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Address:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtAddress" runat="server" Width="320px" Height="100px" 
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblLogin" runat="server" Text=" Login Information " Font-Bold="true"
                            BackColor="Gray"></asp:Label></legend>
                    <table width="98%" cellpadding="1" cellspacing="3">
                        <tr>
                            <td style="width: 130px;" align="right">
                                User Name:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="Please Insert User Name." ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                &nbsp;</td>
                            <td align="left" width="500">
                                <asp:Label ID="lblUserNameMsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Password:                             </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ErrorMessage="Please Insert Password Name." ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Confirm Password:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" Width="200px" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ErrorMessage="Please Insert Confirm Password Name." 
                                    ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                &nbsp;</td>
                            <td align="left" width="500">
                                <asp:Label ID="lblPWMsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblOther" runat="server" Text=" Other Information " Font-Bold="true"
                            BackColor="Gray"></asp:Label></legend>
                    <table width="98%" cellpadding="1" cellspacing="3">
                    <tr>
                            <td style="width: 130px;" align="right">
                                Referrer Id:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtReferrer" runat="server" Width="320px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                User Type:
                            </td>
                            <td align="left" width="500">
                                <asp:DropDownList ID="ddlUserType" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Display Id:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtDisplay" runat="server" Width="320px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Payment Type:
                            </td>
                            <td align="left" width="500">
                                <asp:DropDownList ID="ddlPayment" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Key:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtKey" runat="server" Width="320px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ErrorMessage="Please Insert key." ControlToValidate="txtKey"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                &nbsp;</td>
                            <td align="left" width="500">
                                <asp:Label ID="lblKeyMsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
        <td align="center" valign="middle">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="120px" 
                onclick="btnSave_Click"/>
        </td>
        </tr>
    </table>

</asp:Content>

