<%@ Control Language="C#" AutoEventWireup="true" CodeFile="administrationvenstercategory.ascx.cs" Inherits="usercontrol_administrationvenstercategory" %>
<%@ OutputCache Duration="90" VaryByParam="None" %>
<table id="lefttables"> 
<tr>
<td>
     <div>
        <div><asp:LinkButton runat="server" 
                Text="Min statistikk" onclick="statistic_Click" id="statistic" style="font-weight:bold; font-size:small" Font-Underline="true" ForeColor="#0033cc">
                </asp:LinkButton></div><br />
                 <div><asp:LinkButton runat="server" 
                Text="Administrasjon" onclick="admin_Click" id="admin" style="font-size:small;font-weight:bold;" Font-Underline="true" ForeColor="#0033cc">
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
                    ID="newmailLi" runat="server"></asp:Literal></div>
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
	</td></tr></table>