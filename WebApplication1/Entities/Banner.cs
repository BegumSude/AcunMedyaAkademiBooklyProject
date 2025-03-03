using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooklyProjectNew.Entities
{
    public class Banner
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}