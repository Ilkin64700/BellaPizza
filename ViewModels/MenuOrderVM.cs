using BellaPizza.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.ViewModels
{
    public class MenuOrderVM
    {

        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }

        public MenuOrderVM()
        {
        }

        public MenuOrderVM(Order Order)
        {
            this.Order = Order;
        }

        public MenuOrderVM(Order Order, MenuItem MenuItem)
            : this(Order)
        {
            this.MenuItem = MenuItem;
        }
    }
}
