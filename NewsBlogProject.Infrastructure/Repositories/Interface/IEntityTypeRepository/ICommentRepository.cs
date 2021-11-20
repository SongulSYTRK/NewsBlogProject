using NewsBlogProject.Infrastructure.Repositories.Interface.IBaseRepository;
using NewsBlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Infrastructure.Repositories.Interface.IEntityTypeRepository
{
    public interface ICommentRepository : IBaseRepository<Comment> { }
    
}
