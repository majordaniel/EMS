using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class EmployeeLanguage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please slect employee reg. no.!")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please select language!")]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Please input your reading skill!")]
        [StringLength(50)]
        public string Reading { get; set; }

        [Required(ErrorMessage = "Please input your Speking skill!")]
        [StringLength(50)]
        public string Speaking { get; set; }

        [Required(ErrorMessage = "Please input your writing skill!")]
        [StringLength(50)]
        public string Writing { get; set; }

        [Required(ErrorMessage = "Please input your understanding skill!")]
        [StringLength(50)]
        public string Understanding { get; set; }


        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }


    }
}