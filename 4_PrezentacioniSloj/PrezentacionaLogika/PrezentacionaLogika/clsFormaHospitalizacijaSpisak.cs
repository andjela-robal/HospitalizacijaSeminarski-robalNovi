using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
     public class clsFormaHospitalizacijaSpisak
     {
          // atributi
          private string pStringKonekcije;

          // property

          // konstruktor
          public clsFormaHospitalizacijaSpisak(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
          }

          // private metode

          // public metode
          public DataSet DajPodatkeZaGrid(string filter)
          {
               DataSet dsPodaci = new DataSet();
               clsHospitalizacijaDB objHospitalizacijaDB = new clsHospitalizacijaDB(pStringKonekcije);
               if (filter.Equals(""))
               {
                    dsPodaci = objHospitalizacijaDB.DajSveHospitalizacije();
               }
               else
               {
                    dsPodaci = objHospitalizacijaDB.DajHospitalizacijuPoJmbgPacijenta(filter);
               }
               return dsPodaci;
          }
     }
}
