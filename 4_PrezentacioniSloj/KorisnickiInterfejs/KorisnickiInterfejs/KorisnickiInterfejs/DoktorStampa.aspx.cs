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
     public partial class DoktorStampa : System.Web.UI.Page
     {

          // nase metode
          private void NapuniGrid(DataSet ds)
          {
               // povezivanje grida sa datasetom
               gvspisakDoktora.DataSource = ds.Tables[0];
               gvspisakDoktora.DataBind();
          }


          protected void Page_Load(object sender, EventArgs e)
          {
               clsFormaDoktorStampa objFormaDoktorStampa = new clsFormaDoktorStampa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);

               string filter = Request.QueryString["filter"];
               if (filter == null)
               {
                    filter = "";
               }

               if (filter.Equals(""))
               {
                    lblNaslov.Text = "SPISAK SVIH DOKTORA";
               }
               else
               {
                    lblNaslov.Text = "FILTRIRANI SPISAK DOKTORA, prezime=" + filter;
               }
               
               NapuniGrid(objFormaDoktorStampa.DajPodatkeZaGrid(filter));
          }
     }
}