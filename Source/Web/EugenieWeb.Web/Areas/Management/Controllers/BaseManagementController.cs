namespace EugenieWeb.Web.Areas.Management.Controllers
{
    using System.Collections.Generic;
    using System.Net.Http;

    using Data.Models;

    using Helpers;

    using Web.Controllers;

    public class BaseManagementController : BaseController
    {
        public IDictionary<int, HttpClient> Clients { get; set; }

        public HttpClient GetClient(Store store)
        {
            if (this.Clients == null)
            {
                if (this.HttpContext.Cache.Get("clients") == null)
                {
                    this.HttpContext.Cache.Insert("clients", new Dictionary<int, HttpClient>());
                    this.Clients = this.HttpContext.Cache["clients"] as IDictionary<int, HttpClient>;
                }
                else
                {
                    this.Clients = this.HttpContext.Cache["clients"] as IDictionary<int, HttpClient>;
                }
            }

            if (!this.Clients.ContainsKey(store.Id))
            {
                var client = ServerTester.TestServer(store.Username, store.Password, store.Url);
                if (client != null)
                {
                    this.Clients[store.Id] = client;
                    return client;
                }

                return null;
            }

            return this.Clients[store.Id];
        }
    }
}