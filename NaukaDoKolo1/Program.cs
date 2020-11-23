using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaukaDoKolo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie8();
            
        }
        #region Zestaw1
        static void Zadanie2()
        {
            Console.Write("Podaj ilość przepracowanych lat w firmie: ");
            int lata = int.Parse(Console.ReadLine());
            int dodatekStazowy = 0;

            for (int i = 0; i < lata; i++)
            {
                if (i < 5)
                    dodatekStazowy += 100;
                else if (i < 8)
                    dodatekStazowy += 200;
                else
                    dodatekStazowy += 50;
            }
            Console.WriteLine("Miałeś/aś {0} lat stażu, otrzymujesz {1} zł", lata, dodatekStazowy);
            Console.ReadLine();
        }
        static void Zadanie4()
        {
            Console.WriteLine("Podaj liczbę a: ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj liczbę b: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj liczbę c: ");
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj liczbę d: ");
            int d = int.Parse(Console.ReadLine());

            int start = a, koniec = b, suma = 0;
            while(start<= koniec)
            {
                if (start % c == 0 || start % d == 0)
                    suma += start;
                start++;
            }
            Console.WriteLine("Suma liczb z przedziału od {0} do {1} liczb podzielnych przez {2} lub {3} wynosi: {4}", a, b, c, d, suma);
            Console.ReadLine();
        }
        static void Zadanie6()
        {
            Console.Write("Podaj liczbę: ");
            string liczba = Console.ReadLine();
            char cyfra;
            string wyjscie = default;


            for (int i = 0; i < liczba.Length; i++)
            {
                cyfra = liczba[i];
                switch (cyfra)
                {
                    case '1': wyjscie += "jeden,";
                        break;
                    case '2': wyjscie += "dwa,";
                        break;
                    case '3': wyjscie += "trzy,";
                        break;
                    case '4': wyjscie += "cztery,";
                        break;
                    case '5': wyjscie += "pięć,";
                        break;
                    case '6': wyjscie += "sześć,";
                        break;
                    case '7': wyjscie += "siedem,";
                        break;
                    case '8': wyjscie += "osiem,";
                        break;
                    case '9': wyjscie += "dziewięć,";
                        break;
                    default:
                        break;
                }
            }
            
            Console.WriteLine(wyjscie.Remove(wyjscie.Length-1));
            Console.ReadLine();
        }
        static void Zadanie8()
        {
            // stworzenie tablicy
            Random random = new Random();
            int[] tablica = { 1,2,4,5,6,7,8,9,9};
            //for (int i = 0; i < tablica.Length; i++)
                //tablica[i] = random.Next(1, 51);
            // pierwszy wymiar na liczbę, drugi na jej licznik
            int[,] licznik = new int[10,2];

            licznik[0, 0] = tablica[0];
            licznik[0, 1] = 1;
            int l=1, suma=0;

            for (int h = 0; h < tablica.Length; h++)
            {
                for (int j = 1; j < licznik.GetLength(0); j++)
                {
                    if (l < licznik.GetLength(0))
                    {
                        if (tablica[h] == licznik[j, 0] && licznik[j, 1] > 0)
                            licznik[j, 1] += 1;
                        else
                        {
                            licznik[l, 0] = tablica[h];
                            licznik[l, 1] = 1;
                            l++;
                        }
                    }
                }
            }
            for (int k = 0; k < licznik.GetLength(0); k++)
            {
                if (licznik[k, 1] == 1)
                    suma += licznik[k, 0];
            }

            foreach (int liczba in tablica)
            {
                Console.Write("{0}  ", liczba);
            }
            Console.WriteLine("\nTwoja suma wynosi: {0}", suma);
            Console.ReadLine();
        }
        #endregion

    }
}
