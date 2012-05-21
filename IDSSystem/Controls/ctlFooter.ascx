<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctlFooter.ascx.cs" Inherits="Controls_ctlFooter" %>
<style type="text/css">
    #navigation
    {
        padding: 0px; /*text-align:center;*/
    }
    #navigation li
    {
        display: table-row; /*width:120px;*/
    }
    #navigation li a
    {
        font-family: Verdana, Geneva, sans-serif;
        font-size: 10px;
        float: left;
        text-align: center;
        font-weight: normal;
        color: #999999;
    }
    #navigation li a:hover
    {
        font-size: 10px;
        margin: 0px;
        font-weight: normal; /*   width:120px;*/
        color: #FFF;
    }
</style>
<div style="width: 100%" align="center" id="footer_container">
    <table width="960px" align="center" id="footer_body">
        <tr>
            <td style="width: 20%">
                <h1 id="footerLinkHeadingText">
                    Quick Link</h1>
                <ul id="navigation">
                    <li><a href="#">Home</a></li>
                    <li><a href="#">About</a></li>
                    <li><a href="#">Terms And Condition</a></li>
                    <li><a href="#">FAQ</a></li>
                    <li><a href="#">Contact Us</a></li>

                </ul>
            </td>
            <td style="width: 40%" valign="top">
                <h1 id="footerAoubtUsHeadingText">
                    About Us</h1>
                <p id="footerAoutUsText">
                    Neways International is a privately held American multi-level marketing organization
                    that manufactures and distributes personal care products, nutritional supplements,
                    and household cleaning products and has a presence in more than 23 countries.[1]
                    Neways is headquartered in Springville, Utah. The company claims that its products
                    are chemically safer than other brands.
                </p>
            </td>
            <td style="width: 40%" valign="top">
                <h1 id="footerContactHeadingText">
                    Contact</h1>
                <p id="footerContactText">
                    Telephone: 880-2-8333183, 8333184, 8333195 <br />
                    Fax: +880-2-8311062 <br />
                    Mobile :01811482000,01811482001, 01811482002, 01811482003 01730001074<br />
                    E-mail: sales@tomagroupbd.com, support@tomagroupbd.com <br />
                    Web: www.tomagroupbd.com<br />
                </p>
            </td>
        </tr>
        <tr>
            <td id="footerCopyrightext" colspan="3">
              © Copyright IDS.All Rights Reserved
            </td>
        </tr>
    </table>
</div>
