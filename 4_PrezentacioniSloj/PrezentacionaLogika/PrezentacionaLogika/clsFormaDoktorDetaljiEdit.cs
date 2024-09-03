using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
     public class clsFormaDoktorDetaljiEdit
     {
          // atributi i property
          private string pStringKonekcije;
          private clsDoktorDB objDoktorDB;

          private clsDoktor objPreuzetiDoktor;
          private clsDoktor objIzmenjeniDoktor;

          private string pJmbgPreuzetogDoktora;
          private string pImePreuzetogDoktora;
          private string pPrezimePreuzetogDoktora;

          private string pJmbgIzmenjenogDoktora;
          private string pImeIzmenjenogDoktora;
          private string pPrezimeIzmenjenogDoktora;

          private string pImeIPrezimePreuzetogDoktora;
          private string pImeIPrezimeIzmenjenogDoktora;

          // PROPERTY

          public string JmbgPreuzetogDoktora
          {
               get { return pJmbgPreuzetogDoktora; }
               set
               {
                    pJmbgPreuzetogDoktora = value;
                    pImeIPrezimePreuzetogDoktora = DajImeIPrezime(value);

                    // Podeli ime i prezime
                    string[] imeIPrezime = pImeIPrezimePreuzetogDoktora.Split(' ');
                    if (imeIPrezime.Length == 2)
                    {
                         pImePreuzetogDoktora = imeIPrezime[0];
                         pPrezimePreuzetogDoktora = imeIPrezime[1];
                    }
                    else
                    {
                         // Obrada greške ili inicijalizacija sa praznim vrednostima
                         pImePreuzetogDoktora = "";
                         pPrezimePreuzetogDoktora = "";
                    }
               }
          }

          public string ImePreuzetogDoktora
          {
               get { return pImePreuzetogDoktora; }
          }

          public string PrezimePreuzetogDoktora
          {
               get { return pPrezimePreuzetogDoktora; }
          }

          public string ImeIPrezimePreuzetogDoktora
          {
               get { return pImeIPrezimePreuzetogDoktora; }
          }

          public string JmbgIzmenjenogDoktora
          {
               get { return pJmbgIzmenjenogDoktora; }
               set { pJmbgIzmenjenogDoktora = value; }
          }

          public string ImeIzmenjenogDoktora
          {
               get { return pImeIzmenjenogDoktora; }
               set { pImeIzmenjenogDoktora = value; }
          }

          public string PrezimeIzmenjenogDoktora
          {
               get { return pPrezimeIzmenjenogDoktora; }
               set { pPrezimeIzmenjenogDoktora = value; }
          }

          public string ImeIPrezimeIzmenjenogDoktora
          {
               get { return pImeIPrezimeIzmenjenogDoktora; }
               set
               {
                    pImeIPrezimeIzmenjenogDoktora = value;

                    // Podeli ime i prezime
                    string[] imeIPrezime = value.Split(' ');
                    if (imeIPrezime.Length == 2)
                    {
                         pImeIzmenjenogDoktora = imeIPrezime[0];
                         pPrezimeIzmenjenogDoktora = imeIPrezime[1];
                    }
               }
          }

          // konstruktor
          public clsFormaDoktorDetaljiEdit(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
               objDoktorDB = new clsDoktorDB(pStringKonekcije);
          }

          // privatne metode
          private string DajImeIPrezime(string pomJmbg)
          {
               string pomImeIPrezime = "";
               DataSet dsPodaci = new DataSet();
               pomImeIPrezime = objDoktorDB.DajImeIPrezimePoJmbgDoktora(pomJmbg);
               return pomImeIPrezime;
              
          }

          // javne metode
          public bool ObrisiDoktora()
          {
               bool uspehBrisanja = false;
               uspehBrisanja = objDoktorDB.ObrisiDoktora(pJmbgPreuzetogDoktora);

               return uspehBrisanja;

          }

          public bool IzmeniDoktora()
          {
               bool uspehIzmene = false;
               objPreuzetiDoktor = new clsDoktor();
               objIzmenjeniDoktor = new clsDoktor();

               objPreuzetiDoktor.Jmbg = pJmbgPreuzetogDoktora;
               objPreuzetiDoktor.Ime = pImePreuzetogDoktora;
               objPreuzetiDoktor.Prezime = pPrezimePreuzetogDoktora;

               objIzmenjeniDoktor.Jmbg = pJmbgIzmenjenogDoktora;
               objIzmenjeniDoktor.Ime = pImeIzmenjenogDoktora;
               objIzmenjeniDoktor.Prezime = pPrezimeIzmenjenogDoktora;

               uspehIzmene = objDoktorDB.IzmeniDoktora(objPreuzetiDoktor, objIzmenjeniDoktor);

               return uspehIzmene;
          }
     }
}
