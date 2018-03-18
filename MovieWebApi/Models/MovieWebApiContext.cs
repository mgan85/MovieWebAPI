using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieWebApi.Models
{
    public class MovieWebApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MovieWebApiContext() : base("name=MovieWebApiContext")
        {
        }

        public System.Data.Entity.DbSet<MovieWebApi.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<MovieWebApi.Models.Rate> Rates { get; set; }

        public System.Data.Entity.DbSet<MovieWebApi.Models.User> Users { get; set; }
    }
}
