using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooklyProjectNew.Models
{
    public class ChangePasswordViewModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }


        [Compare("NewPassword", ErrorMessage="Şifreler birbiri ile eşleşmiyor!!!")]

        public string ConfirmPassword { get; set; }
    }
}