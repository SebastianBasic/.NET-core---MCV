using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _NET_core___MCV.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }

        public string ISBN { get; set; }
    }
}