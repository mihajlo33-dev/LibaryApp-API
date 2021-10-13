using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibaryApp.Interfaces;
using LibaryApp.Models;
using LibaryApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibaryApp.Services
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;

        public BookService(BookService bookService) 
        {
            this.bookRepository = bookRepository;
        }

        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await this.bookRepository.GetBooks();
        }

        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await this.bookRepository.GetBook(id);
        }

        public void PutBook(int id, Book book)
        {
            this.bookRepository.PutBook(id,book);
        }

        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            return await this.bookRepository.DeleteBook(id);
        }
    }

    }
