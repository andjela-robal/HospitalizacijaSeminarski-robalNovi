using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasePodataka;

namespace KlaseMapiranje
{
     public class clsMaper
     {
          // atributi
          private string pStringKonekcije;

          // property

          // konstruktor
          public clsMaper(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
          }


          public string DajIDDoktoraZaWebServis(string JmbgDoktoraIzBazePodataka)
          {
               string IDDoktoraWS = "";
               clsDoktorDB objDoktorDB = new clsDoktorDB(pStringKonekcije);
               string imeDoktoraIzBazePodataka = objDoktorDB.DajImeIPrezimePoJmbgDoktora(JmbgDoktoraIzBazePodataka);

               if (!string.IsNullOrEmpty(imeDoktoraIzBazePodataka))
               {
                    string[] deloviImena = imeDoktoraIzBazePodataka.Split(' ');

                    if (deloviImena.Length >= 2)
                    {
                         string imeInicijal = deloviImena[0][0].ToString().ToLower();
                         string prezimeInicijal = deloviImena[1][0].ToString().ToLower();
                         IDDoktoraWS = imeInicijal + prezimeInicijal;
                    }
                    else
                    {
                         IDDoktoraWS = "greska";
                    }
               }
               else
               {
                    IDDoktoraWS = "greska";
               }

               return IDDoktoraWS;

          }

     }
}
