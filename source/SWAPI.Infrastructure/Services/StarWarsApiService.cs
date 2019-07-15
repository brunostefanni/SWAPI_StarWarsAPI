using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SWAPI.Domain.Entities;

namespace SWAPI.Infrastructure.Services
{
    public class StarWarsApiService
    {
        private const string URL_BASE = "https://swapi.co/api/";
        private const string URL_STARSHIP = "starships";

        public HttpClient Client { get; }

        public StarWarsApiService(HttpClient client)
        {
            client.BaseAddress = new Uri(URL_BASE);
            client.DefaultRequestHeaders.Add("Accept",
                "application/json");

            Client = client;
        }

        public async Task<ServiceRequest> GetStarships(string fullURL = URL_BASE+""+URL_STARSHIP)
        {
            var response = await Client.GetAsync(fullURL);

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<ServiceRequest>();

            return result;
        }

        public async Task<IEnumerable<Starship>> GetStarship(int numberOfStarship)
        {
            var response = await Client.GetAsync($"{URL_BASE}/{URL_STARSHIP}/{numberOfStarship}");

            response.EnsureSuccessStatusCode();
            var result = await response.Content
                .ReadAsAsync<IEnumerable<Starship>>();

            return result;
        }
    }
}
