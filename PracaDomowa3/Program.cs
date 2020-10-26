using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaDomowa3
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie2();
        }
        static void Zadanie1()
        {
            int liczba1, liczba2, suma=0;
            Console.WriteLine("Podaj pierwszą liczbę całkowitą...");
            liczba1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj drugą liczbę całkowitą...");
            liczba2 = int.Parse(Console.ReadLine());

            //for (int i=liczba1 +1; i<liczba2; i++)
            //{
            //    if (i % 3 == 0)
            //        suma += i;
            //}

            int i = liczba1;
            //while(i<liczba2)
            //{
            //    if (i % 3 == 0)
            //        suma += i;
            //    i++;
            //}
            do
            {
                if ((i) % 3 == 0)
                    suma += i;
                i++;
            }
            while (i < liczba2);


            Console.WriteLine(suma);
            Console.ReadLine();
        }
        static void Zadanie2()
        {
            int liczba;
            Console.WriteLine("Podaj liczbę całkowitą...");
                liczba = int.Parse(Console.ReadLine());
            for (int i=0; i<liczba; i++)
            {
                for (int j = 0; j < liczba; i++)
                    Console.WriteLine(i * j);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
