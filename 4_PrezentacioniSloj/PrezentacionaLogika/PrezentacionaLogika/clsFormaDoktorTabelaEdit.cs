using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
     public class clsFormaDoktorTabelaEdit
     {
          // atributi
        private string pStringKonekcije;

          // property

          // konstruktor
          public clsFormaDoktorTabelaEdit(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
          }

          // private metode

          // public metode
          public DataSet DajPodatkeZaGrid(string filter)
          {
               DataSet dsPodaci = new DataSet();
               clsDoktorDB objDoktorDB = new clsDoktorDB(pStringKonekcije);
               if (filter.Equals(""))
               {
                    dsPodaci = objDoktorDB.DajSveDoktore();
               }
               else
               {
                    dsPodaci = objDoktorDB.DajDoktoraPoPrezimenu(filter);
               }
               return dsPodaci;
          }
     }
}
