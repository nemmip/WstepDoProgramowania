using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci(10);
            Console.ReadLine();
        }
        static int Fibonacci(int wyraz)
        {
            if (wyraz == 0)
                return 0;
            if (wyraz == 1)
                return 1;
            else
                return Fibonacci(wyraz - 1) + Fibonacci(wyraz - 2);

        }
    }
}
