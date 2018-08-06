<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/Master/Hjemside.master" Inherits="functions_Default" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/headlogo.ascx" tagname="headlogo" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc4" %>
<%@ Register src="~/usercontrol/minside/minsidecontent.ascx" tagname="minsidecontent" tagprefix="uc2" %>
<%@ Register src="~/usercontrol/minside/venstercategory.ascx" tagname="venstercategory" tagprefix="uc5" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc6" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
        <title>Finne kjærlighet, vennskaper og karrie nettverk</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<meta name="keywords" content="dating single, blogg, hobby venn, tema debatt, aktiviteter, nettverk, kjærlighet" />
        <meta name="description" content="Finn kjærlighet, vennskap, gratis medlemskap på Minevenner.no" />
        <meta name="expires" content="never" />
        <meta name="language" content="nor" />
        <meta name="charset" content="ISO-8859-1" />
        <meta name="distribution" content="Global" />
        <meta name="email" content="kundeservice@Minevenner.no" />
        <meta name="copyright" content="Copyright © 2010, Minevenner.no" />
        <meta name="author" content="Minevenner.no" />
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
    <tr style="background:white">
        <td>
            <table style="font-size:small">
                <tr>
                    <td style="width:24%; padding-left:10px; padding-top:10px" valign="top" onclick="__doPostBack('UpdatePanel1', '');">
<table id="lefttables"> 
<tr>
<td>
        <div><asp:LinkButton runat="server" 
                Text="Min statistikk" onclick="statistic_Click" id="statistic" 
                style="font-weight:bold; font-size:small; color:#0033cc;" Font-Underline="true">
                </asp:LinkButton></div>
    <div>
     <br />
    <div>
        <div><b>Postkassen</b></div>
    <div>
        <div>
            <asp:LinkButton runat="server" 
                Text="Innboks" onclick="inbox_Click" id="inbox" >
                </asp:LinkButton><asp:Literal
                    ID="newmailLi" runat="server" Text=""></asp:Literal></div>
            <div>
                <asp:LinkButton runat="server" id="sendt"  Text="Utboks" onclick="sendt_Click" 
                     >
                </asp:LinkButton></div> 
            <div>
                <asp:LinkButton runat="server" id="skriv"  Text="Ny meldning" onclick="skriv_Click" 
                   >
                </asp:LinkButton></div> 
        </div><br />
        <br />
        <div><b>Profil og medlemskap</b></div>
        <div>
        <div>
             <asp:LinkButton runat="server" id="profil" onclick="profil_Click" Text="Vise profil"
                 >
             </asp:LinkButton></div>
        <div>
            <asp:LinkButton runat="server" id="createprofile" onclick="createprofile_Click" 
                Text="Redigere profil" Font-Underline="False"
                  ></asp:LinkButton></div>
          <div>
              <asp:LinkButton runat="server" id="album" Text="Min fotoalbum" onclick="album_Click" 
                  >
              </asp:LinkButton></div>
        
          <div>
            <asp:LinkButton ID="deactivateMember" runat="server" 
                onclick="deactivateMember_Click">Deaktivere Medlem</asp:LinkButton>
                            </div>
            <div>
                <asp:LinkButton id="avsluttmeldem" runat="server" 
                    Text="Avslutte medlemskap" onclick="avsluttmeldem_Click" >
                </asp:LinkButton></div>
        </div>
       <br />
        <br />
        <div><b>Lister og funksjoner</b></div>
        <div>
		     <div>
              <asp:LinkButton runat="server"  id="Bloger" 
                  Text="Min blogg" onclick="Bloger_Click"></asp:LinkButton></div>
                   <div><asp:LinkButton runat="server" id="minenøkler" Text="Mine nøkler" 
                PostbackUrl="/vennskap/functions/Profilepage.aspx?minevenner={0}" 
                onclick="minenøkler_Click"></asp:LinkButton></div>     
            <div><asp:LinkButton runat="server" id="minevenner" Text="Mine venner" 
                    PostbackUrl="/vennskap/functions/Profilepage.aspx?minevenner={0}" 
                    onclick="minevenner_Click"></asp:LinkButton></div>
              
			<div><asp:LinkButton runat="server" id="mineblomster" Text="Mine blomster" 
                    PostbackUrl="/vennskap/functions/Profilepage.aspx?minevenner={0}" 
                    onclick="mineblomster_Click"></asp:LinkButton></div>
            <div><asp:LinkButton runat="server" id="besokere" Text="Mine besøkere" 
                    onclick="besokere_Click" ></asp:LinkButton></div>
             <div><asp:LinkButton runat="server" id="megsomfavoritt" Text="Meg som favoritt" 
                    onclick="megsomfavoritt_Click" ></asp:LinkButton></div>   
            <div><asp:LinkButton runat="server" id="favorittBloger" 
                    Text="Mine favoritt Blogger" onclick="favorittBloger_Click" ></asp:LinkButton></div>   
            <div><asp:LinkButton runat="server" id="favoritt" Text="Mine favoritt profiler" 
                    onclick="favoritt_Click" ></asp:LinkButton></div>
		
             <br/>
             <br/>             
        </div>
	</td></tr></table>                    </td>
                    <td style="width:76%; padding-left:0px; padding-top:10px; padding-right:10px;" valign="top" >
                    <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1" 
                            UpdateMode="Conditional">
                            <ContentTemplate>    
                                <asp:PlaceHolder runat="server" ID="PlaceHolder1"
                                    EnableViewState="false" />
                            </ContentTemplate>
                          
                        </asp:UpdatePanel>

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
	