using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Designation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input designation code!")]
        [Display(Name = "Designation Code")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Designation code must 2 to 5 chararcter long!")]
        [Index(IsUnique = true)]
        [Remote("IsDesignationCodeExists","Designation", HttpMethod = "POST",ErrorMessage = "Designation code already exists!")]
        public string DesignationCode { get; set; }

        [Required(ErrorMessage = "Please input designation name!")]
        [Display(Name = "Designation Name")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsDesignationNameExists", "Designation", HttpMethod = "POST", ErrorMessage = "Designation name already exists!")]
        public string DesignationName { get; set; }

    }
}