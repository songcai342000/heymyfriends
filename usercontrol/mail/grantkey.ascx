<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="grantkey.ascx.cs" Inherits="usercontrol_mail_grantkey" %>
<table id="righttables0" ><tr id="headtr">
 	    <td style="font-weight:bold" align="center">Svar til førspørelse</td>
    </tr>
    <tr><td>
	<table id="righttables"><tr align="center"><td>
    <asp:Button runat="server" id="grantkey" value="Merk alle" 
        style="width:150px;" Text="Godkjenne førspørelse" onclick="grantkey_Click" />&nbsp;&nbsp;<asp:Button 
        runat="server" id="writenew"  
        style="width:150px;" Text="Skrive til vedkommende" onclick="writenew_Click" />&nbsp;&nbsp;<asp:Button ID="block" 
        runat="server" style="width:150px;" 
        Text="Blokke vedkommende" />&nbsp;&nbsp;<asp:Button 
        runat="server" id="selectall" value="Merk alle" 
        style="width:150px;" Text="Slette meldningen" /></td></tr>
        </table>
    </td>
    <tr style="height:35px; background-color:#cce6ff"><td></td>
    </tr>
        </table>
    