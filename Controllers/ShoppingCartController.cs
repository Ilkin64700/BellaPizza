using BellaPizza.Models.Context;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using BellaPizza.AppCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellaPizza.Models.ViewModels;

namespace BellaPizza.Controllers
{
    public class ShoppingCartController : Controller
    {
        public readonly BellaContext bellaContext;
        public ShoppingCartController(BellaContext bellaContext)
        {
            this.bellaContext = bellaContext;
        }

        public IActionResult Index()
        {
            List<Order> cart = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");
            if (cart != null)
                ViewBag.total = cart.Sum(item => item.MenuItem.Price * item.Quantity);

            ShoppingVM shoppingVM = new ShoppingVM(cart);

            //TempData.Keep("Success");
            //TempData.Keep("Error");

            return View(shoppingVM);
        }


        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart") == null)
            {
                List<Order> cart = new List<Order>();
                cart.Add(new Order { MenuItem = bellaContext.MenuItems.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Order> cart = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (isExist(id) != -1)
                    cart[index].Quantity++;
                else
                    cart.Add(new Order { MenuItem = bellaContext.MenuItems.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return NoContent();
        }

        public IActionResult Remove(int id)
        {
            List<Order> cart = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Order> cart = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].MenuItem.Id.Equals(id))
                    return i;
            return -1;
        }

        //public IActionResult ConfirmCart(ShoppingVM shoppingVM)
        //{
        //    List<Order> cart = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");
        //    shoppingVM.Orders = cart;

        //    bellaContext.Orders.Where(x=)

        //    if (shoppingVM.Customer != null)
        //    {
        //        customerRepo.Add(shoppingVM.Customer);
        //        customerRepo.SaveChanges();

        //        if (shoppingVM.Orders != null)
        //        {
        //            for (int i = 0; i < shoppingVM.Orders.Count; i++)
        //            {
        //                shoppingVM.Orders[i].CustomerId = shoppingVM.Customer.Id;
        //                shoppingVM.Orders[i].MenuItemId = shoppingVM.Orders[i].MenuItem.Id;
        //                shoppingVM.Orders[i].MenuItem = null;
        //            }
        //            orderRepo.AddRange(shoppingVM.Orders);
        //            int rowAffected = orderRepo.SaveChanges();
        //            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", null);

        //            if (rowAffected > 0)
        //                TempData["Success"] = "Sifariş Qeydə alındı";
        //            else
        //                TempData["Error"] = "Sifariş Qeydə alınmadı";
        //        }
        //        else
        //            TempData["Error"] = "Sifariş üçün heç bir məhsul seçilməyib";
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}
