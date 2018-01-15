using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class EmployeeSkill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select employee reg. no.!")]
        [Display(Name = "Employee Reg.No.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please select skill")]
        [Display(Name = "Skill")]
        public int SkillId { get; set; }

        [Required(ErrorMessage = "Please input details!")]
        [StringLength(150)]
        public string Details { get; set; }


        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }


    }
}