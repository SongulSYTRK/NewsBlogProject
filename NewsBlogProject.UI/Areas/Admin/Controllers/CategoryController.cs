using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsBlogProject.Infrastructure.Repositories.Interface.IEntityTypeRepository;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.Model.Enums;
using NewsBlogProject.UI.Areas.Admin.Models.DataTransferObjects;
using NewsBlogProject.UI.Areas.Admin.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository,
                                   IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }


        #region CREATE CATEGORY


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateDTO model)
        {
            if (ModelState.IsValid)
             {
                //    Category category = new Category();
                //     category.CategoryName= model.CategoryName ;
                //     category.Description= model.Description ;
                var category = _mapper.Map<Category>(model);

                var  cato =_categoryRepository.Any(expression: x => x.CategoryName == model.CategoryName && x.Description==model.Description);
                
                if ( cato != false)
                {
                    ViewData["warning"] = "the category had";
                    return View();
                }
               
                _categoryRepository.Create(category);
                ViewData["Success"] = "the categoryr has been added";
                return View();
             }
            else
            {
                ViewData["Error"] = "the categoryr hasnt been added";
                return View(model);
            }

        }
        #endregion
        #region List
        public IActionResult List(int id)
        {
            return View(_categoryRepository.GetDefaults(selector: x=> new GetCategoryVM
                                                                {
                                                                 Id=x.Id,
                                                                 CategoryName=x.CategoryName,
                                                                 Description=x.Description
                                                                },
                                                                  
                                                         expression: x=>x.Status != Status.Passive));
        }
        #endregion
        #region UPDATE
        [HttpGet]
        public IActionResult Update(int id)
        {

            //*****var category=_categoryRepository.GetDefault
            //instead of 
            var category = _categoryRepository.GetDefault(
                                selector: x => new GetCategoryVM
                                         { Id = x.Id, CategoryName = x.CategoryName, Description = x.Description, }, 
                                expression: x => x.Id == id);
            //CategoryUpdateDTO model = new CategoryUpdateDTO();
            //model.Id = category.Id;
            //model.CategoryName = category.CategoryName;
            //model.Description = category.Description;
            //************getcategoryVM and CategoryUpdateDTO done mapping (Mapper=>mapping)****//
            var model = _mapper.Map<CategoryUpdateDTO>(category);
            ViewData["Success"] = "Successed";
            return View(model);

        }
        [HttpPost]
        public IActionResult Update(CategoryUpdateDTO model)
        {
           // Category category = _categoryRepository.GetDefault(x => x.Id == model.Id);
            if (ModelState.IsValid)
            {
                //category.Id = model.Id;
                //category.CategoryName = model.CategoryName;
                //category.Description = model.Description;
                var category = _mapper.Map<Category>(model);
                _categoryRepository.Update(category);
                ViewData["Success"] = "the categoryr has been update";
                // return RedirectToAction("List");  //I want to see alertmessage. I dont make redirectaction because ViewData dont work other httppage. 
                return View();
            }
            else
            {
                ViewData["Error"] = "the categoryr hasnt been update";
                return View(model);
            }
        }
            #endregion
        #region Delete
            public JsonResult Delete(int id)
            {
            Category category = _categoryRepository.GetInt(x => x.Id == id);
            _categoryRepository.Delete(category);
            
            ViewData["Warning"] = "the categoryr Deleted";
            // return RedirectToAction("List");

            return Json(" ");
            }

      
        #endregion
        #region Detail
        public IActionResult Detail(int id)
        {
            var category = _categoryRepository.GetDefault(selector: x => new GetCategoryDetailVM { Id = x.Id, CategoryName = x.CategoryName, Description = x.Description, Status = x.Status, CreateDate = x.CreateDate }, expression: x => x.Id == id);
            return View(category);
        }
        #endregion
    }
}


