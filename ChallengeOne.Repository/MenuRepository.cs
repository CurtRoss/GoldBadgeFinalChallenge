using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Repository
{
    public class MenuRepository
    {
        //Create field to hold all the existing meals
        private readonly List<Meal> _mealMenu = new List<Meal>();

        //Meal Create
        public void AddMealToMenu(Meal meal)
        {
            _mealMenu.Add(meal);
        }

        //Read the Menu
        public List<Meal> ReadMenu()
        {
            return _mealMenu;
        }

        //Delete Menu Item
        public bool DeleteMenuItem(int mealNumber)
        {
            Meal mealToDelete = GetMealByNumber(mealNumber);
            if(mealToDelete == null)
            {
                return false;
            }
            int initialCount = _mealMenu.Count;
            _mealMenu.Remove(mealToDelete);

            if(initialCount > _mealMenu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public Meal GetMealByNumber(int number)
        {
            foreach(Meal meal in _mealMenu)
            {
                if(meal.MealNumber == number)
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
