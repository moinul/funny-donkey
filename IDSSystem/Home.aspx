<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register src="Controls/ctlNoticeBoardascx.ascx" tagname="ctlNoticeBoardascx" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width:100%">
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

</div>

<div style="height:3px; background-color:Black;"></div>

    <div id="bodycontainer">
        <div id="bodyInnerContainer">
            <div id="welcomeContainer">
                <h1 id="welcomeHeader">
                    Welcome to Our Site</h1>
                <p id="welcomeBodyText">
                    Neways International is a privately held American multi-level marketing organization
                    that manufactures and distributes personal care products, nutritional supplements,
                    and household cleaning products and has a presence in more than 23 countries. Neways
                    is headquartered in Springville, Utah. The company claims that its products are
                    chemically safer than other brands.
                </p>
                <div id="separator">
                </div>
            </div>
            <div id="serviceContainer">
                <h2 id="serviceHeader">
                    Products</h2>
                <p id="serviceBodyText">
                    Neways is a network-marketing company that stands at the forefront of product innovation.
                    Committed to quality ingredients, extensive research, and unique formulas, Neways
                    manufactures and distributes safe, effective, and innovative products that are a
                    perfect blend of science and nature. We incorporate the very latest and most effective
                    health and wellness science and technology in all our products. We formulate our
                    own products, and most products are produced at our own manufacturing facilities.
                </p>
            </div>
            <div style="background-image: url(Images/separatorVertical.gif); background-repeat: repeat-y;
                width: 10px; height: 220px; float: left">
            </div>
            <div id="newsContainer">
         
                <uc1:ctlNoticeBoardascx ID="ctlNoticeBoardascx1" runat="server" />
         
            </div>
        </div>
    </div>
</asp:Content>
