using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class EmployeEducation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select employee reg. no.!")]
        [Display(Name = "Employee Reg.No.")]
        public int EmployeeId { get; set; }


        [Required(ErrorMessage = "Please select education!")]
        [Display(Name = "Level of Education")]
        public int EducationId { get; set; }

        [Required(ErrorMessage = "Please select exam!")]
        [Display(Name = "Exam / Degree Title:")]
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Please input group name!")]
        [Display(Name = "Major / Group")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please input institute name!")]
        [Display(Name = "Institute Name")]
        public string InstituteName { get; set; }

        [Required(ErrorMessage = "Please set from date!")]
        [Display(Name = "From")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Please set to date!")]
        [Display(Name = "To")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }


        [Required(ErrorMessage = "Please input duration")]
        [Display(Name = "Duration (Years)")]
        [StringLength(25)]
        public string Duration { get; set; }


        [Required(ErrorMessage = "Please set passing year")]
        [Display(Name = "Year of Passing ")]
        public int PassingYear { get; set; }



        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("EducationId")]
        public virtual Education Education { get; set; }

        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }
    }
}