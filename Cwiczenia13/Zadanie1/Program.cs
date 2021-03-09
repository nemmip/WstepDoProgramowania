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
            string path = @"C:\test";
            Directory.SetCurrentDirectory(path);
            try
            {
                if (!Directory.Exists(path))   // jeśli folder nie istnieje
                {
                    Directory.CreateDirectory(path);    // utwórz folder
                    Directory.CreateDirectory(path + @"\Podkatalog pierwszy");
                    Directory.CreateDirectory(path + @"\Podkatalog drugi");
                }
                else
                    Console.WriteLine("Data utworzenia katalogu {0}", Directory.GetCreationTime(path));

                Console.WriteLine("Nazwa katalogu {0}", Directory.GetCurrentDirectory());
                string[] podkatalogi = Directory.GetDirectories(path);

                foreach (string katalog in podkatalogi)
                    Console.WriteLine("\t {0}", katalog);  // wypisuje podkatalogi

                string nadrzedny = Directory.GetDirectoryRoot(path);
                if (Directory.Exists(nadrzedny))
                    Console.WriteLine("Katalog nadrzędny {0}", nadrzedny);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
