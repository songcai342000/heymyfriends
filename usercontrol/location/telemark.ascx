<%@ Control Language="C#" AutoEventWireup="true" CodeFile="telemark.ascx.cs" Inherits="usercontrol_location_telemark" %>

<asp:DropDownList ID="telemarkList" runat="server" 
    onselectedindexchanged="telemarkList_SelectedIndexChanged">
    <asp:ListItem value="" />
       <asp:ListItem value="Bamble" />
            <asp:ListItem value="Bø" />
            <asp:ListItem value="Drangedal" />
            <asp:ListItem value="Fyresdal" />
            <asp:ListItem value="Hjartdal" />
            <asp:ListItem value="Kragerø" />
            <asp:ListItem value="Kviteseid" />
            <asp:ListItem value="Nissedal" />
            <asp:ListItem value="Nome" />
            <asp:ListItem value="Notodden" />
            <asp:ListItem value="Porsgrunn" />
            <asp:ListItem value="Sauherad" />
            <asp:ListItem value=">Seljord" />
            <asp:ListItem value="Siljan" />
            <asp:ListItem value="Skien" />
            <asp:ListItem value="Tinn" />
            <asp:ListItem value="Tokke" />
            <asp:ListItem value="Vinje" />      
</asp:DropDownList>
