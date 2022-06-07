using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos8.Models
{
    public class Musician_Track
    {
        [Required]
        public int IdTrack { get; set; }
        [Required]
        public int IdMusician { get; set; }

        [ForeignKey("IdMusician")]
        public virtual Musician Musician{get;set;}

        [ForeignKey("IdTrack")]
        public virtual Track Track{get;set;}
    }
}