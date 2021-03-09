using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab1 = { 5,11,14,20 };
            int[] tab2 = new int[4];
            for (int i = 0; i < tab1.Length; i++)
            {
                if (tab1[i] % 5 == 0)
                    tab2[i] = tab1[i] + i;
            }
        }
        static void Zadanie1()
        {
            // zmienne
            int[] tab = { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5 };
            int k,l=0, n = tab.Length, wiersze;

            Console.WriteLine("Wpisz k: ");
            k = int.Parse(Console.ReadLine());

            wiersze = (int)Math.Ceiling((double)n / k);
            int[,] tab2 = new int[wiersze,k];

                // pętla przez wiersze
                for (int i=0; i< wiersze; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if ((n % k != 0 )&&(i==wiersze-1))
                            tab2[i, j] = 0;
                        if (l < tab.Length)
                        {
                            tab2[i, j] = tab[l];
                            l++;
                        }
                    Console.Write($"{tab2[i, j],3}");
                    }
                Console.WriteLine();
                }
            Console.ReadLine();
        }
        static void Zadanie2()
        {
            string[] tablica = { "zero", "jeden", "dwa", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć" };
            string liczba;

            Console.WriteLine("Proszę podać liczbę całkowitą");
            liczba = Console.ReadLine();
            foreach (char cyfra in liczba)
                {
                    switch (cyfra)
                    {
                        case '0':
                            Console.Write(tablica[0] + " ");
                            break;
                        case '1':
                            Console.Write(tablica[1] + " ");
                            break;
                        case '2':
                            Console.Write(tablica[2] + " ");
                            break;
                        case '3':
                            Console.Write(tablica[3] + " ");
                            break;
                        case '4':
                            Console.Write(tablica[4] + " ");
                            break;
                        case '5':
                            Console.Write(tablica[5] + " ");
                            break;
                        case '6':
                            Console.Write(tablica[6] + " ");
                            break;
                        case '7':
                            Console.Write(tablica[7] + " ");
                            break;
                        case '8':
                            Console.Write(tablica[8] + " ");
                            break;
                        case '9':
                            Console.Write(tablica[9] + " ");
                            break;
                        default:
                            break;
                    }
                }    

            Console.ReadLine();
        }
        static void Zadanie3()
        {
            string[] tablica = { "zero", "jeden", "dwa", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć" };
            string cyfra;
            int indeksWTablicy;

            Console.WriteLine("Proszę napisać słownie cyfrę");
            cyfra = Console.ReadLine().Trim().ToLower();
            indeksWTablicy = Array.IndexOf(tablica, cyfra);

            switch (indeksWTablicy)
            {
                case 0: Console.WriteLine(0);
                    break;
                case 1:
                    Console.WriteLine(1);
                    break;
                case 2:
                    Console.WriteLine(2);
                    break;
                case 3:
                    Console.WriteLine(3);
                    break;
                case 4:
                    Console.WriteLine(4);
                    break;
                case 5:
                    Console.WriteLine(5);
                    break;
                case 6:
                    Console.WriteLine(6);
                    break;
                case 7:
                    Console.WriteLine(7);
                    break;
                case 8:
                    Console.WriteLine(8);
                    break;
                case 9:
                    Console.WriteLine(9);
                    break;
                default:
                    Console.WriteLine("Wprowadzono błędną wartość!");
                    break;
            }
            Console.ReadLine();

        }
    }
}
