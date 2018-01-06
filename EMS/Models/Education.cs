using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Education
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }

        [Required(ErrorMessage = "Please input education name!")]
        [Display(Name = "Education name")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        [Remote("IsEducationNameExists","Education",HttpMethod = "POST",ErrorMessage = "Education name already exists!")]
        public string EducationName { get; set; }
        public string Description { get; set; }
    }
}