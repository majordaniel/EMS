using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class EmployeeCertification
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select employee regNo.!")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please select Certification!")]
        [Display(Name = "Certification")]
        public int CertificationId { get; set; }

        [Required(ErrorMessage = "Please input institute name!")]
        [Display(Name = "Institute")]
        public string InstituteName { get; set; }


        [Required(ErrorMessage = "Please set from date!")]
        [Display(Name = "From")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Please set to date!")]
        [Display(Name = "To")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ToDate { get; set; }


        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("CertificationId")]
        public virtual Certification Certification { get; set; }
    }
}