using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class EmployeeTrainingHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select employee Reg.No.!")]
        [Display(Name = "Employee Reg.No.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please input training title!")]
        [Display(Name = "Title")]
        [StringLength(100)]
        public string TrainingTitle { get; set; }

        [Required(ErrorMessage = "Please input training Topic!")]
        [Display(Name = "Topic")]
        [StringLength(100)]
        public string TrainingTopic { get; set; }

        [Required(ErrorMessage = "Please input institute name")]
        [Display(Name = "Institute")]
        [StringLength(100)]
        public string TrainingInstitute { get; set; }

        [Required(ErrorMessage = "Please input institute location!")]
        [Display(Name = "Location")]
        [StringLength(25)]
        public string IstituteLocation { get; set; }

        [Required(ErrorMessage = "Please input country name")]
        [Display(Name = "Country")]
        [StringLength(25)]
        public string InstituteCountry { get; set; }

        [Required(ErrorMessage = "Please select training year!")]
        [Display(Name = "Year")]
        public int TrainingYear { get; set; }

        [Required(ErrorMessage = "Please input training duration!")]
        [Display(Name = "Duration")]
        [StringLength(25)]
        public string TrainingDuration { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}