using System;
using RecordLabel.Models;

namespace RecordLabel
{

    public class RecordLabelManager
    {
        public void AddBandToDb(string name, string countryOfOrigin, int numberOfMembers, string website, bool isSigned, string personOfContact, string contactPhoneNumber)
        {
            var db = new DatabaseContext();

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
        }

        public void ViewBands()
        {
            var db = new DatabaseContext();

            foreach (var b in db.Bands)
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