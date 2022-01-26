using BellaPizza.Models.Context;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Controllers
{
    [Area("Manage")]
    public class SiteLayoutController : Controller
    {
        public readonly BellaContext bellaContext;

        public SiteLayoutController(BellaContext bellaContext)
        {
            this.bellaContext = bellaContext;
        }

        [HttpGet]
        public IActionResult PageLayout()
        {
            AppDetail appdetail = bellaContext.AppDetails.FirstOrDefault();
            return View(appdetail);
        }

        [HttpPost]
        public IActionResult PageLayout(AppDetail appDetail)
        {
            bellaContext.AppDetails.Update(appDetail);
            bellaContext.SaveChanges();
            return View();
        }
    }
}
