namespace EugenieWeb.Data.Models
{
    using System;

    public class Download
    {
        public Download()
        {
            this.Time = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Ip { get; set; }

        public DateTime Time { get; set; }

        public DownloadTarget Target { get; set; }
    }
}
