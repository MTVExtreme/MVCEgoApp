﻿using PagedList;
using PersonalityEgo.DAL;
using PersonalityEgo.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PersonalityEgo.Controllers
{
    public class PersonalityController : Controller
    {
        private EgoContext db = new EgoContext();

        // GET: Personality
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstName_desc" : "";
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastName_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.AgeSortParm = sortOrder == "Age" ? "age_desc" : "Age";
            var personalities = from s in db.Personality
                           select s;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            //Comment
            ViewBag.CurrentFilter = searchString;


            if (!String.IsNullOrEmpty(searchString))
            {
                personalities = personalities.Where(s => s.LastName.Contains(searchString)
                                    || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstName_desc":
                    personalities = personalities.OrderByDescending(s => s.FirstName);
                    break;
                case "lastName_desc":
                    personalities = personalities.OrderByDescending(s => s.LastName);
                    break;
                case "date_desc":
                    personalities = personalities.OrderByDescending(s => s.Birthday);
                    break;
                case "age_desc":
                    personalities = personalities.OrderBy(s => s.MentalAge);
                    break;
                default:
                    personalities = personalities.OrderBy(s => s.LastName);
                    break;
            }

            // var personality = db.Personality.Include(r => r.Role);

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(personalities.ToPagedList(pageNumber, pageSize));
        }

        // GET: Personality/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personality personality = db.Personality.Find(id);
            if (personality == null)
            {
                return HttpNotFound();
            }
            return View(personality);
        }

        // GET: Personality/Create
        public ActionResult Create()
        {
            PopulateRolesDropDownList();
            return View();
        }


        private void PopulateRolesDropDownList(object selectedRole = null)
        {
            var rolesQuery = from d in db.Role
                             orderby d.RoleName
                             select d;
            ViewBag.RoleID = new SelectList(rolesQuery, "RoleID", "RoleName", selectedRole);
        }

        // POST: Personality/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,MentalAge,Birthday,RoleID")] Personality personality)
        {
            if (ModelState.IsValid)
            {
                db.Personality.Add(personality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personality);
        }



        // GET: Personality/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personality personality = db.Personality.Find(id);
            if (personality == null)
            {
                return HttpNotFound();
            }
            PopulateRolesDropDownList(personality.RoleID);
            return View(personality);
        }

        // POST: Personality/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Gender,MentalAge,Birthday,RoleID")] Personality personality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateRolesDropDownList(personality.RoleID);
            return View(personality);
        }

        // GET: Personality/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personality personality = db.Personality.Find(id);
            if (personality == null)
            {
                return HttpNotFound();
            }
            return View(personality);
        }

        // POST: Personality/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personality personality = db.Personality.Find(id);
            db.Personality.Remove(personality);
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
