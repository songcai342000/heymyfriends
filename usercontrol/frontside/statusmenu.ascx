<%@ Control Language="C#" AutoEventWireup="true" CodeFile="statusmenu.ascx.cs" Inherits="usercontrol_mainmenu" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
 <table class="menutable" style="color:white; background-color:#cc0099; border-top-color:White; border-top-style:none;">
    <tr>
        <td style="padding-left:10px; width:50%">
            <asp:HyperLink ID="nameHype" runat="server" 
                EnableViewState="False" Font-Size="Small">[nameHype]</asp:HyperLink>
        </td>
        <td style="width:100%; padding-right:10px;" align="right">
            <asp:LoginStatus ID="LoginStatus1" runat="server"  
                visible="false" onloggedout="LoginStatus1_LoggedOut" 
                EnableViewState="False" ForeColor="White"/>&nbsp; &nbsp;
            <asp:HyperLink ID="helpHyp" runat="server" NavigateUrl="~/general/Hjelp.aspx?Help={0}" ForeColor="white" Font-Size="Small"
                EnableViewState="False">Hjelp & Kundeservice</asp:HyperLink>&nbsp; &nbsp;
        </td>
    </tr>
</table>