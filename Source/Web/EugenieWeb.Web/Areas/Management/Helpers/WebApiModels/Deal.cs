namespace EugenieWeb.Web.Areas.Management.Helpers.WebApiModels
{
    using System;
    using System.Collections.Generic;

    public class Deal
    {
        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}