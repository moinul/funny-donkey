<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlHeader.ascx.cs" Inherits="Controls_ctlHeader" %>
<style type="text/css">
    #nav
    {
        padding: 0px;
        margin: 0px 0px 0px 200px;
    }
    #nav li
    {
        display: inline;
    }
    #nav li a
    {
        font-family: Verdana, Geneva, sans-serif;
        font-size: 11px;
        text-decoration: none;
        float: left;
        padding: 8px 0px 0px 0px;
        background-color: #333333;
        font-weight: bold;
        color: White;
        width: 191px;
        height: 28px;
    }
    #nav li a:hover
    {
        background-color: #009900;
        margin: 0px;
        font-weight: bold;
        color: #FFF;
    }
    #content
    {
        width: 900px;
        margin: 0 auto;
    }
</style>
<%--<script src="AC_RunActiveContent.js" type="text/javascript"></script>--%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<table width="100%" cellpadding="0" cellspacing="0" align="center">
    <tr>
        <td style="height: 14px; background-color: #999999">
            <div style="float: right; margin: 0px 210px 5px 0px; text-align: center; font-family: Arial;
                font-weight: bold; font-size: 10px; color: #009900;">
                <a href="SamplePage.aspx">FAQ</a>
            </div>
            <div style="float: right; margin: 0px 20px 5px 0px; text-align: center; font-family: Arial;
                font-weight: bold; font-size: 10px; color: #009900;">
                <a href="Login.aspx">Login</a>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div id="logoContainer">
                <div id="logo">
                </div>
                <div id="companyName">
                    Income Development Service</div>
                <%--                            <div style="float: right; margin: 30px 20px 5px 0px; text-align: center; font-family: Arial;
                    font-weight: bold; font-size: 10px; color: #009900;">
                    <a href="ClientProfile.aspx">Client</a>--%>
            </div>
        </td>
    </tr>
    <tr>
        <td align="center" style="background-color: #333333;">
            <ul id="nav">
                <li><a href="Home.aspx">Home</a></li>
                <li><a href="AboutUs.aspx#">About Us</a></li>
                <li><a href="TermsCondition.aspx">Terms & Condition</a></li>
                <li><a href="FAQ.aspx">FAQ</a></li>
                <li><a href="Contact.aspx">Contact Us</a></li>
            </ul>
        </td>
    </tr>
</table>
<%--<table width="100%" cellpadding="0" cellspacing="0" align="center">
    <tr>
        <td style="background-color: White;">
            <table width="960px" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="150">
                                </td>
                                <td align="left" valign="middle">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                </tr>
                <%--                <tr>
                    <td height="340px" align="center" valign="top">
                        <script language="javascript">
                            if (AC_FL_RunContent == 0) {
                                alert("This page requires AC_RunActiveContent.js. In Flash, run \"Apply Active Content Update\" in the Commands menu to copy AC_RunActiveContent.js to the HTML output folder.");
                            } else {
                                AC_FL_RunContent(
			'codebase', 'http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0',
			'width', '900',
			'height', '340',
			'src', 'anim',
			'quality', 'high',
			'pluginspage', 'http://www.macromedia.com/go/getflashplayer',
			'align', 'middle',
			'play', 'true',
			'loop', 'true',
			'scale', 'showall',
			'wmode', 'window',
			'devicefont', 'false',
			'id', 'anim',

			'name', 'anim',
			'menu', 'true',
			'allowScriptAccess', 'sameDomain',
			'movie', 'anim',
			'salign', ''
			); //end AC code
                            }
                        </script>
                        <noscript>
                            <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0"
                                width="900" height="340" id="anim" align="middle">
                                <param name="allowScriptAccess" value="sameDomain" />
                                <param name="movie" value="anim.swf" />
                                <param name="quality" value="high" />
                                <param name="bgcolor" value="#ffffff" />
                                <embed src="anim.swf" quality="high" bgcolor="#ffffff" width="900" height="340" name="anim"
                                    align="middle" allowscriptaccess="sameDomain" type="application/x-shockwave-flash"
                                    pluginspage="http://www.macromedia.com/go/getflashplayer" />
                            </object>
                        </noscript>
                    </td>
                </tr>
                <tr>
                    <td style="height:3px; background-color:Black;">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>--%>
