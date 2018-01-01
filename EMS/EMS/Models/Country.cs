using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Country
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Country code"), Required]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "Country Code 3 to 5 Character long!")]
        [Index(IsUnique = true)]
        [Remote("IsCountryCodeExists","Country", HttpMethod = "POST",ErrorMessage = "Country code already already exists!")]
        public string CountryCode { get; set; }

        [Display(Name = "Country name"), Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsCountryNameExists","Country",HttpMethod = "POST", ErrorMessage = "Country name already exists!")]
        public string CountryName { get; set; }
    }
}