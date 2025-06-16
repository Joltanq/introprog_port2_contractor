using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using introprog_port2_contractor.Models;

namespace introprog_port2_contractor.Services
{
    class JobService
    {
        List<Job> jobs = new List<Job>();

        // creating 2 sample jobs to easily test 
        public JobService()
        {
            jobs.Add(new Job("Plumbing", new DateTime(2024, 01, 01), 100, true, null));
            jobs.Add(new Job("To be complete", new DateTime(2024, 01, 01), 100, false, null));
        }

        public void CreateJob(Job newJob)
        {
            jobs.Add(newJob);
        }

        // function returns all jobs
        public List<Job> GetJobs()
        {
            return jobs.ToList();
        }


        // this takes 2 integer inputs, and is used to return a list of jobs whose jobs fall between the min max cost provided
        public List<Job> Reporting_SearchByCost(int minCost,int maxCost)
        {
            return GetJobs().Where(job =>  job.Cost >= minCost && job.Cost <= maxCost).ToList();
        }

        // function is used to close a job. this returns the contractor back to the pool
        public void CompleteJob(Job completedJob, Contractor finishingContractor)
        {
            completedJob.Completed = true;
            completedJob.ContractorAssigned = null;
            finishingContractor.IsAssigned = false; 

        }

        // when function is called, contractor is assigned to the job.
        // we also update the job so the contractor is maped to the job
        public void AssignJob(Job assignJob,Contractor assignContractor)
        {
            assignJob.ContractorAssigned = assignContractor;
            assignContractor.IsAssigned = true;
        }

       
    }
}
    