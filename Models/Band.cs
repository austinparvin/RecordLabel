using System.Collections.Generic;

namespace RecordLabel.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public bool IsSigned { get; set; }
        public string PersonOfContact { get; set; }
        public string ContactPhoneNumber { get; set; }

        public List<Album> Albums { get; set; } = new List<Album>();
    }
}