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
    public class Skills_InfoController : Controller
    {
        private HRContext db = new HRContext();

        // GET: Skills_Info
        public async Task<ActionResult> Index()
        {
            return View(await db.Skills_Info.ToListAsync());
        }

        // GET: Skills_Info/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills_Info skills_Info = await db.Skills_Info.FindAsync(id);
            if (skills_Info == null)
            {
                return HttpNotFound();
            }
            return View(skills_Info);
        }

        // GET: Skills_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,flag")] Skills_Info skills_Info)
        {
            if (ModelState.IsValid)
            {
                db.Skills_Info.Add(skills_Info);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(skills_Info);
        }

        // GET: Skills_Info/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills_Info skills_Info = await db.Skills_Info.FindAsync(id);
            if (skills_Info == null)
            {
                return HttpNotFound();
            }
            return View(skills_Info);
        }

        // POST: Skills_Info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,flag")] Skills_Info skills_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skills_Info).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(skills_Info);
        }

        // GET: Skills_Info/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills_Info skills_Info = await db.Skills_Info.FindAsync(id);
            if (skills_Info == null)
            {
                return HttpNotFound();
            }
            return View(skills_Info);
        }

        // POST: Skills_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Skills_Info skills_Info = await db.Skills_Info.FindAsync(id);
            db.Skills_Info.Remove(skills_Info);
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
