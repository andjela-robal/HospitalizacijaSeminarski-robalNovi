using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
     public partial class HospitalizacijaUnos : System.Web.UI.Page
     {
          clsFormaHospitalizacijaUnos objFormaHospitalizacijaUnos;

          // konstruktor

          // nase metode
          private void NapuniCombo()
          {
               DataSet dsUputi = new DataSet();
               dsUputi = objFormaHospitalizacijaUnos.DajPodatkeZaCombo();

               int ukupno = dsUputi.Tables[0].Rows.Count;

               // PUNJENJE COMBO PODACIMA IZ DATASETA
               ddlIDUput.Items.Add("Izaberite...");
               for (int i = 0; i < ukupno; i++)
               {
                    ddlIDUput.Items.Add(dsUputi.Tables[0].Rows[i]["ID"].ToString());
               }
          }

          private void IsprazniKontrole()
          {
               txbID.Text = "";
               txbJmbgP.Text = "";
               txbDatumPrijema.Text = "";
               txbDatumOtpusta.Text = "";
               ddlIDUput.Text = "Izaberite...";
               lblStatus.Text = "";
          }


          // dogadjaji
          protected void Page_Load(object sender, EventArgs e)
          {
               objFormaHospitalizacijaUnos = new clsFormaHospitalizacijaUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
               if (!IsPostBack)
               {
                    NapuniCombo();
               }
          }

          protected void ddlIDUput_SelectedIndexChanged(object sender, EventArgs e)
          {
               //Postavljanje jmbg-a pacijenta automatski nakon što se izabere ID uputa
               clsFormaHospitalizacijaUnos pom = new clsFormaHospitalizacijaUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
               pom.IDUputa = ddlIDUput.SelectedValue;
               pom.PopuniJmbgPacijentaPoIDUputa();
               txbJmbgP.Text = pom.JmbgPacijenta;
          }

          protected void btnSnimi_Click(object sender, EventArgs e)
          {
               lblStatus.Text = ""; // Očistite prethodnu poruku

               try
               {
                    // Preuzimanje vrednosti sa korisničkog interfejsa
                    objFormaHospitalizacijaUnos.ID = txbID.Text;
                    objFormaHospitalizacijaUnos.JmbgPacijenta = txbJmbgP.Text;
                    DateTime datumPrijema;
                    if (!DateTime.TryParse(txbDatumPrijema.Text, out datumPrijema))
                    {
                         lblStatus.Text = "Neispravan format datuma.";
                         return;
                    }
                    objFormaHospitalizacijaUnos.DatumPrijema = datumPrijema;
                    DateTime datumOtpusta;
                    if (!DateTime.TryParse(txbDatumOtpusta.Text, out datumOtpusta))
                    {
                         lblStatus.Text = "Neispravan format datuma.";
                         return;
                    }
                    objFormaHospitalizacijaUnos.DatumOtpusta = datumOtpusta;
                    objFormaHospitalizacijaUnos.IDUputa = ddlIDUput.Text;

                    // Provera ispravnosti vrednosti
                    bool SvePopunjeno = false;
                    try
                    {
                         SvePopunjeno = objFormaHospitalizacijaUnos.DaLiJeSvePopunjeno();
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
                         JedinstvenZapis = objFormaHospitalizacijaUnos.DaLiJeJedinstvenZapis();
                    }
                    catch (Exception ex)
                    {
                         lblStatus.Text = "Greška pri proveri jedinstvenosti zapisa: " + ex.Message;
                         return;
                    }

                    if (!JedinstvenZapis)
                    {
                         lblStatus.Text = "VEĆ POSTOJI HOSPITALIZACIJA SA ISTIM ID-om!";
                         return;
                    }

                    // Snimanje u bazu podataka
                    try
                    {
                         bool uspehSnimanja = objFormaHospitalizacijaUnos.SnimiPodatke();
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