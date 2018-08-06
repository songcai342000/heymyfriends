<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="minsidecontent.ascx.cs" Inherits="usercontrol_minsidecontent" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />

			<table id="minsidesorttable">
			<tr>
                    <td style="vertical-align:middle;">
                        <asp:Literal ID="creditLi" runat="server" ></asp:Literal> 
                    </td>
                    
                    <td style="vertical-align:middle;">  
                        Mine blomster/kupper: 
                        <asp:Literal ID="flowerLi" runat="server" ></asp:Literal>                   
                    </td>
                    
                     <td style="vertical-align:middle">
                        Mine nøkler: 
                        <asp:Literal ID="keyLi" runat="server" ></asp:Literal> 
                    </td>
                    
                </tr>
                <tr>
                    <td style="vertical-align:middle;">
                        <asp:Image runat="server" ID="winepar" ImageUrl="~/images/winepar.jpg" style="width:130px; height:100px" />
                    </td>
                    <td style="vertical-align:middle;">  
                        Mottatt meldninger: 
                        <asp:Literal ID="receivedmessageLi" runat="server" ></asp:Literal>               
                    </td>
                    
                     <td style="vertical-align:middle">
                        Sendt meldninger: 
                        <asp:Literal ID="sentmessageLi" runat="server"></asp:Literal> 
                    </td>
                    
                </tr>
                
                 <tr>
                    <td style="vertical-align:middle;">
                        Gjenstårende meldskap: 
                        <asp:Literal ID="membershipLi" runat="server" ></asp:Literal><br/>
                    </td>
                    
                    <td style="vertical-align:middle;">  
                        Blogger: 
                        <asp:Literal ID="blogLi" runat="server" ></asp:Literal><br/>                  
                    </td>
                    
                     <td style="vertical-align:middle">
                        Venner: 
                        <asp:Literal ID="friendLi" runat="server" ></asp:Literal><br/> 
                    </td>
                    
                </tr>
                
                 <tr>
                    <td style="vertical-align:middle;">
                        Mine favoritt: 
                        <asp:Literal ID="myfavoriteLi" runat="server" ></asp:Literal> 
                    </td>
                    
                    <td style="vertical-align:middle;">  
                        Meg som favoritt: 
                        <asp:Literal ID="iamfavoriteLi" runat="server" ></asp:Literal>                   
                    </td>
                    
                     <td style="vertical-align:middle">
                        Mine besøkere: 
                        <asp:Literal ID="myvisitorLi" runat="server" ></asp:Literal> 
                    </td>
                    
                </tr>
            </table><br/>

   <table id="minsidesorttable"><tr><td valign="top">
                 <div><b><asp:Literal runat="server" ID="Literal1" /> på din søkelist</b></div><br/>
                            <asp:repeater id="yoursearchlist"       
                                runat="server" onitemcommand="yoursearchlist_ItemCommand">
                                <headertemplate>
                                  <table>
                                    <tr>
                                    <td></td>
                                     <td></td>
                                    <td></td>
                                    </tr>
                                </headertemplate>
                                <itemtemplate>
                                  <tr >
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="yoursearchNameBtn" CommandName="yoursearchName" Text='<%# Eval("yoursearchName")%>'><%# Eval("yoursearchName")%></asp:LinkButton></td>
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="yoursearchAgeBtn" CommandName="yoursearchAge" Text='<%# Eval("yoursearchAge")%>'><%# Eval("yoursearchAge")%></asp:LinkButton></td>
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="yoursearchCityBtn" CommandName="yoursearchCity" Text='<%# Eval("yoursearchCity")%>'><%# Eval("yoursearchCity")%></asp:LinkButton></td>                                    
                                  </tr>
                                </itemtemplate>
                                <footertemplate>
                                  </table>
                                </footertemplate>
                            </asp:repeater>
                </td><td align="center"><br />
           <asp:Image ID="Image1" runat="server" height="300px" Width="222px" ImageUrl="~/images/manrose.jpg"/>
           <br />
         </td></tr>
                            <tr>
		            <td>
		                <a href="/vennskap/functions/Profilepage.aspx?searchprofile={0}"><b>flere på søkelisten&nbsp;»</b></a>
		            </td>
		            <td>
		            </td>
		            <td>
		            </td>
		        </tr></table><br/>
	
				<table id="minsidesorttable"">
				  <tr>
				  <td>  	
				
	
				    <b>Nye menn</b><br/>
                        <asp:repeater id="newmenlist"       
                                runat="server" onitemcommand="newmenlist_ItemCommand" >
                                <headertemplate>
                                  <table>
                                    <tr>
                                    <td></td>
                                     <td></td>
                                    <td></td>
                                    </tr>
                                </headertemplate>
                                <itemtemplate>
                                  <tr >
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newmenNameBtn" CommandName="newmenName" Text='<%# Eval("newmenName")%>'><%# Eval("newmenName")%></asp:LinkButton></td>
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newmenAgeBtn" CommandName="newmenAge" Text='<%# Eval("newmenAge")%>'><%# Eval("newmenAge")%></asp:LinkButton></td>
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newmenCityBtn" CommandName="newmenCity" Text='<%# Eval("newmenCity")%>'><%# Eval("newmenCity")%></asp:LinkButton></td>                                    
                                  </tr>
                                </itemtemplate>
                                <footertemplate>
                                  </table>
                                </footertemplate>
                            </asp:repeater>
		                </td>
		                <td>
		            <b>Nye kvinner</b><br/>
                            <asp:repeater id="newwomenlist"       
                                runat="server" onitemcommand="newwomenlist_ItemCommand" >
                                <headertemplate>
                                  <table>
                                    <tr>
                                    <td></td>
                                     <td></td>
                                    <td></td>
                                    </tr>
                                </headertemplate>
                                <itemtemplate>
                                  <tr >
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newwomenNameBtn" CommandName="newwomenName" Text='<%# Eval("newwomenName")%>'><%# Eval("newwomenName")%></asp:LinkButton></td>
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newwomenAgeBtn" CommandName="newwomenAge" Text='<%# Eval("newwomenAge")%>'><%# Eval("newwomenAge")%></asp:LinkButton></td>
                                    <td  style="width:150px;padding-left:3px;padding-right:5px;"><asp:LinkButton runat="server" ID="newwomenCityBtn" CommandName="newwomenCity" Text='<%# Eval("newwomenCity")%>'><%# Eval("newwomenCity")%></asp:LinkButton></td>                                    
                                  </tr>
                                </itemtemplate>
                                <footertemplate>
                                  </table>
                                </footertemplate>
                            </asp:repeater>
		        </td>
		        </tr>
		        <tr>
		            <td>
		                <a href="/vennskap/functions/Profilepage.aspx?boyprofile={0}"><b>flere nye menn&nbsp;»</b></a>
		            </td>
		            <td>
		                <a href="/vennskap/functions/Profilepage.aspx?girlprofile={0}"><b>flere nye kvinner&nbsp;»</b></a>
		            </td>
		            <td></td>
		        </tr>
		 
     	    </table>
			
