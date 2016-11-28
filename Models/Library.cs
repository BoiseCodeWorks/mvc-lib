using System.Collections.Generic;

namespace mvc_library.Models
{
    public class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public Library(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void AddBook(Book bookToAddToList)
        {
            Books.Add(bookToAddToList);
        }

        public List<Book> GetAllBooks()
        {
            return Books;
        }


    }
}