using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreContext _dbcontext;
        public int AuthorId;
        public UpdateAuthorModel _updateModel;

        public UpdateAuthorCommand(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x=>x.Id == AuthorId);

            if (author==null)
            {
                throw new InvalidOperationException("Böyle bir id'e sahip author yok");
            }

            author.AuthorName = _updateModel.AuthorName != default ? _updateModel.AuthorName : author.AuthorName;
            author.AuthorSurname = _updateModel.AuthorSurname != default ? _updateModel.AuthorSurname : author.AuthorSurname;
            

            _dbcontext.SaveChanges();


        }

        public class UpdateAuthorModel
        {
      
            public string AuthorName { get; set; }
            public string AuthorSurname { get; set; }
        }


    }
}
