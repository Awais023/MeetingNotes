using ProjectsNotes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectsNotes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataContext db = new DataContext();// REFERENCE OF DATA CONTEXT FILE HAVING REFERNCE OF PROJECTS AND NOTES
        public ActionResult Index(string SearchBy,string search,string SortBy) // INDEX METHOD FOR SORTING BY PROJECT NAME
        {
            if (SearchBy=="Name")
            {
                return View(db.ProjectObj.Where(x => x.Name.StartsWith(search) || search == null).ToList());//SEARCH ON THE BASIS OF NAME OF PROJECT
            }
            int index=0;// 0 IS FOR ASCENDING ORDER
            Sorting Sort = (Sorting)index;
            var Projects_ = db.ProjectObj.AsQueryable();// FOR QUERYING THE DATA FROM DATABASE
            switch(Sort)
            {
                case Sorting.Ascending:// IF WANT DATA IN ASCENDING ORDER
                    Projects_ = Projects_.OrderBy(x => x.Name);
                    break;
                default:
                    Projects_ = Projects_.OrderByDescending(x => x.Name);// DEFAULT ORDER IS DESCENDING 
                    break;
            }
            return View(Projects_);// RETURN PROJECTS 
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)// WILL DISPLAY THE REQUIRED PROJECTS DETAIL DEPENDING ON THE ID GIVEN 
        {
            var DataByID = db.ProjectObj.Single(x => x.ID == id);
            return View(DataByID);
        }
        // GET: Home/Create
        public ActionResult Create()// CREATE VIEW FOR INSERTION 
        {
            return View();
        }
        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Project Proj)
        {
            try
            {
                db.ProjectObj.Add(Proj);//ADD PROJECTS
                db.SaveChanges();
                return View();// RETURN TO SAME CREATE VIEW

            }
            catch
            {
                return View();
            }

        }
        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Project ProjectObject)
        {
            try
            {

                return RedirectToAction("Index"); ;
            }
            catch
            {
                return View();
            }
        }
        // GET: Home/Delete/5
        public ActionResult Delete(int id)// ACTION TO BE EXECUTED WHEN DESIRED OPTION IS CLICKED FOR DELETION
        {
            var DataByID = db.ProjectObj.Single(x => x.ID == id);
            return View(DataByID);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Project collection)
        {
            try
            {
                var data = db.ProjectObj.Single(x => x.ID == id);
                db.ProjectObj.Remove(data);//DELETED A SPECIFIC ROW FROM TABLE
                db.SaveChanges();// SUBMIT CHANGES AFTER DELETION
                return View();
            }
            catch
            {
                return View();
            }
        }
       
    }
}
