using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsUput
    {
        // atributi
        private string pID;
        private string pJmbg;
        private string pIme;
        private string pPrezime;
        private string pPol;
        private DateTime pDatumUputa;
        private string pDijagnoza;
        private clsDoktor objDoktor;

          // property

          public string ID
        {
             get { return pID; }
             set { pID = value; }
        }

          public string Jmbg
        {
            get { return pJmbg; }
            set { pJmbg = value; }
        }

          public string Ime
        {
            get { return pIme; }
            set { pIme = value; }
        }

        public string Prezime
        {
            get { return pPrezime; }
            set { pPrezime = value; }
        }

        public string Pol
        {
            get { return pPol; }
            set { pPol = value; }
        }
        
        public DateTime DatumUputa
        {
            get { return pDatumUputa; }
            set { pDatumUputa = value; }
        }
          public string Dijagnoza
          {
               get { return pDijagnoza; }
               set { pDijagnoza = value; }
          }

          public clsDoktor Doktor
        {
            get { return objDoktor; }
            set { objDoktor = value; }
        }
    }
}
