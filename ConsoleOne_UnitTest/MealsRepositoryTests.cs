using ChallengeOne.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleOne_UnitTest
{
    [TestClass]
    public class MealsRepositoryTests

    {
        private MenuRepository _repo;
        private Meal _meal;

        [TestInitialize]
        
        public void Arrange()
        {
            _repo = new MenuRepository();
            _meal = new Meal(7, "BurgerBoy", "Best Burger in town", 54);

            _repo.AddMealToMenu(_meal);
        }

        //Add method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange
            Meal meal = new Meal();
            meal.MealName = "Whopper";
            meal.MealNumber = 4;
            MenuRepository repository = new MenuRepository();

            //Act
            repository.AddMealToMenu(meal);
            Meal mealFromDirectory = repository.GetMealByNumber(4);

            //Assert
            Assert.IsNotNull(mealFromDirectory);
        }

        //Read Menu
        [TestMethod]
        public void ReadList_ShouldGetNotNull()
        {
            //Arrange


            //Act
            

            //Assert
            Assert.IsNotNull(_repo.ReadMenu());
        }

        //Delete Meal from Menu
        [TestMethod]
        public void DeleteMeal()
        {
            //Arrange

            //Act
            bool isTrue = _repo.DeleteMenuItem(7);
            //Assert
            Assert.IsTrue(isTrue);
        }

        //Helper method is tested through the last two as they both use the GetMealByNumber()
    }
}
