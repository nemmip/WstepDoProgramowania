using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia9
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Zadanie 1
             */
            //Console.Write("Wpisz tekst: ");
            //string tekstUzytkownika = Console.ReadLine();
            //Console.WriteLine(Zadanie1(tekstUzytkownika));
            //Console.ReadLine();
            /*
             * Zadanie 2
             */
            //Console.Write("Wpisz tekst: ");
            //string tekstUzytkownika = Console.ReadLine();
            //Console.WriteLine(Zadanie2(tekstUzytkownika));
            //Console.ReadLine();
            /*
             * Zadanie 3
             */
            //int[] wektor1 = { 1, 2, 0 }, wektor2 = { 3, 1, -1 };
            //WyswietlWektor(wektor1);
            //Console.WriteLine();
            //WyswietlWektor(wektor2);
            //Console.WriteLine("\nIloczyn skalarny: {0}", IloczynSkalarny(wektor1, wektor2));
            //Console.ReadLine();
            /*
             * Zadanie 5.2
             */
            //double a, b, x;
            //Console.Write("Podaj liczbę a: ");
            //a = double.Parse(Console.ReadLine());
            //Console.Write("\nPodaj liczbę b: ");
            //b = double.Parse(Console.ReadLine());
            //Console.Write("\nPodaj liczbę x: ");
            //x = double.Parse(Console.ReadLine());
            //string wiadomość = Zadanie5_2(a,b,x) ? "należy" : "nie należy";
            //Console.WriteLine("Liczba {0} {1} do przedziału ({2};{3})", x, wiadomość, a, b);
            //Console.ReadLine();
            /*
             * Zadanie 5.3
             */
            //double aX, aY, wekX = 3.0, wekY = 2.0;
            //Console.Write("Podaj współrzędną x punktu A: ");
            //aX = double.Parse(Console.ReadLine());
            //Console.Write("\nPodaj współrzędną y punktu A: ");
            //aY = double.Parse(Console.ReadLine());
            //Console.WriteLine("Twój punkt ma współrzędne: {0};{1}", aX, aY);
            //Przesun(ref aX, ref aY, wekX, wekY);
            //Console.WriteLine("Po przesunięciu o wektor {0};{1} współrzędne punktu są równe {2};{3}", wekX, wekY, aX, aY);
            //Console.ReadLine();
            /*
             * Zadanie 5.4
             */
            int[] tablica = { 1, 4, 6, 8, 2 };
            Console.WriteLine("Podaj mnożnik: ");
            int mnoznik = int.Parse(Console.ReadLine());
            //foreach (int liczba in WariantA(tablica,mnoznik))
            //    Console.Write("{0,3}",liczba);
            WariantB(tablica, mnoznik, out int[] wyjscie);
            foreach (int liczba in wyjscie)
                Console.Write("{0,3}", liczba);
            Console.ReadLine();

        }
        static int Zadanie1(string tekst)
        {
            string liczba = default;    // łańcuch do którego będą dodawane cyfry

            foreach (char znak in tekst) //iteracja przez każdy znak w łańcuchu
            {
                if (int.TryParse(znak.ToString(), out int cyfra)) //sprawdzenie czy dany znak jest typu całkowitoliczbowego
                    liczba += znak; //jeśli tak to dodaj ten znak do nowego łańcucha
            }
            return int.Parse(liczba);   //dokonaj konwersji na int i zwróć liczbę
        }
        static string Zadanie2(string tekst)
        {
            string wyjscie = default;
            foreach (char znak in tekst)
            {
                if (Char.IsUpper(znak))
                    wyjscie += Char.ToLower(znak);
                else if (Char.IsLower(znak))
                    wyjscie += Char.ToUpper(znak);
                else
                    wyjscie += znak;
            }
            return wyjscie;
        }
        #region Zadanie3
        static void WyswietlWektor(int[] wektor)
        {
            foreach (int liczba in wektor)
            {
                Console.Write("{0,2}",liczba);
            }
        }
        static int IloczynSkalarny(int[] wektor1, int[] wektor2)
        {
            int iloczyn = default;
            if (wektor1.Length == wektor2.Length)
            {
                for (int i = 0; i < wektor1.Length; i++)
                {
                    iloczyn += wektor1[i] * wektor2[i];
                }
                return iloczyn;
            }
            else
                return 00;
        }
        #endregion
        static bool Zadanie5_2(double poczatek, double koniec, double liczba)
        {
            if (liczba > poczatek && liczba < koniec)
                return true;
            else
                return false;
        }
        #region Zadanie5_3
        static void Przesun(ref double xPunktu, ref double yPunktu, double xWek, double yWek)
        {
            xPunktu += xWek;
            yPunktu += yWek;
        }
        #endregion
        #region Zadanie5_4
        static int [] WariantA (int [] tab, int mnoznik)
        {
            int[] wyjscie = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++)
                wyjscie[i] = tab[i] * mnoznik;
            return wyjscie;
        }
        static void WariantB(int []tab, int mnoznik,out int[] wyjscie)
        {
            wyjscie = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++)
                wyjscie[i] = tab[i] * 2;
        }
        #endregion

    }
}
