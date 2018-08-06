<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="oppretterprofil.ascx.cs" Inherits="usercontrol_oppretterprofil" %>
<%@ OutputCache Duration="90" VaryByParam="None" %>
<%@ Register src="../location/norwayFylke.ascx" tagname="norwayFylke" tagprefix="uc1" %>
<table id="righttables0" >
			<tr id="headtr">
 	    <td style="font-weight:bold" align="center">
				 Opprette/Redigere profil
			</td>
			</tr></table>
	<table class="righttables">
    <tr  align="left">
        <td style="width:50%">
        Land:<br />
			<asp:dropdownlist runat="server" style="width:200px" id="landlist">
	            <asp:ListItem  value=""></asp:ListItem>
	            <asp:ListItem  value = "Norge">Norge</asp:ListItem>
	            <asp:ListItem  value="Annet">Annet</asp:ListItem>
            </asp:dropdownlist>
        
			<br />
        </td>
        <td style="width:50%">
         Fylke:<br />
            
            <uc1:norwayFylke ID="norwayFylke1" runat="server" />
            
            <br />
           </td>
           
    </tr>
     <tr  align="left">
        <td style="width:50%">
            Fødelsedag:<br />
					<asp:dropdownlist runat="server" id="dob_day">

							<asp:ListItem  value="1">1</asp:ListItem>

							<asp:ListItem  value="2">2</asp:ListItem>

							<asp:ListItem  value="3">3</asp:ListItem>

							<asp:ListItem  value="4">4</asp:ListItem>

							<asp:ListItem  value="5">5</asp:ListItem>

							<asp:ListItem  value="6">6</asp:ListItem>

							<asp:ListItem  value="7">7</asp:ListItem>

							<asp:ListItem  value="8">8</asp:ListItem>

							<asp:ListItem  value="9">9</asp:ListItem>

							<asp:ListItem  value="10">10</asp:ListItem>

							<asp:ListItem  value="11">11</asp:ListItem>

							<asp:ListItem  value="12">12</asp:ListItem>

							<asp:ListItem  value="13">13</asp:ListItem>

							<asp:ListItem  value="14">14</asp:ListItem>

							<asp:ListItem  value="15">15</asp:ListItem>

							<asp:ListItem  value="16">16</asp:ListItem>

							<asp:ListItem  value="17">17</asp:ListItem>

							<asp:ListItem  value="18">18</asp:ListItem>

							<asp:ListItem  value="19">19</asp:ListItem>

							<asp:ListItem  value="20">20</asp:ListItem>

							<asp:ListItem  value="21">21</asp:ListItem>

							<asp:ListItem  value="22">22</asp:ListItem>

							<asp:ListItem  value="23">23</asp:ListItem>

							<asp:ListItem  value="24">24</asp:ListItem>

							<asp:ListItem  value="25">25</asp:ListItem>

							<asp:ListItem  value="26">26</asp:ListItem>

							<asp:ListItem  value="27">27</asp:ListItem>

							<asp:ListItem  value="28">28</asp:ListItem>

							<asp:ListItem  value="29">29</asp:ListItem>

							<asp:ListItem  value="30">30</asp:ListItem>

							<asp:ListItem  value="31">31</asp:ListItem>

						</asp:dropdownlist>	
					
						<asp:dropdownlist runat="server" id="monthlist">
							<asp:ListItem  value=""></asp:ListItem>
							<asp:ListItem  value="1">Januar</asp:ListItem>
							<asp:ListItem  value="2">Februar</asp:ListItem>
							<asp:ListItem  value="3">Mars</asp:ListItem>
							<asp:ListItem  value="4">April</asp:ListItem>		
							<asp:ListItem  value="5">Mai</asp:ListItem>
							<asp:ListItem  value="6">Juni</asp:ListItem>
							<asp:ListItem  value="7">Juli</asp:ListItem>
							<asp:ListItem  value="8">August</asp:ListItem>
							<asp:ListItem  value="9">September</asp:ListItem>
							<asp:ListItem  value="10">Oktober</asp:ListItem>
							<asp:ListItem  value="11">November</asp:ListItem>
							<asp:ListItem  value="12">Desember</asp:ListItem>
						</asp:dropdownlist>
															
						<asp:dropdownlist runat="server" id="yearlist">
                            <asp:ListItem  value="1992">1992</asp:ListItem>
							<asp:ListItem  value="1991">1991</asp:ListItem>

							<asp:ListItem  value="1990">1990</asp:ListItem>

							<asp:ListItem  value="1989">1989</asp:ListItem>

							<asp:ListItem  value="1988">1988</asp:ListItem>

							<asp:ListItem  value="1987">1987</asp:ListItem>

							<asp:ListItem  value="1986">1986</asp:ListItem>

							<asp:ListItem  value="1985">1985</asp:ListItem>

							<asp:ListItem  value="1984">1984</asp:ListItem>

							<asp:ListItem  value="1983">1983</asp:ListItem>

							<asp:ListItem  value="1982">1982</asp:ListItem>

							<asp:ListItem  value="1981">1981</asp:ListItem>

							<asp:ListItem  value="1980">1980</asp:ListItem>

							<asp:ListItem  value="1979">1979</asp:ListItem>

							<asp:ListItem  value="1978">1978</asp:ListItem>

							<asp:ListItem  value="1977">1977</asp:ListItem>

							<asp:ListItem  value="1976">1976</asp:ListItem>

							<asp:ListItem  value="1975">1975</asp:ListItem>

							<asp:ListItem  value="1974">1974</asp:ListItem>

							<asp:ListItem  value="1973">1973</asp:ListItem>

							<asp:ListItem  value="1972">1972</asp:ListItem>

							<asp:ListItem  value="1971">1971</asp:ListItem>

							<asp:ListItem  value="1970">1970</asp:ListItem>

							<asp:ListItem  value="1969">1969</asp:ListItem>

							<asp:ListItem  value="1968">1968</asp:ListItem>

							<asp:ListItem  value="1967">1967</asp:ListItem>

							<asp:ListItem  value="1966">1966</asp:ListItem>

							<asp:ListItem  value="1965">1965</asp:ListItem>

							<asp:ListItem  value="1964">1964</asp:ListItem>

							<asp:ListItem  value="1963">1963</asp:ListItem>

							<asp:ListItem  value="1962">1962</asp:ListItem>

							<asp:ListItem  value="1961">1961</asp:ListItem>

							<asp:ListItem  value="1960">1960</asp:ListItem>

							<asp:ListItem  value="1959">1959</asp:ListItem>

							<asp:ListItem  value="1958">1958</asp:ListItem>

							<asp:ListItem  value="1957">1957</asp:ListItem>

							<asp:ListItem  value="1956">1956</asp:ListItem>

							<asp:ListItem  value="1955">1955</asp:ListItem>

							<asp:ListItem  value="1954">1954</asp:ListItem>

							<asp:ListItem  value="1953">1953</asp:ListItem>

							<asp:ListItem  value="1952">1952</asp:ListItem>

							<asp:ListItem  value="1951">1951</asp:ListItem>

							<asp:ListItem  value="1950">1950</asp:ListItem>

							<asp:ListItem  value="1949">1949</asp:ListItem>

							<asp:ListItem  value="1948">1948</asp:ListItem>

							<asp:ListItem  value="1947">1947</asp:ListItem>

							<asp:ListItem  value="1946">1946</asp:ListItem>

							<asp:ListItem  value="1945">1945</asp:ListItem>

							<asp:ListItem  value="1944">1944</asp:ListItem>

							<asp:ListItem  value="1943">1943</asp:ListItem>

							<asp:ListItem  value="1942">1942</asp:ListItem>

							<asp:ListItem  value="1941">1941</asp:ListItem>

							<asp:ListItem  value="1940">1940</asp:ListItem>

							<asp:ListItem  value="1939">1939</asp:ListItem>

							<asp:ListItem  value="1938">1938</asp:ListItem>

							<asp:ListItem  value="1937">1937</asp:ListItem>

							<asp:ListItem  value="1936">1936</asp:ListItem>

							<asp:ListItem  value="1935">1935</asp:ListItem>

							<asp:ListItem  value="1934">1934</asp:ListItem>

							<asp:ListItem  value="1933">1933</asp:ListItem>

							<asp:ListItem  value="1932">1932</asp:ListItem>

							<asp:ListItem  value="1931">1931</asp:ListItem>

							<asp:ListItem  value="1930">1930</asp:ListItem>

							<asp:ListItem  value="1929">1929</asp:ListItem>

							<asp:ListItem  value="1928">1928</asp:ListItem>

							<asp:ListItem  value="1927">1927</asp:ListItem>

							<asp:ListItem  value="1926">1926</asp:ListItem>

							<asp:ListItem  value="1925">1925</asp:ListItem>

							<asp:ListItem  value="1924">1924</asp:ListItem>

							<asp:ListItem  value="1923">1923</asp:ListItem>

							<asp:ListItem  value="1922">1922</asp:ListItem>

							<asp:ListItem  value="1921">1921</asp:ListItem>

							<asp:ListItem  value="1920">1920</asp:ListItem>

							<asp:ListItem  value="1919">1919</asp:ListItem>

							<asp:ListItem  value="1918">1918</asp:ListItem>

							<asp:ListItem  value="1917">1917</asp:ListItem>

							<asp:ListItem  value="1916">1916</asp:ListItem>

							<asp:ListItem  value="1915">1915</asp:ListItem>

							<asp:ListItem  value="1914">1914</asp:ListItem>

							<asp:ListItem  value="1913">1913</asp:ListItem>

							<asp:ListItem  value="1912">1912</asp:ListItem>

							<asp:ListItem  value="1911">1911</asp:ListItem>

							<asp:ListItem  value="1910">1910</asp:ListItem>

							<asp:ListItem  value="1909">1909</asp:ListItem>
						</asp:dropdownlist>
        </td>
        <td>
           Kommune:<br />
            <asp:ScriptManager ID="ScriptManager2" 
                               runat="server" />
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2" 
                            UpdateMode="Conditional">
                            <ContentTemplate>    
                                <asp:PlaceHolder runat="server" ID="PlaceHolder2"
                                    EnableViewState="false"/>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="norwayFylke1" 
                                     />
                            </Triggers>
                        </asp:UpdatePanel>
            <br />
        </td>   
    </tr>
    <tr  align="left">
        <td>
        Barn:<br />
			<asp:dropdownlist runat="server" id="children" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="Nei">Nei</asp:ListItem>
				<asp:ListItem  value="Ja">Ja</asp:ListItem>
			</asp:dropdownlist>
        </td>
        <td>
         Sivilstand:<br />
			<asp:dropdownlist runat="server" id="sivilstand" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="Gift">Gift</asp:ListItem>
				<asp:ListItem  value="Har partner">Har partner</asp:ListItem>
				<asp:ListItem  value="Separert">Separert</asp:ListItem>
				<asp:ListItem  value="Singel">Singel</asp:ListItem>
				<asp:ListItem  value="Skilt">Skilt</asp:ListItem>
				<asp:ListItem  value="Enke/Enkemann">Enke/Enkemann</asp:ListItem>
			</asp:dropdownlist><br />
            </td>
    </tr>
    
    <tr  align="left">
        <td>
          Drikker:<br />
			<asp:dropdownlist runat="server" id="drinking" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="Ja">Ja</asp:ListItem>
				<asp:ListItem  value="Nei">Nei</asp:ListItem>
				<asp:ListItem  value="Av og til">Av og til</asp:ListItem>
			</asp:dropdownlist>
        </td>
        <td>
		    Røker:<br />
			<asp:dropdownlist runat="server" id="smoking" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="Ja">Ja</asp:ListItem>
				<asp:ListItem  value="Nei">Nei</asp:ListItem>
				<asp:ListItem  value="Av og til">Av og til</asp:ListItem>
			</asp:dropdownlist>
			</td>

    </tr>
    <tr  align="left"><br/>
        <td><br /> Hårfarge:<br />
			<asp:dropdownlist runat="server" id="haircolor" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="Blondt">Blondt</asp:ListItem>
				<asp:ListItem  value="Brunt">Brunt</asp:ListItem>
				<asp:ListItem  value="Askeblondt">Askeblondt</asp:ListItem>
				<asp:ListItem  value="Farget/varierer">Farget/varierer</asp:ListItem>
				<asp:ListItem  value="Gråsprengt">Gråsprengt</asp:ListItem>
				<asp:ListItem  value="Grått">Grått</asp:ListItem>
				<asp:ListItem  value="Mørkt">Mørkt</asp:ListItem>
				<asp:ListItem  value="Rødt">Rødt</asp:ListItem>
				<asp:ListItem  value="Skallet">Skallet</asp:ListItem>
				<asp:ListItem  value="Svart">Svart</asp:ListItem>
				<asp:ListItem  value="Svart">Svart</asp:ListItem>
			</asp:dropdownlist>
       <br />
        </td>
        <td><br />
             Kroppstype:<br/>
			<asp:dropdownlist runat="server" id="body" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="Kraftig/Stor">Kraftig/Stor</asp:ListItem>
				<asp:ListItem  value="Sånn passe">Sånn passe</asp:ListItem>
				<asp:ListItem  value="Middels">Middels</asp:ListItem>
				<asp:ListItem  value="Muskuløs">Muskuløs</asp:ListItem>
				<asp:ListItem 	value="Slank">Slank</asp:ListItem>
				<asp:ListItem  value="Veltrenet">Veltrenet</asp:ListItem>
			</asp:dropdownlist><br /></td>
    </tr>
		<tr  align="left">
        <td>
         Høyde:<br />
			<asp:dropdownlist runat="server" id="height" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="155 cm">155 cm</asp:ListItem>
				<asp:ListItem  value="156 - 160 cm">156 - 160 cm</asp:ListItem>
				<asp:ListItem  value="161 - 165 cm">161 - 165 cm</asp:ListItem>
				<asp:ListItem  value="166 - 170 cm">166 - 170 cm</asp:ListItem>
				<asp:ListItem  value="171 - 175 cm">171 - 175 cm</asp:ListItem>
				<asp:ListItem  value="176 - 180 cm">176 - 180 cm</asp:ListItem>
				<asp:ListItem  value="181 - 185 cm">181 - 185 cm</asp:ListItem>
				<asp:ListItem 	value="186 - 190 cm">186 - 190 cm</asp:ListItem>
				<asp:ListItem  value="191 - 195 cm">191 - 195 cm</asp:ListItem>
				<asp:ListItem  value="196 - 200 cm">196 - 200 cm</asp:ListItem>
				<asp:ListItem  value="200 cm">200 cm</asp:ListItem>
			</asp:dropdownlist>
        <br />
        </td>
        <td>
             Øyenfarge:<br />
			<asp:dropdownlist runat="server" id="eyecolor" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="Blå">Blå</asp:ListItem>
				<asp:ListItem  value="Brun">Brun</asp:ListItem>
				<asp:ListItem  value="Grå">Grå</asp:ListItem>
				<asp:ListItem  value="Grønne">Grønne</asp:ListItem>
				<asp:ListItem  value="Nøttebrune">Nøttebrune</asp:ListItem>
				<asp:ListItem  value="Flerfargete">Flerfargete</asp:ListItem>
			</asp:dropdownlist><br />
        </td>
    </tr>
     <tr  align="left">
        <td style="width:50%">
        Utdannelse:<br />
			<asp:dropdownlist runat="server" id="education" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="Folkehøyskole">Folkehøyskole</asp:ListItem>
				<asp:ListItem  value="Grunnskole">Grunnskole</asp:ListItem>
				<asp:ListItem  value="Gymnas">Gymnas</asp:ListItem>
				<asp:ListItem  value="Høyskole/Universitet">Høyskole/Universitet</asp:ListItem>
				<asp:ListItem  value="Yrkesskole">Yrkesskole</asp:ListItem>
			</asp:dropdownlist>
       <br />
        </td>
        <td style="width:50%">
            Yrke:<br />
			<asp:dropdownlist runat="server" id="profession" style="width:200px;">
				<asp:ListItem  value=""></asp:ListItem>
				<asp:ListItem  value="Annet">Annet</asp:ListItem>
				<asp:ListItem  value="Arbeidsledig">Arbeidsledig</asp:ListItem>
				<asp:ListItem  value="Bank/Finans/Forsikring">Bank/Finans/Forsikring</asp:ListItem>
				<asp:ListItem  value="Butikk/Detaljhandel">Butikk/Detaljhandel</asp:ListItem>
				<asp:ListItem  value="Data/IT">Data/IT</asp:ListItem>
				<asp:ListItem  value="Selvstendig næringsdrivende">Selvstendig næringsdrivende</asp:ListItem>
				<asp:ListItem  value="Bygg og anlegg">Bygg og anlegg</asp:ListItem>
				<asp:ListItem  value="Hjemmeværende">Hjemmeværende</asp:ListItem>
				<asp:ListItem  value="Hotell- og turistnæring">Hotell- og turistnæring</asp:ListItem>
				<asp:ListItem  value="Industri">Industri</asp:ListItem>
				<asp:ListItem  value="Jordbruk">Jordbruk</asp:ListItem>
				<asp:ListItem  value="Jurist">Jurist</asp:ListItem>
				<asp:ListItem  value="Kultur/Media">Kultur/Media</asp:ListItem>
				<asp:ListItem  value="Lege">Lege</asp:ListItem>
				<asp:ListItem  value="Lærer">Lærer</asp:ListItem>
				<asp:ListItem  value="Offentlig forvaltning">Offentlig forvaltning</asp:ListItem>
				<asp:ListItem  value="Pensjonist">Pensjonist</asp:ListItem>
				<asp:ListItem  value="Politiker">Politiker</asp:ListItem>
				<asp:ListItem  value="Reklame">Reklame</asp:ListItem>
				<asp:ListItem  value="Restaurant">Restaurant</asp:ListItem>
				<asp:ListItem  value="Student">Student</asp:ListItem>
				<asp:ListItem  value="Servicenæring">Servicenæring</asp:ListItem>
				<asp:ListItem  value="Transport/Kommunikasjon">Transport/Kommunikasjon</asp:ListItem>
				<asp:ListItem  value="Underholdning/Media">Underholdning/Media</asp:ListItem>
				<asp:ListItem  value="Utdannelse/Forskning">Utdannelse/Forskning</asp:ListItem>
				<asp:ListItem  value="Pleie/Omsorg">Pleie/Omsorg</asp:ListItem>
			</asp:dropdownlist><br /></td>
    </tr>
    <tr align="left">
        <td>
            Religion:<br />
            <asp:DropDownList ID="religion" runat="server" style="width:200px;">
                <asp:ListItem  value=""></asp:ListItem>
                <asp:ListItem  value="Annet">Annet</asp:ListItem>
                <asp:ListItem  value="Atheism">Ateist</asp:ListItem>
                <asp:ListItem  value="Buddhism">Buddhist</asp:ListItem>
                <asp:ListItem  value="Hinduism">Hindu</asp:ListItem>
                <asp:ListItem  value="Jøde">Jødisk</asp:ListItem>                
                <asp:ListItem  value="Kristen">Kristen</asp:ListItem>
                <asp:ListItem  value="Muslimer">Muslimer</asp:ListItem>
                <asp:ListItem  value="Muslimer">Scientolog</asp:ListItem>                
            </asp:DropDownList>
            <br />
        </td>
         <td>
            Etnisk bakgrunn:<br />
            <asp:DropDownList ID="ethenic" runat="server" style="width:200px;">
                <asp:ListItem  value=""></asp:ListItem>
                <asp:ListItem  value="Annet">Annet</asp:ListItem>
                <asp:ListItem  value="Afrikaner">Afrikaner</asp:ListItem>
                <asp:ListItem  value="Asiat">Asiat</asp:ListItem>
                <asp:ListItem  value="Australian and oceanic">Australian and oceanic</asp:ListItem>                
                <asp:ListItem  value="Blanndet etnisk bakgrunn">Blanndet etnisk bakgrunn</asp:ListItem>
                <asp:ListItem  value="Europeisk">Europeisk</asp:ListItem>
                <asp:ListItem  value="Latinamerikansk">Latinamerikansk</asp:ListItem>
            </asp:DropDownList>
            <br />
           </td>
    </tr>
    <tr  align="left">
        <td>
            
            Språk:<br />
            <asp:DropDownList ID="language2" runat="server" 
                style="width:200px;">
                <asp:ListItem  value=""></asp:ListItem>
                <asp:ListItem  value="Norsk">Norsk</asp:ListItem>
                <asp:ListItem  value="Svensk">Svensk</asp:ListItem>
                <asp:ListItem  value="Dansk">Dansk</asp:ListItem>
                <asp:ListItem  value="Engelsk">Engelsk</asp:ListItem>
                <asp:ListItem  value="Finsk">Finsk</asp:ListItem>
                <asp:ListItem  value="Annet">Annet</asp:ListItem>
            </asp:DropDownList>
            
        </td><td>Språk to:<br />
	        <asp:dropdownlist runat="server" id="language1" style="width:200px;">
		       	<asp:ListItem  value=""></asp:ListItem>
		        <asp:ListItem  value="Norsk">Norsk</asp:ListItem>
		        <asp:ListItem  value="Svensk">Svensk</asp:ListItem>
		        <asp:ListItem  value="Dansk">Dansk</asp:ListItem>
		        <asp:ListItem  value="Engelsk">Engelsk</asp:ListItem>
		        <asp:ListItem  value="Finsk">Finsk</asp:ListItem>
		        <asp:ListItem  value="Annet">Annet</asp:ListItem>
	        </asp:dropdownlist><br /></td></tr></table>
   
         <br/>
        <table class="righttables">
        <tr  align="left">
            <td><br/>
             Last opp profil bilde:<br />
             <asp:Image runat="server" id="profilePic" width="100px" height="120px" /><br />
	           <asp:FileUpload ID="loadpropic" runat="server" />
                    &nbsp;&nbsp;<asp:Button ID="loadpropicBtn" runat="server" Text="Last opp" 
                    onclick="loadpropicBtn_Click" /><br />
                <asp:Label ID="UploadStatusLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td> </td>
         </tr></table><br/>
        <table class="righttables">
        <tr  align="left">
        <td align ="left" style="width:50%"><br />
        Interesser:<br />
							<asp:checkbox runat="server" id="bilerChk" 
                /><asp:Label runat="server" id="lblbiler">Biler / Motorsykler</asp:Label><br />
							<asp:checkbox runat="server" id="sportinterestChk" 
                 /><asp:Label runat="server" id="lblsport" >Sport</asp:Label><br />
							<asp:checkbox runat="server" id="dansChk" 
                 /><asp:Label runat="server" id="lbldans">Dans</asp:Label><br />
							<asp:checkbox runat="server" id="dataChk" 
                 /><asp:Label runat="server" id="lblcomputersandinternet">Datamaskiner / Internett</asp:Label><br />
							<asp:checkbox runat="server"  id="filmChk" 
                 /><asp:Label runat="server" id="lblfilm">Film / Kino / Teater </asp:Label><br />
							<asp:checkbox runat="server" id="trimChk" 
                 /><asp:Label runat="server" id="lbltrim">Trim</asp:Label><br />
							<asp:checkbox runat="server" id="kunstChk" 
                 /><asp:Label runat="server" id="lblkunst" >Kunst / Håndverk</asp:Label><br />
							<asp:checkbox runat="server" id="litteratureandhistoryChk" 
                 /><asp:Label runat="server" id="lbllitteratureandhistory">Litteratur / Historie</asp:Label><br />
							<asp:checkbox runat="server" id="matlagingChk" 
                 /><asp:Label runat="server" id="lblmatlaging">Matlagning</asp:Label><br />
							<asp:checkbox runat="server" id="natureChk" 
                /><asp:Label runat="server" id="lblnature">Natur</asp:Label><br />
							<asp:checkbox runat="server" id="politicsChk" 
                 /><asp:Label runat="server" id="lblpolitics">Politikk</asp:Label><br />
							<asp:checkbox runat="server" id="travellingChk" 
                 /><asp:Label runat="server" id="lbltravelling">Reiser</asp:Label><br />
							<asp:checkbox runat="server" id="scienceinterestChk" 
                 /><asp:Label runat="server" id="lblshopping">Vitenskap</asp:Label><br />
                            <asp:checkbox runat="server" id="charityinterestChk" 
                 /><asp:Label runat="server" id="lblcharity">Veldedighetsarbeid</asp:Label><br />
                            <asp:checkbox runat="server" id="klubbfestChk" 
                 /><asp:Label runat="server" id="lblklubbfest">Nattklubb / Fest</asp:Label><br />
							<asp:checkbox runat="server" id="singingandplayingChk" 
                 /><asp:Label runat="server" id="lblsingingandplaying">Synge / Spille instrument</asp:Label><br />
							<asp:checkbox runat="server" id="annetChk" 
                 /><asp:Label runat="server" id="lblannet">Annet</asp:Label><br />
						</td>
						<td style="padding-top:20px" valign="top" style="width:50%">
							<div>Musikk							<br />
							<asp:checkbox runat="server" 
                                    id="musicclassicChk" /><asp:Label runat="server" id="lblmusicclassic">Klassisk / Opera</asp:Label></asp:Label><br />
							<asp:checkbox runat="server" id="musicrockChk" 
                                /><asp:Label runat="server" id="lblmusicrock">Rock</asp:Label><br />
							<asp:checkbox runat="server" id="musicmeatlChk" 
                                /><asp:Label runat="server" id="lblmusicmeatl">meatl</asp:Label><br />
							<asp:checkbox runat="server" id="musichiphopChk" 
                                /><asp:Label runat="server" id="lblmusichiphop">Hip-Hop</asp:Label><br />
							<asp:checkbox runat="server" id="musicfolkmusicChk" 
                                /><asp:Label runat="server" id="lblmusicfolkmusic">Folkemusikk</asp:Label><br />
							<asp:checkbox runat="server" id="musicthechnoChk" 
                                /><asp:Label runat="server" id="lblmusicthechno">Thechno</asp:Label><br />
						    <asp:checkbox runat="server" id="musictranceChk" 
                                /><asp:Label runat="server" id="lbltrance">Trance</asp:Label><br />
							<asp:checkbox runat="server" id="musicbluesChk" 
                                /><asp:Label runat="server" id="lblmusicblues">Blues</asp:Label><br />
							<asp:checkbox runat="server" id="musicnewageChk" 
                                /><asp:Label runat="server" id="lblmusicnewage">New age</asp:Label><br />
							<asp:checkbox runat="server" id="musiccelticChk" 
                                 /><asp:Label runat="server" id="lblmusicceltic">Keltisk</asp:Label><br />
							<asp:checkbox runat="server" id="musicreligionChk" 
                                /><asp:Label runat="server" id="lblmusicreligious">Religious musikk</asp:Label><br />
							<asp:checkbox runat="server" id="musicchamberChk" 
                                 /><asp:Label runat="server" id="lblmusicchamber">Kammer</asp:Label><br />
                                 <asp:checkbox runat="server" id="musicjazzChk" 
                                 /><asp:Label runat="server" id="lbljazz">Jazz</asp:Label><br />		
							<asp:checkbox runat="server" id="musicotherChk" 
                                 /><asp:Label runat="server" id="lblmusicother">Annet</asp:Label><br />							
						</td>
					</tr>
					</table><br/>
					<table class="righttables" style="background-color:#f0f8ff">
					<tr  align="left">
					  <td valign="top" align ="left" style="width:50%">
							<br /><div> Favoritt sport </div>
                          <asp:TextBox ID="sport" runat="server"></asp:TextBox>
						
                    	<br /><br />
						<br /><div> Favoritt husdyr </div>
                      <asp:TextBox ID="dyr" runat="server"></asp:TextBox>
					</td>
					<td valign="top" align ="left" style="width:50%">
							<br /><div> Favoritt boktype </div>
                          <asp:TextBox ID="boktype" runat="server"></asp:TextBox>
					</td>
				</tr>
				 <tr  align="left">
				<td style="vertical-align:middle;padding-left:2px; height:15px;" style="width:50%">		Jeg er<br />
				<asp:DropDownList ID="genderList" name="mag" style="width:210px; height:18px;" 
                        runat="server">
                    <asp:ListItem value=""></asp:ListItem>                    
                    <asp:ListItem value="Kvinne">Kvinne</asp:ListItem>
                    <asp:ListItem value="Man">Man</asp:ListItem>
  
				</asp:DropDownList>&nbsp;<br/>
				</td><td style="width:50%"></td>
				</tr>
    <tr align="left">
				<td style="vertical-align:middle;padding-left:2px; height:15px;" style="width:50%">		Jeg søker<br />
				<asp:DropDownList ID="DropDownList2" name="mag" style="width:210px; height:18px;" runat="server">
                    <asp:ListItem value=""></asp:ListItem>                    
                    <asp:ListItem value="Kvinne">Kvinne</asp:ListItem>
                    <asp:ListItem value="Man">Man</asp:ListItem>
             
				</asp:DropDownList>&nbsp;&nbsp;mellom<br/>
				</td><td style="vertical-align:bottom;padding-left:2px; height:15px;"><asp:dropdownlist runat="server" id="min">
                        <asp:ListItem value="18">18</asp:ListItem>
                        <asp:ListItem value="19">19</asp:ListItem>
                        <asp:ListItem value="20">20</asp:ListItem>
                        <asp:ListItem value="21">21</asp:ListItem>
                        <asp:ListItem value="22">22</asp:ListItem>
                        <asp:ListItem value="23">23</asp:ListItem>
                        <asp:ListItem value="24">24</asp:ListItem>
                        <asp:ListItem value="25">25</asp:ListItem>
                        <asp:ListItem value="26">26</asp:ListItem>
                        <asp:ListItem value="27">27</asp:ListItem>
                        <asp:ListItem value="28">28</asp:ListItem>
                        <asp:ListItem value="29">29</asp:ListItem>
                        <asp:ListItem value="30">30</asp:ListItem>
                       
                        <asp:ListItem value="31">31</asp:ListItem>
                        <asp:ListItem value="32">32</asp:ListItem>
                        <asp:ListItem value="33">33</asp:ListItem>
                        <asp:ListItem value="34">34</asp:ListItem>
                        <asp:ListItem value="35">35</asp:ListItem>
                        <asp:ListItem value="36">36</asp:ListItem>
                        <asp:ListItem value="37">37</asp:ListItem>
                        <asp:ListItem value="38">38</asp:ListItem>
                        <asp:ListItem value="39">39</asp:ListItem>
                        <asp:ListItem value="40">40</asp:ListItem>

                        <asp:ListItem value="41">41</asp:ListItem>
                        <asp:ListItem value="42">42</asp:ListItem>
                        <asp:ListItem value="43">43</asp:ListItem>
                        <asp:ListItem value="44">44</asp:ListItem>
                        <asp:ListItem value="45">45</asp:ListItem>
                        <asp:ListItem value="46">46</asp:ListItem>
                        <asp:ListItem value="47">47</asp:ListItem>
                        <asp:ListItem value="48">48</asp:ListItem>
                        <asp:ListItem value="49">49</asp:ListItem>
                        <asp:ListItem value="50">50</asp:ListItem>
                        
                        <asp:ListItem value="51">51</asp:ListItem>
                        <asp:ListItem value="52">52</asp:ListItem>
                        <asp:ListItem value="53">53</asp:ListItem>
                        <asp:ListItem value="54">54</asp:ListItem>
                        <asp:ListItem value="55">55</asp:ListItem>
                        <asp:ListItem value="56">56</asp:ListItem>
                        <asp:ListItem value="57">57</asp:ListItem>
                        <asp:ListItem value="58">58</asp:ListItem>
                        <asp:ListItem value="59">59</asp:ListItem>
                        <asp:ListItem value="60">60</asp:ListItem>
                        
                        <asp:ListItem value="61">61</asp:ListItem>
                        <asp:ListItem value="62">62</asp:ListItem>
                        <asp:ListItem value="63">63</asp:ListItem>
                        <asp:ListItem value="64">64</asp:ListItem>
                        <asp:ListItem value="65">65</asp:ListItem>
                        <asp:ListItem value="66">66</asp:ListItem>
                        <asp:ListItem value="67">67</asp:ListItem>
                        <asp:ListItem value="68">68</asp:ListItem>
                        <asp:ListItem value="69">69</asp:ListItem>
                        <asp:ListItem value="70">70</asp:ListItem>
                       
                        <asp:ListItem value="71">71</asp:ListItem>
                        <asp:ListItem value="72">72</asp:ListItem>
                        <asp:ListItem value="73">73</asp:ListItem>
                        <asp:ListItem value="74">74</asp:ListItem>
                        <asp:ListItem value="75">75</asp:ListItem>
                        <asp:ListItem value="76">76</asp:ListItem>
                        <asp:ListItem value="77">77</asp:ListItem>
                        <asp:ListItem value="78">78</asp:ListItem>
                        <asp:ListItem value="79">79</asp:ListItem>
                        <asp:ListItem value="80">80</asp:ListItem>

                        <asp:ListItem value="81">81</asp:ListItem>
                        <asp:ListItem value="82">82</asp:ListItem>
                        <asp:ListItem value="83">83</asp:ListItem>
                        <asp:ListItem value="84">84</asp:ListItem>
                        <asp:ListItem value="85">85</asp:ListItem>
                        <asp:ListItem value="86">86</asp:ListItem>
                        <asp:ListItem value="87">87</asp:ListItem>
                        <asp:ListItem value="88">88</asp:ListItem>
                        <asp:ListItem value="89">89</asp:ListItem>
                        <asp:ListItem value="90">90</asp:ListItem>
                       
                        <asp:ListItem value="91">91</asp:ListItem>
                        <asp:ListItem value="92">92</asp:ListItem>
                        <asp:ListItem value="93">93</asp:ListItem>
                        <asp:ListItem value="94">94</asp:ListItem>
                        <asp:ListItem value="95">95</asp:ListItem>
                        <asp:ListItem value="96">96</asp:ListItem>
                        <asp:ListItem value="97">97</asp:ListItem>
                        <asp:ListItem value="98">98</asp:ListItem>
                        <asp:ListItem value="99">99</asp:ListItem>          
                    </asp:dropdownlist>&nbsp; og &nbsp;
	               <asp:dropdownlist runat="server" id="maks">
                         <asp:ListItem value="18">18</asp:ListItem>
                        <asp:ListItem value="19">19</asp:ListItem>
                        <asp:ListItem value="20">20</asp:ListItem>
                        <asp:ListItem value="21">21</asp:ListItem>
                        <asp:ListItem value="22">22</asp:ListItem>
                        <asp:ListItem value="23">23</asp:ListItem>
                        <asp:ListItem value="24">24</asp:ListItem>
                        <asp:ListItem value="25">25</asp:ListItem>
                        <asp:ListItem value="26">26</asp:ListItem>
                        <asp:ListItem value="27">27</asp:ListItem>
                        <asp:ListItem value="28">28</asp:ListItem>
                        <asp:ListItem value="29">29</asp:ListItem>
                        <asp:ListItem value="30">30</asp:ListItem>
                       
                        <asp:ListItem value="31">31</asp:ListItem>
                        <asp:ListItem value="32">32</asp:ListItem>
                        <asp:ListItem value="33">33</asp:ListItem>
                        <asp:ListItem value="34">34</asp:ListItem>
                        <asp:ListItem value="35">35</asp:ListItem>
                        <asp:ListItem value="36">36</asp:ListItem>
                        <asp:ListItem value="37">37</asp:ListItem>
                        <asp:ListItem value="38">38</asp:ListItem>
                        <asp:ListItem value="39">39</asp:ListItem>
                        <asp:ListItem value="40">40</asp:ListItem>

                        <asp:ListItem value="41">41</asp:ListItem>
                        <asp:ListItem value="42">42</asp:ListItem>
                        <asp:ListItem value="43">43</asp:ListItem>
                        <asp:ListItem value="44">44</asp:ListItem>
                        <asp:ListItem value="45">45</asp:ListItem>
                        <asp:ListItem value="46">46</asp:ListItem>
                        <asp:ListItem value="47">47</asp:ListItem>
                        <asp:ListItem value="48">48</asp:ListItem>
                        <asp:ListItem value="49">49</asp:ListItem>
                        <asp:ListItem value="50">50</asp:ListItem>
                        
                        <asp:ListItem value="51">51</asp:ListItem>
                        <asp:ListItem value="52">52</asp:ListItem>
                        <asp:ListItem value="53">53</asp:ListItem>
                        <asp:ListItem value="54">54</asp:ListItem>
                        <asp:ListItem value="55">55</asp:ListItem>
                        <asp:ListItem value="56">56</asp:ListItem>
                        <asp:ListItem value="57">57</asp:ListItem>
                        <asp:ListItem value="58">58</asp:ListItem>
                        <asp:ListItem value="59">59</asp:ListItem>
                        <asp:ListItem value="60">60</asp:ListItem>
                        
                        <asp:ListItem value="61">61</asp:ListItem>
                        <asp:ListItem value="62">62</asp:ListItem>
                        <asp:ListItem value="63">63</asp:ListItem>
                        <asp:ListItem value="64">64</asp:ListItem>
                        <asp:ListItem value="65">65</asp:ListItem>
                        <asp:ListItem value="66">66</asp:ListItem>
                        <asp:ListItem value="67">67</asp:ListItem>
                        <asp:ListItem value="68">68</asp:ListItem>
                        <asp:ListItem value="69">69</asp:ListItem>
                        <asp:ListItem value="70">70</asp:ListItem>
                       
                        <asp:ListItem value="71">71</asp:ListItem>
                        <asp:ListItem value="72">72</asp:ListItem>
                        <asp:ListItem value="73">73</asp:ListItem>
                        <asp:ListItem value="74">74</asp:ListItem>
                        <asp:ListItem value="75">75</asp:ListItem>
                        <asp:ListItem value="76">76</asp:ListItem>
                        <asp:ListItem value="77">77</asp:ListItem>
                        <asp:ListItem value="78">78</asp:ListItem>
                        <asp:ListItem value="79">79</asp:ListItem>
                        <asp:ListItem value="80">80</asp:ListItem>

                        <asp:ListItem value="81">81</asp:ListItem>
                        <asp:ListItem value="82">82</asp:ListItem>
                        <asp:ListItem value="83">83</asp:ListItem>
                        <asp:ListItem value="84">84</asp:ListItem>
                        <asp:ListItem value="85">85</asp:ListItem>
                        <asp:ListItem value="86">86</asp:ListItem>
                        <asp:ListItem value="87">87</asp:ListItem>
                        <asp:ListItem value="88">88</asp:ListItem>
                        <asp:ListItem value="89">89</asp:ListItem>
                        <asp:ListItem value="90">90</asp:ListItem>
                       
                        <asp:ListItem value="91">91</asp:ListItem>
                        <asp:ListItem value="92">92</asp:ListItem>
                        <asp:ListItem value="93">93</asp:ListItem>
                        <asp:ListItem value="94">94</asp:ListItem>
                        <asp:ListItem value="95">95</asp:ListItem>
                        <asp:ListItem value="96">96</asp:ListItem>
                        <asp:ListItem value="97">97</asp:ListItem>
                        <asp:ListItem value="98">98</asp:ListItem>
                        <asp:ListItem value="99">99</asp:ListItem>          
                    </asp:dropdownlist></td><tr><td><br/>
           Kontakt type:<br />
    <asp:checkbox runat="server" id="activityChk" 
            /> Aktivitetsvenn<br />
			<asp:checkbox runat="server" id="acquaintanceChk" 
            /> Bekjentskap<br />
			<asp:checkbox runat="server" id="marriageChk" 
            /> Ekteskap<br />
			<asp:checkbox runat="server" id="relationshipChk" 
            /> Forhold<br />
			<asp:checkbox runat="server" id="travelChk" 
             /> Reisevenn<br />
			<asp:checkbox runat="server" id="romanceChk" /> Romanse<br />
			<asp:checkbox runat="server" id="friendChk"/> Vennskap<br />
        </td>
        <td style="width:50%">
            &nbsp;</td>
		</tr>
		</table>
		<br/>
		<table class="righttables">
		<tr ><td style="width:100%" id="righttables.column"><br/>
            Fri tekst om deg selv:</td></tr>
        <tr ><td style="width:100%" id="righttables.column">
            <asp:TextBox ID="seldescription" runat="server" Height="300px" Width="670px"></asp:TextBox>
            </td>
    </tr>
    <tr><td style="width:100%" colspan="2">
        <asp:Button ID="profilBtn" runat="server" Text="Submit" 
            onclick="profilBtn_Click" />
            </td>
    </tr>
</table>
