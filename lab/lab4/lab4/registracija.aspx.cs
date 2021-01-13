using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class registracija : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isLogged"] != null)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void registriraj_Click(object sender, EventArgs e)
    {

        if (String.IsNullOrEmpty(rtb_k_ime.Text)) // trebao bi implementirati provjeru jel korisnik već postoji, neda mi se
            rlb_obavijest.Text = "ime nije uneseno !!";

        else if (String.IsNullOrEmpty(rtb_password.Text))
            rlb_obavijest.Text = "loznika nije unesena !!";

        else if (String.IsNullOrEmpty(rtb_password_p.Text))
            rlb_obavijest.Text = "ponovljena loznika nije unesena !!";

        else if (String.Compare(rtb_password.Text, rtb_password_p.Text) != 0)
            rlb_obavijest.Text = "lozinke nisu jednake !!";

        else
        {

            string hashLozinka = hash_crypto.create_hash(rtb_password.Text);
            Random rand = new Random(DateTime.Now.Millisecond); // pseudo random -> nisam zadovoljan, ovo mora biti pametnije
            string salt = rand.Next().ToString();

            string slanaHashLozinka = hash_crypto.create_hash(hashLozinka + salt);

            // stvaram connect string i konekciju (metoda ???)
            string connStr = WebConfigurationManager
                .ConnectionStrings["mojaKonekcija"]
                .ConnectionString;
            SqlConnection conn = new SqlConnection(connStr); // stvaranje konekcije

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            //unosim korisnika
            cmd.CommandText = "INSERT INTO Korisnik(korisnikIme, korisnikLozinka, korisnikEmail, salt) VALUES(@korisnikIme, @korisnikLozinka, @korisnikEmail, @salt)";

            cmd.Parameters.AddWithValue("korisnikIme", rtb_k_ime.Text);
            cmd.Parameters.AddWithValue("korisnikLozinka", slanaHashLozinka);
            cmd.Parameters.AddWithValue("korisnikEmail", rtb_email.Text);
            cmd.Parameters.AddWithValue("salt", salt);

            // krenemo s unosom
            try
            {
                conn.Open();
                int noviRedovi = cmd.ExecuteNonQuery();
                if (noviRedovi == 1)
                    rlb_obavijest.Text = "uspješna registracija !!";
            }
            catch (Exception ex)
            {
                rlb_obavijest.Text = "Greška pri registraciji:" + ex.Message;
            } finally
            {
                conn.Close(); // zatvaram connection
            }
        }
    }

}
