namespace EugenieWeb.Web.Areas.Management.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using WebApiModels;

    public interface IWebApiClient
    {
        Task<HttpStatusCode> AddOrUpdateAsync(HttpClient client, AddProductModel model);

        Task<IEnumerable<MissingProduct>> GetMissingProductsAsync(HttpClient client);

        ICollection<Report> GetReports(HttpClient client);

        ReportDetailsResponse GetReportDetails(HttpClient client, DateTime date);

        Task<IEnumerable<Seller>> GetSellersAsync(HttpClient client);

        Task<ReportDetailsResponse> GetDealsForSeller(HttpClient client, string username, DateTime start, DateTime end);

        Task<UserInfoResponse> GetUserInfo(HttpClient client);

        Task<HttpStatusCode> WasteProductsAsync(HttpClient client, IEnumerable<IdQuantityPair> model);

        Task<HttpStatusCode> SellProductsAsync(HttpClient client, IEnumerable<IdQuantityPair> model);

        Task<HttpStatusCode> DeleteProductAsync(HttpClient client, string name);
    }
}
