<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="MoneyWithdrawConfirmationView.aspx.cs" Inherits="MoneyWithdrawConfirmationView" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td colspan = "2">
                <asp:ListView ID="lvConfirmation" runat="server" DataKeyNames="IID" 
                     onitemcommand="lvConfirmation_ItemCommand" 
                     onitemdatabound="lvConfirmation_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%">
                            <tr id="tr1" runat="server" >
                                <th align ="left">
                                    Request Date
                                </th>
                                <th align ="left">
                                    Amount
                                </th>
                                <th>
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
                            <td align ="left">
                                <asp:Label ID="lblRequestdate" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblAmount" runat="server"></asp:Label>                                
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkUser" runat="server"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkConfirm" runat="server">Confirm</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id="trBody" runat="server">
                            <td align ="left">
                                <asp:Label ID="lblRequestdate" runat="server"></asp:Label>                                
                            </td>
                            <td align ="left">
                                <asp:Label ID="lblAmount" runat="server"></asp:Label>                                
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkUser" runat="server"></asp:LinkButton>
                            </td>
                            <td>
                                 <asp:LinkButton ID="lnkConfirm" runat="server">Confirm</asp:LinkButton>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        no item to display!!!
                    </EmptyDataTemplate>
                </asp:ListView>
                <asp:DataPager ID="dpConfirmation" runat="server" PagedControlID="lvConfirmation" 
                      PageSize="5" onprerender="dpConfirmation_PreRender">
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
