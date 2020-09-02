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
            Movie movieToUpdate = _context.Movies.Where(m  =>  m.MovieId == updatedMovie.MovieId).FirstOrDefault();

            // Validation backup Check that incoming isn't empty or null, if it is, set to original value. Allows sending only one input to change.
            movieToUpdate.Title = (updatedMovie.Title == "" || updatedMovie.Title == null) ? movieToUpdate.Title : updatedMovie.Title;

            movieToUpdate.Director = (updatedMovie.Director == "" || updatedMovie.Director == null) ? movieToUpdate.Director : updatedMovie.Director;

            movieToUpdate.Genre = (updatedMovie.Genre == "" || updatedMovie.Genre == null) ? movieToUpdate.Genre : updatedMovie.Genre;

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