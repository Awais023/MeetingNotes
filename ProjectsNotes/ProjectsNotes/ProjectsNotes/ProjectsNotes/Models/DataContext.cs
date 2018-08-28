using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectsNotes.Models
{
    public class DataContext :DbContext
    {

        public DataContext(): base("Connection") { }// GETTING CONNECTION STRING 
        public DbSet<Project> ProjectObj { get; set; }//DATABASE SET FOR PROJECTS
        public DbSet<Note> NoteObj { get; set; }// //DATABASE SET FOR NOTES
        public System.Data.Entity.DbSet<ProjectsNotes.Models.UserGroup> UserGroups { get; set; }

        public DbSet<UserAccount> uAccount { get; set; }// //DATABASE SET FOR NOTES

        public DbSet<AddParticipant> Participant { get; set; }// //DATABASE SET FOR PARTICIPANTS
    }
}