using BellaPizza.Models.Context;
using BellaPizza.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Controllers
{
    public class AboutController : Controller
    {
        public readonly BellaContext BellaContext;
        public AboutController(BellaContext bellaContext)
        {
            this.BellaContext = bellaContext;
        }


        public IActionResult About()
        {
            AppDetail appDetail = BellaContext.AppDetails.FirstOrDefault();
            return View(appDetail);
        }
    }
}
