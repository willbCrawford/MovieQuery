using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieQuery.Models
{
    public class MoviePlatform
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
