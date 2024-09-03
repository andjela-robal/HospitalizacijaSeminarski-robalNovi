using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PrezentacionaLogika;
using System.Configuration;

namespace KorisnickiInterfejs
{
     public partial class Login : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {

          }

          protected void btnPRIJAVA_Click(object sender, EventArgs e)
          {
               try
               {
                    // provera korisnika 
                    clsFormaLogin objFormaLogin = new clsFormaLogin(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                    objFormaLogin.KorisnickoIme = txbKorisnickoIme.Text;
                    objFormaLogin.Sifra = txbSifra.Text;
                    bool pronadjenKorisnik = objFormaLogin.VazeciKorisnik();

                    if (pronadjenKorisnik)
                    {
                         string ImePrezime = objFormaLogin.DajImePrezimeKorisnika();

                         // ubacivanje korisnika u sesiju
                         Session["KorisnikImePrezime"] = ImePrezime;

                         // ucitavanje Welcome admin
                         Response.Redirect("WelcomeAdmin.aspx");
                    }
                    else
                    {
                         lblStatus.Text = "KORISNIK NIJE PRONADJEN!";
                    }
               }
               catch (Exception ex)
               {
                    lblStatus.Text = "Došlo je do greške: " + ex.Message;
               }

          }

          protected void btnOdustani_Click(object sender, EventArgs e)
          {
               Response.Redirect("Default.aspx");
          }
     }
}