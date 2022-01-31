using BellaPizza.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.ViewModels
{
    public class CampaignVM
    {

        public List<HomeSlider> HomeSliders { get; set; }
        public List<MenuItemGroup> MenuItemGroups { get; set; }
        public List <Campaign> Campaigns { get; set; }
        public Birthday Birthday { get; set; }
        public MasterClass MasterClass { get; set; }
        public ChildrenParty ChildrenParty { get; set; }
        public AppDetail AppDetail { get; set; }
        public ContactUs ContactUs { get; set; }

    }
}
