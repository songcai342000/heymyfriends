<%@ Control Language="C#" AutoEventWireup="true" CodeFile="annenalbum.ascx.cs" Inherits="usercontrol_annenalbum" %>
<%@ OutputCache Duration="90" VaryByParam="None" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
    <table class="righttables0"><tr id="headtr">
 	    <td style="font-weight:bold;" align="center">
 	        Fotoalbum!
	    </td></tr></table><br/>
                       
                        <table class="righttables0">
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
