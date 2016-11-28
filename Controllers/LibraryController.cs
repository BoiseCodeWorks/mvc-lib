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
        public static Library library = new Library("The Library of Alexandria", "Alexandria");
        public IActionResult Index()
        {
            return View(library);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(string title, string author)
        {
            if (title == null || author == null)
            {
                return RedirectToAction("AddBook");
            }
            library.AddBook(new Book(title, author));
            return RedirectToAction("Index");
        }


    }
}
