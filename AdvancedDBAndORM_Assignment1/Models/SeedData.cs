using AdvancedDBAndORM_Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Transactions;

namespace AdvancedDBAndORM_Assignment1.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            DBContext context = new DBContext(serviceProvider.GetRequiredService<DbContextOptions<DBContext>>());
            if (!context.SongVersions.Any())
            {
                Artist artist = new Artist("Mariah Carey");
                context.Artists.Add(artist);
                await context.SaveChangesAsync();

                Album album = new Album("Music Box");
                context.Albums.Add(album);
                await context.SaveChangesAsync();

                Song song = new Song("Hero");
                context.Songs.Add(song);
                await context.SaveChangesAsync();
                Song song1 = new Song("Ill Be There");
                context.Songs.Add(song1);
                await context.SaveChangesAsync();
                Song song2 = new Song("When You Believe");
                context.Songs.Add(song2);
                await context.SaveChangesAsync();

                context.SongVersions.Add(new SongVersion(song.ID,artist.ID,album.ID,230));
                context.SongVersions.Add(new SongVersion(song1.ID, artist.ID, album.ID, 240));
                context.SongVersions.Add(new SongVersion(song2.ID, artist.ID, album.ID, 250));
                await context.SaveChangesAsync();


                Artist artist1 = new Artist("Whitney Houston");
                context.Artists.Add(artist1);
                await context.SaveChangesAsync();

                Album album1 = new Album("Whitney Houston");
                context.Albums.Add(album1);
                await context.SaveChangesAsync();

                Song song3 = new Song("One Moment in Time");
                context.Songs.Add(song3);
                await context.SaveChangesAsync();
                Song song4 = new Song("Without You");
                context.Songs.Add(song4);
                await context.SaveChangesAsync();
                Song song5 = new Song("How Will I Konw");
                context.Songs.Add(song5);
                await context.SaveChangesAsync();

                context.SongVersions.Add(new SongVersion(song3.ID, artist1.ID, album1.ID, 230));
                context.SongVersions.Add(new SongVersion(song4.ID, artist1.ID, album1.ID, 240));
                context.SongVersions.Add(new SongVersion(song5.ID, artist1.ID, album1.ID, 250));
                await context.SaveChangesAsync();


                Artist artist2 = new Artist("Celine Dion");
                context.Artists.Add(artist2);
                await context.SaveChangesAsync();

                Album album2 = new Album("My Love Is Your Love");
                context.Albums.Add(album2);
                await context.SaveChangesAsync();

                Song song6 = new Song("My Heart Will Go On");
                context.Songs.Add(song6);
                await context.SaveChangesAsync();
                Song song7 = new Song("I Look to You");
                context.Songs.Add(song7);
                await context.SaveChangesAsync();
                Song song8 = new Song("My Love Is Your Love");
                context.Songs.Add(song8);
                await context.SaveChangesAsync();

                context.SongVersions.Add(new SongVersion(song6.ID, artist2.ID, album2.ID, 230));
                context.SongVersions.Add(new SongVersion(song7.ID, artist2.ID, album2.ID, 240));
                context.SongVersions.Add(new SongVersion(song8.ID, artist2.ID, album2.ID, 250));
                await context.SaveChangesAsync();

                Artist artist3 = new Artist("Michael Jackson");
                context.Artists.Add(artist3);
                await context.SaveChangesAsync();

                Album album3 = new Album("History - Past");
                context.Albums.Add(album3);
                await context.SaveChangesAsync();

                Song song9 = new Song("Billie Jean");
                context.Songs.Add(song9);
                await context.SaveChangesAsync();
                Song song10 = new Song("They Dont Care About Us");
                context.Songs.Add(song10);
                await context.SaveChangesAsync();
                Song song11 = new Song("We Are The World");
                context.Songs.Add(song11);
                await context.SaveChangesAsync();

                SongVersion songVersion1 = new SongVersion(song9.ID, artist3.ID, album3.ID, 230);
                context.SongVersions.Add(songVersion1);
                await context.SaveChangesAsync();
                SongVersion songVersion2 = new SongVersion(song10.ID, artist3.ID, album3.ID, 240);
                context.SongVersions.Add(songVersion2);
                await context.SaveChangesAsync();
                SongVersion songVersion3 = new SongVersion(song11.ID, artist3.ID, album3.ID, 250);
                context.SongVersions.Add(songVersion3);
                await context.SaveChangesAsync();

               

                Artist artist4 = new Artist("Emilia");
                context.Artists.Add(artist4);
                await context.SaveChangesAsync();

                Album album4 = new Album("Big Big World");
                context.Albums.Add(album4);
                await context.SaveChangesAsync();

                Song song12 = new Song("Big Big World");
                context.Songs.Add(song12);
                await context.SaveChangesAsync();

                context.SongVersions.Add(new SongVersion(song12.ID, artist4.ID, album4.ID, 250));
                await context.SaveChangesAsync();



                Artist artist5 = new Artist("Adele");
                context.Artists.Add(artist5);
                await context.SaveChangesAsync();

                Album album5 = new Album("21");
                context.Albums.Add(album5);
                await context.SaveChangesAsync();

                Song song13 = new Song("Halo");
                context.Songs.Add(song13);
                await context.SaveChangesAsync();
                Song song14 = new Song("Someone Like You");
                context.Songs.Add(song14);
                await context.SaveChangesAsync();
                Song song15 = new Song("Easy On Me");
                context.Songs.Add(song15);
                await context.SaveChangesAsync();

                SongVersion songVersion4 = new SongVersion(song13.ID, artist5.ID, album5.ID, 230);
                context.SongVersions.Add(songVersion4);
                await context.SaveChangesAsync();
                SongVersion songVersion5 = new SongVersion(song14.ID, artist5.ID, album5.ID, 240);
                context.SongVersions.Add(songVersion5);
                await context.SaveChangesAsync();
                SongVersion songVersion6 = new SongVersion(song15.ID, artist5.ID, album5.ID, 250);
                context.SongVersions.Add(songVersion6);
                await context.SaveChangesAsync();
 

                Album album6 = new Album("25");
                context.Albums.Add(album6);
                await context.SaveChangesAsync();

                Song song16 = new Song("Rolling In the Deep");
                context.Songs.Add(song16);
                await context.SaveChangesAsync();
                Song song17 = new Song("Hello");
                context.Songs.Add(song17);
                await context.SaveChangesAsync();
                Song song18 = new Song("When We Were Young");
                context.Songs.Add(song18);
                await context.SaveChangesAsync();
                Song song19 = new Song("Love In The Dark");
                context.Songs.Add(song19);
                await context.SaveChangesAsync();
                Song song20 = new Song("Someone");
                context.Songs.Add(song20);
                await context.SaveChangesAsync();

           

                context.SongVersions.Add(new SongVersion(song16.ID, artist5.ID, album6.ID, 230));
                context.SongVersions.Add(new SongVersion(song17.ID, artist5.ID, album6.ID, 240));           
                await context.SaveChangesAsync();
               
                SongVersion songVersion7 = new SongVersion(song18.ID, artist5.ID, album6.ID, 230);
                context.SongVersions.Add(songVersion7);
                await context.SaveChangesAsync();
                SongVersion songVersion8 = new SongVersion(song19.ID, artist5.ID, album6.ID, 240);
                context.SongVersions.Add(songVersion8);
                await context.SaveChangesAsync();
                SongVersion songVersion9 = new SongVersion(song20.ID, artist5.ID, album6.ID, 250);
                context.SongVersions.Add(songVersion9);
                await context.SaveChangesAsync();

                Library library= new Library("MySample1");
                context.Librarys.Add(library);
                await context.SaveChangesAsync();

                context.PlayLists.Add(new PlayList(library.ID, songVersion1.ID));
                context.PlayLists.Add(new PlayList(library.ID, songVersion2.ID));
                context.PlayLists.Add(new PlayList(library.ID, songVersion3.ID));
                await context.SaveChangesAsync();

                Library library2 = new Library("MySample2");
                context.Librarys.Add(library2);
                await context.SaveChangesAsync();

                context.PlayLists.Add(new PlayList(library2.ID, songVersion4.ID));
                context.PlayLists.Add(new PlayList(library2.ID, songVersion5.ID));
                context.PlayLists.Add(new PlayList(library2.ID, songVersion6.ID));
                await context.SaveChangesAsync();

                Library library3 = new Library("MySample3");
                context.Librarys.Add(library3);
                await context.SaveChangesAsync();

                context.PlayLists.Add(new PlayList(library3.ID, songVersion7.ID));
                context.PlayLists.Add(new PlayList(library3.ID, songVersion8.ID));
                context.PlayLists.Add(new PlayList(library3.ID, songVersion9.ID));
                await context.SaveChangesAsync();


            }
         



        }
    }
}
