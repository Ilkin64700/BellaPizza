using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Models.Entity
{
    public class MenuItemGroup:BaseEntity
    {

        [Required]
        [DisplayName("Qrup Adi")]
        [StringLength(250, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string MenuItemGroupName { get; set; } // pizza

        public virtual List<MenuItem> MenuItems { get; set; }
    }
}
