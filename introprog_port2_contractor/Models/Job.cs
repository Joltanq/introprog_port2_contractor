using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using introprog_port2_contractor.Models;



namespace introprog_port2_contractor.Models
{
    class Job
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public DateTime JobDate { get; set; }
        public int Cost { get; set; }
        public bool Completed { get; set; }
        public Contractor ContractorsAssigned { get; set; }

   

        public Job(int id, string title, DateTime jobDate, int cost, bool completed, Contractor contractorAssigned)
        {
            Id = id;
            Title = title;
            JobDate = jobDate;
            Cost = cost;
            Completed = completed;
            ContractorsAssigned = contractorAssigned;
        }


        public override string ToString()
        {
            return $"{Title} {JobDate} {Cost} {Completed} {ContractorsAssigned}";
        }


    }
}