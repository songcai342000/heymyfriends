<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="miniloggin.ascx.cs" Inherits="usercontrol_frontside_miniloggin" %>

 <table cellpadding="0" cellspacing="1" border="0" style="width:730px;" align="center">
	                <tr>
                <!-- start left -->
			                <td style="width:242px;height:150px; padding-left:10px">
			                <br/>
                                 <asp:Login ID="Login1" runat="server" LoginButtonText="Logg Inn" 
                                                PasswordLabelText="Passord:" TitleText="Logg Inn" 
                                    UserNameLabelText="Brukernavn:" 
                                    onloggedin="Login1_LoggedIn" DisplayRememberMe="False" 
                                    EnableViewState="False" FailureText="Feil oppstår. Venligst prøv igjen."> 
                                    <LoginButtonStyle BackColor="#0099FF" ForeColor="White" />
                                </asp:Login><br/>
                                <asp:LinkButton ID="recoverPassword" runat="server" Font-underline="true" 
                                    ForeColor="#0033cc" 
                                    PostBackUrl="/vennskap/Recoverpassword.aspx">Har du glemt passord ditt? Klikk her</asp:LinkButton>
                                <br/>
 
                            </td>
			                <td style="width:50px" valign="middle">
                               
			                </td>			
			                <td style="padding-top:10px; color:Black">
				                <table cellpadding="0" cellspacing="2">
				                <tr>
                				
				                <td><b style="font-weight:bold;color:#cc0099">Minevenner.no</b> tilbyr et gøy og imøtekommende miljø for</td>
			                    <tr>
                			
				                    <td><b style="font-weight:bold;color:#cc0099">deg</b> som vil finne <b style="color:#cc0099">kjærelighet, vennskap og bekjenskap</b> på nett</td>
			                    </tr>
			                    <tr>
                    			
				                    <td>&nbsp;</td>
			                    <tr>
                    			
				                    <td>Vi oppdaterer jevnlig websien med morsomt og godt innhold</td>
			                    <tr>
                    			
				                    <td><b style="font-weight:bold;color:#cc0099">Og</b> legger ofte ut spennende tilbud. </td>
			                    </tr>
			                    <tr>
				                    <td>&nbsp;</td>
			                    <tr>
			                    <td>
			                     <asp:HyperLink ID="hyperlink1" runat="server" Font-Bold="True" 
                                    Font-Italic="False" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="false"
                                    ForeColor="#FF9933" NavigateUrl="~/general/Opprettkonto.aspx">Bli Medlem Gratis!</asp:HyperLink><br/>			                    </td>
			                    </tr>
			                
		                </table>								
		
			</td>
			</tr>
			</table>