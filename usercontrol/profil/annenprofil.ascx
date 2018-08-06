<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="annenprofil.ascx.cs" Inherits="usercontrol_profil_annenprofil" %>
<%@ OutputCache Duration="90" VaryByParam="None" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
       
		<table id="righttables0">
			 <tr id="headtr">
			<td align="center">
			<b style="font-weight:bold;">
				 <asp:Literal ID="username" runat="server"></asp:Literal>s profil
			</b>
                
			</td>
			</tr>
			<tr>
			<td style="padding:10px 10px 10px 10px;" align="center">
			
			</td>
			</tr>
			<tr>
			<td>
			<b style="font-weight:bold; padding-left:10px;"><asp:Literal ID="name" runat="server"></asp:Literal></b> - 
                <b style="font-weight:bold; color:#cc0099"><asp:Literal ID="online" runat="server"></asp:Literal></b></td></tr>
			<tr>
				<td style="padding:10px 10px 10px 10px;"><span style="color:#CC0066;font-weight:bold;">Kjønn:</span>
				<asp:Literal ID="gender" runat="server"></asp:Literal>
				</td>
			</tr>
			<tr>
				<td style="padding:10px 10px 10px 10px;"><span style="color:#CC0066;font-weight:bold;">Alder:</span>
				<asp:Literal ID="age" runat="server"></asp:Literal> &aring;r</td>
			</tr>
			<tr>
				<td style="padding:10px 10px 10px 10px;"><span style="color:#CC0066;font-weight:bold;">Land:</span>
				<asp:Literal ID="country" runat="server"></asp:Literal>
				</td>
			</tr>
			<tr>
				<td style="padding:10px 10px 10px 10px;"><span style="color:#CC0066;font-weight:bold;">
				Fylke:
				</span>
				<asp:Literal ID="province" runat="server"></asp:Literal> 
				</td>
			</tr>
			<tr>
			
				<td style="padding:10px 10px 10px 10px;"><span style="color:#CC0066;font-weight:bold;">By:</span>
				<asp:Literal ID="city" runat="server"></asp:Literal>
			</td>
		</tr>
		<tr>
			<td style="padding:10px 10px 10px 10px;"><span style="color:#CC0066;font-weight:bold;">Sivilstand:</span>
			<asp:Literal ID="marital" runat="server"></asp:Literal>
			</td>
		</tr>
		<tr><td></td></tr>
		
		<tr>
		<td style="padding-top:10px;">
		<div style="padding-bottom:6px;padding-left:6px;"><asp:Button ID="blockProfile"
            runat="server" Text="Blokkere kontakt" onclick="blockProfile_Click" width="150px" BackColor="#cc0099" ForeColor="white"/>
            </div>
            
            <div style="padding-bottom:6px;padding-left:6px;"><asp:Button 
                runat="server" id="askkey" Text="Be om nøkkelen til albumen" 
                onclick="askkey_Click" width="150px"></asp:Button></div>
		
		<div style="padding-bottom:6px;padding-left:6px;"><asp:Button 
                runat="server" id="favorittprofil" Text="Legg til i favoritter" 
                onclick="favorittprofil_Click" width="150px"></asp:Button></div>
        
         <div style="padding-bottom:6px;padding-left:6px;"><asp:Button 
        runat="server" id="venner" Text="Legge til i vennelist" 
        onclick="venner_Click" width="150px"></asp:Button></div>
		        
        <div style="padding-bottom:6px;padding-left:6px;">
            <asp:Button ID="flower" runat="server" Text="Sende en gave" 
                onclick="flower_Click" width="150px"></asp:Button></div>
                
		 <div style="padding-bottom:6px;padding-left:6px;">
            <asp:Button ID="blink" runat="server" Text="Sende blunk" 
                 onclick="blink_Click" style="width:150px" 
                ></asp:Button></div>
        <div style="padding-bottom:6px;padding-left:6px;">
            <asp:Button ID="post" runat="server" Text="Sende meldning" 
        PostBackUrl="~/functions/Readmailprofil.aspx?skriv{0}" 
        onclick="post_Click" width="150px"></asp:Button></div>
        
       
        
		</td>
		</tr>
		</table>
		<br/>
		 <table id="righttables">
       
		<tr>
			<td>
			    Har du et profilbilde øker det sjansen for å bli kontaktet
			    (Laste opp/bytte profilbilde)
			</td>
		</tr>
		<tr>
		<td>
        <asp:Image ID="profileImg" runat="server" Width="100px" Height="120px" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="loadBtn"
            runat="server" Text="Forespøre profilbilde" onclick="loadBtn_Click" width="150px" BackColor="#cc0099" ForeColor="white"/>
		</td>
		</tr>
        <tr>
            <td align="center">
                <asp:Label ID="UploadStatusLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>       
		
		</table><br/>
		<table id="righttalbes">
		<tr>
		<td style="width:50%;">
			<table cellspacing="0" cellpadding="0" style="width:350px; padding-left:10px;">
				<tr><td colspan="2" style="color:#CC0099;font-weight:bold;"></td></tr>			
				<tr><td colspan="2" style="color:#CC0099;font-weight:bold;">Generellt</td></tr>
				<tr><td>Stjernetegn:</td><td style="padding-left:5px;">			
				    <asp:Literal ID="star" runat="server"></asp:Literal>
                </td></tr>
				<tr><td style="background:#E8E8FF;">Barn:</td><td style="padding-left:5px;background:#E8E8FF;">			
				<asp:Literal ID="child" runat="server"></asp:Literal>
                    </td></tr>
				<tr><td>Drikker:</td><td style="padding-left:5px;"><asp:Literal ID="drink" runat="server"></asp:Literal>
                    </td></tr>
				<tr><td style="background:#E8E8FF;">Røyker:</td><td style="padding-left:5px;background:#E8E8FF;">
				<asp:Literal ID="smoke" runat="server"></asp:Literal>
                    </td></tr>
                <tr><td>Sivilstand:</td><td style="padding-left:5px;">
				<asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </td></tr>
			
			<tr><td colspan="2" style="color:#CC0099;font-weight:bold;padding-top:20px;">Bakgrunn</td></tr>
			<tr><td>Etnisk bakgrunn:</td><td style="padding-left:5px;"><asp:Literal ID="ethenic" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td style="background:#E8E8FF;">Religion:</td><td style="padding-left:5px;background:#E8E8FF;"><asp:Literal ID="religion" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td>Yrke:</td><td style="padding-left:5px;">
			<asp:Literal ID="occupation" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td style="background:#E8E8FF;">Utdannelse:</td><td style="padding-left:5px;background:#E8E8FF;">
			<asp:Literal ID="education" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td>Språk:</td><td style="padding-left:5px;">
			<asp:Literal ID="language1" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td style="background:#E8E8FF;">Språk to:</td><td style="padding-left:5px;background:#E8E8FF;">
			<asp:Literal ID="language2" runat="server"></asp:Literal>
                    </td></tr>
 
			<tr><td colspan="2" style="color:#CC0099;font-weight:bold;padding-top:20px;">Utseende</td></tr>
			<tr><td>Hårfarge:</td><td style="padding-left:5px;">
			<asp:Literal ID="haircolor" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td style="background:#E8E8FF;">Kroppstype:</td><td style="padding-left:5px;background:#E8E8FF;">		
			<asp:Literal ID="physique" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td>Høyde:</td><td style="padding-left:5px;">
					<asp:Literal ID="height" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td style="background:#E8E8FF;">Øyenfarge:</td><td style="padding-left:5px;background:#E8E8FF;">
					<asp:Literal ID="eyecolor" runat="server"></asp:Literal>
                    </td></tr></table>
		</td>
		<td style="width:50%; valign="top" style="padding-top:0px">
			<table id="#flexibletable" style="width:350px;">
			<tr><td style="color:#CC0099;font-weight:bold;">Interesser</td></tr>
			<tr><td>Generellt:</td><td style="padding-left:5px;">
			<asp:Literal ID="hobby" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td style="background:#E8E8FF;">Musikk:</td><td style="padding-left:5px;background:#E8E8FF;">
					<asp:Literal ID="music" runat="server"></asp:Literal>
                    </td></tr>
			<tr><td>Sport:</td><td style="padding-left:5px;">
					<asp:Literal ID="sport" runat="server"></asp:Literal>
                    </td></tr>
			<tr style="background:#E8E8FF;"><td>Pet:</td><td style="padding-left:5px;">
					<asp:Literal ID="pet" runat="server"></asp:Literal>
                    </td></tr>	
                  
			<tr><td colspan="2" style="color:#CC0099;font-weight:bold;padding-top:20px;">Om den jeg søker</td></tr>
			<tr><td>Kjønn:</td><td style="padding-left:5px;">
			<asp:Literal ID="search" runat="server"></asp:Literal>
                    </td></tr>		
			<tr><td style="background:#E8E8FF;">Alder:</td><td style="padding-left:5px;background:#E8E8FF;">&nbsp;<asp:Literal ID="searchage" runat="server"></asp:Literal></td></tr>
			<tr><td>Type av kontakt:</td><td style="padding-left:5px;">
		        <asp:Literal ID="kontakttype" runat="server"></asp:Literal>
                    </td></tr>	
                    	<tr><td></td><td>
                    </td></tr>
			<tr><td></td><td>
                    </td></tr>	
                    	<tr><td></td><td>
                    </td></tr>
			<tr><td></td><td>
                    </td></tr>	
                    	<tr><td></td><td>
                    </td></tr>
			<tr><td></td><td>
                    </td></tr>	
			</table> 
		</td>
		</tr>
		</table>
		<br/>	
		<table id="righttables">
		<tr><td style="height:12px;background:url('') no-repeat"></td></tr>
		<tr><td style="padding:0px 10px 10px 10px;"><font style="color:#CC0099;font-weight:bold;">Om meg selv</font><br />
		<div style="width:533px;">
		 <asp:Literal ID="selv" runat="server"></asp:Literal></div>
                    </td></tr>	<br /><br />
		
	
		<tr><td style="height:12px;background:url('../images/big_profile_bg2_2.gif') no-repeat 50% top;"></td></tr>
		</table><br/>
		<table id="righttables">
		<tr><td style="padding:0px 10px 10px 10px;"><font style="color:#CC0099;font-weight:bold;">Om den jeg søker</font><br />
		<div>
		<br /><br />
		<asp:Literal ID="desired" runat="server"></asp:Literal>
		</div>
		</td></tr>
		<tr><td style="padding:0px 10px 10px 10px;">
            <asp:Panel ID="approvedenypanel" runat="server">
            </asp:Panel>
		</td></tr>
		</table>
	