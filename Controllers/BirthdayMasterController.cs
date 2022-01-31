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
    public class BirthdayMasterController : Controller
    {
        private readonly BellaContext _bellaContext;
        public BirthdayMasterController(BellaContext bellaContext)
        {
            _bellaContext = bellaContext;
        }
        public async Task<IActionResult> BirthdayMaster()
        {
            CampaignVM campaignVM = new CampaignVM
            {
                Birthday = await _bellaContext.Birthdays.FirstOrDefaultAsync(),
                MasterClass = await _bellaContext.MasterClasses.FirstOrDefaultAsync(),
                ChildrenParty = await _bellaContext.ChildrenParties.FirstOrDefaultAsync(),
                Campaigns = await _bellaContext.Campaigns.ToListAsync()
            };

            return View(campaignVM);
        }
            
        
    }
}
