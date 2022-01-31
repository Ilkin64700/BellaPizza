using BellaPizza.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.ViewModels
{
    public class BlogVM
    {
        public List<Blog> Blogs { get; set; }
        public LoyalProgram LoyalProgram { get; set; }
        public WhatsappOrder WhatsappOrder { get; set; }
        public NewPizza NewPizza { get; set; }
    }
}
