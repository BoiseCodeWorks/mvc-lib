using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_library.Models;

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
            var library = _db.Libraries.Find(id);

            if (library == null)
            {
                return NotFound($"Sorry there is no library by that id: {id}");
            }

            return View(library);

        }

        // public IActionResult AddBook()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public IActionResult AddBook(string title, string author, string description)
        // {
        //     if (title == null || author == null)
        //     {
        //         return RedirectToAction("AddBook");
        //     }
        //     library.AddBook(new Book(title, author, description));
        //     return RedirectToAction("Index");
        // }
        // public IActionResult ViewBook(int id)
        // {
        //   var myBook = library.GetBookById(id);
        //   return View(myBook);
        // }
    }
}
