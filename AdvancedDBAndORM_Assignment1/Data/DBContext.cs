using AdvancedDBAndORM_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AdvancedDBAndORM_Assignment1.Models.ModelVM;

namespace AdvancedDBAndORM_Assignment1.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; } = default!;
        public DbSet<Album> Albums { get; set; } = default!;
        public DbSet<Artist> Artists { get; set; } = default!;
        public DbSet<SongVersion> SongVersions { get; set; } = default!;
      
        public DbSet<Library> Librarys { get; set; } = default!;
        public DbSet<PlayList> PlayLists { get; set; } = default!;
        public DbSet<AdvancedDBAndORM_Assignment1.Models.ModelVM.SongVersionPlayListVM> SongVersionPlayListVM { get; set; }


    }
}
