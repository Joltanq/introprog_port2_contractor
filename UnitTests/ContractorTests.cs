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

        // there is no point testing adding a constructor with invalid fields as the constructor will not allow me to do so
        [TestMethod]
        public void AddContractor_WithValidFields()
        {
            // Arrange
            ContractorService contractorService = new([new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, true), new Contractor("Jane", "Fonda", new DateTime(1985, 05, 01), 100, false)]);
            Contractor testContractor = new Contractor("Bob", "Joe", new DateTime(1991, 01, 01), 100, true);

            // Act
            contractorService.AddContractor(testContractor);

            // Assert
            // Checks that the contractor has been added to the list 
            CollectionAssert.Contains(contractorService.GetContractors(), testContractor);
            // Checks that the list length is correct
            Assert.AreEqual(3, contractorService.GetContractors().Count);
        }
        
        // system currently allows for duplicate contractors to be added. this tests to ensure functionality is not unintentionally changed in the future
        [TestMethod]
        public void AddContractor_DuplicateContractors()
        {
            // Arrange
            ContractorService contractorService = new([new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, true), new Contractor("Jane", "Fonda", new DateTime(1985, 05, 01), 100, false)]);
            Contractor testContractor = new Contractor("Bob", "Joe", new DateTime(1991, 01, 01), 100, true);

            // Act
            contractorService.AddContractor(testContractor);
            contractorService.AddContractor(testContractor);

            // Assert
            // Checks that the list length is correct
            Assert.AreEqual(4, contractorService.GetContractors().Count);
        }


        [TestMethod]
        public void RemoveContractor_RemovesFromList()
        {
            // Arrange
            Contractor testContractor = new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, true);
            Contractor contractortobeDeleted = new Contractor("Jane", "Fonda", new DateTime(1985, 05, 01), 100, false);
            ContractorService contractorService = new([testContractor,contractortobeDeleted]);
            

            // Act
            contractorService.RemoveContractor(contractortobeDeleted);

            // Assert
            CollectionAssert.DoesNotContain(contractorService.GetContractors(), contractortobeDeleted);
            Assert.AreEqual(1,contractorService.GetContractors().Count);    
        }

        [TestMethod]
        public void RemoveContractor_CannotRemoveAssignedContractor()
        {
            // Arrange
            Contractor testContractor = new Contractor("John", "Cena", new DateTime(1991, 01, 01), 100, true);
            ContractorService contractorService = new([testContractor]);


            // Act
            contractorService.RemoveContractor(testContractor);

            // Assert
            CollectionAssert.Contains(contractorService.GetContractors(), testContractor);
            Assert.AreEqual(1, contractorService.GetContractors().Count);
        }



    }   
}
