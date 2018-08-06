<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Blogside.ascx.cs" Inherits="usercontrol_blog_blogside" %>
<%@ OutputCache Duration="90" VaryByParam="None" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
<table align="left">
        <tr style="height:300px">
            <td width="50%" valign="top">
            <table class="flexibletable" style="width:100%; padding-bottom:10px;"><tr><td>
                <asp:Image runat="server" ID="Image1" ImageUrl="~/images/blog.jpg" Width="250px" Height="110px"/><br />
                Total blogger: 
                <asp:Literal ID="blogcount" runat="server"></asp:Literal><br/>
            </td></tr>
            
            <tr><td>
                    <b style="font-weight:bold; color:#990099;" id="butvalgBlogg">Utvalgte Blogger</b><br />
                <asp:Panel ID="Panel2" runat="server" Width="250px" HorizontalAlign="left">
                    <ul >
                        <li ><asp:HyperLink runat="server" id="selectedcontent1" Font-Size="x-small"></asp:HyperLink></li>
                        <li ><asp:HyperLink runat="server" id="selectedcontent2" Font-Size="x-small"></asp:HyperLink></li>                        
                    </ul>
                </asp:Panel>
            </td></tr></table>   
           
            </td>
             <td width="50%"  valign="top">
              <table class="flexibletable" style="height:100%; padding-bottom:10px; padding-top:0px;padding-left:0px">
                <tr><td><div style="background-color:#ffddff;height:25px; vertical-align:middle;">
                    <b  style="font-weight:bold; padding-left:25px; color:#990099;" id="btemadebatt">
                    Debatt tema</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a runat="server" id="earliertopic" style="padding-right:20px; color:#990099;" href="/vennskap/general/moreblog.aspx?contentsortedblog={0}">Tidligere temaer >></a></div>
                    <asp:HyperLink ID="blogcontent" runat="server" NavigateUrl="~/general/moreblog.aspx?topic={0}"></asp:HyperLink><br/>
                    <table>
                        <tr>
                            <td style="width:155px" align="left">
	                            <table id="flexibletable" width="150px" height="220px" style="padding-left:0px; padding-top:0px;">
	                            <tr><td valign="top">
	                            <div style="height:20px; color:#990099;" align="center">Positive synspunkter</div>
                                <div><asp:Panel ID="positivePanel" runat="server" Width="148px" height="220px" HorizontalAlign="left" ForeColor="#990099">
                                
                                    </asp:Panel></div>                                  
	                            </td></tr>
	                            </table>
                            </td>
                            <td style="width:155px" align="left">
                                <table id="flexibletable" width="148px" height="220px" style="padding-left:0px; padding-top:0px;">
	                            <tr><td valign="top">
	                                <div style="height:20px; color:#0033cc;" align="center">Negative synspunkter</div>
	                                <div><asp:Panel ID="negativePanel" runat="server" Width="145px" height="220px" HorizontalAlign="left" ForeColor="#0033cc">
	                                
                                    </asp:Panel></div>         
	                            </td></tr>
	                            </table>                            
	                        </td>
                        </tr>
                    </table><br/>
        
                </td></tr>
            </table>
            </td>
        </tr>
       
        <tr style="height:300px">
            <td width="50%" valign="top">
            <table class="flexibletable" style="padding-top:2px;">
             <tr><td>
                <div style="font-weight:bold; color:#990099;">Anbefalte blogger:</div><br/>
                <asp:Panel runat="server" ID="recommandPanel" Width="310px" HorizontalAlign="left">
                <div><ul>
                    <li><asp:HyperLink ID="recommand1" runat="server" ForeColor="black"></asp:HyperLink></li><br/>
                <li><asp:HyperLink ID="recommand2" runat="server" ForeColor="black"></asp:HyperLink></li><br/>
                <li><asp:HyperLink ID="recommand3" runat="server" ForeColor="black"></asp:HyperLink></li></ul>
                </asp:Panel>                
            </td></tr></table>
            </td>
             <td width="50%" valign="top">
             
                  <table class="flexibletable" width="100%" style="padding-left:0px; padding-top:0px">
                    <tr><td>
                       <div style="background-color:#ffddff;height:25px"><table><tr><td style="width:100px; font-weight:normal;" align="center">
                            <asp:LinkButton ID="relationtitleBtn" runat="server" forecolor="#990099" Font-Bold="true"
                                onclick="relationtitleBtn_Click">Forhold</asp:LinkButton></td>
                            <td runat="server" style="width:100px;font-weight:normal;" align="center">
                            <asp:LinkButton ID="activitytitleBtn" runat="server" forecolor="#990099" Font-Bold="true"
                                onclick="activitytitleBtn_Click">Aktivitet</asp:LinkButton></td><td runat="server" style="width:100px;font-weight:normal;" align="center">
                            <asp:LinkButton ID="othertitleBtn" runat="server" forecolor="#990099" Font-Bold="true" onclick="othertitleBtn_Click">Annet</asp:LinkButton></td></tr></table></div>
                            <h3 style="padding-left:28px;"><asp:Label id="sortedLbl" runat="server"></asp:Label></h3>
                            <div style="padding-left:20px;">
                               
                                <a runat="server" id="selectedsortedblogtitle" style="padding-left:20px;">
                                   </a>
                                    <ul>
                                <li><a runat="server" id="selectedsortedblogcontent"></a><asp:HyperLink runat="server" id="selectedsortedblogContentHyp"></asp:HyperLink></li><br/>
                                </ul>
                                <asp:repeater id="sortedblog"       
                                runat="server" onitemcommand="sortedblog_ItemCommand">
                                <headertemplate>
                                  <table>
                                    <tr>
                                    <td></td>
                                     <td></td>
                                    </tr>
                                </headertemplate>
                                <itemtemplate>
                                  <tr >
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="sortedblogTitleBtn" CommandName="sortedblogtitle" Text='<%# Eval("Blogtitle")%>'><%# Eval("Blogtitle")%></asp:LinkButton></td>
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="sortedblogUserBtn" CommandName="sortedbloguser" Text='<%# Eval("Username")%>'><%# Eval("Username")%></asp:LinkButton></td>
                                  </tr>
                                </itemtemplate>
                                <footertemplate>
                                  </table>
                                </footertemplate>
                            </asp:repeater>
                                <br/>
      
                                <a runat="server" id="moresorted" href="/vennskap/general/moreblog.aspx?contentsortedblog={0}">Flere Blogger >></a><br/><br/>
                            </div>
                    </td></tr>
                </table>
            </td>
        </tr>
 
        <tr style="height:180px">
            <td style="width:50%" valign="top">
                  
                   <table class="flexibletable" style="padding-left:10px; padding-right:10px">
                    <tr>
                        <td valign="top" align="center">
                            <div style="font-weight:bold; color:#990099;">Tilfedige mannblogger</div>
                            <table cellpadding="1px" cellspacing="1px">
                                <tr  align="center">
                                    <td style="padding:2px 2px 2px 2px;">
                                        <asp:ImageButton ID="ImageButton7" runat="server" width="97px" Height="115px"/><br/>
                                        <asp:Literal ID="Literal7" runat="server"></asp:Literal>
                                    </td>
                                     <td style="padding:2px 2px 2px 2px;">
                                         <asp:ImageButton ID="ImageButton8" runat="server" width="97px" Height="115px"/><br/>
                                        <asp:Literal ID="Literal8" runat="server"></asp:Literal>
                                    </td>
                                     <td style="padding:2px 2px 2px 2px;">
                                         <asp:ImageButton ID="ImageButton9" runat="server" width="97px" Height="115px"/><br/>
                                        <asp:Literal ID="Literal9" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                              
                            </table>
                            <div style="height:10px"></div>
                        </td>
                    </tr>
                </table>
                </td>
               <td style="width:50%" valign="top">
               <table class="flexibletable" style="padding-left:10px; padding-right:10px">
                    <tr>
                        <td valign="top" align="center">
                            <div style="font-weight:bold; color:#990099;">Tilfedige kvinneblogger</div>
                            <table cellpadding="1px" cellspacing="1px">                            
                                <tr  align="center">
                                    <td style="padding:2px 2px 2px 2px;">
                                        <asp:ImageButton ID="ImageButton1" runat="server" width="97px" Height="115px"/><br/>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                    </td>
                                     <td style="padding:2px 2px 2px 2px;">
                                         <asp:ImageButton ID="ImageButton2" runat="server" width="97px" Height="115px"/>
                                         <br/>
                                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                    </td>
                                     <td style="padding:2px 2px 2px 2px;">
                                         <asp:ImageButton ID="ImageButton3" runat="server" width="97px" Height="115px"/>
                                         <br/>
                                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            
                            </table>
                            <div style="height:10px"></div>                            
                        </td>
                    </tr>
                    </table>
                    </td>
                    </tr>
        </table>
          
            
