<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true"
    CodeFile="rptUserChildInfo.aspx.cs" Inherits="rptUserChildInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Scripts/TreeViewStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="40%" align="right">
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
                <asp:Button ID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <div class="mainstructure">
        <div class="nodelevel">
            <div class="node">
                <asp:HyperLink CssClass="nodeLink" ID="node_parent" runat="server"></asp:HyperLink>
            </div>
        </div>
        <div class="nodelevel">
            <div class="Secondleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_second_left" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Secondleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_second_right" runat="server"></asp:HyperLink>
                </div>
            </div>
        </div>
        <div class="nodelevel">
            <div class="Thirdleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_third_left_left" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Thirdleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_third_left_right" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Thirdleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_third_right_left" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Thirdleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_third_right_right" runat="server"></asp:HyperLink>
                </div>
            </div>
        </div>
        <div class="nodelevel">
            <div class="Fourleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_four_FirstLeft_left" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Fourleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_four_FirstLeft_right" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Fourleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_four_FirstRight_left" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Fourleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_four_FirstRight_right" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Fourleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_four_SecondLeft_left" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Fourleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_four_SecondLeft_right" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Fourleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_four_SecondRight_left" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="Fourleveldivider">
                <div class="node">
                    <asp:HyperLink CssClass="nodeLink" ID="node_four_SecondRight_right" runat="server"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
