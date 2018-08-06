<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="blockprofile.ascx.cs" Inherits="usercontrol_profil_blockprofile" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
<table id="righttables0" style="width:730px"><tr id="headtr">
 	    <td style="font-weight:bold" align="center">
            Er du sikker på du vil blokkere vedkommende? 	    
            </td></tr>
    <tr  valign="top" align="center" style="height:50px">
        <td>
       <br />
            <asp:Button ID="yesBtn" runat="server" Text="Ja" onclick="yesBtn_Click"></asp:Button>
            <asp:Button ID="noBtn" runat="server" Text="Nei" onclick="noBtn_Click"></asp:Button>
</td>
</tr>
</table>