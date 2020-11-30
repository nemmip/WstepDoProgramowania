using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tablica = { 1, 4, 6, 8, 2 };
            string[] tablicaString = { "ala", "kot", "dom" };
            Console.WriteLine("Podaj mnożnik: ");
            int mnoznik = int.Parse(Console.ReadLine());
            foreach (int liczba in WariantA(tablica, mnoznik))
                Console.Write("{0,3}", liczba);

            Console.WriteLine();
            foreach (string slowo in WariantA(tablicaString,mnoznik))
                Console.Write("{0,5} ", slowo);
            
            Console.ReadLine();
        }
        static int[] WariantA(int[] tab, int mnoznik)
        {
            for (int i = 0; i < tab.Length; i++)
               tab[i] *=mnoznik;
            return tab;
        }
        static string[] WariantA(string[]tab, int mnoznik)
        {
            string[] wyjscie = new string[tab.Length];
            while (mnoznik>0)
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    wyjscie[i] += tab[i];
                }
                mnoznik--;
            }
            return wyjscie;
        }
    }
}
