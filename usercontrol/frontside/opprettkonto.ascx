<%@ Control EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="opprettkonto.ascx.cs" Inherits="usercontrol_opprettkonto" %>
<link href="../../App_Themes/vennskaper/vennskaper.css" rel="stylesheet" type="text/css" />

<table id="righttablenonborder" style="background-color:#ffddff;">		
				<tr>
					<td style="vertical-align:middle;"><br />
                        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
                            EditProfileUrl="/vennskap/functions/Profilepage.aspx?editmember={0}" 
                            ConfirmPasswordLabelText="Bekrefte passord:" 
                            CompleteSuccessText="Din konto har blitt opprettet" 
                            ConfirmPasswordRequiredErrorMessage="Passord må bekrefts" 
                            CreateUserButtonText="Lage bruker" 
                            DuplicateEmailErrorMessage="E-post addressen du har tastet inn er brukt av annen bruker. Vennligst tast inn en annen e-post address. " 
                            DuplicateUserNameErrorMessage="Venligst velg et annet brukernavn" 
                            EmailLabelText="E-post:" PasswordLabelText="Passord:" 
                            UserNameLabelText="Brukernavn:" 
       
                            UnknownErrorMessage="Din konto har ikke blitt laget. Venligst prøv på nytt." 
                            EditProfileText="Redigere din profil" 
                            ConfirmPasswordCompareErrorMessage="Passordene er ikke like" 
                            oncreateduser="CreateUserWizard1_CreatedUser" EnableViewState="False">
                            <CreateUserButtonStyle BackColor="#6699FF" ForeColor="White" />
                            <WizardSteps>
                                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                </asp:CreateUserWizardStep>
                                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                </asp:CompleteWizardStep>
                            </WizardSteps>
                        </asp:CreateUserWizard>
					</td>
				</tr>
			<tr>
				<td align="left" style="color:red;">
                    <asp:Literal ID="agreementrequired" runat="server"></asp:Literal></td>
			</tr>
			<tr>
				<td style="vertical-align:middle;padding-left:0px;padding-top:4px;padding-bottom:4px;">		
					<table cellspacing="0" cellpadding="0">
						<tr>
							<td><asp:CheckBox id="agree" runat="server" 
                                    oncheckedchanged="agree_CheckedChanged" /></td>
							<td style="padding-left:6px;">Jeg forsikrer at jeg har fylt 18 år og godkjenner disse <a href="../../general/Hjelp.aspx?Agreement={0}" style="border:0px;color:blue;">vilkår og medlemsavtale</a>.
							</td>
						</tr>
						
					</table>
				</td>
			</tr>		
		</table>