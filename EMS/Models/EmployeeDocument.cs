using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace EMS.Models
{
    public class EmployeeDocument
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select Employee reg.No.!")]
        [Display(Name = "Employee Reg.No.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please select documents type!")]
        [Display(Name = "Document type")]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "Please input document title name!")]
        [Display(Name = "Title")]
        [StringLength(100)]
        public string DocumentTitle { get; set; }

        [Required(ErrorMessage = "Please set attachment date!")]
        [Display(Name = "Attachment date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DocumentAddedDate { get; set; }

        [Required(ErrorMessage = "Please set expire date!")]
        [Display(Name = "Expire date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpiredDate { get; set; }

        [StringLength(150)]
        public string Details { get; set; }

        
        [Display(Name = "Upload file")]
        public string FilePath { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentType { get; set; }

    }
}