using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PrezentacionaLogika;
using System.Configuration;


namespace KorisnickiInterfejs
{
     public partial class DoktorDetaljiEdit : System.Web.UI.Page
     {
          // atributi
          private string pJmbg = "";
          clsFormaDoktorDetaljiEdit objFormaDoktorDetaljiEdit;

          // nase metode
          private void IsprazniKontrole()
          {
               txbJmbg.Text = "";
               txbIme.Text = "";
               txbPrezime.Text = "";

          }

          private void AktivirajKontrole()
          {
               txbJmbg.Enabled = true;
               txbIme.Enabled = true;
               txbPrezime.Enabled = true;

          }

          private void DeaktivirajKontrole()
          {
               txbJmbg.Enabled = false;
               txbIme.Enabled = false;
               txbPrezime.Enabled = false;
          }

          private void PrikaziPodatke(clsFormaDoktorDetaljiEdit objFormaDoktorDetaljiEdit)
          {
               // podacima stranice upravlja klasa prezentacione logike, zato se uzimaju iz nje za prikaz
               txbJmbg.Text = objFormaDoktorDetaljiEdit.JmbgPreuzetogDoktora;
               txbIme.Text = objFormaDoktorDetaljiEdit.ImePreuzetogDoktora;
               txbPrezime.Text = objFormaDoktorDetaljiEdit.PrezimePreuzetogDoktora;

          }

          // dogadjaji
          protected void Page_Load(object sender, EventArgs e)
          {
               try
               {
                    objFormaDoktorDetaljiEdit = new clsFormaDoktorDetaljiEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                    pJmbg = Request.QueryString["Jmbg"].ToString();
                    objFormaDoktorDetaljiEdit.JmbgPreuzetogDoktora = pJmbg;
                    if (!IsPostBack)
                    {
                         PrikaziPodatke(objFormaDoktorDetaljiEdit);
                    }
               }
               catch (Exception ex)
               {
                    lblStatus.Text = "Greška pri učitavanju stranice: " + ex.Message;
               }
          }

          protected void btnObrisi_Click(object sender, EventArgs e)
          {
               objFormaDoktorDetaljiEdit.JmbgPreuzetogDoktora = txbJmbg.Text;
               bool uspehBrisanja = objFormaDoktorDetaljiEdit.ObrisiDoktora();
               if (uspehBrisanja)
               {
                    lblStatus.Text = "Uspesno obrisan zapis!";
                    IsprazniKontrole();
               }
               else
               {
                    lblStatus.Text = "NEUSPEH BRISANJA zapisa!";
               }
          }

          protected void btnIzmeni_Click(object sender, EventArgs e)
          {
               // PREUZIMANJE POCETNIH, STARIH VREDNOSTI - OVDE NEMA POTREBE JER SE URADI NA PAGE LOAD
               //objFormaDoktorDetaljiEdit.JmbgPreuzetogDoktora = txbJmbg.Text;
               AktivirajKontrole();
               txbJmbg.Focus();

          }

          protected void btnSnimiIzmenu_Click(object sender, EventArgs e)
          {
               objFormaDoktorDetaljiEdit.JmbgIzmenjenogDoktora = txbJmbg.Text;
               objFormaDoktorDetaljiEdit.ImeIzmenjenogDoktora = txbIme.Text;
               objFormaDoktorDetaljiEdit.PrezimeIzmenjenogDoktora = txbPrezime.Text;
               bool uspehIzmene = objFormaDoktorDetaljiEdit.IzmeniDoktora();
               if (uspehIzmene)
               {
                    lblStatus.Text = "Uspesno izmenjen zapis!";
                    IsprazniKontrole();
               }
               else
               {
                    lblStatus.Text = "NEUSPEH IZMENE zapisa!";
               }
               DeaktivirajKontrole();
          }
     }
}