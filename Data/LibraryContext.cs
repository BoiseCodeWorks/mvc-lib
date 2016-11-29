using Microsoft.EntityFrameworkCore;
using mvc_library.Models;

namespace mvc_library
{
    public class LibraryContext : DbContext
    {
        public DbSet<Library> Libraries {get; set;}
        public DbSet<Book> Books {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./MVCLibrary.db");
        }
    }
}