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
     public partial class UputSpisak : System.Web.UI.Page
     {
          // atributi
          private clsFormaUputSpisak objFormaUputSpisak;

          // konstruktor


          // nase metode
          private void NapuniGrid(DataSet ds)
          {
               // povezivanje grida sa datasetom
               gvUputi.DataSource = ds.Tables[0];
               gvUputi.DataBind();
          }



          // dogadjaji
          protected void Page_Load(object sender, EventArgs e)
          {
               objFormaUputSpisak = new clsFormaUputSpisak(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
          }

          protected void btnFiltriraj_Click(object sender, EventArgs e)
          {
               if (txbFilter.Text != "")
               {
                    NapuniGrid(objFormaUputSpisak.DajPodatkeZaGrid(txbFilter.Text));
                    lblStatus.Text = "Filtrirano!";
               }
               else lblStatus.Text = "Potrebno je uneti Prezime pacijenta";
          }

          protected void btnSvi_Click(object sender, EventArgs e)
          {
               NapuniGrid(objFormaUputSpisak.DajPodatkeZaGrid(""));
          }
     }
}