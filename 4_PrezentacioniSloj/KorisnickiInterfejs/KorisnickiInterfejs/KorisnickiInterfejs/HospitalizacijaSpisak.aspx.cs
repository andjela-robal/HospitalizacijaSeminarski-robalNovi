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
     public partial class HospitalizacijaSpisak : System.Web.UI.Page
     {
          // atributi
          private clsFormaHospitalizacijaSpisak objFormaHospitalizacijaSpisak;

          // konstruktor


          // nase metode
          private void NapuniGrid(DataSet ds)
          {
               // povezivanje grida sa datasetom
               gvHospitalizacije.DataSource = ds.Tables[0];
               gvHospitalizacije.DataBind();
          }



          // dogadjaji
          protected void Page_Load(object sender, EventArgs e)
          {
               objFormaHospitalizacijaSpisak = new clsFormaHospitalizacijaSpisak(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
          }

          protected void btnFiltriraj_Click(object sender, EventArgs e)
          {
               if (txbFilter.Text != "")
               {
                    NapuniGrid(objFormaHospitalizacijaSpisak.DajPodatkeZaGrid(txbFilter.Text));
                    lblStatus.Text = "Filtrirano!";
               }
               else lblStatus.Text = "Potrebno je uneti Jmbg pacijenta";
          }

          protected void btnSvi_Click(object sender, EventArgs e)
          {
               NapuniGrid(objFormaHospitalizacijaSpisak.DajPodatkeZaGrid(""));
          }
     }
}