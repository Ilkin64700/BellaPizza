using BellaPizza.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.ViewModels
{
    public class CampaignVM
    {
        public List <Campaign> Campaigns { get; set; }
        public List<MenuItemGroup> MenuItemGroups { get; set; }
        public Birthday Birthday { get; set; }
        public MasterClass MasterClass { get; set; }
        public ChildrenParty ChildrenParty { get; set; }

    }
}
