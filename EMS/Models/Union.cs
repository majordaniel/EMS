using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Union
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select police station!")]
        [Display(Name = "Police Station")]
        public int PoliceStationId { get; set; }

        [Required(ErrorMessage = "Please input union code!")]
        [Display(Name = "Union code")]
        [StringLength(5)]
        [Index(IsUnique = true)]
        [Remote("IsUnionCodeExists","Union",HttpMethod = "POST", ErrorMessage = "Union code already exists!")]
        public string UnionCode { get; set; }

        [Required(ErrorMessage = "Please input union code!")]
        [Display(Name = "Union name")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsUnionNameExists", "Union", HttpMethod = "POST", ErrorMessage = "Union name already exists!")]
        public string UnionName { get; set; }

        [ForeignKey("PoliceStationId")]
        public virtual PoliceStation PoliceStation { get; set; }
    }
}