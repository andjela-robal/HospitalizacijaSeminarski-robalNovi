using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;
//
using System.Data;
using System.Configuration;
using PrezentacionaLogika;


namespace KorisnickiInterfejs
{
     public partial class UputUnos : System.Web.UI.Page
     {
          clsFormaUputUnos objFormaUputUnos;

          // konstruktor


          // nase metode
          private void NapuniCombo()
          {
               // IZDVAJANJE PODATAKA IZ XML POSREDSTVOM WEB SERVISA
               DataSet dsDoktori = new DataSet();
               dsDoktori = objFormaUputUnos.DajPodatkeZaCombo();

               int ukupno = dsDoktori.Tables[0].Rows.Count;

               // PUNJENJE COMBO PODACIMA IZ DATASETA
               ddlDoktor.Items.Add("Izaberite...");
               for (int i = 0; i < ukupno; i++)
               {
                    ddlDoktor.Items.Add(dsDoktori.Tables[0].Rows[i]["Ime i Prezime"].ToString());
               }
          }

          private void IsprazniKontrole()
          {
               txbID.Text = "";
               txbJmbgP.Text = "";
               txbIme.Text = "";
               txbPrezime.Text = "";
               txbDatumUputa.Text = "";
               ddlPol.Text = "Izaberite...";
               txbDijagnoza.Text = "";
               ddlDoktor.Text = "Izaberite...";
               lblStatus.Text = "";
          }


          // dogadjaji
          protected void Page_Load(object sender, EventArgs e)
          {
               objFormaUputUnos = new clsFormaUputUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
               if (!IsPostBack)
               {
                    NapuniCombo();
               }
          }

          protected void btnSnimi_Click(object sender, EventArgs e)
          {
               lblStatus.Text = ""; // Očistite prethodnu poruku

               try
               {
                    // Preuzimanje vrednosti sa korisničkog interfejsa
                    objFormaUputUnos.ID = txbID.Text;
                    objFormaUputUnos.JmbgPacijenta = txbJmbgP.Text;
                    objFormaUputUnos.Ime = txbIme.Text;
                    objFormaUputUnos.Prezime = txbPrezime.Text;
                    DateTime datumUputa;
                    if (!DateTime.TryParse(txbDatumUputa.Text, out datumUputa))
                    {
                         lblStatus.Text = "Neispravan format datuma.";
                         return;
                    }
                    objFormaUputUnos.DatumUputa = datumUputa;
                    objFormaUputUnos.Pol = ddlPol.Text;
                    objFormaUputUnos.Dijagnoza = txbDijagnoza.Text;
                    objFormaUputUnos.ImeIPrezimeDoktora = ddlDoktor.Text;

                    // Provera ispravnosti vrednosti
                    bool SvePopunjeno = false;
                    try
                    {
                         SvePopunjeno = objFormaUputUnos.DaLiJeSvePopunjeno();
                    }
                    catch (Exception ex)
                    {
                         lblStatus.Text = "Greška pri proveri popunjenosti: " + ex.Message;
                         return;
                    }

                    if (!SvePopunjeno)
                    {
                         lblStatus.Text = "NISU SVI PODACI POPUNJENI!";
                         txbID.Focus();
                         return;
                    }

                    bool JedinstvenZapis = false;
                    try
                    {
                         JedinstvenZapis = objFormaUputUnos.DaLiJeJedinstvenZapis();
                    }
                    catch (Exception ex)
                    {
                         lblStatus.Text = "Greška pri proveri jedinstvenosti zapisa: " + ex.Message;
                         return;
                    }

                    if (!JedinstvenZapis)
                    {
                         lblStatus.Text = "VEĆ POSTOJI UPUT SA ISTIM ID-om!";
                         return;
                    }

                    bool UskladjenoSaPoslovnimPravilima = false;
                    try
                    {
                         UskladjenoSaPoslovnimPravilima = objFormaUputUnos.DaLiSuPodaciUskladjeniSaPoslovnimPravilima();
                    }
                    catch (Exception ex)
                    {
                         lblStatus.Text = "Greška pri proveri poslovnih pravila: " + ex.Message;
                         return;
                    }

                    if (!UskladjenoSaPoslovnimPravilima)
                    {
                         lblStatus.Text = "PODACI NISU U SKLADU SA POSLOVNIM PRAVILIMA!"; 
                         return;
                    }

                    // Snimanje u bazu podataka
                    try
                    {
                         bool uspehSnimanja = objFormaUputUnos.SnimiPodatke();
                         if (uspehSnimanja)
                         {
                              lblStatus.Text = "USPESNO SNIMLJENI PODACI!";
                         }
                         else
                         {
                              lblStatus.Text = "DOŠLO JE DO GREŠKE PRI SNIMANJU PODATAKA!";
                         }
                    }
                    catch (Exception ex)
                    {
                         lblStatus.Text = "DOŠLO JE DO GREŠKE: " + ex.Message;
                    }
               }
               catch (Exception ex)
               {
                    lblStatus.Text = "OPŠTA GREŠKA: " + ex.Message;
               }
          }

          protected void btnPonisti_Click(object sender, EventArgs e)
          {
               IsprazniKontrole();
          }
     }
}