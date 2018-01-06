using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Exam
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input exam name!")]
        [Display(Name = "Exam name")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        [Remote("IsExamNameExists", "Exam", HttpMethod = "POST", ErrorMessage = "Exam name already exists!")]
        public string ExamName { get; set; }

        [Required(ErrorMessage = "Please select education!")]
        [Display(Name = "Education")]
        public int EducationId { get; set; }

        [ForeignKey("EducationId")]
        public virtual Education Education { get; set; }
    }
}