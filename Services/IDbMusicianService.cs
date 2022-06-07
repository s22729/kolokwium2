using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolos8.Models.Dtos;

namespace kolos8.Services
{
    public interface IDbMusicianService
    {
        Task<MusicianDto> GetMusician(int id);

        Task DeleteMusician(int id); 
    }
}