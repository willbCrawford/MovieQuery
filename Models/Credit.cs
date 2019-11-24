using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieQuery.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { 
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string FullCreditName
        {
            get
            {
                return CreditName + ": " + FullName;
            }
        }

        public string CreditName { get; set; }
        public List<MovieCredit> MovieCredits { get; set; }
    }
}
