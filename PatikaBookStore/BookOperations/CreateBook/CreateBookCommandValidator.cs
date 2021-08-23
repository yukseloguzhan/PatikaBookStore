using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x=>x._createBookModel.GenreId).GreaterThan(0);
            RuleFor(x=>x._createBookModel.PageCount).GreaterThan(0);
            RuleFor(x => x._createBookModel.Title).NotEmpty().MinimumLength(4);
            RuleFor(x => x._createBookModel.PublishDate.Date).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);
        }
    }
}
