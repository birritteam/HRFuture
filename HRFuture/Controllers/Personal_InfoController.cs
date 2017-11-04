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
using System.Web.Hosting;
using System.IO;

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
            ViewBag.idYM = (db.Personal_Info.Where(x => x.type == "YM").Max(x => x.id) + 1);
            ViewBag.idYF = (db.Personal_Info.Where(x => x.type == "YF").Max(x => x.id) + 1);
            ViewBag.idFM = (db.Personal_Info.Where(x => x.type == "FM").Max(x => x.id) + 1);
            ViewBag.idFF = (db.Personal_Info.Where(x => x.type == "FF").Max(x => x.id) + 1);
            return View();
        }

        // POST: Personal_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,type,fname,lname,fathername,mothername,ename,bdate,bronum,glass,smoke,health,smoketype,curraddres,lastaddress,mobile,phone,mail,facebook,education,netifuse,netusing,notes,knownfriend,knowninitiative,knowngheraspage,applydate,sizejacket,sizeshirt,sizepants,sizevest,sizesport,sizeshoes,isactive,personalphoto,schoolname,Time,updateddate,educationbranch")] Personal_Info personal_Info, IEnumerable<HttpPostedFileBase> file1, IEnumerable<HttpPostedFileBase> file2)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if ( Request.Files.Count > 0 )
                    {
                        personal_Info.personalphoto = saveFile(file1, personal_Info.type + "_" + personal_Info.type + "_personalimage");
                        personal_Info.idphoto = saveFile(file2, personal_Info.type + "_" + personal_Info.type + "_idimage");
                    }
                       
                    db.Personal_Info.Add(personal_Info);
                    await db.SaveChangesAsync();
                    return new JsonResult { Data = "Successd" };
                }
                catch(Exception ex)
                {
                    return new JsonResult { Data = "Faild"  + ex.Message};
                }
                 
                }

            return new JsonResult { Data = "Faild"   };
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
        public async Task<ActionResult> Edit([Bind(Include = "id,type,fname,lname,fathername,mothername,ename,bdate,bronum,glass,smoke,health,smoketype,curraddres,lastaddress,mobile,phone,mail,facebook,education,netifuse,netusing,notes,knownfriend,knowninitiative,knowngheraspage,applydate,sizejacket,sizeshirt,sizepants,sizevest,sizesport,sizeshoes,isactive,personalphoto,schoolname,Time,updateddate,educationbranch")] Personal_Info personal_Info)
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

        public string saveFile ( IEnumerable<HttpPostedFileBase> file ,string filename  )
        {
            string path = HostingEnvironment.ApplicationPhysicalPath + "images";
            if (file != null )
                foreach (var f in file)
                {
                    path = Path.Combine(path, filename + Path.GetExtension(f.FileName));
                    f.SaveAs(path);
                }
            return path;
           
        }

        public ActionResult uploadimage(IEnumerable<HttpPostedFileBase> uploadedimage)
        {
            string path = Server.MapPath("~/images/");
         
            
            if (uploadedimage != null)
                foreach (var f in uploadedimage)
                {
                    path = Path.Combine(path, "Hi" + Path.GetExtension(f.FileName));
                    f.SaveAs(path);
                    return new JsonResult { Data = "تم التحميل بنجاح" };
                }

            
                
            return new JsonResult { Data = "فشل العملية" };
        }

    }
}
