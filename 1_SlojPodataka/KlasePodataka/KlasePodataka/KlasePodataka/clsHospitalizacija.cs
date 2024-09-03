using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
     public class clsHospitalizacija
     {
          // atributi
          private string pID;
          private string pJmbgPacijenta;
          private DateTime pDatumPrijema;
          private DateTime pDatumOtpusta;
          private clsUput objUput;

          // property

          public string ID
          {
               get { return pID; }
               set { pID = value; }
          }

          public string JmbgPacijenta
          {
               get { return pJmbgPacijenta; }
               set { pJmbgPacijenta = value; }
          }

          public DateTime DatumPrijema
          {
               get { return pDatumPrijema; }
               set { pDatumPrijema = value; }
          }
          public DateTime DatumOtpusta
          {
               get { return pDatumOtpusta; }
               set { pDatumOtpusta = value; }
          }

          public clsUput Uput
          {
               get { return objUput; }
               set { objUput = value; }
          }
     }
}
