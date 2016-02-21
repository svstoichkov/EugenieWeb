namespace EugenieWeb.Web.Areas.Management.Helpers.WebApiModels
{
    public class Barcode
    {
        public Barcode(string barcode)
        {
            this.Value = barcode;
        }

        public string Value { get; set; }
    }
}