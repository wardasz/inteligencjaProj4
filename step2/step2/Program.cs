using System;
using System.Collections.Generic;
using System.Linq;

namespace step2
{
    class Program
    {
        static List<slowo> slowa = new List<slowo>();
        static List<dziedzina> dziedziny = new List<dziedzina>();       

        static void Main(string[] args)
        {
            utwozDziedziny();
            //wersja pc
            //string text = System.IO.File.ReadAllText(@"D:\studia\magisterka\sem1\inteligencja\proj4\inteligencjaProj4\oczyszczony.txt");
            //wersja laptop
            string text = System.IO.File.ReadAllText(@"D:\studia\sem1\inteligencja\proj4\inteligencjaProj4\oczyszczony.txt");
            string[] words = text.Split(' ');

            foreach(string s in words)
            {
                slowo sl = slowa.Select(n => n).Where(x => x.dajSlowo() == s).FirstOrDefault();
                if (sl == null)
                {
                    slowa.Add(new slowo(s));
                }
                else
                {
                    sl.podbij();
                }
            }

            foreach(slowo s in slowa)
            {
                Console.WriteLine(s.dajSlowo() + " " + s.dajIle());
            }

            foreach(dziedzina d in dziedziny)
            {
                d.porownaj(slowa);
            }

            dziedzina winer = new dziedzina("nicosc", new string[] { "pustka"});
            foreach(dziedzina d in dziedziny)
            {
                Console.WriteLine("Artykół zawieraz " + d.dajZbieznosc() + " słów z dziedziny " + d.dajNazwe());
                if (d.dajZbieznosc() > winer.dajZbieznosc()) { winer = d; }
            }

            Console.WriteLine("Najprawdopodobniej artykuł należy do kategorii " + winer.dajNazwe());


            Console.ReadKey();
        }


        public static void utwozDziedziny()
        {
            string[] tmp;
            dziedzina TMP;
            tmp = new string[]{ "ala"};
            TMP = new dziedzina("alizm", tmp);
            dziedziny.Add(TMP);
            tmp = new string[] { "kot" };
            TMP = new dziedzina("kotyzm", tmp);
            dziedziny.Add(TMP);
            tmp = new string[] { "ma" };
            TMP = new dziedzina("posiadanie", tmp);
            dziedziny.Add(TMP);
        }

    }
}
