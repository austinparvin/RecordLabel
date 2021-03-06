using System;
using System.Collections.Generic;
using System.Linq;
using RecordLabel.Models;

namespace RecordLabel
{

    public class RecordLabelManager
    {
        public DatabaseContext Db { get; set; } = new DatabaseContext();
        public void AddBandToDb(string name, string countryOfOrigin, int numberOfMembers, string website, bool isSigned, string personOfContact, string contactPhoneNumber)
        {


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

            Db.Bands.Add(newBand);
            Db.SaveChanges();
        }

        public void ViewBands()
        {
            foreach (var b in Db.Bands)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"Id:                      {b.Id}");
                Console.WriteLine($"Name:                    {b.Name}");
                Console.WriteLine($"Country of Origin:       {b.CountryOfOrigin}");
                Console.WriteLine($"Number of Members:       {b.NumberOfMembers}");
                Console.WriteLine($"Website:                 {b.Website}");
                Console.WriteLine($"IsSigned:                {b.IsSigned}");
                Console.WriteLine($"PersonOfContact:         {b.PersonOfContact}");
                Console.WriteLine($"Contact phone number:    {b.ContactPhoneNumber}");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void IsSignedDbUpdate(bool isSigned, int bandId)
        {
            Db.Bands.First(b => b.Id == bandId).IsSigned = isSigned;
            Db.SaveChanges();

        }
        public int AddAlbumToDB(int bandId, string title, bool isExplicit, DateTime releaseDate)
        {
            var band = Db.Bands.First(b => b.Id == bandId);
            var albumToAdd = new Album()
            {
                Title = title,
                IsExplicit = isExplicit,
                ReleaseDate = releaseDate
            };

            band.Albums.Add(albumToAdd);
            Db.SaveChanges();

            return albumToAdd.Id;

        }

        public int AddSongToDB(int albumId, string songTitle, string songLryics, string songLength)
        {
            var album = Db.Albums.First(a => a.Id == albumId);
            var songToAdd = new Song()
            {
                Title = songTitle,
                Lyrics = songLryics,
                Length = songLength,
                // SongGenres = songGenres
            };

            album.Songs.Add(songToAdd);
            Db.SaveChanges();
            return songToAdd.Id;
        }

        public void GetAlbumsByBandId(int bandId)
        {
            var albums = Db.Albums.Where(b => b.BandId == bandId);

            foreach (var a in albums)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"Id:                   {a.Id}");
                Console.WriteLine($"Title:                {a.Title}");
                Console.WriteLine($"Is it Explicit:       {a.IsExplicit}");
                Console.WriteLine($"Release Date:         {a.ReleaseDate}");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("");
            }
        }
        public void GetSongsByAlbumId(int albumId)
        {
            var songs = Db.Songs.Where(s => s.AlbumId == albumId);

            foreach (var s in songs)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"Id:                  {s.Id}");
                Console.WriteLine($"Title:               {s.Title}");
                Console.WriteLine($"Lyrics:              {s.Lyrics}");
                Console.WriteLine($"Song Length:         {s.Length}");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("");
            }
        }
        public void ViewAllAlbums()
        {
            var albums = Db.Albums.OrderBy(a => a.ReleaseDate);
            foreach (var a in albums)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"Id:                   {a.Id}");
                Console.WriteLine($"Title:                {a.Title}");
                Console.WriteLine($"Is it Explicit:       {a.IsExplicit}");
                Console.WriteLine($"Release Date:         {a.ReleaseDate}");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ViewBandBasedOnIsSigned(bool isSigned)
        {
            var bands = Db.Bands.Where(b => b.IsSigned == isSigned);

            foreach (var b in bands)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"Id:                      {b.Id}");
                Console.WriteLine($"Name:                    {b.Name}");
                Console.WriteLine($"Country of Origin:       {b.CountryOfOrigin}");
                Console.WriteLine($"Number of Members:       {b.NumberOfMembers}");
                Console.WriteLine($"Website:                 {b.Website}");
                Console.WriteLine($"IsSigned:                {b.IsSigned}");
                Console.WriteLine($"PersonOfContact:         {b.PersonOfContact}");
                Console.WriteLine($"Contact phone number:    {b.ContactPhoneNumber}");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}