<%@ Control Language="C#" AutoEventWireup="true" CodeFile="utboks.ascx.cs" Inherits="usercontrol_mail_utboks" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
    <table id="righttables0" ><tr style="height: 16px; width:16px;">
 	    <td style="font-weight:bold" align="center">Sendte elementer</td>
    </tr>
    <tr><td>
	<table>
        <tr><td style="padding:12px;" colspan="5">
            <asp:Button ID="slettalle" 
                runat="server" type="button" value="Slett merkede" 
                Text="Slett merkede" onclick="slettalle_Click" />&nbsp;&nbsp;</td></tr></table></td></tr>	
        <tr><td style="height:10px;">

                <asp:repeater id="Repeater1"       
                    runat="server" onitemcommand="Repeater1_ItemCommand">
                    <headertemplate>
                      <table>
                        <tr>
                          <td style="width:175px;border-left:3px #ECF5FF solid;"><asp:Checkbox runat="server" id="checkall" type="checkbox" />Check all</td>
		 
		                    <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b>Emne</b></a></td>
                    		
		                    <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b>Mottaker</b></td>
                     
		                    <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b>Dato/Tid</b></td>
                        </tr>
                    </headertemplate>
                    <itemtemplate>
                      <tr bgcolor="#e8e8e8">
                        <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:CheckBox ID="chk" runat="server" EnableViewState="False" /></td>
                        <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="titleBtn" CommandName="mailtitle"><%# Eval("Mailtitle")%></asp:LinkButton></td>
                        <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="nameBtn" CommandName="mailreceiver"><%# Eval("Receiver")%></asp:LinkButton></td>
                        <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="timeBtn" CommandName="mailtime"><%# Eval("Time")%></asp:LinkButton></td>
                      </tr>
                    </itemtemplate>
                    
                    <AlternatingItemTemplate>
                      <tr>
                        <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:CheckBox ID="chk" runat="server" EnableViewState="False" /></td>
                        <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="titleBtn" CommandName="mailtitle"><%# Eval("Mailtitle")%></asp:LinkButton></td>
                        <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="nameBtn" CommandName="mailreceiver"><%# Eval("Receiver")%></asp:LinkButton></td>
                        <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="timeBtn" CommandName="mailtime"><%# Eval("Time")%></asp:LinkButton></td>
                      </tr>
                    </AlternatingItemTemplate>
                    
                    <footertemplate>
                      </table>
                    </footertemplate>
                </asp:repeater>
	            </td>
	        </tr>
	    </table>
	 </td>
	</tr>
</table>