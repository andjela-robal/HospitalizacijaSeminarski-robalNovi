using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace WSDoktori
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
          public DataSet DajSveDoktore()
          {
               DataSet dsDoktora = new DataSet();
               dsDoktora.ReadXml(Server.MapPath("~/") + "XML/Doktori.XML");

               return dsDoktora;
          }


          [WebMethod]
          public string DajDoktora(string jmbg)
          {
               string ImePrezimeDoktora = "";
               DataSet dsDoktori = new DataSet();
               dsDoktori.ReadXml(Server.MapPath("~/") + "XML/Doktori.XML");
               // filtriranje dataset-a
               DataRow[] result = dsDoktori.Tables[0].Select("Jmbg='" + jmbg + "'");
               if (result.Length > 0)
               {
                    string ime = result[0]["Ime"].ToString();
                    string prezime = result[0]["Prezime"].ToString();
                    ImePrezimeDoktora = ime + " " + prezime;
               }

               return ImePrezimeDoktora;
          }

          [WebMethod]
          public string DajJmbgDoktora(string ime, string prezime)
          {
               string JmbgDoktora = "";
               DataSet dsDoktori = new DataSet();
               dsDoktori.ReadXml(Server.MapPath("~/") + "XML/Doktori.XML");
               // filtriranje dataset-a
               DataRow[] result = dsDoktori.Tables[0].Select("Ime='" + ime + "' AND Prezime='" + prezime + "'");
               JmbgDoktora = result[0].ItemArray[0].ToString();

               return JmbgDoktora;
          }
     }
}
