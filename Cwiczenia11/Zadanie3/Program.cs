using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nieposortowanaTablica1 = { 6,1,8,4,5,2,7,3,9 };
            int[] nieposortowanaTablica2 = { 2, 5, 3, 8, 1, 6, 4, 7 };
            SortujSzybko(nieposortowanaTablica1, 0, nieposortowanaTablica1.Length - 1);
            Console.ReadLine();
        }
        static void SortujSzybko(int []tablica, int i, int j)
        {
           if(i<j)
            {
                int pivot = PodzielTablice(tablica, i, j);
                SortujSzybko(tablica, i, pivot - 1);
                SortujSzybko(tablica, pivot + 1, j);
            }

        }
        static int PodzielTablice(int [] tablica, int l, int r)
        {
            int indeksPodzialu = WybierzPunktPodzialu(l, r);
            int wartoscPodzialu = tablica[indeksPodzialu];
            Zamien(tablica, indeksPodzialu, r);
            int aktualnaPozycja = l;
            for (int i = l; i < r; i++)
            {
                if (tablica[i]<wartoscPodzialu)
                {
                    Zamien(tablica, i, aktualnaPozycja);
                    aktualnaPozycja++;
                }
            }
            Zamien(tablica, aktualnaPozycja, r);
            return aktualnaPozycja;
        }
        static int WybierzPunktPodzialu(int l, int r)
        {
            return l + (r - l) / 2;
        }
        static void Zamien(int []tablica,int a, int b)
        {
            int key = tablica[a];
            tablica[a] = tablica[b];
            tablica[b] = key;
        }

    }
}
