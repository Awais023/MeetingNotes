using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectsNotes.Models
{
    [Table("Project")]
    public class Project// CLASS ACCORDING TO TABLE IN DATABASE
    {
        [Key]
        public int ID { get; set; }// PRIMARY KEY ATTRIBUTE

        // COLUMNS ACCORDIN GTO DATABASE
        [Required(ErrorMessage = "Project Name is required")]//ERROR MESSAGE IF LEFT EMPTY
        [Display(Name="Project Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Severity is required")]
        [Display(Name = "Severity")]
        public string Severity { get; set; }
        public List<Note> Note { get; set; }
       

    }
}