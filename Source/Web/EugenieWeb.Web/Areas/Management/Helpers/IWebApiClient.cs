namespace EugenieWeb.Web.Areas.Management.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using WebApiModels;

    public interface IWebApiClient
    {
        ICollection<Report> GetReports(HttpClient client);

        ReportDetailsResponse GetReportDetails(HttpClient client, DateTime date);

        ICollection<Product> GetProducts(HttpClient client);

        HttpStatusCode AddOrUpdate(HttpClient client, AddProductModel model);

        Task<IEnumerable<MissingProduct>> GetMissingProductsAsync(HttpClient client);

        Task<IEnumerable<Seller>> GetSellersAsync(HttpClient client);

        Task<ReportDetailsResponse> GetDealsForSeller(HttpClient client, string username, DateTime start, DateTime end);

        Task<UserInfoResponse> GetUserInfo(HttpClient client);

        Task<IEnumerable<Product>> GetProductsByNameAsync(HttpClient client, string name, CancellationToken token);

        Task<Product> GetProductById(HttpClient client, int id);

        Task<Product> GetProductByBarcode(HttpClient client, string barcode);

        Task<HttpStatusCode> WasteProductsAsync(HttpClient client, IEnumerable<IdQuantityPair> model);

        Task<HttpStatusCode> SellProductsAsync(HttpClient client, IEnumerable<IdQuantityPair> model);

        Task<IEnumerable<Product>> GetExpiringProductsAsync(HttpClient client, int days);

        Task<IEnumerable<Product>> GetLowQuantityProducts(HttpClient client, decimal quantity);

        HttpStatusCode DeleteProduct(HttpClient client, string name);
    }
}