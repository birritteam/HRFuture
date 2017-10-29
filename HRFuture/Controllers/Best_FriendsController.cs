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
    public class Best_FriendsController : Controller
    {
        private HRContext db = new HRContext();

        // GET: Best_Friends
        public async Task<ActionResult> Index()
        {
            var best_Friends = db.Best_Friends.Include(b => b.Personal_Info);
            return View(await best_Friends.ToListAsync());
        }

        // GET: Best_Friends/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Best_Friends best_Friends = await db.Best_Friends.FindAsync(id);
            if (best_Friends == null)
            {
                return HttpNotFound();
            }
            return View(best_Friends);
        }

        // GET: Best_Friends/Create
        public ActionResult Create()
        {
            ViewBag.personid = new SelectList(db.Personal_Info, "id", "fname");
            return View();
        }

        // POST: Best_Friends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "personid,persontype,name")] Best_Friends best_Friends)
        {
            if (ModelState.IsValid)
            {
                db.Best_Friends.Add(best_Friends);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.personid = new SelectList(db.Personal_Info, "id", "fname", best_Friends.personid);
            return View(best_Friends);
        }

        // GET: Best_Friends/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Best_Friends best_Friends = await db.Best_Friends.FindAsync(id);
            if (best_Friends == null)
            {
                return HttpNotFound();
            }
            ViewBag.personid = new SelectList(db.Personal_Info, "id", "fname", best_Friends.personid);
            return View(best_Friends);
        }

        // POST: Best_Friends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "personid,persontype,name")] Best_Friends best_Friends)
        {
            if (ModelState.IsValid)
            {
                db.Entry(best_Friends).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.personid = new SelectList(db.Personal_Info, "id", "fname", best_Friends.personid);
            return View(best_Friends);
        }

        // GET: Best_Friends/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Best_Friends best_Friends = await db.Best_Friends.FindAsync(id);
            if (best_Friends == null)
            {
                return HttpNotFound();
            }
            return View(best_Friends);
        }

        // POST: Best_Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Best_Friends best_Friends = await db.Best_Friends.FindAsync(id);
            db.Best_Friends.Remove(best_Friends);
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
