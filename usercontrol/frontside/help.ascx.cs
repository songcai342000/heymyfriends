using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class usercontrol_frontside_help : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void questionsBtn_Click(object sender, EventArgs e)
    {
        membershipcostLi.Visible = true;
        membershipcostLi.Text = "Ja, medlemskap er gratis. Som medlem har du alltid tilgang til del av funksjonaliteter" +
                  " på websiden. Man må ha et abonnemnet for å ha tilgang til alle funksjonaliteter. " + 
                  "Nytt medlem kan få 7 dagers abonnement som en velkommen gave " + 
                   "fra Minevenner.no.";
    }
    protected void orderBtn_Click(object sender, EventArgs e)
    {
        orderLi.Visible = true;
        orderLi.Text = "Abonnement selgs direkt på nett. Du kan velge å betale via nettbank eller via telegiro eller skrive ut fakturaen på papir og betale i banken.";
    }
    protected void twoaccountBtn_Click(object sender, EventArgs e)
    {
        twoaccountLi.Visible = true;
        twoaccountLi.Text = "Nei. En bruker kan bare opprettere en konto. Det er helle ikke tillatt at to eller flere personer deler sammen konto.";
    }
    protected void supportBtn_Click(object sender, EventArgs e)
    {
        supportLi.Visible = true;
        supportLi.Text = "Trenger du hjelp eller har du spørsmål kan du sende inn en skriftlig henvendelse via webmail eller epost. Alle henvendelse blir behandlet fortløpende.";
    }
    protected void cancelmembershipBtn_Click(object sender, EventArgs e)
    {
        cancelmembershipLi.Visible = true;
        cancelmembershipLi.Text = "Ja. Du kan deaktivere eller slette medlemskap selv. Det tar bare kort tid å utføre.";
    }
    
}
