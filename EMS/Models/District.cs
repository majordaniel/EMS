using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class District
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select division!")]
        [Display(Name = "Division")]
        public int DivisionId { get; set; }

        [Required(ErrorMessage = "Please input district code!")]
        [Display(Name = "District code")]
        [Index(IsUnique = true)]
        [StringLength(5)]
        [Remote("IsDistrictCodeExists","District",HttpMethod = "POST", ErrorMessage = "District code already exists!")]
        public string DistrictCode { get; set; }

        [Required(ErrorMessage = "Please input district name!")]
        [Display(Name = "District name")]
        [Index(IsUnique = true)]
        [StringLength(50)]
        [Remote("IsDistrictNameExists", "District", HttpMethod = "POST", ErrorMessage = "District name already exists!")]
        public string DistrictName { get; set; }

        [ForeignKey("DivisionId")]
        public virtual Division Division { get; set; }
        public virtual List<PoliceStation> PoliceStations { get; set; } 

    }
}