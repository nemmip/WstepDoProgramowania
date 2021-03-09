using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\DANE\rownania.csv";
            Delta(path, out int savedRecords);
            Console.WriteLine("Wykonano zapis do nowego pliku, zapisano: {0} rekordów", savedRecords);
            Console.ReadLine();
        }
        static void Delta(string filePath, out int savedRecords)
        {
            FileStream newFile = new FileStream(@"..\..\DANE\rownaniaNowe.csv", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter (newFile);
            string[] dataArray = File.ReadAllLines(filePath);
            savedRecords = default;

            foreach (string line in dataArray)
	        {
                string [] eachLine = line.Split(';');
                int [] eachParam = new int [3];
                int index = 0;
                foreach (string param in eachLine)
	            {
                    int.TryParse(param, out int result);
                    eachParam[index] = result;
                    index++;
	            }
                int delta = Calculate(eachParam);
                if (delta>0)
                {
                    streamWriter.WriteLine(line);
                    savedRecords ++;
                }
	        }
            streamWriter.Close();
            
        }
        static int Calculate(int[] paramsArray)
        {
            if(paramsArray.Length == 3)
            {
                int delta = paramsArray[1]*paramsArray[1] - 4*(paramsArray[0]*paramsArray[2]);
                return delta;
            }
            else
                return -1;
        }

    }
}
