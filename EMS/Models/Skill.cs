using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Skill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input skill!")]
        [Display(Name = "Name")]
        [StringLength(150)]
        [Index(IsUnique = true)]
        [Remote("IsSkillNameExists","Skill",HttpMethod = "POST", ErrorMessage = "Skill name already Exists!")]
        public string SkillName { get; set; }
        public string Description { get; set; }

    }
}