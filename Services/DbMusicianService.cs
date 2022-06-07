using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolos8.Models;
using kolos8.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace kolos8.Services
{
    public class DbMusicianService : IDbMusicianService
    {   
        private readonly MainDbContext _dbContext;

        public DbMusicianService(MainDbContext dbContext){
            _dbContext = dbContext;
        }

        public async Task<MusicianDto> GetMusician(int id){
            return _dbContext.Musicians
            .Include(e => e.Tracks)
            .Where(e => e.IdMusician == id)
            .Select(e => new MusicianDto{
                FirstName = e.FristName,
                LastName = e.LastName,
                NickName = e.NickName,
                Tracks = e.Tracks
                    .ToList()
                    .OrderBy(n => n.Duration)
                    .Select(t => new TrackDto{
                        TrackName = t.TrackName,
                        Duration = t.Duration
                    })
            }).First();
        }

        public async Task DeleteMusician(int id){
            Musician musician = _dbContext.Musicians.Where(e => e.IdMusician == id).First();
            IEnumerable<Track> tracks = _dbContext.Tracks.Where(e=>e.Musicians.Contains(musician)).ToList();
            if(tracks.Count() > 0){
                _dbContext.Musicians.Remove(musician);
                _dbContext.Tracks.RemoveRange(musician.Tracks);
                _dbContext.Musician_Track.RemoveRange(_dbContext.Musician_Track.Where(e => e.IdMusician == musician.IdMusician).ToList());
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}