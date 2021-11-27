using Microsoft.AspNetCore.Mvc;
using NewsBlogProject.Infrastructure.Repositories.Interface.IEntityTypeRepository;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.UI.Areas.Member.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Member.Controllers
{

    [Area("Member")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ILikeRepository _likeRepository;
        public CommentController(ICommentRepository commentRepository, ILikeRepository likeRepository)
        {
            this._commentRepository = commentRepository;
            this._likeRepository = likeRepository;
        }
        #region ADDCOMMENT
        public JsonResult AddComment(string GetComment, int newsId)
        {
            Comment comment = new Comment();
            comment.Text = GetComment;
            comment.NewsCastId = newsId;
            comment.CreateDate = DateTime.Now;
            comment.AppUserId = 2;
            _commentRepository.Create(comment);
            return Json("");
        }
        #endregion

        #region DELETECOMMENT
        public JsonResult DeleteComment(int id)
        {
          var comment=  _commentRepository.GetInt(x => x.Id == id);
            _commentRepository.Delete(comment);
            return Json("");

        }
        #endregion
        #region GetComment
        public JsonResult GetComment(int id)
        {
            var Comment = _commentRepository.GetDefault(
                                                           selector: x => new GetCommentVM
                                                           {
                                                               Id = x.Id,
                                                               Text = x.Text,
                                                               CreateDate = x.CreateDate,
                                                               Fullname = x.AppUser.FullName,
                                                               UserImage = x.AppUser.Image
                                                           },
                                                          
                                                            expression: x => x.Id == id
                                                       ) ;
            return Json(Comment);

        }
        #endregion
    }
}
