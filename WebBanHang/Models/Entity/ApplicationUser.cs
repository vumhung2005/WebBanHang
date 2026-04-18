using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebBanHang.Models.Entity
{
    public class ApplicationUser:IdentityUser
    {
        public String FullName { get; set; }
    }
}