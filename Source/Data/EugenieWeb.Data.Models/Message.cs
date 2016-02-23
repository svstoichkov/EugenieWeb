namespace EugenieWeb.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public Message()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
