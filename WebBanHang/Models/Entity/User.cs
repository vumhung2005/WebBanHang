using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Order> Orders    { get; set; }
        public User()
        {
           Orders = new List<Order>();
        }
    }
}