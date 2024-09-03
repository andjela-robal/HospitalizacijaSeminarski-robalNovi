using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;
using KlasePodataka;
using System.Data;

namespace PrezentacionaLogika
{
     public class clsFormaLogin
     {

          private string pStringKonekcije;

          private string pKorisnickoIme;

          public string KorisnickoIme
          {
               get { return pKorisnickoIme; }
               set { pKorisnickoIme = value; }
          }
          private string pSifra;

          public string Sifra
          {
               get { return pSifra; }
               set { pSifra = value; }
          }

          // konstruktor
          public clsFormaLogin(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
          }


          // javne metode
          public bool VazeciKorisnik()
          {
               bool vazeci = false;

               clsKorisnikDB objKorisnikDB = new clsKorisnikDB(pStringKonekcije);
               DataSet dsPodaci = objKorisnikDB.DajKorisnikaPoKorisnickomImenuISifri(pKorisnickoIme, pSifra);

               if (dsPodaci.Tables[0].Rows.Count > 0)
               // pronasao ga je u bazi
               {
                    vazeci = true;
                HttpContext.Current.Session["KorisnickoIme"] = pKorisnickoIme;
                HttpContext.Current.Session["ImePrezime"] = dsPodaci.Tables[0].Rows[0].ItemArray[2].ToString() + " " + dsPodaci.Tables[0].Rows[0].ItemArray[1].ToString();
 
               }
               else
               {
                    vazeci = false;
               }

               return vazeci;

          }

          public string DajImePrezimeKorisnika()
          {
               string ImePrezime = "";

               clsKorisnikDB objKorisnikDB = new clsKorisnikDB(pStringKonekcije);
               DataSet dsPodaci = objKorisnikDB.DajKorisnikaPoKorisnickomImenuISifri(pKorisnickoIme, pSifra);

               if (dsPodaci.Tables[0].Rows.Count > 0)
               // pronasao ga je u bazi
               {
                    ImePrezime = dsPodaci.Tables[0].Rows[0].ItemArray[2].ToString() + " " + dsPodaci.Tables[0].Rows[0].ItemArray[1].ToString();
               }
               return ImePrezime;

          }

            public void OdjaviKorisnika()
        {
            HttpContext.Current.Session.Abandon();
        }

        public bool DaLiJeSesijaAktivna()
        {
            return HttpContext.Current.Session["KorisnickoIme"] != null;
        }



     }
}
