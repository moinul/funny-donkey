<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="GenerateUserKey.aspx.cs" Inherits="GenerateUserKey" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="Payment Type"></asp:Label>
</td>
<td align="left">
    <asp:DropDownList ID="ddlPaymetType" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlPaymetType_SelectedIndexChanged">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td style="height: 26px">
    <asp:Label ID="Label2" runat="server" Text="Amount"></asp:Label>
</td>
<td align="left" style="height: 26px">
    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td style="height: 26px">
    <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label>
</td>
<td align="left" style="height: 26px">
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td style="height: 26px">
    <asp:Label ID="Label5" runat="server" Text="Phone No"></asp:Label>
</td>
<td align="left" style="height: 26px">
    <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    
</td>
<td align="left">
    <asp:Button ID="btnGenerateKey" runat="server" Text="Generate Key" 
        onclick="btnGenerateKey_Click" />
</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="Generated Key"></asp:Label>
</td>
<td align="left">
    <asp:Label ID="lblGenerateKey" runat="server" ></asp:Label>
</td>
</tr>
</table>
</asp:Content>

