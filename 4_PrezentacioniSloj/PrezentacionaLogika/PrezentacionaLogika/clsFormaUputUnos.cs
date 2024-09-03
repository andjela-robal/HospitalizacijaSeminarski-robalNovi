using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using KlasePodataka;
using PoslovnaLogika;


namespace PrezentacionaLogika
{
     public class clsFormaUputUnos
     {
          // atributi
          private string pStringKonekcije;
          private string pID;
          private string pJmbgPacijenta;
          private string pIme;
          private string pPrezime;
          private string pPol;
          private string pDijagnoza;
          private DateTime pDatumUputa;
          private string pImeIPrezimeDoktora;
          private string pImeDoktora;
          private string pPrezimeDoktora;

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
          public string ImeIPrezimeDoktora
          {
           get { return pImeIPrezimeDoktora; }
           set
          {
                  pImeIPrezimeDoktora = value;
                  PostaviImePrezimeDoktora();
              }
          }

           public string ImeDoktora
         {
             get { return pImeDoktora; }
             private set { pImeDoktora = value; }
         }

         public string PrezimeDoktora
         {
             get { return pPrezimeDoktora; }
             private set { pPrezimeDoktora = value; }
         }

    // metoda za postavljanje imena i prezimena doktora
    private void PostaviImePrezimeDoktora()
    {
        if (!string.IsNullOrEmpty(pImeIPrezimeDoktora))
        {
            string[] imeIPrezime = pImeIPrezimeDoktora.Split(' ');
            if (imeIPrezime.Length == 2)
            {
                pImeDoktora = imeIPrezime[0];
                pPrezimeDoktora = imeIPrezime[1];
            }
            else
            {
                // Ako ime i prezime nisu pravilno podeljeni
                pImeDoktora = null;
                pPrezimeDoktora = null;
            }
        }
        else
        {
            pImeDoktora = null;
            pPrezimeDoktora = null;
        }
    }

          // konstruktor
          public clsFormaUputUnos(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
          }

          // private metode

          // public metode
          public DataSet DajPodatkeZaCombo()
          {
               DataSet dsPodaci = new DataSet();
               clsDoktorDB objDoktorDB = new clsDoktorDB(pStringKonekcije);

               dsPodaci = objDoktorDB.DajSveDoktore();
               if (dsPodaci.Tables.Count > 0)
               {
                    DataTable dt = dsPodaci.Tables[0];
                    dt.Columns.Add("Ime i Prezime", typeof(string), "Ime + ' ' + Prezime");
               }

               return dsPodaci;
          }

          public bool DaLiJeSvePopunjeno()
          {
               bool SvePopunjeno = false;


               if ((pID.Length > 0) && (pJmbgPacijenta.Length > 0) && (pIme.Length > 0) && (pPrezime.Length > 0) && (pIme.Length > 0) && (!pPol.Equals("Izaberite..."))
                    && (pDatumUputa != default(DateTime)) && (pDijagnoza.Length > 0) && (!pImeIPrezimeDoktora.Equals("Izaberite...")))
               {
                    SvePopunjeno = true;
               }
               else
               {
                    SvePopunjeno = false;
               }

               return SvePopunjeno;
          }


          public bool DaLiJeJedinstvenZapis()
          {
               bool JedinstvenZapis = false;
               DataSet dsPodaci = new DataSet();
               clsUputDB objUputDB = new clsUputDB(pStringKonekcije);
               dsPodaci = objUputDB.DajUputPoID(pID);

               if (dsPodaci.Tables[0].Rows.Count == 0)
               {
                    JedinstvenZapis = true;
               }
               else
               {
                    JedinstvenZapis = false;
               }

               return JedinstvenZapis;

          }

          public bool SnimiPodatke()
          {
               bool uspehSnimanja = false;

               clsUputDB objUputDB = new clsUputDB(pStringKonekcije);

               clsUput objNoviUput = new clsUput();
               objNoviUput.ID = pID;
               objNoviUput.Jmbg = pJmbgPacijenta;
               objNoviUput.Ime = pIme;
               objNoviUput.Prezime = pPrezime;
               objNoviUput.Pol = pPol;
               objNoviUput.Dijagnoza = pDijagnoza;
               objNoviUput.DatumUputa = pDatumUputa;

               clsDoktor objDoktor = new clsDoktor();
               clsDoktorDB objDoktorDB = new clsDoktorDB(pStringKonekcije);

               objDoktor.Jmbg = objDoktorDB.DajJmbgDoktoraPoImenuIPrezimenu(pImeDoktora, pPrezimeDoktora).ToString();
               objDoktor.Ime = pImeDoktora;
               objDoktor.Prezime = pPrezimeDoktora;

               objNoviUput.Doktor = objDoktor;

               uspehSnimanja = objUputDB.SnimiNoviUput(objNoviUput);


               return uspehSnimanja;
          }

          public bool DaLiSuPodaciUskladjeniSaPoslovnimPravilima()
          {
               
               // POSLOVNO PRAVILO:
               // Jedan doktor može izdati određeni broj uputa svaki dan. 
               // Podrazumevani limit je 10 uputa na jedan dan.
               bool UskladjeniPodaci = false;

               clsPoslovnaPravila objPoslovnaPravila = new clsPoslovnaPravila(pStringKonekcije);

               //izracunavanje Jmbg doktora
               clsDoktorDB objDoktorDB = new clsDoktorDB(pStringKonekcije);
               string JmbgDoktora = objDoktorDB.DajJmbgDoktoraPoImenuIPrezimenu(ImeDoktora, PrezimeDoktora);

               UskladjeniPodaci = objPoslovnaPravila.DaLiJeMoguceIzdavanjeUputa(JmbgDoktora);

               return UskladjeniPodaci;
               
          }
          
     }
}
