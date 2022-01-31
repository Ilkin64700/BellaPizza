using BellaPizza.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.ViewModels
{
    public class WelcomeVM
    {
        public Reservation Reservation { get; set; }
        public List<MealSlider> MealSliders { get; set; }
        public List<AboutPagePoints> AboutPagePoints { get; set; }
        public AppDetail AppDetail { get; set; }
    }
}
