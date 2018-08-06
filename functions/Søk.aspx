<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master" CodeFile="Søk.aspx.cs" Inherits="Søk" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc2" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/minside/venstercategory.ascx" tagname="venstercategory" tagprefix="uc4" %>
<%@ Register src="~/usercontrol/minside/søkkontent.ascx" tagname="søkkontent" tagprefix="uc5" %>
<%@ Register src="~/usercontrol/frontside/headlogo.ascx" tagname="headlogo" tagprefix="uc6" %>


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
<asp:Content ID="bodyContent" ContentPlaceHolderID="body" Runat="Server">
        <table align="center" style="background-color:white">
           <tr style="width:   950px;">
                <td valign="bottom">
                    <uc2:statusmenu ID="statusmenu1" runat="server" />                   
                    <uc6:headlogo ID="headlogo1" runat="server" />
		            <uc1:mainmenu ID="mainmenu1" runat="server" />
	            </td>
	        </tr>
    <tr><td>
        <table style="background-color:#ffffff"> 		
                    <tr>
                        <td valign="top" style="padding-left:10px; padding-top:10px; width:24%">
        		            
                            <uc4:venstercategory ID="venstercategory1" runat="server" />
        		            
        </td>
            <td style="padding-left:0px; padding-top:10px; padding-right:10px;" valign="top"width:76%" valign="top">
                
                <uc5:søkkontent ID="søkkontent1" runat="server" />
                
            </td>
	        </tr>
        </table>
    </td></tr>
    <tr><td>
        
        <uc3:copyright ID="copyright1" runat="server" />
        
    </td></tr>
</table>
</asp:Content>     
