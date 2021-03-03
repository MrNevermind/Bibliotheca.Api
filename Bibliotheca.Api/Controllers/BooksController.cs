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
    public class BooksController : ControllerBase
    {
        private BibliothecaManager Manager { get; set; }
        public BooksController(BibliothecaManager bibliothecaManager)
        {
            Manager = bibliothecaManager;
        }

        [HttpGet]
        public Book[] GetBooks()
        {
            return Manager.GetBooks();
        }
        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            return Manager.GetBook(id);
        }
        [HttpPost("{bookId}/return")]
        public void ReturnBook(int bookId)
        {
            Manager.ReturnBook(bookId);
        }
        [HttpGet("{title}/check")]
        public BookStatus? CheckBookStatus(string title)
        {
            return Manager.CheckBookStatus(title);
        }
        [HttpPost]
        public void AddBook([FromBody] Book book)
        {
            Manager.AddBook(book);
        }
        [HttpPut("{id}")]
        public void UpdateBook(int id, [FromBody] Book book)
        {
            Manager.UpdateBook(id, book);
        }
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            Manager.DeleteBook(id);
        }
    }
}
