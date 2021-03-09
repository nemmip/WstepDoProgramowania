using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
           int nagrody = WylosujNagrody(out int[,] tablicaNagrod); //przypisz ile nagród występuje oraz utwórz tablicę z nagrodami
            Wypisz(tablicaNagrod, out int numerWiersza);
            Waz(ref numerWiersza, ref nagrody,tablicaNagrod);
            Console.ReadLine();
        }
        /// <summary>
        /// Wpisuje do tablicy wylosowaną pozycje w konsoli oraz znak dziesiętny nagrody
        /// </summary>
        /// <param name="tablica">Tablica która ma zostać wypełniona</param>
        /// <returns>Zwraca liczbę nagród</returns>
        static int WylosujNagrody(out int [,]tablica)
        {
            int szerokoscOkna = Console.WindowWidth;    //szerokość okna konsoli
            const int liczbaNagrod = 6; //liczba nagród
            tablica = new int[liczbaNagrod, 2]; // tablica dwuwymiarowa która trzyma lokalizację oraz jej kod dziesiętny
            Random random = new Random();   // generator liczb pseudolosowych
            for (int i = 0; i < liczbaNagrod; i++)
            {
                tablica[i, 0] = random.Next(szerokoscOkna); //wylosuj kolumne
                tablica[i, 1] = random.Next(65, 91); //wylosuj literę
            }
            return liczbaNagrod; // na koniec zwróć liczbę nagród
        }
        /// <summary>
        /// Wypisuje nagrody w konsoli, zwraca też numer w którym znajdują się nagrody
        /// </summary>
        /// <param name="tablica">tablics przechowująca wartości do wypisania</param>
        /// <param name="wiersz">wiersz, w którym mają zostać wypisane nagrody</param>
        static void Wypisz(int [,] tablica, out int wiersz)
        {
            wiersz = 5; //wiersz w którym będą nagrody
            int kolumna; // kolumna w której będą nagrody
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                kolumna = tablica[i, 0]; // przypisz wartość
                Console.SetCursorPosition(kolumna, wiersz); //ustaw kursor
                Console.Write((char)tablica[i, 1]); //wypisz wartość
            }
        }
        /// <summary>
        /// Główna funkcja, która służy do "zjadania" nagród
        /// </summary>
        /// <param name="wiersz">numer wiersza, w kótrym będzie działać funkcja</param>
        /// <param name="liczbaNagrod">maksymalna liczba nagród</param>
        /// <param name="tablica">tablica z wartościami</param>
        static void Waz(ref int wiersz, ref int liczbaNagrod, int [,]tablica)
        {
            Console.SetCursorPosition(0, wiersz); //ustaw domyślną pozycję kursora
            char[] waz = new char[liczbaNagrod+1]; //zadeklaruj tablicę charów z wężem o długości LiczbaNagród+1
            int indeks = liczbaNagrod - 1, suma = default; // indeks w wężu idzie od końca, suma punktów jest domyślną wartością
            waz[liczbaNagrod] ='>'; // ostatni element to głowa
            String cialoWeza; //pomocniczy łańcuch z ciałem węża

            for (int i = 0; i < Console.WindowWidth-waz.Length; i++) //maksymalna wartość i jest równa szerokości okna - długość węża
            {
                Console.SetCursorPosition(i, wiersz); //przesuwaj kursor w prawo
                if (CzyLitera(tablica, i, out int wierszWTablicy)) //jeśli na tej pozycji znajduje się litera podaj jej wiersz w tablicy
                {
                    suma += PoliczPunkty(tablica[wierszWTablicy, 1]); //dodaj punkty otrzymane za literę
                    waz[indeks] = (char)tablica[wierszWTablicy, 1]; //od końca dodawaj kolejne litery
                    indeks--; //zmniejsz indeks o 1
                }
                cialoWeza = new String(waz); //przekonwertuj tablicę charów na string
                Console.Write(" " + cialoWeza.TrimStart('\0')); //przesuń węża i usuń białe znaki
                WyswietlPunkty(suma); //wyświetl liczbę punktów
                Thread.Sleep(150); //opóźnia działanie programu
            }
        }
        /// <summary>
        /// Sprawdza czy w danej kolumnie znajduje się litera
        /// </summary>
        /// <param name="tablica">Tablica z wartościami</param>
        /// <param name="kolumna">Kolumna do sprawdzenia</param>
        /// <param name="wierszTablicy">Wiersz w tablicy do zwrócenia</param>
        /// <returns>Zwraca wartość true jeśli litera istnieje w danej kolumnie lub false jeśli jest inaczej</returns>
        static bool CzyLitera(int [,]tablica, int kolumna, out int wierszTablicy)
        {
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                if (tablica[i, 0] == kolumna) //jeśli wartości są równe
                {
                    wierszTablicy = i; //przypisz wartość wiersza
                    return true; //zwroć prawdę
                }      
            }
            wierszTablicy = default; //jeśli nie znaleziono daj domyślną wartość
            return false; //zwróć fałsz
        }
        /// <summary>
        /// Liczy ile punktów należy się za daną literę
        /// </summary>
        /// <param name="kodDziesietny">Kod dziesiętny znaku</param>
        /// <returns>Zwraca odpowiednią liczbę punktów za daną literę</returns>
        static int PoliczPunkty(int kodDziesietny)
        {
            if (kodDziesietny % 5 == 0) //jeśli jest podzielne przez 5
                return 10; //należy się 10 punktów
            else // przeciwnym wypadku
                return 2;   //należą się dwa punkty
        }
        /// <summary>
        /// Wyświetla na dole konsoli liczbę punktów
        /// </summary>
        /// <param name="liczba">Liczba punktów do wyświetlenia</param>
        static void WyswietlPunkty(int liczba)
        {
            Console.SetCursorPosition(0, Console.WindowHeight); //Ustal pozycję kursora w konsoli
            Console.Write("Liczba punktów: {0}", liczba); // Wyświetl liczbę punktów
        }

    }
}
