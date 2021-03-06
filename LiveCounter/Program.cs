﻿using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace LiveCounter
{
    class Program
    {
        public static string totalCases;
        public static string totalDeaths;
        public static string totalRecovered;
        public static string currentCases;

        static void Main(string[] args)
        {
            Console.Title = "Live Corona Counter | Refreshing every 2 Seconds";
            drawAscii();
            drawBox();

            while (true)
            {
                getInfo();
                Console.SetCursorPosition(46, 15);
                Console.WriteLine("Total Cases:     " + totalCases);
                Console.SetCursorPosition(46, 16);
                Console.WriteLine("Total Deaths:    " + totalDeaths);
                Console.SetCursorPosition(46, 17);
                Console.WriteLine("Total Recovered: " + totalRecovered);
                Console.SetCursorPosition(46, 18);
                Console.WriteLine("Active Cases:    " + currentCases);

                Thread.Sleep(2000);
            }
        }

        public static int getInfo()
        {
            WebClient wb = new WebClient();
            string downloadStat = wb.DownloadString("https://www.worldometers.info/coronavirus/");
            var splitString = Regex.Split(downloadStat, "style>");

            foreach (string item in splitString)
            {
                if (item.Contains("<h1>Coronavirus Cases:</h1>"))
                {
                    var splitItem = Regex.Split(item, ">");

                    /* Enable this to Debug, in case the current Locations of the Numbers change!!!
                    int number = 0;
                    foreach(string idkkdk in splitItem)
                    {
                        Console.WriteLine(idkkdk + "[" + number + "]");
                        number++;
                    }*/

                    totalCases = splitItem[19].Replace(" </span", "");
                    totalDeaths = splitItem[31].Replace("</span", "");
                    totalRecovered = splitItem[39].Replace("</span", "");

                    string replaceCommaCases = totalCases.Replace(",", "");
                    string replaceCommaRecovered = totalRecovered.Replace(",", "");
                    string replaceCommaDead = totalDeaths.Replace(",", "");

                    int x = Int32.Parse(replaceCommaCases);
                    int y = Int32.Parse(replaceCommaRecovered);
                    int z = Int32.Parse(replaceCommaDead);
                    int currentCasesInt = x - y - z;

                    string formatted = currentCasesInt.ToString("N0");
                    string formatwithComma = formatted.Replace(".", ",");

                    currentCases = formatwithComma;
                }
            }

            return 0;
        }

        public static int drawAscii()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("   ██████╗ ██████╗ ██████╗  ██████╗ ███╗   ██╗ █████╗     ██████╗ ██████╗ ██╗   ██╗███╗   ██╗████████╗███████╗██████╗ ");
            Console.WriteLine("  ██╔════╝██╔═══██╗██╔══██╗██╔═══██╗████╗  ██║██╔══██╗   ██╔════╝██╔═══██╗██║   ██║████╗  ██║╚══██╔══╝██╔════╝██╔══██╗");
            Console.WriteLine("  ██║     ██║   ██║██████╔╝██║   ██║██╔██╗ ██║███████║   ██║     ██║   ██║██║   ██║██╔██╗ ██║   ██║   █████╗  ██████╔╝");
            Console.WriteLine("  ██║     ██║   ██║██╔══██╗██║   ██║██║╚██╗██║██╔══██║   ██║     ██║   ██║██║   ██║██║╚██╗██║   ██║   ██╔══╝  ██╔══██╗");
            Console.WriteLine("  ╚██████╗╚██████╔╝██║  ██║╚██████╔╝██║ ╚████║██║  ██║   ╚██████╗╚██████╔╝╚██████╔╝██║ ╚████║   ██║   ███████╗██║  ██║");
            Console.WriteLine("   ╚═════╝ ╚═════╝ ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝    ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚═╝  ╚═╝");
            Console.ResetColor();

            return 0;
        }

        public static int drawBox()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("                                           ╔════════════════════════════════╗");
            Console.WriteLine("                                           ║                                ║");
            Console.WriteLine("                                           ║                                ║");
            Console.WriteLine("                                           ║           Loading...           ║");
            Console.WriteLine("                                           ║                                ║");
            Console.WriteLine("                                           ║                                ║");
            Console.WriteLine("                                           ║                                ║");
            Console.WriteLine("                                           ╚════════════════════════════════╝");
            Console.ResetColor();

            return 0;
        }
    }
}
