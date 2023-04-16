using ComicsApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace DominoesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComicsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetComics()
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

            return Ok(comic);
        }
    }
}
