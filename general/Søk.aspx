<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master" CodeFile="Søk.aspx.cs" Inherits="Søk" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc2" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/minside/venstercategory.ascx" tagname="venstercategory" tagprefix="uc4" %>
<%@ Register src="~/usercontrol/minside/søkkontent.ascx" tagname="søkkontent" tagprefix="uc5" %>
<%@ Register src="~/usercontrol/frontside/headlogo.ascx" tagname="headlogo" tagprefix="uc6" %>


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
           <tr style="width:   950px; height:20px; background-color:#CC0099">
                <td valign="bottom">
                    <uc2:statusmenu ID="statusmenu1" runat="server" />                   
                    <br />                    
                    <uc6:headlogo ID="headlogo1" runat="server" />
                    <br />
		            <uc1:mainmenu ID="mainmenu1" runat="server" />
	            </td>
	        </tr></tr>
    <tr style="background-color:#ECF5FF"><td>
        <table > 		
                    <tr>
                        <td valign="top">
        		            
                            <uc4:venstercategory ID="venstercategory1" runat="server" />
        		            
        </td><td style="padding-left:10px;" valign="top">
            
            </td>
            <td style="padding-left:10px;" valign="top">
                
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
