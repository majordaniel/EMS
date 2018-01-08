using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Language
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input language code!")]
        [Display(Name = "Code")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "Language code must be 2 to 3 character long!")]
        [Index(IsUnique = true)]
        [Remote("IsLanguageCodeExists", "Language", HttpMethod = "POST", ErrorMessage = "Laguage code already exists")]
        public string LanguageCode { get; set; }


        [Required(ErrorMessage = "Please input language name!")]
        [Display(Name = "Name")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Language code must be 3 to 10 character long!")]
        [Index(IsUnique = true)]
        [Remote("IsLanguageNameExists", "Language", HttpMethod = "POST", ErrorMessage = "Laguage name already exists")]
        public string LanguageName  { get; set; }
    }
}