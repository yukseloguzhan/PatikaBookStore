using AutoMapper;
using PatikaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model;

        public CreateAuthorCommand(BookStoreContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public void Handle()
        {
           var author =  _dbcontext.Authors.SingleOrDefault(x=>x.AuthorName == Model.AuthorName && x.AuthorSurname==x.AuthorSurname);
            if (author!=null)
            {
                throw new InvalidOperationException("Daha önce bu yazar eklendi");
            }

            var obj = _mapper.Map<Author>(Model);
            _dbcontext.Add(obj);
            _dbcontext.SaveChanges();
        }

        public class CreateAuthorModel
        {
            public string AuthorName { get; set; }
            public string AuthorSurname { get; set; }
            public DateTime BornDate { get; set; }
        }

    }
}
