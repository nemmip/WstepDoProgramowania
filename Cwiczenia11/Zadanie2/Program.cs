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
            Console.Write("Podaj liczbę naturalną: ");
            int.TryParse(Console.ReadLine(), out int liczba);
            Console.WriteLine(LiczbaPojedyncza(liczba));
            Console.ReadLine();
        }
        static string LiczbaPojedyncza(int liczba)
        {
            if (liczba < 10)
                return WypiszSlownie(liczba);
            else
                return LiczbaPojedyncza(liczba / 10) + LiczbaPojedyncza(liczba % 10);
        }
        static string WypiszSlownie(int liczba) 
        {
            switch (liczba)
            {
                case 0: return "zero ";
                case 1: return "jeden ";
                case 2: return "dwa ";
                case 3: return "trzy ";
                case 4: return "cztery ";
                case 5: return "pięć ";
                case 6: return "sześć ";
                case 7: return "siedem ";
                case 8: return "osiem ";
                case 9: return "dziewięć";
                default:
                    return "";
            }
        }
    }
}
