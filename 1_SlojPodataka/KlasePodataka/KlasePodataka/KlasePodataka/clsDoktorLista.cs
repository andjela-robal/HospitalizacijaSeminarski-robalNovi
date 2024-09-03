using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsDoktorLista
    {
        // atributi
        private List<clsDoktor> pListaDoktora; 

        // property
        public List<clsDoktor> ListaDoktora
        {
            get
            {
                return pListaDoktora;
            }
            set
            {
                if (this.pListaDoktora != value)
                    this.pListaDoktora = value;
            }
        }

        // konstruktor
        public clsDoktorLista()
        {
            pListaDoktora = new List<clsDoktor>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(clsDoktor objNoviDoktor)
        {
            pListaDoktora.Add(objNoviDoktor);
        }

        public void ObrisiElementListe(clsDoktor objDoktorZaBrisanje)
        {
            pListaDoktora.Remove(objDoktorZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaDoktora.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsDoktor objStariDoktor, clsDoktor objNoviDoktor)
        {
            int indexStarogDoktora = 0;
            indexStarogDoktora = pListaDoktora.IndexOf(objStariDoktor);  
            pListaDoktora.RemoveAt(indexStarogDoktora); 
            pListaDoktora.Insert(indexStarogDoktora, objNoviDoktor);   
        }

           

     




    }
}
