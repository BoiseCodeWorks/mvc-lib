using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_library.Models;
using Microsoft.EntityFrameworkCore;


namespace mvc_library.Controllers
{
    public class LibraryController : Controller
    {
        private LibraryContext _db;

        public LibraryController(LibraryContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var libraries = _db.Libraries.ToList();
            return View(libraries);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Library library)
        {
            _db.Libraries.Add(library);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var library = _db.Libraries.Include(
              db => db.Books
            ).FirstOrDefault(lib => lib.Id == id);

            if (library == null)
            {
                return NotFound($"Sorry there is no library by that id: {id}");
            }
            return View(library);
        }

        [HttpGet("/Library/Details/{libraryId}/Books")]
        public IActionResult AddBook(int libraryId)
        {
            return View();
        }

        [HttpPost("/Library/Details/{libraryId}/Books")]
        public IActionResult AddBook(int libraryId, Book book)
        {
            book.LibraryId = libraryId;
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = libraryId });
        }

        // public IActionResult ViewBook(int id)
        // {
        //   var myBook = library.GetBookById(id);
        //   return View(myBook);
        // }
    }
}
