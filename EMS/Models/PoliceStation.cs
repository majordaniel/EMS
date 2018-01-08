using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class PoliceStation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select District!")]
        [Display(Name = "Disctrict")]
        public int DistrictId { get; set; }

        [Required(ErrorMessage = "Please input police station code!")]
        [Display(Name = "Police station code")]
        [StringLength(5)]
        [Index(IsUnique = true)]
        [Remote("IsPoliceStationCodeExists","PoliceStation", HttpMethod = "POST", ErrorMessage = "Police Station Code Already Exists!")]
        public string PoliceStationCode { get; set; }

        [Required(ErrorMessage = "Please input police station code!")]
        [Display(Name = "Police station name")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsPoliceStationNameExists", "PoliceStation", HttpMethod = "POST", ErrorMessage = "Police Station Name Already Exists!")]
        public string PoliceStationName { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
        public virtual List<Union> Unions { get; set; } 

    }
}