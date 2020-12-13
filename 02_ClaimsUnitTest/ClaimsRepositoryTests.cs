using _01_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_ClaimsUnitTest
{
    [TestClass]
    public class ClaimsRepositoryTests
    {
        private ClaimRepository _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim((ClaimType)1, "Big Freaking car Accident", 17000, new DateTime(2019, 12, 12), new DateTime(2019,12,23), true);
            _repo.AddClaimToList(_claim);
        }

        //Create Method
        [TestMethod]
        public void CreateTestMethod()
        {
            //Arrange 
                //Already used AddClaimToList in TI

            //Act (if the claim got added above, it would be the first on the list to be dequeued)
            
            Claim actual = _repo.GetClaimList().Dequeue();

            //Assert
            Assert.AreEqual(_claim, actual);
        }
    }
}
