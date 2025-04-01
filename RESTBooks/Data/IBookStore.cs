using RESTBooks.Models;

namespace RESTBooks.Data
{
    public interface IBookStore
    {
        List<Book> getAllBooks();
        Book getBook(int id);
        Book addBook(Book book);
        String updateBook(Book book);
        bool deleteBook(int id);
    }
}
