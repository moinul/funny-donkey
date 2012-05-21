<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlLogin.ascx.cs" Inherits="Controls_ctlLogin" %>
<table width="60%" style="border: 1px; border-style: solid; border-color: #003300;">
    <tr>
        <td align="center">
            <div id="loginContainer">
                <div id="loginHeader" align="center">
                    Login to IDF
                </div>
                <br />
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="lblUserName" runat="server" Text="User Name" Width="100px"></asp:Label>
                <asp:TextBox ID="txtUserName" runat="server" ForeColor="#1589B2" Text=""></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblPassword" runat="server" Text="Password" Width="100px"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" ForeColor="#1589B2" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <asp:CheckBox ID="chkRemember" runat="server" />
                Remember Me
                <br />
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <br />
                <br />
                <a href="#">I forgot my login details?</a> <a href="#">Signup</a>
                <br />
                <br />
            </div>
        </td>
    </tr>
</table>
