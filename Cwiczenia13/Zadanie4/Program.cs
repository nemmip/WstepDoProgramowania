using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileOrg = @"C:\Users\julka\source\repos\nemmip\Uniwerek\Cwiczenia13\Zadanie4\bajka.txt";
            string fileNew = @"C:\Users\julka\source\repos\nemmip\Uniwerek\Cwiczenia13\Zadanie4\bajka2.txt";

            CopyAndReverseLetters(fileOrg, fileNew);
            Console.ReadLine();
        }
        static void CopyAndReverseLetters(string pathOrg, string pathCop)
        {
            // usun ewentualną kopię oryginalnego pliku
            DeleteFile(pathCop);
            if (File.Exists(pathOrg))
            {
                FileStream fileOrgStream = new FileStream(pathOrg, FileMode.Open, FileAccess.Read);
                FileStream fileCopStream = new FileStream(pathCop, FileMode.Create, FileAccess.Write);
                CopyInto(fileOrgStream, fileCopStream);
            }
            
        }
        static string ReverseLine (string lineToReverse)
        {
            char[] line = lineToReverse.ToCharArray();
            for (int i = 0; i < line.Length; i++)
            {
                if (Char.IsUpper(line[i]))
                   line[i] =  Char.ToLower(line[i]);
                else if (Char.IsLower(line[i]))
                    line[i] = Char.ToUpper(line[i]);
                else
                    continue;
            }
            string reversed = new string(line);
            return reversed;
        }
        static void CopyInto(FileStream fileToCopy, FileStream fileIntoCopy)
        {
            StreamReader streamReader = new StreamReader(fileToCopy);
            StreamWriter streamWriter = new StreamWriter(fileIntoCopy);
            fileToCopy.Position = 0;
            string line = null;
            string reservedLine = null;
            
            while ((line = streamReader.ReadLine()) != null)
            {
                reservedLine = ReverseLine(line);
                streamWriter.WriteLine(reservedLine);
            }
            streamWriter.Close();
            streamReader.Close();
        }
        static void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

    }
}
