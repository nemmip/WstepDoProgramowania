using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\DANE\Wykaz_nazwisk_męskich_2020_styczen.txt";
            Console.Write("Podaj swoje nazwisko: ");
            string surname = Console.ReadLine().Trim().ToUpper();
            CountMatchSurnames(path, surname, out int lenghtOfArray);
            string[] surnameArray = SelectSurnames(path, surname, lenghtOfArray);
            PrintSurnames(surnameArray, surname);
            Console.ReadLine();

        }
        static void CountMatchSurnames(string path, string surname, out int lenght)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(file);

            lenght = default;
            int surnameLenght = surname.Length;
            char firstLetter = surname[0];
            string line = null, actualSurname = default;

            while((line=streamReader.ReadLine())!=null)
            {
                string[] record = line.Split(',');
                actualSurname = record[0];
                if (
                    (actualSurname.Length == surnameLenght) &&
                    (firstLetter == actualSurname[0]))
                    lenght++;
            }
            streamReader.Close();
        }
        static string[] SelectSurnames(string path,string surname, int lenght)
        {
            string[] selectedSurnames = new string[lenght];
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(file);
            FileStream newFile = new FileStream(@"..\..\DANE\nazwiska.txt", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(newFile);

            int index = 0;
            string line = null,actualSurname = default;
            while ((line = streamReader.ReadLine())!=null)
            {
                string[] record = line.Split(',');
                actualSurname = record[0];
                if ((actualSurname.Length == surname.Length)
                    &&
                    (actualSurname[0]==surname[0]))
                {
                    selectedSurnames[index] = line;
                    streamWriter.WriteLine(line);
                    index++;
                }
            }

            streamWriter.Close();
            streamReader.Close();
            return selectedSurnames;
        }
        static void PrintSurnames(string[] array, string surname)
        {
            string[] line;
            foreach (string record in array)
            {
                line = record.Split(',');
                Console.ForegroundColor = ConsoleColor.White;
                if (line[0]==surname)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(record);
            }
        }
    }
}
