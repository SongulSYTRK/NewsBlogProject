using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Admin.Models.VMs
{
    public class GetNewsCastVM
    {
        public int Id { get; set; }

        public string Title { get; set; }
       
        public string Content { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }

        public string CategoryName { get; set; }
        public string  UserFullName { get; set; }


    }
}
