using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsBlogProject.Infrastructure.Repositories.Interface.IEntityTypeRepository;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.Model.Enums;
using NewsBlogProject.UI.Areas.Admin.Models.DataTransferObjects;
using NewsBlogProject.UI.Areas.Admin.Models.VMs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsCastController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly INewsCastRepository _newsCastRepository;
        private readonly IMapper _mapper;
        public NewsCastController(IAppUserRepository appUserRepository,
                                  ICategoryRepository categoryRepository,
                                   INewsCastRepository newsCastRepository,
                                   IMapper mapper)
        {

            this._appUserRepository = appUserRepository;
            this._categoryRepository = categoryRepository;
            this._newsCastRepository = newsCastRepository;
            this._mapper = mapper;
        }
        #region Create 
        [HttpGet]
        public IActionResult Create()
        {
            NewsCastCreateDTO model = new NewsCastCreateDTO()

            {
                Categories = _categoryRepository.GetDefaults
                    (selector: x => new GetCategoryVM
                    {
                        Id = x.Id,
                        CategoryName = x.CategoryName
                    },
              expression: x => x.Status != Status.Passive),


              AppUsers = _appUserRepository.GetDefaults
                        (selector: x => new GetAppUserVM
                        {
                            Id = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName


                        },
                        expression: x=>x.Status != Status.Passive)

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(NewsCastCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var newsCast = _mapper.Map<NewsCast>(model);
                if (newsCast.ImagePath != null)
                {
                    using var image = Image.Load(model.ImagePath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));

                    Guid guid = Guid.NewGuid();
                    image.Save($"wwwroot/images/{guid}{newsCast.Title}.jpg");  
                    newsCast.Image = ($"/images/{guid}{newsCast.Title}.jpg");
                    _newsCastRepository.Create(newsCast);
                    return RedirectToAction("List");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
         

        }

        #endregion
        #region List
        public IActionResult List()
        {
            var NewsList = _newsCastRepository.GetDefaults
                (selector: x => new GetNewsVM
                {    Id=x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,
                    CategoryName = x.Category.CategoryName,
                    UserFullName = x.AppUser.FullName,
                },
                expression: x => x.Status != Status.Passive,
                include:x=>x.Include(z=>z.Category).Include(z=>z.AppUser));
            return View(NewsList);
        }
        #endregion
        #region Delete
        public IActionResult Delete(int id)
        {
            var newscast = _newsCastRepository.GetInt(x=>x.Id==id);
            _newsCastRepository.Delete(newscast);
            return RedirectToAction("List");
        }
        #endregion
        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var news = _newsCastRepository.GetDefault(selector: x => new GetNewsVM
                                                                   { 
                                                                    Id=x.Id,
                                                                    Title= x.Title,
                                                                    Content=x.Content,
                                                                    Image=x.Image,
                                                                    CategoryName=x.Category.CategoryName,
                                                                    UserFullName=x.AppUser.FullName
                                                                   },

                                                     expression: x=>x.Id==id,
                                                     include:x=>x.Include(z=>z.Category).Include(z=>z.AppUser));
            if(ModelState.IsValid)
            {
                var model = _mapper.Map<NewsCastUpdateDTO>(news);

                model.Categories = _categoryRepository.GetDefaults
                      (selector: x => new GetCategoryVM
                      {
                          Id = x.Id,
                          CategoryName = x.CategoryName
                      },
              expression: x => x.Status != Status.Passive);
                model.AppUsers = _appUserRepository.GetDefaults
                      (selector: x => new GetAppUserVM
                      {
                          Id = x.Id,
                          FirstName = x.FirstName,
                          LastName = x.LastName


                      },
                         expression: x => x.Status != Status.Passive);

                return View(model);
            }
            else
            {
                return View(news);
            }
        }
        [HttpPost]
        public IActionResult Update (NewsCastUpdateDTO model)
        {

            var News = _mapper.Map<NewsCast>(model);
            if(ModelState.IsValid)
            {
                using var image = Image.Load(model.ImagePath.OpenReadStream());
                image.Mutate(x=>x.Resize(256,256));
                image.Save($"wwwroot/images/{News.Title}.jpg");
                News.Image = ($"/images/{News.Title}.jpg");
                _newsCastRepository.Update(News);
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }




        }
        #endregion
        #region Detail
        public IActionResult Detail(int id)
        {
            var detail = _newsCastRepository.GetDefault(
                                              selector: x => new GetNewsCastDetailVM
                                              {
                                                  Id = x.Id,
                                                  Title = x.Title,
                                                  Content = x.Content,
                                                  Image = x.Image,
                                                  UserFullName = x.AppUser.FullName,
                                                  UserImmage = x.AppUser.Image,
                                                  CreateDate=x.CreateDate,
                                                  CategoryName = x.Category.CategoryName,
                                                  CommentCount = x.Comment.Count,
                                                  LikeCount = x.Like.Count,
                                                  Comments = x.Comment.Where(z=>z.NewsCastId==id)
                                                                    .OrderByDescending(z => z.CreateDate)
                                                                    .Select(z=> new CommentVM
                                                                    {
                                                                      Id=z.Id,
                                                                      Text=z.Text,
                                                                      Fullname=z.AppUser.FullName,
                                                                      UserImage=z.AppUser.Image,
                                                                      CreateDate=z.CreateDate
                                                                    })
                                                                    .ToList(),


                                              },
                                              expression: x => x.Id == id,
                                              include: x => x.Include(z => z.AppUser).ThenInclude(z => z.Comments)
                                              ) ;
            return View(detail);
        }
        #endregion
    }
}
