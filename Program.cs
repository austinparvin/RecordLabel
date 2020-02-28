using System;
using RecordLabel.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleTools;

namespace RecordLabel
{
    class Program
    {
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
            var db = new DatabaseContext();
            // Ask for Name
            System.Console.WriteLine("What is the Band name?");
            var name = Console.ReadLine().ToLower();

            // Ask for COO
            System.Console.WriteLine("What is their Country of Origin?");
            var countryOfOrigin = Console.ReadLine().ToLower();

            //Ask for number of members
            System.Console.WriteLine("How many members are in the band?");
            int numberOfMembers;
            var isInt = int.TryParse(Console.ReadLine(), out numberOfMembers);
            while (!isInt)
            {
                System.Console.WriteLine("That is not a number. Try again.");
                isInt = int.TryParse(Console.ReadLine(), out numberOfMembers);
            }

            // Ask for Website
            System.Console.WriteLine("What is their website?");
            var website = Console.ReadLine().ToLower();

            //Ask isSigned
            System.Console.WriteLine("Are they signed?");
            bool isSigned;
            var isBool = bool.TryParse(Console.ReadLine(), out isSigned);
            while (!isBool)
            {
                System.Console.WriteLine("That is not a valid answer. Try again.");
                isBool = bool.TryParse(Console.ReadLine(), out isSigned);
            }

            // Ask for Person of Contact
            System.Console.WriteLine("What is the person of contact?");
            var personOfContact = Console.ReadLine().ToLower();

            // Ask for contact Phone Number
            System.Console.WriteLine("What is their Phone Number?");
            var contactPhoneNumber = Console.ReadLine().ToLower();

            var newBand = new Band()
            {
                Name = name,
                CountryOfOrigin = countryOfOrigin,
                NumberOfMembers = numberOfMembers,
                Website = website,
                IsSigned = isSigned,
                PersonOfContact = personOfContact,
                ContactPhoneNumber = contactPhoneNumber
            };

