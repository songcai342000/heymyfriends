<%@ Control Language="C#" AutoEventWireup="true" CodeFile="annet.ascx.cs" Inherits="usercontrol_location_annet" %>

<asp:DropDownList ID="askerList" runat="server" 
    onselectedindexchanged="askerList_SelectedIndexChanged" >
    <asp:ListItem value=""  />
    <asp:ListItem value="Annet" />
</asp:DropDownList>
