using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void prijava_Click(object sender, EventArgs e)
    {
        if (tb_korisnik.Text == "jhusic" && tb_password.Text == "nekalozinka")
        {
            Session["korisnik"] = tb_korisnik.Text;
            Response.Redirect("about.aspx");
        } else
        {
            Session.Abandon();
        }
    }
}