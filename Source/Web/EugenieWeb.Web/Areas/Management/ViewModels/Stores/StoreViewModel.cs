namespace EugenieWeb.Web.Areas.Management.ViewModels.Stores
{
    using System.ComponentModel.DataAnnotations;

    using Data.Models;

    using Infrastructure.Mapping;

    public class StoreViewModel : IMapFrom<Store>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Url { get; set; }
    }
}