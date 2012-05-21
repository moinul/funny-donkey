<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true"
    CodeFile="MoneyWithdrawNotificationView.aspx.cs" Inherits="MoneyWithdrawNotificationView"
    Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Can be Withdrawn :"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAmount" runat="server" Text="Balance Amount"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Request Amount :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server" ValidationGroup="g1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount"
                    ErrorMessage="*" ValidationGroup="g1">
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtAmount" Type="Integer"
                    Operator="DataTypeCheck" ErrorMessage="Value must be an integer!" ValueToCompare="g1" />                
                <asp:Label ID="lblMSG" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnWithdraw" runat="server" Text="Withdraw" OnClick="btnWithdraw_Click"
                    ValidationGroup="g1" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ListView ID="lvNotification" runat="server" DataKeyNames="IID" OnItemCommand="lvNotification_ItemCommand"
                    OnItemDataBound="lvNotification_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server">
                                <th align="left">
                                    Request Date
                                </th>
                                <th align="left">
                                    Amount
                                </th>
                                <th align="left">
                                    User
                                </th>
                                <th>
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr id="trBody" runat="server">
                            <td align="left">
                                <asp:Label ID="lblRequestdate" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkUser" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkVerify" runat="server">Verify</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id="trBody" runat="server">
                            <td align="left">
                                <asp:Label ID="lblRequestdate" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkUser" runat="server"></asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkVerify" runat="server">Verify</asp:LinkButton>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        no item to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
                <asp:DataPager ID="dpNotification" runat="server" PagedControlID="lvNotification"
                    PageSize="5" OnPreRender="dpNotification_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" PreviousPageText="Previous"
                            ShowNextPageButton="False" ShowFirstPageButton="False" />
                        <asp:NumericPagerField PreviousPageText="..." CurrentPageLabelCssClass="BornoCss"
                            NumericButtonCssClass="BornoCss" NextPreviousButtonCssClass="BornoCss" RenderNonBreakingSpacesBetweenControls="True"
                            ButtonType="Link" />
                        <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" LastPageText="Last"
                            NextPageText="Next" PreviousPageText="Previous" ShowPreviousPageButton="False"
                            ShowLastPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
    </table>
</asp:Content>
