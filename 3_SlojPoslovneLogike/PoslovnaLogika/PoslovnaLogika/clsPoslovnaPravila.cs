using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

using KlasePodataka;
using KlaseMapiranje;


namespace PoslovnaLogika
{
     public class clsPoslovnaPravila
     {
          private string pStringKonekcije;
          private clsMaper objMaper;

          public clsPoslovnaPravila(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
               objMaper = new clsMaper(pStringKonekcije);
          }


          public bool DaLiJeMoguceIzdavanjeUputa(string JmbgDoktora)
          {

               //Poslovno pravilo: Jedan doktor može izdati određeni broj uputa svaki dan.
               bool mogucaRegistracija = false;

               // 1. Postavljanje mapera i veze sa servisom
               clsDoktorDB objDoktorDB = new clsDoktorDB(pStringKonekcije);
               string IDDoktoraWS = objMaper.DajIDDoktoraZaWebServis(JmbgDoktora);

               // 2. Dobijamo ograničenje preko servisa
               WSBolnickiPodaci.Service1SoapClient objOgranicenja = new WSBolnickiPodaci.Service1SoapClient();
               string maxBrojUputaStr = objOgranicenja.DajMaxBrojUputaNaDan(IDDoktoraWS);

               int maxBrojUputa;
               if (int.TryParse(maxBrojUputaStr, out maxBrojUputa))
               {
                    // 3. Dobijamo broj unešenih uputa danas
                    DateTime danas = DateTime.Now.Date;
                    int trenutanBrojUputa = objDoktorDB.DajBrojUputaNaDan(JmbgDoktora, danas);

                    // 4. Upozorenje: Ograničenje 
                    if (trenutanBrojUputa < maxBrojUputa)
                    {
                         mogucaRegistracija = true;
                    }
                    else
                    {
                         mogucaRegistracija = false;
                    }
               }
               else
               {
                    // Logovanje ili obrada greške ako je rezultat ID doktora umesto broja uputa
                    Trace.WriteLine($"Greška: Metoda DajMaxBrojUputaNaDan je vratila ID doktora '{maxBrojUputaStr}' umesto broja uputa.");
               }

               return mogucaRegistracija;
          }

          public void DodajMaxBrojUputaZaNovogDoktora(string jmbgDoktora)
          {
               //Poslovno pravilo: Za novog doktora je podrazumevani maksimalni broj uputa 10
               // Koristino maper za ID doktora za web servis
               string idDoktora = objMaper.DajIDDoktoraZaWebServis(jmbgDoktora);

               // Učitavanje XML-a
               string xmlPath = @"D:\SCHOOL projects\HospitalizacijaSeminarski\2_SlojServisa\WebServis\BolnickiPodaci\BolnickiPodaci\XML\OgranicenjaSistematizacije.XML";
               DataSet dsOgranicenja = new DataSet();
               dsOgranicenja.ReadXml(xmlPath);

               // Provera da li doktor već postoji u XML-u
               DataRow[] postojeciDoktor = dsOgranicenja.Tables[0].Select($"IDDoktora='{idDoktora}'");

               if (postojeciDoktor.Length == 0)
               {
                    // Dodavanje novi red
                    DataRow newRow = dsOgranicenja.Tables[0].NewRow();
                    newRow["IDDoktora"] = idDoktora;
                    newRow["MaxBrUputaNaDan"] = 10; // Podrazumevani broj uputa
                    dsOgranicenja.Tables[0].Rows.Add(newRow);

                    // Čuvanje promena u XML
                    dsOgranicenja.WriteXml(xmlPath);
               }
          }
     }

}
