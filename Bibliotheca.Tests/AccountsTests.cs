using Bibliotheca.Core;
using Bibliotheca.Library;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Bibliotheca.Tests
{
    class AccountsTests
    {
        BibliothecaManager Manager { get; set; }
        int AccountId { get; set; }

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
        public void CreateAccount()
        {
            AccountId = Manager.AddAccount(new Account() {
                FirstName = "FROM TEST",
                LastName = "FROM TEST",
                PhoneNumber = "+37035598988"
            });

            Assert.IsTrue(AccountId > 0);
        }

        [Test, Order(2)]
        public void GetAccounts()
        {
            var accounts = Manager.GetAccounts();
            Assert.IsTrue(accounts.Length > 0);
        }

        [Test, Order(3)]
        public void GetAccount()
        {
            var account = Manager.GetAccount(AccountId);
            Assert.IsNotNull(account);
        }

        [Test, Order(4)]
        public void UpdateAccount()
        {
            Manager.UpdateAccount(AccountId, new Account() {
                FirstName = "TEST FROM",
                LastName = "TEST FROM",
                PhoneNumber = "+37035598999"
            });

            var account = Manager.GetAccount(AccountId);

            Assert.IsNotNull(account);
            Assert.IsTrue(account.FirstName == "TEST FROM");
            Assert.IsTrue(account.LastName == "TEST FROM");
            Assert.IsTrue(account.PhoneNumber == "+37035598999");
        }

        [Test, Order(5)]
        public void DeleteAccount()
        {
            Manager.DeleteAccount(AccountId);
            var account = Manager.GetAccount(AccountId);
            Assert.IsTrue(account == null);
        }
    }
}
