using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProjectsController : Controller
    {
        private ChallangeDataEntities2 db = new ChallangeDataEntities2();

        // GETTER: Project
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.User).Include(p => p.User1).Include(p => p.User2).Include(p => p.User3);
            return View(projects.ToList());
        }

        // list the amount of avaliable projects to join from
        // GETTER: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // creating a new project
        // GETTER: Projects/Create
        public ActionResult Create()
        {
            ViewBag.StudentOne = new SelectList(db.Users, "UserName", "StudentName");
            ViewBag.StudentTwo = new SelectList(db.Users, "UserName", "StudentName");
            ViewBag.StudentThree = new SelectList(db.Users, "UserName", "StudentName");
            ViewBag.StudentFour = new SelectList(db.Users, "UserName", "StudentName");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,StudentOne,StudentTwo,StudentThree,StudentFour,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentOne = new SelectList(db.Users, "UserName", "StudentName", project.StudentOne);
            ViewBag.StudentTwo = new SelectList(db.Users, "UserName", "StudentName", project.StudentTwo);
            ViewBag.StudentThree = new SelectList(db.Users, "UserName", "StudentName", project.StudentThree);
            ViewBag.StudentFour = new SelectList(db.Users, "UserName", "StudentName", project.StudentFour);
            return View(project);
        }

        // editing memebers of a project
        // GETTER: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentOne = new SelectList(db.Users, "UserName", "StudentName", project.StudentOne);
            ViewBag.StudentTwo = new SelectList(db.Users, "UserName", "StudentName", project.StudentTwo);
            ViewBag.StudentThree = new SelectList(db.Users, "UserName", "StudentName", project.StudentThree);
            ViewBag.StudentFour = new SelectList(db.Users, "UserName", "StudentName", project.StudentFour);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,StudentOne,StudentTwo,StudentThree,StudentFour,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentOne = new SelectList(db.Users, "UserName", "StudentName", project.StudentOne);
            ViewBag.StudentTwo = new SelectList(db.Users, "UserName", "StudentName", project.StudentTwo);
            ViewBag.StudentThree = new SelectList(db.Users, "UserName", "StudentName", project.StudentThree);
            ViewBag.StudentFour = new SelectList(db.Users, "UserName", "StudentName", project.StudentFour);
            return View(project);
        }

        // deleting/removing a project from the system
        // GETTER: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // confirming project deletion
        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
