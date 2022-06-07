using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos8.Models.Dtos
{
    public class MusicianDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public IEnumerable<TrackDto> Tracks { get; set; }
    }
}