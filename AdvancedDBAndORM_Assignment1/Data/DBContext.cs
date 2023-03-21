using AdvancedDBAndORM_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AdvancedDBAndORM_Assignment1.Models.ModelVM;
using System.Reflection.Metadata;

namespace AdvancedDBAndORM_Assignment1.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           //modelBuilder.Entity<Song>().UseTpcMappingStrategy()
           //     .ToTable("Songs");
           // modelBuilder.Entity<Episode>()
           //     .ToTable("Episodes");

            
        }
        public DbSet<Song> Songs { get; set; } = default!;
        public DbSet<Album> Albums { get; set; } = default!;
        public DbSet<Artist> Artists { get; set; } = default!;

        public DbSet<SongVersion> SongVersions { get; set; } = default!;
      
        public DbSet<Library> Librarys { get; set; } = default!;
        public DbSet<PlayList> PlayLists { get; set; } = default!;
        public DbSet<AdvancedDBAndORM_Assignment1.Models.ModelVM.SongVersionPlayListVM> SongVersionPlayListVM { get; set; }

        public DbSet<Podcast> Podcasts { get; set; } = default!;
        public DbSet<Episode> Episodes { get; set; } = default!;
        
        public DbSet<PodcastEpisode> PodcastEpisodes { get; set; } = default!;
        public DbSet<Listener> Listeners { get; set; } = default!;
        public DbSet<PodcastListener> PodcastListeners { get; set; } = default!;

    }
}
