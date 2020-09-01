﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var movies = _context.Movies.ToList();
            return Ok(movies);           
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movieId = _context.Movies.Where(m => m.MovieId == id);
            return Ok(movieId);
        }

        // POST api/movie
        [HttpPost]
        public IActionResult Post([FromBody] Movie value)
        {
            // Create movie in db logic
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            

            _context.Movies.Add(value);
            _context.SaveChanges();

            return Ok();
        }

            

        // PUT api/movie
        [HttpPut]
        public IActionResult Put([FromBody] Movie updatedMovie)
        {
            // Update movie in db logic
            Movie movie = _context.Movies.Where(m  =>  m.MovieId == updatedMovie.MovieId).FirstOrDefault();
            movie.Title = updatedMovie.Title;
            movie.Genre = updatedMovie.Genre;
            movie.Director = updatedMovie.Director;
            _context.SaveChanges();


            return Ok();
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