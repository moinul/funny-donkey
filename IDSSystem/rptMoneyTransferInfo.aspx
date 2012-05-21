<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true"
    CodeFile="rptMoneyTransferInfo.aspx.cs" Inherits="rptMoneyTransferInfo" %>

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
                <asp:TextBox ID="txtUserDispalayID" runat="server" Text="" />
                <cc1:TextBoxWatermarkExtender ID="txtUserDispalayID_TextBoxWatermarkExtender1" runat="server"
                    TargetControlID="txtUserDispalayID" WatermarkText="User Dispaly ID" />
                <cc1:AutoCompleteExtender ID="txtUserDispalayID_AutoCompleteExtender1" runat="server"
                    TargetControlID="txtUserDispalayID" ServiceMethod="SystemUserDisplayName" ServicePath="IDSService.asmx"
                    MinimumPrefixLength="2" CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20"
                    ShowOnlyCurrentWordInCompletionListItem="true">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td width="30%" align="right">
                <asp:Label ID="Label2" runat="server" Text="Date From :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender1" runat="server" TargetControlID="txtDateFrom"
                    Format="dd-MM-yyyy" />
            </td>
        </tr>
        <tr>
            <td width="30%" align="right">
                <asp:Label ID="Label3" runat="server" Text="Date To :"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender1" runat="server" TargetControlID="txtDateTo"
                    Format="dd-MM-yyyy" />
            </td>
        </tr>
        <tr>
            <td width="30%" align="right">
            </td>
            <td align="left">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
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
                <asp:ListView ID="lvTransaction" runat="server" OnItemDataBound="lvTransaction_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%" border="0" cellpadding="1px" cellspacing="0">
                            <tr>
                                <td>
                                    Date
                                </td>
                                <td>
                                    User Name
                                </td>
                                <td>
                                    Amount
                                </td>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        No Transaction to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
                <table style="float: right;" cellpadding="0" cellpadding="0">
                    <tr>
                        <td>
                            <asp:DataPager ID="dpstdList" runat="server" PagedControlID="lvTransaction" PageSize="10"
                                OnPreRender="dpstdList_PreRender">
                                <Fields>
                                    <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="PagerCss" PreviousPageText="Previous"
                                        ShowNextPageButton="False" ShowFirstPageButton="False" />
                                    <asp:NumericPagerField PreviousPageText="..." CurrentPageLabelCssClass="PagerCss"
                                        NumericButtonCssClass="PagerCss" NextPreviousButtonCssClass="PagerCss" RenderNonBreakingSpacesBetweenControls="True"
                                        ButtonType="Link" />
                                    <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="PagerCss" LastPageText="Last"
                                        NextPageText="Next" PreviousPageText="Previous" ShowPreviousPageButton="False"
                                        ShowLastPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
