using NewsBlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Admin.Models.VMs
{
    public class GetNewsCastDetailVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        
        public string CategoryName { get; set; }

        public string UserFullName { get; set; }
        public string UserImmage { get; set; }
        public DateTime? CreateDate { get; set; }

        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
        public List<CommentVM> Comments { get; set; }
    }
}
