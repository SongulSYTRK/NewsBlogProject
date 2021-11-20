﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsBlogProject.Infrastructure.Repositories.Interface.IEntityTypeRepository;
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.Model.Enums;
using NewsBlogProject.UI.Areas.Admin.Models.DataTransferObjects;
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
            _categoryRepository.Create(category);
            return View();
             }
            else
            {
                return View(model);
            }

        }
        #endregion
        #region List
        public IActionResult List(int id)
        {
            return View(_categoryRepository.GetDefaults(x => x.Status != Status.Passive));
        }
        #endregion
        #region UPDATE
        [HttpGet]
        public IActionResult Update(int id)
        {
            Category category = _categoryRepository.GetDefault(x => x.Id == id);
            //CategoryUpdateDTO model = new CategoryUpdateDTO();
            //model.Id = category.Id;
            //model.CategoryName = category.CategoryName;
            //model.Description = category.Description;
            var model = _mapper.Map<CategoryUpdateDTO>(category);
            return View(model);

        }
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
                return RedirectToAction("List");
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
            Category category = _categoryRepository.GetDefault(x => x.Id == id);
            _categoryRepository.Delete(category);
            return RedirectToAction("List");
            }
            #endregion
        }
    }

