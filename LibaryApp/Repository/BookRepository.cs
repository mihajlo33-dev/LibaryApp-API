using LibaryApp.Interfaces;
using LibaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApp.Repository
{
    
    public class BookRepository : IBookRepository
    {

        private readonly CoreDbContext _context;
        public BookRepository(CoreDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = _context.Books.ToListAsync();
            
            return await books;
        }

        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                throw new Exception("Book doesn't exist!");
            }

            return book;
        }

        public  void  PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                throw new Exception("Book doesn't exist!");
            }

            _context.Books.Update(book);


            _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new Exception("Book doesn't exist!");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }





    }
}
