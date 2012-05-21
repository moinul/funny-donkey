<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true"
    CodeFile="rptSponsorChildList.aspx.cs" Inherits="SponsorChildList" %>

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
                <asp:TextBox ID="txtSponsorDispalayID" runat="server" Text="" />
                <cc1:TextBoxWatermarkExtender ID="txtSponsorDispalayID_TextBoxWatermarkExtender1"
                    runat="server" TargetControlID="txtSponsorDispalayID" WatermarkText="Sponsor Dispaly ID" />
                <cc1:AutoCompleteExtender ID="txtSponsorDispalayID_AutoCompleteExtender1" runat="server"
                    TargetControlID="txtSponsorDispalayID" ServiceMethod="SystemUserDisplayName"
                    ServicePath="IDSService.asmx" MinimumPrefixLength="2" CompletionInterval="1000"
                    EnableCaching="true" CompletionSetCount="20" ShowOnlyCurrentWordInCompletionListItem="true">
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
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ListView ID="lvChildList" runat="server" 
                    onitemdatabound="lvChildList_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%" border="0" cellpadding="1px" cellspacing="0">
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    User Name
                                </td>
                                <td>
                                    Display Name
                                </td>
                                <td>
                                   Contact No
                                </td>
                                <td>
                                   Email
                                </td>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDisplayName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblContactNo" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                          <td>
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDisplayName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblContactNo" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        No Child to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
            </td>
        </tr>
    </table>
</asp:Content>
