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
            jobs.Add(new Job("Plumbing", new DateTime(2024, 01, 01), 100, true, null));
            jobs.Add(new Job("To be complete", new DateTime(2024, 01, 01), 100, false, null));
        }

        public void CreateJob(Job newJob)
        {
            jobs.Add(newJob);
        }

        public List<Job> GetJobs()
        {
            return jobs.ToList();
        }


        public List<Job> Reporting_SearchByCost(int minCost,int maxCost)
        {
            return GetJobs().Where(job =>  job.Cost >= minCost && job.Cost <= maxCost).ToList();
            //JobReporting.ItemsSource = JobService.GetJobs().Where(j => j.Cost >= mincost && j.Cost <= maxcost).ToList();

        }
    }
}
    