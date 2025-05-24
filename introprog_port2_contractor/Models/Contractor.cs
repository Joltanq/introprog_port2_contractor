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
        public DateTime DateOfBirth { get; set; }
        public decimal HourlyWage { get; set; }
        public bool IsAssigned { get; set; }


        public Contractor(string firstName, string lastName, DateTime DateOfBirth, decimal hourlyWage, bool isAssigned)
        {
            
            FirstName = firstName;
            LastName = lastName;
            this.DateOfBirth = DateOfBirth;
            HourlyWage = hourlyWage;
            IsAssigned = isAssigned;
        }

        // overload to create unavailable
        public Contractor(string firstName)
        {

            FirstName = firstName;

        }


        public override string ToString()
        {
            return $"{FirstName} {LastName} - {HourlyWage:C}/hr";
        }






    }
}
