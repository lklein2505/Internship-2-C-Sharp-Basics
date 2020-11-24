using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

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
                { 3, "Dodi" },
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
                    case 4:
                        AddNewSong(songDict);
                        break;
                    case 5:
                        DeleteByIndex(songDict);
                        break;
                    case 6:
                        DeleteByName(songDict);
                        break;
                    case 7:
                        Console.WriteLine("Zelite izbrisati cijelu playlistu? (y/n)");
                        var confirmation = Console.ReadLine();
                if (confirmation == "y")
                        songDict.Clear();
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
                }
            }
            if (flag1 != 1)
                Console.WriteLine("Pjesma s tim nazivom ne postoji! Zelite li se vratiti u pocetni izbornik? (y/n)");
                if (Console.ReadLine() == "n")
                    exit = true;
        }

        static void AddNewSong(Dictionary<int, string> songDict)
        {
            Console.WriteLine("Unesite ime pjesme koju zelite dodati u listu: ");
            var newSong = Console.ReadLine();
            Console.WriteLine("Zelite dodati pjesmu '" + newSong + "' u playlistu? (y/n)");
            var confirmation = Console.ReadLine();
            if (confirmation == "y")
                songDict.Add(songDict.Count + 1, newSong);
        }

        static void DeleteByIndex(Dictionary<int, string> songDict)
        {
            Console.WriteLine("Unesite redni broj pjesmu koju zelite izbrisati: ");
            var deleteIndex = int.Parse(Console.ReadLine());
            if (deleteIndex > songDict.Count)
            {
                Console.WriteLine("Greska, nema pjesme pod tim rednim brojem! Zelite li se vratiti u pocetni izbornik? (y/n)");
                if (Console.ReadLine() == "n")
                    exit = true;
            }
            else
            {
                Console.WriteLine("Zelite izbrisati pjesmu pod rednim brojem " + deleteIndex + "? (y/n)");
                var confirmation = Console.ReadLine();
                if (confirmation == "y")
                {
                    if (deleteIndex == songDict.Count)
                        songDict.Remove(deleteIndex);
                    else
                    {
                        songDict.Remove(deleteIndex);
                        for (var i = deleteIndex; i < songDict.Count; i++)
                        {
                            songDict[i] = songDict[i + 1];
                        }
                        songDict.Remove(songDict.Count);
                    }
                }
            }
        }

        static void DeleteByName(Dictionary<int, string> songDict)
        {
            Console.WriteLine("Upisite ime pjesme koju zelite izbrisati iz playliste: ");
            var deleteSong = Console.ReadLine();
            var flag2 = 0;
            foreach (var pair in songDict)
            {
                if (deleteSong == pair.Value)
                {
                    flag2 = 1;
                    Console.WriteLine("Zelite izbrisati pjesmu '" + deleteSong + "'? (y/n)");
                    var confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        if (pair.Key == songDict.Count)
                            songDict.Remove(pair.Key);
                        else
                        {
                            songDict.Remove(pair.Key);
                            for (var i = pair.Key; i < songDict.Count; i++)
                            {
                                songDict[i] = songDict[i + 1];
                            }
                            songDict.Remove(songDict.Count);
                        }                                
                    }
                    break;
                }
            }
            if (flag2 != 1)
            {
                Console.WriteLine("Pjesma s tim nazivom ne postoji! Zelite li se vratiti u pocetni izbornik? (y/n)");
                if (Console.ReadLine() == "n")
                    exit = true;
            }
        }
    }
}
