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
            string path = @"C:\Users\julka\Desktop\Strona";
            Tree(path);
            Console.ReadLine();
        }
        static void Tree(string path, int paragraph = 0)
        {
            
            string message;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
                return;
            else
            {
                message = default;

                DirectoryInfo[] subdirectories = directoryInfo.GetDirectories();
                FileInfo[] files = directoryInfo.GetFiles();

                for (int i = 0; i < paragraph; i++)
                    message += " ";
                if (paragraph ==0)
                    Console.WriteLine(directoryInfo.FullName);
                else
                    Console.WriteLine(message + "|__" + directoryInfo.Name);
                paragraph += 3;

                foreach (DirectoryInfo directories in subdirectories)
                  Tree(directories.FullName, paragraph);

                foreach (FileInfo file in files)
                    Console.WriteLine(message + "* " + file.Name);

            }
            
        }
    }
}
