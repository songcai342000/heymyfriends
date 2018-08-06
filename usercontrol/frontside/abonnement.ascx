<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="abonnement.ascx.cs" Inherits="usercontrol_abonnement" %>
<%@ OutputCache Duration="90" VaryByParam="None" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
    <table>
    <tr>
    <td valign="top">
        <table class="righttablenonborder" style="background-color:#ffddff;height:35px;width:940px;padding-top:0px; padding-left:0px;border:#ffddff;">
        <tr align="left" valign="middle"><td style=" padding-left:20px;"><b style="color:#0033CC; font-weight:bold; height:30px;">
            <asp:Literal ID="validdaysinforLi" runat="server"></asp:Literal></b>
        </td></tr></table></td></tr>
        <tr><td></td></tr>
        <tr><td>
        <table class="righttablenonborder" style="width:940px;padding-left:0px;padding-top:0px; background-color:#ffddff;">
        <tr><td valign="top" style=" padding-left:20px;">
         <table style="width:50%;">
          <tr>
 	        <td style="font-weight:bold;">
 	        Velg betalingsmåte
 	        </td></tr></table><br/>
 
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" /></td>
                            <td>
                                <asp:ImageButton ID="ImageButton2" runat="server" /></td>
                            <td>
                                <asp:ImageButton ID="ImageButton3" runat="server" /></td>
                            <td>
                                <asp:ImageButton ID="ImageButton4" runat="server" /></td>
                        </tr>
                    </table><br/>
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem>Visa</asp:ListItem>
                            <asp:ListItem>MasterCard</asp:ListItem>
                            <asp:ListItem>EuroCard</asp:ListItem>
                            <asp:ListItem>Klarna</asp:ListItem>
                            <asp:ListItem>Betaling via bank/giro</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
            </td>
            <td valign="top">
            <table style="width:50%">
         <tr>
 	        <td style="font-weight:bold" align="left">
 	        Velg abonnement
 	        </td></tr>
            <tr><td>
              <asp:RadioButtonList ID="priceRad" runat="server">
              </asp:RadioButtonList>
               </td>
            </tr>
              
            </table>
          
            </td>
            </tr>
            <tr>
                    <td >
                        &nbsp;</td>
                    <td align="right">
                        <asp:Button runat="server" ID="payBtn" Text="Fortsatt" onclick="payBtn_Click" Backcolor="#cc0099"/>
                    </td>
                </tr>
            </table>
            </td>
            </tr>
            </table>
     