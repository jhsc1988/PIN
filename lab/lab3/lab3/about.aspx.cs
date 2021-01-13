using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class about : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["korisnik"] != null)
        {
            lb_about_korisnik.Text = "Dobro došao: " +Session["korisnik"].ToString();
        } else
        {
            Response.Redirect("Default.aspx");
        }
    }
}