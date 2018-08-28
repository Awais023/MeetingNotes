using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectsNotes.Models
{
    [Table("UserGroup")]
    public class UserGroup
    {
        [Key]
        // PRIMARY KEY ATTRIBUTE

        [Display(Name = "Project ID")]
        public int  ID { get; set; }

        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "Group Name Is Required.")]//ERROR MESSAGE IF LEFT EMPTY
        public string Name { get; set; }

        [Display(Name = "Group Admin Email")]
        [Required(ErrorMessage = "Email Is Required.")]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$", ErrorMessage = "Please Enter Valid Email")]//REGULAR EXPRESSION FOR EMAIL FORMAT VALIDATION
        public string Email { get; set; }


    }
}