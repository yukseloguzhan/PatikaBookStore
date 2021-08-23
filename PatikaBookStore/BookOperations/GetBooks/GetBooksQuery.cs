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


        public GetBooksQuery(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<BooksViewModel> Handle()
        {
            var liste1 = _dbcontext.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = new List<BooksViewModel>();

            foreach (var x in liste1)
            {
                vm.Add(new BooksViewModel
                {
                    Title = x.Title,
                    PageCount = x.PageCount,
                    PublishDate = x.PublishDate.Date.ToString("dd/MM/yyyy"),
                    Genre = ((GenreEnum)x.GenreId).ToString()

                });
            }

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

