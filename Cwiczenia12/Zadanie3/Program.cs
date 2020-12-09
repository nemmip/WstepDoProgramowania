using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ocenyTekst = { "4,5;5;3,5", "3,5;3;5;4,5", "5;4,5" };
            //string[] ocenyTekst = { "Z;5;3,5", "3,5;3;5;X", "5;4,5" };
            double[][] oceny = TabelaOcen(ocenyTekst);
            WyswietlOceny(oceny);
            Console.WriteLine("Średnia: {0:F2}", SredniaOcen(oceny));
            Console.ReadLine();
        }
        static double [][] TabelaOcen (string[] oceny)
        {
            string[][] ocenyWSemestrze = new string[oceny.Length][];
            double[][] ocenyDouble = new double[ocenyWSemestrze.GetLength(0)][];
            for (int i = 0; i < oceny.Length; i++)
               ocenyWSemestrze[i] = oceny[i].Split(';');
            for (int j = 0; j < ocenyWSemestrze.GetLength(0); j++)
            {
                ocenyDouble[j] = new double[ocenyWSemestrze[j].Length];
                for (int k = 0; k < ocenyWSemestrze[j].Length; k++)
                {
                    try
                    {
                        ocenyDouble[j][k] = double.Parse(ocenyWSemestrze[j][k]);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Wyjątek: Nieprawidłowy format ciągu wejściowego. Popraw dane: Semestr {0} Przedmiot {1}", j+1, k+1);
                        ocenyDouble[j][k] = default;
                        continue;
                    }
                }
            }
            return ocenyDouble;
        }
        static void WyswietlOceny (double [][] tabelaZOcenami)
        {
            foreach (double[] semestr in tabelaZOcenami)
            {
                foreach (double przedmiot in semestr)
                    Console.Write("{0,5:F2}", przedmiot);

                Console.WriteLine();
            }
        }
        static double SredniaOcen(double[][]tabelaZOcenami)
        {
            int licznik = 0; 
            double suma = 0;

            for (int i = 0; i < tabelaZOcenami.GetLength(0); i++)
            {
                for (int j = 0; j < tabelaZOcenami[i].Length; j++)
                {
                    suma += tabelaZOcenami[i][j];
                    licznik++;
                }
            }
            return suma / licznik;
        }
    }
}
