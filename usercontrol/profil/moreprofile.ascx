<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="moreprofile.ascx.cs" Inherits="usercontrol_profil_moreprofile" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
<table id="righttables0" >
        <tr><td style="height:10px;">
            <div style="width:   690px; padding-right:10px;" align="right"><asp:Panel runat="server" ID="pagePan" Width="200px"/></div>
                <asp:repeater id="Repeater1"       
                    runat="server" onitemcommand="Repeater1_ItemCommand">
                    <headertemplate>
                      <table>
                        <tr style="height:35px; background-color:#cce6ff;">
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><a><b>Bruknavn</b></a></td>
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><a ><b>Alder</b></a></td>
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><a ><b>Bosted</b></a></td>
		                    <td style="width:115px;padding-left:3px;padding-right:5px; color:#cc0099;"><a ><b>On/offline</b></a></td>		                    
                        	<td style="width:115px;padding-left:3px;padding-right:5px;"><a ><b>Album</b></a></td>
                        	<td style="width:115px;padding-left:3px;padding-right:5px;"><a ><b>Blogg</b></a></td>
                        </tr>
                    </headertemplate>
                    <itemtemplate>
                      <tr bgcolor="#e8e8e8">
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton id="usernameLi" runat="server" CommandName="username" Text='<%# Eval("UsernameParameter") %>'></asp:LinkButton></td>
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" id="ageLi" CommandName="age" Text='<%# Eval("AgeParameter") %>'></asp:LinkButton></td>
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton ID="locationLi" runat="server" CommandName="location" Text='<%# Eval("CityParameter") %>'></asp:LinkButton></td>
		                    <td style="width:115px;padding-left:3px;padding-right:5px;color:#cc0099;"><asp:LinkButton ID="LinkButton1" runat="server" CommandName="location" Text='<%# Eval("OnlineParameter") %>'></asp:LinkButton></td>		                    
                        	<td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" id="albumLi" CommandName="album" Text='<%# Eval("AlbumParameter") %>'></asp:LinkButton></td>
                        	<td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" id="blogLi" CommandName="blog" Text='<%# Eval("BlogParameter") %>'></asp:LinkButton></td>
                      </tr>
                    </itemtemplate>
                    
                    <AlternatingItemTemplate>
                      <tr>
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton id="usernameLi" runat="server" CommandName="username" Text='<%# Eval("UsernameParameter") %>'></asp:LinkButton></td>
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" id="ageLi" CommandName="age" Text='<%# Eval("AgeParameter") %>'></asp:LinkButton></td>
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton ID="locationLi" runat="server" CommandName="location" Text='<%# Eval("CityParameter") %>'></asp:LinkButton></td>
		                    <td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton ID="LinkButton1" runat="server" CommandName="location" Text='<%# Eval("OnlineParameter") %>'></asp:LinkButton></td>		                    
                        	<td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" id="albumLi" CommandName="album" Text='<%# Eval("AlbumParameter") %>'></asp:LinkButton></td>
                        	<td style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" id="blogLi" CommandName="blog" Text='<%# Eval("BlogParameter") %>'></asp:LinkButton></td>
                      </tr>
                    </AlternatingItemTemplate>
                    
                    <footertemplate>
                      </table>
                    </footertemplate>
                </asp:repeater>
	        </td>
	    </tr>
</table>