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
    public class BlogController : Controller
    {
        private readonly BellaContext _bellacontext;
        public BlogController(BellaContext bellacontext)
        {
            _bellacontext = bellacontext;
        }

        public async Task<IActionResult> Blog()
        {
            BlogVM blogVM = new BlogVM()
            {
                Blogs = await _bellacontext.Blogs.ToListAsync()
            };


            return View(blogVM);
        }

        public async Task<ActionResult> Detail(int? Id)
        {
            if (Id == null)
                return NotFound();

            Blog blog = new Blog();
            blog = await _bellacontext.Blogs.FirstOrDefaultAsync(x => x.Id == Id);
            if (blog == null)
                return NotFound();
            return View(blog);
        }
    }
}
