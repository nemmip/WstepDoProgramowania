using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie5
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pathFile = @"C:\Users\julka\source\repos\nemmip\Uniwerek\Cwiczenia13\Zadanie5\bajka.txt";
            //string string pathFile = @"C:\Users\julka\source\repos\nemmip\Uniwerek\Cwiczenia13\Zadanie5\szekspir.txt";
            string pathFile = @"C:\Users\julka\source\repos\nemmip\Uniwerek\Cwiczenia13\Zadanie5\shrek.txt";
            string pathReport = @"C:\Users\julka\source\repos\nemmip\Uniwerek\Cwiczenia13\Zadanie5\znaki.txt";
            int[] reportArray = new int[400];
            DeleteOldFile(pathReport);
            AnalizeFile(pathFile, reportArray);
            SaveReport(reportArray, pathReport);
            Console.ReadLine();
        }
        static void SaveReport(int[] dataArray, string pathFile)
        {
            FileStream fileStream = new FileStream(pathFile, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            for (int i = 0; i < dataArray.Length; i++)
            {
                if(dataArray[i]>0)
                    streamWriter.WriteLine("Znak {0} wystąpił {1} razy", (char)i, dataArray[i]);
            }
            streamWriter.WriteLine("RAZEM = {0}", dataArray.Sum());
            streamWriter.Close();
        }
        static void DoReport (string lineToAnalize, int[] dataArray)
        {
            foreach (char letter in lineToAnalize)
                dataArray[(byte)letter] += 1;
        }
        static void AnalizeFile(string filePath, int [] analizeArray)
        {
            if (File.Exists(filePath))
            {
                FileStream fileStream = new FileStream(filePath,FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileStream);
                string line = null;

                fileStream.Position = 0;

                while((line = streamReader.ReadLine())!= null)
                    DoReport(line, analizeArray);
                streamReader.Close();
            }
            
        }
        static void DeleteOldFile(string pathToDelete)
        {
            if (File.Exists(pathToDelete))
                File.Delete(pathToDelete);
        }
    }
}
