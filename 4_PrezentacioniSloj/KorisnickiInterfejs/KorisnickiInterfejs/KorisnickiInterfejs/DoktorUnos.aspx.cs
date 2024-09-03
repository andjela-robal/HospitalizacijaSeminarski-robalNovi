using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtils;
using System.Configuration;

using PoslovnaLogika;
namespace KorisnickiInterfejs
{
     public partial class DoktorUnos : System.Web.UI.Page
     {

          private void IsprazniKontrole()
          {
               txbJmbg.Text = "";
               txbIme.Text = "";
               txbPrezime.Text = "";

          }

          protected void Page_Load(object sender, EventArgs e)
          {

          }

          protected void btnSnimi_Click(object sender, EventArgs e)
          {
               try
               {
                    KlasePodataka.clsDoktorDB objDoktorDB = new KlasePodataka.clsDoktorDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                    KlasePodataka.clsDoktor objDoktor = new KlasePodataka.clsDoktor();

                    // Proveri da li JMBG sadrži samo brojeve i ima tačnu dužinu
                    if (txbJmbg.Text.All(char.IsDigit) && txbJmbg.Text.Length == 13)
                    {
                         objDoktor.Jmbg = txbJmbg.Text;
                    }
                    else
                    {
                         lblStatus.Text = "JMBG mora biti broj od 13 cifara.";
                         return;
                    }

                    objDoktor.Ime = txbIme.Text;
                    objDoktor.Prezime = txbPrezime.Text;

                    bool uspeh = objDoktorDB.SnimiNovogDoktora(objDoktor);

                    if (uspeh)
                    {
                         PoslovnaLogika.clsPoslovnaPravila poslovnaPravilaXML = new PoslovnaLogika.clsPoslovnaPravila(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                         poslovnaPravilaXML.DodajMaxBrojUputaZaNovogDoktora(txbJmbg.Text);
                         lblStatus.Text = "Snimljeno";
                         IsprazniKontrole();
                    }
                    else
                    {
                         lblStatus.Text = "Greška pri snimanju";
                    }
               }
               catch (Exception ex)
               {
                    lblStatus.Text = $"Greška: {ex.Message}";
               }
          }

          protected void btnOdustani_Click(object sender, EventArgs e)
          {
               IsprazniKontrole();
          }
     }
}