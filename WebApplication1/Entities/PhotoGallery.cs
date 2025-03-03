using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooklyProjectNew.Entities
{
    public class PhotoGallery
    {
        public int PhotoGalleryId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsShown { get; set; }
    }
}