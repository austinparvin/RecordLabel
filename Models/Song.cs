using System;
using System.Collections.Generic;

namespace RecordLabel.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public string Length { get; set; }

        public List<SongGenre> SongGenres { get; set; }
        // Navigation Properties
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}