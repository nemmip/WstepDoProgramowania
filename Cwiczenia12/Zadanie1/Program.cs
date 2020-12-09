using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool powtorz = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    Console.Write("Wpisz liczbę całkowitą: ");
                    int wejscie = int.Parse(Console.ReadLine());
                    Console.WriteLine(Oblicz(wejscie));
                    powtorz = false;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowy format ciągu wejściowego. Wpisz prawidłową wartość.");
                    powtorz = true;
                }
                Console.ReadLine();
            } while (powtorz);
        }
        static string Oblicz (int x)
        {
            int wynik = x * x - 3 * x;
            return "Wynik funkcji: " + wynik.ToString() ;
        }
    }
}
