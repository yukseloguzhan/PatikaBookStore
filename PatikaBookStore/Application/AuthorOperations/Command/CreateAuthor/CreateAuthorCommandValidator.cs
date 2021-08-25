using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x=>x.Model.AuthorName).MinimumLength(2);
            RuleFor(x => x.Model.BornDate).LessThanOrEqualTo(DateTime.Now);
        }
    }
}
