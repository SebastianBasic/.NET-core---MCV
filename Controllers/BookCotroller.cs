using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _NET_core___MCV.Models;
using Microsoft.EntityFrameworkCore;

namespace _NET_core___MCV.Controllers
{
    public class BookController : Controller
    {
        private readonly MariaDbContext _db;
        public Book Book { get; set; }

        public BookController(MariaDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null) {
                return View(Book);
            }else{
                Book = _db.Book.FirstOrDefault(u => u.id == id);

                if(Book == null){
                    return NotFound();
                }else{
                    return View(Book);
                }
            }
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new {data = await _db.Book.ToListAsync()});
        }

        [HttpDelete]
        public async Task<IActionResult> Destroy(int id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(u => u.id == id);

            if(bookFromDb == null){
                return Json(new {success = false, message="Error while Deleting"});
            }
            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            
            return Json(new {success = true, message = "Delete successful"});
        }
        #endregion
    }
}
