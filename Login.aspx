<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register src="~/usercontrol/frontside/loggin.ascx" tagname="loggin" tagprefix="uc5" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/headlogo.ascx" tagname="headlogo" tagprefix="uc2" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc4" %>


<%@ Register src="usercontrol/frontside/roseperson.ascx" tagname="roseperson" tagprefix="uc6" %>


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
<asp:Content ID="bodyContent" ContentPlaceHolderID="body" Runat="Server">
        <table align="center" style="background-color:white">
           <tr style="width: 950px;">
                <td valign="bottom" style="width:100%">
                    <uc3:statusmenu ID="statusmenu1" runat="server" /> 
                    <uc2:headlogo ID="headlogo1" runat="server" />
		            <uc1:mainmenu ID="mainmenu1" runat="server" />
	            </td>
	        </tr>
		            <tr style="background-color:#ffddff;">
			            <td valign="middle" style="width:100%">
		                    <uc6:roseperson ID="roseperson1" runat="server" />
	                        <br/>
		  
		                    <uc5:loggin ID="loggin1" runat="server" />
                        </td><br/>
                    </tr>
            <tr>
                <td>
		            <uc4:copyright ID="copyright1" runat="server" />
                </td>
            </tr>
    </table>
        
</asp:Content>

