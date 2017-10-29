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
    public class Personal_InfoController : Controller
    {
        private HRContext db = new HRContext();

        // GET: Personal_Info
        public async Task<ActionResult> Index()
        {
            return View(await db.Personal_Info.ToListAsync());
        }

        // GET: Personal_Info/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Info personal_Info = await db.Personal_Info.FindAsync(id);
            if (personal_Info == null)
            {
                return HttpNotFound();
            }
            return View(personal_Info);
        }

        // GET: Personal_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personal_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,type,fname,lname,fathername,mothername,ename,bdate,bronum,glass,smoke,health,smoketype,curraddres,lastaddress,mobile,phone,mail,facebook,education,netifuse,netusing,notes,knownfriend,knowninitiative,knowngheraspage,applydate,sizejacket,sizeshirt,sizepants,sizevest,sizesport,sizeshoes,isactive,personalphoto,idphoto")] Personal_Info personal_Info)
        {
            if (ModelState.IsValid)
            {
                db.Personal_Info.Add(personal_Info);
                await db.SaveChangesAsync();
                return new JsonResult { Data = "Successd" };
            }

            return new JsonResult { Data = "Faild" };
        }

        // GET: Personal_Info/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Info personal_Info = await db.Personal_Info.FindAsync(id);
            if (personal_Info == null)
            {
                return HttpNotFound();
            }
            return View(personal_Info);
        }

        // POST: Personal_Info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,type,fname,lname,fathername,mothername,ename,bdate,bronum,glass,smoke,health,smoketype,curraddres,lastaddress,mobile,phone,mail,facebook,education,netifuse,netusing,notes,knownfriend,knowninitiative,knowngheraspage,applydate,sizejacket,sizeshirt,sizepants,sizevest,sizesport,sizeshoes,isactive,personalphoto,idphoto")] Personal_Info personal_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_Info).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(personal_Info);
        }

        // GET: Personal_Info/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Info personal_Info = await db.Personal_Info.FindAsync(id);
            if (personal_Info == null)
            {
                return HttpNotFound();
            }
            return View(personal_Info);
        }

        // POST: Personal_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Personal_Info personal_Info = await db.Personal_Info.FindAsync(id);
            db.Personal_Info.Remove(personal_Info);
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
