using BellaPizza.Models.Context;
using BellaPizza.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellaPizza.Models.Entity;


namespace BellaPizza.Controllers
{
    public class FindUsController : Controller
    {
        public readonly BellaContext _bellaContext;
        public FindUsController(BellaContext bellaContext)
        {
            _bellaContext = bellaContext;
        }


        public async Task<IActionResult> FindUs()
        {
            RelateusVM relateusVM = new RelateusVM()
            {
                Reservation= await _bellaContext.Reservations.FirstOrDefaultAsync(),
                MealSliders = await _bellaContext.MealSliders.ToListAsync(),
                AboutPagePoints = await _bellaContext.AboutPagePoints.ToListAsync(),
                AppDetail = await _bellaContext.AppDetails.FirstOrDefaultAsync(),
                ContactUs = await _bellaContext.ContactUs.FirstOrDefaultAsync()


            };

            return View(relateusVM);

        }
    }
}
