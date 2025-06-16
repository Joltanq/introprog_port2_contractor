using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using introprog_port2_contractor.Models;

namespace introprog_port2_contractor.Services
{
    class ContractorService
    {
        List<Contractor> contractors = new List<Contractor>();
        
        public ContractorService()
        {

            contractors.Add(new Contractor("Bob", "Joe", new DateTime(1991, 01, 01), 100,true));
            contractors.Add(new Contractor("Jane", "Fonda", new DateTime(1985, 05, 01), 100, false));

        }

        public List<Contractor> GetContractors()
        {
            return contractors.ToList();
        }


        public void AddContractor(Contractor newContractor)
        {
            contractors.Add(newContractor); 
        }

        public void RemoveContractor(Contractor oldContractor)
        {
            contractors.Remove(oldContractor);  
        }

    }
}
