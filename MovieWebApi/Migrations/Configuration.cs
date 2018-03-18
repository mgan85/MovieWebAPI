namespace MovieWebApi.Migrations
{
    using MovieWebApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieWebApi.Models.MovieWebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MovieWebApi.Models.MovieWebApiContext";
        }

        protected override void Seed(MovieWebApi.Models.MovieWebApiContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new User()
                {
                    Id = 1,
                    Login = "mgan",
                    Name = "Marcin",
                    Surname = "Ganczarek"
                },
                new User()
                {
                    Id = 2,
                    Login = "jankowalski",
                    Name = "Jan",
                    Surname = "Kowalsko"
                },
                new User()
                {
                    Id = 3,
                    Login = "mgan85",
                    Name = "Mariusz",
                    Surname = "Gawron"
                },
                new User()
                {
                    Id = 3,
                    Login = "smith",
                    Name = "John",
                    Surname = "Smith"
                }
            );

            context.Movies.AddOrUpdate(x => x.Id,
                new Movie()
                {
                    Id = 1,
                    Title = "The Blind Side",
                    ReleaseYear = 2009,
                    Genre = Movie.MovieGenre.Biography.ToString()
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Intouchables",
                    ReleaseYear = 2011,
                    Genre = Movie.MovieGenre.Biography.ToString()
                },
                new Movie()
                {
                    Id = 3,
                    Title = "El laberinto del fauno",
                    ReleaseYear = 2006,
                    Genre = Movie.MovieGenre.Fantasy.ToString()
                },
                new Movie()
                {
                    Id = 4,
                    Title = "Lord of War",
                    ReleaseYear = 2005,
                    Genre = Movie.MovieGenre.Drama.ToString()
                },
                new Movie()
                {
                    Id = 5,
                    Title = "Qu'est-ce qu'on a fait au Bon Dieu?",
                    ReleaseYear = 2014,
                    Genre = Movie.MovieGenre.Comedy.ToString()
                },
                new Movie()
                {
                    Id = 6,
                    Title = "The Pianist",
                    ReleaseYear = 2002,
                    Genre = Movie.MovieGenre.Drama.ToString()
                },
                new Movie()
                {
                    Id = 7,
                    Title = "The Rock",
                    ReleaseYear = 1996,
                    Genre = Movie.MovieGenre.Action.ToString()
                },
                new Movie()
                {
                    Id = 8,
                    Title = "How to Train Your Dragon",
                    ReleaseYear = 2010,
                    Genre = Movie.MovieGenre.Action.ToString()
                }
           );
        }
    }
}
