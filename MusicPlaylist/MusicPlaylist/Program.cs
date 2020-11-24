using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace MusicPlaylist
{
    class Program
    {
        public static bool exit = false;
        static void Main(string[] args)
        {
            var songDict = new Dictionary<int, string>()
            {
                { 1, "Libar" },
                { 2, "Trag u beskraju" },
                { 3, "Dođi" },
                { 4, "Napile se ulice" },
                { 5, "Africa" },
                { 6, "Wonderwall" },
                { 7, "Yesterday" },
                { 8, "Blue" },
            };

            while (!exit)
            {
                Console.WriteLine("Odaberite akciju:\n" +
                "1 - Ispis cijele liste\n" +
                "2 - Ispis imena pjesme unosom pripadajuceg rednog broja\n" +
                "3 - Ispis rednog broja pjesme unosom pripadajuceg imena\n" +
                "4 - Unos nove pjesme\n" +
                "5 - Brisanje pjesme po rednom broju\n" +
                "6 - Brisanje pjesme po imenu\n" +
                "7 - Brisanje cijele liste\n" +
                "8 - Uredivanje imena pjesme\n" +
                "9 - Uredivanje rednog broja pjesme\n" +
                "0 - Izlaz iz aplikacije\n");

                var choosenAction = int.Parse(Console.ReadLine());
                switch (choosenAction)
                {
                    case 1:
                        PrintList(songDict);
                        break;
                    case 2:
                        PrintByIndex(songDict);
                        break;
                    case 3:
                        PrintTheIndex(songDict);
                        break;
                    case 0:
                        exit = true;
                        break;
                }
            }
            
        }

        static void PrintList(Dictionary<int, string> songDict)
        {
            foreach (var pair in songDict)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }
            exit = true;
        }

        static void PrintByIndex(Dictionary<int, string> songDict)
        {
            Console.WriteLine("\nIzaberi redni broj pjesme: ");
            var indexNumber = int.Parse(Console.ReadLine());

            if (indexNumber > songDict.Count)
            {
                Console.WriteLine("Greska, nema pjesme pod tim rednim brojem! Zelite li se vratiti u pocetni izbornik? (y/n)");
                if (Console.ReadLine() == "n")
                    exit = true;
            }
            else
            {
                foreach (var pair in songDict)
                {
                    if (indexNumber == pair.Key)
                        Console.WriteLine(pair.Value);
                }
                exit = true;
            }
        }

        static void PrintTheIndex(Dictionary<int, string> songDict)
        {
            Console.WriteLine("\nUpisite ime pjesme: ");
            var songName = (Console.ReadLine());
            var flag1 = 0;
            foreach (var pair in songDict)
            {
                if (songName == pair.Value)
                {
                    flag1 = 1;
                    Console.WriteLine(pair.Key);
                    exit = true;
                }
            }
            if (flag1 != 1)
                Console.WriteLine("Pjesma s tim nazivom ne postoji! Zelite li se vratiti u pocetni izbornik? (y/n)");
                if (Console.ReadLine() == "n")
                    exit = true;
        }
    }
}
