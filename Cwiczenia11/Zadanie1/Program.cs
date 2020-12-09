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
            Console.Write("Podaj n: ");
            int.TryParse(Console.ReadLine(), out int n);
            Console.WriteLine("{0} wyraz ciągu wynosi {1}", n, LiczbyTrojkatne(n));
            Console.ReadLine();

        }
        static int LiczbyTrojkatne(int liczbaWywolan)
        {
            if (liczbaWywolan == 1) return 1;
            else
                return liczbaWywolan + LiczbyTrojkatne(liczbaWywolan - 1);
        }
    }
}
