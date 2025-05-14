using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introprog_port2_contractor.Models
{
    class Contractor
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StartDate { get; set; }
        public int HourlyWage { get; set; }

        // do i need a new attribute to say if it has been assigned? ie isAssigned boolean. once assigned via job service, this updates?

        public Contractor(string firstName, string lastName, string startDate, int hourlyWage)
        {
            
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            HourlyWage = hourlyWage;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {HourlyWage:C}/hr";
        }






    }
}
