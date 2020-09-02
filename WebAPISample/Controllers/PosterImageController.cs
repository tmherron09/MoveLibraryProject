using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISample.Data;
using WebAPISample.Models;
using System.IO;

namespace WebApiBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosterImageController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PosterImageController(ApplicationContext context)
        {
            _context = context;
        }


        // PUT: api/PosterImage/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult Post([FromForm] ICollection<IFormFile> file)
        {
            byte[] fileBytes;

            using (var ms = new MemoryStream())
            {
                file.First().CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            var posterMovieId = file.Skip(1).Select(f=> f.ContentDisposition);


            var poster = _context.PosterImages.Where(p => p.PosterImageId == Convert.ToInt32(posterMovieId)).Single();

            poster.ImageData = fileBytes;

            return Ok();
        }

    }
}
