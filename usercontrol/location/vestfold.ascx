<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vestfold.ascx.cs" Inherits="usercontrol_location_vestfold" %>

<asp:DropDownList ID="askerList" runat="server" 
    onselectedindexchanged="askerList_SelectedIndexChanged">
    <asp:ListItem value=""  />
        <asp:ListItem value="Andebu" />
            <asp:ListItem value="Hof" />
            <asp:ListItem value="Holmestrand" />
            <asp:ListItem value="Horten" />
            <asp:ListItem value="Lardal" />
            <asp:ListItem value="Larvik" />
            <asp:ListItem value="Nøtterøy" />
            <asp:ListItem value="Re" />
            <asp:ListItem value="Sande" />
            <asp:ListItem value="Sandefjord" />
            <asp:ListItem value="Stokke" />
            <asp:ListItem value="Svelvik" />
            <asp:ListItem value="Tjøme" />
            <asp:ListItem value="Tønsberg" />
</asp:DropDownList>
