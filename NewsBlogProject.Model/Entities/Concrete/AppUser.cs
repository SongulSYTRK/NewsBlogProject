using Microsoft.AspNetCore.Http;
using NewsBlogProject.Model.Entities.Abstract;
using NewsBlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsBlogProject.Model.Entities.Concrete
{
 public  class AppUser:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public Role Role { get; set; }
        public string Image { get; set; }
        public string XsImage { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }

        public List<NewsCast> NewsCasts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
