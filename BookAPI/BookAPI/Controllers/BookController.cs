using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookAPI.Models;
using BookAPI.Repositories;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookRepository bookRepository;
        public BookController(BookRepository bookrepository)
        {
            bookRepository = bookrepository;
        }

        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookRepository.ReadAll();
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public Book Get(Guid id)
        {
            return bookRepository.Read(id);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            bookRepository.Create(book);
        }

        [HttpPut]
        public void Put([FromBody] Book book)
        {
            bookRepository.Update(book);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            bookRepository.Delete(id);
        }
    }
}
