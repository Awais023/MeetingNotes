using ProjectsNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectsNotes.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (DataContext db = new DataContext())
            {
                return View(db.uAccount.ToList());//DISPLAY THE LIST OF ALL REGISTERED USERS
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account)// CONTROLLER FUNCTION TO REGISTER A USER
        {
            if(ModelState.IsValid)// REPRESENT THE ERROR AND SUBMITTED VALUES
            {
                using (DataContext db = new DataContext())// DATABASE CONNECTION 
                {
                    db.uAccount.Add(account);// INSERTING INTO DB USING LINQ QUERIES
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + "   " + account.LastName + " Successfully Registered.";
            }
            return View();
        }

        public ActionResult Login()// CONTROLLER FUNCTION TO LOGIN A USER
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (DataContext db2 = new DataContext())
            {
                var usr = db2.uAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();// LINQ QUERY TO MATCH USERNAME AND PASSWORD
                if(usr!=null)
                {
                   HttpContext.Session["ID"] = usr.ID.ToString();
                   HttpContext.Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is not correct.");
                }
                return View();
            }
        }

        public ActionResult LoggedIn()
        {
            if (Session["ID"]!=null)//IF NO USER IS LOG IN 
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }





    }
}