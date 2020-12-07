using ChallengeOne.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_GoldBadgeFinalProject
{
    public class UI
    {
        private MenuRepository _menuRepository = new MenuRepository();

        //Method that starts the app
        public void Run()
        {
            SeedMethod();
            Menu();
        }

        //Menu

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options to Manager
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add new meal to menu.\n" +
                    "2. Delete an existing meal from the menu.\n" +
                    "3. Display the existing meals from our menu.\n" +
                    "4. Exit");

                //Get user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new meal to add to the menu
                        CreateNewMeal();
                        break;
                    case "2":
                        //Delete an Existing meal from the menu
                        DeleteExistingMeal();
                        break;
                    case "3":
                        //Display the Existing meals from the menu
                        Console.Clear();
                        DisplayAllMealsOnMenu();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create new meal
        private void CreateNewMeal()
        {
            Console.Clear();
            Meal newMeal = new Meal();

            //Meal Number
            Console.WriteLine("Please enter the number you want to assign to this meal");
            string mealNumberAsInt = Console.ReadLine();
            
            newMeal.MealNumber = int.Parse(mealNumberAsInt);

            //Meal Name
            Console.WriteLine("Please input the name for this meal");
            newMeal.MealName = Console.ReadLine();

            //Meal Description
            Console.WriteLine("please write in a description for this meal");
            newMeal.MealDescription = Console.ReadLine();

            //list of ingredients
            newMeal.ListOfIngredients = new List<string>();

            bool keepAdding = true;
            while (keepAdding) 
            { 
                Console.WriteLine("Please input ingredient");
                string ingredient = Console.ReadLine();
               
                if (!newMeal.ListOfIngredients.Contains(ingredient))
                {
                    newMeal.ListOfIngredients.Add(ingredient);
                }
                else
                {
                    Console.WriteLine("Your ingredient was already on the list so it was not added.");
                }

                bool tryAnotherLetter = true;

                while (tryAnotherLetter) 
                { 
                    Console.WriteLine("Would you like to add another ingredient? Y/N?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer.Contains("n"))
                    {
                        keepAdding = false;
                        tryAnotherLetter = false;
                    }
                    else if (answer.Contains("y"))
                    {
                        keepAdding = true;
                        tryAnotherLetter = false;
                    }
                    else
                    {
                        Console.WriteLine("Not an available input, try again");
                        tryAnotherLetter = true;
                    }
                }

            }
            //price for the meal

            Console.WriteLine("Please enter the price of this meal?");
            newMeal.MealPrice = double.Parse(Console.ReadLine());

            _menuRepository.AddMealToMenu(newMeal);
        }

        //Delete an Existing meal from the menu

        private void DeleteExistingMeal()
        {
            bool areYouSure = true;

            while (areYouSure)
            {

            
               Console.Clear();
                DisplayAllMealsOnMenu();
    
                Console.WriteLine("Enter the Meal Number of the meal you would like to delete");
                int input = int.Parse(Console.ReadLine());
                Meal mealToDelete = _menuRepository.GetMealByNumber(input);

                Console.WriteLine($"Are you sure you want to get rid of {mealToDelete.MealName}? Y/N");
                string userInput = Console.ReadLine();
    
                if (userInput.Contains("y"))
                {
                    _menuRepository.DeleteMenuItem(mealToDelete.MealNumber);
                    Console.WriteLine("Meal was deleted");
                    areYouSure = false;

                }
                else if(userInput.Contains("n"))
                {
                    areYouSure = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please try again.");
                    areYouSure = true;
                }
            }
        }

        //Display all meals from the menu
        private List<Meal> DisplayAllMealsOnMenu()
        {
            Console.Clear();
            List<Meal> mealList = _menuRepository.ReadMenu();
            foreach(Meal meal in mealList)
            {
                Console.WriteLine($"{meal.MealNumber}. {meal.MealName}. ${meal.MealPrice}. Description: {meal.MealDescription}\n" +
                    $"Ingredients in meal:");

                foreach(string ingredient in meal.ListOfIngredients)
                {
                    Console.WriteLine(ingredient);
                }
                Console.WriteLine("\n\n");
            }
            return mealList;
        }

        //Seed Data
        private void SeedMethod()
        {
            Meal whopper = new Meal(1, "Whopper", "Cheeseburger with fries", 5.55);
            Meal salad = new Meal(2, "Chopped salad", "Classic chopped salad", 4.55);
            Meal burrito = new Meal(3, "Burrito", "Mexican classic in a rolled up tortilla", 6.55);

            string cheese = "cheese";
            string tomato = "tomato";
            string buns = "buns";
            string tortilla = "tortilla";
            string burger = "burger";
            string lettuce = "lettuce";


            whopper.ListOfIngredients.Add(cheese);
            whopper.ListOfIngredients.Add(burger);
            whopper.ListOfIngredients.Add(buns);
            salad.ListOfIngredients.Add(tomato);
            salad.ListOfIngredients.Add(lettuce);
            burrito.ListOfIngredients.Add(tortilla);
            burrito.ListOfIngredients.Add(tomato);


            _menuRepository.AddMealToMenu(whopper);
            _menuRepository.AddMealToMenu(salad);
            _menuRepository.AddMealToMenu(burrito);


        }


    }
}
