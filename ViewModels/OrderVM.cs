using BellaPizza.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace BellaPizza.Models.ViewModels
{
    public class OrderVM
    {
        public List<Order> Orders { get; set; }
        public List<Customer> Customers { get; set; }

        public OrderVM()
        {
        }

        public OrderVM(List<Order> orders)
        {
            this.Orders = orders;
        }

        public OrderVM(List<Order> orders, List<Customer> customers)
            : this(orders)
        {
            this.Customers = customers;
        }
    }
}
