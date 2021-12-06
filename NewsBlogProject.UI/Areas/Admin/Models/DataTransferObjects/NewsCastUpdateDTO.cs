using Microsoft.AspNetCore.Http;
using NewsBlogProject.UI.Areas.Admin.Models.VMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Admin.Models.DataTransferObjects
{
    public class NewsCastUpdateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "must to type into title")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string Title { get; set; }


        [Required(ErrorMessage = "must to type into content")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string Content { get; set; }

        public string Image { get; set; }

        [NotMapped]
        [FileExtensions]
        public IFormFile ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int AppUserId { get; set; }



        //going to users
        public List<GetCategoryVM> Categories { get; set; }


        public List<GetAppUserVM> AppUsers { get; set; }
    }
}
