using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj liczbę naturalną: ");
            Console.WriteLine(SumaCyfr(Console.ReadLine()));
            Console.ReadLine();
        }
        static int SumaCyfr(string liczba)
        {
            int suma = 0;
            if (int.TryParse(liczba, out int sprawdzenie))
            {
                foreach (char cyfra in liczba)
                    suma += int.Parse(cyfra.ToString());
                return suma;
            }
            else
                return 0;
        }
    }
}
