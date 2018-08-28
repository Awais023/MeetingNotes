using ProjectsNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO.MemoryMappedFiles;


namespace ProjectsNotes.Controllers
{
    public class UserGroupController : Controller
    {
        DataContext db = new DataContext();
        // GET: UserGroup
        public ActionResult Index(string SortBy)
        {
            var GrouP = db.UserGroups.AsQueryable();// FOR QUERYING THE DATA FROM DATABASE
            int index = 0;//FOR DESCENDING ORDER
            Sorting Sort = (Sorting)index;
            switch (Sort)
            {
                case Sorting.Ascending:// IF WANT DATA IN ASCENDING ORDER
                    GrouP = GrouP.OrderBy(x => x.Name); // WILL SORT DATA IN ASCENDING ORDER
                    break;
                default:
                    GrouP = GrouP.OrderByDescending(x => x.Name);// DEFAULT ORDER IS DESCENDING
                    break;
            }
            return View(GrouP);// RETURN PROJECTS  
        }

        // GET: UserGroup/Details/5
        public ActionResult Details(int id)
        {
            var DataByID = db.UserGroups.Single(x => x.ID == id);
            return View(DataByID);
        }

        // GET: UserGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserGroup/Create
        [HttpPost]
        public ActionResult Create(UserGroup Group)//ADD GROUP TO DATABASE
        {
            try
            {
                db.UserGroups.Add(Group);
                db.SaveChanges();
                return View();// RETURN TO SAME CREATE VIEW
            }
            catch
            {
                return View();
            }
        }

        // GET: UserGroup/Edit/5
        public ActionResult Edit(int id)
        {
            var DataByID = db.UserGroups.Single(x => x.ID == id);
            return View(DataByID);
        }

        // POST: UserGroup/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserGroup Group)//EDIT A GROUP 
        {
            UserGroup Group_ = db.UserGroups.Single(x => x.ID == id);
            try
            {
                UserGroup GRoup = db.UserGroups.Single(x => x.ID == id);
                GRoup.ID = Group.ID;
                GRoup.Name = Group.Name;
                GRoup.Email = Group.Email;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddMembers(AddParticipant Member)//ADD MEMBERS IN A GROUP WITH UNIQUE EMAILS
        {
            try
            {
                db.Participant.Add(Member);
                db.SaveChanges();
                return View();// RETURN TO SAME CREATE VIEW
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ViewMembers(int id)// VIEW MEMBERS OF EVERY GROUP
        {
            try
            {
                List<AddParticipant> ParticipanT = db.Participant.Where(p => p.GroupID == id).ToList();
                return View(ParticipanT);// RETURN PROJECTS  
            }
            catch
            {
                return View();
            }
       }
        // GET: UserGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserGroup/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
