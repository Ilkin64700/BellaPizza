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
    public class BlogDetailController : Controller
    {
        private readonly BellaContext _bellaContext;

        public BlogDetailController(BellaContext bellaContext)
        {
            _bellaContext = bellaContext;
        }
        public async Task<IActionResult> Campaign()
        {
            BlogVM blogVM = new BlogVM
            {
                LoyalProgram = await _bellaContext.LoyalPrograms.FirstOrDefaultAsync(),
                WhatsappOrder = await _bellaContext.WhatsappOrders.FirstOrDefaultAsync(),
                NewPizza = await _bellaContext.NewPizzas.FirstOrDefaultAsync()

            };


            return View(blogVM);
        }
    }
}
