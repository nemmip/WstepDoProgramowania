using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracaDomowa3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie7();
        }
        static void Zadanie1()
        {
            int liczba1, liczba2, suma = 0;
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
            for (int i = 1; i <= liczba; i++)
            {
                for (int j = 1; j <= liczba; j++)
                    Console.Write($"{i * j,-3}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Zadanie3()
        {
            int liczba;
            Console.WriteLine("Podaj liczbę całkowitą...");
            liczba = int.Parse(Console.ReadLine());
            for (int i = 1; i <= liczba; i++)
            {
                for (int j = 1; j <= liczba; j++)
                {
                    if (j == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (j > i)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (j < i)
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{i * j,-3}");
                }

                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Zadanie4()
        {
            char duzaLitera, malalitera;
            int i, j;
            for (i = 65, j = 97; (i <= 90) && (j <= 122); i++, j++)
            {
                duzaLitera = (char)i;
                malalitera = (char)j;
                Console.Write($"{duzaLitera}{malalitera,-2}");
            }
            Console.ReadLine();
        }
        static void Zadanie5()
        {
            Random random = new Random();
            int liczba = random.Next(100);
            int liczbaUzytkownika, licznik = 0;
            Console.WriteLine("Podaj liczbę...");
            do
            {
                liczbaUzytkownika = int.Parse(Console.ReadLine());
                if (liczbaUzytkownika == liczba)
                {
                    licznik++;
                    Console.WriteLine($"Udało Ci się w {licznik} rundzie!");
                }
                else if (liczbaUzytkownika > liczba)
                {
                    licznik++;
                    Console.WriteLine("Podana liczba jest za duża");
                }
                else if (liczbaUzytkownika < liczba)
                {
                    licznik++;
                    Console.WriteLine("Podana liczba jest za mała");
                }
            }
            while (liczbaUzytkownika != liczba);
            Console.ReadLine();
        }
        static void Zadanie6()
        {
            Random random = new Random();
            int licznik = 0;
            int rzut;
            Console.WriteLine("Będę rzucać kostką...");
            do
            {
                rzut = random.Next(1, 7);
                licznik++;
                Console.WriteLine($"{licznik}. runda: liczba oczek: {rzut}");
            }
            while (rzut != 6);
            Console.ReadLine();


        }
        static void Zadanie7()
        {
            string napis = "Lubię programować";
            int kol = 0, wier = 2;
            int bufor = Console.WindowWidth;
            int maxKolNapisu = bufor - napis.Length;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            while (kol<maxKolNapisu)
            {
                Console.SetCursorPosition(kol, wier);
                Console.Write(" " + napis);
                kol++;
                Thread.Sleep(100);
            }            
            Console.ReadLine();
        }
        static void Zadanie8()
        {
            int n, licznik;
            double pierwiastek;
            Console.WriteLine("Podaj przedział...");
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                licznik = 0;
                pierwiastek = Math.Sqrt(i);
                for (int j = 1; j <= pierwiastek; j++)
                {
                    if (i % j == 0)
                        licznik++;
                }
                if (licznik == 1)
                    Console.Write($"{i,-4}");
            }
            Console.ReadLine();
        }
        static void Zadanie3_9()
        {
            int n;
            Console.WriteLine("Podaj liczbę wierszy");
            n = int.Parse(Console.ReadLine());
            // A

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < i)
                        Console.Write('*');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }

            // B

            for (int i = n; i >= 0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < i)
                        Console.Write('*');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }

            // C

            for (int i = 0; i <= n; i++)
            {
                for (int j = n; j >= 0; j--)
                {
                    if (j < i)
                        Console.Write('*');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            // D

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if ((j * i == 0) || (i == n) || (j == n))
                        Console.Write('*');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Zadanie3_10()
        {
            int n, silnia = 1;
            Console.WriteLine("Proszę podać n...");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
                silnia *= i;
            Console.WriteLine(silnia);
            Console.ReadLine();
        }
        static void Zadanie3_11()
        {
            int suma = 0, licznik = 0;
            for (int i = 1; suma <= 100; i++)
            {
                suma += i;
                licznik = i;
            }

            Console.WriteLine($"Należy dodać do siebie {licznik} kolejnych liczb całkowitych aby ich suma przekroczyła 100");
            Console.ReadLine();
        }
        static void Zadanie3_12()
        {
            int liczba, suma = 0;
            do
            {
                Console.WriteLine("Proszę podać liczbę");
                liczba = int.Parse(Console.ReadLine());
                suma += liczba;

            }
            while (liczba != 0);
            Console.WriteLine(suma);
            Console.ReadLine();
        }
        static void Zadanie3_13()
        {
            int n, suma = -0;
            Console.WriteLine("Proszę podać n...");
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                    suma -= i;
                else
                    suma += i;
            }
            Console.WriteLine(suma);
            Console.ReadLine();

        }
        static void Zadanie3_14()
        {
            int n;
            Console.WriteLine("Proszę podać n...");
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                 int suma = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                        suma += j;
                }
                if (suma == i)
                    Console.WriteLine(suma);
            }
            Console.ReadLine();
        }
        static void Zadanie3_15()
        {
            for (int i=1; i<=10; i++)
            {
                for (int j=0; j<=5;j++)
                {
                    for (int k=0; k<=2; k++)
                    {
                        if (i + j + k == 10)
                            Console.WriteLine($"{i}+{j}+{k} = 10");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
