using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatikaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreContext _dbcontext;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var list = _dbcontext.Authors.OrderBy(y=>y.Id);
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(list);
            return vm;
        }

    }

    public class AuthorsViewModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public DateTime BornDate { get; set; }
    }

}
