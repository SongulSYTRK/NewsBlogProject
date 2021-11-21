using NewsBlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Admin.Models.VMs
{
    public class GetCategoryVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        
    }
}
