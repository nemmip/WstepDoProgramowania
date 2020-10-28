using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cwiczenia5
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie5();
        }
        static void Zadanie1()
        {
            Console.WriteLine($"{"Liczba godzin",-20}{"Wariant 1", -15}{"Wariant 2"}");
            double wariant1=0;
            double wariant2 = 0.10;
            for (int i = 1; i<=16; i++)
            {
                wariant1 +=50.00;
                wariant2 += wariant2*2;
                if (wariant2>wariant1)
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{i,-20}{wariant1.ToString("C", CultureInfo.CurrentCulture),-15}" +
                    $"{wariant2.ToString("C", CultureInfo.CurrentCulture)}");

            }
            Console.ReadLine();
        }
        static void Zadanie2()
        {
            Random random = new Random();
            int karta,suma = 0;
            string odpowiedz;
            bool blad = true;
            do
            {
                karta = random.Next(2, 12);
                suma += karta;
                Console.WriteLine($"Mam kartę o wartości: {karta}. Suma wynosi {suma}.");
                Console.WriteLine("Czy mam pobrać następną kartę? y/n");
                odpowiedz = Console.ReadLine().Trim().ToLower();
                if (odpowiedz == "y")
                    blad = true;
                else if (odpowiedz == "n")
                {
                    blad = false;
                    Console.WriteLine("Czy chcesz zacząć jeszcze raz? y/n");
                    odpowiedz = Console.ReadLine().Trim().ToLower();
                    if (odpowiedz == "y")
                    {
                        blad = true;
                        suma = 0;
                    }  
                    else
                        break;
                }
                    
                else
                {
                    blad = false;
                    Console.WriteLine("Wprowadzono inną odpowiedź niż oczekiwana...");
                }
            }
            while (blad && suma < 21);

            Console.WriteLine($"Twoja końcowa suma wynosi: {suma}");
            if (suma == 21)
                Console.WriteLine("Oczko!");
            else if (karta == 11 && suma == 22)
                Console.WriteLine("Oczko perskie!");
            else
                Console.WriteLine("Nie było oczka");

            Console.ReadLine();
           
        }
        static void Zadanie3()
        {
            int liczba;
            int suma = 0, cyfra;
            Console.WriteLine("Podaj liczbę całkowitą...");
            liczba = int.Parse(Console.ReadLine());

            while (liczba>0)
            {
                cyfra = liczba % 10;
                liczba = liczba / 10;
                suma += cyfra;

                Console.WriteLine($"{cyfra} {suma}");
            }
            Console.ReadLine();
        }
        static void Zadanie4()
        {
            int n,h=0;
            int srodek = Console.WindowWidth / 2;
            int wysokosc = Console.WindowHeight;
            Console.WriteLine("Podaj długość boku kwadratu");
            n = int.Parse(Console.ReadLine());
            
            
            //pętla do rysowania kwadratu
            while(h<wysokosc-n)
            {
                for (int i=0; i<=n; i++)
                {
                   
                    Console.SetCursorPosition(srodek,h);
                    for (int j=0; j<=n; j++)
                    {
                        Console.Write("*");   
                    }
                    if (i==0)
                    {
                        Console.SetCursorPosition(srodek,0);
                        Console.Clear();
                        Console.SetCursorPosition(srodek,h+n);
                        for (int k = 0; k<=n;k++)
                                Console.Write("*");     
                    }
                    Console.WriteLine(); 
                    h++;
                }
                Thread.Sleep(60);
             }   
            Console.ReadLine();
        }
        static void Zadanie5()
        {
            int wysokosc = Console.WindowWidth(), szerokosc = Console.WindowHeight();
            int n;
            if (wysokosc>szerokosc)
                n=szerokosc;
            else
                n=wysokosc;

            for (int i = 0; i<=n; i++)
            {
                for(int j=0;j<=n;j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Zadanie6()
        {
            int n, suma = 0, f1 = 0, f2 = 0;
            Console.WriteLine("Proszę podać wartość n...");
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i <= 2)
                {
                    f1 = 0;
                    f2 = 1;
                    suma = f1 + f2;
                    f1 = suma;
                }
                else
                {
                    suma = f1 + f2;
                    f1 = suma;
                    f2 = suma - f2;
                }
            }
            Console.WriteLine(suma);
            Console.ReadLine();
        }
        static void Zadanie7()
        {
            int x = 0, n, y1, y2;
            Console.WriteLine("Podaj wartość n...");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine($"{"x",0}{"y1=3x-5",10}{"y2=4x-3",10}");
            Console.WriteLine();
            do
            {
                y1 = 3 * x - 5;
                y2 = 4 * x - 3;
                Console.WriteLine($"{x,0}{y1,10}{y2,10}");
                x++;

            }
            while (x <= n);
            Console.ReadLine();
        }
    }
        }
        
    

