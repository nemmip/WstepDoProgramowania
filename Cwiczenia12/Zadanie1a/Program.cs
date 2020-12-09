using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1a
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ifSuccesful;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Wpisz liczbę całkowitą: ");
                ifSuccesful = int.TryParse(Console.ReadLine(), out int wejscie);
                if (!ifSuccesful)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowy format ciągu wejściowego. Wpisz prawidłową wartość");
                    continue;
                }
                Console.WriteLine(Oblicz(wejscie));
                Console.ReadLine();
            } while (!ifSuccesful);
            
        }
        static string Oblicz (int x)
        {
            int wynik = x * x - 3 * x;
            return "Wynik funkcji: " + wynik.ToString();
        }
    }
}
