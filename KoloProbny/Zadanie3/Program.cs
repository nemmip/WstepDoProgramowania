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
            string path = @"..\..\DANE\ubrania.csv";
            string[] array = ArrayOfRecords(path);

        }
        static string Niven(string price)
        {

        }
        static string [] ArrayOfRecords (string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(file);
            file.Position = 0;
            string line = null;
            int numberOfRecords = default, index = default, correctRecords = default;

            while((line=streamReader.ReadLine())!=null)
                numberOfRecords++;

            string[] array = new string[numberOfRecords];
            string[] recordA;

            file.Position = 0;

            while((line=streamReader.ReadLine())!= null)
            {
                recordA = line.Split(';');
                if (double.TryParse(recordA[3], out double price))
                {
                    if (array.Contains(line))
                    {
                        array[index] = default;
                        index++;
                    }
                    else
                    {
                        array[index] = line;
                        index++; correctRecords++;
                    }
                }
            }
            string[] correctRecordsArray = new string[correctRecords];
            index = default;
            foreach (string record in array)
            {
                if (record!=default)
                {
                    recordA = record.Split(';');
                    correctRecordsArray[index] = Niven(recordA[3]);

                }
            }

        }

    }
}
