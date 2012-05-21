<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true"
    CodeFile="EditClient.aspx.cs" Inherits="EditClient" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div id="ClientProfileHeader" align="center">
        Create Customer Profile
    </div>
    <table id="ClientGeneralInfoText">
        <tr>
            <td>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblGeneralInfoTitle" runat="server" Text="General Information" Font-Bold="true"
                            BackColor="Gray"></asp:Label></legend>
                    <table width="98%" cellpadding="1" cellspacing="3">
                        <tr>
                            <td style="width: 130px;" align="right">
                                First Name:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtFisrtName" runat="server" Width="320px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert First Name."
                                    ControlToValidate="txtFisrtName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Last Name:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtLastName" runat="server" Width="320px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert Last Name."
                                    ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Date of Birth:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtDOB" runat="server" Width="200px"></asp:TextBox>
                                <cc1:CalendarExtender ID="ctlCalender" runat="server" TargetControlID="txtDOB">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Insert Date of Birth."
                                    ControlToValidate="txtDOB"></asp:RequiredFieldValidator>
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
                                <asp:TextBox ID="txtContactNo" runat="server" Width="320px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Insert Contact No."
                                    ControlToValidate="txtContactNo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;" align="right">
                                Address:
                            </td>
                            <td align="left" width="500">
                                <asp:TextBox ID="txtAddress" runat="server" Width="320px" Height="100px" 
                                    TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Insert Address."
                                    ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblOther" runat="server" Text="Other Information" Font-Bold="true"
                            BackColor="Gray"></asp:Label></legend>
                    <table width="98%" cellpadding="1" cellspacing="3">
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
                                &nbsp;
                            </td>
                            <td align="left" width="500">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="120px" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
