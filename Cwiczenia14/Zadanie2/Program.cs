using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFile = @"..\..\Program.cs";
            string program = Load(pathFile);
            bool bracets = IfBracetsEven(program);
            string message = "Czy liczba klamer jest równa? ";
            message = bracets ? message + "tak" : message + "nie";
            Console.WriteLine(message);
            Console.ReadLine();
        }
        static string Load(string path)
        {
            string allLines = File.ReadAllText(path);
            return allLines;
        }
        static bool IfBracetsEven(string file)
        {
            int numberOpening = 0, numberClosing = 0;
            foreach (char character in file)
            {
                if (character == '{')
                    numberOpening++;
                else if (character == '}')
                    numberClosing++;
            }
            if (numberOpening == numberClosing)
                return true;
            else
                return false;
        }
    }
}
