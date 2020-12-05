using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Repository
{
    public class Meal
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> ListOfIngredients { get; set; }
        public double MealPrice { get; set; }


        public Meal(int mealNumber, string mealName, string mealDescription, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = new List<string>();
            MealPrice = mealPrice;
        }

        public Meal() { }
    }
}
