using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\DANE\ubrania.csv";

            Console.Write("Podaj cenę minimalną: ");
            double.TryParse(Console.ReadLine(), out double minimum);
            Console.Write("\nPodaj cenę maksymalną: ");
            double.TryParse(Console.ReadLine(), out double maximum);

            SelectRecords(path, minimum, maximum);

            Console.WriteLine("Wykonano zapis do pliku.");
            Console.ReadLine();
        }
        static void SelectRecords(string pathFile, double minimumPrice, double maximumPrice)
        {
            bool correctValues = IsCorrectMinMax(minimumPrice, maximumPrice);
            if (correctValues)
            {
                FileStream file = new FileStream(pathFile, FileMode.Open, FileAccess.Read);
                FileStream newFile = new FileStream(@"..\..\DANE\tabelka.html", FileMode.Create, FileAccess.Write);

                StreamReader fileStreamReader = new StreamReader(file);
                StreamWriter newFileStreamWriter = new StreamWriter(newFile);

                string line = fileStreamReader.ReadLine();  //wczytanie pierwszej lini pliku (z nagłówkami)
                // napisanie początu pliku html
                newFileStreamWriter.WriteLine("<html><body>");
                newFileStreamWriter.WriteLine(@"<table border=""1"">");
                string[] headers = line.Split(';');
                string message = "<tr>";
                foreach (string header in headers)
                    message += $"<th>{header}</th>";

                newFileStreamWriter.WriteLine(message + "</tr>");
                file.Position = 0;

                while ((line = fileStreamReader.ReadLine())!=null)
                {
                    string[] arrayOfRecord = line.Split(';');
                    if (double.TryParse(arrayOfRecord[3], out double price))
                    {
                        if ((price >= minimumPrice)&& (price <= maximumPrice))
                            WriteInHTML(newFileStreamWriter, arrayOfRecord);
                    }
                    else
                    {
                        Console.WriteLine("Błędny rekord o id: {0}", arrayOfRecord[0]);
                    }
                }

                newFileStreamWriter.WriteLine("</table>");
                newFileStreamWriter.WriteLine("</body></html>");
                newFileStreamWriter.Close();
                fileStreamReader.Close();
            }
            else
                Console.WriteLine("Błędnie podane wartości.");
        }
        static bool IsCorrectMinMax(double minimum, double maximum)
        {
            if (minimum <= maximum)
                return true;
            else
                return false;
        }
        static void WriteInHTML(StreamWriter stream, string[] lineArray)
        {
            string record = "<tr>";
            foreach (string item in lineArray)
            {
                record += "<td>" + item + "</td>";
            }
            record += "</tr>";
            stream.WriteLine(record);
        }
    }
}
