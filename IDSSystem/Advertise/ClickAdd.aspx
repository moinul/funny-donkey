<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true"
    CodeFile="ClickAdd.aspx.cs" Inherits="Advertise_ClickAdd" %>

<%@ Register src="../Controls/uclUserBalance.ascx" tagname="uclUserBalance" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="width:100%">
    <uc1:uclUserBalance ID="uclUserBalance1" runat="server" />
</div>
    <asp:ListView ID="lvAdd" runat="server" 
    OnItemDataBound="lvAdd_ItemDataBound" onitemcommand="lvAdd_ItemCommand">
        <LayoutTemplate>
            <table border="0" cellpadding="0" cellspacing="1" width="100%" style="border-style: none">
                <tr class="dGridHeaderClass" id="tr1" runat="server">
                    <td align="center">
                        Links
                    </td>
                </tr>
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="dGridRowClass" id="trBody" runat="server">
                <td align="center">
                    <asp:LinkButton ID="lnkAdd" runat="server"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="dGridAltRowClass" id="trBody" runat="server">
                <td align="center">
                    <asp:LinkButton ID="lnkAdd" runat="server"></asp:LinkButton>
                </td>
            </tr>
        </AlternatingItemTemplate>
    </asp:ListView>
</asp:Content>
