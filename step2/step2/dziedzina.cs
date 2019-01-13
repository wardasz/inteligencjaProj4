using System;
using System.Collections.Generic;
using System.Text;

namespace step2
{
    class dziedzina
    {
        private string nazwa;
        private int moc;

        public dziedzina(string a, int b)
        {
            nazwa = a;
            moc = b;
        }

        public string dajNazwe()
        {
            return nazwa;
        }

        public int dajMoc()
        {
            return moc;
        }
    }
}
