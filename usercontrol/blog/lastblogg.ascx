<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lastblogg.ascx.cs" Inherits="usercontrol_lastblogg" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
    <table class="righttables" style="padding-bottom:10px">
        <tr>
	        <td>
	            <div>
    	        <div style="color:#0033cc; font-weight:bold">Du har 
                    <asp:Literal ID="blogcount" runat="server"></asp:Literal> Blogger&nbsp;</div><br/>
    	        <b style="color:#cc0099">(Klikke en katelog for å se bloggene i kateloggen)</b><br/><br/>
                 <asp:LinkButton ID="topiclink" runat="server" onclick="topiclink_Click" Font-Size="Smaller" Font-Bold="true">Tema debatt</asp:LinkButton><br/>
                      <asp:repeater id="topicbloglist"       
                            runat="server" onitemcommand="topicbloglist_ItemCommand">
                            <headertemplate>
                              <table>
                                <tr>
                                    <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b></b>Emne</a></td>
                                    <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b>Dato/Tid</b></td>
                                </tr>
                            </headertemplate>
                            <itemtemplate>
                              <tr>
                                <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="titleBtn" CommandName="blogTitle" Font-Bold="True" Text='<%# Eval("Blogtitle")%>'><%# Eval("Blogtitle")%></asp:LinkButton></td>
                                <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="timeBtn" CommandName="blogTime" Text='<%# Eval("Time")%>'><%# Eval("Time")%></asp:LinkButton></td>
                              </tr>
                            </itemtemplate>
                            <footertemplate>
                              </table>
                            </footertemplate>
                    </asp:repeater>
                <br/>
                <asp:LinkButton ID="relationlink" runat="server" onclick="relationlink_Click" Font-Size="Smaller" Font-Bold="true">Forhold</asp:LinkButton><br/>
                      <asp:repeater id="relationbloglist"       
                            runat="server" onitemcommand="relationbloglist_ItemCommand">
                            <headertemplate>
                              <table>
                                <tr>
                                    <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b></b>Emne</a></td>
                                    <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b>Dato/Tid</b></td>
                                </tr>
                            </headertemplate>
                            <itemtemplate>
                              <tr>
                                <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="titleBtn" CommandName="blogTitle" Font-Bold="True" Text='<%# Eval("Blogtitle")%>'><%# Eval("Blogtitle")%></asp:LinkButton></td>
                                <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="timeBtn" CommandName="blogTime" Text='<%# Eval("Time")%>'><%# Eval("Time")%></asp:LinkButton></td>
                              </tr>
                            </itemtemplate>
                            <footertemplate>
                              </table>
                            </footertemplate>
                    </asp:repeater>
                <br/>                
                <asp:LinkButton ID="activitylink" runat="server" onclick="activitylink_Click" Font-Size="Smaller" Font-Bold="true">Aktivitet</asp:LinkButton><br/>
                      <asp:repeater id="activitybloglist"       
                            runat="server" onitemcommand="activitybloglist_ItemCommand">
                            <headertemplate>
                              <table>
                                <tr>
                                    <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b></b>Emne</a></td>
                                    <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b>Dato/Tid</b></td>
                                </tr>
                            </headertemplate>
                            <itemtemplate>
                              <tr>
                                <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="titleBtn" CommandName="blogTitle" Font-Bold="True" Text='<%# Eval("Blogtitle")%>'><%# Eval("Blogtitle")%></asp:LinkButton></td>
                                <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="timeBtn" CommandName="blogTime" Text='<%# Eval("Time")%>'><%# Eval("Time")%></asp:LinkButton></td>
                              </tr>
                            </itemtemplate>
                            <footertemplate>
                              </table>
                            </footertemplate>
                    </asp:repeater>
                <br/>                    
                <asp:LinkButton  ID="otherlink" runat="server" onclick="otherlink_Click" Font-Size="Smaller" Font-Bold="true">Annet</asp:LinkButton><br/>
                     <asp:repeater id="otherbloglist"       
                        runat="server" onitemcommand="otherbloglist_ItemCommand">
                        <headertemplate>
                          <table>
                            <tr>
                                <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b></b>Emne</a></td>
                                <td style="width:175px;padding-left:3px;padding-right:5px;"><a href=""><b>Dato/Tid</b></td>
                            </tr>
                        </headertemplate>
                        <itemtemplate>
                           <tr>
                            <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="titleBtn" CommandName="blogTitle" Font-Bold="True" Text='<%# Eval("Blogtitle")%>'><%# Eval("Blogtitle")%></asp:LinkButton></td>
                            <td  style="width:175px;padding-left:3px;padding-right:5px;"> <asp:LinkButton runat="server" ID="timeBtn" CommandName="blogTime" Text='<%# Eval("Time")%>'><%# Eval("Time")%></asp:LinkButton></td>
                          </tr>
                        </itemtemplate>
                        <footertemplate>
                          </table>
                        </footertemplate>
                </asp:repeater>                      
   	        </div></td></tr></table>              
  		        <br />
  		        <table class="righttables"><tr><td style="padding-top:10px;">
  		        <asp:Image runat="server" ID="blogImg" ImageUrl="~/images/blog.jpg" Width="60px" Height="50px"/> <b style="font-weight:bold; color:#0033cc">Skrive din opplevelse, din tanker, hva du gjør, hva du treffer... jo flere skriver du, jo mere kjenner andre 
                deg... ...</b>
		        <br /><br />
		        <div><b>Velge en katelog for din blogg og laste opp bloggen</b>
		        </div>
		        <table>
                    <tr>
	                    <td>
	                        <div>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                                    <asp:ListItem Value="topic">Debatt</asp:ListItem>
                                    <asp:ListItem Value="relation">Forhold</asp:ListItem>
                                    <asp:ListItem Value="activity">Aktivitet</asp:ListItem>
                                    <asp:ListItem Value="other">Annet</asp:ListItem>
                                </asp:RadioButtonList> &nbsp;&nbsp;</div>
                            <div style="font-weight:bold">Blogg title <b style="font-weight:normal">(Tast inn bloggtitle)</b></div>
                            <div align="left">				                    
                            <asp:TextBox ID="blogtitle" runat="server" Width="90%" ></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="Du må taste inn en title" ControlToValidate="blogtitle">*</asp:RequiredFieldValidator> </div><br/>
                            <div style="font-weight:bold">Last opp bilde <b style="font-weight:normal"></b></div>
                             <div align="left">
                                 <asp:FileUpload ID="loadPic" runat="server" />	
                                 <asp:Button ID="loadBtn" runat="server" Text="Laste opp" 
                                     onclick="loadBtn_Click" />			                    
                            </div><br/>
                            <asp:Literal ID="UploadStatusLabel" runat="server" Text=""></asp:Literal>
                            <div style="font-weight:bold"><asp:Literal runat="server" ID="meaningLi" /><b style="font-weight:normal"> 
                                <asp:RadioButtonList ID="meaningRad" runat="server" Enabled="False" 
                                    Visible="False" onselectedindexchanged="meaningRad_SelectedIndexChanged">
                                    <asp:ListItem>Jeg er enig</asp:ListItem>
                                    <asp:ListItem>Jeg er uenig</asp:ListItem>
                                </asp:RadioButtonList>
                            </b>				                    
                            </div>
                            <div style="font-weight:bold">Skrive blogg</div>
                             <div align="left">
                             <asp:Panel runat="server" ID="bigPanel" BorderStyle="solid" BorderColor="blue" BorderWidth="1px" Width="500px">	
                             <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1" 
                            UpdateMode="Conditional">
                            <ContentTemplate>    
                                <asp:PlaceHolder runat="server" ID="PlaceHolder1"
                                    EnableViewState="false" >
                                <Input id="inpHide" type="hidden" runat="server" />
                                <textarea id="blogtext" runat="server" cols="80" rows="10" style="overflow:hidden; border:none 0px blue;" >
                                </textarea>
                            </asp:PlaceHolder>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="venstercategory1" 
                                     />
                            </Triggers>
                        </asp:UpdatePanel>
                        </asp:Panel>
                            </div><br/>                             	
                                 <asp:Button ID="Button1" runat="server" BackColor="#6699ff"
                                Text="Sende" onclick="Button1_Click" /> 
                            </div>
    	                </td>
    	            </tr>
    	        </table>
            </td>
        </tr>
    </table>
<script language="javascript" type="text/javascript">  
function getText(){
    var text = document.getElementsByTagName("textarea").value;
    document.myForm.inpHide.value = text;
}

function assignText(){
    var text = document.myForm.inpHide.value;
    document.getElementsByTagName("textarea").value = text;
}

</script>