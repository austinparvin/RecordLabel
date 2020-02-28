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
        public void AddAlbumToDB(int bandId, string title, bool isExplicit, DateTime releaseDate, List<Song> songsToAdd)
        {
            var band = Db.Bands.First(b => b.Id == bandId);
            var albumToAdd = new Album()
            {
                Title = title,
                IsExplicit = isExplicit,
                ReleaseDate = releaseDate,
                Songs = songsToAdd
            };

            band.Albums.Add(albumToAdd);
            Db.SaveChanges();

        }

        public void GetAlbumsByBandId(int bandId){
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
    }
}