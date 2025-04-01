using RESTBooks.Models;

namespace RESTBooks.Data
{
    public class BookStore : IBookStore {
        private static List<Book> books = new List<Book> {
            new Book { Id=1, Title="Sample", Author="Author", ISBN="123", PublicationDate=DateTime.Now }
        };
        private static int nextId = 2;

        public List<Book> getAllBooks() => books;

        public Book getBook(int id)
        {
            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return books.First();
        }
        public Book addBook(Book book) {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            book.Id = nextId;
            nextId++;

            book.PublicationDate = DateTime.Now;

            books.Add(book);
            return book;
        }

        public String updateBook(Book book) {
            var index = books.FindIndex(b => b.Id == book.Id);
            if (index >= 0) 
            { 
                books[index] = book;
                return "1";
            }
            else { return "0"; }
        }

        public bool deleteBook(int id)
        {
            var index = books.FindIndex(b => b.Id == id);
            if (index >= 0)
            {
                books.RemoveAll(b => b.Id == id);
                return true;
            }
            else { return false; }
        }
    }

}
