namespace EugenieWeb.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Download
    {
        public Download()
        {
            this.Time = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ip { get; set; }

        public DateTime Time { get; set; }

        public DownloadTarget Target { get; set; }
    }
}
