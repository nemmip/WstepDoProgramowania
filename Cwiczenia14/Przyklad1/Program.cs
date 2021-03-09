using System;
using System.IO;

namespace PlikiPrzyklad
{
    class Program
    {
        static double suma;
        static void Main(string[] args)
        {
            string sciezka1 = @"..\..\DANE\dochody.txt";
            string sciezka2 = @"..\..\DANE\sumaDochodow.txt";
            Wczytaj(sciezka1);
            if (Zapisz(sciezka2))
            {
                Console.WriteLine("Dane zapisano do pliku");
            }
            Console.ReadKey();
        }

        // Wczytanie dochodów z pliku źródłowego i posumowanie
        public static void Wczytaj(string sciezka)
        {
            StreamReader re = null;
            FileStream fs = null;
            try
            {
                if (File.Exists(sciezka))
                {
                    fs = new FileStream(sciezka, FileMode.OpenOrCreate, FileAccess.Read);
                    re = new StreamReader(fs);
                    string linia = null;
                    suma = 0;
                    while ((linia = re.ReadLine()) != null)
                    {
                        suma += double.Parse(linia);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (re != null)
                {
                    re.Close();
                }
            }
        }

        // Zapisanie wyniku do pliku wyjściowego
        public static bool Zapisz(string sciezka)
        {
            bool czyZapisano = false;
            StreamWriter sw = null;
            FileStream fs = null;
            try
            {
                fs = File.Create(sciezka);
                sw = new StreamWriter(fs);

                sw.WriteLine(suma);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    czyZapisano = true;
                }
            }
            return czyZapisano;
        }
    }
}