            db.Bands.Add(newBand);
            db.SaveChanges();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ViewBands()
        {
            var db = new DatabaseContext();

            foreach (var b in db.Bands)
            {
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine($"Id:                      {b.Id}");
                System.Console.WriteLine($"Name:                    {b.Name}");
                System.Console.WriteLine($"Country of Origin:       {b.CountryOfOrigin}");
                System.Console.WriteLine($"Number of Members:       {b.NumberOfMembers}");
                System.Console.WriteLine($"Website:                 {b.Website}");
                System.Console.WriteLine($"IsSigned:                {b.IsSigned}");
                System.Console.WriteLine($"PersonOfContact:         {b.PersonOfContact}");
                System.Console.WriteLine($"Contact phone number:    {b.ContactPhoneNumber}");
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine("");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void IsSigned(bool isSigned)
        {
            var db = new DatabaseContext();
            ViewBands();
            System.Console.WriteLine("Which band?");
            int bandId;
            var isInt = int.TryParse(Console.ReadLine(), out bandId);
            var isInDb = db.Bands.Any(p => p.Id == bandId);
            while (!isInt || !isInDb)
            {
                if (!isInt)
                {
                    System.Console.WriteLine("That is not a number. Try again.");
                }
                else if (!isInDb)
                {
                    System.Console.WriteLine("That Id is not in the database. Try again.");
                }

                isInt = int.TryParse(Console.ReadLine(), out bandId);
                isInDb = db.Bands.Any(p => p.Id == bandId);
            }

            db.Bands.First(b => b.Id == bandId).IsSigned = isSigned;
            db.SaveChanges();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void AddAlbum()
        {
            // 1. Pick a Band
            var db = new DatabaseContext();
            ViewBands();
            System.Console.WriteLine("Which band?");
            int bandId;
            var isInt = int.TryParse(Console.ReadLine(), out bandId);
            var isInDb = db.Bands.Any(p => p.Id == bandId);
            while (!isInt || !isInDb)
            {
                if (!isInt)
                {
                    System.Console.WriteLine("That is not a number. Try again.");
                }
                else if (!isInDb)
                {
                    System.Console.WriteLine("That Id is not in the database. Try again.");
                }

                isInt = int.TryParse(Console.ReadLine(), out bandId);
                isInDb = db.Bands.Any(p => p.Id == bandId);
            }

            var band = db.Bands.First(b => b.Id == bandId);

            // 2. Give Album Info
            // Ask for Name
            System.Console.WriteLine("What is the title?");
            var title = Console.ReadLine().ToLower();

            //Ask isSigned
            System.Console.WriteLine("Is it explicit?");
            bool isExplicit;
            var isBool = bool.TryParse(Console.ReadLine(), out isExplicit);
            while (!isBool)
            {
                System.Console.WriteLine("That is not a valid answer. Try again.");
                isBool = bool.TryParse(Console.ReadLine(), out isExplicit);
            }

            // Ask for The last time it was watered
            System.Console.WriteLine("Release Date?");
            DateTime releaseDate;
            var isDate = DateTime.TryParse(Console.ReadLine(), out releaseDate);
            while (!isDate)
            {
                System.Console.WriteLine("That is not a valid date. Try again.");
                isDate = DateTime.TryParse(Console.ReadLine(), out releaseDate);
            }

            // 3. create album object to add
            var albumToAdd = new Album()
            {
                Title = title,
                IsExplicit = isExplicit,
                ReleaseDate = releaseDate
            };

            System.Console.WriteLine("Please enter info about songs:");
            // 4. Ask for songs
            while (UserInput != "q")
            {
                // 1. Ask if we need to add songs to the album


                // 2. Get Song Info
                // Ask for Name
                System.Console.WriteLine("What is the title?");
                var songTitle = Console.ReadLine().ToLower();

                // Ask for Lyrics
                System.Console.WriteLine("What are the lyrics?");
                var songLryics = Console.ReadLine().ToLower();


                // Ask for Lyrics
                System.Console.WriteLine("How long is the song?");
                var songLength = Console.ReadLine().ToLower();

                // 3. Create song object to add
                var songToAdd = new Song()
                {
                    Title = songTitle,
                    Lyrics = songLryics,
                    Length = songLength
                };

                albumToAdd.Songs.Add(songToAdd);

                System.Console.WriteLine("Add a song press enter, 'q' to quit");
                UserInput = Console.ReadLine();
                ValidateInput("", "q");
            }

            // 5. Add the album
            band.Albums.Add(albumToAdd);
            db.SaveChanges();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ViewAlbums()
        {
            var db = new DatabaseContext();
            ViewBands();
            System.Console.WriteLine("Which band?");
            int bandId;
            var isInt = int.TryParse(Console.ReadLine(), out bandId);
            var isInDb = db.Bands.Any(p => p.Id == bandId);
            while (!isInt || !isInDb)
            {
                if (!isInt)
                {
                    System.Console.WriteLine("That is not a number. Try again.");
                }
                else if (!isInDb)
                {
                    System.Console.WriteLine("That Id is not in the database. Try again.");
                }

                isInt = int.TryParse(Console.ReadLine(), out bandId);
                isInDb = db.Bands.Any(p => p.Id == bandId);
            }

            var albums = db.Albums.Where(b => b.BandId == bandId);

            foreach (var a in albums)
            {
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine($"Id:                   {a.Id}");
                System.Console.WriteLine($"Title:                {a.Title}");
                System.Console.WriteLine($"Is it Explicit:       {a.IsExplicit}");
                System.Console.WriteLine($"Release Date:         {a.ReleaseDate}");
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void ViewAllAlbums()
        {
            var db = new DatabaseContext();
            var albums = db.Albums.OrderBy(a => a.ReleaseDate);
            foreach (var a in albums)
            {
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine($"Id:                   {a.Id}");
                System.Console.WriteLine($"Title:                {a.Title}");
                System.Console.WriteLine($"Is it Explicit:       {a.IsExplicit}");
                System.Console.WriteLine($"Release Date:         {a.ReleaseDate}");
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine("");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        static void ViewSongs()
        {
            ViewAllAlbums();

            var db = new DatabaseContext();
            System.Console.WriteLine("Which Album?");
            int albumId;
            var isInt = int.TryParse(Console.ReadLine(), out albumId);
            var isInDb = db.Bands.Any(p => p.Id == albumId);
            while (!isInt || !isInDb)
            {
                if (!isInt)
                {
                    System.Console.WriteLine("That is not a number. Try again.");
                }
                else if (!isInDb)
                {
                    System.Console.WriteLine("That Id is not in the database. Try again.");
                }

                isInt = int.TryParse(Console.ReadLine(), out albumId);
                isInDb = db.Bands.Any(p => p.Id == albumId);
            }

            var songs = db.Songs.Where(s => s.AlbumId == albumId);

            foreach (var s in songs)
            {
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine($"Id:                  {s.Id}");
                System.Console.WriteLine($"Title:               {s.Title}");
                System.Console.WriteLine($"Lyrics:              {s.Lyrics}");
                System.Console.WriteLine($"Song Length:         {s.Length}");
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ViewBandBasedOnIsSigned(bool isSigned)
        {
            var db = new DatabaseContext();
            var bands = db.Bands.Where(b => b.IsSigned == isSigned);

            foreach (var b in bands)
            {
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine($"Id:                      {b.Id}");
                System.Console.WriteLine($"Name:                    {b.Name}");
                System.Console.WriteLine($"Country of Origin:       {b.CountryOfOrigin}");
                System.Console.WriteLine($"Number of Members:       {b.NumberOfMembers}");
                System.Console.WriteLine($"Website:                 {b.Website}");
                System.Console.WriteLine($"IsSigned:                {b.IsSigned}");
                System.Console.WriteLine($"PersonOfContact:         {b.PersonOfContact}");
                System.Console.WriteLine($"Contact phone number:    {b.ContactPhoneNumber}");
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void CreateMenu(string[] args)
        {
            var subMenu = new ConsoleMenu(args, level: 1)
              .Add("View all albums for a band", () => ViewAlbums())
              .Add("View all the albums, ordered by ReleaseDate", () => ViewAllAlbums())
              .Add("View an Album's songs", () => ViewSongs())
              .Add("View All bands that are signed", () => ViewBandBasedOnIsSigned(true))
              .Add("View all bands that are not signed", () => ViewBandBasedOnIsSigned(false))
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