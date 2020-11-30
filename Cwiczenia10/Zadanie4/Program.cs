using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    class Program
    {
        static void Main()
        {
            Console.Write("Podaj liczbę rund: "); //zapytanie do użytkownika
            int.TryParse(Console.ReadLine(), out int rundy); //sprawdzenie czy podał prawidłową wartość i przypisanie jej do liczby rund
            Oczko(rundy);
            Console.ReadLine();
        }
        /// <summary>
        /// Główna funkcja obsługująca grę
        /// </summary>
        /// <param name="liczbaRund">Liczba rund jaka ma sie wykonać</param>
        static void Oczko(int liczbaRund)
        {
            // inicjalizacja tablicy dwuwymiarowej na wyniki. Pierwszy wymiar to runda, drugi to karty w tej rundzie
            int[,] wyniki = new int[liczbaRund, 11]; 
            int obecnaRunda = 1; //licznik jaka jest obecnie runda
            do
            {
                Console.WriteLine("****RUNDA {0}****", obecnaRunda); //wyświetlenie komunikatu
                WynikRundy(obecnaRunda-1, wyniki); //uruchomienie rundy
                obecnaRunda++; //zwiększ licznik rundy
            }
            while (obecnaRunda <= liczbaRund); //dopóki nie przekroczy wartość podaną przez użytkownika, kontunuuj
            WyswietlTabliceWynikow(WynikGry(wyniki)); //na koniec wyświetl tablicę wyników po utworzeniu tablicy postrzępionej
        }
        /// <summary>
        /// Funkcja obsługująca konkretną rundę
        /// </summary>
        /// <param name="numerRundy">Wartość rundy, która pomoże do wpisania wyniku w odpowiednie miejsce</param>
        /// <param name="tablicaWynikow">Tablica do trzymania kart wylosowanych w rundzie</param>
        static void WynikRundy(int numerRundy, int [,] tablicaWynikow)
        { 
            int karta, suma = 0, indeks = 0;    //zmienna trzymająca kartę, sumę w obecnej rundzie, indeks do wpisywania karty
            string odpowiedz, komunikat;    //łańcuchy odpowiednio na odpowiedź użytkownika oraz na wyświetlenie stosownego komunikatu
            do
            {
                karta = WylosujKarte(); //wylosuj odpowiednią kartę
                tablicaWynikow[numerRundy,indeks] = karta; //wpisz kartę w odpowiednie miejsce
                indeks++; //zwiększ indeks 
                suma += karta; //zwiększ sumę
                Console.WriteLine("Mam kartę o wartości {0}. Suma wynosi: {1}", karta, suma); //wypisz komunikat
                Console.WriteLine("Czy pobrać następną kartę? y/n");
                odpowiedz = Console.ReadLine().ToLower().Trim(); //pobierz i przekonwertuj odpowiedź użytkownika
                if (odpowiedz != "n" && odpowiedz != "y") //jeśli wprowadził inną niż zamierzone
                {
                    Console.WriteLine("Błędnie wprowadzona wartość, tracisz rundę"); //wypisz stosowny komunikat
                    break; //wyjdź z pętli
                }
            } while (odpowiedz == "y" && suma<21); //dopóki użytkownik chce wylosować kartę i suma jest mniejsza niż 21 kontynuuj
            //poniższy kod wypisuje odpowiedni komunikat w zależności od spełnionych warunków
            if (suma == 21)
                komunikat = "Wygrałeś!";
            else if (suma == 22 && (suma - 11 == tablicaWynikow[numerRundy, indeks-1]))
                komunikat = "Perskie oczko!";
            else
                komunikat = "Przegrałeś!";
            Console.WriteLine(komunikat);

        }
        /// <summary>
        /// Prosta funkcja do losowania karty
        /// </summary>
        /// <returns>Zwraca kartę o wartości (2,11></returns>
        static int WylosujKarte()
        {
            Random random = new Random();
            return random.Next(2, 12);
        }
        /// <summary>
        /// Funkcja tworzy tablicę postrzępioną o ilości wierszy równej ilości rund oraz kolumn równej liczbie wylosowanych kart w danej rundzie
        /// </summary>
        /// <param name="wynikiRund">Bazowa tablica dwuwymiarowa z wylosowanymi kartami</param>
        /// <returns>Zwraca tablicę postrzępioną</returns>
        static int[][] WynikGry(int[,] wynikiRund)
        {
            int[][] wynikiGry = new int[wynikiRund.GetLength(0)][]; //inicjalizacja tablicy postrzępionej
            int dlugoscPostrzepionej; //zmienna na długość drugiego wymiaru tablicy postrzępionej
            for (int i = 0; i < wynikiRund.GetLength(0); i++) //pętla przez wiersze
            {
                dlugoscPostrzepionej = 0; //bazowo ustaw na 0
                for (int j = 0; j < wynikiRund.GetLength(1); j++) //pętla przez karty w bazowej tablicy
                {
                    if (wynikiRund[i, j] > 1) // jeśli jest karta
                        dlugoscPostrzepionej++; //zwiększ długość postrzępionej tablicy
                }
                wynikiGry[i] = new int[dlugoscPostrzepionej]; //ustal długość drugiego wymiaru dla odpowiedniej rundy
                for (int k = 0; k < dlugoscPostrzepionej; k++)
                {
                    wynikiGry[i][k] = wynikiRund[i, k]; //wypełnij tablicę
                }
            }
            return wynikiGry; //zwróć tablicę
        }
        /// <summary>
        /// Wyświetla tablicę wyników z tablicy postrzępionej
        /// </summary>
        /// <param name="tablica">Tablica postrzępiona trzymająca wyniki z poszczególnych rund</param>
        static void WyswietlTabliceWynikow(int [][] tablica)
        {
            foreach (int[] podtablica in tablica) //dla każdej podtablicy
            {
                foreach (int liczba in podtablica) //dla każdego elementu podtablicy
                {
                    Console.Write("{0,3}", liczba); //wyświetl ten element z przerwą
                }
                Console.WriteLine();
            }
        }

    }
}
