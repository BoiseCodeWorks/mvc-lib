using System.Collections.Generic;

namespace mvc_library.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}