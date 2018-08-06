<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master" CodeFile="Hjelp.aspx.cs" Inherits="Hjelp" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/headlogo.ascx" tagname="headlogo" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc4" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc6" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    <head>
        <title>Finne kjærlighet, vennskaper og karrie nettverk</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<meta name="keywords" CONTENT="dating single, blogg, hobby venn, tema debatt, aktiviteter, nettverk, kjærlighet">
        <meta name="description" CONTENT="Finn kjærlighet, vennskap, gratis medlemskap på Minevenner.no" />
        <meta name="expires" CONTENT="never" />
        <meta name="language" CONTENT="nor" />
        <meta name="charset" CONTENT="ISO-8859-1" />
        <meta name="distribution" CONTENT="Global" />
        <meta name="email" CONTENT="kundeservice@Minevenner.no">
        <meta name="copyright" CONTENT="Copyright © 2010, Minevenner.no">
        <meta name="author" CONTENT="Minevenner.no">
    </head>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<table align="center" style="background-color:white; width:950px">
    <tr style="width:   950px;">
        <td valign="bottom">
            <uc6:statusmenu ID="statusmenu1" runat="server" />                   
            <uc3:headlogo ID="headlogo1" runat="server" />
            <uc1:mainmenu ID="mainmenu1" runat="server" />
        </td>
	</tr>
    <tr style="background-color:#ffddff; padding-bottom:10px;">
        <td>
        <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        <br/>
            
             <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1" 
                            UpdateMode="Conditional">
                            <ContentTemplate>    
                                <asp:PlaceHolder runat="server" ID="PlaceHolder1"
                                    EnableViewState="false" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="mainmenu1" 
                                     />
                            </Triggers>
                        </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
    <td>
    <uc4:copyright ID="copyright1" runat="server" />
    </td>
    </tr>
</table>
</asp:Content>
	