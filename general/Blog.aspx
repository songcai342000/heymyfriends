<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master" CodeFile="Blog.aspx.cs" Inherits="general_Blog" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/headlogo.ascx" tagname="headlogo" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc4" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc6" %>

<%@ Register src="~/usercontrol/blog/blogside.ascx" tagname="blogside" tagprefix="uc2" %>

<%@ Register src="~/usercontrol/blog/bloggvenster.ascx" tagname="bloggvenster" tagprefix="uc5" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<table align="center" style="background-color:white; width:950px">
   <tr>
                <td valign="bottom">
                    <uc6:statusmenu ID="statusmenu1" runat="server" />                  
                    <uc3:headlogo ID="headlogo1" runat="server" />
		            <uc1:mainmenu ID="mainmenu1" runat="server" />
	            </td>
	        </tr>
    <tr style="width:100%">
    <td>
    <table><tr>
        <td>
            <uc2:blogside ID="blogside1" runat="server" />
        </td>
         <td>
            <uc5:bloggvenster ID="bloggvenster1" runat="server" />
        </td>
    </tr></table>
    </td>
    </tr>
    <tr>
    <td>
    <uc4:copyright ID="copyright1" runat="server" />
    </td>
    </tr>
</table>
</asp:Content>
	