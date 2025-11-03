using Library_BasicCRUD.Models;
namespace Library_BasicCRUD.Services
{
    public class BooksService
    {
        private readonly List<Book> _books = new()
        {
        new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
        new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 },
        new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925 }
        };
        public List<Book> GetAll()
        {
            return _books;
        }
        public Book? GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }
        public void Add(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
        }   
        
         public bool Update(int id, Book updatedBook)
        {
            var book = GetById(id);
            if (book == null)
            {
                return false;
            }
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;
            return true;

        }
        public bool Delete(int id)
        {
            var book = GetById(id);
            if (book == null)
            {
                return false;
            }
            _books.Remove(book);
            return true;
        }
    }
}
