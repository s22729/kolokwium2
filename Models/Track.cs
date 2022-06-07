using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos8.Models
{
    public class Track
    {
        [Key]
        public int IdTrack { get; set; }
        [Required]
        [MaxLength(20)]
        public string TrackName { get; set; }
        [Required]
        public float Duration { get; set; } 

        public int IdMusicAlbum { get; set; }

        [ForeignKey("IdMusicAlbum")]
        public virtual Album Album {get; set;}

        public virtual IEnumerable<Musician> Musicians{get;set;}
    }
}