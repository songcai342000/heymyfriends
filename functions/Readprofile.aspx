<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Hjemside.master" CodeFile="Readprofile.aspx.cs" Inherits="functions_Readprofile" %>
<%@ Register src="~/usercontrol/frontside/mainmenu.ascx" tagname="mainmenu" tagprefix="uc1" %>
<%@ Register src="~/usercontrol/frontside/headlogonopicture.ascx" tagname="headlogonopicture" tagprefix="uc3" %>
<%@ Register src="~/usercontrol/frontside/copyright.ascx" tagname="copyright" tagprefix="uc4" %>
<%@ Register src="~/usercontrol/minside/venstercategory2.ascx" tagname="venstercategory2" tagprefix="uc5" %>
<%@ Register src="~/usercontrol/frontside/statusmenu.ascx" tagname="statusmenu" tagprefix="uc6" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
        <title>Finne kj�rlighet, vennskaper og karrie nettverk</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<meta name="keywords" content="dating single, blogg, hobby venn, tema debatt, aktiviteter, nettverk, kj�rlighet">
        <meta name="description" content="Finn kj�rlighet, vennskap, gratis medlemskap p� Minevenner.no" />
        <meta name="expires" content="never" />
        <meta name="language" content="nor" />
        <meta name="charset" content="ISO-8859-1" />
        <meta name="distribution" content="Global" />
        <meta name="email" content="kundeservice@Minevenner.no">
        <meta name="copyright" content="Copyright � 2010, Minevenner.no">
        <meta name="author" content="Minevenner.no">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<table align="center" style="background-color:white; width:950px">
    <tr style="width:   950px;">
                <td valign="bottom">
                    <uc6:statusmenu ID="statusmenu1" runat="server" />                   
                    <uc3:headlogonopicture ID="headlogonopicture1" runat="server" />
		            <uc1:mainmenu ID="mainmenu1" runat="server" />
	            </td>
	        </tr>
    <tr style="background-color:white;">
        <td>
            <table style="font-size:small">
                <tr>
                    <td style="width:25%; padding-left:10px; padding-top:10px" valign="top">
                        
<table id="lefttables"> 
<tr>
<td>
     <div>
        <div><asp:LinkButton runat="server" 
                Text="Min statistikk" onclick="statistic_Click" id="statistic" style="font-weight:bold; font-size:small" ForeColor="#0033cc">
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
                   <div><asp:LinkButton runat="server" id="minen�kler" Text="Mine n�kler" 
                PostbackUrl="/vennskap/functions/Profilepage.aspx?minevenner={0}" 
                onclick="minen�kler_Click"></asp:LinkButton></div>     
            <div><asp:LinkButton runat="server" id="minevenner" Text="Mine venner" 
                    PostbackUrl="/vennskap/functions/Profilepage.aspx?minevenner={0}" 
                    onclick="minevenner_Click"></asp:LinkButton></div>
              
			<div><asp:LinkButton runat="server" id="mineblomster" Text="Mine blomster" 
                    PostbackUrl="/vennskap/functions/Profilepage.aspx?minevenner={0}" 
                    onclick="mineblomster_Click"></asp:LinkButton></div>
            <div><asp:LinkButton runat="server" id="besokere" Text="Mine bes�kere" 
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
	</td></tr></table>                        
                    </td>
                    <td style="width:75%; padding-top:10px; padding-left:10px; padding-right:10px;" valign="top" >
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
	