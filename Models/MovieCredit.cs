using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieQuery.Models
{
    public class MovieCredit
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CreditId { get; set; }
        public Credit Credit { get; set; }
    }
}
