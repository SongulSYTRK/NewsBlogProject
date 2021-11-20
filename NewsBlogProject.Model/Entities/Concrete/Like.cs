using NewsBlogProject.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Model.Entities.Concrete
{
   public  class Like:BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int NewsCastId { get; set; }
        public NewsCast NewsCast { get; set; }
    }
}
