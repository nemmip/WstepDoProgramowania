using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\DANE\PanTadeusz.txt";

            Console.Write("Podaj liczbę samogłosek: ");
            try
            {
                int vowel = int.Parse(Console.ReadLine());  //zmienna na liczbę samogłosek
                int records = RecordsSpecificVowels(path, @"..\..\DANE\wynik.txt", vowel);
                Console.WriteLine("Zapisano {0} wierszy do pliku wynikowego", records);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
        static int RecordsSpecificVowels(string filePath, string newFilePath, int numberOfVowels)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            FileStream newFile = new FileStream(newFilePath, FileMode.Create, FileAccess.Write);

            StreamReader fileStreamReader = new StreamReader(file);
            StreamWriter newFileStreamWriter = new StreamWriter(newFile);

            char[] vowelsArray = { 'a', 'ą', 'e', 'ę', 'i', 'u', 'o', 'ó', 'y' };
            string line = null;
            int numberOfRecord = default;

            file.Position = 0;
            while ((line = fileStreamReader.ReadLine())!=null)
            {
                string newLine = line.ToLower();
                int counter = 0;
                foreach (char letter in newLine)
                {
                    if (vowelsArray.Contains(letter))
                        counter++;
                }
                if (counter == numberOfVowels)
                {
                    numberOfRecord++;
                    newFileStreamWriter.WriteLine("{0}) {1}", numberOfRecord, line);
                }
            }
            fileStreamReader.Close();
            newFileStreamWriter.Close();
            return numberOfRecord;
        }
    }
}
