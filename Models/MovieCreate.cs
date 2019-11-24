using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieQuery.Models
{
    public class MovieCreate
    {
        public Movie Movie { get; set; }
        public List<Credit> Credit { get; set; }
        public List<Platform> Platform { get; set; }
    }
}
