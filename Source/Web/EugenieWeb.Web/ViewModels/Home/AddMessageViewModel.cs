namespace EugenieWeb.Web.ViewModels.Home
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class AddMessageViewModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("Имейл")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Съдържание")]
        public string Content { get; set; }
    }
}
