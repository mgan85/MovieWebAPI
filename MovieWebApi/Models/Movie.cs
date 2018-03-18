using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieWebApi.Models
{
    public class Movie
    {
        public enum MovieGenre
        {
            Action,
            Drama,
            SF,
            Fantasy,
            Comedy,
            Horror,
            Biography,
            Animation
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public int RunningTime { get; set; }
        public double AverageRating { get; set; }
    }
}