using ProjectsNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO.MemoryMappedFiles;
using System.IO;

namespace ProjectsNotes.Controllers
{
    public enum Sorting
    {
        Ascending, Descending
    }
    public class NotesController : Controller
    {
        // GET: Notes
        DataContext db = new DataContext();
        public ActionResult Index(string SearchBy, string search, string SortBy)
        {
            if (SearchBy == "Agenda")
            {
                return View(db.NoteObj.Where(x => x.Agenda.StartsWith(search) || search == null).ToList());//SEARCH ON THE BASIS OF AGENDA OF NOTE
            }
            int index = 1;//FOR DESCENDING ORDER
            Sorting Sort = (Sorting)index;
            var SortingNotes = db.NoteObj.AsQueryable();// FOR QUERYING THE DATA FROM DATABASE
            switch (Sort)
            {
                case Sorting.Ascending:// IF WANT DATA IN ASCENDING ORDER
                    SortingNotes = SortingNotes.OrderBy(x => x.Agenda); // WILL SORT DATA IN ASCENDING ORDER
                    break;
                default:
                    SortingNotes = SortingNotes.OrderByDescending(x => x.Agenda);// DEFAULT ORDER IS DESCENDING
                    break;
            }
            return View(SortingNotes);// RETURN PROJECTS  
        }
        public ActionResult Display(int ProjectId)
        {
            List<Note> NoteObj = db.NoteObj.Where(Notes => Notes.ProjectID == ProjectId).ToList();//DISPLAY NOTES OF THAT PROJECT
            return View(NoteObj);// RETURN PROJECTS  
        }
        public ActionResult NoteSent(int Id)
        {
            Note Note_ = db.NoteObj.Single(x => x.ID == Id);//CHANGE THE STATUS OF NOTE 
            if (Note_.Status == "Save")
            {
                Note_.Status = "Sent";
            }
            db.SaveChanges();
            return View();
        }


        // GET: Notes/Details/5)
        // WILL DISPLAY THE REQUIRED PROJECTS DETAIL DEPENDING ON THE ID GIVEN 
        public ActionResult Details(int id)
        {
            var DataByID = db.NoteObj.Single(x => x.ID == id);
            return View(DataByID);
        }

        // GET: Notes/Create
        [HttpGet]
        public ActionResult Create()// CREATE VIEW FOR INSERTION 
        {
            return View();
        }

        // POST: Notes/Create

        [HttpPost]
        public ActionResult Create(Note Proj, HttpPostedFileBase ImageFile)// ADD IMAGE AND OTHER DETAILS OF NOTE
        {
            string fileName = Path.GetFileNameWithoutExtension(Proj.ImageFile.FileName);
            string extension = Path.GetExtension(Proj.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            Proj.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            Proj.ImageFile.SaveAs(fileName);
            using (DataContext db2 = new DataContext())
            {
                db2.NoteObj.Add(Proj);
                db2.SaveChanges();
            }
            ModelState.Clear();
            return View();// RETURN TO SAME CREATE VIEW

        }
        [HttpGet]
        public ActionResult View(int id)// VIEW IMAGE OF EVERY SPECIFIC NOTE
        {
            Note NoteImage = new Note();
            using (DataContext db3 = new DataContext())
            {
                NoteImage = db3.NoteObj.Where(x => x.ID == id).FirstOrDefault();
            }
            return View(NoteImage);
        }

        public ActionResult SectionedSepartely()//SEPARTE SECTION FOR SENT NOTES
        {
            var data = db.NoteObj.Where(x => x.Status == "Sent").ToList();
            return View(data);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int id)
        {
            var DataByID = db.NoteObj.Single(x => x.ID == id);
            return View(DataByID);
        }

        // POST: Notes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Note collection)//EDIT A NOTE IF IT IS IN SAVE STATE NOT IN SENT MODE
        {
            Note Notes_ = db.NoteObj.Single(x => x.ID == id);
            try
            {
                if (Notes_.Status == "Save")
                {
                    Note NOte = db.NoteObj.Single(x => x.ID == id);
                    NOte.ProjectID = collection.ProjectID;
                    NOte.Agenda = collection.Agenda;
                    NOte.DateOfNote = collection.DateOfNote;
                    NOte.Attendee = collection.Attendee;
                    NOte.DescriptionOfNote = collection.DescriptionOfNote;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "NOTE IS ALREADY SENT SO IT CANNOT BE EDITED";
                    return RedirectToAction("Edit");
                }
            }
            catch
            {
                return View();
            }
        }
        // GET: Notes/Delete/5
        public ActionResult Delete(int id)
        {
            var DataByID = db.NoteObj.Single(x => x.ID == id);
            return View(DataByID);
        }
        // POST: Notes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Note Note)// ACTION TO BE EXECUTED WHEN DESIRED OPTION IS CLICKED FOR DELETION
        {
            try
            {
                var data = db.NoteObj.Single(x => x.ID == id);
                db.NoteObj.Remove(data);
                db.SaveChanges();
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
