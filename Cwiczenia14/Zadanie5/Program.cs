using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\DANE\pomiary.csv";
            double[,] measurementsArray = DataArray(path);
            double average = AverageAndErrors(measurementsArray);
            Console.WriteLine("Średnia prawidłowych rekordów wynosi: {0}", average);
            Console.ReadLine();
        }
        static double [,] DataArray(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(file);

            file.Position = 0;
            int lineCounter = default, index = default;
            string line = null;
            string[] eachLine = default;
            while ((line = streamReader.ReadLine())!= null)
                lineCounter++;

            double[,] data = new double[lineCounter, 3];

            file.Position = 0;
            line = null;
            while ((line = streamReader.ReadLine()) != null)
            {
                eachLine = line.Split(';');
                for (int i = 0; i < eachLine.Length; i++)
                {
                    double.TryParse(eachLine[i], out double result);
                    data[index, i] = result;
                }
                index++;
            }
            streamReader.Close();
            return data;
        }
        static double AverageAndErrors(double [,] array)
        {
            string path = @"..\..\DANE\errors.csv";
            FileStream newFile = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(newFile);
            double sum = default, counter = default;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i,1]<array[i,2])
                {
                    streamWriter.WriteLine("{0};{1};{2};", array[i, 0].ToString(), array[i, 1].ToString(), array[i, 2].ToString());
                }
                else
                {
                    sum += array[i, 2];
                    counter++;
                }
            }
            streamWriter.Close();
            return sum / counter;
        }
    }
}
