using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj x: ");
            int.TryParse(Console.ReadLine(), out int x);
            Console.Write("\nPodaj n: ");
            int.TryParse(Console.ReadLine(), out int n);
            Console.WriteLine(Oblicz(x, n));
            Console.ReadLine();
        }
        static int Oblicz(int x, int n)
        {
            int w = 0;
            for (int i = 1; i <= n; i++)
            {
                w += x + i;
            }
            return w;
        }
    }
}
