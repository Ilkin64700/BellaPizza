using BellaPizza.Models;
using BellaPizza.Models.Context;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Controllers
{
    public class HomeController : Controller
    {
        public readonly BellaContext bellaContext;
        public HomeController(BellaContext bellaContext)
        {
            this.bellaContext = bellaContext;
        }

        public IActionResult Index()
        {
            List<MenuItemGroup> menuItemGroups = bellaContext.MenuItemGroups.Include(x => x.MenuItems).ToList();

            return View(menuItemGroups);
        }

        public async Task<IActionResult> GetDetail(int? id)
        {
            MenuItem menuItem = await bellaContext.MenuItems.FindAsync(id);
            //MenuItem menuItem2 = await bellaContext.MenuItems.Where(x => x.Id == id).FirstOrDefaultAsync();
            //MenuItem menuItem3 = await bellaContext.MenuItems.FirstOrDefaultAsync(x => x.Id == id);

            return View(menuItem);
        }

    }
}


// Cannot implicitly convert type 'List<MenuItemGroup>' to 'MenuItemGroup'	