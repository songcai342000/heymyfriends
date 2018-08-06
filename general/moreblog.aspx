<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master" CodeFile="moreblog.aspx.cs" Inherits="general_moreblog" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc2" %>
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
	        <tr style="width:   950px; background-color:#ffddff;">
                <td>
                    <div style="width:   930px; padding-right:10px;" align="right"><asp:Panel runat="server" ID="pagePan" Width="200px"/></div>
<div style="width:930px; padding-left:10px; padding-top:10px;" align="center">
    <asp:repeater id="moreblogs"       
    runat="server" onitemcommand="moreblogs_ItemCommand" >
    <headertemplate>
      <table style="border: solid 1px #e1e1e1;">
        <tr style="font-weight:bold; height:35px; background-color:#cce6ff;">
        <td>Tema</td>
        <td>Blogger</td>
         <td>Tid</td>
        </tr>
    </headertemplate>
    <itemtemplate>
      <tr  bgcolor="#e8e8e8">
        <td  style="width:175px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="blogtitleearlier" CommandName="blogtitleearlierCN"><%# Eval("Blogtitle")%></asp:LinkButton></td>
        <td  style="width:175px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="blogwritter" CommandName="writterprofileCN"><%# Eval("Username")%></asp:LinkButton></td>
        <td  style="width:175px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="blogtimeearlier" CommandName="blogtimeearlierCN"><%# Eval("Time")%></asp:LinkButton></td>
      </tr>
    </itemtemplate>
    <alternatingitemtemplate>
      <tr  >
        <td  style="width:175px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="blogtitleearlier" CommandName="blogtitleearlierCN"><%# Eval("Blogtitle")%></asp:LinkButton></td>
        <td  style="width:175px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="blogwritter" CommandName="writterprofileCN"><%# Eval("Username")%></asp:LinkButton></td>
        <td  style="width:175px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="blogtimeearlier" CommandName="blogtimeearlierCN"><%# Eval("Time")%></asp:LinkButton></td>
      </tr>
    </alternatingitemtemplate>
    <footertemplate>
      </table>
    </footertemplate>
</asp:repeater>
                    </div>
		</td></tr>
		<tr>
                <td >
                    <uc3:copyright ID="copyright1" runat="server" />
                </td>
            </tr>
		</table>
</asp:Content>        
		