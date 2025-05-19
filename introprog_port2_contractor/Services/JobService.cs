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
            jobs.Add(new Job(0, "Plumbing", new DateTime(2024,01,01), 100, true, null));
        }

        public void CreateJob(Job newJob)
        {
            jobs.Add(newJob);
        }

        public List<Job> GetJobs()
        {
            return jobs.ToList();  
        }

        public void AssignJob(Job SelectedJob,Contractor ContractorAssigned)
        {
            //jobs.Add(new Job(0, "Plumbing", new DateTime(2024, 01, 01), 100, false, ContractorAssigned));
            //var existingJob = jobs.FirstOrDefault(j => j.Id == SelectedJob.Id);
            //existingJob.Title = SelectedJob.Title;
            //existingJob.Cost = SelectedJob.Cost;   
            //existingJob.ContractorAssigned = ContractorAssigned;
            //existingJob.Completed = SelectedJob.Completed;
      
        }

        public void CompleteJob()
        {
            //needs to return contractor to pool. call remove contractor
        }
    }
}
    