using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using OnlineBookWebsite.Models;

namespace TextBookNinja.Controllers
{
    [Authorize(Roles = "Member")]
    public class UsersBooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UsersBooks
        public async Task<ActionResult> Index()
        {
            var usersBooks = db.UsersBooks.Include(u => u.Book).Include(u => u.User);
            return View(await usersBooks.ToListAsync());
        }

        // GET: UsersBooks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersBook usersBook = await db.UsersBooks.FindAsync(id);
            if (usersBook == null)
            {
                return HttpNotFound();
            }
            return View(usersBook);
        }

        // GET: UsersBooks/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "ID", "Title");
            ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: UsersBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserID,BookID,Price,CreateDate,Condition,Comment,EditDate")] UsersBook usersBook)
        {
            if (ModelState.IsValid)
            {
                db.UsersBooks.Add(usersBook);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "ID", "Title", usersBook.BookID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName", usersBook.UserID);
            return View(usersBook);
        }

        // GET: UsersBooks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersBook usersBook = await db.UsersBooks.FindAsync(id);
            if (usersBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "ID", "Title", usersBook.BookID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName", usersBook.UserID);
            return View(usersBook);
        }

        // POST: UsersBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Price,Condition,Comment,EditDate")] UsersBook usersBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersBook).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "ID", "Title", usersBook.BookID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName", usersBook.UserID);
            return View(usersBook);
        }

        // GET: UsersBooks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersBook usersBook = await db.UsersBooks.FindAsync(id);
            if (usersBook == null)
            {
                return HttpNotFound();
            }
            return View(usersBook);
        }

        // POST: UsersBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UsersBook usersBook = await db.UsersBooks.FindAsync(id);
            db.UsersBooks.Remove(usersBook);
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
