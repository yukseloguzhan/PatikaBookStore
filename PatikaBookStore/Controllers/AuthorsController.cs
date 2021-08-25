using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaBookStore.Application.AuthorOperations.Command.CreateAuthor;
using PatikaBookStore.Application.AuthorOperations.Command.DeleteAuthor;
using PatikaBookStore.Application.AuthorOperations.Command.UpdateAuthor;
using PatikaBookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using PatikaBookStore.Application.AuthorOperations.Queries.GetAuthors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PatikaBookStore.Application.AuthorOperations.Command.CreateAuthor.CreateAuthorCommand;
using static PatikaBookStore.Application.AuthorOperations.Command.UpdateAuthor.UpdateAuthorCommand;

namespace PatikaBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var list = query.Handle();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;

            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody]CreateAuthorModel author)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = author;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id,[FromBody] UpdateAuthorModel newauthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command._updateModel = newauthor;
            command.AuthorId = id;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }


    }
}
