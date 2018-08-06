<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="nymeldning.ascx.cs" Inherits="usercontrol_mail_nymeldning" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
<table id="righttables0" style="border-bottom-style:none;"><tr id="headtr">
 	    <td style="font-weight:bold" align="center">Ny melding</td>
        </tr>
        <tr style="height:35px;">
 	            <td></td>
        </tr>
        <tr><td>
        <table>		
        <tr>
			<td align="center">Til:</td><td> 
                <asp:TextBox ID="receiver" runat="server" Width="600px"></asp:TextBox></td>
		</tr>
		<tr>
                <td align="center">Emne:</td><td>
                <asp:TextBox ID="mailtitle" runat="server" Width="600px"></asp:TextBox></td>
		</tr>
		
		<tr><td></td>
			<td align="center">Klikke her til å legge til en 
                <asp:ImageButton 
                    ID="ImageButton1" runat="server" style="height: 16px; width:16px;" 
                    onclick="ImageButton1_Click" ToolTip="Blink" /><b style="color:#cc0099;">  eller </b>
                <asp:ImageButton 
                    ID="ImageButton2" runat="server" onclick="ImageButton2_Click" ImageUrl="~/images/blink.jpg" style="height: 16px; width:16px;"/></td></tr></table></td></tr>
        <table id="righttables" style="border-top-style:none;">
        <tr>
               <td align="left" style="padding-left:20px">
                    <Textarea ID="messagetext" runat="server" cols="108" rows="10"></Textarea>
               </td>
		</tr>
		<tr><td></td></tr>
		<tr><td align="left" style="padding-left:20px">
        <asp:Button ID="send2" runat="server" Text="Send" onclick="send2_Click" /></td></tr>
</table>
