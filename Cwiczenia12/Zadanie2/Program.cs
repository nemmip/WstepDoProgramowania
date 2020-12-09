using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            string odp = "t";
            int liczba = -15;
            do
            {
                try
                {
                    Console.WriteLine("Wynik 100/{0} = {1}", liczba, Dzielenie(liczba));
                    Console.WriteLine("Czy dzielić jeszcze raz (t/n)?");
                    odp = Console.ReadLine();
                    liczba += 5;
                }
                catch(DivideByZeroException e)
                {
                    Console.WriteLine("Wyjątek dzielenia przez zero: {0}", e.ToString() );
                    Console.WriteLine("Czy dzielić jeszcze raz (t/n)?");
                    odp = Console.ReadLine();
                    liczba += 5;
                }

            } while (odp.ToLower() == "t");
        }
        static int Dzielenie(int x)
        {
            return 100 / x;
        }

    }
}
