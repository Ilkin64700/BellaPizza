using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Models.Entity
{
    public class Customer: BaseEntity
    {
        [Required]
        [DisplayName("Musteri Adi")]
        [StringLength(500, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string Name { get; set; }

        [DisplayName("Unvan")]
        [StringLength(250, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string Address { get; set; }

        [Phone]
        [Required]
        [DisplayName("Elaqe Nomresi")]
        public string PhoneNumber { get; set; }

        [DisplayName("Aciqlama")]
        [StringLength(500, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string Description { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
