using System;
using System.Collections.Generic;
using System.Text;

namespace step2
{
    class slowo
    {
        private string nazwa;
        private int ile;

        public slowo(string a)
        {
            nazwa = a;
            ile = 1;
        }

        public string dajSlowo()
        {
            return nazwa;
        }

        public int dajIle()
        {
            return ile;
        }

        public void podbij()
        {
            ile++;
        }
    }
}
