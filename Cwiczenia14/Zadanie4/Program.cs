using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\DANE\oceny.txt";
            double [][] grades = GradesArray(path);
            PrintGrades(grades);
            Console.WriteLine("Średnia: {0:F2}", GradesAverage(grades));
            Console.ReadLine();
        }
        static double [][] GradesArray(string filePath)
        {
           string[] grades = Array (filePath);
           string[][] gradesInSem = new string[grades.Length][];
            double[][] gradesDouble = new double[gradesInSem.GetLength(0)][];
            for (int i = 0; i < grades.Length; i++)
               gradesInSem[i] = grades[i].Split(';');
            for (int j = 0; j < gradesInSem.GetLength(0); j++)
            {
                gradesDouble[j] = new double[gradesInSem[j].Length];
                for (int k = 0; k < gradesInSem[j].Length; k++)
                {
                    try
                    {
                        gradesDouble[j][k] = double.Parse(gradesInSem[j][k]);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Wyjątek: Nieprawidłowy format ciągu wejściowego. Popraw dane: Semestr {0} Przedmiot {1}", j+1, k+1);
                        gradesDouble[j][k] = default;
                        continue;
                    }
                }
            }
            return gradesDouble; 

        }
        static string [] Array (string filePath)
        {
            FileStream file = new FileStream (filePath, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(file);
            int numberOfLines = default, index = default;
            string line = null;
            while((line = streamReader.ReadLine())!=null)
                numberOfLines++;
            
            string [] lines = new string [numberOfLines];
            file.Position = 0;
            line = null;

            while((line = streamReader.ReadLine())!=null)
            {
                lines [index] = line;
                index++;
            }
            streamReader.Close();
            return lines;
        }
        static void PrintGrades (double [][] gradesArray)
        {
            foreach (double[] sem in gradesArray)
            {
                foreach (double subject in sem)
                    Console.Write("{0,5:F2}", subject);

                Console.WriteLine();
            }
        }
        static double GradesAverage(double[][]gradesArray)
        {
            int counter = 0; 
            double sum = 0;

            for (int i = 0; i < gradesArray.GetLength(0); i++)
            {
                for (int j = 0; j < gradesArray[i].Length; j++)
                {
                    sum += gradesArray[i][j];
                    counter++;
                }
            }
            return sum / counter;
        }
    }
}
