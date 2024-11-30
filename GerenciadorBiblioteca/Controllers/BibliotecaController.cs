using GerenciadorBiblioteca.Models;
using GerenciadorBiblioteca.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorBiblioteca.Controllers
{
    public class LibraryController
    {
        private readonly BibliotecaData _data;

        public LibraryController(BibliotecaData data)
        {
            _data = data;
        }

        public List<Book> GetBooks() => _data.LoadBooks();

        public Book GetBookById(Guid id) => GetBooks().FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            var books = _data.LoadBooks();
            books.Add(book);
            _data.SaveBooks(books);
        }

        public void EditBook(Book updatedBook)
        {
            var books = _data.LoadBooks();
            var book = books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.ISBN = updatedBook.ISBN;
                book.Pages = updatedBook.Pages;
                book.Edition = updatedBook.Edition;
                _data.SaveBooks(books);
            }
        }

        public void DeleteBook(Guid id)
        {
            var books = _data.LoadBooks();
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                _data.SaveBooks(books);
            }
        }

        public void BorrowBook(Guid id)
        {
            var books = _data.LoadBooks();
            var book = books.FirstOrDefault(b => b.Id == id && b.IsAvailable);
            if (book != null)
            {
                book.IsAvailable = false;
                _data.SaveBooks(books);
            }
        }

        public void ReturnBook(Guid id)
        {
            var books = _data.LoadBooks();
            var book = books.FirstOrDefault(b => b.Id == id && !b.IsAvailable);
            if (book != null)
            {
                book.IsAvailable = true;
                _data.SaveBooks(books);
            }
        }
    }
}
