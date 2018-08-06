<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="passwordrecover.ascx.cs" Inherits="usercontrol_frontside_recoverpassword" %>

 <table style=" background-color: #ffbfff; width:950px;" >
	                <tr>
                <!-- start left -->
			                <td style="width:242px;height:150px;">
			                <br/>
                                <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" SuccessPageUrl="/vennskap/Login.aspx" SubmitButtonStyle-BackColor="#0099FF" SubmitButtonStyle-ForeColor="White">
                                </asp:PasswordRecovery>
                            </td>
	
			                <td style="padding-top:10px; padding-left:100px; color:Black">
				                
				                <p>Her finner du mange</p>
                			
				                    <p>Du kan raskt finne din drømvenn raskt</p>
                    			
				                    <p>Her prater du med andre i sikker miljø</p>
                    			
				                    <p>Du kan laste bilde og fotoalbum helt gratis. </p>

			                    <p>
			                     <asp:HyperLink ID="hyperlink1" runat="server" Font-Bold="True" 
                                    Font-Italic="False" Font-Size="Large" Font-Strikeout="False"
                                    ForeColor="#FF9933" Font-Underline="True" NavigateUrl="~/general/Opprettkonto.aspx">Ny 
                                    Bruker? Blir Meldem Gratis!</asp:HyperLink>			                    </p>
		
			</td>
			</tr>
			</table>