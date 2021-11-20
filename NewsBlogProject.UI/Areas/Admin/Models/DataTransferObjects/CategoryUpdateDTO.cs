using NewsBlogProject.Model.Enums;
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

        public DateTime? CreateDate { get; set; }
        public string CreateComputerName { get; set; }
        public string CreateIp { get; set; }


        public DateTime? DeleteDate { get; set; }
        public string DeleteComputerName { get; set; }
        public string DeleteIp { get; set; }


        public DateTime? UpdateDate { get; set; }
        public string UpdateComputerName { get; set; }
        public string UpdateIp { get; set; }

        public Status Status { get; set; }
    }
}
