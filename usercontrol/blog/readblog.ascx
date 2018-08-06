<%@ Control Language="C#" AutoEventWireup="true" CodeFile="readblog.ascx.cs" Inherits="usercontrol_blog_readblog" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
   
    <table class="righttablenonborder" style="width:940px; padding-left:0px; background-color:#ffddff;" align="center"><tr valign="top"><td>
        <div style="width:590px; font-weight:bold; padding-left:350px;height:40px;padding-top:15px;"><asp:Literal runat="server" ID="blogtitleLi" /></div>
        <div style="width:600px; padding-left:180px;">Blogger: <asp:Literal ID="usernameLi" runat="server"></asp:Literal></div>
          <table class="righttables" runat="server" id="readblogtable" style="border-style: inset none outset none; width:580px; padding-top:10px; background-color:#ffddff;" align="center" ><tr>
              <td id="contentcol" style="padding-top:10px; width:420px;" valign="top">
 
                    <b style="color:#0033cc; font-weight:normal;"><asp:Literal runat="server" id="chosenblogcontent" /></b>
                </td>
                <td style="padding:10px 20px 20px 20px; width:130px;">
                <asp:Button ID="writetomeBtn" runat="server" Text="Skriv til meg"
                    onclick="writetomeBtn_Click"></asp:Button><br /><br />
                <asp:Button ID="readprofileBtn" runat="server" Text="Les min profil" 
                    onclick="readprofileBtn_Click"></asp:Button><br /><br />  
                <asp:Button ID="favoriteblogBtn" runat="server" Text="Legg bloggen i favoritt" 
                    onclick="favoriteblogBtn_Click"></asp:Button><br />
                </td></tr></table><br/>
                <div style="width:590px; font-weight:bold; padding-left:350px;height:40px;padding-top:15px;"><a id="moreblogstop" runat="server" style="color:#0033CC">Mine andre blogg >></a></div>
    </td>
  </tr></table><br/>
  <table class="righttablenonborder" style="width:940px; padding-left:0px; padding-bottom:10px; background-color:#ffddff;" align="center">
   <tr >
    <td style="padding-left:175px;">
  <div style="width:600px;">
              <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
                        <asp:UpdatePanel runat="server" ID="updatepanel1" 
                            UpdateMode="Conditional">
                            <ContentTemplate>    
                                <asp:PlaceHolder runat="server" ID="commentPanel"
                                    EnableViewState="false" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="sendComment" 
                                     />
                            </Triggers>
                        </asp:UpdatePanel></div>
         
        <div runat="server" id="commentTitle" style="font-weight:bold; width:600px;background-color:#ffddff;">Skriv commentar</div>
        <div></div>
        <div style="width:450px;">
        <Textarea ID="txtComment" runat="server" rows="20" cols="50" BackColor="#f0f8ff" ></Textarea></div>
                <div style="height:30px"></div>
        <div style="width:450px;">
            <asp:Button ID="sendComment" runat="server" Text="Send" BackColor="#cc0099" 
                onclick="sendComment_Click" /></div>
                <div style="height:10px"></div>
    </td>
  </tr>
</table>
