using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace step2
{
    class dziedzina
    {
        private string nazwa;
        private string[] klucze;
        private int zbieznosc;

        public dziedzina(string a, string[] b)
        {
            nazwa = a;
            klucze = b;
            zbieznosc = 0;
        }

        public string dajNazwe()
        {
            return nazwa;
        }

        public int dajZbieznosc()
        {
            return zbieznosc;
        }

        public void porownaj(List<slowo> slowa)
        {
            foreach (string k in klucze)
            {
                slowo s = slowa.Select(n => n).Where(x => x.dajSlowo() == k).FirstOrDefault();
                if (s != null)
                {
                    zbieznosc += s.dajIle();
                }
            }
        }
    }
}
