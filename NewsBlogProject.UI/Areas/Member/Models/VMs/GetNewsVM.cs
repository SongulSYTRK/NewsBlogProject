using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Member.Models.VMs
{
    public class GetNewsVM
    {
        public int Id { get; set; }

        public string Title { get; set; }
       
        public string Content { get; set; }

        public string Image { get; set; }

        

        public string CategoryName { get; set; }
        public string  UserFullName { get; set; }


        public string UserImage { get; set; }
        public DateTime? CreateDate { get; set; }

        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
        public List<GetCommentVM> Comments { get; set; }

    }
}
