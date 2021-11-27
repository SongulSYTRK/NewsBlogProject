
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsBlogProject.Infrastructure.Repositories.Interface.IEntityTypeRepository;
using NewsBlogProject.Model.Enums;
using NewsBlogProject.UI.Areas.Member.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Member.Controllers
{
    [Area("Member")]
    public class MemberNewsController : Controller
    {
        private readonly INewsCastRepository _newsCastRepository;
        private readonly IMapper _mapper;
        public MemberNewsController(INewsCastRepository newsCastRepository,
                                    IMapper mapper)
        {
            this._newsCastRepository = newsCastRepository;
            this._mapper = mapper;
        }
        #region Member get newsList
        public IActionResult GetListNews()
        {
            var NewsList = _newsCastRepository.GetDefaults(
                                                           selector: x=> new GetNewsVM
                                                           { 
                                                           Id=x.Id,
                                                           Title=x.Title,
                                                           Content=x.Content,
                                                           Image=x.Image,
                                                           CategoryName=x.Category.CategoryName,
                                                           UserFullName=x.AppUser.FullName,
                                                           UserImage=x.AppUser.Image,
                                                           CreateDate=x.CreateDate,
                                                           LikeCount=x.Like.Count,
                                                           CommentCount=x.Comment.Count                                                 
                                                           },
                                                           expression: x=>x.Status != Status.Passive);
            return View(NewsList);
        }
        #endregion
        #region Member read more detail
        public IActionResult NewsDetail(int id)
        {
            var NewsDetail = _newsCastRepository.GetDefault(
                                                   selector: x=> new GetNewsVM
                                                   {
                                                       Id = x.Id,
                                                       Title = x.Title,
                                                       Content = x.Content,
                                                       Image = x.Image,
                                                       CategoryName = x.Category.CategoryName,
                                                       UserFullName = x.AppUser.FullName,
                                                       UserImage = x.AppUser.Image,
                                                       CreateDate = x.CreateDate,
                                                       LikeCount = x.Like.Count,
                                                       CommentCount = x.Comment.Count,
                                                       Comments = x.Comment.Where(z=>z.NewsCastId==id)
                                                                           .OrderByDescending(z=>z.CreateDate)
                                                                           .Select(z=> new GetCommentVM
                                                                           { 
                                                                             Id=z.Id,
                                                                             Text=z.Text,
                                                                             Fullname=z.AppUser.FullName,
                                                                             UserImage=z.AppUser.Image
                                                                           })
                                                                           .ToList()
                                                                        
                                                   },
                                                   expression: x => x.Status != Status.Passive,
                                                   include: x => x.Include(z => z.AppUser).ThenInclude(z => z.Comments)


                                                 );
            return View(NewsDetail);
        }
        #endregion

    }
}
