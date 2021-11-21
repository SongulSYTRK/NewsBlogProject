using Microsoft.AspNetCore.Http;
using NewsBlogProject.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NewsBlogProject.UI.Areas.Admin.Models.DataTransferObjects
{
    public class AppUserUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "must to type into firstname")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "must to type into lastname")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "must to type into username")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "must to type into password")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Role Role { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }



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
