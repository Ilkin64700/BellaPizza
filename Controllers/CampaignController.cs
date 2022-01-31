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
    public class CampaignController : Controller
    {
        private readonly BellaContext _bellacontext;
        public CampaignController(BellaContext bellacontext)
        {
            _bellacontext = bellacontext;
        }

        public async Task<ActionResult> Detail(int? Id)
        {
            if (Id == null)
                return NotFound();

            Campaign campaign = new Campaign();
            campaign = await _bellacontext.Campaigns.FirstOrDefaultAsync(x => x.Id == Id);
            if (campaign == null)
                return NotFound();
            return View(campaign);
        }
    }
}
