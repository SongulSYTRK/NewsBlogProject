using NewsBlogProject.Infrastructure.Context;
using NewsBlogProject.Infrastructure.Repositories.Interface.IEntityTypeRepository;
using NewsBlogProject.Infrastructure.Repositories.Repository.Abstract;
using NewsBlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Infrastructure.Repositories.Repository.Concrete
{
   public  class CommentRepository:BaseRepository<Comment> , ICommentRepository
    {
        public CommentRepository(AppDbContext appDbContext): base(appDbContext)
        {

        }
    }
}
