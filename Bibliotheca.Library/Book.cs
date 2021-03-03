using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheca.Library
{
    public class Book
    {
        public int? Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public byte[] Cover { get; set; }
        public BookStatus Status { get; set; }
    }
}
