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
     public partial class DoktorTabelaEdit : System.Web.UI.Page
     {
          private void NapuniGrid(DataSet ds)
          {
               gvSpisakDoktoraEdit.DataSource = ds.Tables[0];
               gvSpisakDoktoraEdit.DataBind();
          }
          protected void Page_Load(object sender, EventArgs e)
          {
               try
               {
                    if (!IsPostBack)
                    {
                         clsFormaDoktorTabelaEdit objFormaDoktorTabelaEdit = new clsFormaDoktorTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                         DataSet ds = objFormaDoktorTabelaEdit.DajPodatkeZaGrid("");
                         if (ds != null && ds.Tables.Count > 0)
                         {
                              NapuniGrid(ds);
                         }
                         else
                         {
                             
                         }
                    }
               }
               catch (Exception ex)
               {
                    // Loguj grešku ili prikaži poruku o grešci
                    // Na primer:
                    // lblError.Text = "Greška: " + ex.Message;
               }
          }

          protected void gvSpisakDoktoraEdit_SelectedIndexChanged(object sender, EventArgs e)
          {
               Response.Redirect("DoktorDetaljiEdit.aspx?Jmbg=" + gvSpisakDoktoraEdit.Rows[gvSpisakDoktoraEdit.SelectedIndex].Cells[1].Text);
          } 
     }
}