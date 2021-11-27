using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogProject.UI.Areas.Admin.Models.VMs
{
    public class CommentVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Fullname { get; set; }
        public string UserImage { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
