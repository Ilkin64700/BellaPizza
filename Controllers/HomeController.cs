using BellaPizza.Models;
using BellaPizza.Models.Context;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BellaPizza.AppCode.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BellaPizza.ViewModels;

namespace BellaPizza.Controllers
{
    public class HomeController : Controller
    {
        private readonly BellaContext _bellaContext;

        public HomeController(BellaContext bellaContext)
        {
            _bellaContext = bellaContext;
        }

        public async Task<IActionResult> Index()
        {
            CampaignVM campaignVM = new CampaignVM
            {
                Campaigns = await _bellaContext.Campaigns.ToListAsync(),
                MenuItemGroups = await _bellaContext.MenuItemGroups.Include(x => x.MenuItems).ToListAsync()
            };

            return View(campaignVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetDetail(int? id)
        {
            MenuItem menuItem = await _bellaContext.MenuItems.FindAsync(id);
            Order order = new Order() { Quantity = 1 };
            MenuOrderVM menuOrderVM = new MenuOrderVM(order, menuItem);

            return View(menuOrderVM);
        }
    }
}


// Cannot implicitly convert type 'List<MenuItemGroup>' to 'MenuItemGroup'	