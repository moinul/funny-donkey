<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlShowClientGeneralInformation.ascx.cs"
    Inherits="Controls_ctlShowClientGeneralInformation" %>

<table width="98%" cellpadding="1" cellspacing="3" id="ClientGeneralInfoText">
    <tr>
        <td style="width: 130px;" align="right">
            User Name:
        </td>
        <td align="left" width="500">
            <asp:Label ID="lblUserName" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            &nbsp;</td>
        <td align="left" width="500">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            First Name:
        </td>
        <td align="left" width="500">
            <asp:Label ID="lblFisrtName" runat="server" Font-Bold="True" 
                ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Last Name:
        </td>
        <td align="left" width="500">
            <asp:Label ID="lblLastName" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Date of Birth:
        </td>
        <td align="left" width="500">
            <asp:Label ID="lblDOB" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Email:
        </td>
        <td align="left" width="500">
            <asp:Label ID="lblEmail" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Contact No:
        </td>
        <td align="left" width="500">
            <asp:Label ID="lblContactNo" runat="server" Font-Bold="True" 
                ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Address:
        </td>
        <td align="left" width="500">
            <asp:Label ID="lblAddress" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Referrer:
        </td>
        <td align="left" width="500">
            <asp:Label ID="lblReferrer" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <%--<tr>
        <td style="width: 130px;" align="right">
            User Type:</td>
        <td align="left" width="500">
            <asp:Label ID="lblType" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
        </td>
    </tr>--%>
    <tr>
        <td style="width: 130px;" align="right">
            User Display Id:</td>
        <td align="left" width="500">
            <asp:Label ID="lblDisplayId" runat="server" Font-Bold="True" 
                ForeColor="#003366"></asp:Label>
        </td>
    </tr>
</table>
 

