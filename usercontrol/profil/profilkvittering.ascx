<%@ Control Language="C#" EnableViewState="false" AutoEventWireup="true" CodeFile="profilkvittering.ascx.cs" Inherits="usercontrol_profil_profilkvittering" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
<table id="righttables0" style="width:730px"><tr id="headtr">
 	    <td style="font-weight:bold" align="center">
 	        Meldning
 	    </td></tr>
    <tr  valign="top" align="center" style="height:50px">
        <td>
       <br />
            <asp:Literal ID="receip" runat="server"></asp:Literal>
            <br />
            <asp:HyperLink ID="registermemberlink" runat="server" Enabled="False" 
                Visible="False">Opprett brukerkonto</asp:HyperLink>
</td>
</tr>
</table>
