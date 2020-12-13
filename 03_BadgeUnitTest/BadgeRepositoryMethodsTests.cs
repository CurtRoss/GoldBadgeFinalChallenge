using _02_BadgeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _03_BadgeUnitTest
{
    [TestClass]
    public class BadgeRepositoryMethodsTests
    {
        private BadgeRepository _badgeRepository;
        private Badge _badge;
        
        

        [TestInitialize]
        public void Arrange()
        {
            //Door one = new Door("one");
            //Door two = new Door("two");
            _badgeRepository = new BadgeRepository();
            _badge = new Badge();

            _badgeRepository.AddBadgeToDictionary(1, _badge);
            //_badgeRepository
        }

        //Add Method
        [TestMethod]
       
        public void AddBadgeToDictionaryShouldBeNotNull()
        {
            //Arrange
            Badge badge = new Badge();
            badge.BadgeNumber = 3;
            BadgeRepository repository = new BadgeRepository();

            //Act
            repository.AddBadgeToDictionary(badge.BadgeNumber, badge);
            Badge badgeFromRepository = repository.GetBadgeByBadgeNumber(3);

            //Assert
            Assert.IsNotNull(badgeFromRepository);
        }

        //Read Method
        [TestMethod]
        public void ReadMethodShouldGetNotNull()
        {
            //Arrange
            Badge badge = new Badge();
            badge.BadgeNumber = 3;
            BadgeRepository repository = new BadgeRepository();

            //Act
            

            //Assert
            Assert.IsNotNull(repository.GetDictionary());
        }

        [TestMethod]
        public void UpdateMethodTestShouldGetTrue()
        {
            //Arrange
            Badge badge = new Badge();
            badge.DoorNames.Add("D4");
            badge.DoorNames.Add("stupid");

            badge.BadgeNumber = 3;
            BadgeRepository repository = new BadgeRepository();
            repository.AddBadgeToDictionary(3, badge);

            Badge newBadge = new Badge();
            newBadge.DoorNames.Add("hello");
            newBadge.DoorNames.Add("IKEA");
            newBadge.BadgeNumber = 1000;




            //Act
            bool updateResult = repository.UpdateBadge(3, newBadge);

            //Assert
            Assert.IsTrue(updateResult);

        }

        [TestMethod]
        public void DeleteMethodTestShouldReturnTrue()
        {
            //Arrange
            Badge badge = new Badge();
            badge.BadgeNumber = 3;
            BadgeRepository repository = new BadgeRepository();
            repository.AddBadgeToDictionary(3, badge);

            //Act


            //Assert
            Assert.IsTrue(repository.DeleteBadgeByBadgeNumber(3));
        }

        [TestMethod]
        public void GetBadgeByBadgeNumberShouldGetNotNull()
        {
            //Arrange
            Badge badge = new Badge();
            badge.BadgeNumber = 3;
            BadgeRepository repository = new BadgeRepository();
            repository.AddBadgeToDictionary(3, badge);

            //Assert
            Assert.IsNotNull(repository.GetBadgeByBadgeNumber(3));
        }
    }
}
