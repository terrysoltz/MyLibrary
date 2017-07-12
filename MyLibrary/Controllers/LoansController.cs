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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MyLibrary.Controllers
{
    public class LoansController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _db;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationDbContext db
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set
            {
                _db = value;
            }
        }


        // GET: Loans
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var loans = db.Loans.Include(l => l.Book).Include(l => l.Branch).Where(l => l.Borrower.Id == user.Id);
            var temploans = await loans.ToListAsync();
            return View(temploans);
        }

        // GET: Loans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = await db.Loans.FindAsync(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: Loans/Create
        [Authorize]
        public async Task<ActionResult> Create(int? id)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copies copies = await db.Copies.FindAsync(id);
            if (copies == null)
            {
                return HttpNotFound();
            }

            var bookLoans = new LoanViewModel();
            bookLoans.Copies = copies;
            bookLoans.Loan = new Loan();
            bookLoans.Loan.DateOut = System.DateTime.Now;
            bookLoans.Loan.DueDate = bookLoans.Loan.DateOut.AddMonths(1);
            bookLoans.Loan.Borrower = user;
            return View(bookLoans);
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Prefix = "Loan", Include = "BookID,BranchID,DateOut,DueDate")] Loan loan,
            [Bind(Prefix = "Copies", Include = "CopiesID,BookID,BranchID,NoCopies")] Copies copies)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            loan.Borrower = user;
            if (ModelState.IsValid)
            {
                var thisCopy = await db.Copies.FindAsync(copies.CopiesID);
                if (thisCopy.NoCopies < 1)
                {
                    return RedirectToAction("Index", "Copies");
                }
                else
                {
                    thisCopy.NoCopies -= 1;
                }

                db.Loans.Add(loan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var loanViewModel = new LoanViewModel();
            loanViewModel.Copies = copies;
            loanViewModel.Loan = loan;
            return View(loanViewModel);
        }

        // GET: Loans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = await db.Loans.FindAsync(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", loan.BookID);
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", loan.BranchID);
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LoanID,BookID,BranchID,ApplicationUserID,DateOut,DueDate")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", loan.BookID);
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", loan.BranchID);
            return View(loan);
        }

        // GET: Loans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = await db.Loans.FindAsync(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Loan loan = await db.Loans.FindAsync(id);
            var thisCopy = db.Copies.Where(c => c.BookID == loan.BookID && c.BranchID == loan.BranchID).FirstOrDefault();
            thisCopy.NoCopies += 1;
            db.Loans.Remove(loan);
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
