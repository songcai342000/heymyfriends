<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="mainmenu.ascx.cs" Inherits="usercontrol_mainmenu" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
 <table id="menutable" style="border-bottom-color:Silver;">
    <tr>
        <td style="width:100%; padding-left:5px">
        <asp:LinkButton id="start" runat="server" PostbackUrl="/vennskap/Login.aspx" 
                Text="Startside" ForeColor="white"></asp:LinkButton>&nbsp; | &nbsp;
        <asp:LinkButton id="minside" runat="server" 
                Text="Min side" 
                ForeColor="white"
                onclick="minside_Click"></asp:LinkButton>&nbsp; | &nbsp;
        <asp:LinkButton id="seek" runat="server"  
                Text="Søk" onclick="seek_Click" ForeColor="white"></asp:LinkButton>&nbsp; | &nbsp;
        <asp:LinkButton id="Blog" runat="server" PostbackUrl="/vennskap/general/Blog.aspx" Text="Blogg" ForeColor="white"></asp:LinkButton>&nbsp; | &nbsp;
        <asp:LinkButton id="venner" runat="server" 
                Text="Om Minevenner" 
                ForeColor="white" 
                onclick="venner_Click"></asp:LinkButton>&nbsp; | &nbsp;        
        <asp:LinkButton id="abonnement" runat="server" 
                Text="Abonnement" 
                ForeColor="white"
                onclick="abonnement_Click"></asp:LinkButton>&nbsp; | &nbsp;
        </td>
    </tr>
</table>