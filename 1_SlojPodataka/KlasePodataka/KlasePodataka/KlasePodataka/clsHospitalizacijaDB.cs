using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data;
using System.Data.SqlClient;
using DBUtils;

namespace KlasePodataka
{
     public class clsHospitalizacijaDB : clsTabela
     {
          // atributi
          private DataSet dsHospitalizacije;

          // property
          // konstruktor
          public clsHospitalizacijaDB(string NoviStringKonekcije)
                 : base(new clsKonekcija(NoviStringKonekcije), "Hospitalizacija")
          {
               dsHospitalizacije = new DataSet();
          }

          // privatne metode

          // javne metode
          public DataSet DajSveHospitalizacije()
          {
               // Upit za clsTabela metodu
               string selectUpit = "SELECT * FROM DajSveHospitalizacijeSaJoinIDUputa";

               dsHospitalizacije = this.DajPodatke(selectUpit);
               return dsHospitalizacije;
          }

          public DataSet DajHospitalizacijuPoJmbgPacijenta(string JmbgPacijenta)
          {
               string selectUpit = "EXEC DajHospitalizacijuPoJmbgPacijenta @JmbgPacijenta = '" + JmbgPacijenta + "'";
               dsHospitalizacije = this.DajPodatke(selectUpit);
               return dsHospitalizacije;
          }


          public DataSet DajHospitalizacijuPoID(string ID)
          {
               string selectUpit = "EXEC DajHospitalizacijuPoID @IDHospitalizacije = '" + ID + "'";
               dsHospitalizacije = this.DajPodatke(selectUpit);
               return dsHospitalizacije;
          }

          public bool SnimiNovuHospitalizaciju(clsHospitalizacija objNovaHospitalizacija)
          {
               bool uspeh = false;
               string SnimanjeUpit = $"EXEC DodajNovuHospitalizaciju '{objNovaHospitalizacija.ID}', '{objNovaHospitalizacija.JmbgPacijenta}', '{objNovaHospitalizacija.DatumPrijema.ToString("yyyy-MM-dd")}', " +
                    $" '{objNovaHospitalizacija.DatumOtpusta}',  '{objNovaHospitalizacija.Uput.ID}'";
               uspeh = this.IzvrsiAzuriranje(SnimanjeUpit);
               return uspeh;

          }

     }
}
