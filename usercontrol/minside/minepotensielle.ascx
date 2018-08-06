<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="minepotensielle.ascx.cs" Inherits="usercontrol_minside_minepotensielle" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
	<table id="righttables0" ><tr id="headtr">
 	    <td style="font-weight:bold" align="center">
 	        <asp:Literal ID="potensialTitle" runat="server" />
 	    </td><tr><td>
  <asp:repeater id="Repeater1"       
                    runat="server">
                    <headertemplate>
                      <table>
                        <tr style="font-weight:bold;">
                        <td  style="width:115px;padding-left:3px;padding-right:5px;">Navn</td>
                        <td  style="width:115px;padding-left:3px;padding-right:5px;">Alder</td>
                        <td  style="width:115px;padding-left:3px;padding-right:5px;">By</td>
                        <td  style="width:115px;padding-left:3px;padding-right:5px;">On/Offline</td>                        
                        <td  style="width:115px;padding-left:3px;padding-right:5px;">Album</td>  
                        <td  style="width:115px;padding-left:3px;padding-right:5px;">Blogg</td>                          
                      </tr>
                    </headertemplate>
                    <itemtemplate>
                      <tr>
                        <tr  bgcolor="#e8e8e8">
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="nameli" Text='<%# Eval("UsernameParameter")%>'><%# Eval("UsernameParameter")%></asp:LinkButton></td>
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="ageli" Text='<%# Eval("AgeParameter")%>'><%# Eval("AgeParameter")%></asp:LinkButton></td>
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="cityli" Text='<%# Eval("CityParameter")%>'><%# Eval("CityParameter")%></asp:LinkButton></td>
                        <td  style="width:115px;padding-left:3px;padding-right:5px; color:#cc0099;"><asp:LinkButton runat="server" ID="onlineli" Text='<%# Eval("OnlineParameter")%>'><%# Eval("OnlineParameter")%></asp:LinkButton></td>                        
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="albumli" Text='<%# Eval("AlbumParameter")%>'><%# Eval("AlbumParameter")%></asp:LinkButton></td> 
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="LinkButton1" Text='<%# Eval("BlogParameter")%>'><%# Eval("AlbumParameter")%></asp:LinkButton></td>                           
                      </tr>
                    </itemtemplate>
                    
                    <alternatingitemtemplate>
                      <tr>
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="nameli" Text='<%# Eval("UsernameParameter")%>'><%# Eval("UsernameParameter")%></asp:LinkButton></td>
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="ageli" Text='<%# Eval("AgeParameter")%>'><%# Eval("AgeParameter")%></asp:LinkButton></td>
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="cityli" Text='<%# Eval("CityParameter")%>'><%# Eval("CityParameter")%></asp:LinkButton></td>
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="onlineli" Text='<%# Eval("OnlineParameter")%>'><%# Eval("OnlineParameter")%></asp:LinkButton></td>                        
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="albumli" Text='<%# Eval("AlbumParameter")%>'><%# Eval("AlbumParameter")%></asp:LinkButton></td> 
                        <td  style="width:115px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="LinkButton1" Text='<%# Eval("BlogParameter")%>'><%# Eval("AlbumParameter")%></asp:LinkButton></td>                           
                     </tr>
           </alternatingitemtemplate>
                    
                    <footertemplate>
                      </table>
                    </footertemplate>
                </asp:repeater>
                </td></tr></table>
