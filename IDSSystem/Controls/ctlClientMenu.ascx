<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlClientMenu.ascx.cs"
    Inherits="Controls_ctlClientMenu" %>
<style type="text/css">
    #clientNavigation
    {
        padding: 0px; /*text-align:center;*/
    }
    #clientNavigation li
    {
        display: table-row; /*width:120px;*/
    }
    #clientNavigation li a
    {
        font-family: Verdana, Geneva, sans-serif;
        font-size: 11px;
        float: left;
        text-align: left;
        font-weight: bold;
        color: #77BC51;
        padding: 1px 0px 1px 0px;
        text-decoration: none;
    }
    #clientNavigation li a:hover
    {
        font-size: 11px;
        margin: 0px;
        font-weight: normal; /*   width:120px;*/
        color: #333333;
        font-weight: bold;
    }
</style>
<div id="menuContainer" runat="server">
    <ul id="clientNavigation">
        <li><a href="#">Dashboard</a></li>
        <li><a href="ClientProfile.aspx">My Profile</a></li>
        <li><a href="#">Change Password</a></li>
        <li><a href="Advertise/ClickAdd.aspx">Click To Earn</a></li>
        <li><a href="CreateClient.aspx">Create User</a></li>
        <li><a href="#">Account Summary</a></li>
        <li><a href="#">Account Details</a></li>
        <li><a href="MoneyWithdrawNotificationView.aspx">Account Money Withdraw</a></li>
        <li><a href="MoneyTransaction.aspx">Account Money Transfer</a></li>
        <li><a href="ViewDailyIncome.aspx">Report: Daily Income</a></li>
        <li><a href="rptUserChildInfo.aspx">Report: Child Info</a></li>
        <li><a href="rptUserSponserInfo.aspx">Report: Sponser Info</a></li>
        <li><a href="rptUserSponserInfo.aspx">My Sponsor</a></li>
        <li><a href="#">Report: Transfer Info</a></li>
        <li><a href="#">Report: Withdraw Info</a></li>
    </ul>
</div>
