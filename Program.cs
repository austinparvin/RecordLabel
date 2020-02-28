﻿using System;
using RecordLabel.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleTools;
using System.Collections.Generic;

namespace RecordLabel
{
    class Program
    {
        static public RecordLabelManager RLM { get; set; } = new RecordLabelManager();
        static public string UserInput { get; set; } = "";
        static public void ValidateInput(string x, string y)
        {
            while (UserInput != x && UserInput != y)
            {
                Console.WriteLine("I'm sorry. That is not a valid input.");
                Console.WriteLine("");
                Console.WriteLine("Please try again");
                UserInput = Console.ReadLine().ToLower();
            }
        }
        static void AddBand()
        {
            // Ask for Name
            Console.WriteLine("What is the Band name?");
            var name = Console.ReadLine().ToLower();

            // Ask for COO
            Console.WriteLine("What is their Country of Origin?");
            var countryOfOrigin = Console.ReadLine().ToLower();

            //Ask for number of members
            Console.WriteLine("How many members are in the band?");
            int numberOfMembers;
            var isInt = int.TryParse(Console.ReadLine(), out numberOfMembers);
            while (!isInt)
            {
                Console.WriteLine("That is not a number. Try again.");
                isInt = int.TryParse(Console.ReadLine(), out numberOfMembers);
            }

            // Ask for Website
            Console.WriteLine("What is their website?");
            var website = Console.ReadLine().ToLower();

            //Ask isSigned
            Console.WriteLine("Are they signed?");
            bool isSigned;
            var isBool = bool.TryParse(Console.ReadLine(), out isSigned);
            while (!isBool)
            {
                Console.WriteLine("That is not a valid answer. Try again.");
                isBool = bool.TryParse(Console.ReadLine(), out isSigned);
            }

            // Ask for Person of Contact
            Console.WriteLine("What is the person of contact?");
            var personOfContact = Console.ReadLine().ToLower();

            // Ask for contact Phone Number
            Console.WriteLine("What is their Phone Number?");
            var contactPhoneNumber = Console.ReadLine().ToLower();

            RLM.AddBandToDb(name, countryOfOrigin, numberOfMembers, website, isSigned, personOfContact, contactPhoneNumber);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        static void IsSigned(bool isSigned)
        {
            RLM.ViewBands();

            Console.WriteLine("Which band?");

            int bandId;
            var isInt = int.TryParse(Console.ReadLine(), out bandId);
            var isInDb = RLM.Db.Bands.Any(p => p.Id == bandId);
            while (!isInt || !isInDb)
            {
                if (!isInt)
                {
                    Console.WriteLine("That is not a number. Try again.");
                }
                else if (!isInDb)
                {
                    Console.WriteLine("That Id is not in the database. Try again.");
                }

                isInt = int.TryParse(Console.ReadLine(), out bandId);
                isInDb = RLM.Db.Bands.Any(p => p.Id == bandId);
            }

            RLM.IsSignedDbUpdate(isSigned, bandId);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void AddAlbum()
        {
            // 1. Get a Band
            RLM.ViewBands();
            Console.WriteLine("Which band?");
            int bandId;
            var isInt = int.TryParse(Console.ReadLine(), out bandId);
            var isInDb = RLM.Db.Bands.Any(p => p.Id == bandId);
            while (!isInt || !isInDb)
            {
                if (!isInt)
                {
                    Console.WriteLine("That is not a number. Try again.");
                }
                else if (!isInDb)
                {
                    Console.WriteLine("That Id is not in the database. Try again.");
                }

                isInt = int.TryParse(Console.ReadLine(), out bandId);
                isInDb = RLM.Db.Bands.Any(p => p.Id == bandId);
            }

            // 2. Get Album Info
            // Ask for Name
            Console.WriteLine("What is the title?");
            var title = Console.ReadLine().ToLower();

            //Ask isSigned
            Console.WriteLine("Is it explicit?");
            bool isExplicit;
            var isBool = bool.TryParse(Console.ReadLine(), out isExplicit);
            while (!isBool)
            {
                Console.WriteLine("That is not a valid answer. Try again.");
                isBool = bool.TryParse(Console.ReadLine(), out isExplicit);
            }

            // Ask for The last time it was watered
            Console.WriteLine("Release Date?");
            DateTime releaseDate;
            var isDate = DateTime.TryParse(Console.ReadLine(), out releaseDate);
            while (!isDate)
            {
                Console.WriteLine("That is not a valid date. Try again.");
                isDate = DateTime.TryParse(Console.ReadLine(), out releaseDate);
            }

            // 3. Get songs
            Console.WriteLine("Please enter info about songs:");
            var songsToAdd = new List<Song>();

            while (UserInput != "q")
            {
                // 1. Ask if we need to add songs to the album


                // 2. Get Song Info
                // Ask for Name
                Console.WriteLine("What is the title?");
                var songTitle = Console.ReadLine().ToLower();

                // Ask for Lyrics
                Console.WriteLine("What are the lyrics?");
                var songLryics = Console.ReadLine().ToLower();


                // Ask for Lyrics
                Console.WriteLine("How long is the song?");
                var songLength = Console.ReadLine().ToLower();

                // 3. Create song object to add
                var songToAdd = new Song()
                {
                    Title = songTitle,
                    Lyrics = songLryics,
                    Length = songLength
                };

                songsToAdd.Add(songToAdd);

                Console.WriteLine("Add a song press enter, 'q' to quit");
                UserInput = Console.ReadLine();
                ValidateInput("", "q");
            }

            // 5. Add the album
            RLM.AddAlbumToDB(bandId, title, isExplicit, releaseDate, songsToAdd);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void ViewAlbums()
        {
            RLM.ViewBands();
            Console.WriteLine("Which band?");
            int bandId;
            var isInt = int.TryParse(Console.ReadLine(), out bandId);
            var isInDb = RLM.Db.Bands.Any(p => p.Id == bandId);
            while (!isInt || !isInDb)
            {
                if (!isInt)
                {
                    Console.WriteLine("That is not a number. Try again.");
                }
                else if (!isInDb)
                {
                    Console.WriteLine("That Id is not in the database. Try again.");
                }

                isInt = int.TryParse(Console.ReadLine(), out bandId);
                isInDb = RLM.Db.Bands.Any(p => p.Id == bandId);
            }

            RLM.GetAlbumsByBandId(bandId);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ViewSongs()
        {
            RLM.ViewAllAlbums();

            Console.WriteLine("Which Album?");
            int albumId;
            var isInt = int.TryParse(Console.ReadLine(), out albumId);
            var isInDb = RLM.Db.Bands.Any(p => p.Id == albumId);
            while (!isInt || !isInDb)
            {
                if (!isInt)
                {
                    Console.WriteLine("That is not a number. Try again.");
                }
                else if (!isInDb)
                {
                    Console.WriteLine("That Id is not in the database. Try again.");
                }

                isInt = int.TryParse(Console.ReadLine(), out albumId);
                isInDb = RLM.Db.Bands.Any(p => p.Id == albumId);
            }

            RLM.GetSongsByAlbumId(albumId);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void CreateMenu(string[] args)
        {
            var subMenu = new ConsoleMenu(args, level: 1)
              .Add("View all albums for a band", () => ViewAlbums())
              .Add("View all the albums, ordered by ReleaseDate", () => RLM.ViewAllAlbums())
              .Add("View an Album's songs", () => ViewSongs())
              .Add("View All bands that are signed", () => RLM.ViewBandBasedOnIsSigned(true))
              .Add("View all bands that are not signed", () => RLM.ViewBandBasedOnIsSigned(false))
              .Add("Sub_Close", ConsoleMenu.Close)
              .Add("Sub_Exit", () => Environment.Exit(0))
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.EnableFilter = false;
                  config.Title = "Submenu";
                  config.EnableBreadcrumb = true;
                  config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                  config.WriteItemAction = item => Console.Write("{0}", item.Name);
              });

            var menu = new ConsoleMenu(args, level: 0)
              .Add("Sign a band", () => AddBand())
              .Add("Produce an album", () => AddAlbum())
              .Add("Let go a band", () => IsSigned(false))
              .Add("Resign a band", () => IsSigned(true))
              .Add("View", subMenu.Show)
              .Add("Exit", () => Environment.Exit(0))
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.EnableFilter = false;
                  config.Title = "Main menu";
                  config.EnableWriteTitle = true;
                  config.EnableBreadcrumb = true;
                  config.WriteItemAction = item => Console.Write("{0}", item.Name);
              });

            menu.Show();
        }
        static void Main(string[] args)
        {
            CreateMenu(args);
        }
    }
}