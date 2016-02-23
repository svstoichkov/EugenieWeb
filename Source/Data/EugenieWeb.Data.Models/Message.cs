namespace EugenieWeb.Data.Models
{
    using System;

    public class Message
    {
        public Message()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
