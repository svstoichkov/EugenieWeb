namespace EugenieWeb.Web.Areas.Management.Helpers
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using WebApiModels;

    public static class ServerTester
    {
        public static HttpClient TestServer(string username, string password, string address)
        {
            var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(address);

                var result = GetTokenAsync(client, username, password);
                if (result)
                {
                    return client;
                }

            return null;
        }

        private static bool GetTokenAsync(HttpClient client, string username, string password)
        {
            try
            {
                var content = new StringContent($"grant_type=password&username={username}&password={password}");
                var response = client.PostAsync("api/account/token", content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var deserializedResult = JsonConvert.DeserializeObject<LoginTokenResponse>(result);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", deserializedResult.access_token);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }
}