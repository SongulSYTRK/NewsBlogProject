using NewsBlogProject.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Model.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<NewsCast> NewsCasts { get; set; }
    }
}
