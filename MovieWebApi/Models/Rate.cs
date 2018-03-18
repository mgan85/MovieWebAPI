using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieWebApi.Models
{
    public class Rate
    {
        [Key]
        [Column(Order = 1)]
        public int MovieId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}