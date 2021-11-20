using AutoMapper; //for profile
using NewsBlogProject.Model.Entities.Concrete;
using NewsBlogProject.UI.Areas.Admin.Models.DataTransferObjects;
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
            CreateMap<AppUser, AppUserCreateDTO>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDTO>().ReverseMap();
        }
        
    }
}
