using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationContext _context;
        public MovieController(ApplicationContext context)
        {
            _context = context;
        }
        // GET api/movie
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _context.Movies.Include(m => m.PosterImage).ToList();
            return Ok(movies);           
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _context.Movies.Where(m => m.MovieId == id).Include(m => m.PosterImage).SingleOrDefault();


            return Ok(movie);
        }

        // POST api/movie
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Movie value)
        {
            // Create movie in db logic
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            PosterImage newPoster = new PosterImage();
            value.PosterImageId = await GetMoviePoster(value, newPoster);




            _context.Movies.Add(value);
            _context.SaveChanges();

            Movie insertedMovie = _context.Movies.OrderByDescending(m => m.MovieId).Include(m=> m.PosterImage).First();

            return Ok(insertedMovie);
        }

        private async Task<int> GetMoviePoster(Movie movie, PosterImage posterImage)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "imdb-internet-movie-database-unofficial.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "***REMOVED***");

            string query = HttpUtility.UrlEncode(movie.Title);
            Uri posterRequest = new Uri("https://imdb-internet-movie-database-unofficial.p.rapidapi.com/film/" + query);

            var response = await client.GetAsync(posterRequest);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            JObject jsonString = JObject.Parse(content);
            string imageUrl = jsonString["poster"].ToString();

            posterImage.PosterLink = imageUrl;

            _context.PosterImages.Add(posterImage);
            _context.SaveChanges();

            movie.PlotSynop = jsonString["plot"].ToString();

            var last = _context.PosterImages.OrderByDescending(p => p.PosterImageId).First();
            return last.PosterImageId;
        }


        // PUT api/movie
        [HttpPut]
        public IActionResult Put([FromBody] Movie updatedMovie)
        {
            // Update movie in db logic
            Movie movieToUpdate = _context.Movies.Where(m  =>  m.MovieId == updatedMovie.MovieId).FirstOrDefault();

            // Validation backup Check that incoming isn't empty or null, if it is, set to original value. Allows sending only one input to change.
            movieToUpdate.Title = (updatedMovie.Title == "" || updatedMovie.Title == null) ? movieToUpdate.Title : updatedMovie.Title;
            movieToUpdate.Director = (updatedMovie.Director == "" || updatedMovie.Director == null) ? movieToUpdate.Director : updatedMovie.Director;
            movieToUpdate.Genre = (updatedMovie.Genre == "" || updatedMovie.Genre == null) ? movieToUpdate.Genre : updatedMovie.Genre;
            movieToUpdate.PosterImageId = (updatedMovie.PosterImageId == null) ? movieToUpdate.PosterImageId : updatedMovie.PosterImageId;

            _context.SaveChanges();

            Movie updatedMovieInDb = _context.Movies.Where(m => m.MovieId == updatedMovie.MovieId).Include(m=> m.PosterImage).Single();

            return Ok(updatedMovieInDb);
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete movie from db logic
            return Ok();
        }
    }
}
