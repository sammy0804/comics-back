using ComicsApi.Model;
using ComicsApi.Model.Responses;
using ComicsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace DominoesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComicsController : ControllerBase
    {
        private readonly List<RatedComic> _ratedComics;
        ComicsService _comicsService;

        public ComicsController (ComicsService comicsService, List<RatedComic> ratedComics)
        {
            _comicsService = comicsService;
            _ratedComics = ratedComics;
        }

        [HttpGet]
        public async Task<IActionResult> GetComics()
        {
            var comic = await _comicsService.GetComics();
            return Ok(comic);
        }

        [HttpPost]
        public async Task<IActionResult> RateComic([FromQuery] int id, [FromQuery] int rate)
        {
            var comic = await _comicsService.GetComic(id);
            _ratedComics.Add(new RatedComic
            {
                Comic= comic,
                Rate=rate
            });
            return NoContent();
        }

        [HttpGet("rated")]
        public IActionResult GetRatedComics()
        {
            return Ok(_ratedComics);
        }
    }
}
