using AutoMapper; //for profile
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.UI.Areas.Admin.Models.DataTransferObjects;
using NewsBlogProject.UI.Areas.Admin.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Models.Mapper
{
    public class Mapping : Profile 
    {
        public Mapping()
        {
            /////***We added mapperlibrary. Before We made it one by one by hand.(we lost more time in this process )***////
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            CreateMap<Category, GetCategoryVM>().ReverseMap();
            CreateMap<GetCategoryVM, CategoryUpdateDTO>().ReverseMap();
            CreateMap<Category, GetCategoryDetailVM>().ReverseMap();

            CreateMap<AppUser, AppUserCreateDTO>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDTO>().ReverseMap();
            CreateMap<AppUser, GetAppUserVM>().ReverseMap();
            CreateMap<GetAppUserVM, AppUserUpdateDTO>().ReverseMap();
            CreateMap<AppUser, GetCategoryDetailVM>().ReverseMap();


            CreateMap<NewsCast, NewsCastCreateDTO>().ReverseMap();
            CreateMap<NewsCast, NewsCastUpdateDTO>().ReverseMap();
            CreateMap<NewsCast, GetNewsVM>().ReverseMap();
            CreateMap<GetNewsVM, NewsCastUpdateDTO>().ReverseMap();

            CreateMap<NewsCast, GetNewsVM>().ReverseMap();

            CreateMap<Comment, CommentVM>().ReverseMap();
        }
        
    }
}
