using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibaryApp.Models;
using LibaryApp.Interfaces;

namespace LibaryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly CoreDbContext _context;
        private IBookService bookService;


        public BooksController(CoreDbContext context)
        {
            _context = context;
            this.bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        [Route("books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await this.bookService.GetBooks();
        }

        // GET: api/Books/5
        [HttpGet]
        [Route("book/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await this.bookService.GetBook(id);
        }

        // PUT: api/Books/5.
        [HttpPut("{id}")]
        public void PutBook(int id, Book book)
        {
            this.bookService.PutBook(id,book);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
           return await  this.bookService.DeleteBook(id);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
