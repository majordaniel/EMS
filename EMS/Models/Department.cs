using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input Department code!")]
        [Display(Name = "Department Code")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Department code must be 2 to 5 character long!")]
        [Index(IsUnique = true)]
        [Remote("IsDepartmentCodeEixsts","Department",HttpMethod = "POST", ErrorMessage = "Department code already exists!")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Please input Department name!")]
        [Display(Name = "Department Name")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsDepartmentNameExists","Department", HttpMethod = "POST", ErrorMessage = "Department name already exists!")]
        public string DepartmentName { get; set; }

    }
}