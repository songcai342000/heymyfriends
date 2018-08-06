<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lagalbum.ascx.cs" Inherits="usercontrol_lagalbum" %>
<%@ OutputCache Duration="90" VaryByParam="None" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
    <table class="righttables0"><tr class="headtr">
 	    <td style="font-weight:bold;" align="center">
 	        Fotoalbum!
 	    </td></tr><tr><td>
	    <table>
				<tr>
					<td>
                    	<div style="color:#CC0099;font-weight:bold;">Lag din personlig album</div>
                    	<div align="right" style="width:650px"><asp:ImageButton
                                ID="keyBtn" runat="server" ImageUrl="~/images/key.jpg" Width="30px" 
                                Height="30px" 
                                ToolTip="Låse du album, må andre få løken fra deg for å se ditt album"/></div>
                        <div align="right" style="width:650px"><asp:LinkButton
                                ID="keylinkBtn" runat="server" ForeColor="#cc0099" 
                            Font-Size="xx-small" onclick="keylinkBtn_Click">Låse album</asp:LinkButton></div>
                        <br />
                        Du kan lagre totalt 30 bilder i album!
                  		<br />
						<br />
                        <asp:FileUpload ID="loadalbum" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br /><br />Legge til tekst for bilde
                        <div>
                            <asp:TextBox ID="imagetext" runat="server"></asp:TextBox> 
                            &nbsp; <asp:Button ID="albumBtn"
                            runat="server" Text="Laste opp" onclick="albumBtn_Click" />
                            </div>
                        <br />
                         <asp:Label ID="UploadStatusLabel" runat="server"></asp:Label>
                         <br />
                        <br />
                        
                        </tr></table></td></tr></table><br/>
                       
                        <table class="righttables" style="padding-left:0px">
                        <tr>
                            <td>
                                <div style="color:#CC0099;font-weight:bold;"><asp:Literal runat="server" ID="clickPicLi" visible="false" Text="Klikke et bilde for å se den på full størrelse"></asp:Literal></div>
                                <br/>
                            </td>
                            </tr>
                            <tr>
                            <td>
                                <asp:Panel ID="photoPanel" runat="server">
                                </asp:Panel>
                            </td>
                            </tr>
			            </table>
