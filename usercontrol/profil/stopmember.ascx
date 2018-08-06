<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="stopmember.ascx.cs" Inherits="usercontrol_profil_stopmember" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
<table id="righttables" style="padding-bottom:10px">
  
    <tr valign="middle">
        <td>
       <br />
            Hvis du <b style="color:#cc0099; font-weight:bold;">deaktiverer din profil</b>, blir profilen sjulet fra andre meldem. 
            Du kan reaktivere den igjen med å klikke "Reaktivere min profil" klappen <br />
</td>
</tr>
<tr>
<td>
       <br />
       <asp:Button ID="deactivateBtn" runat="server" Text="Deaktivere profil" 
           width="150px" ForeColor="white" backcolor="#6699FF" 
           onclick="deactivateBtn_Click"/>
            <br />
</td>
</tr>
</table>
<br/>
<table id="righttables" style="padding-bottom:10px">
 <tr valign="middle">
        <td>
       <br />
            Hvis du <b style="color:#cc0099; font-weight:bold;">avsluttet meldemskap</b>, blir profilen din slettet fra våre meldembasen vår.
            Når du ønsker å bli meldem igjen, må du registere på nytt.<br />
</td>
</tr>
<tr>
<td>
       <br />
       <asp:Button ID="stopmemberBtn" runat="server" Text="Stoppe meldemskap" 
           width="150px" ForeColor="white" backcolor="#6699FF" 
           onclick="stopmemberBtn_Click"/>
            <br />
</td>
</table>
