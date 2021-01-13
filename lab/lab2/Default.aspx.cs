using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private string s = "magicword";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsPostBack) {
            checkMagicWord();
        }
        
    }
    private void checkMagicWord()
    {
        if (txt_box_1.Text == s)
        {
            lbl_1.Text = "Pogodak !!!";
            lbl_1.Visible = true;
        }
        else
        {
            lbl_1.Text = "nop";
            lbl_1.Visible = true;
        }

    }
}