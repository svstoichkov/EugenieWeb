﻿namespace EugenieWeb.Web.Areas.Management.ViewModels.Stores
{
    using System.ComponentModel.DataAnnotations;

    public class AddStoreViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        public string Url { get; set; }
    }
}