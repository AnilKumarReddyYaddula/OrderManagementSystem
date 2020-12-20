using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Models
{
    public class OrderByAdmin
    {
        public string Name { get; set; }
        public string RoleType { get; set; }
        public int OrderId { get; set; }
        public string StatusDesc { get; set; }
        public string ShippingAddress { get; set; }



    }
}