namespace EugenieWeb.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Store
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}