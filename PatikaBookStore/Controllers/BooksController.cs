using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaBookStore.Application.BookOperations.Commands.CreateBook;
using PatikaBookStore.Application.BookOperations.Commands.DeleteBook;
using PatikaBookStore.Application.BookOperations.Commands.UpdateBook;
using PatikaBookStore.Application.BookOperations.Queries.GetBooks;
using PatikaBookStore.Application.BookOperations.Queries.GetByIdBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PatikaBookStore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static PatikaBookStore.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace PatikaBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            GetByIdBookQuery query = new GetByIdBookQuery(_context, _mapper);

            query.BookId = id;
            GetByIdBookValidator validations = new GetByIdBookValidator();
            validations.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command._createBookModel = newBook;

            CreateBookCommandValidator validations = new CreateBookCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBookModel book)
        {

            UpdateBookCommand _command = new UpdateBookCommand(_context);

            _command._updateBookModel = book;
            _command.BookId = id;

            UpdateBookCommandValidator validations = new UpdateBookCommandValidator();
            validations.ValidateAndThrow(_command);
            _command.Handle();

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

            command.BookId = id;
            DeleteBookCommandValidator validations = new DeleteBookCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
    
            return Ok();

        }

    }
}
