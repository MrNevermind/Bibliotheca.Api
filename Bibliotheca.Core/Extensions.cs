using Bibliotheca.Core.Tables;
using Bibliotheca.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheca.Core
{
    public static class Extensions
    {
        #region Accounts
        public static AccountTable ToTable(this Account account)
        {
            return new AccountTable()
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                PhoneNumber = account.PhoneNumber
            };
        }

        public static Account ToAccount(this AccountTable table)
        {
            return new Account()
            {
                Id = table.Id,
                FirstName = table.FirstName,
                LastName = table.LastName,
                PhoneNumber = table.PhoneNumber
            };
        }

        public static void Update(this AccountTable table, Account account)
        {
            table.FirstName = account.FirstName;
            table.LastName = account.LastName;
            table.PhoneNumber = account.PhoneNumber;
        }
        #endregion
        #region Books
        public static BookTable ToTable(this Book book)
        {
            return new BookTable()
            {
                Author = book.Author,
                Title = book.Title,
                Status = book.Status,
                Cover = book.Cover
            };
        }

        public static Book ToBook(this BookTable table)
        {
            return new Book()
            {
                Id = table.Id,
                Author = table.Author,
                Cover = table.Cover,
                Title = table.Title,
                Status = table.Status
            };
        }

        public static void Update(this BookTable table, Book book)
        {
            table.Author = book.Author;
            table.Title = book.Title;
            table.Status = book.Status;
            table.Cover = book.Cover;
        }
        #endregion
    }
}
