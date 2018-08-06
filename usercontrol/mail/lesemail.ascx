<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lesemail.ascx.cs" Inherits="usercontrol_mail_lesemail" %>
 <table id="righttables0"><tr id="headtr">
 	    <td style="font-weight:bold" align="center">Lese meldning</td>
    </tr>
    <tr><td>
	        <table id="righttables" style="border-bottom-style:none;border-top-style:none;border-right-style:none;border-left-style:none;">
<tr style="padding-left:10px"><td>
    <asp:Button runat="server" type="button" id="reply" value="Merk alle" 
        style="width:120px;" Text="Svare" onclick="reply_Click" />&nbsp;&nbsp;<asp:Button 
        runat="server" style="width:140px;" 
        Text="Blokke vedkommende" onclick="block_Click" />&nbsp;&nbsp;<asp:Button 
        runat="server" id="deleteall" 
        style="width:120px;" Text="Slette meldningen" onclick="deleteall_Click" /></td></tr>
        <tr><td>
        <table id="flexibletable" style="border-bottom-style:none;border-top-style:none;border-right-style:none;border-left-style:none;">
            <tr style="padding-left:10px">
                <td>
                    <asp:Literal ID="fromto" runat="server"></asp:Literal>: 
                    <asp:HyperLink ID="senderLink" runat="server" NavigateUrl="/vennskap/functions/Nye.aspx">HyperLink</asp:HyperLink>
                </td>
            </tr>
             <tr style="padding-left:10px">
                <td>
                    <asp:Literal ID="title" runat="server"></asp:Literal>&nbsp;&nbsp;<asp:Literal ID="time" runat="server"></asp:Literal>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Literal ID="attach" runat="server" Text="Legge til en blomst eller blunke"></asp:Literal>&nbsp;&nbsp;<asp:ImageButton 
                        runat="server" id="flower" border="0" 
                        style="vertical-align:middle;" onclick="flower_Click" />&nbsp;&nbsp;<asp:ImageButton 
                        runat="server" id="blink" imageUrl="/vennskap/images/blink.jpg" runat="server" 
                        border="0" style="vertical-align:middle; width: 26px;" onclick="blink_Click" />
                </td>
            </tr>
            <tr>
            <td align="center">
            <table>
            <tr>           
                <td valign="top" align="left" style="padding-left:20px">
                <asp:Panel ID="panel1" runat="server" Width="600px">
                <asp:Literal runat="server" id="mailcontent" />
                <Textarea ID="chosenblogcontentPan" runat="server" 
                        style="width:590px;" visible="false"></Textarea> <br/>
                </asp:Panel>
                </td>
            </tr>
            </table><br/>
                    </td>
            </tr>
             <tr>
                <td align="left" style="padding-left:10px">
                    <asp:Button ID="sendBtn" runat="server" Text="Send" onclick="sendBtn_Click" /></td>
            </tr>
        </table>
        </td>
    </tr>
</table>