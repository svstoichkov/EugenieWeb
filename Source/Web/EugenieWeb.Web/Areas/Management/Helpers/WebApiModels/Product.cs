namespace EugenieWeb.Web.Areas.Management.Helpers.WebApiModels
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Measure = MeasureType.бр;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        [MinLength(3)]
        public string Name { get; set; }

        public decimal BuyingPrice { get; set; }

        public decimal? SellingPrice { get; set; }

        public MeasureType Measure { get; set; }

        public decimal? Quantity { get; set; }

        // public ICollection<Barcode> Barcodes { get; set; }

        // public ICollection<ExpirationDate> ExpirationDates { get; set; }
    }
}
