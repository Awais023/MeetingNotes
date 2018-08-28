using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectsNotes.Models
{
    [Table("UserAccount")]
    public class UserAccount
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "First name Is Required.")]//ERROR MESSAGE IF LEFT EMPTY
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name Is Required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Email Is Required.")]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$", ErrorMessage = "Please Enter Valid Email")]//REGULAR EXPRESSION FOR EMAIL FORMAT VALIDATION
        public String Email { get; set; }


        [Required(ErrorMessage = "User name Is Required.")]
        [Display(Name = "User Name")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        [MaxLength(30)]
        public String Password { get; set; }

        [Required(ErrorMessage = "Confirm Your Password .")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [MaxLength(30)]
        public String ConfirmPassword { get; set; }
    }
}