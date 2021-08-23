using AutoMapper;
using PatikaBookStore.BookOperations.GetBooks;
using PatikaBookStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.BookOperations.GetByIdBook
{
    public class GetByIdBookQuery
    {
        private readonly BookStoreContext _dbcontext;
        private readonly IMapper _mapper;
        public int BookId;

        public GetByIdBookQuery(BookStoreContext dbcontext,IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public BooksDetailViewModel Handle()
        {
            var book = _dbcontext.Books.Where(x => x.Id == BookId).SingleOrDefault();

            if (book == null)
            {
                throw new InvalidOperationException("Bu id'e sahip kitap yok!");
            }


            var bookView = _mapper.Map<BooksDetailViewModel>(book); 
            return bookView;


        }

    }

    public class BooksDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}
