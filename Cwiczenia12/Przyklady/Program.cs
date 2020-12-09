using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przyklady
{
    class Program
    {
        static int Dzielenie(int x)
        {
            if (x == 0) throw new DivideByZeroException();       // zg�oszenie wyj�tku
            return 100 / x;
        }
        static void JakiesDzialanie()
        {
            try
            {
                Console.WriteLine(Dzielenie(0));
                //... i jakie� inne dzia�ania
            }
            catch (Exception e)
            {
                throw;                 // ponowne zg�oszenie tego samego wyj�tku
            }
        }

        static void Main(string[] args)
        {
            try
            {
                JakiesDzialanie();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Wyj�tek dzielenia przez zero: {0}", e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Jaski� Wyj�tek: {0}", e.ToString());
            }

            Console.ReadKey();
        }
    }
}
