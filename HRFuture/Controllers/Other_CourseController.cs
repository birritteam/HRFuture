using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRFuture.Models;

namespace HRFuture.Controllers
{
    public class Other_CourseController : Controller
    {
        private HRContext db = new HRContext();

        // GET: Other_Course
        public async Task<ActionResult> Index()
        {
            var other_Course = db.Other_Course.Include(o => o.Personal_Info);
            return View(await other_Course.ToListAsync());
        }

        // GET: Other_Course/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Course other_Course = await db.Other_Course.FindAsync(id);
            if (other_Course == null)
            {
                return HttpNotFound();
            }
            return View(other_Course);
        }

        // GET: Other_Course/Create
        public ActionResult Create()
        {
            ViewBag.personid = new SelectList(db.Personal_Info, "id", "fname");
            return View();
        }

        // POST: Other_Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "personid,persontype,name,organizer,date")] Other_Course other_Course)
        {
            if (ModelState.IsValid)
            {
                db.Other_Course.Add(other_Course);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.personid = new SelectList(db.Personal_Info, "id", "fname", other_Course.personid);
            return View(other_Course);
        }

        // GET: Other_Course/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Course other_Course = await db.Other_Course.FindAsync(id);
            if (other_Course == null)
            {
                return HttpNotFound();
            }
            ViewBag.personid = new SelectList(db.Personal_Info, "id", "fname", other_Course.personid);
            return View(other_Course);
        }

        // POST: Other_Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "personid,persontype,name,organizer,date")] Other_Course other_Course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(other_Course).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.personid = new SelectList(db.Personal_Info, "id", "fname", other_Course.personid);
            return View(other_Course);
        }

        // GET: Other_Course/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Course other_Course = await db.Other_Course.FindAsync(id);
            if (other_Course == null)
            {
                return HttpNotFound();
            }
            return View(other_Course);
        }

        // POST: Other_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Other_Course other_Course = await db.Other_Course.FindAsync(id);
            db.Other_Course.Remove(other_Course);
            await db.SaveChangesAsync();
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
