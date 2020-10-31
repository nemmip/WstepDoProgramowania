/*
 * do funkcji jest przekazywana tablica dwuwymiarowa charów 8x8(szachownica)wypełniona '0'  
 * i parametry x i y. x i y to położenie gońca na szachownicy. Twoim zadaniem jest wyświetlić 
 * obszar w jakim może się poruszyć ten goniec na szachownicy przez zamienienie '0' na 'X'

x i y mogą być randomowe, byle nie wykraczały poza szachownicę
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachownica
{
    class Program
    {
        static void Main(string[] args)
        {
            // tytuł okna XD
            Console.Title = "Pozycja Gońca";

            //generator liczb pseudolosowych
            Random random = new Random();

            // zmienna x określająca położenie gońca na osi literowej 
            int x= random.Next(0, 8);

            // zmienna y okreslajaca polozenie gonca na osi liczbowej
            int y= random.Next(0, 8);

            //Console.WriteLine("Podaj współrzędną x");
            //x = int.Parse(Console.ReadLine());
            //Console.WriteLine("Podaj współrzędną y");
            //y = int.Parse(Console.ReadLine());

            // tablica dwuwymiarowa charow
            char[,] szachownica = new char[8,8];

            //petla na wypełnienie tablicy '0
            for (int i = 0; i< szachownica.GetLength(1); i++)
            {
                for (int j = 0; j< szachownica.GetLength(0); j++)
                    szachownica[j, i] = '0';
            }
            // użycie funkcji
            ruchGonca(szachownica, x, y);
            //napisanie współrzędnych gońca
            Console.WriteLine($"{x} {y}");
            for (int i = 0; i < szachownica.GetLength(1); i++)
            {
                for (int j = 0; j < szachownica.GetLength(0); j++)
                {
                    // wyświetlenie tablicy i nadanie odpowiednich kolorów
                    if (szachownica[j,i]=='G')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{szachownica[j, i],3}");
                    }
                    else if (szachownica[j,i]=='X')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"{szachownica[j, i],3}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"{szachownica[j, i],3}");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// funkcja przyjmuje szachownicę i pozycję gońca, a następnie oblicza wszystkie możliwe pola ruchu dla tej figury
        /// </summary>
        /// <param name="tablica">szachownica wypełniona zerami</param>
        /// <param name="pozycjaX">pozycja gonca na osi literowej</param>
        /// <param name="pozycjaY">pozycja gonca na osi liczbowej</param>
        /// <returns>tablice z zaznaczona pozycja gonca oraz polami ruchu</returns>
        static char[,] ruchGonca(char[,] tablica, int pozycjaX, int pozycjaY)
        {
            //zmienna ruchu lewo gora
            int lewoGoraX ,lewoGoraY;   // x maleje y rosnie
            //zmienna ruchu prawo gora
            int prawoGoraX, prawoGoraY;  //x rosnie y rosnie
            //zmienna ruchu lewo dol 
            int lewoDolX, lewoDolY;    // x maleje y maleje
            //zmienna ruchu prawo dol
            int prawoDolX, prawoDolY;   // x rosnie y maleje


            // ruch w lewo i w górę
            lewoGoraY = pozycjaY; lewoGoraX = pozycjaX;
            while (lewoGoraY < tablica.GetLength(0) && lewoGoraX >= 0)
            {
                tablica[lewoGoraX, lewoGoraY] = 'X';
                lewoGoraY++; lewoGoraX--;
            }

            // ruch w prawo i w górę
            prawoGoraX = pozycjaX; prawoGoraY = pozycjaY;
            while (prawoGoraX< tablica.GetLength(0) && prawoGoraY<tablica.GetLength(1))
            {
                tablica[prawoGoraX, prawoGoraY] = 'X';
                prawoGoraX++; prawoGoraY++;
            }
            // ruch lewo dol
            lewoDolX = pozycjaX; lewoDolY = pozycjaY;
            while(lewoDolX>=0 && lewoDolY>=0)
            {
                tablica[lewoDolX, lewoDolY] = 'X';
                lewoDolX--; lewoDolY--;
            }
            // ruch prawo dol
            prawoDolX = pozycjaX; prawoDolY = pozycjaY;
            while(prawoDolX<tablica.GetLength(0) && prawoDolY>=0)
            {
                tablica[prawoDolX, prawoDolY] = 'X';
                prawoDolX++; prawoDolY--;
            }

            // przypisanie pozycji gońca na szachownicy
            tablica[pozycjaX, pozycjaY] = 'G';

            return tablica;
        }
       
    }
}
