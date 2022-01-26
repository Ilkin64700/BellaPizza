using BellaPizza.Models.Context;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BellaPizza.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BellaPizza.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class OrderController : Controller
    {
        public readonly BellaContext bellaContext;
        public OrderController(BellaContext bellaContext)
        {
            this.bellaContext = bellaContext;
        }

        public IActionResult Order()
        {
            List<Customer> customers = bellaContext.Customers
                                            .Include(c => c.Orders)
                                                .ThenInclude(o => o.MenuItem)
                                            .ToList();

            return View(customers);
        }

        public IActionResult Sended(int id)
        {
            List<Order> orders = bellaContext.Orders.Where(x => x.CustomerId == id).ToList();

            foreach (Order order in orders)
            {
                order.IsSended = true;
                bellaContext.Update(order);
            }

            //orders.ForEach(o => ////bunu da yazmaq olar 
            //{
            //    o.IsSended = true;
            //    bellaContext.Update(o);
            //});

            bellaContext.SaveChanges();

            return RedirectToAction("Order");
        }

    }
}
