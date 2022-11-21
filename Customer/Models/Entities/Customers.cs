using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Models.Entities
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerPhone { get; set; }
    }
}
