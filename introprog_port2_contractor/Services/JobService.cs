using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using introprog_port2_contractor.Models;

namespace introprog_port2_contractor.Services
{
    class JobService
    {
        List<Job> jobs = new List<Job>();
    
        public JobService()
        {
            jobs.Add(new Job("Plumbing", new DateTime(2024,01,01), 100, true, null));
        }

        public void CreateJob()
        {
    
        }

        public List<Job> GetJobs()
        {
            return jobs.ToList();  
        }

        public void AssignJob(Contractor ContractorAssigned)
        {
            jobs.Add(new Job("Plumbing", new DateTime(2024, 01, 01), 100, false, ContractorAssigned));
        }

        public void CompleteJob()
        {
            //needs to return contractor to pool. call remove contractor
        }
    }
}
    