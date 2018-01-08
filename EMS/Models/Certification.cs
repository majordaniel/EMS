using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Certification
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input certificate name!")]
        [Display(Name = "Name")]
        [StringLength(150)]
        [Index(IsUnique = true)]
        [Remote("IsCertificationNameExists", "Certification", HttpMethod = "POST", ErrorMessage = "Certificate name already exists!")]
        public string CertificationName { get; set; }
        public string Description { get; set; }
    }
}