using ComicsApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ComicsApi.Services
{
    public class ComicsService
    {
        public async Task<Comic> GetComics()
        {
            using var httpClient = new HttpClient();

            HttpResponseMessage response;
            do
            {
                var rand = new Random();
                int randomComicNumber = rand.Next(1, 2501);
                response = await httpClient.GetAsync($"https://xkcd.com/{randomComicNumber}/info.0.json");
            } while (response.StatusCode != HttpStatusCode.OK);

            string responseBody = await response.Content.ReadAsStringAsync();
            var comic = JsonConvert.DeserializeObject<Comic>(responseBody);

            return comic;
        }

        public async Task<Comic> GetComic(int id)
        {
            using var httpClient = new HttpClient();
            HttpResponseMessage response;
            response = await httpClient.GetAsync($"https://xkcd.com/{id}/info.0.json");
            string responseBody = await response.Content.ReadAsStringAsync();
            var comic = JsonConvert.DeserializeObject<Comic>(responseBody);

            return comic;
        }
    }
}
