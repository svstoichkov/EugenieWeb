namespace EugenieWeb.Web.Areas.Management.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using WebApiModels;

    public class WebApiClient : IWebApiClient
    {
        public ICollection<Report> GetReports(HttpClient client)
        {
            var response = client.GetAsync("api/reports").Result;

            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ICollection<Report>>(result);
        }

        public ReportDetailsResponse GetReportDetails(HttpClient client, DateTime date)
        {
            var response = client.GetAsync($"api/reports?date={date.Year}-{date.Month}-{date.Day}").Result;

            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ReportDetailsResponse>(result);
        }

        public async Task<IEnumerable<Seller>> GetSellersAsync(HttpClient client)
        {
            var response = await client.GetAsync("api/sellers");

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Seller>>(result);
        }

        public async Task<ReportDetailsResponse> GetDealsForSeller(HttpClient client, string username, DateTime start, DateTime end)
        {
            var response = await client.GetAsync($"api/deals?username={username}&start={start.Year}-{start.Month}-{start.Day}&end={end.Year}-{end.Month}-{end.Day}");

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReportDetailsResponse>(result);
        }

        public async Task<HttpStatusCode> AddOrUpdateAsync(HttpClient client, AddProductModel model)
        {
            var serialized = JsonConvert.SerializeObject(model);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/products", content);

            return response.StatusCode;
        }

        public async Task<IEnumerable<MissingProduct>> GetMissingProductsAsync(HttpClient client)
        {
            var response = await client.GetAsync($"api/missingProducts");

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<MissingProduct>>(result);
        }

        public async Task<UserInfoResponse> GetUserInfo(HttpClient client)
        {
            var response = await client.GetAsync($"api/account/userinfo");

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserInfoResponse>(result);
        }

        public async Task<HttpStatusCode> WasteProductsAsync(HttpClient client, IEnumerable<IdQuantityPair> model)
        {
            var serialized = JsonConvert.SerializeObject(model);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("api/deals/waste", content);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> SellProductsAsync(HttpClient client, IEnumerable<IdQuantityPair> model)
        {
            var serialized = JsonConvert.SerializeObject(model);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("api/deals/sell", content);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteProductAsync(HttpClient client, string name)
        {
            var response = await client.DeleteAsync($"api/products?name={name}");

            return response.StatusCode;
        }
    }
}