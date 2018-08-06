<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vestagder.ascx.cs" Inherits="usercontrol_location_vestagder" %>

<asp:DropDownList ID="askerList" runat="server" 
    onselectedindexchanged="askerList_SelectedIndexChanged">
    <asp:ListItem value=""  />
      <asp:ListItem value="Audnedal" />
            <asp:ListItem value="Farsund" />
            <asp:ListItem value="Flekkefjord" />
            <asp:ListItem value="Hægebostad" />
            <asp:ListItem value="Kristiansand" />
            <asp:ListItem value="Kvinesdal" />
            <asp:ListItem value="Lindesnes" />
            <asp:ListItem value="Lyngdal" />
            <asp:ListItem value="Mandal" />
            <asp:ListItem value="Marnardal" />
            <asp:ListItem value="Sirdal" />
            <asp:ListItem value="Songdalen" />
            <asp:ListItem value="Søgne" />
            <asp:ListItem value="Vennesla" />
            <asp:ListItem value="Åseral" />
</asp:DropDownList>
