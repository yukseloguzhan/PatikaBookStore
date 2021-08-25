using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x=>x.GenreId).GreaterThan(0);
            RuleFor(x => x._updateGenreModel.Name).MinimumLength(4).When(y=>y._updateGenreModel.Name != string.Empty);
        }
    }
}
