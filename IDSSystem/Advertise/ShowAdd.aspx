<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true"
    CodeFile="ShowAdd.aspx.cs" Inherits="Advertise_ShowAdd" %>

<%@ Register src="../Controls/uclUserBalance.ascx" tagname="uclUserBalance" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style >
    .styleframe
    {
    	width:100%;
    	height:400px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="width:100%">

    <uc1:uclUserBalance ID="uclUserBalance1" runat="server" />

</div>
    <div style="width:100%">
        <asp:Timer runat="server" ID="Timer1" Interval="1000" OnTick="Timer1_Tick" />
        <asp:UpdatePanel runat="server" ID="TimePanel" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label runat="server" ID="Label1" />
                <br />
                <%--<asp:Button ID="btnDone" runat="server" Text="Done" Enabled="false" OnClientClick="window.opener.location.reload();self.close();"/>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>
    <div style="float: right">
        <%--<asp:Button ID="btnDone" runat="server" Text="Done" Enabled="false" OnClientClick="self.close();"/>--%>
    </div>
    <div>
        <%--<iframe id="MyIframe" src="http://www.google.com" runat="server" scrolling="yes" frameborder="0" style="border: none;
            overflow: hidden; width: 100%; height: 400px;" allowtransparency="true"></iframe>--%>
            <iframe id="MyIframe" width="100%" runat="server" ></iframe> 
    </div>
    <div id="divMsg" visible="false" runat="server">
        This Advertise session has expired!!!!
    </div>
</asp:Content>
