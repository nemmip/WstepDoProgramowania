using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cwiczenia6
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie4_8();
        }
        static void Zadanie1()
        {
            int rozmiar;
            Console.WriteLine("Podaj rozmiar tablicy");
            rozmiar = int.Parse(Console.ReadLine());
            int[] tablica = new int[rozmiar];

            Random random = new Random();
            for (int i = 0; i < rozmiar; i++)
                tablica[i] = random.Next(65, 91);
            foreach (int litera in tablica)
            {
                Console.Write((char)litera);
            }

            Console.ReadLine();
        }
        static void Zadanie2()
        {
            const int wiersz = 5, liczbaNagrod = 6;
            Random random = new Random();
            

            int[,] tablica = new int[liczbaNagrod, 2];

            for (int i = 0; i<liczbaNagrod; i++)
            {
                tablica[i,0] = random.Next(Console.WindowWidth);
                tablica[i,1] = random.Next(65, 91);
            }
            
            for (int i=0; i<liczbaNagrod; i++)
            {
                Console.SetCursorPosition(tablica[i, 0], wiersz);
                Console.Write((char)tablica[i, 1]);
            }
            Console.Read();
        }
        static void Zadanie3()
        {
            Console.Title = "Zadanie 3";

            // wyświetlenie liter
            const int wiersz = 5, liczbaNagrod = 6;
            Random random = new Random();


            int[,] tablica = new int[liczbaNagrod, 2];
            char[] znaki = new char[Console.WindowWidth];

            for (int i = 0; i < liczbaNagrod; i++)
            {
                tablica[i, 0] = random.Next(Console.WindowWidth);
                tablica[i, 1] = random.Next(65, 91);
            }
            for (int i = 0; i < liczbaNagrod; i++)
            {
                Console.SetCursorPosition(tablica[i, 0], wiersz);
                Console.Write((char)tablica[i, 1]);
                znaki[tablica[i,0]] = (char)tablica[i, 1];
            }

            //zmienna iteracyjna przez węża
            int j = liczbaNagrod-1;
            // tablica węża
            char[] waz = new char[1+liczbaNagrod];
            waz[liczbaNagrod] = '>';
            int punkty = 0;

            for (int i=0; i<Console.WindowWidth-waz.Length; i++)
            {
                Console.SetCursorPosition(i, wiersz);
                if (znaki[i] >= 65 && znaki[i] < 91)
                {
                    waz[j] = znaki[i];
                    Console.Write(" ");
                    foreach (var literka in waz)
                        Console.Write(literka);
                    
                    if (waz[j] % 5 == 0)
                        punkty += 10;
                    else
                        punkty += 2;
                    j--;
                }
                else
                {
                    Console.Write(" ");
                    foreach (var literka in waz)
                        Console.Write(literka);   
                }
                Thread.Sleep(100);
                Console.SetCursorPosition(0, Console.WindowHeight);
                Console.Write($"Punkty: {punkty}");
            }

            Console.ReadLine();
        }
        static void Zadanie4()
        {
            // zmienne
            int liczbaRund, karta, suma, j;
            bool wyjscie = false;
            string odpowiedz;

            // generator liczb pseudolosowych
            Random random = new Random();
            Console.WriteLine("Podaj liczbę rund: ");
            liczbaRund = int.Parse(Console.ReadLine());

            // tablica pierwszy wymiar trzyma numer rundy, drugi wynik
            int[,] tablica = new int[liczbaRund, 11];

            // tablica postrzepiona
            int[][] tablicaWynikow = new int[liczbaRund][];

            for (int i=0; i<liczbaRund; i++)
            {
                suma = 0; j=0;
                Console.WriteLine($"*** Runda {i+1} ***");
                do
                {
                    karta = random.Next(2, 12);
                    tablica[i,j] =  karta; 
                    suma += karta;

                    Console.WriteLine($"Mam kartę o wartości {karta}. Suma wynosi: {suma}.");
                    Console.WriteLine("Czy mam pobrać następną kartę? y/n");
                    odpowiedz = Console.ReadLine().Trim().ToLower();
                    
                    if (odpowiedz == "y")
                    {
                        wyjscie = false;
                        j++;
                    }   
                    else if (odpowiedz == "n")
                        wyjscie = true;
                    else
                    {
                        wyjscie = true;
                        Console.WriteLine("Wprowadzono inną odpowiedź niż oczekiwana...");
                    }
                }
                while (!wyjscie && suma<21);
                
            }
            for (int k = 0; k < tablicaWynikow.GetLength(0); k++)
            {
                suma = 0; karta =0 ;
                tablicaWynikow[k] = new int[tablica.GetLength(1)];
                for (int l=0; l<tablica.GetLength(1); l++)
                {
                    if (tablica[k,l]>1)
                    tablicaWynikow[k][l] = tablica[k, l];
                        
                        karta = tablica[k,l];
                        suma += karta;

                }
                Console.WriteLine();
                Console.WriteLine($"Twoja suma dla rundy {k + 1} wynosi: {suma}");
                if (suma == 21)
                    Console.WriteLine("Oczko!");
                else if (karta == 11 && suma == 22)
                    Console.WriteLine("Oczko perskie!");
                else
                    Console.WriteLine("Nie było oczka");
            }
            Console.WriteLine();
            foreach (int[] podtablica in tablicaWynikow)
            {
                foreach (int x in podtablica)
                {
                    if (x!=0)
                        Console.Write(x + " ");
                }
                    
                Console.WriteLine();
            }
            Console.ReadLine();

        }
        static void Zadanie4_1()
        {
            // zmienne
            int wielkoscTablicy, i = 0;
            
            Console.WriteLine("Podaj wielkość tablicy");
            wielkoscTablicy = int.Parse(Console.ReadLine());
            int[] tablica = new int[wielkoscTablicy];
            do
            {
                Console.WriteLine($"Podaj {i + 1} element");
                tablica[i] = int.Parse(Console.ReadLine());
                i++;
            }
            while (i < wielkoscTablicy);
            foreach (int x in tablica)
                Console.Write($"{x,-3}");
            Console.ReadLine();
        }
        static void Zadanie4_2()
        {
            // tablice
            int[] tab1 = new int[10], tab2 = new int[10];

            // generator liczb pseudolosowych
            Random random = new Random();

            // wypełnienie tab1 wartościami
            for (int i = 0; i < tab1.Length; i++)
                tab1[i] = random.Next(-100, 100);
            int k = 0,j=0;
            while (k < tab1.Length && j < tab2.Length)
            {
                if (tab1[k] > 0)
                {
                    tab2[j] = tab1[k];
                    j++;
                }
                k++;
            }
        }
        static void Zadanie4_3()
        {
            // zmienne
            int wielkosc,i=0, elementDodatni=0;
            Console.WriteLine("Podaj wielkość tablicy");
            wielkosc = int.Parse(Console.ReadLine());

            // tablica
            int[] tablica = new int[wielkosc];
            do
            {
                Console.WriteLine($"Podaj {i + 1} element tablicy");
                tablica[i] = int.Parse(Console.ReadLine());
                if (tablica[i] > 0)
                    elementDodatni++;
                i++;
            }
            while (i<wielkosc);
            Console.WriteLine($"Wartość i numer pozycji największego elementu: {tablica.Max()} "
                +$"{Array.IndexOf(tablica,tablica.Max())}");

            Console.WriteLine($"Wartość i numer pozycji najmniejszego elementu: {tablica.Min()} "
                + $"{Array.IndexOf(tablica, tablica.Min())}");

            Console.WriteLine($"Średnia wartości wszystkich elementów: {tablica.Average()}");

            Console.WriteLine($"Liczba dodatnich elementów: {elementDodatni}");

            Console.ReadLine();

        }
        static void Zadanie4_4()
        {
            // tablica 
            int[] tablica = new int[100];

            // generator liczb pseudolosowych
            Random random = new Random();

            // wypełnienie tablicy
            for (int i = 0; i < tablica.Length; i++)
                tablica[i] = random.Next(0, 1000);

            int licznik, k=0;
            //Tablica z liczbami pierwszymi, w celu sprawdzenia poprawności programu
            //int[] tabLiczbPierwszych = new int[100];
            double pierwiastek;
            
            for (int i = 1; i < tablica.Length; i++)
            {
                licznik = 0;
                pierwiastek = Math.Sqrt(tablica[i]);
                for (int j = 1; j <= pierwiastek; j++)
                {
                    if (tablica[i] % j == 0)
                        licznik++;
                }
                if (licznik == 1)
                {
                    //tabLiczbPierwszych[k] = tablica[i];
                    k++;
                }    
            }
            Console.WriteLine($"W tablicy jest {k} liczb pierwszych");
            Console.ReadLine();
        }
        static void Zadanie4_5()
        {
            int n = 10,  ostatniElement;
            Random random = new Random();
            int[] tab1 = new int[n], tab2 = new int[n];

            for (int i = 0; i < n; i++)
                tab1[i] = random.Next(0, 100);

            ostatniElement = tab1[0];
            for (int i=0; i+1<n; i++)
            {

                tab2[i] = tab1[i + 1];
            }
            tab2[n - 1] = ostatniElement;

            foreach (int x in tab1)
                Console.Write($"{x,-4}");
            Console.WriteLine();
            foreach (int y in tab2)
                Console.Write($"{y,-4}");

            Console.ReadLine();

        }
        static void Zadanie4_6()
        {
            double[,] tablica = new double[5, 5];
            Random random = new Random();
            double suma = 0.00;
            // wpisanie wartosci do tablicy
            for(int i=0; i<tablica.GetLength(0); i++)
            {
                for (int j = 0; j < tablica.GetLength(1); j++)
                {
                    tablica[i, j] = random.Next(-50, 50);
                    Console.Write($"{tablica[i, j],5}");
                    if (i == j)
                        suma += tablica[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Suma wynosi: {suma}");
            Console.ReadLine();
        }
        static void Zadanie4_7()
        {
            int[,] macierz1 = new int[2, 3], macierz2 = new int[2, 3], macierz3 = new int [2,3];
            Random random = new Random();
            // wypełnianie macierzy i ich dodawanie
            for(int i = 0; i < macierz1.GetLength(0); i++)
            {
                for (int j=0; j<macierz1.GetLength(1); j++)
                {
                    macierz1[i, j] = random.Next(-50, 50);
                    macierz2[i, j] = random.Next(-50, 50);

                    macierz3[i, j] = macierz1[i, j] + macierz2[i, j];
                }
            }
            // wyświetlenie macierzy A i B w celu sprawdzenia poprawności programu

            //Console.WriteLine("Macierz A");
            //for (int k = 0; k<macierz1.GetLength(0); k++)
            //{
            //    for (int l = 0; l < macierz1.GetLength(1); l++)
            //        Console.Write($"{macierz1[k, l],4}");
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine("Macierz B");
            //for (int k = 0; k < macierz2.GetLength(0); k++)
            //{
            //    for (int l = 0; l < macierz2.GetLength(1); l++)
            //        Console.Write($"{macierz2[k, l],4}");
            //    Console.WriteLine();
            //}

            Console.WriteLine();
            Console.WriteLine("Macierz C");
            for (int k = 0; k < macierz3.GetLength(0); k++)
            {
                for (int l = 0; l < macierz3.GetLength(1); l++)
                    Console.Write($"{macierz3[k, l],4}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Zadanie4_8()
        {
            string[,] dniTygodnia;
            dniTygodnia = new string[7, 3]; // pamiętaj o zmianie rozmiaru tablicy
            // polski
            dniTygodnia[0, 0] = "poniedzialek";
            dniTygodnia[1, 0] = "wtorek";
            dniTygodnia[2, 0] = "środa";
            dniTygodnia[3, 0] = "czwartek";
            dniTygodnia[4, 0] = "piątek";
            dniTygodnia[5, 0] = "sobota";
            dniTygodnia[6, 0] = "niedziela";
            //angielski
            dniTygodnia[0, 1] = "monday";
            dniTygodnia[1, 1] = "tuesday";
            dniTygodnia[2, 1] = "wednesday";
            dniTygodnia[3, 1] = "thursday";
            dniTygodnia[4, 1] = "friday";
            dniTygodnia[5, 1] = "saturday";
            dniTygodnia[6, 1] = "sunday";
            //niemiecki
            dniTygodnia[0, 2] = "montag";
            dniTygodnia[1, 2] = "dienstag";
            dniTygodnia[2, 2] = "mittwoch";
            dniTygodnia[3, 2] = "donnerstag";
            dniTygodnia[4, 2] = "freitag";
            dniTygodnia[5, 2] = "samstag";
            dniTygodnia[6, 2] = "sonntag";

            for (int i = 0; i<dniTygodnia.GetLength(0); i++)
            {
                for (int j = 0; j < dniTygodnia.GetLength(1); j++)
                    Console.Write($"{dniTygodnia[i, j],-15}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
