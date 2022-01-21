using BellaPizza.AppCode.Helpers;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.AppCode.ViewComponents
{
    [ViewComponent]
    public class CartCount : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Order> carts = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");

            int cartCount = 0;
            if (carts != null)
            {
                cartCount = carts.Sum(x => x.Quantity);
            }

            return View(cartCount);
        }
    }
}
