using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kolokwium
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie3();
        }
        static void Zadanie1()
        {
            // ukrycie kursora
            Console.CursorVisible = false;
            // utworzenie tablicy charow
            char[,] tablica = new char[6, 6];
            
            // generator liczb pseudolosowych
            Random random = new Random();

            // zmienna bool wskazujaca czy kursor znajduje sie na przeciwprostokatnej
            bool przeciwprostokatna = false;
            // zmienne do losowania wiersza i kolumny
            int wiersz, kolumna;
            
            // pętle do wypełniania tablicy odpowiednimi znakami i wyświetlania jej
            for (int i=0; i<tablica.GetLength(0); i++)
            {
                for (int j = 0; j < tablica.GetLength(1); j++)
                {
                    if (i >= j)
                        tablica[i, j] = '*';
                    else
                        tablica[i, j] = ' ';
                    Console.Write(tablica[i, j]);
                }
                Console.WriteLine();
            }
            // nacisnięcie ENTER spowoduje uruchomienie kolejnych instrukcji
            Console.ReadLine();
            do
            {
                // gwiazdki świecą na wybrany kolor
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                // losowanie wiersza i kolumny
                wiersz = random.Next(0, 6);
                kolumna = random.Next(0, 6);
                Console.SetCursorPosition(wiersz, kolumna); //postawienie kursora w odpowiednim miejscu

                if (tablica[kolumna, wiersz] == '*') // jeśli jest tam gwiazdka napisz ją w kolorze
                {
                    Console.Write('*');
                    przeciwprostokatna = false; //pętla ma się dalej wykonać
                }
                else
                    przeciwprostokatna = false; // pętla ma się dalej wykonać
                if (kolumna==wiersz)    // jeśli będziemy na przeciwprostokątnej
                    przeciwprostokatna = true;  //daj sygnał do przerwania pętli
                Thread.Sleep(100);
            } while (!przeciwprostokatna);

            Console.ReadLine();
        }
        static void Zadanie2()
        {
            int[] tablica1 = new int[15], tablica2 = new int[15]; // tablice do zadeklarowania
            Random random = new Random();   //generator liczb pseudolosowych
            int liczba1, liczba2;   // liczby które będą wstawiane do tablicy 
            double suma = default;    // suma (ai - pi)^2
            bool czyJestLiczba; // zmienna potrzebna do określenia czy w danym miejscu tablicy jest już liczba, czy trzeba ją dalej generować
            // pętla do wypełnienia pierwszej tablicy
            for (int i = 0; i < tablica1.Length; i++)
            {
                czyJestLiczba = false;
                while (!czyJestLiczba)
                {
                    liczba1 = random.Next(1000); //zakres do 1000 dla czytelnosci
                    if (liczba1 % 3 == 0 || liczba1 % 4 == 0)
                    {
                        tablica1[i] = liczba1;
                        czyJestLiczba = true;
                    }
                    else
                        czyJestLiczba = false;
                }
            }
            Array.Sort(tablica1); //posortowanie tablicy1
            // pętla do wypełnienia drugiej tablicy
            for (int j = 0; j < tablica2.Length; j++)
            {
                czyJestLiczba = false;
                while (!czyJestLiczba)
                {
                    liczba2 = random.Next(1000);    // zakres do 1000 dla czytelności
                    if (liczba2 % 4 == 0 || liczba2 % 5 == 0)
                    {
                        tablica2[j] = liczba2;
                        czyJestLiczba = true;
                    }
                    else
                        czyJestLiczba = false;
                }
            }
            Array.Sort(tablica2); // posortowanie drugiej tablicy

            for (int k = 0; k < tablica1.Length; k++)
                suma += Math.Pow((double)tablica1[k] - (double)tablica2[k], 2); //obliczenie sumy (ai -pi)^2

            double pD = Math.Sqrt(suma); //ostateczny wzor

            //wyświetlenie pierwszej tablicy
            Console.Write("Tablica numer 1: ");
            foreach (int  liczba in tablica1)
                Console.Write("{0}  ", liczba);

            // wyświetlenie drugiej tablicy
            Console.Write("\nTablica numer 2: ");
            foreach (int  liczba in tablica2)
                Console.Write("{0}  ", liczba);

            // wyświetlenie wyniku z dwoma miejscami po przecinku
            Console.WriteLine("\n\nObliczony wynik: {0}", Math.Round(pD,2));
            Console.ReadLine();
        }
        static void Zadanie3()
        {
            Console.Write("Proszę podać dowolną liczbę naturalną: ");
            int liczba = int.Parse(Console.ReadLine()); // pobranie wartości od uzytkownika
            double suma = default;    //inicjalizacja sumy z wartością domyślną
            string rownanie = default;  // inicjalizacja równania do wyświetlenia z wartością domyślną
            double licznik, mianownik;  // zmienne potrzebne do wzoru


            for (int i = 1; i <= liczba; i++)
            {
                licznik = Math.Pow(2, i); // oblicz licznik sumy
                mianownik = Math.Pow((double)i, 2); // oblicz mianownik sumy
                rownanie += licznik.ToString() + "/" + mianownik.ToString() + " + "; // konwersja na string i dodanie do zmiennej równanie
                suma += licznik / mianownik; // obliczenie sumy
            }
           
            Console.WriteLine("S(n) = " + rownanie.Remove(rownanie.Length - 3)); // napisanie równania, na końcu odejmujemy ciąg " + ", który ma 3 znaki długości
            Console.WriteLine("S(n) = {0}", Math.Round(suma, 3)); // napisanie sumy z zaokrągleniem do 3 miejsc po przecinku
            Console.ReadLine();
        }
    }
}
