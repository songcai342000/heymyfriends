<%@ Control Language="C#" AutoEventWireup="true" CodeFile="bloggvenster.ascx.cs" Inherits="usercontrol_Blog_blogvenster" %>
<%@ OutputCache Duration="90" VaryByParam="None" %>     
            <table class="flexibletable" style="width:248px; height:335px;padding-left:0px; padding-top:2px;">
                <tr>
                    <td valign="top" align="center">
                            <b style="font-weight:bold;color:#990099;">Populære Blogger</b><br/><br/>
                        <asp:Panel runat="server" ID="popularPanel" Height="260px">
                            <asp:repeater id="popularblog"       
                                    runat="server" onitemcommand="popularblog_ItemCommand">
                                    <headertemplate>
                                      <table>
                                        <tr>
                                        <td></td>
                                         <td></td>
                                        </tr>
                                    </headertemplate>
                                    <itemtemplate>
                                      <tr>
                                        <td  style="width:100px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="popularblogTitleBtn" CommandName="popularblogtitle" Text='<%# Eval("Blogtitle")%>'><%# Eval("Blogtitle")%></asp:LinkButton></td>
                                        <td  style="width:100px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="popularblogUserBtn" CommandName="popularbloguser" Text='<%# Eval("Username")%>'><%# Eval("Username")%></asp:LinkButton></td>
                                      </tr>
                                    </itemtemplate>
                                   
                                    <footertemplate>
                                      </table>
                                    </footertemplate>
                            </asp:repeater>
                      </asp:Panel>
                    </td>
                </tr>
            </table></td></tr>
            <tr><td>
            <table class="flexibletable" style="width:248px; height:175px; padding-left:0px; padding-top:2px;">
                <tr>
                    <td valign="top" align="center">
                        <div style="font-weight:bold; color:#990099;">Søk opp blogg</div><br/>
                        <asp:TextBox ID="searchTxt" runat="server"></asp:TextBox><br/>
                            <asp:RadioButtonList ID="searchRadioBtn" runat="server" 
                                            onselectedindexchanged="searchRadioBtn_SelectedIndexChanged">
                                <asp:ListItem>Søke etter brukernavn</asp:ListItem>
                                <asp:ListItem>Søke etter blogg title</asp:ListItem>
                            </asp:RadioButtonList><br/>
                            <asp:Button 
                            ID="searchBtn" runat="server"
                            Text="Søk" onclick="searchBtn_Click" />
                    </td>
                </tr>
            </table></td></tr>
            <tr><td>
            <table class="flexibletable" style="width:248px; height:295px; padding-left:0px; padding-top:2px;">
                <tr>
                    <td valign="top" align="center">
                        <b style="font-weight:bold; color:#990099;">Nye Blogg</b><br/>
                        <asp:Panel runat="server" ID="newblogPanel" Height="200px">
                          <asp:repeater id="newbloglist"       
                            runat="server" onitemcommand="newbloglist_ItemCommand">
                            <headertemplate>
                              <table>
                                <tr>
                                <td></td>
                                 <td></td>
                                </tr>
                            </headertemplate>
                            <itemtemplate>
                              <tr  bgcolor="#e8e8e8">
                                <td  style="width:100px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newblogtitleBtn" CommandName="newblogtitle" Text='<%# Eval("Blogtitle")%>'><%# Eval("Blogtitle")%></asp:LinkButton></td>
                                <td  style="width:100px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newbloguserBtn" CommandName="newbloguser" Text='<%# Eval("Username")%>'><%# Eval("Username")%></asp:LinkButton></td>
                              </tr>
                            </itemtemplate>
                            <alternatingitemtemplate>
                              <tr  >
                                <td  style="width:100px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newblogtitleBtn" CommandName="newblogtitle" Text='<%# Eval("Blogtitle")%>'><%# Eval("Blogtitle")%></asp:LinkButton></td>
                                <td  style="width:100px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newbloguserBtn" CommandName="newbloguser" Text='<%# Eval("Username")%>'><%# Eval("Username")%></asp:LinkButton></td>
                              </tr>
                            </alternatingitemtemplate>
                            <footertemplate>
                              </table>
                            </footertemplate>
                        </asp:repeater>
                        </asp:Panel>
                        <br/>
                            <div><a href="/vennskap/general/moreblog.aspx?newblog={0}" id="newblog" runat="server">Flere Blogg >></a><br /><br />
                    </td>
                </tr>
            </table>
               
 