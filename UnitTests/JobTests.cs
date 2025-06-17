using introprog_port2_contractor.Services;
using introprog_port2_contractor.Models;


namespace UnitTests
{
    [TestClass]
    public sealed class JobUnitTests
    {
        [TestMethod]
        public void GetJob_ReturnsCollection()
        {
            // Arrange 
            JobService jobService = new([new Job("Plumbing", new DateTime(2024, 01, 01), 100, true, null), new Job("To be complete", new DateTime(2024, 01, 01), 100, false, null)]);


            // Act
            List<Job> jobs = jobService.GetJobs();


            //Assert 
            CollectionAssert.AllItemsAreInstancesOfType(jobs, typeof(Job));

        }

        [TestMethod]
        public void CreateJob_WithValidInputs()
        {
            // Arrange 
            JobService jobService = new();
            Job testJob = new("Plumbing", new DateTime(2024, 01, 01), 100, true, null);


            // Act
            jobService.CreateJob(testJob); 


            //Assert 
            CollectionAssert.Contains(jobService.GetJobs(), testJob);
            // because i created with my parameterless constructor, it comes with 2 default jobs. therefore assert count has to be 3
            Assert.AreEqual(3, jobService.GetJobs().Count); 
        }

        [TestMethod]
        public void ReportingSearch_ReturnsResults()
        {
            // Arrange 
            JobService jobService = new([new Job("Plumbing", new DateTime(2024, 01, 01), 100, true, null), new Job("To be complete", new DateTime(2024, 01, 01), 100, false, null)]);


            // Act
            List<Job> reportinglist =  jobService.Reporting_SearchByCost(0, 500);


            //Assert 
            Assert.AreEqual(2,reportinglist.Count);

        }

        [TestMethod]
        public void ReportingSearch_ReturnsNoResults()
        {
            // Arrange 
            JobService jobService = new([new Job("Plumbing", new DateTime(2024, 01, 01), 100, true, null), new Job("To be complete", new DateTime(2024, 01, 01), 100, false, null)]);


            // Act
            List<Job> reportinglist = jobService.Reporting_SearchByCost(0, 10);


            //Assert 
            Assert.AreEqual(0, reportinglist.Count);

        }

        [TestMethod]
        public void CompleteJob_ReturnsContractorToPool_SetsJobAsComplete_SetsContractorAssignedToNull()
        {
            // Arrange 
            Contractor assignedContractor = new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, true);
            Job jobtobeCompleted = new Job("To be complete", new DateTime(2024, 01, 01), 100, false, assignedContractor);
            JobService jobService = new([jobtobeCompleted]);


            // Act
            jobService.CompleteJob(jobtobeCompleted, assignedContractor);


            //Assert 
            Assert.IsTrue(jobtobeCompleted.Completed);
            Assert.IsFalse(assignedContractor.IsAssigned);
            Assert.AreEqual(null, jobtobeCompleted.ContractorAssigned);
        }

        [TestMethod]
        public void AssignJob_AssignsCorrectContractor()
        {
            // Arrange 
            Contractor assignedContractor = new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, false);
            Job jobtobeCompleted = new Job("To be complete", new DateTime(2024, 01, 01), 100, false, null);
            JobService jobService = new([jobtobeCompleted]);


            // Act
            jobService.AssignJob(jobtobeCompleted, assignedContractor);

            //Assert 
            Assert.AreEqual(assignedContractor, jobtobeCompleted.ContractorAssigned);
        }


        [TestMethod]
        public void AssignJob_AssigningUnavailableContractor()
        {
            // Arrange 
            Contractor assignedContractor = new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, true);
            Job jobtobeCompleted = new Job("To be complete", new DateTime(2024, 01, 01), 100, false, null);
            JobService jobService = new([jobtobeCompleted]);


            // Act
            jobService.AssignJob(jobtobeCompleted, assignedContractor);

            //Assert 
            Assert.IsTrue(assignedContractor.IsAssigned);
            Assert.IsNull(jobtobeCompleted.ContractorAssigned);
        }

        [TestMethod]
        public void AssignJob_CannotAssignContractorIfOneExists()
        {
            // Arrange 
            Contractor assignedContractor = new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, true);
            Contractor secondassignedContractor = new Contractor("Bob", "Joe", new DateTime(1991, 01, 01), 100, false);
            Job jobtobeCompleted = new Job("To be complete", new DateTime(2024, 01, 01), 100, false, assignedContractor);
            JobService jobService = new([jobtobeCompleted]);


            // Act
            jobService.AssignJob(jobtobeCompleted, secondassignedContractor);

            //Assert 
            Assert.AreEqual(assignedContractor, jobtobeCompleted.ContractorAssigned);
            Assert.IsFalse(secondassignedContractor.IsAssigned);
        }


        [TestMethod]
        public void AssignJob_ClosedJobDoesNotAllowContractorAssignment()
        {
            // Arrange 
            Contractor assignedContractor = new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, false);
            Job jobtobeCompleted = new Job("To be complete", new DateTime(2024, 01, 01), 100, true, null);
            JobService jobService = new([jobtobeCompleted]);


            // Act
            jobService.AssignJob(jobtobeCompleted, assignedContractor);

            //Assert 
            Assert.IsNull(jobtobeCompleted.ContractorAssigned);
        }





    }
}
