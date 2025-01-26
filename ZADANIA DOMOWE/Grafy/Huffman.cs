using System;
using System.Collections.Generic;
using System.Linq;

namespace Grafy
{
    public class WezelKopca
    {
        public char znak;
        public uint czestosc;
        public WezelKopca lewe, prawe;

        public WezelKopca(char znak, uint czestosc)
        {
            lewe = prawe = null;
            this.znak = znak;
            this.czestosc = czestosc;
        }
    }

    public class PorownajWezelKopca : IComparer<WezelKopca>
    {
        public int Compare(WezelKopca x, WezelKopca y)
        {
            return x.czestosc.CompareTo(y.czestosc);
        }
    }

    public class Program
    {
        static void DrukujKody(WezelKopca korzen, string kod)
        {
            if (korzen == null)
                return;

            if (korzen.znak != '$')
                Console.WriteLine(korzen.znak + ": " + kod);

            DrukujKody(korzen.lewe, kod + "0");
            DrukujKody(korzen.prawe, kod + "1");
        }

        static void KodyHuffmana(char[] znaki, uint[] czestosci, int rozmiar)
        {
            WezelKopca lewe, prawe, szczyt;
            var kopiec = new SortedSet<WezelKopca>(new PorownajWezelKopca());

            for (int i = 0; i < rozmiar; ++i)
                kopiec.Add(new WezelKopca(znaki[i], czestosci[i]));

            while (kopiec.Count != 1)
            {
                lewe = kopiec.Min;
                kopiec.Remove(lewe);

                prawe = kopiec.Min;
                kopiec.Remove(prawe);

                szczyt = new WezelKopca('$', lewe.czestosc + prawe.czestosc);
                szczyt.lewe = lewe;
                szczyt.prawe = prawe;

                kopiec.Add(szczyt);
            }

            DrukujKody(kopiec.Min, "");
        }

        static void Main()
        {
            char[] znaki = { 'A', 'B', 'C', 'D' };
            uint[] czestosci = { 1, 2, 3, 4 };
            int rozmiar = znaki.Length;
            KodyHuffmana(znaki, czestosci, rozmiar);
        }
    }
}
