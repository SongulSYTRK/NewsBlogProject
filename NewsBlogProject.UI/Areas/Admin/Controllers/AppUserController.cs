

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Microsoft.AspNetCore.Mvc;
using NewsBlogProject.Infrastructure.Repositories.Interface.IEntityTypeRepository;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.UI.Areas.Admin.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using NewsBlogProject.Model.Enums;
using AutoMapper;
using NewsBlogProject.UI.Areas.Admin.Models.VMs;

namespace NewsBlogProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;

        // *****I injected IMapper. In this way Two class property merged automatically***///
        private readonly IMapper _mapper; 
        public AppUserController(IAppUserRepository appUserRepository,
                                 IMapper mapper)
        {
            this._appUserRepository = appUserRepository;
            this._mapper = mapper;
        }
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AppUserCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                //AppUser appUser = new AppUser();
                //appUser.FirstName = model.FirstName;
                //appUser.LastName = model.LastName;
                //appUser.UserName = model.UserName;
                //appUser.Password = model.Password;
                //appUser.Role = model.Role;
                //appUser.Image = model.Image;


                /////*******Before I write Totaly seven line of code . But Now I write 1 line of code . I won time and errorrate decreased*****//////
                var appUser = _mapper.Map<AppUser>(model);


                if (model.ImagePath != null)
                {
                    //****I setting image. you can  cut , crop image **//
                    using var image = SixLabors.ImageSharp.Image.Load(model.ImagePath.OpenReadStream()); //find image
                    image.Mutate(x => x.Resize(256, 256)); //setting size 
                    image.Save($"wwwroot/images/{appUser.UserName}.jpg");   //saved document 
                    appUser.Image = ($"/images/{appUser.UserName}.jpg");   //send to appuser.image property



                    _appUserRepository.Create(appUser);
                    return RedirectToAction("List");
                }
                else
                {
                    return View();
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
            return View(_appUserRepository.GetDefaults(selector: x=>new GetAppUserVM
                                                          {
                Id=x.Id,
                FirstName=x.FirstName,
                                                            LastName=x.LastName,
                                                          UserName=x.UserName,
                                                          Password=x.Password,
                                                          Role=x.Role,
                                                          Image=x.Image
                                                          },
                                                          expression: x=>x.Status!=Status.Passive));
        }
        #endregion
        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var appUser = _appUserRepository.GetDefault(selector: x=>new GetAppUserVM
                                                          {Id=x.Id,
                                                          FirstName=x.FirstName,
                                                          LastName=x.LastName,
                                                          UserName=x.UserName,
                                                          Password=x.Password,
                                                          Role=x.Role,
                                                          Image=x.Image
                                                          },
                                                          expression: x=>x.Id==id);
            // AppUserUpdateDTO model = new AppUserUpdateDTO();
            if (ModelState.IsValid)
            {
                //model.FirstName=appUser.FirstName;
                //model.LastName =appUser.LastName ;
                //model.UserName =appUser.UserName ;
                //model.Password = appUser.Password;
                //model.Role = appUser.Role;
                //model.Image = appUser.Image;
                var model = _mapper.Map<AppUserUpdateDTO>(appUser);
                return View(model);
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public IActionResult Update(AppUserUpdateDTO model)
        {
            // AppUser appUser = _appUserRepository.GetDefault(x => x.Id == model.Id);
            if (ModelState.IsValid)
            {

                //appUser.FirstName = model.FirstName;
                //appUser.LastName = model.LastName;
                //appUser.UserName = model.UserName;
                //appUser.Password = model.Password;
                //appUser.Role = model.Role;
                var appUser = _mapper.Map<AppUser>(model);
                if (model.ImagePath != null)
                {
                    using var image = SixLabors.ImageSharp.Image.Load(model.ImagePath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save($"wwwroot/images/{appUser.UserName}.jpg");
                    appUser.Image = ($"/images/{appUser.UserName}.jpg");
                    _appUserRepository.Update(appUser);
                    return RedirectToAction("List");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View(model);
            }
        }
        #endregion



        #region Delete
        public IActionResult Delete(int id)
        {
            AppUser appUser = _appUserRepository.GetInt(x => x.Id == id);
            _appUserRepository.Delete(appUser);
            return RedirectToAction("List");
        }
        #endregion
        #region Detail
        public IActionResult Detail(int id)
        {
            return View(_appUserRepository.GetDefault
                (selector: x => new GetAppUserDetailVM
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Image = x.Image,
                    ImagePath = x.ImagePath,
                    Role = x.Role,
                    CreateDate = x.CreateDate
                },
                 expression: x => x.Id == id));
        }
        #endregion
    }
}
