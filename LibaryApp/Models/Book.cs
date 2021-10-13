using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LibaryApp.Models
{
    [Table("books")]
    public partial class Book
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("author_name")]
        [StringLength(50)]
        public string AuthorName { get; set; }
        [Column("rented")]
        public bool? Rented { get; set; }
    }
}
