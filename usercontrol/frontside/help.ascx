<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="help.ascx.cs" Inherits="usercontrol_frontside_help" %>
<table style="font-size:small; padding-left:20px; padding-top:20px;">
    <tr>
        <td style="color:#0033cc;">
        
              <p style="color:#cc0099; font-weight:bold;">Ofte stilte spørsmål</p>
              &nbsp;&nbsp;<p style="font-size:x-small;">
                  <asp:LinkButton id="questionsBtn" runat="server" 
                        onclick="questionsBtn_Click">Er medlemskap gratis?</asp:LinkButton><br/>
                  <asp:Panel ID="Panel1" runat="server" Width="650px">
                      <asp:Literal ID="membershipcostLi" runat="server"></asp:Literal>
                  </asp:Panel>
                  <br/></p>
                  
                    <p>
                        <asp:LinkButton id="orderBtn" runat="server"
                        onclick="orderBtn_Click">Hvordan kjøper jeg abonnement?</asp:LinkButton><br/>
                  <asp:Panel ID="Panel2" runat="server" Width="650px">
                      <asp:Literal ID="orderLi" runat="server"></asp:Literal>
                  </asp:Panel>
                  <br/></p>
                    <p>
                        <asp:LinkButton id="twoaccountBtn" runat="server" 
                        onclick="twoaccountBtn_Click">Kan jeg ha to konto?</asp:LinkButton><br/>
                  <asp:Panel ID="Panel3" runat="server" Width="650px">
                      <asp:Literal ID="twoaccountLi" runat="server"></asp:Literal>
                  </asp:Panel>
                  <br/></p>
                  
                  <p>
                        <asp:LinkButton id="supportBtn" runat="server" 
                        onclick="supportBtn_Click">Hvordan kan jeg få hjelp hvis jeg har problem til å bruke funksjonene på websiden?</asp:LinkButton><br/>
                  <asp:Panel ID="Panel5" runat="server" Width="650px">
                      <asp:Literal ID="supportLi" runat="server"></asp:Literal>
                  </asp:Panel>
                  <br/></p>
                  
                    <p>
                        <asp:LinkButton id="cancelmembershipBtn" runat="server" 
                        onclick="cancelmembershipBtn_Click">Kan jeg avslutte medlemskap?</asp:LinkButton><br/>
                  <asp:Panel ID="Panel4" runat="server" Width="650px">
                      <asp:Literal ID="cancelmembershipLi" runat="server"></asp:Literal>
                  </asp:Panel>
                  <br/></p>
        </td>
    </tr>
</table>