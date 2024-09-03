using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DBUtils;
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class clsKorisnikDB : clsTabela
    {

        // atributi
        private DataSet dsKorisnici;

        // konstruktor
        public clsKorisnikDB(string NoviStringKonekcije)
               : base(new clsKonekcija(NoviStringKonekcije), "Korisnik")

        {
               dsKorisnici = new DataSet();
          }

        // privatne metode

        // javne metode
        public DataSet DajKorisnikaPoKorisnickomImenuISifri(string pomKorisnickoIme, string pomSifra)
        {
               // Upit za stored procedure
               string selectUpit = "EXEC DajKorisnikaPoKorisnickomImenuISifri @KorisnickoIme, @Sifra";

               selectUpit = selectUpit.Replace("@KorisnickoIme", $"'{pomKorisnickoIme}'");
               selectUpit = selectUpit.Replace("@Sifra", $"'{pomSifra}'");

               dsKorisnici = this.DajPodatke(selectUpit);
               return dsKorisnici;
          }
    }
}
