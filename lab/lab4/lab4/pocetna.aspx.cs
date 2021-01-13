using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pocetna : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.Equals(Session["isLogged"].ToString(), "Yes") && Session["LoggedUser"] != null)
        {
            pocetna_korisnik.Text = "Dobrodošli: " + Session["LoggedUser"].ToString();
        }
        else
            Response.Redirect("Default.aspx");
    }

    protected void lb_odjava_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Remove("isLogged");
        Session.Remove("LoggedUser");

        Response.Redirect("Default.aspx");
    }
}