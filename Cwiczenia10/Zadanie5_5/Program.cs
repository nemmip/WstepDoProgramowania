using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Prostokat();
            Console.ReadLine();
        }
        static void Prostokat()
        {
            Console.Write("Podaj długość: ");
            int.TryParse(Console.ReadLine(), out int dlugosc);
            Console.Write("\nPodaj szerokość: ");
            int.TryParse(Console.ReadLine(), out int szerokosc);
            Console.Write("\nPodaj znak: ");
            char.TryParse(Console.ReadLine(), out char znak);
            Rysuj(dlugosc, szerokosc, znak);
            Console.WriteLine("\n");
            Rysuj(szerokosc, dlugosc, znak);
        }
        static void Rysuj(int dlugosc, int szerokosc, char znak)
        {
            for (int i = 0; i < dlugosc; i++)
            {
                for (int j = 0; j < szerokosc; j++)
                {
                    Console.Write(znak);
                }
                Console.WriteLine();
            }
        }
    }
}
