using BellaPizza.Models.Context;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MenuController : Controller
    {

        public readonly BellaContext bellaContext;

        public MenuController(BellaContext bellaContext)
        {
            this.bellaContext = bellaContext;
        }


        public IActionResult Menu()
        {
            List<MenuItem> menuItems = bellaContext.MenuItems.Include(x => x.MenuItemGroup).ToList();

            return View(menuItems);
        }


        public IActionResult AddOrEdit(int id = 0)
        {
            ViewBag.MenuItemGroup = new SelectList(bellaContext.MenuItemGroups.ToList(), "Id", "MenuItemGroupName");

            if (id == 0)
            {
                return View(new MenuItem());
            }
            else
            {
                MenuItem menuItem = bellaContext.MenuItems.Find(id);
                if (menuItem == null)
                {
                    return NotFound();
                }
                return View(menuItem);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddOrEdit(int id, MenuItem menuItem, IFormFile ImagePath)
        {
            ViewBag.MenuItemGroup = new SelectList(bellaContext.MenuItemGroups.ToList(), "Id", "MenuItemGroupName");

            if (ModelState.IsValid)
            {

                if (ImagePath != null)
                {
                    string randomFileName = Path.Combine("wwwroot", "images", $"{Guid.NewGuid().ToString()}{Path.GetExtension(ImagePath.FileName)}");
                    using (var stream = new FileStream(randomFileName, FileMode.Create))
                        ImagePath.CopyTo(stream);
                    menuItem.ImagePath = Path.GetFileName(randomFileName);
                }


                if (id == 0)
                {
                    bellaContext.MenuItems.Add(menuItem);
                    bellaContext.SaveChanges();
                }
                else
                {
                    try
                    {
                        if (ImagePath != null)
                            bellaContext.MenuItems.Find(id).ImagePath = menuItem.ImagePath;
                        bellaContext.MenuItems.Find(id).MenuItemDescription = menuItem.MenuItemDescription;
                        bellaContext.MenuItems.Find(id).MenuItemGroupId = menuItem.MenuItemGroupId;
                        bellaContext.MenuItems.Find(id).MenuItemName = menuItem.MenuItemName;
                        bellaContext.MenuItems.Find(id).Price = menuItem.Price;
                        bellaContext.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                    }
                }

                MenuItem AddedRow = bellaContext.MenuItems.Where(x => x.Id == menuItem.Id).Include(x => x.MenuItemGroup).FirstOrDefault();

                //string jsonResult = JsonConvert.SerializeObject(melumat, Formatting.Indented, options);


                return Json(new { isValid = true, menuItem = AddedRow }, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            return Json(new { isValid = false });
        }


        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int[] selectRowsArr)
        {
            foreach (int item in selectRowsArr)
            {
                MenuItem MenuRow = bellaContext.MenuItems.Find(item);
                bellaContext.MenuItems.Remove(MenuRow);
                var pathImage = Path.Combine("wwwroot", "images", MenuRow.ImagePath);
                if (System.IO.File.Exists(pathImage))
                    System.IO.File.Delete(pathImage);
            }
            int affectedRow = bellaContext.SaveChanges();

            if (affectedRow != 0)
                return Json(new { isValid = true });
            else
                return Json(new { isValid = false });
        }

        public IActionResult MenuItemGroupList()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MenuItemGroupList(MenuItemGroup menuItemGroup)
        {
            bellaContext.MenuItemGroups.Add(menuItemGroup);
            bellaContext.SaveChanges();
            return RedirectToAction("Menu");
        }
    }
}
