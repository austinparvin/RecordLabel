namespace RecordLabel.Models
{
    public class SongGenre
    {
        public int SongGenreId { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}