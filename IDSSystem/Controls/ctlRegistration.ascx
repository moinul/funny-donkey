<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlRegistration.ascx.cs"
    Inherits="Controls_ctlRegistration" %>
<div id="RegHeader" align="center">
    Customer Registration
</div>
<br />
<table width="80%" cellpadding="1" cellspacing="1" id="BodyText">
    <tr>
        <td style="width: 130px;" align="right">
            Name:
        </td>
        <td align="left" width="500">
            <asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
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
            Mobile:
        </td>
        <td align="left" width="500">
            <asp:TextBox ID="txtMobile" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Home:
        </td>
        <td align="left" width="500">
            <asp:TextBox ID="txtHome" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Present Address:
        </td>
        <td align="left" width="500">
            <asp:TextBox ID="txtAddressPresent" runat="server" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Permanent Address:
        </td>
        <td align="left" width="500">
            <asp:TextBox ID="txtAddressPermanent" runat="server" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Referrer:
        </td>
        <td align="left" width="500">
            <asp:TextBox ID="txtReferrer" runat="server" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right" height="10">
        </td>
        <td height="10" align="left" width="500">
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            User Name:
        </td>
        <td align="left" width="500">
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Password:
        </td>
        <td align="left" width="500">
            <asp:TextBox ID="txtPassword" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            Confirm Password:
        </td>
        <td align="left" width="500">
            <asp:TextBox ID="txtConfirmPassword" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            &nbsp;
        </td>
        <td align="left" width="500">
            <asp:CheckBox ID="chkUserType" runat="server" />
            <asp:Label ID="lblPremium" runat="server" Text=" Want to be a premium user ($30 for One Year / $50 for Two Years)"
                ForeColor="#339933"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" style="height: 200px; width: 130px;">
            &nbsp;
        </td>
        <td align="left" width="500" style="height: 200px;">
            <asp:TextBox ID="txtTermCon" runat="server" ForeColor="Gray" Height="200px" TextMode="MultiLine"
                Width="500px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            &nbsp;
        </td>
        <td align="left" width="500">
            <asp:CheckBox ID="chkTermCon" runat="server" />
            <asp:Label ID="lblTerms" runat="server" Text=" I am agree to the Terms &amp; Conditions"
                ForeColor="#339933"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 130px;" align="right">
            &nbsp;
        </td>
        <td align="left" width="500">
            <table cellpadding="2" cellspacing="2">
                <tr>
                    <td style="width: 170px;">
                        <div id="captchaAreaLoginUsers" style="float: left; width: 150px;">
                            <img src="http://www.dolancer.com/captcha/1335679314.192.jpg" width="150" height="40"
                                style="border: 0;" alt=" " /></div>
                    </td>
                    <td>
                        <a href="JavaScript: loadCaptcha2();">
                            <img style="padding-top: 3px; padding-left: 2px;" border="0" alt="" src="http://www.dolancer.com/app/views/image/refresh.png"
                                align="bottom" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
