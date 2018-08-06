<%@ Control Language="C#" AutoEventWireup="true" CodeFile="finnmark.ascx.cs" Inherits="usercontrol_location_finnmark" %>

<asp:DropDownList ID="askerList" runat="server" 
    onselectedindexchanged="askerList_SelectedIndexChanged">
    <asp:ListItem value=""  />
            <asp:ListItem value="Alta" />
            <asp:ListItem value="Berlevåg" />
            <asp:ListItem value="Båtsfjord" />
            <asp:ListItem value="Gamvik" />
            <asp:ListItem value="Hammerfest " />
            <asp:ListItem value="Hasvik" />
            <asp:ListItem value="Karasjok" />
            <asp:ListItem value="Kautokeino" />
            <asp:ListItem value="Kvalsund" />
            <asp:ListItem value="Lebesby" />
            <asp:ListItem value="Loppa" />
            <asp:ListItem value="Måsøy" />
            <asp:ListItem value="Nesseby" />
            <asp:ListItem value="Nordkapp" />
            <asp:ListItem value="Porsanger" />
            <asp:ListItem value="Sør-Varanger" />
            <asp:ListItem value="Tana" />
            <asp:ListItem value="Vadsø" />
            <asp:ListItem value="Vardø" />
</asp:DropDownList>
