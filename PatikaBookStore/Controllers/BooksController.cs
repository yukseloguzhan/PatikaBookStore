using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaBookStore.BookOperations.CreateBook;
using PatikaBookStore.BookOperations.GetBooks;
using PatikaBookStore.BookOperations.GetByIdBook;
using PatikaBookStore.BookOperations.UpdateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PatikaBookStore.BookOperations.CreateBook.CreateBookCommand;
using static PatikaBookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace PatikaBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;
        public BooksController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            GetByIdBookQuery query = new GetByIdBookQuery(_context);

            try
            {
                var result = query.Handle(id);
                return Ok(result);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
      
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context);

            try
            {
                command._createBookModel = newBook;
                command.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,[FromBody] UpdateBookModel book)
        {

            UpdateBookCommand _command = new UpdateBookCommand(_context);

            try
            {
                _command._updateBookModel = book;
                _command.Handle(id);
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book==null)
            {
                return NotFound(); 
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

    }
}
