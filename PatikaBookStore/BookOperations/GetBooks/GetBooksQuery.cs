using AutoMapper;
using PatikaBookStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreContext _dbcontext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var liste1 = _dbcontext.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(liste1);
     
            return vm;
        }

    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }

}

