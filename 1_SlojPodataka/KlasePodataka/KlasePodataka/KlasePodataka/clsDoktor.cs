using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
     public class clsDoktor
     {
          // atributi
          private string pJmbg;
          private string pIme;
          private string pPrezime;

          // property
          public string Jmbg
          {
               get
               {
                    return pJmbg;
               }
               set
               {
                    if (this.pJmbg != value)
                         this.pJmbg = value;
               }
          }

          public string Ime
          {
               get
               {
                    return pIme;
               }
               set
               {
                    if (this.pIme != value)
                         this.pIme = value;
               }
          }

          public string Prezime
          {
               get
               {
                    return pPrezime;
               }
               set
               {
                    if (this.pPrezime != value)
                         this.pPrezime = value;
               }
          }


          // konstruktor
          public clsDoktor()
          {
               pJmbg = "";
               pIme = "";
               pPrezime = "";
          }

          // privatne metode

          // javne metode
     }
}
