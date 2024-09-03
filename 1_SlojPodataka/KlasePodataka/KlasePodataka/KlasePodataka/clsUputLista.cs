using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsUputLista
    {

        // atributi
        private List<clsUput> pListaUputa; 

        // property
        public List<clsUput> ListaUputa
        {
            get
            {
                return pListaUputa;
            }
            set
            {
                if (this.pListaUputa != value)
                    this.pListaUputa = value;
            }
        }

        // konstruktor
        public clsUputLista()
        {
            pListaUputa = new List<clsUput>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(clsUput objNoviUput)
        {
            pListaUputa.Add(objNoviUput);
        }

        public void ObrisiElementListe(clsUput objUputZaBrisanje)
        {
            pListaUputa.Remove(objUputZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaUputa.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsUput objStariUput, clsUput objNoviUput)
        {
            int indexStarogUputa = 0;
            indexStarogUputa = pListaUputa.IndexOf(objNoviUput);
            pListaUputa.RemoveAt(indexStarogUputa);
            pListaUputa.Insert(indexStarogUputa, objNoviUput);   
        }

           
    }
}
