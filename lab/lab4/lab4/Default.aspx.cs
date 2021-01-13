using System;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoggedUser"] != null)
            Response.Redirect("pocetna.aspx"); // treba mi nekakav pametni mehanizam da pamtim zadnji url
    }
    protected void registracija_Click(object sender, EventArgs e)
    {
        Response.Redirect("registracija.aspx");
    }

    protected void prijava_Click(object sender, EventArgs e)
    {

        string connStr = WebConfigurationManager
            .ConnectionStrings["mojaKonekcija"]
            .ConnectionString;
        SqlConnection conn = new SqlConnection(connStr); // stvaranje konekcije
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT korisnikIme, korisnikLozinka, salt FROM Korisnik WHERE korisnikIme = @korisnikIme";
        cmd.Parameters.AddWithValue("korisnikIme", tb_korisnik.Text);

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                string spremljenaLozinka = reader["korisnikLozinka"].ToString();
                string ime = reader["korisnikIme"].ToString();
                string salt = reader["salt"].ToString();

                string hashLozinka = hash_crypto.create_hash(tb_password.Text);
                string slanaHashLozinka = hash_crypto.create_hash(hashLozinka + salt);

                if (String.Compare(slanaHashLozinka, spremljenaLozinka) == 0)
                {
                    Session["isLogged"] = "Yes";
                    Session["LoggedUser"] = ime;
                    lb_obavijest.Text = "Dobar dan " + ime;
                    Response.Redirect("pocetna.aspx");
                }
                else
                    lb_obavijest.Text = "kriva lozinka ili password !!!";

            }
        }
        catch (Exception ex)
        {
            lb_obavijest.Text = "Greška:" + ex.Message;
        }
        finally
        {
            conn.Close(); // zatvaram connection
        }

    }
}
