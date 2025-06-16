using introprog_port2_contractor.Services;
using introprog_port2_contractor.Models;


namespace UnitTests
{
    [TestClass]
    public sealed class ContractorTests
    {
        [TestMethod]
        public void GetContractor_ReturnsCollection()
        {
            // Arrange 
            ContractorService contractorService = new([new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, true), new Contractor("Jane", "Fonda", new DateTime(1985, 05, 01), 100, false)]);


            // Act
            List<Contractor> contractors = contractorService.GetContractors();


            //Assert 
            CollectionAssert.AllItemsAreInstancesOfType(contractors, typeof(Contractor));

        }
    }
}
