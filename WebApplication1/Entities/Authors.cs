using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooklyProjectNew.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual List<Book> Books { get; set; } // yazarın birden fazla kitabı olabilir. //navigation property
    }
}