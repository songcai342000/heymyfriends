<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="administration.ascx.cs" Inherits="usercontrol_minside_administration" %>
<%@ OutputCache Duration="90" VaryByParam="None" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
<table id="Table1" align="center" width="720px">
    <tr>
        <td style="color:#0033cc; font-weight:bold">        
            Check new profiles: </td>
    </tr>
    <tr>
        <td>
            <asp:ListBox ID="newprofiles" runat="server" 
                ></asp:ListBox>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
&nbsp;<asp:Literal ID="Literal2" runat="server"></asp:Literal>
        </td>
    </tr>
     <tr>
        <td>
            <asp:Button ID="evaluateprofile" runat="server" Text="Check profile" 
                onclick="evaluateprofile_Click" />
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center" width="720px">
    <tr>
        <td style="color:#0033cc; font-weight:bold">        
            Legg til utvalgte blogg 1: </td>
    </tr>
    <tr>
        <td>
            Tast inn fil ruten: 
            <asp:FileUpLoad ID="choseFile" runat="server"></asp:FileUpLoad>
&nbsp;<asp:Button ID="choseBtn" runat="server" Text="Confirm" onclick="choseBtn_Click"/>
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center" width="720px">
    <tr>
        <td style="color:#0033cc; font-weight:bold">        
            Legg til utvalgte blogg 2: </td>
    </tr>
    <tr>
        <td>
            Tast inn fil ruten: 
            <asp:FileUpLoad ID="choseBlog2" runat="server"></asp:FileUpLoad>
&nbsp;<asp:Button ID="chosenblog2Btn" runat="server" Text="Confirm" onclick="chosenblog2Btn_Click"/>
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center">
    <tr>
        <td style="color:#0033cc; font-weight:bold">
            Legg til tema blogg: </td>
    </tr>
    <tr>
        <td>
            Tast inn fil ruten:
            <asp:FileUpLoad ID="topicFile" runat="server"></asp:FileUpLoad>
&nbsp;<asp:Button ID="topicBtn" runat="server" Text="Confirm" onclick="topicBtn_Click"/>
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center" width="720px">
    <tr>
        <td style="color:#0033cc; font-weight:bold">        
            Legg til tema: </td>
    </tr>
    <tr>
        <td>
            Tast inn tema: 
            <asp:TextBox ID="temaTxt" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="temaBtn" runat="server" Text="Confirm" onclick="temaBtn_Click"/>
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center">
    <tr>
        <td style="color:#0033cc; font-weight:bold">
            Legg til url til blogg 1: </td>
    </tr>
    <tr>
        <td>
            Tast inn url:
            <asp:TextBox ID="blog1Txt" runat="server"></asp:TextBox>
&nbsp;Taste inn title: <asp:TextBox ID="blog1titleTxt" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="blog1Btn" runat="server" Text="Legge til" onclick="blog1Btn_Click"/>
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center">
    <tr>
        <td style="color:#0033cc; font-weight:bold">
            Legg til anbefalte blogg 2: </td>
    </tr>
    <tr>
        <td>
            Tast inn url:
            <asp:TextBox ID="blog2Txt" runat="server"></asp:TextBox>
&nbsp;Taste inn title: <asp:TextBox ID="blog2titleTxt" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="blog2Btn" runat="server" Text="Confirm" onclick="blog2Btn_Click"/>
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center">
    <tr>
        <td style="color:#0033cc; font-weight:bold">
            Legg til anbefalte blogg 3: </td>
    </tr>
    <tr>
        <td>
            Tast inn url: 
            <asp:TextBox ID="blog3Txt" runat="server"></asp:TextBox>
&nbsp;Taste inn title: <asp:TextBox ID="blog3titleTxt" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="blog3Btn" runat="server" Text="Confirm" onclick="blog3Btn_Click"/>
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center">
    <tr>
        <td style="color:#0033cc; font-weight:bold">
            Forny fresk blogg list: </td>
    </tr>
    <tr>
        <td>
            Tast inn tidligste dato du vil ha med på blogglisten (format: dd.mm.åååå): 
            <asp:TextBox ID="renewTxt" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="renewBtn" runat="server" Text="Confirm" onclick="renewBtn_Click" 
                Height="25px"/>
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center">
    <tr>
        <td style="color:#0033cc; font-weight:bold">
            Slette blogger som er 30 dager gammel: </td>
    </tr>
    <tr>
        <td>
&nbsp;<asp:Button ID="remove30daysOldBtn" runat="server" Text="Confirm" onclick="remove30daysOldBtn_Click"/>
        </td>
    </tr>
</table><br/>

<table id="righttables" align="center">
    <tr>
        <td style="color:#0033cc; font-weight:bold">
            Forny popular blogg list: </td>
    </tr>
    <tr>
        <td align="center">
&nbsp;<asp:Button ID="renewpopularBtn" runat="server" Text="Confirm" onclick="renewpopularBtn_Click"/>
        </td>
    </tr>
</table>

<br/>
<table id="righttables" align="center">
    <tr>
        <td style="color:#0033cc; font-weight:bold">
            write comment: </td>
    </tr>
    <tr>
        <td>
            <Textarea ID="commentTxt" runat="server" 
                cols="50" rows="10"></Textarea><br/>
&nbsp;<asp:Button ID="commentBtn" runat="server" Text="Confirm" onclick="commentBtn_Click"/>
        </td>
    </tr>
</table>





