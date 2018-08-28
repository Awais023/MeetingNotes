using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectsNotes.Models
{
    [Table("Note")]
    public class Note// CLASS ACCORDING TO TABLE IN DATABASE
    {
        [Key]// PRIMARY KEY ATTRIBUTE

        // COLUMNS ACCORDIN GTO DATABASE
        public int ID { get; set; }

        [Required(ErrorMessage = "Project ID is required")]//ERROR MESSAGE IF LEFT EMPTY
        [Display(Name = "Project ID")]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Agenda of Note is required")]
        [Display(Name = "Agenda")]
        public string Agenda { get; set; }


        [Required(ErrorMessage = "Time of Note is required")]
        [Display(Name = "Time Of Note")]
        public DateTime DateOfNote { get; set; }

        [Required(ErrorMessage = "Attendee of Note is required")]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$",ErrorMessage ="Please Enter Valid Email")]//REGULAR EXPRESSION FOR EMAIL FORMAT VALIDATION
        [Display(Name = "Attendee Name")]
        public string Attendee { get; set; }

        [Required(ErrorMessage = "Detail of Note is required")]
        [Display(Name = "Detail Of Note")]
        public string DescriptionOfNote { get; set; }


        [Required(ErrorMessage = "Status of Note is required")]
        [Display(Name = "Current Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


    }
}