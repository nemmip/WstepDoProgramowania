using System;
using System.Diagnostics;
using System.Linq;

namespace Cwiczenia8
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie4_15();
            Console.ReadLine();
        }
        static void Zadanie1a()
        {
            // zmienne
            int indeks;                                         //zmienna trzymająca indeks, na którym powinen znajdować się pierwiastek w liczbie
            double pierwiastek;                                 // zmienna do obliczania pierwiastka
            string sLiczba, sPierwiastek;                       // stringi dla liczby i pierwiastka
            Stopwatch stoper = new Stopwatch();                 // stoper

            stoper.Start();
            for (int i=1; i<=500000; i++)                       // pętla for do iteracji przez przedział
            {
                sLiczba = i.ToString();                         // konwersja do string
                pierwiastek = Math.Sqrt((double)i);             // obliczenie pierwiastka
                sPierwiastek = pierwiastek.ToString();
                indeks = sLiczba.Length - sPierwiastek.Length;  // obliczenie indeksu


                if ((sPierwiastek.Length<=sLiczba.Length)&&     // wykona się tylko gdy długość pierwiastka jest mniejsza niż długość liczby
                    sLiczba.IndexOf(sPierwiastek) ==indeks)     // i gdy pierwiastek znajduje się na końcu liczby
                    Console.WriteLine(i);                       // wypisuje liczbę
            }
            stoper.Stop();
            Console.WriteLine("Czas działania: {0}", stoper.ElapsedMilliseconds);

        }
        static void Zadanie1b()
        {
            // zmienne
            double pierwiastek;                                 // zmienna do obliczania pierwiastka
            string sLiczba, sPierwiastek;                       // stringi dla liczby i pierwiastka
            Stopwatch stoper = new Stopwatch();                 // stoper

            stoper.Start();
            for (int i = 1; i <= 500000; i++)                   // pętla for do iteracji przez przedział
            {
                sLiczba = i.ToString();                         // konwersja do string
                pierwiastek = Math.Sqrt((double)i);             // obliczenie pierwiastka
                sPierwiastek = pierwiastek.ToString();          // konwersja do string
               
                if (sLiczba.EndsWith(sPierwiastek))             // jeśli pierwiastek znajduje się na końcu
                    Console.WriteLine(i);                       // wypisuje liczbę
            }
            stoper.Stop();
            Console.WriteLine("Czas działania: {0}", stoper.ElapsedMilliseconds);

        }
        static void Zadanie2()
        {
            string[] dochody = { "4500,50;4655,65;4400,47;5078,90",             // tablica źródłowa
                                 "3506,80;3455,75;3300;4090,40",
                                 "3160,50;2988,60;3100,60;3050"};
            double[,] dane = new double[dochody.Length, 4];                     // tablica dwuwymiarowa
            double suma;                                                        // zmienna trzymajaca sumę kolumny


            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", "Kwartał I",      // nagłówek
                              "Kwartał II", "Kwartał III", "Kwartał IV");

            for (int i = 0; i < dochody.Length; i++)                            // pętla do wpisywania wartości
            {
                string[] tablica = dochody[i].Split(';');                       // chwilowe utworzenie tablicy
                
                for (int j=0;j<dane.GetLength(1); j++)
                {
                    dane[i, j] = double.Parse(tablica[j]);                      // konwersja na double i wpisanie danych
                    Console.Write("{0,-15}", dane[i, j]);                       // wyświetlenie w konsoli
                }
                Console.WriteLine();                                            // przejście do kolejnego wiersza
                
            }
            for (int k = 0; k < dane.GetLength(1); k++)                         // pętla na sumę
            {
                suma = 0;                                                       // zerowanie zmiennych
                for (int l = 0; l< dochody.GetLength(0); l++)                   // tutaj pętla jest w odwrotnej kolejności niż for ze zmiennymi i,j
                    suma += dane[l, k];                                         // sumowanie
                Console.ForegroundColor = ConsoleColor.DarkRed;                 // zmiana koloru tekstu
                Console.Write("{0,-15}", suma);                                 // wypisanie sumy
            }

        }
        static void Zadanie3()
        {
            string[] numerPesel = { "69091592986", "82072266559", "82121432627", "91042369619", "86051537184" };    // tablica źródłowa z numerami PESEL
            int rokUrodzenia;   // zmienna trzymająca rok urodzenia
            bool kobieta = false; // jesli prawda to osoba jest kobietą, jeśli fałsz, to mężczyczną
            Console.WriteLine("{0,-20}{1,-20}{2,-20}", "Numer PESEL","Rok urodzenia", "Płeć");     // wypisanie nagłówka
            for (int i=0; i<numerPesel.Length; i++) 
            {
                rokUrodzenia = int.Parse(numerPesel[i].Substring(0, 2));    // znalezienie liczb odpowiedzialnych za rok urodzenia
                if (int.Parse(numerPesel[i].Substring(9, 1)) % 2 == 0)  // jeśli cyfra na pozycji 10 jest parzysta
                    kobieta = true; // osoba jest kobietą
                else
                    kobieta = false;    // jeśli nie, mężczyzną

                if (rokUrodzenia < 10)  // jeśli liczba przechowywana w zmiennej rokUrodzenia jets mniejsza niż 10 
                    rokUrodzenia = 2000 + rokUrodzenia; // osoba urodziła się po 2000 roku
                else
                    rokUrodzenia = 1900 + rokUrodzenia; // w przeciwnym wypadku osoba urodziła sie w latach 1900-1999
                if (kobieta)    // jeśli osoba jest kobietą
                    Console.WriteLine("{0,-20}{1,-20}{2,-20}", numerPesel[i], rokUrodzenia, "Kobieta"); // wypisz stosowną wiadomość z odpowiednią płcią
                else
                    Console.WriteLine("{0,-20}{1,-20}{2,-20}", numerPesel[i], rokUrodzenia, "Mężczyzna");   // w przeciwnym razie wypisz inną wiadomość


            }
        }
        static void Zadanie4_9()
        {
            // zmienne
            string wejscieUzytkownika;  // zmienna na tekst użytkownika
            int licznik = 0;    // licznik słów

            Console.WriteLine("Proszę wporwadzić jakiś tekst...");
            wejscieUzytkownika = Console.ReadLine();    // czytanie wartości

            string[] tablica = wejscieUzytkownika.Split(' ');   //podzielenie wprowadzonego łańcucha na pojedyncze słowa
            foreach (string slowo in tablica)   // dla każdego słowa w tekście
                licznik++;  // zwiększ licznik
            Console.WriteLine($"W twoim tekście znajduje się : {licznik} słów");    // wypisz stosowną wiadomość
            
        }
        static void Zadanie4_10()
        {
            // zmienne
            DateTime data;  // zmienna trzymająca datę

            Console.WriteLine("Podaj datę w formacie DD-MM-RRRR");  // komunikat do użytkownika
            data = DateTime.Parse(Console.ReadLine());  // zapisanie wprowadzonej wartości
            Console.WriteLine(data.ToString("MMMM"));   // wypisanie słownie miesiąca
        }
        static void Zadanie4_11()
        {
            // zmienne
            string wejscieUzytkownika;  // zmienna na tekst użytkownika
            char[] litery = new char [26] ; // tablica charów na litery w alfabecie
            int[] licznik = new int [26];   // tablica trzymająca licznik dla każdej liczby
            int i = 0, indeks;  // zmeinne sterujące

            Console.WriteLine("Proszę wprowadzić jakiś tekst");
            wejscieUzytkownika = Console.ReadLine().Trim().ToLower();   // zapisanie wartości użytkownika, usunięcie białych znaków przed i za, zmniejszenie liter

            foreach (char litera in wejscieUzytkownika) // dla każdej litery w tekście
            {
                if (litery.Contains(litera))    //sprawdź czy litera już jest w tablicy z literami
                {
                    indeks = Array.IndexOf(litery, litera); // jeśli tak znajdź jej indeks
                    licznik[indeks] += 1;   // indeks licznika danej litery jest taki sam co indeks w tablicy liter, więc go powiększ
                }
                else
                {
                     litery[i] = litera; // w przeciwnym wypadku dodaj nową litere do tablicy
                     licznik[i] = 1; // przypisz domyślną wartość licznika
                     i++;    // zwiększ zmienną sterującą
                }
            }
            for (int j=0; j<litery.Length; j++) // wypisywanie liter w konsoli
            {
                if ((litery[j]!='\0') &&(licznik[j]!=0))    //ominięcie wartości domyślnych w tablicach
                Console.WriteLine($"{litery[j]} - {licznik[j]}");
            }
            
                
        }
        static void Zadanie4_12()
        {
            int liczbaZnakow, numerWiersza = 1; ;   // zmienne sterujące
            // fragment powieści A. A. Milne, "Kubuś Puchatek"
            string tekst = "W parę godzin później, gdy noc zbierała się do odejścia,\n" +
                           "Puchatek obudził się nagle z uczuciem dziwnego przygnębienia.\n" +
                           "To uczucie dziwnego przygnębienia miewał już nieraz i wiedział,\n" +
                           "co ono oznacza. Był głodny. Więc poszedł do spiżarni,\n" +
                           "wgramolił się na krzesełko, sięgnął na górną półkę, ale nic nie znalazł.";
            Console.WriteLine(tekst + "\n");    // wypisanie tekstu

            string[] liczbaWierszy = tekst.Split('\n'); //podział tekstu po pojawieniu się znaku nowej linii
            Console.WriteLine($"Liczba wierszy: {liczbaWierszy.Length}");   //liczba wierszy równa się liczbie elementów w tablicy
            foreach(string zdanie in liczbaWierszy) //dla każdej linii
            {
                liczbaZnakow = 0;   // wyzeruj wartość liczby znaków
                foreach (char znak in zdanie)   // dla każdego znaku w linii
                    liczbaZnakow++; // zwiększ liczbę znaków
                Console.WriteLine($"Liczba znaków w wierszu numer {numerWiersza} wynosi: {liczbaZnakow}");  // po przeliczeniu dla danej linii wypisz dane
                numerWiersza++; // zwiększ numer wiersza

            }
            
        }
        static void Zadanie4_13()
        {
            char[] wzorDzielenia = { ' ', '.', ',', '\n' }; // tablica charów która posłuży do dzielenia tekstu na substringi
            int i = 0, indeks;  // zmienne sterujące

            // fragment powieści A. A. Milne, "Kubuś Puchatek"
            string tekst = "W parę godzin później, gdy noc zbierała się do odejścia,\n" +
                           "Puchatek obudził się nagle z uczuciem dziwnego przygnębienia.\n" +
                           "To uczucie dziwnego przygnębienia miewał już nieraz i wiedział,\n" +
                           "co ono oznacza. Był głodny. Więc poszedł do spiżarni,\n" +
                           "wgramolił się na krzesełko, sięgnął na górną półkę, ale nic nie znalazł.";

            Console.WriteLine(tekst + "\n");    // wypisanie tekstu

            string[] slowa = tekst.Split(wzorDzielenia);    // podzielenie tekstu na pojedyncze słowa według wzoru do dzielenia

            string[] powtorzoneSlowa = new string[slowa.Length];    // tablica na powtórzone słowa
            int[] licznik = new int[powtorzoneSlowa.Length];    // tablica na licznik

            foreach (string slowo in slowa) // dla kazdego słowa
            {
                if (powtorzoneSlowa.Contains(slowo))    // jeśli słowo już wystąpiło
                {
                    indeks = Array.IndexOf(powtorzoneSlowa,slowo);  // znajdź indeks w tablicy dla tego słowa
                    licznik[indeks]++;  // zwiększ licznik
                }
                else
                {
                    powtorzoneSlowa[i] = slowo; // w przeciwnym wypadku dodaj nowe słowo do tablicy
                    licznik[i]++;   // zwiększ licznik
                    i++;    // zwiększ zmienną sterującą
                }
            }
            Console.WriteLine("Powtórzone słowa:"); 
            for (int j=0; j<licznik.Length; j++)
            {
                if ((licznik[j] > 1)&&(powtorzoneSlowa[j]!="")) // jeśli licznik jest większy od 1 i słowo nie jest spacją 
                    Console.WriteLine($"{powtorzoneSlowa[j]} - {licznik[j]}");  // wypisz raport
            }

        }
        static void Zadanie4_14()
        {
            string[] identyfikatory = { "PVMQZ-1979", "PHLKL-2010", "XCZAT-1991", "QCOBM-1972", "TYSQI-2003" }; // inicjalizacja tablicy z identyfikatorami
            int[] rokZakupu = new int[identyfikatory.Length];   // deklaracja tablicy zawierająca rok zakupu danego środka

            for (int i=0; i<rokZakupu.Length; i++)
            {
                rokZakupu[i] = int.Parse(identyfikatory[i].Substring(identyfikatory[i].IndexOf('-')+1,4)); // przypisanie wartości roku zakupu
                Console.WriteLine($"Od zakupu {identyfikatory[i]} upłynęło { (int)DateTime.Now.Year - rokZakupu[i]} lat");  // wyświetlenie komunikatu
            }
        }
        static void Zadanie4_15()
        {
            string klucz = "GADERYPOLUKI";
            string wejscieUzytkownika;
            string tekstZaszyfrowany = String.Empty;
            int indeks;

            Console.WriteLine("Proszę podać jakieś słowo");
            wejscieUzytkownika = Console.ReadLine().Trim().ToUpper();
            foreach(char litera in wejscieUzytkownika)
            {
                if (klucz.Contains(litera))
                {
                    indeks = klucz.IndexOf(litera);
                    if (indeks % 2 == 0)
                        tekstZaszyfrowany += klucz[indeks + 1];
                    else
                        tekstZaszyfrowany += klucz[indeks - 1];
                }
                else
                    tekstZaszyfrowany += litera;
            }
            Console.WriteLine(tekstZaszyfrowany);
        }
    }
}
