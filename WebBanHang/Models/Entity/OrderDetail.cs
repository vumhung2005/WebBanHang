using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.Entity
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public double TotalPrice {  get; set; }

    }
}