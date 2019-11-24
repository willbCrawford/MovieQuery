using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieQuery.Models
{
    public class MovieCreditPlatfromEdit
    {
        public Movie Movie { get; set; }
        public int CreditId;
        public List<Credit> Credits { get; set; }
        public List<Platform> Platform { get; set; }
    }
}
