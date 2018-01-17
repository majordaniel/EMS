using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class Attendance
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Employee!")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please set your in time")]
        [Display(Name = "In Time")]
        public DateTime InTime { get; set; }

        [Required(ErrorMessage = "Please your Out time!")]
        [Display(Name = "Out Time")]
        public DateTime OutTime { get; set; }

        [Required(ErrorMessage = "Please input note")]
        [StringLength(150)]
        public string Note { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
       
    }
    
}