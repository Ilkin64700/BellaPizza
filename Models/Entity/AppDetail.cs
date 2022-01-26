using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellaPizza.Models.Entity
{
    public class AppDetail : BaseEntity
    {

        [DisplayName("Web Basliq")]
        [StringLength(50, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")] // Web Basliq deyeri 250 simvoldan artiq ola bilmez
        public string WebTitle { get; set; }


        [DisplayName("Unvan")]
        [StringLength(250, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string Address { get; set; }

        [DisplayName("Elaqe Nomresi")]
        [Phone]
        public string PhoneNumber { get; set; }

        [DisplayName(" 2-ci Elaqe Nomresi")]
        [Phone]
        public string HomeNumber { get; set; }

        [DisplayName("Poct Unvani")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("Aciqlama")]
        [StringLength(500, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string Description { get; set; }

        [DisplayName("Is Saati")]
        [StringLength(100, ErrorMessage = "{0} deyeri {1} simvoldan artiq ola bilmez")]
        public string WorkingHours { get; set; }

        [DisplayName("Facebook Ünvanı")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan artıq ola bilməz ")]
        public string Facebook { get; set; }

        [DisplayName("Twitter Ünvanı")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan artıq ola bilməz ")]
        public string Twitter { get; set; }

        [DisplayName("Instagram Ünvanı")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan artıq ola bilməz ")]
        public string Instagram { get; set; }

        [DisplayName("Müəssisə Haqqında Məlumat")]
        [StringLength(190, ErrorMessage = "{0} {1} simvoldan artıq ola bilməz ")]
        public string About { get; set; }
    }
}
