using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooklyProjectNew.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        //hatayı gösterebilir misin burda ımageurl yeni ekledik

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }

}