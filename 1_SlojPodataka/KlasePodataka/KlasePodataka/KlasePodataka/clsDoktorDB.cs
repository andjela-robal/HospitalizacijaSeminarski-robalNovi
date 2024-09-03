using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DBUtils;

namespace KlasePodataka
{
    public class clsDoktorDB : clsTabela
    {
        // atributi
        private DataSet dsDoktori;

        // property

        // konstruktor
        public clsDoktorDB(string NoviStringKonekcije)
               : base(new clsKonekcija(NoviStringKonekcije), "Doktor")
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
               dsDoktori = new DataSet();
        }

        // privatne metode

        // javne metode
        public DataSet DajSveDoktore()
        {
            // Upit za clsTabela metodu
            string selectUpit = "SELECT * FROM DajSveDoktore";

            dsDoktori = this.DajPodatke(selectUpit);
            return dsDoktori;
          }

        public string DajImeIPrezimePoJmbgDoktora(string JmbgDoktora)
        {
            string ImeIPrezimeDoktora = "";

               string selectUpit = $"EXEC DajDoktoraPoJmbg @JmbgDoktora = '" + JmbgDoktora + "'";
               DataSet dsRezultat = this.DajPodatke(selectUpit);

               if (dsRezultat.Tables[0].Rows.Count > 0)
               {
                    ImeIPrezimeDoktora= dsRezultat.Tables[0].Rows[0]["Ime Doktora"].ToString();
               }

            return ImeIPrezimeDoktora;
        }

        public string DajJmbgDoktoraPoImenuIPrezimenu(string ImeDoktora, string PrezimeDoktora)
        {
               string JmbgDoktora = "";
               string selectUpit = $"EXEC DajJmbgDoktoraPoImenuIPrezimenu @Ime = '{ImeDoktora}', @Prezime = '{PrezimeDoktora}'";
               DataSet dsRezultat = this.DajPodatke(selectUpit);

               if (dsRezultat.Tables[0].Rows.Count > 0)
               {
                     JmbgDoktora = dsRezultat.Tables[0].Rows[0]["Jmbg"].ToString();
               }

               return JmbgDoktora;
          }


          public DataSet DajDoktoraPoPrezimenu(string PrezimeDoktora)
        {
               string selectUpit = $"EXEC DajDoktoraPoPrezimenu @Prezime = '{PrezimeDoktora}'";
               dsDoktori = this.DajPodatke(selectUpit);

               return dsDoktori;
        }

        // overloading metoda - isto se zove, ima drugaciji parametar
        public DataSet DajDoktoraPoPrezimenu(clsDoktor objDoktorZaFilter)
        {
               string selectUpit = $"EXEC DajDoktoraPoPrezimenu @Prezime = '{objDoktorZaFilter.Prezime}'";
               dsDoktori = this.DajPodatke(selectUpit);

               return dsDoktori;
        }

        public bool SnimiNovogDoktora(clsDoktor objNoviDoktor)
        {
           bool uspeh = false;
           string unosUpit = $"INSERT INTO Doktor (Jmbg, Ime, Prezime) VALUES ('{objNoviDoktor.Jmbg}', " +
                    $"'{objNoviDoktor.Ime}', '{objNoviDoktor.Prezime}')";
           uspeh=this.IzvrsiAzuriranje(unosUpit);
           return uspeh;

          }

        public bool ObrisiDoktora(clsDoktor objDoktorZaBrisanje)
        {
            bool uspeh= false;

            string brisanjeUpit = $"EXEC ObrisiDoktora @JmbgDoktor = '{objDoktorZaBrisanje.Jmbg}'";
            uspeh = this.IzvrsiAzuriranje(brisanjeUpit);

            return uspeh;

         }

        // method overloading - ista procedura sa razlicitim parametrom
        public bool ObrisiDoktora(string JmbgDoktoraZaBrisanje)
        {
            bool uspeh = false;

            string deleteUpit = $"EXEC ObrisiDoktora @JmbgDoktor = '{JmbgDoktoraZaBrisanje}'";
            uspeh = this.IzvrsiAzuriranje(deleteUpit);

            return uspeh;

        }

        public bool IzmeniDoktora(clsDoktor objStariDoktor, clsDoktor objNoviDoktor)
        {
            bool uspeh= false;

            string azuriranjeUpit = $"EXEC IzmeniDoktora @StariJmbg = '{objStariDoktor.Jmbg}'," +
                    $" @JmbgDoktor = '{objNoviDoktor.Jmbg}', " +
                    $"@Ime = '{objNoviDoktor.Ime}', @Prezime = '{objNoviDoktor.Prezime}'";
            uspeh = this.IzvrsiAzuriranje(azuriranjeUpit);
            return uspeh;

        }

        // method overloading - ista metoda, samo drugaciji parametri
        public bool IzmeniDoktora(string JmbgStarogDoktora, clsDoktor objNoviDoktor)
        {
            bool uspeh = false;

            string updateUpit = $"EXEC IzmeniDoktora @StariJmbg = '{JmbgStarogDoktora}'," +
                    $" @JmbgDoktor = '{objNoviDoktor.Jmbg}', " +
                    $"@Ime = '{objNoviDoktor.Ime}', @Prezime = '{objNoviDoktor.Prezime}'";
            uspeh= this.IzvrsiAzuriranje(updateUpit);
            return uspeh;

          }

          public int DajBrojUputaNaDan(string jmbgDoktora, DateTime datum)
          {
               int brojUputa = 0;
               DataSet dsRezultat = new DataSet();

               string selectUpit = $"EXEC DajBrojUputaDoktoraPoDatumu @JmbgDoktora = '{jmbgDoktora}', " +
                    $"@DatumUputa = '{datum:yyyy-MM-dd}'";
               dsRezultat = this.DajPodatke(selectUpit);

               if (dsRezultat.Tables[0].Rows.Count > 0)
               {
                    brojUputa = int.Parse(dsRezultat.Tables[0].Rows[0][0].ToString());
               }

               return brojUputa;
          }


     }
}
