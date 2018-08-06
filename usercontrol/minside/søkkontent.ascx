<%@ Control Language="C#" AutoEventWireup="true" CodeFile="søkkontent.ascx.cs" Inherits="usercontrol_søkkontent" %>
<%@ OutputCache Duration="180" VaryByParam="None" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />
<table id="righttables0" >
			<tr id="headtr"><td style="width:50%;padding-left:20px">
			        &nbsp;Avanserte søk</td><td style="width:50%;padding-left:20px">Meldem søk </td></tr>
		    </table><table id="righttables" height="400px"><tr>
		    <td style="width:48%;border-right:solid 1px #e1e1e1;">
            Jeg søker<br />
				<asp:DropDownList ID="gender" style="width:220px; height:18px;" runat="server">
                    <asp:ListItem Value="Kvinne">Kvinne</asp:ListItem>
                    <asp:ListItem Value="Man">Man</asp:ListItem>
                    <asp:ListItem Value="Par">Par</asp:ListItem>
				</asp:DropDownList><br /><br />Mellom
				<asp:dropdownlist runat="server" id="min">
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="26">26</asp:ListItem>
                        <asp:ListItem Value="27">27</asp:ListItem>
                        <asp:ListItem Value="28">28</asp:ListItem>
                        <asp:ListItem Value="29">29</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                       
                        <asp:ListItem Value="31">31</asp:ListItem>
                        <asp:ListItem Value="32">32</asp:ListItem>
                        <asp:ListItem Value="33">33</asp:ListItem>
                        <asp:ListItem Value="34">34</asp:ListItem>
                        <asp:ListItem Value="35">35</asp:ListItem>
                        <asp:ListItem Value="36">36</asp:ListItem>
                        <asp:ListItem Value="37">37</asp:ListItem>
                        <asp:ListItem Value="38">38</asp:ListItem>
                        <asp:ListItem Value="39">39</asp:ListItem>
                        <asp:ListItem Value="40">40</asp:ListItem>

                        <asp:ListItem Value="41">41</asp:ListItem>
                        <asp:ListItem Value="42">42</asp:ListItem>
                        <asp:ListItem Value="43">43</asp:ListItem>
                        <asp:ListItem Value="44">44</asp:ListItem>
                        <asp:ListItem Value="45">45</asp:ListItem>
                        <asp:ListItem Value="46">46</asp:ListItem>
                        <asp:ListItem Value="47">47</asp:ListItem>
                        <asp:ListItem Value="48">48</asp:ListItem>
                        <asp:ListItem Value="49">49</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        
                        <asp:ListItem Value="51">51</asp:ListItem>
                        <asp:ListItem Value="52">52</asp:ListItem>
                        <asp:ListItem Value="53">53</asp:ListItem>
                        <asp:ListItem Value="54">54</asp:ListItem>
                        <asp:ListItem Value="55">55</asp:ListItem>
                        <asp:ListItem Value="56">56</asp:ListItem>
                        <asp:ListItem Value="57">57</asp:ListItem>
                        <asp:ListItem Value="58">58</asp:ListItem>
                        <asp:ListItem Value="59">59</asp:ListItem>
                        <asp:ListItem Value="60">60</asp:ListItem>
                        
                        <asp:ListItem Value="61">61</asp:ListItem>
                        <asp:ListItem Value="62">62</asp:ListItem>
                        <asp:ListItem Value="63">63</asp:ListItem>
                        <asp:ListItem Value="64">64</asp:ListItem>
                        <asp:ListItem Value="65">65</asp:ListItem>
                        <asp:ListItem Value="66">66</asp:ListItem>
                        <asp:ListItem Value="67">67</asp:ListItem>
                        <asp:ListItem Value="68">68</asp:ListItem>
                        <asp:ListItem Value="69">69</asp:ListItem>
                        <asp:ListItem Value="70">70</asp:ListItem>
                       
                        <asp:ListItem Value="71">71</asp:ListItem>
                        <asp:ListItem Value="72">72</asp:ListItem>
                        <asp:ListItem Value="73">73</asp:ListItem>
                        <asp:ListItem Value="74">74</asp:ListItem>
                        <asp:ListItem Value="75">75</asp:ListItem>
                        <asp:ListItem Value="76">76</asp:ListItem>
                        <asp:ListItem Value="77">77</asp:ListItem>
                        <asp:ListItem Value="78">78</asp:ListItem>
                        <asp:ListItem Value="79">79</asp:ListItem>
                        <asp:ListItem Value="80">80</asp:ListItem>

                        <asp:ListItem Value="81">81</asp:ListItem>
                        <asp:ListItem Value="82">82</asp:ListItem>
                        <asp:ListItem Value="83">83</asp:ListItem>
                        <asp:ListItem Value="84">84</asp:ListItem>
                        <asp:ListItem Value="85">85</asp:ListItem>
                        <asp:ListItem Value="86">86</asp:ListItem>
                        <asp:ListItem Value="87">87</asp:ListItem>
                        <asp:ListItem Value="88">88</asp:ListItem>
                        <asp:ListItem Value="89">89</asp:ListItem>
                        <asp:ListItem Value="90">90</asp:ListItem>
                       
                        <asp:ListItem Value="91">91</asp:ListItem>
                        <asp:ListItem Value="92">92</asp:ListItem>
                        <asp:ListItem Value="93">93</asp:ListItem>
                        <asp:ListItem Value="94">94</asp:ListItem>
                        <asp:ListItem Value="95">95</asp:ListItem>
                        <asp:ListItem Value="96">96</asp:ListItem>
                        <asp:ListItem Value="97">97</asp:ListItem>
                        <asp:ListItem Value="98">98</asp:ListItem>
                        <asp:ListItem Value="99">99</asp:ListItem>          
                    </asp:dropdownlist>&nbsp; og &nbsp;
	               <asp:dropdownlist runat="server" id="maks">
                       <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="26">26</asp:ListItem>
                        <asp:ListItem Value="27">27</asp:ListItem>
                        <asp:ListItem Value="28">28</asp:ListItem>
                        <asp:ListItem Value="29">29</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                       
                        <asp:ListItem Value="31">31</asp:ListItem>
                        <asp:ListItem Value="32">32</asp:ListItem>
                        <asp:ListItem Value="33">33</asp:ListItem>
                        <asp:ListItem Value="34">34</asp:ListItem>
                        <asp:ListItem Value="35">35</asp:ListItem>
                        <asp:ListItem Value="36">36</asp:ListItem>
                        <asp:ListItem Value="37">37</asp:ListItem>
                        <asp:ListItem Value="38">38</asp:ListItem>
                        <asp:ListItem Value="39">39</asp:ListItem>
                        <asp:ListItem Value="40">40</asp:ListItem>

                        <asp:ListItem Value="41">41</asp:ListItem>
                        <asp:ListItem Value="42">42</asp:ListItem>
                        <asp:ListItem Value="43">43</asp:ListItem>
                        <asp:ListItem Value="44">44</asp:ListItem>
                        <asp:ListItem Value="45">45</asp:ListItem>
                        <asp:ListItem Value="46">46</asp:ListItem>
                        <asp:ListItem Value="47">47</asp:ListItem>
                        <asp:ListItem Value="48">48</asp:ListItem>
                        <asp:ListItem Value="49">49</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        
                        <asp:ListItem Value="51">51</asp:ListItem>
                        <asp:ListItem Value="52">52</asp:ListItem>
                        <asp:ListItem Value="53">53</asp:ListItem>
                        <asp:ListItem Value="54">54</asp:ListItem>
                        <asp:ListItem Value="55">55</asp:ListItem>
                        <asp:ListItem Value="56">56</asp:ListItem>
                        <asp:ListItem Value="57">57</asp:ListItem>
                        <asp:ListItem Value="58">58</asp:ListItem>
                        <asp:ListItem Value="59">59</asp:ListItem>
                        <asp:ListItem Value="60">60</asp:ListItem>
                        
                        <asp:ListItem Value="61">61</asp:ListItem>
                        <asp:ListItem Value="62">62</asp:ListItem>
                        <asp:ListItem Value="63">63</asp:ListItem>
                        <asp:ListItem Value="64">64</asp:ListItem>
                        <asp:ListItem Value="65">65</asp:ListItem>
                        <asp:ListItem Value="66">66</asp:ListItem>
                        <asp:ListItem Value="67">67</asp:ListItem>
                        <asp:ListItem Value="68">68</asp:ListItem>
                        <asp:ListItem Value="69">69</asp:ListItem>
                        <asp:ListItem Value="70">70</asp:ListItem>
                       
                        <asp:ListItem Value="71">71</asp:ListItem>
                        <asp:ListItem Value="72">72</asp:ListItem>
                        <asp:ListItem Value="73">73</asp:ListItem>
                        <asp:ListItem Value="74">74</asp:ListItem>
                        <asp:ListItem Value="75">75</asp:ListItem>
                        <asp:ListItem Value="76">76</asp:ListItem>
                        <asp:ListItem Value="77">77</asp:ListItem>
                        <asp:ListItem Value="78">78</asp:ListItem>
                        <asp:ListItem Value="79">79</asp:ListItem>
                        <asp:ListItem Value="80">80</asp:ListItem>

                        <asp:ListItem Value="81">81</asp:ListItem>
                        <asp:ListItem Value="82">82</asp:ListItem>
                        <asp:ListItem Value="83">83</asp:ListItem>
                        <asp:ListItem Value="84">84</asp:ListItem>
                        <asp:ListItem Value="85">85</asp:ListItem>
                        <asp:ListItem Value="86">86</asp:ListItem>
                        <asp:ListItem Value="87">87</asp:ListItem>
                        <asp:ListItem Value="88">88</asp:ListItem>
                        <asp:ListItem Value="89">89</asp:ListItem>
                        <asp:ListItem Value="90">90</asp:ListItem>
                       
                        <asp:ListItem Value="91">91</asp:ListItem>
                        <asp:ListItem Value="92">92</asp:ListItem>
                        <asp:ListItem Value="93">93</asp:ListItem>
                        <asp:ListItem Value="94">94</asp:ListItem>
                        <asp:ListItem Value="95">95</asp:ListItem>
                        <asp:ListItem Value="96">96</asp:ListItem>
                        <asp:ListItem Value="97">97</asp:ListItem>
                        <asp:ListItem Value="98">98</asp:ListItem>
                        <asp:ListItem Value="99">99</asp:ListItem>          
                    </asp:dropdownlist>		
				</td><td valign="top" width="51%" style="padding-left:20px">
                             Brukernavn:<br /><asp:TextBox ID="memberTxt" runat="server"></asp:TextBox>
                       <br/>
                             <asp:CheckBox ID="CheckBox6" runat="server" />&nbsp;Matche eksakt</td>
                      
			</tr>				
			<tr>
	            <td style="width:48%;border-right:solid 1px #e1e1e1;">		
                    &nbsp;
	                
                 </td><td></td></tr>
			<tr>
			<td style="width:48%;border-right:solid 1px #e1e1e1;">
			    Fylke:<br />
									
                    <asp:DropDownList runat="server" ID="fylke">
			            <asp:ListItem value="">Velg fylke...</asp:ListItem>
			            <asp:ListItem value="Akershus">Akershus  </asp:ListItem>
			            <asp:ListItem value="Aust-Agder">Aust-Agder  </asp:ListItem>
			            <asp:ListItem value="Buskerud">Buskerud  </asp:ListItem>
			            <asp:ListItem value="Finnmark">Finnmark  </asp:ListItem>
			            <asp:ListItem value="Hedmark">Hedmark  </asp:ListItem>
			            <asp:ListItem value="Hordaland">Hordaland  </asp:ListItem>
			            <asp:ListItem value="Møre og Romsdal">Møre og Romsdal  </asp:ListItem>
			            <asp:ListItem value="Nordland">Nordland  </asp:ListItem>
			            <asp:ListItem value="Nord-Trøndelag">Nord-Trøndelag  </asp:ListItem>
			            <asp:ListItem value="Oppland">Oppland  </asp:ListItem>
			            <asp:ListItem value="Oslo">Oslo  </asp:ListItem>
			            <asp:ListItem value="Rogaland">Rogaland  </asp:ListItem>
			            <asp:ListItem value="Sogn og Fjordane">Sogn og Fjordane  </asp:ListItem>
			            <asp:ListItem value="Sør-Trøndelag">Sør-Trøndelag  </asp:ListItem>
			            <asp:ListItem value="Telemark">Telemark  </asp:ListItem>
			            <asp:ListItem value="Troms">Troms  </asp:ListItem>
			            <asp:ListItem value="Vest-Agder">Vest-Agder  </asp:ListItem>
			            <asp:ListItem value="Vestfold">Vestfold  </asp:ListItem>
			            <asp:ListItem value="Østfold">Østfold  </asp:ListItem>
		            </asp:DropDownList><br />
			</td><td style="padding-left:20px">
				        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                    Text="Søk" />
                </td>
			</tr><tr><td style="border-right: 1px solid #e1e1e1; width:48%"></td><td></td></tr>
			<tr>
				<td 
                    style="border-right: 1px solid #e1e1e1; width:48%">
				<table style="width:100%; padding: 0px 0px 0px 0px">
				    <tr><td style="vertical-align:middle;"><asp:CheckBox ID="CheckBox2" runat="server" />
                        Vis alle profiler</td></tr>
                    <tr><td style="vertical-align:middle;"></td></tr>  
                    <tr><td style="vertical-align:middle;">Vis bare profiler med: </td></tr>   
				    <tr><td style="vertical-align:middle"><asp:CheckBox ID="CheckBox3" runat="server" />
                        Profilbilde</td></tr>
				    <tr><td style="vertical-align:middle"><asp:CheckBox ID="CheckBox4" runat="server" />
                        Fotoalbum</td></tr>
				    <tr><td style="vertical-align:middle"><asp:CheckBox ID="CheckBox5" runat="server" />
                        Blogg</td></tr>
                    <tr><td style="vertical-align:middle">
                        </td></tr>
				    <tr>
				    <td style="vertical-align:middle">
                        Nye meldemer:</td></tr>
                    <tr><td style="vertical-align:middle;" colspan="2">
                    </td></tr>
                    <tr>
				    <td style="padding-top:3px;padding-left:2px;">
				        <asp:DropDownList runat="server" ID="nymeldem">
				            <asp:ListItem value=""></asp:ListItem>
					        <asp:ListItem value="I dag">I dag</asp:ListItem>
					        <asp:ListItem value="De siste tre dagene">De siste tre dagene</asp:ListItem>
					        <asp:ListItem value="Den seneste uken">Den seneste uken</asp:ListItem>
					        <asp:ListItem value="Den seneste måneden">Den seneste måneden</asp:ListItem>
				        </asp:DropDownList>
				    </td>
				    </tr>
				    <tr><td></td></tr>
				    <tr>
				    <td style="padding-left:2px;vertical-align:middle;">
				        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Søk" />
                        </td></tr><tr><td></td><td>&nbsp;</td></tr>
			    </table>
				</td><td style="padding-left:20px"></td>
			</tr></table>