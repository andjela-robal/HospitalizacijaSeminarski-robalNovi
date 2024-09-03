using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using KlasePodataka;


namespace PrezentacionaLogika
{
     public class clsFormaHospitalizacijaUnos
     {
          // atributi
          private string pStringKonekcije;
          private string pID;
          private string pJmbgPacijenta;
          private DateTime pDatumPrijema;
          private DateTime pDatumOtpusta;
          private string pIDUputa;

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
          public string IDUputa
          {
               get { return pIDUputa; }
               set { pIDUputa = value; }
          }

          // konstruktor
          public clsFormaHospitalizacijaUnos(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
          }

          // private metode

          // public metode
          public DataSet DajPodatkeZaCombo()
          {
               DataSet dsPodaci = new DataSet();
               clsUputDB objUputDB = new clsUputDB(pStringKonekcije);

               dsPodaci = objUputDB.DajSveUpute();

               return dsPodaci;
          }

          public void PopuniJmbgPacijentaPoIDUputa()
          {
               if (!string.IsNullOrEmpty(pIDUputa))
               {
                    clsUputDB objUputDB = new clsUputDB(pStringKonekcije);
                    pJmbgPacijenta = objUputDB.DajJmbgPacijentaPoID(pIDUputa);
               }
          }


          public bool DaLiJeSvePopunjeno()
          {
               bool SvePopunjeno = false;


               if ((pID.Length > 0) && (pJmbgPacijenta.Length > 0) && (pDatumPrijema != default(DateTime))
                    && (pDatumOtpusta != default(DateTime)) && (!pIDUputa.Equals("Izaberite...")))
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
               clsHospitalizacijaDB objHospitalizacijaDB = new clsHospitalizacijaDB(pStringKonekcije);
               dsPodaci = objHospitalizacijaDB.DajHospitalizacijuPoID(pID);

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

               clsHospitalizacijaDB objHospitalizacijaDB = new clsHospitalizacijaDB(pStringKonekcije);

               clsHospitalizacija objNovaHospitalizacija = new clsHospitalizacija();
               objNovaHospitalizacija.ID = pID;
               objNovaHospitalizacija.JmbgPacijenta = pJmbgPacijenta;
               objNovaHospitalizacija.DatumPrijema = pDatumPrijema;
               objNovaHospitalizacija.DatumOtpusta = pDatumOtpusta;

               clsUput objUput = new clsUput();

               clsUputDB objUputDB = new clsUputDB(pStringKonekcije);
               objUput.ID = pIDUputa;

               objNovaHospitalizacija.Uput = objUput;

               uspehSnimanja = objHospitalizacijaDB.SnimiNovuHospitalizaciju(objNovaHospitalizacija);


               return uspehSnimanja;
          }

     }
}
