using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;
using DBUtils;

namespace KlasePodataka
{
    public class clsUputDB : clsTabela
    {
        // atributi
        private DataSet dsUputi;

        // property
        // konstruktor
        public clsUputDB(string NoviStringKonekcije)
               : base(new clsKonekcija(NoviStringKonekcije), "Uput")
        {
               dsUputi = new DataSet();
          }

        // privatne metode

        // javne metode
        public DataSet DajSveUpute()
        {
               // Upit za clsTabela metodu
               string selectUpit = "SELECT * FROM DajSveUputeSaJoin";

               dsUputi = this.DajPodatke(selectUpit);
               return dsUputi;
          }

        public DataSet DajUputPoPrezimenuPacijenta(string Prezime)
        {
               string selectUpit = "EXEC DajUputPoPrezimenuPacijenta @PacijentPrezime = '" + Prezime + "'";
               dsUputi = this.DajPodatke(selectUpit);
               return dsUputi;
          }


        public DataSet DajUputPoID(string ID)
        {
               string selectUpit = "EXEC DajUputPoID @ID = '" + ID + "'";
               dsUputi = this.DajPodatke(selectUpit);
               return dsUputi;
        }


        public string DajJmbgPacijentaPoID (string ID)
        {
               string jmbgPacijenta;
               DataSet dsRezultat = this.DajPodatke("EXEC DajJmbgPacijentaPoID @ID = '" + ID + "'");
               jmbgPacijenta = (dsRezultat.Tables[0].Rows[0].ItemArray[0].ToString());
               return jmbgPacijenta;

        }

        public int DajUkupnoUputaZaDoktora(string Jmbg)
        {
               int ukupnoDoktora=0;
               DataSet dsRezultat = this.DajPodatke("EXEC DajBrojUputaZaDoktora @JmbgDoktora = '" + Jmbg + "'");
               ukupnoDoktora = int.Parse(dsRezultat.Tables[0].Rows[0].ItemArray[0].ToString());

               return ukupnoDoktora;
        } 

        private clsUputLista DajListuSvihUputa()
        {
               clsUputLista objUputLista = new clsUputLista();

               DataSet dsPodaciUputa = this.DajPodatke("SELECT * FROM DajSveUputeSaJoinJmbgomDoktora");

               foreach (DataRow row in dsPodaciUputa.Tables[0].Rows)
               {
                    clsDoktor objDoktor = new clsDoktor
                    {
                         Jmbg = row["JmbgDoktora"].ToString()
                    };

                    string celoImeDoktora = row["ImeDoktora"].ToString();
                    string[] imePrezime = celoImeDoktora.Split(' ');

                    if (imePrezime.Length > 1)
                    {
                         objDoktor.Ime = imePrezime[0];
                         objDoktor.Prezime = imePrezime[1];
                    }

                    clsUput objUput = new clsUput
                    {
                         ID = row["ID"].ToString(),
                         Jmbg = row["JmbgPacijenta"].ToString(),
                         Ime = row["ImePacijenta"].ToString(),
                         Prezime = row["PrezimePacijenta"].ToString(),
                         Pol = row["PolPacijenta"].ToString(),
                         DatumUputa = Convert.ToDateTime(row["DatumUputa"]),
                         Dijagnoza = row["Dijagnoza"].ToString(),
                         Doktor = objDoktor
                    };

                    objUputLista.DodajElementListe(objUput);
               }

               return objUputLista;
          }


          public bool SnimiNoviUput(clsUput objNoviUput)
        {
               bool uspeh = false;
               string SnimanjeUpit = $"EXEC DodajNoviUput '{objNoviUput.ID}', '{objNoviUput.Jmbg}', '{objNoviUput.Ime}', '{objNoviUput.Prezime}'," +
                    $" '{objNoviUput.Pol}', '{objNoviUput.DatumUputa.ToString("yyyy-MM-dd")}', '{objNoviUput.Dijagnoza}', '{objNoviUput.Doktor.Jmbg}'";
               uspeh = this.IzvrsiAzuriranje(SnimanjeUpit);
               return uspeh;

          }

        public bool ObrisiUput(string IDUputaZaBrisanje)
        {
               bool uspeh= false;

               string brisanjeUpit = $"EXEC ObrisiUput @ID = '{IDUputaZaBrisanje}'";
               uspeh = this.IzvrsiAzuriranje(brisanjeUpit);

               return uspeh;

        }

        public bool IzmeniUput(clsUput objStariUput, clsUput objNoviUput)
        {
               bool uspeh = false;

               string azuriranjeUpit = $"EXEC IzmeniUput '{objStariUput.ID}', '{objNoviUput.ID}', '{objNoviUput.Jmbg}', '{objNoviUput.Ime}', " +
                    $"'{objNoviUput.Prezime}', '{objNoviUput.Pol}', '{objNoviUput.DatumUputa.ToString("yyyy-MM-dd")}', '{objNoviUput.Doktor.Jmbg}'";
               uspeh = this.IzvrsiAzuriranje(azuriranjeUpit);
               return uspeh;

          }

        


    }
}
