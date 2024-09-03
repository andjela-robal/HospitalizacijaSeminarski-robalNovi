using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Diagnostics;

using System.Data;
using KlaseMapiranje;


namespace BolnickiPodaci
{
     /// <summary>
     /// Summary description for Service1
     /// </summary>
     [WebService(Namespace = "http://tempuri.org/")]
     [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
     [System.ComponentModel.ToolboxItem(false)]
     // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     // [System.Web.Script.Services.ScriptService]
     public class Service1 : System.Web.Services.WebService
     {

          [WebMethod]
          public DataSet DajSvaOgranicenja()
          {
               DataSet dsOgranicenja = new DataSet();
               dsOgranicenja.ReadXml(Server.MapPath("~/") + "XML/OgranicenjaSistematizacije.XML");

               return dsOgranicenja;
          }


          [WebMethod]
          public string DajMaxBrojUputaNaDan(string pomIDDoktora)
          {
               string rezultat = pomIDDoktora; // Inicijalno postavite rezultat na ID doktora
               try
               {
                    DataSet dsOgranicenja = new DataSet();
                    dsOgranicenja.ReadXml(Server.MapPath("~/") + "XML/OgranicenjaSistematizacije.XML");

                    // Filtriranje DataSet-a
                    DataRow[] result = dsOgranicenja.Tables[0].Select("IDDoktora='" + pomIDDoktora + "'");

                    if (result.Length > 0)
                    {
                         // Pretvorite rezultat u broj i vratite kao string
                         int maxBrojUputa = int.Parse(result[0].ItemArray[1].ToString());
                         rezultat = maxBrojUputa.ToString();
                    }
               }
               catch (Exception ex)
               {
                    // Zapisivanje greške kao trace
                    Trace.WriteLine($"Greška u metodi DajMaxBrojUputaNaDan: {ex.Message}");
               }

               return rezultat;
          }
     }
}
