<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master" CodeFile="Recoverpassword.aspx.cs" Inherits="Recoverpassword" %>

<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/headlogo.ascx" tagname="headlogo" tagprefix="uc2" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc4" %>

<%@ Register src="usercontrol/frontside/passwordrecover.ascx" tagname="passwordrecover" tagprefix="uc5" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
    <head>
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
		            <tr style="height:28px">
			            <td>
		                </td>
		            </tr>
		            <tr>
                        <td>
                            <uc5:passwordrecover ID="passwordrecover1" runat="server" />
                        </td><br/>
                    </tr>
            <tr>
                <td>
		            <uc4:copyright ID="copyright1" runat="server" />
                </td>
            </tr>
    </table>
        
</asp:Content>

