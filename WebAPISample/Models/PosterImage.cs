using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISample.Models
{
    public class PosterImage
    {

        public int PosterImageId { get; set; }
        public string PosterLink { get; set; }
        [AllowNull]
        public byte[] ImageData { get; set; }

    }
}
