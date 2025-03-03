using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooklyProjectNew.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<BookCategories> BookCategories { get; set; }
    }
}