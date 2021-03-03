using Bibliotheca.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bibliotheca.Core
{
    public class BibliothecaManager
    {
        private BibliothecaContext Context { get; set; }
        public BibliothecaManager(BibliothecaContext bibliothecaContext)
        {
            Context = bibliothecaContext;
        }

        #region Accounts
        public Account[] GetAccounts()
        {
            return Context.Accounts.OrderBy(a => a.FirstName).ThenBy(a => a.LastName).Select(a => a.ToAccount()).ToArray();
        }
        public Account GetAccount(int id)
        {
            var account = Context.Accounts.FirstOrDefault(a => a.Id == id);

            if (account != null)
                return account.ToAccount();
            else
                return null;
        }
        public Book[] GetAccountBooks(int id)
        {
            return Context.Accounts.Where(a => a.Id == id).SelectMany(a => a.Books).ToArray().Select(b => b.ToBook()).ToArray();
        }
        public int AddAccount(Account account)
        {
            var table = account.ToTable();

            Context.Accounts.Add(table);
            Context.SaveChanges();

            return table.Id;
        }
        public void UpdateAccount(int id, Account account)
        {
            var table = Context.Accounts.FirstOrDefault(a => a.Id == id);
            if (table != null)
            {
                table.Update(account);
                Context.Accounts.Update(table);
                Context.SaveChanges();
            }
        }
        public void DeleteAccount(int id)
        {
            var table = Context.Accounts.FirstOrDefault(a => a.Id == id);
            if (table != null)
            {
                Context.Accounts.Remove(table);
                Context.SaveChanges();
            }
        }
        #endregion
        #region Books
        public Book[] GetBooks()
        {
            return Context.Books.OrderBy(b => b.Author).ThenBy(b => b.Title).Select(b => b.ToBook()).ToArray();
        }
        public Book GetBook(int id)
        {

            var book = Context.Books.FirstOrDefault(a => a.Id == id);

            if (book != null)
                return book.ToBook();
            else
                return null;
        }
        public BookStatus? CheckBookStatus(string title)
        {
            var book = Context.Books.FirstOrDefault(b => b.Title.ToLower().Contains(title.ToLower()));
            if (book != null)
                return book.Status;
            else
                return null;
        }
        public int AddBook(Book book)
        {
            var table = book.ToTable();

            Context.Books.Add(table);
            Context.SaveChanges();

            return table.Id;
        }
        public void UpdateBook(int id, Book book)
        {
            var table = Context.Books.FirstOrDefault(a => a.Id == id);
            if (table != null)
            {
                table.Update(book);
                Context.Books.Update(table);
                Context.SaveChanges();
            }
        }
        public void DeleteBook(int id)
        {
            var table = Context.Books.FirstOrDefault(a => a.Id == id);
            if (table != null)
            {
                Context.Books.Remove(table);
                Context.SaveChanges();
            }
        }
        #endregion
        #region Take/Return
        public void TakeBook(int accountId, int bookId)
        {
            var account = Context.Accounts.FirstOrDefault(a => a.Id == accountId);
            var book = Context.Books.FirstOrDefault(b => b.Id == bookId);

            if(account != null && book != null)
            {
                if (account.Books == null)
                    account.Books = new List<Tables.BookTable>();
                book.Status = BookStatus.Taken;
                account.Books.Add(book);
                book.Account = account;
                Context.Accounts.Update(account);
                Context.Books.Update(book);
                Context.SaveChanges();
            }
        }
        public void ReturnBook(int bookId)
        {
            var book = Context.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                var account = Context.Accounts.FirstOrDefault(a => a.Id == book.Account.Id);

                account.Books.Remove(book);
                book.Account = null;
                book.Status = BookStatus.Available;
                Context.Accounts.Update(account);
                Context.Books.Update(book);
                Context.SaveChanges();
            }
        }
        #endregion
    }
}
