namespace EugenieWeb.Web.Areas.Management.Helpers.WebApiModels
{
    using System;

    public class ExpirationDate
    {
        public ExpirationDate(DateTime date, string batch)
        {
            this.Date = date;
            this.Batch = batch;
        }

        public string Batch { get; set; }

        public DateTime Date { get; set; }
    }
}