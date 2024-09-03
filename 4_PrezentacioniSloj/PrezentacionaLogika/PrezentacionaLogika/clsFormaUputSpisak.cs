using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
     public class clsFormaUputSpisak
     {
          // atributi
          private string pStringKonekcije;

          // property

          // konstruktor
          public clsFormaUputSpisak(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
          }

          // private metode

          // public metode
          public DataSet DajPodatkeZaGrid(string filter)
          {
               DataSet dsPodaci = new DataSet();
               clsUputDB objUputDB = new clsUputDB(pStringKonekcije);
               if (filter.Equals(""))
               {
                    dsPodaci = objUputDB.DajSveUpute();
               }
               else
               {
                    dsPodaci = objUputDB.DajUputPoPrezimenuPacijenta(filter);
               }
               return dsPodaci;
          }
     }
}
