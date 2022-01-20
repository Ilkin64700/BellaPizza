using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Models.Entity
{
    public class MenuItem : BaseEntity
    {


        [Required]
        [DisplayName("Menyu Adi")]
        [StringLength(250, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string MenuItemName { get; set; }

        [DisplayName("Menyunun Terkibi")]
        [StringLength(250, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string MenuItemDescription { get; set; }

        [DisplayName("Qiymeti")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 150.00, ErrorMessage = "{0} {1} ile {2} arasinda olmalidir")] //Qiymeti 0.01 ile 100.00 arasinda olmalidir
        public decimal Price { get; set; }

        [DisplayName("Sekli")]
        [StringLength(550, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string ImagePath { get; set; }

        public bool IsNew { get; set; }

        public int MenuItemGroupId { get; set; }


        public virtual MenuItemGroup MenuItemGroup { get; set; }
        public virtual List<Order> Orders { get; set; }


    }
}
