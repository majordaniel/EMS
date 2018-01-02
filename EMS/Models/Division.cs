using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Division
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Country!")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }


        [Required(ErrorMessage = "Please input Division Code!")]
        [Display(Name = "Division code")]
        [StringLength(5)]
        [Index(IsUnique = true)]
        [Remote("IsDivisionCodeExists","Division", HttpMethod = "POST", ErrorMessage = "Division code already exists!, please try another")]
        public string DivisionCode { get; set; }

        [Required(ErrorMessage = "Please input Division name!")]
        [Display(Name = "Division name")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsDivisionNameExists","Division", HttpMethod = "POST", ErrorMessage = "Division name already exists!, please try again!")]
        public string DivisionName { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual List<District> Districts { get; set; }
    }
}