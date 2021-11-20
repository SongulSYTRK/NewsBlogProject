using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Admin.Models.DataTransferObjects
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "must to type into name")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string CategoryName { get; set; }


        [Required(ErrorMessage = "must to type into name")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string Description { get; set; }
    }
}
