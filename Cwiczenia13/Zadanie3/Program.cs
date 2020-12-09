using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Users\julka\source\repos\nemmip\Uniwerek\Cwiczenia13\Zadanie3\dochody.txt";
            
            if (File.Exists(file))
            {
                FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileStream);
                string line = null;
                double sum = default;
                int monthCounter = default;
                while((line = streamReader.ReadLine()) != null)
                {
                    sum+= double.Parse(line);
                    monthCounter++;
                    Console.WriteLine("Dochód za miesiąc {0:D2} = {1}", monthCounter, line);
                }
                streamReader.Close();
                Console.WriteLine("Suma = {0,22}",sum);
                Console.ReadLine();
            }
        }
    }
}
