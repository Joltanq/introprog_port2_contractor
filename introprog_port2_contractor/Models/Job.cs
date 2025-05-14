using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace introprog_port2_contractor.Models
{
    class Job
    {
        public string Title { get; set; }
        public DateTime JobDate { get; set; }
        public int Cost { get; set; }
        public bool Completed { get; set; }
        public string ContractorAssigned { get; set; }

        public Job(string title, DateTime jobDate, int cost, bool completed, string contractorAssigned)
        {
            Title = title;
            JobDate = jobDate;
            Cost = cost;
            Completed = completed;
            ContractorAssigned = contractorAssigned;
        }

  
       
    }
}