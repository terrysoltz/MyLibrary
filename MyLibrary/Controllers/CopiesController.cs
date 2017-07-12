using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Models;
using PagedList;
using PagedList.EntityFramework;

namespace MyLibrary.Controllers
{
    public class CopiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Copies
        public async Task<ActionResult> Index(int? page)
        {
            var copies = db.Copies.Include(c => c.Book).Include(c => c.Branch).OrderBy(c => c.Book.Title);
            var authors = await db.BookAuthors.ToListAsync();
            //copiesView.Copies = copies;
            ViewBag.Authors = authors;

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(await copies.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: Copies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copies copies = await db.Copies.FindAsync(id);
            if (copies == null)
            {
                return HttpNotFound();
            }
            return View(copies);
        }

        // GET: Copies/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title");
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName");
            return View();
        }

        // POST: Copies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CopiesID,BookID,BranchID,NoCopies")] Copies copies)
        {
            if (ModelState.IsValid)
            {
                db.Copies.Add(copies);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", copies.BookID);
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", copies.BranchID);
            return View(copies);
        }

        // GET: Copies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copies copies = await db.Copies.FindAsync(id);
            if (copies == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", copies.BookID);
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", copies.BranchID);
            return View(copies);
        }

        // POST: Copies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CopiesID,BookID,BranchID,NoCopies")] Copies copies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copies).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", copies.BookID);
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", copies.BranchID);
            return View(copies);
        }

        // GET: Copies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copies copies = await db.Copies.FindAsync(id);
            if (copies == null)
            {
                return HttpNotFound();
            }
            return View(copies);
        }

        // POST: Copies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Copies copies = await db.Copies.FindAsync(id);
            db.Copies.Remove(copies);
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
