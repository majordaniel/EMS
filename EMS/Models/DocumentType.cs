using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class DocumentType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input document type!")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsDocumentTypeNameExists","DocumentType",HttpMethod = "POST",ErrorMessage = "DocumentType type already Exists!")]
        public string TypeName { get; set; }

        [Required(ErrorMessage = "Please input description!")]
        [StringLength(150)]
        public string Description { get; set; }

    }
}