namespace EugenieWeb.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Backup
    {
        public Backup()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [MaxLength(200)]
        public string FileName { get; set; }

        public double FileSize { get; set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
