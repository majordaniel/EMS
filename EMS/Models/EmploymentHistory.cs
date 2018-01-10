using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class EmploymentHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select Employee Reg.No.!")]
        [Display(Name = "Employee Reg.No.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please input company name!")]
        [Display(Name = "Company Name")]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please input company location!")]
        [Display(Name = "Company Location")]
        [StringLength(100)]
        public string CompanyLocation { get; set; }

        [Required(ErrorMessage = "Please select department!")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select position!")]
        [Display(Name = "Position")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Please set from date!")]
        [Display(Name = "Employment From")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EmploymentFromDate { get; set; }

        [Display(Name = "Is Current Employee?")]
        public IsAct IsCurrentEmployee { get; set; }

        [Required(ErrorMessage = "Please set to date!")]
        [Display(Name = "EMployment To")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime EmploymentToDate { get; set; }

        [Required(ErrorMessage = "Please input responsibilities")]
        [StringLength(150)]
        public string Responsibilities { get; set; }





        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

    }
    public enum IsAct
    {
        [Display(Name = "Yes")]
        True,
        [Display(Name = "No")]
        False
    }
}