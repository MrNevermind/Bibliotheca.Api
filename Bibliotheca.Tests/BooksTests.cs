using Bibliotheca.Core;
using Bibliotheca.Library;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Bibliotheca.Tests
{
    public class BooksTests
    {
        BibliothecaManager Manager { get; set; }
        int BookId { get; set; }

        [SetUp]
        public void Setup()
        {
            Settings.ConnectionString = "Data Source=bibliotheca_test.db";

            using (var context = BibliothecaContext.CreateContext())
            {
                context.Database.Migrate();
            }

            Manager = new BibliothecaManager(BibliothecaContext.CreateContext());
        }

        [Test, Order(1)]
        public void CreateBook()
        {
            BookId = Manager.AddBook(new Book()
            {
                Title = "FROM TEST",
                Author = "FROM TEST",
                Status = BookStatus.Available
            });

            Assert.IsTrue(BookId > 0);
        }

        [Test, Order(2)]
        public void GetBooks()
        {
            var books = Manager.GetBooks();
            Assert.IsTrue(books.Length > 0);
        }

        [Test, Order(3)]
        public void GetBook()
        {
            var book = Manager.GetBook(BookId);
            Assert.IsNotNull(book);
        }

        [Test, Order(4)]
        public void UpdateBook()
        {
            Manager.UpdateBook(BookId, new Book()
            {
                Title = "TEST FROM",
                Author = "TEST FROM",
            });

            var book = Manager.GetBook(BookId);

            Assert.IsNotNull(book);
            Assert.IsTrue(book.Title == "TEST FROM");
            Assert.IsTrue(book.Author == "TEST FROM");
        }

        [Test, Order(5)]
        public void DeleteBook()
        {
            Manager.DeleteBook(BookId);
            var book = Manager.GetBook(BookId);
            Assert.IsTrue(book == null);
        }
    }
}