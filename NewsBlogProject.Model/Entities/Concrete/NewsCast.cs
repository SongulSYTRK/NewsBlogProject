using Microsoft.AspNetCore.Http;
using NewsBlogProject.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsBlogProject.Model.Entities.Concrete
{
   public  class NewsCast:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Like>  Like { get; set; }
        public List<Comment> Comment { get; set; }
    }
}
