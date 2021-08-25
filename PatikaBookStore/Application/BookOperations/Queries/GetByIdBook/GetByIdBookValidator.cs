using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.BookOperations.Queries.GetByIdBook
{
    public class GetByIdBookValidator : AbstractValidator<GetByIdBookQuery>
    {
        public GetByIdBookValidator()
        {
            RuleFor(x=>x.BookId).GreaterThan(0);
        }
    }
}
