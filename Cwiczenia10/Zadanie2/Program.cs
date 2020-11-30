using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] tablicaWejscie = new int[1000][];   //inicjalizacja tablicy
            Dzielniki(tablicaWejscie);
            Wypisz(tablicaWejscie);
            Console.ReadLine();
        }
        /// <summary>
        /// Funkcja wpisuje dzielniki danej liczby do tablicy postrzępionej
        /// </summary>
        /// <param name="tablica">tablica postrzępiona</param>
        /// <returns>Zwraca wypełnioną dzielnikami tablicę</returns>
        static int[][] Dzielniki(int[][] tablica)
        {
            int indeks, dlugoscPostrzepionej;   //indeks w tablicy postrzępionej i długość danej postrzępionej tablicy
            for (int i = 1; i <= tablica.GetLength(0); i++) //pętla przez główną tablicę
            {
                indeks = 0; //zerowanie zmiennych
                dlugoscPostrzepionej = IleDzielnikow(i);    //ustalenie długości postrzępionej tablicy
                tablica[i - 1] = new int[dlugoscPostrzepionej]; //utworzenie postrzępionej tablicy
                for (int j = 1; j <= i; j++)    //pętla przez tablicę postrzępioną
                { 
                    if (i%j==0) //jeśli j jest dzielnikiem i
                    {
                        tablica[i-1][indeks] = j; //dopisz j do tablicy
                        indeks++; //zwiększ indeks tablicy
                    }
                }
            }
            return tablica; //zwróć wypełnioną tablicę
        }
        /// <summary>
        /// Funkcja oblicza liczbę dzielników danej liczby
        /// </summary>
        /// <param name="liczba">liczba której dzielniki będą rozpatrywane</param>
        /// <returns>Zwraca liczbę dzielników</returns>
        static int IleDzielnikow(int liczba)
        {
            int liczbaDzielnikow = default; //ustaw na wartość domyślną typu
            for (int i = 1; i <=liczba; i++)
            {
                if (liczba % i == 0) //jeśli liczba jest podzielna przez i 
                    liczbaDzielnikow++; //zwiększ liczbę dzielników
            }
            return liczbaDzielnikow; // zwróć liczbę dzielników
        }
        /// <summary>
        /// Sprawdza czy dana liczba jest doskonała
        /// </summary>
        /// <param name="tablica">Tablica ze wszystkimi dzielnikami</param>
        /// <param name="liczba">Rozpatrywana liczba</param>
        /// <returns>Zwraca wartość true jeśli liczba jest doskonała lub false gdy jest inaczej</returns>
        static bool CzyDoskonala (int[][]tablica, int liczba)
        {
            int suma = tablica[liczba-1].Sum() - liczba; //dodaj wszystkie elementy w podtablicy i odejmij ostatni element (który jest rozpatrywaną liczbą)
            if (suma == liczba)//jeśli suma jest równa liczbie 
                return true; //zwróć prawdę
            else //w przeciwnym wypadku
                return false; //zwróć fałsz
        }
        /// <summary>
        /// Funkcja służąca do wypisania programu na konsolę i analizy danych
        /// </summary>
        /// <param name="tablica">Tablica do wypisania</param>
        static void Wypisz(int[][] tablica)
        {
            int dlugosc1 = tablica.GetLength(0), dlugosc2; //dlugosc1 to długość pierwszego wymiaru tablicy, dlugosc2 postrzepionej tablicy
            string dzielniki, liczbaJestDoskonala; //dzielniki przechowuje lańcuch zawierający dzielniki, liczbaJestDoskonala stosowna wiadomość
            
            for (int i = 1; i <= dlugosc1; i++) //pętla główna przez pierwszy wymiar
            {
                Console.ForegroundColor = ConsoleColor.White; //ustal kolor domyślny tekstu
                dzielniki = default; //ustal wartość dzielniki na domyślną
                dlugosc2 = tablica[i-1].Length; //ustal długość tablicy postrzępionej
                //jeśli funkcja CzyDoskonala zwróci wartosć true to wypisz stosowny komunikat, w przeciwnym wypadku daj pusty łańcuch
                liczbaJestDoskonala = CzyDoskonala(tablica, i) ? "Jest liczbą doskonałą" : ""; 
                for (int j = 0; j < dlugosc2; j++) //pętla przez drugi wymiar 
                {
                    dzielniki += tablica[i-1][j].ToString() + " ";  //konwersja elementów na string i dopisanie ich do łańcucha dzielniki
                }
                Console.Write("{0,6}{1,-5}",i.ToString() + ": " ,dzielniki); //wypisz liczbę i odpowiadające im dzielniki
                Console.ForegroundColor = ConsoleColor.DarkRed; //zmień kolor tekstu na czerwony
                Console.Write("{0,-2}\n", liczbaJestDoskonala); //wypisz komunikat
            }
        }
    }
}