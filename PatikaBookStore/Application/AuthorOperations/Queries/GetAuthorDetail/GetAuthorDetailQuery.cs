using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreContext _dbcontext;
        private readonly IMapper _mapper;
        public int AuthorId;

        public GetAuthorDetailQuery(BookStoreContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }


        public GetAuthorDetailModel Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x=>x.Id == AuthorId);

            if (author == null)
            {
                throw new InvalidOperationException("Böyle id'e sahip author yok");
            }

            GetAuthorDetailModel authormodel = _mapper.Map<GetAuthorDetailModel>(author);
            return authormodel;

        }

    }


    public class GetAuthorDetailModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public DateTime BornDate { get; set; }
    }

}
