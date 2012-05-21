<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="CreateAdd.aspx.cs" Inherits="Admin_CdeateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2 class="headline2" align="center">
        <span>Add / Edit Advertise</span>
    </h2>
    
    <fieldset>
        <table width="100%">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server" Text="" EnableTheming="false" CssClass="msg"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="20%">
                    Name
                </td>
                <td width="30%" align="left">
                    <asp:TextBox ID="txtName" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Url
                </td>
                <td align="left" valign="top">
                    Http://<asp:TextBox ID="txtUrl" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="r1" ErrorMessage="*"
                        ControlToValidate="txtUrl">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" ValidationGroup="r1" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
        <asp:ListView ID="lvAdd" runat="server" OnItemDataBound="lvAdd_ItemDataBound" OnItemCommand="lvAdd_ItemCommand">
            <LayoutTemplate>
                <table border="0" cellpadding="0" cellspacing="1" width="100%" style="border-style: none">
                    <tr class="dGridHeaderClass" id="tr1" runat="server">
                        <td align="center">
                            SL.
                        </td>
                        <td align="center">
                            Name
                        </td>
                        <td align="center">
                            Url
                        </td>
                        <td align="center">
                        </td>
                    </tr>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class="dGridRowClass" id="trBody" runat="server">
                    <td align="center">
                        <asp:Label ID="lblSL" runat="server"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                    <td align="center" visible="true">
                        <asp:HyperLink ID="lblUrl" runat="server"></asp:HyperLink>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lnkEdit" runat="server">Edit</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </fieldset>
</asp:Content>

