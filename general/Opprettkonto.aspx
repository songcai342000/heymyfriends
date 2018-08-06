<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master" CodeFile="Opprettkonto.aspx.cs" Inherits="Opprettkonto" %>
<%@ Register src="~/usercontrol/frontside/opprettkonto.ascx" tagname="opprettkonto" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc2" %>
<%@ Register src="~/usercontrol/frontside/headlogonopicture.ascx" tagname="headlogonopicture" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc4" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc5" %>

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
    <table align="center" style="width:950px; background-color:white">
            <tr style="width: 100%;">
                <td valign="bottom" style="width:100%">
                    <uc5:statusmenu ID="statusmenu1" runat="server" /> 
                    <uc3:headlogonopicture ID="headlogonopicture1" runat="server" />
		            <uc2:mainmenu ID="mainmenu1" runat="server" />
	            </td>
	        </tr>
	        <tr style="background-color:#ffddff;"><td style="border-left-style:solid; border-left-color:White; border-right-style:solid; border-right-color:White;">
            <table align="center" style="width:100%; background-color:#ffddff;">
            <tr>
             <td style="width:30%; padding-top:10px" valign="top" align="center">
                 <asp:ImageButton ID="createPic" runat="server" ImageUrl="~/images/winepar.jpg" Width="210px" Height="160px" />
            </td>
            <td style="width:70%; padding-top:10px" valign="top" align="center">
                <uc1:opprettkonto ID="opprettkonto1" runat="server" />
            </td>
            </tr>
            </table></td>
        </tr>
         <tr style="background-color: White;">
            <td>
                <uc4:copyright ID="copyright1" runat="server" />
            </td>
        </tr>
    </table>
    
</asp:Content>


 
 

 
 

 
