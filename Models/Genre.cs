using System.Collections.Generic;

namespace RecordLabel.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SongGenre> SongGenres { get; set; }
    }
}