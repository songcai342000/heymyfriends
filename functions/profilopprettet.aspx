<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master"  CodeFile="Profilopprettet.aspx.cs" Inherits="Profilopprettet" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc4" %>
<%@ Register src="~/usercontrol/profil/profilkvittering.ascx" tagname="profilkvittering" tagprefix="uc2" %>
<%@ Register src="~/usercontrol/frontside/headlogo.ascx" tagname="headlogo" tagprefix="uc6" %>
<%@ Register src="../usercontrol/minside/venstercategory2.ascx" tagname="venstercategory2" tagprefix="uc5" %>
<asp:Content runat="server" ID="head" ContentPlaceHolderID="head">
     <title>Finne kjærlighet, vennskaper og karrie nettverk</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<meta name="keywords" content="dating single, blogg, hobby venn, tema debatt, aktiviteter, nettverk, kjærlighet">
        <meta name="description" content="Finn kjærlighet, vennskap, gratis medlemskap på Minevenner.no" />
        <meta name="expires" content="never" />
        <meta name="language" content="nor" />
        <meta name="charset" content="ISO-8859-1" />
        <meta name="distribution" content="Global" />
        <meta name="email" content="kundeservice@Minevenner.no">
        <meta name="copyright" content="Copyright © 2010, Minevenner.no">
        <meta name="author" content="Minevenner.no">
</asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="body">
<table align="center" style="background-color:white; width:950px;">
    <tr>
        <td valign="bottom">
            <uc3:statusmenu ID="statusmenu1" runat="server" />                   
            <uc6:headlogo ID="headlogo1" runat="server" />
            <uc1:mainmenu ID="mainmenu1" runat="server" />
        </td>
    </tr>
    <tr>
         <td>
           <table style="width:100%">
            <tr>
            <td style="width:22%; padding-left:10px; padding-top:10px">
                <uc5:venstercategory2 ID="venstercategoryanother" runat="server" />
            </td>
            <td align="left" style="width:78%; padding-left:0px; padding-top:10px" valign="top">
                <asp:Panel ID="Panel1" runat="server">
                </asp:Panel>
            </td>
            </tr>
            </table>     
          </td>
    </tr>
    <tr>
        <td>
            <uc4:copyright ID="copyright1" runat="server" />
        </td>
    </tr>
</table>
</asp:Content>


