using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kolos8.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext(){

        }

        public MainDbContext(DbContextOptions options) : base(options){

        }

        public DbSet<Musician> Musicians{get;set;}
        public DbSet<Musician_Track> Musician_Track{get;set;}
        public DbSet<Track> Tracks{get;set;}
        public DbSet<Album> Albums{get;set;}
        public DbSet<MusicLabel> MusicLabels{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
            optionBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician_Track>().HasKey(e => new {e.IdMusician, e.IdTrack});

            modelBuilder.Entity<Musician>().HasData(
                new Musician{
                    IdMusician = 1,
                    FristName = "Ryszard",
                    LastName = "Andrzejewski",
                    NickName = "Peja"
                }
            );
            modelBuilder.Entity<Track>().HasData(
                new Track{
                    IdTrack = 1,
                    TrackName = "997",
                    Duration = 2.00f,
                    IdMusicAlbum = 1  
                }
            );
            modelBuilder.Entity<Musician_Track>().HasData(
                new Musician_Track{
                    IdTrack = 1,
                    IdMusician = 1
                }
            );
            modelBuilder.Entity<Album>().HasData(
                new Album{
                    IdAlbum = 1,
                    AlbumName = "Slums attack",
                    PublishDate = DateTime.Now,
                    IdMusicLabel = 1
                }
            );
            modelBuilder.Entity<MusicLabel>().HasData(
                new MusicLabel{
                    IdMusicLabel = 1,
                    Name = "nie wiem"
                }
            );
        }

    }
}