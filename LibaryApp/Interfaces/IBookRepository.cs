using LibaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApp.Interfaces
{
    interface IBookRepository
    {
        Task<ActionResult<IEnumerable<Book>>> GetBooks();
        Task<ActionResult<Book>> GetBook(int id);
        void PutBook(int id, Book book);

        Task<ActionResult<Book>> DeleteBook(int id);
    }
}
