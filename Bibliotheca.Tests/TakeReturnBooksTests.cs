using Bibliotheca.Core;
using Bibliotheca.Library;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Bibliotheca.Tests
{
    public class TakeReturnBooksTests
    {
        BibliothecaManager Manager { get; set; }

        int BookId { get; set; }
        int AccountId { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            Settings.ConnectionString = "Data Source=bibliotheca_test.db";

            using (var context = BibliothecaContext.CreateContext())
            {
                context.Database.Migrate();
            }

            Manager = new BibliothecaManager(BibliothecaContext.CreateContext());

            AccountId = Manager.AddAccount(new Account()
            {
                FirstName = "FROM TEST",
                LastName = "FROM TEST",
                PhoneNumber = "+37035598988"
            });


            BookId = Manager.AddBook(new Book()
            {
                Title = "FROM TEST",
                Author = "FROM TEST",
                Status = BookStatus.Available
            });
        }

        [Test, Order(1)]
        public void TakeBook()
        {
            Manager.TakeBook(AccountId, BookId);
            var books = Manager.GetAccountBooks(AccountId);
            Assert.IsTrue(books.Length > 0);
        }

        [Test, Order(2)]
        public void GetTakenBook()
        {
            var books = Manager.GetAccountBooks(AccountId);
            Assert.IsTrue(books.Length > 0);
        }

        [Test, Order(3)]
        public void ReturnBook()
        {
            Manager.ReturnBook(BookId);
            var books = Manager.GetAccountBooks(AccountId);
            Assert.IsTrue(books.Length == 0);
        }

    }
}
