using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Models.Entity
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [StringLength(255)]
        public string ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Zəhmət olmasa şəkil seçin")]
        [DataType(DataType.Upload)]
        public IFormFile Photo { get; set; }
    }
}
