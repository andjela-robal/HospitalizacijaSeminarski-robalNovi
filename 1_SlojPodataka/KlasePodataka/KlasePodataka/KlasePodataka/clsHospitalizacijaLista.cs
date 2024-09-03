using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
     public class clsHospitalizacijaLista
     {       
          // atributi
          private List<clsHospitalizacija> pListaHospitalizacija;

          // property
          public List<clsHospitalizacija> ListaHospitalizacija
          {
               get
               {
                    return pListaHospitalizacija;
               }
               set
               {
                    if (this.pListaHospitalizacija != value)
                         this.pListaHospitalizacija = value;
               }
          }

          // konstruktor
          public clsHospitalizacijaLista()
          {
               pListaHospitalizacija = new List<clsHospitalizacija>();

          }

          // privatne metode

          // javne metode
          public void DodajElementListe(clsHospitalizacija objNovaHospitalizacija)
          {
               pListaHospitalizacija.Add(objNovaHospitalizacija);
          }

          public void ObrisiElementListe(clsHospitalizacija objHospitalizacijaZaBrisanje)
          {
               pListaHospitalizacija.Remove(objHospitalizacijaZaBrisanje);
          }

          public void ObrisiElementNaPoziciji(int pozicija)
          {
               pListaHospitalizacija.RemoveAt(pozicija);
          }

          public void IzmeniElementListe(clsHospitalizacija objStaraHospitalizacija, clsHospitalizacija objNovaHospitalizacija)
          {
               int indexStareHospitalizacije = 0;
               indexStareHospitalizacije = pListaHospitalizacija.IndexOf(objStaraHospitalizacija);
               pListaHospitalizacija.RemoveAt(indexStareHospitalizacije);
               pListaHospitalizacija.Insert(indexStareHospitalizacije, objNovaHospitalizacija);
          }


     }
}
