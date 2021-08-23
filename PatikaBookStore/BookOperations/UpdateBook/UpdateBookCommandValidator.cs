using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x=>x.BookId).GreaterThan(0);
            RuleFor(x=>x._updateBookModel.GenreId).GreaterThan(0);
            RuleFor(x=>x._updateBookModel.Title).MinimumLength(1);
        }
    }
}
