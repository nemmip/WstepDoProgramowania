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
            int[,] tablica = new int[100, 2];
            WypelnijBlizniaczymi(tablica);

            Console.ReadLine();
        }
        static int [,] WypelnijBlizniaczymi(int [,] tablicaWejscie)
        {
            int indeks = 0;
            int lPierwsza1 = default, lPierwsza2 = default;
            for (int i=3; i<2000; i++)
            {
                lPierwsza1 = CzyJestPierwsza(i) ? i : lPierwsza1;
                lPierwsza2 = CzyJestPierwsza(i-1) ? i-1 : lPierwsza2;

                if (CzyBlizniacze(lPierwsza1,lPierwsza2))
                {
                    tablicaWejscie [indeks,0] = lPierwsza2;
                    tablicaWejscie [indeks,1] = lPierwsza1;
                    indeks++;
                }
                else
                    continue;
            }
            return tablicaWejscie;
        }
       static bool CzyJestPierwsza (int liczba)
       {
            int licznik = 0;
            for (int i = 2; i <= liczba; i++)
			{
                if (liczba%i==0)
                    licznik++;
                if (licznik>1)
                    return false;
			}
            if (licznik == 1)
                return true;
            else
                return false;
       }
       static bool CzyBlizniacze(int liczbaPierwsza_1, int liczbaPierwsza_2)
       {
            if (liczbaPierwsza_1 - liczbaPierwsza_2 == 2)
                return true;
            else
                return false;
       }
    }
}
