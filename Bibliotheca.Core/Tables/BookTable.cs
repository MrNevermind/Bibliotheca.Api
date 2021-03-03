using Bibliotheca.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bibliotheca.Core.Tables
{
    [Table("BookTable")]
    public class BookTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public byte[] Cover { get; set; }
        public BookStatus Status { get; set; }
        public AccountTable Account { get; set; }
    }
}
