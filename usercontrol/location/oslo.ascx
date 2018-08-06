<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oslo.ascx.cs" Inherits="usercontrol_location_oslo" %>

<asp:DropDownList ID="askerList" runat="server" 
    onselectedindexchanged="askerList_SelectedIndexChanged">
    <asp:ListItem value=""  />
      <asp:ListItem value="" />
        <asp:ListItem value="Nydalen" />
        <asp:ListItem value="Oslo" />
</asp:DropDownList>
