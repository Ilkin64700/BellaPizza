using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Models.Entity
{
    public class Order : BaseEntity
    {
        [DisplayName("Sayi")]
        [Range(1, 20, ErrorMessage = "{0} {1} ile {2} arasinda olmalidir")]
        public int Quantity { get; set; }

        public bool IsSended { get; set; }

        public int MenuItemId { get; set; }
        public int CustomerId { get; set; }


        public virtual MenuItem MenuItem { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
