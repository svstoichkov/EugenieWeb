namespace EugenieWeb.Web.Areas.Management.Helpers.WebApiModels
{
    using System;
    using System.Collections.Generic;

    public class ReportDetailsResponse
    {
        public DateTime Date { get; set; }

        public IEnumerable<Deal> Waste { get; set; }

        public IEnumerable<Deal> Sells { get; set; }

        public IEnumerable<Shipment> Shipments { get; set; }
    }
}