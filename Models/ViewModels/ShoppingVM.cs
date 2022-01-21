using BellaPizza.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Models.ViewModels
{
    public class ShoppingVM
    {
        public List<Order> Orders { get; set; }
        public Customer Customer { get; set; }
        public ShoppingVM()
        {
        }

        public ShoppingVM(List<Order> orders)
        {
            this.Orders = orders;
        }

        public ShoppingVM(List<Order> orders, Customer customer)
            : this(orders)
        {
            this.Customer = customer;
        }
    }
}
