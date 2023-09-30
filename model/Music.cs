using System.ComponentModel.DataAnnotations;

namespace mymusic.model
{
    public class Music
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Composer { get; set; }

        [Required]
        public string Album { get; set; }

        [Required]
        public string MusicalGenre { get; set; }

        [Required]
        public double Duration { get; set; }
    }
}
