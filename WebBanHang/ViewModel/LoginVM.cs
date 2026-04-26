using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Can Not Be Blank")]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
    }
}