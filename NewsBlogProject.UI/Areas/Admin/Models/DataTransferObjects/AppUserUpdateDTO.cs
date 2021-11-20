﻿using Microsoft.AspNetCore.Http;
using NewsBlogProject.Model.Enums;
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
    }
}
