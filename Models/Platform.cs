using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieQuery.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<MoviePlatform> MoviePlatforms { get; set; }
    }
}
