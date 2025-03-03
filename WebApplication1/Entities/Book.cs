using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooklyProjectNew.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Price { get; set; }

        public int DiscountRate { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; } //bir kitabın 1 adet yazarı olabilir.

        public virtual List<BookCategories> BookCategories { get; set; }

        public int Review { get; set; }
        public bool IsOnSale { get; set; }
    }
}