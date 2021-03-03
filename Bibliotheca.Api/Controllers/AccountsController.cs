using Bibliotheca.Core;
using Bibliotheca.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotheca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private BibliothecaManager Manager { get; set; }
        public AccountsController(BibliothecaManager bibliothecaManager)
        {
            Manager = bibliothecaManager;
        }

        [HttpGet]
        public Account[] GetAccounts()
        {
            return Manager.GetAccounts();
        }
        [HttpGet("{id}")]
        public Account GetAccount(int id)
        {
            return Manager.GetAccount(id);
        }
        [HttpGet("{id}/books")]
        public Book[] GetAccountBooks(int id)
        {
            return Manager.GetAccountBooks(id);
        }
        [HttpPost]
        public void AddAccount([FromBody] Account account)
        {
            Manager.AddAccount(account);
        }
        [HttpPost("{accountId}/take/{bookId}")]
        public void TakeBook(int bookId, int accountId)
        {
            Manager.TakeBook(accountId, bookId);
        }
        [HttpPut("{id}")]
        public void UpdateAccount(int id, [FromBody] Account account)
        {
            Manager.UpdateAccount(id, account);
        }
        [HttpDelete("{id}")]
        public void DeleteAccount(int id)
        {
            Manager.DeleteAccount(id);
        }
    }
}
