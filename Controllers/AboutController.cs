using BellaPizza.Models.Context;
using BellaPizza.Models.Entity;
using BellaPizza.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Controllers
{
    public class AboutController : Controller
    {
        public readonly BellaContext _bellaContext;
        public AboutController(BellaContext bellaContext)
        {
            _bellaContext = bellaContext;
        }


        public async Task <IActionResult> About()
        {
            WelcomeVM welcomeVM = new WelcomeVM()
            {
                Reservation = await _bellaContext.Reservations.FirstOrDefaultAsync(),
                MealSliders = await _bellaContext.MealSliders.ToListAsync(),
                AboutPagePoints = await _bellaContext.AboutPagePoints.ToListAsync(),
                AppDetail = await _bellaContext.AppDetails.FirstOrDefaultAsync()


            };

            return View(welcomeVM);
        }
    }
}
