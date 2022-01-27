using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Models
{
    public class AppUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        [ProtectedPersonalData]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }

    }
}
