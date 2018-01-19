using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input role name!")]
        [Display(Name = "Role name")]
        [StringLength(25)]
        [Index(IsUnique = true)]
        [Remote("IsRoleNameExists", "Role", HttpMethod = "POST", ErrorMessage = "Role name Already exists!")]
        public string RoleName { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

    }
}