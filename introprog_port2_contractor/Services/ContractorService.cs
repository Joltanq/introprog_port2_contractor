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

            contractors.Add(new Contractor("Bob", "Joe", "asda", 100));
            contractors.Add(new Contractor("Jane", "Fonda", "asda", 100));

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

        public Contractor Search(int id)
        {
            for (int i = 0; i < contractors.Count; i++)
            {
                if (contractors[i].id == id)
                {
                    return contractors[i];
                }
            }return null;
        }
    }
}
