using EFCcoreMySQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCcoreMySQL
{
    class Program
    {
        static ushort CreateAlbum(disquaireContext ctx, string title, short createdYear)
        {
            Album albumToCreate = new Album() { Title = title, CreatedYear = createdYear };
            ctx.Album.Add(albumToCreate);
            ctx.SaveChanges();
            return albumToCreate.Id;
        }
        static void UpdateAlbum(disquaireContext ctx, string title, short createdYear, ushort id)
        {
            Album albumToUpdate = ctx.Album.Find(id);
            albumToUpdate.Title = title;
            albumToUpdate.CreatedYear = createdYear;
            ctx.SaveChanges();
        }
        static void DeleteAlbum(disquaireContext ctx, ushort id)
        {
            Album albumToRemove = ctx.Album.Find(id);
            ctx.Album.Remove(albumToRemove);
            ctx.SaveChanges();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("EF Core...");

            disquaireContext ctx = new disquaireContext();

            //create
            Artist artistToCreate = new Artist() { Name = "Edith Piaf", Birthday = new DateTime(1919, 12, 01) };
            ctx.Artist.Add(artistToCreate);
            ctx.SaveChanges();

            //update
            artistToCreate.Birthday = new DateTime(1919, 10, 01);
            ctx.SaveChanges();

            // delete
            ctx.Artist.Remove(artistToCreate);
            ctx.SaveChanges();

            ushort id_album =  CreateAlbum(ctx, "fais dodo", 1980);

            UpdateAlbum(ctx, "compliation été 2021", 2021, id_album);

            DeleteAlbum(ctx, id_album);


            Console.WriteLine("query 1");
            using (disquaireContext context = new disquaireContext())
            {
                List<Album> albums = context.Album.Where(a => a.CreatedYear > 2000).ToList();

                foreach (Album album in albums)
                {
                    Console.WriteLine(album.Title + " " + album.CreatedYear);
                }
            }

            Console.WriteLine("query 2");
            using (disquaireContext context = new disquaireContext())
            {
                List<Album> albums = context.Album.Where(a => a.Title.StartsWith("L") && a.CreatedYear > 2000).ToList();

                foreach (Album album in albums)
                {
                    Console.WriteLine(album.Title + " " + album.CreatedYear);
                }
            }

            Console.WriteLine("query 3");
            using (disquaireContext context = new disquaireContext())
            {
                var query = from album in context.Album where album.CreatedYear == 2014 select album;
                var albums = query.ToList();
                foreach (Album album in albums)
                {
                    Console.WriteLine(album.Title + " " + album.CreatedYear);
                }
            }

            Console.WriteLine("query 4");
            using (disquaireContext context = new disquaireContext())
            {
                var albums = context.Album.FromSqlRaw("Select * from album where created_year<2000").ToList();
                foreach (Album album in albums)
                {
                    Console.WriteLine(album.Title + " " + album.CreatedYear);
                }
            }


            Console.WriteLine("query 5");
            using (disquaireContext context = new disquaireContext())
            {
                var query = from album_artist in context.AlbumArtist 
                            join artist in context.Artist
                            on album_artist.IdArtist equals artist.Id
                            join album in context.Album
                            on album_artist.IdAlbum equals album.Id
                            where album.CreatedYear > 2000
                            select new { artist, album};
                var res = query.ToList();
                foreach (var item in res)
                {
                    Console.WriteLine(item.artist.Name + " " + item.album.Title);
                }
            }



            /*
                SELECT distinct(artist.name)
                FROM album_artist
                INNER JOIN artist
                    ON album_artist.id_artist = artist.id
                INNER JOIN album
                    ON album_artist.id_album = album.id
                WHERE album.created_year > 2000;
             */
            Console.WriteLine("query 6");
            using (disquaireContext context = new disquaireContext())
            {
                var query = (
                        from album_artist in context.AlbumArtist
                        join artist in context.Artist
                        on album_artist.IdArtist equals artist.Id
                        join album in context.Album
                        on album_artist.IdAlbum equals album.Id
                        where album.CreatedYear > 2000
                        select artist
                    ).Distinct();
                
                var res = query.ToList();
                foreach (var item in res)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
