﻿namespace EugenieWeb.Data.Models
{
    using System;

    public class Backup
    {
        public Backup()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FileName { get; set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
