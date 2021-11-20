using NewsBlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlogProject.Model.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        
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
