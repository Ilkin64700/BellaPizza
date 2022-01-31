using BellaPizza.Models.Context;
using BellaPizza.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Controllers
{
    public class MenuProductController : Controller
    {
        private readonly BellaContext _bellaContext;
        public MenuProductController(BellaContext bellaContext)
        {
            _bellaContext = bellaContext;
        }
        public async Task<IActionResult> MenuProduct()
        {
            CampaignVM campaignVM = new CampaignVM
            {            
                MenuItemGroups = await _bellaContext.MenuItemGroups.Include(x => x.MenuItems).ToListAsync()              
            };

            return View(campaignVM);
        }
    }
}
