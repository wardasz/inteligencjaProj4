using System;
using System.Collections.Generic;
using System.Linq;

namespace step2
{
    class Program
    {
        static List<slowo> slowa = new List<slowo>();
        static List<dziedzina> dziedziny = new List<dziedzina>();
        static string[] alizm = new string[] { "ala" };
        static string[] kotyzm = new string[] { "kot" };
        static string[] posiadanie = new string[] { "ma" };

        static void Main(string[] args)
        {
            //wersja pc
            string text = System.IO.File.ReadAllText(@"D:\studia\magisterka\sem1\inteligencja\proj4\inteligencjaProj4\oczyszczony.txt");
            //wersja laptop
            //string text = System.IO.File.ReadAllText(@"D:\studia\magisterka\sem1\inteligencja\proj4\oczyszczony.txt");
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

            dziedzina tmp;
            int alizmI = porownaj(alizm);
            tmp = new dziedzina("alizm", alizmI);
            dziedziny.Add(tmp);
            int kotyzmI = porownaj(kotyzm);
            tmp = new dziedzina("kotyzm", kotyzmI);
            dziedziny.Add(tmp);
            int posiadanieI = porownaj(posiadanie);
            tmp = new dziedzina("posiadanie", posiadanieI);
            dziedziny.Add(tmp);

            Console.WriteLine("Alizm tekstu równa się: " + alizmI);
            Console.WriteLine("Kotyzm tekstu równa się: " + kotyzmI);
            Console.WriteLine("Posiadanie tekstu równa się: " + posiadanieI);

            dziedzina winer = new dziedzina("nicosc", 0);
            foreach(dziedzina d in dziedziny)
            {
                if (d.dajMoc() > winer.dajMoc()) { winer = d; }
            }

            Console.WriteLine("Najprawdopodobniej artykuł należy do kategorii " + winer.dajNazwe());


            Console.ReadKey();
        }

        public static int porownaj(string[] lista)
        {
            int wynik = 0;

            foreach(string s in lista)
            {
                slowo sl = slowa.Select(n => n).Where(x => x.dajSlowo() == s).FirstOrDefault();
                if (sl != null)
                {
                    wynik += sl.dajIle();
                }
            }
            return wynik;
        }



    }
}
