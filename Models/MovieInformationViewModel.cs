using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieQuery.Models
{
    public class MovieInformationViewModel
    {
        public Movie Movie { get; set; }
        public List<Credit> Credits { get; set; }
        public List<Platform> Platforms { get; set; }
    }
}
