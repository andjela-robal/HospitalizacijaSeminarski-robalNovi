using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DBUtils;
using System.Configuration;
using System.Data;

namespace KorisnickiInterfejs
{
     public partial class DoktorTabelarni : System.Web.UI.Page
     {
          private void NapuniGrid(DataSet ds)
          {
               // povezivanje grida sa datasetom
               gvSpisakDoktora.DataSource = ds.Tables[0];
               gvSpisakDoktora.DataBind();
          }
          protected void Page_Load(object sender, EventArgs e)
          {

          }

          protected void btnFiltriraj_Click(object sender, EventArgs e)
          {
               KlasePodataka.clsDoktorDB objDoktorDB = new KlasePodataka.clsDoktorDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
               if(txbFilter.Text!= "")
               {
                    NapuniGrid(objDoktorDB.DajDoktoraPoPrezimenu(txbFilter.Text));
                    lblStatus.Text = "Filtrirano!";
               }
               else lblStatus.Text= "Potrebno je uneti Prezime";
          }

          protected void btnSvi_Click(object sender, EventArgs e)
          {
               KlasePodataka.clsDoktorDB objDoktorDB = new KlasePodataka.clsDoktorDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
               NapuniGrid(objDoktorDB.DajSveDoktore());
          }
     }
}