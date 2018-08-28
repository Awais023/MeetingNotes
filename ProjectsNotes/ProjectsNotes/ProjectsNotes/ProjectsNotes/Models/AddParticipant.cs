using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectsNotes.Models
{
    [Table("AddParticipant")]
    public class AddParticipant
    {
        [Key]
        // PRIMARY KEY ATTRIBUTE
        [Display(Name = "Addition ID")]
        public int AdditionNo { get; set; }

        [Required(ErrorMessage ="Group ID is required")]//ERROR MESSAGE IF LEFT EMPTY
        [Display(Name = "Group ID")]
        public int GroupID { get; set; }

        [Required(ErrorMessage = "Admin email is required")]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$", ErrorMessage = "Please Enter Valid Email")]//REGULAR EXPRESSION FOR EMAIL FORMAT VALIDATION
        [Display(Name = "ParticipantEmail")]
        public string Email { get; set; }

    }
}