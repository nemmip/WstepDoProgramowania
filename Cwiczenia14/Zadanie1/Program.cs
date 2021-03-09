using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\DANE\pracownicy.csv";
            string[,] workersArray = LoadData(path);
            string[,] workersSalary = Salary(workersArray);
            Print(workersSalary);

            Console.ReadLine();
        }
        static string[,] LoadData(string filePath)
        {
            FileStream file = new FileStream(filePath,  FileMode.Open,  FileAccess.Read);
            StreamReader streamReader = new StreamReader(file);

            string line  = streamReader.ReadLine();
            int columns = line.Split(';').Length;
            int records = 1;
            line = null;
            while((line = streamReader.ReadLine())!=null)
                records++;

            string[,] dataArray = new string[records, columns];

            file.Position = 0;
            line = null;
            int index = 0;
            while((line = streamReader.ReadLine())!=null)
            {
                string[] lineRecord = line.Split(';');
                for (int i = 0; i < columns; i++)
                    dataArray[index, i] = lineRecord[i];
                index++;
            }
            streamReader.Close();
            return dataArray;

        }
        static string[,] Salary (string [,] array)
        {
            FileStream newFile = new FileStream(@"..\..\DANE\pracownicyPensja.csv", FileMode.Open, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(newFile);
            newFile.Position = 0;

            string[,] finalArray = new string[array.GetLength(0), array.GetLength(1) + 1];
            int[,] hoursAndRate = new int[array.GetLength(0), 2];
            for (int i = 0; i < finalArray.GetLength(0); i++)
            {
                int index = 0;
                string line = null;
                for (int j = 0; j < finalArray.GetLength(1); j++)
                {
                    if (j >= array.GetLength(1))
                    {
                        if (i == 0)
                            finalArray[i, j] = "Pensja";
                        else
                            finalArray[i, j] = (hoursAndRate[i, 0] * hoursAndRate[i, 1]).ToString();
                    }
                    else
                        finalArray[i, j] = array[i, j];
                    line += finalArray[i, j] + ";";

                    if ((int.TryParse(finalArray[i,j], out int result)) && index<2)
                    {
                        hoursAndRate[i, index] = result;
                        index++;
                    }
                }
                streamWriter.WriteLine(line);
            }
            streamWriter.Close();
            return finalArray;
        }
        static void Print(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0,10}", array[i, j]);
                }
                Console.WriteLine();
            }
        }
        
    }
}
